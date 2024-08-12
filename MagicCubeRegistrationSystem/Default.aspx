<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MagicCubeRegistrationSystem.Default" %>

<!DOCTYPE html>

<style>
    .center {
        border-color : blue;
        border-radius: 25px;
        display: block;
        margin-left: auto;
        margin-right: auto;
        margin-top: 60px;
        width: 800px;
        height:550px;
        border: 3px solid black;
        background-image: linear-gradient(to right, white,white);
        text-align:center; 
        vertical-align:middle;
        padding: 10px;
        box-shadow: 24px 24px 4px 2px rgba(0, 0, 255, .2);  
    }
    .container{
        display: flex;
        /* 水平置中 */
        justify-content: center;    
        /* 垂直置中 */
        align-items: center;      
    }
       
    
    .image{
        /*background-color: #FBD603;*/
        background-image: url("../images/background.png") ;
    }

</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>        
    </title>
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    
    <div class="container image">
        <div class="center">
            <form id="form1" runat="server">
                <h1>台北市教育局113學年度國中小</h1>
                <h1>魔術方塊競賽報名系統</h1>
                <br />
                <h3>學校代碼:<br /><asp:TextBox ID="txtSchoolName" runat="server" Font-Size="Large" Height="50" Width="330px" placeholder="Enter school code" ></asp:TextBox>                     
                <asp:Button ID="btnKind" runat="server" Text="查詢" OnClick="btnKind_Click" class="btn btn-primary"/>
                </h3>
                <br />
                <h3>校別: <asp:DropDownList ID="ddlKind" runat="server" AutoPostBack="True" ></asp:DropDownList>            
                </h3>                
                <h3>密碼:<br /><asp:TextBox ID="txtPassword" runat="server" Font-Size="Large" Height="50" Width="400px" placeholder="password"></asp:TextBox>
                </h3>
                <asp:Button ID="OK" runat="server" Text="確認" Width="92px" OnClick="OK_Click" class="btn btn-success btn-lg"/>
                <br/>
                <br/>
                <asp:Label ID="LoginMessage" runat="server" Width="200px"></asp:Label>
       
            </form>
        </div>
    </div>
</body>
</html>