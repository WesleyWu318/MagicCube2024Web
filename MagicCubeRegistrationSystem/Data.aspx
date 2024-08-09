<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="MagicCubeRegistrationSystem.Data" %>

<!DOCTYPE html>

<style>
    .div-1 {
        background-color: #EBEBEB;
    }
    
    .div-2 {
    	background-color: #ABBAEA;
    }
    
    .div-3 {
    	background-color: #FBD603;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head >
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    
    <body>
        <form id="form1" runat="server">
            <div class="jumbotron">
                <div class="div-3">
                    <h2>學校代碼: 
                        <asp:Label ID="lblSchoolCode" runat="server" Text="Label"></asp:Label>
                         &nbsp;&nbsp;&nbsp;校名:
                        <asp:Label ID="lblSchoolName" runat="server" Text="Label"></asp:Label>
                    </h2>
                </div>
                <h2>密碼:&nbsp;
                <asp:TextBox ID="txtPassword" runat="server" Font-Size="Large" Height="27px" Width="195px"></asp:TextBox>
                <asp:Button ID="btnPassEdit" runat="server" Text="修改密碼" OnClick="btnPassEdit_Click" />
               <asp:Button ID="btnPassUpdate" runat="server" Text="更新" Visible="False" OnClick="btnPassUpdate_Click" /><asp:Button ID="btnPassCancel" runat="server" Text="取消" Visible="False" OnClick="btnPassCancel_Click" />
               <h3><asp:Label ID="PasswordMessage" runat="server" Width="250px"></asp:Label></h3>
                <h2>聯絡人:
            </h2>
         <%--   <hr></hr>--%>
            <h3>姓名&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTeacherName" runat="server" Font-Size="Large" Height="27px" Width="195px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;
            </h3>
            <h3>職稱&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTeacherTitle" runat="server" Font-Size="Large" Height="27px" Width="195px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;
            </h3>
            <h3>電話&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTeacherPhone" runat="server" Font-Size="Large" Height="27px" Width="195px"></asp:TextBox>
            </h3>
            <h3>email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTeacherEmail" runat="server" Font-Size="Large" Height="27px" Width="195px"></asp:TextBox>
            </h3>
            <p><asp:Button ID="OK" runat="server" Text="確認" Width="404px" OnClick="OK_Click" />
            </p>
        
            </div>

            <div style="height: 413px">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="GridView1_RowCancelingEdit"

    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="SchoolCode,ID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btn_Edit" runat="server" Text="編輯" CommandName="Edit" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btn_Update" runat="server" Text="更新" CommandName="Update"/>
                            <asp:Button ID="btn_Cancel" runat="server" Text="取消" CommandName="Cancel"/>
                        </EditItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="序號">
                        <ItemTemplate>
                            <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="參賽學生">
                        <ItemTemplate>
                            <asp:Label ID="lbl_StudentName" runat="server" Text='<%#Eval("StudentName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_StudentName" runat="server" Text='<%#Eval("StudentName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="指導老師">
                        <ItemTemplate>
                            <asp:Label ID="lbl_TeacherName" runat="server" Text='<%#Eval("TeacherName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_TeacherName" runat="server" Text='<%#Eval("TeacherName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>
                <RowStyle BackColor="#e7ceb6"/>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=LAPTOP-TN1KHR01;Initial Catalog=MagicCube;User ID=admin;Password=magiccube" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Student2024]"></asp:SqlDataSource>
        </div>

        </form>
    

    </body>
</html>
