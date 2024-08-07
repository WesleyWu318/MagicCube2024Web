<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm2_Get.aspx.vb" Inherits="WebApplication2.WebForm2_Get2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

        <script type="text/javascript">



        var val = Request.QueryString["fname"];
        var lastName = request.QueryString("lname");

        alarm(firstName);


        </script>

</head>
<body>
        <h1>The form method="get" attribute</h1>

    <form id="form1" runat="server">
        <div>
                          <label for="fname">First name:</label>
  <input type="text" id="fname" name="fname"><br><br>

        </div>
    </form>
</body>
</html>
