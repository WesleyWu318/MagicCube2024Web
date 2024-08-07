using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MagicCubeRegistrationSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OK_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();

            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MagicCubeConnectionString"].ConnectionString;
            command.Connection = connection;

            if (connection.State != System.Data.ConnectionState.Open) connection.Open();

            //if (connection.State == System.Data.ConnectionState.Open)
            //{
            //    Response.Write("<script>alert('數據庫連接成功! ');</script>");
            //}
            //else
            //{
            //    Response.Write("<script>alert('數據庫連接失敗! ');</script>");
            //}

            string commandString = "SELECT * FROM RegistrationAccount where SchoolCode='@SchoolCode'";

            string id, password;
            id = txtSchoolName.Text.Trim();
            password = txtPassword.Text.Trim();
            bool isLogin = false;

            commandString = commandString.Replace("@SchoolCode", id);

            System.Data.DataTable objDataTable = GetDataTable(connection, commandString);

            if (objDataTable.Rows.Count > 0)
            {
                System.Data.DataRow objDataRow = objDataTable.Rows[0];

                if (objDataRow["Password"].ToString() == password)
                {
                    LoginMessage.Text = objDataRow["SchoolName"].ToString() + "登入成功!";
                    isLogin = true;


                }
                else
                {
                    LoginMessage.Text = "密碼錯誤";
                }

            }
            else
            {
                LoginMessage.Text = "查無此學校代碼";
            }


            if (isLogin)
            {
                AddID(connection, id);

                commandString = "SELECT ID FROM RegistrationAccount where SchoolCode='@SchoolCode'";

                Session["School ID"] = id;

                Response.Redirect("WebForm2.aspx");

            }

            //connection.Close();



        }

        public void AddID(SqlConnection connection, string sc)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            string commandString = "SELECT ID FROM Student2024 where SchoolCode='@SchoolCode'";
            commandString = commandString.Replace("@SchoolCode", sc);

            System.Data.DataTable objDataTable = GetDataTable(connection, commandString);

            if (objDataTable.Rows.Count == 0)
            {
                for(int i=1; i<=6; i++)
                {
                    string cmd = "INSERT INTO Student2024 (SchoolCode, ID, StudentName, TeacherName) VALUES (@SchoolCode, @ID, NULL, NULL)";

                    cmd = cmd.Replace("@SchoolCode", sc);
                    cmd = cmd.Replace("@ID", i.ToString());

                    SqlCommand IDCommand = new SqlCommand(cmd, connection);

                    IDCommand.ExecuteNonQuery();

                }
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