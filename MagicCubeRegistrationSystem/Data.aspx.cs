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

namespace MagicCubeRegistrationSystem
{
    public partial class Data : System.Web.UI.Page
    {
        // table
        string cs = ConfigurationManager.ConnectionStrings["MagicCubeConnectionString"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        string passcode;

        protected void ShowData()
        {
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            string sql = "Select SchoolCode,ID,StudentName,TeacherName from Student2024 where SchoolCode='@SchoolCode' and Kind='@kind'";
            string SchoolCode = lblSchoolCode.Text;
            sql = sql.Replace("@SchoolCode", SchoolCode);
            sql = sql.Replace("@kind", Session["kind"].ToString());

            adapt = new SqlDataAdapter(sql, con);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            con.Close();
        }
        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.
            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
        }

        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update
            string kind = Session["kind"].ToString();     
            string schoolCode = Session["SchoolID"].ToString();

            ProjectClass thisProject = new ProjectClass();
            thisProject.HistoryMessages("modify", "student infomation", thisProject.getIP(), schoolCode, kind);
            
            Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox studentName = GridView1.Rows[e.RowIndex].FindControl("txt_StudentName") as TextBox;
            TextBox teacherName = GridView1.Rows[e.RowIndex].FindControl("txt_TeacherName") as TextBox;
            con = new SqlConnection(cs);
            con.Open();
            //updating the record
            string sqlcmd = "Update Student2024 set studentName='@studentName', TeacherName='@teacherName' where ID='@id' and SchoolCode='@schoolCode' and Kind='@kind'";
            sqlcmd = sqlcmd.Replace("@studentName", studentName.Text);
            sqlcmd = sqlcmd.Replace("@teacherName", teacherName.Text);
            sqlcmd = sqlcmd.Replace("@id", id.Text);
            sqlcmd = sqlcmd.Replace("@schoolCode", schoolCode);
            sqlcmd = sqlcmd.Replace("@kind", kind);
            SqlCommand cmd = new SqlCommand(sqlcmd, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data
            ShowData();
        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview
            GridView1.EditIndex = -1;
            ShowData();
        }

        public void ShowAllPostBackData()
        {

            string[] keys = Request.Form.AllKeys;
            Literal ctlAllPostbackData = new Literal();
            ctlAllPostbackData.Text = "<div class='well well-lg' style='border:1px solid black;z-index:99999;position:absolute;'><h3>All postback data:</h3><br />";
            for (int i = 0; i < keys.Length; i++)
            {
                ctlAllPostbackData.Text += "<b>" + keys[i] + "</b>: " + Request[keys[i]] + "<br />";
            }
            ctlAllPostbackData.Text += "</div>";
            this.Controls.Add(ctlAllPostbackData);

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            passcode = Session["password"].ToString();

            if (!IsPostBack)
            {

                if (Session["SchoolID"].ToString() == "333603") btnManager.Visible = true;
                else btnManager.Visible = false;
                
                string SchoolID = Session["SchoolID"].ToString();
                string kind = Session["kind"].ToString();
                passcode = Session["password"].ToString();
                lblSchoolCode.Text = SchoolID;
                txtPassword.Text = setPassword();
                Session["password"] = passcode;
                txtPassword.Enabled = false;

                ShowData();
                SqlConnection connection = new SqlConnection();
                SqlCommand command = new SqlCommand();

                connection.ConnectionString = cs;

                command.Connection = connection;

                if (connection.State != System.Data.ConnectionState.Open) connection.Open();
                
                
                string commandString = "SELECT * FROM RegistrationAccount where SchoolCode='@SchoolCode' and Kind='@Kind'";
                string id;
                id = lblSchoolCode.Text.Trim();
                commandString = commandString.Replace("@SchoolCode", id);
                commandString = commandString.Replace("@Kind", kind);

                System.Data.DataTable objDataTable = GetDataTable(connection, commandString);

                if (objDataTable.Rows.Count > 0)
                {
                    System.Data.DataRow objDataRow = objDataTable.Rows[0];

                    lblSchoolName.Text = objDataRow["SchoolName"].ToString();
                    txtTeacherName.Text = objDataRow["TeacherName"].ToString();
                    txtTeacherPhone.Text = objDataRow["TeacherPhone"].ToString();
                    txtTeacherEmail.Text = objDataRow["TeacherEmail"].ToString();
                    txtTeacherTitle.Text = objDataRow["TeacherTitle"].ToString();
                }
            }
                        
        }

        protected void OK_Click(object sender, EventArgs e)
        {
            string schoolCode = Session["SchoolID"].ToString();
            string kind = Session["kind"].ToString();

            ProjectClass thisProject = new ProjectClass();
            thisProject.HistoryMessages("modify", "teacher infomation", thisProject.getIP(), schoolCode, kind);

            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MagicCubeConnectionString"].ConnectionString;

            connection.Open();
            string commandString = "update RegistrationAccount set TeacherName = '@TeacherName', TeacherTitle = '@TeacherTitle', TeacherPhone = '@TeacherPhone', TeacherEmail = '@TeacherEmail' where SchoolCode = '@SchoolCode' and Kind = '@Kind'";
            
            commandString = commandString.Replace("@TeacherName", txtTeacherName.Text.Trim());
            commandString = commandString.Replace("@TeacherTitle", txtTeacherTitle.Text.Trim());
            commandString = commandString.Replace("@TeacherPhone", txtTeacherPhone.Text.Trim());
            commandString = commandString.Replace("@TeacherEmail", txtTeacherEmail.Text.Trim());
            commandString = commandString.Replace("@SchoolCode", lblSchoolCode.Text.Trim());
            commandString = commandString.Replace("@Kind", kind);

            SqlCommand command = new SqlCommand(commandString, connection);

            command.ExecuteNonQuery();

            connection.Close();

            string message = "請輸入聯絡人: ";
            bool isNull = false;

            if(txtTeacherName.Text == "")
            {
                if(isNull)
                {                    
                    message += " ";
                }
                message += "姓名";
                isNull = true;
            }
            if (txtTeacherPhone.Text == "")
            {
                if (isNull)
                {                    
                    message += " ";
                }
                message += "電話";
                isNull = true;
            }
            if (txtTeacherTitle.Text == "")
            {
                if (isNull)
                {                    
                    message += " ";
                }
                message += "職稱";
                isNull = true;
            }
            if (txtTeacherEmail.Text == "")
            {
                if (isNull)
                {                    
                    message += " ";
                }
                message += "信箱";
                isNull = true;
            }
            if(!isNull) message = "修改成功";

            lblErrorMessage.Text = message;
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

        

        public string getIP()
        {
            string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (ipAddress == "::1")
            {
                ipAddress = "127.0.0.1";
            }

            return ipAddress;

        }

        protected void btnPassEdit_Click(object sender, EventArgs e)
        {
            btnPassEdit.Visible = false;
            btnPassUpdate.Visible = true;
            btnPassCancel.Visible = true;
            txtPassword.Text = passcode;
            txtPassword.Enabled = true;
            PasswordMessage.Text = "";
            //txtPassword.TextMode = TextBoxMode.Password;

        }

        protected void btnPassUpdate_Click(object sender, EventArgs e)
        {
            btnPassEdit.Visible = true;
            btnPassUpdate.Visible = false;
            btnPassCancel.Visible = false;
            txtPassword.Enabled = false;

            string SchoolCode = Session["SchoolID"].ToString();

            passcode = txtPassword.Text;
            string SchoolID = Session["SchoolID"].ToString();
            string kind = Session["kind"].ToString();
            Session["password"] = passcode;

            //check password
            if (passcode == SchoolCode)
            {
                PasswordMessage.Text = "密碼不能與預設密碼相同";
                txtPassword.Text = setPassword();
            }
            else
            {

                ProjectClass thisProject = new ProjectClass();
                thisProject.HistoryMessages("modify", "password", thisProject.getIP(), SchoolCode, kind);

                PasswordMessage.Text = "密碼修改成功";
                con = new SqlConnection(cs);
                con.Open();

                string sqlcmd = "Update RegistrationAccount set Password='@password' where SchoolCode='@schoolCode' and Kind = '@Kind'";
                sqlcmd = sqlcmd.Replace("@password", passcode);
                sqlcmd = sqlcmd.Replace("@schoolCode", SchoolID);
                sqlcmd = sqlcmd.Replace("@Kind", kind);

                SqlCommand cmd = new SqlCommand(sqlcmd, con);
                cmd.ExecuteNonQuery();
                con.Close();
                txtPassword.Text = setPassword();
            }

        }

        protected void btnPassCancel_Click(object sender, EventArgs e)
        {
            btnPassEdit.Visible = true;
            btnPassUpdate.Visible = false;
            btnPassCancel.Visible = false;
            txtPassword.Text = setPassword();
            txtPassword.Enabled = false;
            //txtPassword.TextMode = TextBoxMode.Password;
        }

        protected string setPassword()
        {
            string temp = "";
            for (int i = 0; i < passcode.Length; ++i)
            {
                temp += "*";
            }
            return temp;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnManager_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Info.aspx");
        }
    }
}