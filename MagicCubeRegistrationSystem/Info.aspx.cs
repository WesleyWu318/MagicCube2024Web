using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace MagicCubeRegistrationSystem
{
    public partial class Info : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MagicCubeConnectionString"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        
        protected void ShowData()
        {
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            string sql = "SELECT SchoolName, a.SchoolCode, ID, StudentName, TeacherName FROM Student2024 as A, School as b Where a.SchoolCode = b.SchoolCode and a.Kind = '@kind' and b.Kind = a.Kind";
                        
            sql = sql.Replace("@kind", Session["schoolType"].ToString());

            adapt = new SqlDataAdapter(sql, con);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            sql = "SELECT COUNT(*) FROM Student2024 WHERE StudentName IS NOT NULL AND TRIM(StudentName) <> '' AND Kind = '@kind'";

            sql = sql.Replace("@kind", Session["schoolType"].ToString());

            SqlCommand cmdQuery = new SqlCommand(sql, con);
            int count = (int)cmdQuery.ExecuteScalar();

            lblStudentCount.Text = count.ToString();
            lblSchoolKind.Text = Session["schoolType"].ToString();

            
            cmdQuery.Dispose();
            con.Close();
            con.Dispose();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Session["schoolType"] = "國小";
            }

            btnResetPassword.Enabled = false;

            ShowData();
        }

        

        protected void btnJunior_Click(object sender, EventArgs e)
        {
            Session["schoolType"] = "國中"; // 國小            
            ShowData();

        }

        protected void btnEle_Click(object sender, EventArgs e)
        {
            Session["schoolType"] = "國小"; // 國中
            ShowData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnExcel_Click1(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }



        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            string fileName = (Session["schoolType"].ToString() == "國小") ? "ElementaryContestants.xls" : "JuniorContestants.xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                // 如果有分页，取消分页
                GridView1.AllowPaging = false;
               // GridView1.DataBind();


                // 将 DataGrid 渲染为 HTML
                GridView1.RenderControl(hw);

                // 写入到响应中
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            
            con = new SqlConnection(cs);
            con.Open();
                       
            string sqlcmd = "Update RegistrationAccount set Password='@password' where SchoolCode='@schoolCode' and Kind = '@Kind'";
            sqlcmd = sqlcmd.Replace("@password", txtSchoolCode.Text);
            sqlcmd = sqlcmd.Replace("@schoolCode", txtSchoolCode.Text);
            sqlcmd = sqlcmd.Replace("@Kind", ddlKind.SelectedItem.Text);

            SqlCommand cmdUpdate = new SqlCommand(sqlcmd, con);
            cmdUpdate.ExecuteNonQuery();

            lblResetMessage.Text = "修改成功!";
            
            
            cmdUpdate.Dispose();
            con.Close();
            con.Dispose();
        }

        protected void btnKind_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();

            connection.ConnectionString = cs;

            command.Connection = connection;

            if (connection.State != System.Data.ConnectionState.Open) connection.Open();

            string commandString = "SELECT * FROM School where SchoolCode='@SchoolCode'";

            string SchoolCode = txtSchoolCode.Text.Trim();
            commandString = commandString.Replace("@SchoolCode", SchoolCode);

            System.Data.DataTable objDataTable = GetDataTable(connection, commandString);

            ddlKind.Items.Clear();
            btnResetPassword.Enabled = false;

            if (objDataTable.Rows.Count == 0)
            {
                ddlKind.Visible = false;
                lblResetMessage.Text = "查無此學校代碼";                
            }
            else if (objDataTable.Rows.Count == 1)
            {
                System.Data.DataRow objDataRow = objDataTable.Rows[0];
                ddlKind.Items.Add(objDataRow["Kind"].ToString());                
                ddlKind.Visible = true;
                btnResetPassword.Enabled = true;
            }
            else if (objDataTable.Rows.Count == 2)
            {
                ddlKind.Items.Add("國小");
                ddlKind.Items.Add("國中");
                ddlKind.Visible = true;
                btnResetPassword.Enabled = true;
            }

            command.Dispose();
            connection.Close();
            connection.Dispose();

        }

        public System.Data.DataTable GetDataTable(SqlConnection connection, string SQL)
        {
            SqlConnection conn = new SqlConnection(connection.ConnectionString);
            conn.Open();
            string query = SQL;

            SqlCommand cmd = new SqlCommand(query, conn);

            System.Data.DataTable t1 = new System.Data.DataTable();
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(t1);
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();

            return t1;
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void SendEmail()
        {

            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();

            connection.ConnectionString = cs;

            command.Connection = connection;

            if (connection.State != System.Data.ConnectionState.Open) connection.Open();

            string commandString = "Select * From RegistrationAccount where not(TeacherEmail is NULL or TeacherEmail = '')";
                
            System.Data.DataTable objDataTable = GetDataTable(connection, commandString);

            string SchoolCode, Kind, TeacherEmail;

            for ( int i = 0; i < objDataTable.Rows.Count; i++)
            {
                DataRow dataRow = objDataTable.Rows[i];

                SchoolCode = dataRow["SchoolCode"].ToString().Trim();
                Kind = dataRow["Kind"].ToString().Trim();
                TeacherEmail = dataRow["TeacherEmail"].ToString().Trim();

                commandString = "Select TeacherName, StudentName From Student2024 where not(StudentName is NULL or StudentName = '') and SchoolCode = '@SchoolCode' and Kind = '@Kind'";

                commandString = commandString.Replace("@SchoolCode", SchoolCode);
                commandString = commandString.Replace("@Kind", Kind);

                System.Data.DataTable objDataTable2 = GetDataTable(connection, commandString);

                int playerCount = objDataTable2.Rows.Count;

                if (playerCount > 0)
                {
                      

                    try
                    {
                        // 建立 MailMessage 物件，設定寄件者、收件者、主旨及郵件內容
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("haps@ms4.hinet.net");
                        mail.To.Add(TeacherEmail); // 可以新增多個收件者
                        mail.Subject = "臺北市教育局113學年度國中小魔術方塊競賽-本校報名選手資料確認";

                        mail.IsBodyHtml = true;
                        mail.Body = "<table border='1' cellpadding='5' cellspacing='0'>"; // 開始表格

                        // 表格標題
                        mail.Body += "<tr><th>編號</th><th>選手名稱</th><th>老師名稱</th></tr>";

                        for (int j=1; j<= playerCount; j++)
                        {
                            DataRow dataRow2 = objDataTable2.Rows[j];
                            string playerName = dataRow2["StudentName"].ToString();
                            string playerTeacher = dataRow2["TeacherName"].ToString();

                            // 每一行的表格內容
                            mail.Body += $"<tr><td>{j}</td><td>{playerName}</td><td>{playerTeacher}</td></tr>";
                        }

                        // 結束表格
                        mail.Body += "</table>";

                        // 建立 SmtpClient 物件，並設定 SMTP 伺服器的詳細資訊
                        SmtpClient smtpClient = new SmtpClient("msa.hinet.net", 587); // SMTP 伺服器和端口號
                                                                                      //smtpClient.Credentials = new NetworkCredential("your-email@example.com", "your-password"); // 驗證
                                                                                      //smtpClient.EnableSsl = true; // 如果伺服器需要 SSL

                        // 發送郵件
                        smtpClient.Send(mail);
                        Console.WriteLine("郵件已成功發送。");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("發送郵件失敗: " + ex.Message);
                    }

                }
            }            

            command.Dispose();
            connection.Close();
            connection.Dispose();

        }
    }
}