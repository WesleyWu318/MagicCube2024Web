﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
//using Helper;

namespace MagicCubeRegistrationSystem
{
    public partial class Default : System.Web.UI.Page
    {
        string SchoolName = null;
        string cs = ConfigurationManager.ConnectionStrings["MagicCubeConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoginMessage.Text = null;
                ddlKind.Items.Clear();
                ddlKind.Visible = false;
            }
        }

        protected void OK_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();

            connection.ConnectionString = cs;

            command.Connection = connection;
            
            if (ddlKind.Items.Count == 0)
            {
                LoginMessage.Text = "請先按查詢確認校別";
            }
            else 
            {
                string id, kind, password;
                id = txtSchoolName.Text.Trim();
                kind = ddlKind.SelectedItem.Text;
                password = txtPassword.Text.Trim();

                checkSchool(connection, id, kind, password);
            }

            ddlKind.Items.Clear();

        }
        public void AddID(SqlConnection connection, string SchoolCode, string kind)
        {
            SqlConnection conn = connection;
            SqlCommand command = new SqlCommand();

            string commandString = "SELECT ID FROM Student2024 where SchoolCode='@SchoolCode' and Kind='@Kind'";
            commandString = commandString.Replace("@SchoolCode", SchoolCode);
            commandString = commandString.Replace("@Kind", kind);

            System.Data.DataTable objDataTable = GetDataTable(connection, commandString);

            if (objDataTable.Rows.Count == 0)
            {
                for (int i = 1; i <= 6; ++i)
                {
                    string cmdString = "INSERT INTO Student2024 (SchoolCode, Kind, ID, StudentName, TeacherName) VALUES (@SchoolCode, @Kind, @ID, NULL, NULL)";
                    //cmdString = cmdString.Replace("@SchoolCode", SchoolCode);
                    //cmdString = cmdString.Replace("@Kind", Kind);
                    //cmdString = cmdString.Replace("@ID", i.ToString());
                    //SqlCommand cmd = new SqlCommand(cmdString, connection);
                    //cmd.ExecuteNonQuery();
                    using (SqlCommand cmd = new SqlCommand(cmdString, connection))
                    {
                        cmd.Parameters.AddWithValue("@SchoolCode", SchoolCode);
                        cmd.Parameters.AddWithValue("@Kind", kind);
                        cmd.Parameters.AddWithValue("@ID", i.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }

        public void checkSchool(SqlConnection connection, string SchoolCode, string kind, string password)
        {

            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            
            string commandString = "SELECT * FROM RegistrationAccount where SchoolCode='@SchoolCode' and Kind='@Kind'";
            commandString = commandString.Replace("@SchoolCode", SchoolCode);
            commandString = commandString.Replace("@Kind", kind);

            System.Data.DataTable objDataTable = GetDataTable(connection, commandString);

            if (objDataTable.Rows.Count == 0)
            {
                string commandSchoolName = "SELECT SchoolName FROM School where SchoolCode='@SchoolCode' and Kind='@Kind'";
                commandSchoolName = commandSchoolName.Replace("@SchoolCode", SchoolCode);
                commandSchoolName = commandSchoolName.Replace("@Kind", kind);
                System.Data.DataTable SCDataTable = GetDataTable(connection, commandSchoolName);
                System.Data.DataRow SCDataRow = SCDataTable.Rows[0];
                SchoolName = SCDataRow["SchoolName"].ToString();


                string cmdString = "INSERT INTO RegistrationAccount (SchoolCode, Kind, Password, SchoolName, TeacherName, TeacherPhone, TeacherEmail) VALUES (@SchoolCode, @Kind, @Password, @SchoolName, NULL, NULL, NULL)";
                using (SqlCommand cmd = new SqlCommand(cmdString, connection))
                {
                    cmd.Parameters.AddWithValue("@SchoolCode", SchoolCode);
                    cmd.Parameters.AddWithValue("@Kind", kind);
                    cmd.Parameters.AddWithValue("@Password", SchoolCode); // 預設密碼為學校編號
                    cmd.Parameters.AddWithValue("@SchoolName", SchoolName);

                    cmd.ExecuteNonQuery();
                }
            }
            commandString = "SELECT * FROM RegistrationAccount where SchoolCode='@SchoolCode' and Kind='@Kind'";
            commandString = commandString.Replace("@SchoolCode", SchoolCode);
            commandString = commandString.Replace("@Kind", kind);
            //password = txtPassword.Text.Trim();

            objDataTable = GetDataTable(connection, commandString);
            bool isLogin = false;

            if (objDataTable.Rows.Count > 0)
            {
                System.Data.DataRow objDataRow = objDataTable.Rows[0];
                if (objDataRow["Password"].ToString() == password)
                {
                    LoginMessage.Text = objDataRow["SchoolName"].ToString() + "登入成功！";
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
                AddID(connection, SchoolCode, kind);
                Session["SchoolID"] = SchoolCode;
                Session["Kind"] = kind;
                Session["Password"] = password;

                ProjectClass thisProject = new ProjectClass();
                thisProject.HistoryMessages("login", " ", thisProject.getIP(), SchoolCode, kind);

                Response.Redirect("Data.aspx");
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

        protected void btnKind_Click(object sender, EventArgs e)
        {
            
            LoginMessage.Text = "";
            ddlKind.Items.Clear();

            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();

            connection.ConnectionString = cs;

            command.Connection = connection;

            if (connection.State != System.Data.ConnectionState.Open) connection.Open();

            string commandString = "SELECT * FROM School where SchoolCode='@SchoolCode'";

            string SchoolCode = txtSchoolName.Text.Trim();
            commandString = commandString.Replace("@SchoolCode", SchoolCode);

            System.Data.DataTable objDataTable = GetDataTable(connection, commandString);

            if (objDataTable.Rows.Count == 0)
            {
                ddlKind.Visible = false;
                LoginMessage.Text = "查無此學校代碼";
            }
            else if (objDataTable.Rows.Count == 1)
            {
                System.Data.DataRow objDataRow = objDataTable.Rows[0];
                ddlKind.Items.Add(objDataRow["Kind"].ToString());
                SchoolName = objDataRow["SchoolName"].ToString();
                ddlKind.Visible = true;
            }
            else if (objDataTable.Rows.Count == 2)
            {
                ddlKind.Items.Add("國小");
                ddlKind.Items.Add("國中");
                ddlKind.Visible = true;
            }
        }

    }

}