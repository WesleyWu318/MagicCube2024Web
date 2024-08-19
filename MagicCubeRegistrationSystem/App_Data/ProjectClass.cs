using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web;
using System.Runtime.Remoting.Contexts;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class ProjectClass
{
    private System.Collections.ObjectModel.Collection<string> _colTowns;
    private System.Collections.ObjectModel.Collection<string> _colStatus;


    public ProjectClass()
    {
        HttpContext.Current.Application["ThisProject"] = this;
    }

    public void HistoryMessages(string action, string msg, string ip, string sc, string kind)
    {
        SqlConnection connection = new SqlConnection();

        connection.ConnectionString = ConfigurationManager.ConnectionStrings["MagicCubeConnectionString"].ConnectionString;

        if (connection.State != System.Data.ConnectionState.Open) connection.Open();

        string commandSelectString = "SELECT TeacherName FROM RegistrationAccount where SchoolCode='@SchoolCode' and Kind='@Kind'";
        string user = "NULL";

        commandSelectString = commandSelectString.Replace("@SchoolCode", sc);
        commandSelectString = commandSelectString.Replace("@Kind", kind);

        SqlCommand command = new SqlCommand(commandSelectString, connection);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            user = reader["TeacherName"].ToString();
        }

        reader.Close();
        string commandString = "INSERT INTO History (modifyDate, action, message, modifyUser, IP, schoolCode, kind) VALUES ('@modifyDate', '@action', '@message', '@modifyUser', '@IP', '@schoolCode', '@kind')";

        DateTime currentTime = DateTime.Now;

        commandString = commandString.Replace("@modifyDate", currentTime.ToString());
        commandString = commandString.Replace("@action", action);
        commandString = commandString.Replace("@message", msg);
        commandString = commandString.Replace("@modifyUser", user.ToString());
        commandString = commandString.Replace("@IP", ip);
        commandString = commandString.Replace("@schoolCode", sc);
        commandString = commandString.Replace("@kind", kind);


        SqlCommand historyCommand = new SqlCommand(commandString, connection);

        historyCommand.ExecuteNonQuery();
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
    
}