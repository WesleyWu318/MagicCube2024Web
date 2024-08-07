<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>台北市教育局112學年度國中小魔術方塊競賽成績輸入系統</title>
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <link rel="stylesheet" href="css/style.css"/>

    <script type="text/javascript">
        window.onload = function () {
        }

        $(document).ready(function () {

        });

    function browserRedirect() {
        var sUserAgent = navigator.userAgent.toLowerCase();
        if (/ipad|iphone|midp|rv:1.2.3.4|ucweb|android|windows ce|windows mobile/.test(sUserAgent)) {
            //跳转移动端页面
            window.location.href = "./DefaultM.aspx";
            browserRedirect();
        } else {
            //跳转pc端页面
            //window.location.href = "./Default_PC.aspx";
        }
    }


    </script>

    <%--  --%>
    <script type="text/javascript">


        var attempt = 3; // Variable to count number of attempts.

        function Login_Click() {
            document.forms.myform.submit();

        }

      

    </script>
    <style type="text/css">
        #form_id {
            width: 309px;
        }
        #myform {
            width: 299px;
        }
    </style>
    </head>
<body>


    <div class="container" >
        <div class="center" >
           <h3 >台北市教育局112學年度國中小魔術方塊競賽</h3>
           <h3 >成績輸入系統</h3>
            <form id="myform" runat="server" action="webForm2_Post.aspx" class="formcenter">
                <label>使用者帳號 :</label><input type="text" name="username" id="username" autocomplete="off" readonly onfocus="this.removeAttribute('readonly');"/>
                <br />
                 <label>密碼 :</label><input type="password" name="password" id="password" autocomplete="off" readonly onfocus="this.removeAttribute('readonly');"" />
                <br />
                <input type="button" value="登入" id="submitA" onclick="Login_Click()" /> 
                <b class="note"> 
                備註: </b>請輸入帳號及密碼<br />
                <br />
                &nbsp;<asp:HiddenField id="txtSessionID" ClientIDMode="Static" runat="server" />                
                <asp:Label ID="Label1" runat="server" Text="更新日期:2023/12/10"></asp:Label><br />                
                <asp:Label ID="lblMessage" runat="server" Text="翔虹STEAM中心"></asp:Label>
                <br />
             </form>
        </div>
    </div>
</body>
</html>
