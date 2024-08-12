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
            con.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Session["schoolType"] = "國小";
            }
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

        protected void Button1_Click(object sender, EventArgs e)
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
            
            con.Close();

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
            return t1;
        }
    }
}