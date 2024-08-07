<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MagicCubeRegistrationSystem.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server"   >
        <div class="jumbotron">          
            <h2 for="txtSchoolName"> 學校代碼 <asp:TextBox ID="txtSchoolName" runat="server" Font-Size="Small" Height="27px" Width="195px" ></asp:TextBox>
            </h2>
            <h2>密碼&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPassword" runat="server" Font-Size="Small" Height="27px" Width="195px"></asp:TextBox>
            </h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp;<asp:Button ID="OK" runat="server" Text="確認" Width="92px" OnClick="OK_Click" />
            <br></br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LoginMessage" runat="server" Width="144px"></asp:Label>
        </div>
        <div>
        <input type="submit" value="Submit" />
        </div>
    </form>
</body>
</html>
