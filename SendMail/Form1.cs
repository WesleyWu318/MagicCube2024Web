using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            SendEmail();
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

        private void SendEmail()
        {

            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();

            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MagicCubeConnectionString"].ConnectionString;

            command.Connection = connection;

            if (connection.State != System.Data.ConnectionState.Open) connection.Open();

            string commandString = "Select * From RegistrationAccount where not(TeacherEmail is NULL or TeacherEmail = '')";

            System.Data.DataTable objDataTable = GetDataTable(connection, commandString);

            string SchoolCode, Kind, TeacherEmail;

            for (int i = 0; i < objDataTable.Rows.Count; i++)
            {
                DataRow dataRow = objDataTable.Rows[i];

                string strSchoolCode = dataRow["SchoolCode"].ToString().Trim();
                string strKind = dataRow["Kind"].ToString().Trim();
                string schoolName = dataRow["SchoolName"].ToString().Trim();

                TeacherEmail = dataRow["TeacherEmail"].ToString().Trim();

                string strCommandString = "Select TeacherName, StudentName From Student2024 where not(StudentName is NULL or StudentName = '') and SchoolCode = '@SchoolCode' and Kind = '@Kind'";

                strCommandString = strCommandString.Replace("@SchoolCode", strSchoolCode);
                strCommandString = strCommandString.Replace("@Kind", strKind);

                System.Data.DataTable objDataTable2 = GetDataTable(connection, strCommandString);

                int playerCount = objDataTable2.Rows.Count;

                if (playerCount > 0)
                {

                    try
                    {
                        // 建立 MailMessage 物件，設定寄件者、收件者、主旨及郵件內容
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("biau@ms4.hinet.net");
                        mail.To.Add(TeacherEmail); // 可以新增多個收件者
                        mail.To.Add("manyoyoyo666@gmail.com");
                        mail.Subject = $"臺北市教育局113學年度國中小魔術方塊競賽-{schoolName}報名選手資料確認表";

                        mail.IsBodyHtml = true;
                        mail.SubjectEncoding = Encoding.UTF8; // 設定主題的編碼
                        mail.BodyEncoding = Encoding.UTF8; // 設定內容的編碼

                        mail.Body = "<table border='1' cellpadding='5' cellspacing='0'>"; // 開始表格

                        // 表格標題
                        mail.Body += "<tr><th>編號</th><th>選手名稱</th><th>老師名稱</th></tr>";

                        for (int j = 1; j <= playerCount; j++)
                        {
                            DataRow dataRow2 = objDataTable2.Rows[j-1];
                            string playerName = dataRow2["StudentName"].ToString();
                            string playerTeacher = dataRow2["TeacherName"].ToString();

                            // 每一行的表格內容
                            mail.Body += $"<tr><td>{j}</td><td>{playerName}</td><td>{playerTeacher}</td></tr>";
                        }

                        // 結束表格
                        mail.Body += "</table>";

                        // 建立 SmtpClient 物件，並設定 SMTP 伺服器的詳細資訊
                        SmtpClient smtpClient = new SmtpClient("msa.hinet.net", 587); // SMTP 伺服器和端口號
                        
                        smtpClient.Send(mail);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("發送郵件失敗: " + ex.Message);
                    }

                }
            }

            MessageBox.Show("郵件已成功發送完畢。");

            command.Dispose();
            connection.Close();
            connection.Dispose();

        }

    }

    
}
