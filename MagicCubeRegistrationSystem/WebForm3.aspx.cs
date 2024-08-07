using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace MagicCubeRegistrationSystem
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        //Connection String from web.config File
        string cs = ConfigurationManager.ConnectionStrings["MagicCubeConnectionString"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }
        //ShowData method for Displaying Data in Gridview
        protected void ShowData()
        {
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("Select SchoolCode,ID,StudentName,TeacherName from Student2024", con);
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}