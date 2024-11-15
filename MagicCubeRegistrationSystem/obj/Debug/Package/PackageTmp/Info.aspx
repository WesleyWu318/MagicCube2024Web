<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="MagicCubeRegistrationSystem.Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h2>重設帳號密碼</h2>
            <h2>
            <asp:Label ID="lblSchoolCode" runat="server" Text="學校代號"></asp:Label>           　
            <asp:TextBox ID="txtSchoolCode" runat="server"></asp:TextBox>　
            <asp:Button ID="btnKind" runat="server" Text="查詢" OnClick="btnKind_Click" class="btn btn-primary"/>
            <asp:DropDownList ID="ddlKind" runat="server" AutoPostBack="True" ></asp:DropDownList>
            &nbsp;</h2>
            <h2>
            
            <asp:Button ID="btnResetPassword" runat="server" Text="重置密碼" OnClick="btnResetPassword_Click" />
            <asp:Label ID="lblResetMessage" runat="server" Text=""></asp:Label>
            </h2>
            <p>&nbsp;</p>
        <h2>報名選手彙整&nbsp;</h2>
        </div>
        <asp:Button ID="btnEle" runat="server" Text="國小" OnClick="btnEle_Click" />　　
        <asp:Button ID="btnJunior" runat="server" Text="國中" OnClick="btnJunior_Click" />　　　　　　<asp:Button ID="btnExcel" runat="server" OnClick="btnExcel_Click1" Text="匯出到EXCEL" />
&nbsp;<asp:Button ID="btnSendEmail" runat="server" OnClick="btnSendEmail_Click" style="margin-left: 57px" Text="傳送Email" Visible="False" />
        <br />
        <br />
        <asp:Label ID="lblSchoolKind" runat="server" Text="Label"></asp:Label>
        報名人數:
        <asp:Label ID="lblStudentCount" runat="server" Text="Label"></asp:Label>
&nbsp;人<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="SchoolName" HeaderText="學校名稱" SortExpression="SchoolName" />
                <asp:BoundField DataField="SchoolCode" HeaderText="學校代碼" SortExpression="SchoolCode" />
                <asp:BoundField DataField="ID" HeaderText="學生ID" SortExpression="ID" />
                <asp:BoundField DataField="StudentName" HeaderText="學生名稱" SortExpression="StudentName" />
                <asp:BoundField DataField="TeacherName" HeaderText="指導老師" SortExpression="TeacherName" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MagicCubeConnectionString %>" SelectCommand="SELECT  SchoolName, a.SchoolCode, ID, StudentName, TeacherName FROM Student2024 as A, School as b Where a.SchoolCode = b.SchoolCode and a.Kind = '國小' and b.Kind = a.Kind
"></asp:SqlDataSource>
        <br />

    </form>
</body>
</html>
