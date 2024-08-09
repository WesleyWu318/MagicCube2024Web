<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="_2024MagicCube.WebForm2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h2>學校代碼:&nbsp;
                <asp:Label ID="lblSchoolCode2" runat="server" Text="Label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 校名:&nbsp;
                <asp:Label ID="lblSchoolName" runat="server" Text="Label"></asp:Label>
            </h2>
             <h2>聯絡人&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTeacherName" runat="server" Font-Size="Large" Height="27px" Width="195px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;
            </h2>
            <h2>電話&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTeacherPhone" runat="server" Font-Size="Large" Height="27px" Width="195px"></asp:TextBox>
            </h2>
            <h2>email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTeacherEmail" runat="server" Font-Size="Large" Height="27px" Width="195px"></asp:TextBox>
            </h2>
            <p><asp:Button ID="OK" runat="server" Text="確認" Width="404px" OnClick="OK_Click" />
            </p>
        
        </div>

        <div style="height: 413px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="GridView1_RowCancelingEdit"

OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="SchoolCode,ID">
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