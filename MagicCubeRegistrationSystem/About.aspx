<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MagicCubeRegistrationSystem.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="jumbotron">
                    <h2>學校代碼 <asp:TextBox ID="txtSchoolName" runat="server" Font-Size="Small" Height="27px" Width="195px"></asp:TextBox>
            </h2>

        <h2>姓名&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtTeacherName" runat="server" Font-Size="Small" Height="27px" Width="195px"></asp:TextBox>
        </h2>
        <h2>電話&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTeacherPhone" runat="server" Font-Size="Large" Height="27px" Width="195px"></asp:TextBox>
        </h2>
        <h2>email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTeacherEamil" runat="server" Font-Size="Small" Height="27px" Width="195px"></asp:TextBox>
        </h2>
        <p><asp:Button ID="OK" runat="server" Text="確認" Width="404px" OnClick="OK_Click" />
        </p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    &nbsp;<br></br>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

        <h2>&nbsp;</h2>
    <p>&nbsp;</p>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>
