using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace _2024MagicCube
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MagicCubeConnectionString"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string[] keys = Request.Form.AllKeys;
                //ShowAllPostBackData(keys);

                string SchoolID = Session["SchoolID"].ToString();
                lblSchoolCode2.Text = SchoolID;

                ShowData();
                SqlConnection connection = new SqlConnection();
                SqlCommand command = new SqlCommand();

                // connection.ConnectionString = "Data Source=LAPTOP-TN1KHR01;Initial Catalog=MagicCube;Integrated Security=SSPI;";
                connection.ConnectionString = "Data Source=LAPTOP-TN1KHR01;Initial Catalog=MagicCube;User Id=admin;Password=magiccube;";

                command.Connection = connection;

                if (connection.State != System.Data.ConnectionState.Open) connection.Open();

                //if (connection.State == System.Data.ConnectionState.Open)
                //    Response.Write("<script>alert('數據庫連接成功! ');</script>");
                //else
                //    Response.Write("<script>alert('數據庫連接失敗! ');</script>");

                string commandString = "SELECT * FROM RegistrationAccount where SchoolCode='@SchoolCode'";
                string id;
                id = lblSchoolCode2.Text.Trim();
                commandString = commandString.Replace("@SchoolCode", id);

                System.Data.DataTable objDataTable = GetDataTable(connection, commandString);

                if (objDataTable.Rows.Count > 0)
                {
                    System.Data.DataRow objDataRow = objDataTable.Rows[0];

                    lblSchoolName.Text = objDataRow["SchoolName"].ToString();
                    txtTeacherName.Text = objDataRow["TeacherName"].ToString();
                    txtTeacherPhone.Text = objDataRow["TeacherPhone"].ToString();
                    txtTeacherEmail.Text = objDataRow["TeacherEmail"].ToString();
                }

            }
        }

        protected void OK_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();

            // connection.ConnectionString = "Data Source=LAPTOP-TN1KHR01;Initial Catalog=MagicCube;Integrated Security=SSPI;";
            connection.ConnectionString = "Data Source=LAPTOP-TN1KHR01;Initial Catalog=MagicCube;User Id=admin;Password=magiccube;";

            command.Connection = connection;

            if (connection.State != System.Data.ConnectionState.Open) connection.Open();

            //if (connection.State == System.Data.ConnectionState.Open)
            //    Response.Write("<script>alert('數據庫連接成功! ');</script>");
            //else
            //    Response.Write("<script>alert('數據庫連接失敗! ');</script>");

            Label SchoolCode = form1.FindControl("lblSchoolCode2") as Label;
            TextBox TeacherName = form1.FindControl("txtTeacherName") as TextBox;
            TextBox TeacherPhone = form1.FindControl("txtTeacherPhone") as TextBox;
            TextBox TeacherEmail = form1.FindControl("txtTeacherEmail") as TextBox;
            //updating the record
            string sqlcmd = "Update RegistrationAccount set TeacherName='@TeacherName', TeacherPhone='@TeacherPhone', TeacherEmail='@TeacherEmail' where SchoolCode='@SchoolCode'";
            sqlcmd = sqlcmd.Replace("@TeacherName", TeacherName.Text);
            sqlcmd = sqlcmd.Replace("@TeacherPhone", TeacherPhone.Text);
            sqlcmd = sqlcmd.Replace("@TeacherEmail", TeacherEmail.Text);
            sqlcmd = sqlcmd.Replace("@SchoolCode", SchoolCode.Text);
            SqlCommand cmd = new SqlCommand(sqlcmd, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview
            //GridView1.EditIndex = -1;
        }

        public void ShowAllPostBackData(string[] keys)
        {
            //string[] keys = Request.Form.AllKeys;
            Literal ctlAllPostbackData = new Literal();
            ctlAllPostbackData.Text = "<div class='well well-lg' style='border:1px solid black;z-index:99999;position:absolute;'><h3>All postback data:</h3><br />";
            for (int i = 0; i < keys.Length; i++)
            {
                ctlAllPostbackData.Text += "<b>" + keys[i] + "</b>: " + Request[keys[i]] + "<br />";
            }
            ctlAllPostbackData.Text += "</div>";
            this.Controls.Add(ctlAllPostbackData);
        }

        public System.Data.DataTable GetDataTable(SqlConnection connection, string SQL)
        {
            // SqlConnection conn = new SqlConnection(connection.ConnectionString);
            SqlConnection conn = connection;
            // conn.Open();
            string query = SQL;

            SqlCommand cmd = new SqlCommand(query, conn);

            System.Data.DataTable t1 = new System.Data.DataTable();
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(t1);
            }
            return t1;
        }

        protected void ShowData()
        {
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            string cmdadapt = "Select SchoolCode,ID,StudentName,TeacherName from Student2024 where SchoolCode='@SchoolCode'";
            cmdadapt = cmdadapt.Replace("@SchoolCode", Session["SchoolID"].ToString());
            adapt = new SqlDataAdapter(cmdadapt, con);
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
            Label schoolCode = GridView1.Rows[e.RowIndex].FindControl("lbl_SchoolCode") as Label;
            Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox studentName = GridView1.Rows[e.RowIndex].FindControl("txt_StudentName") as TextBox;
            TextBox teacherName = GridView1.Rows[e.RowIndex].FindControl("txt_TeacherName") as TextBox;
            con = new SqlConnection(cs);
            con.Open();
            //updating the record
            string sqlcmd = "Update Student2024 set studentName='@studentName', TeacherName='@teacherName' where ID='@id' and SchoolCode='@schoolCode'";
            sqlcmd = sqlcmd.Replace("@studentName", studentName.Text);
            sqlcmd = sqlcmd.Replace("@teacherName", teacherName.Text);
            sqlcmd = sqlcmd.Replace("@id", id.Text);
            sqlcmd = sqlcmd.Replace("@schoolCode", schoolCode.Text);
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

    }
}