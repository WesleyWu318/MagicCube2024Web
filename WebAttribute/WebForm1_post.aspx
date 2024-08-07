<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1_post.aspx.vb" Inherits="WebApplication2.WebForm1_post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>The form method="post" attribute</h1>

<form action="/webForm2_post.aspx" method="post" target="_blank">
  <label for="fname">First name:</label>
  <input type="text" id="fname" name="fname"><br><br>
  <label for="lname">Last name:</label>
  <input type="text" id="lname" name="lname"><br><br>
  <input type="submit" value="Submit">
</form>

<p>Click on the submit button, and the form will be submittied using the POST method.</p>

</body>
</html>
