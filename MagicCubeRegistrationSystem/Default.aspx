<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MagicCubeRegistrationSystem._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

         <div class="jumbotron">
            <h2>學校代碼 <asp:TextBox ID="txtSchoolName" runat="server" Font-Size="Small" Height="27px" Width="195px"></asp:TextBox>
            </h2>
            <h2>密碼&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPassword" runat="server" Font-Size="Small" Height="27px" Width="195px"></asp:TextBox>
            </h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp;<asp:Button ID="OK" runat="server" Text="確認" Width="92px" OnClick="OK_Click" />
            <br></br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LoginMessage" runat="server" Width="144px"></asp:Label>
        </div>
        <div>
<%--            <input type="submit" value="Submit" />--%>
        </div>
  

    

</asp:Content>
