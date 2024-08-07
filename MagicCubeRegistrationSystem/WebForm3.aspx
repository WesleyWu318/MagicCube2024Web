<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="MagicCubeRegistrationSystem.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
    <div style="height: 413px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="GridView1_RowCancelingEdit"

OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="SchoolCode,ID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SchoolCode">
                    <ItemTemplate>
                        <asp:Label ID="lbl_SchoolCode" runat="server" Text='<%#Eval("SchoolCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="StudentName">
                    <ItemTemplate>
                        <asp:Label ID="lbl_StudentName" runat="server" Text='<%#Eval("StudentName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_StudentName" runat="server" Text='<%#Eval("StudentName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TeacherName">
                    <ItemTemplate>
                        <asp:Label ID="lbl_TeacherName" runat="server" Text='<%#Eval("TeacherName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_TeacherName" runat="server" Text='<%#Eval("TeacherName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
<%--                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField ID="SchoolCode" DataField="SchoolCode" HeaderText="SchoolCode" ReadOnly="True" SortExpression="SchoolCode" />
                <asp:BoundField ID="ID" DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField ID="StudentName" DataField="StudentName" HeaderText="StudentName" SortExpression="StudentName" />
                <asp:BoundField ID="TeacherName" DataField="TeacherName" HeaderText="TeacherName" SortExpression="TeacherName" />--%>
            </Columns>
            <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>
            <RowStyle BackColor="#e7ceb6"/>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=LAPTOP-TN1KHR01;Initial Catalog=MagicCube;User ID=admin;Password=magiccube" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Student2024]"></asp:SqlDataSource>
    </div>
</form>
</body>
</html>