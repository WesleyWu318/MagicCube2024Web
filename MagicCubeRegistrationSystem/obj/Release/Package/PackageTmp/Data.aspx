<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="MagicCubeRegistrationSystem.Data" %>

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
        height:800px;
        border: 3px solid black;
        background-image: linear-gradient(to right, white,white);
        text-align:center; 
        vertical-align:middle;
        padding: 10px;
        box-shadow: 12px 12px 4px 2px rgba(0, 0, 255, .2);  
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

    .close{
        margin-top: 15px;  
        padding-top: 10px;
        margin-bottom: 10px;        
        border-color : black;
        border-radius: 25px;
        display: block;
        margin-left: auto;
        margin-right: auto;
        width: 500px;
        height:230px;
        border: 1px solid black;
        align-items: center;  
    }

    .gridAlign{        
        display: flex;
        justify-content: center;    
        align-items: center;
        border-radius: 5px;
    }

    .gridview-header {
    background-color: #414648;
    color: white;
    font-weight: bold;
    text-align: center;
    padding: 10px;
    }

    /* GridView Row Style */
    .gridview-row {
        border-radius: 5px;
        background-color: #FFFAF3;
        text-align: center;
        padding: 10px;        
    }

    /* GridView Alternate Row Style */
    .gridview-row-alternate {
        background-color: #E9E4DC;
    }

    /* GridView Edit Button Style */
    .gridview-button-edit {
        background-color: #AE5335;
        color: white;
        border: none;
        padding: 5px 10px;
        cursor: pointer;
        border-radius: 5px;
    }

    /* GridView Update/Cancel Button Style */
    .gridview-button-update {
        background-color: #4CAF50;
        color: white;
        border: none;
        padding: 5px 10px;
        cursor: pointer;
        border-radius: 5px;
    }

    .gridview-button-cancel {
        background-color: #f44336;
        color: white;
        border: none;
        padding: 5px 10px;
        cursor: pointer;
        border-radius: 5px;
    }

    .yellow{
        background-color: #EECF6D;
        border-radius: 5px;
    }

    .red{
        color: red;
    }

    .gridview{
        width: 600px;
    }

</style>


<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>--%>
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>        
    </title>
    <%--<link rel="stylesheet" href="css/style.css" />--%>
</head>


<body>
    <form id="form1" runat="server">
        <div class="center">
            <h2 class="yellow">學校代碼:&nbsp;
                <asp:Label ID="lblSchoolCode" runat="server" Text="Label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp; 校名:&nbsp;
                <asp:Label ID="lblSchoolName" runat="server" Text="Label"></asp:Label>
            </h2>
           <h2>密碼:&nbsp;
                <asp:TextBox ID="txtPassword" runat="server" Font-Size="Large" Height="27px" Width="195px"></asp:TextBox>
                <asp:Button ID="btnPassEdit" runat="server" Text="修改密碼" OnClick="btnPassEdit_Click" class="btn btn-primary btn-sm"/>
               <asp:Button ID="btnPassUpdate" runat="server" Text="更新" Visible="False" OnClick="btnPassUpdate_Click" class="btn btn-warning btn-sm" /><asp:Button ID="btnPassCancel" runat="server" Text="取消" Visible="False" OnClick="btnPassCancel_Click" class="btn btn-light btn-sm"/>
               <asp:Button ID="btnManager" runat="server" Text="管理系統" class="btn btn-info btn-sm" OnClick="btnManager_Click"/>
               <br />
            </h2>
             <div ><asp:Label ID="PasswordMessage" runat="server" Width="300px" CssClass="red"></asp:Label><div>
             <div class="close">
                <h2>聯絡人</h2>
             <%--   <hr></hr>--%>
                <h3>姓名&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtTeacherName" runat="server" Font-Size="Large" Height="27px" Width="195px" placeholder="name"></asp:TextBox></h3>
                <h3>職稱&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtTeacherTitle" runat="server" Font-Size="Large" Height="27px" Width="195px" placeholder="title"></asp:TextBox></h3>
                <h3>電話&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtTeacherPhone" runat="server" Font-Size="Large" Height="27px" Width="195px" placeholder="phone number"></asp:TextBox></h3>
                <h3>email&nbsp; <asp:TextBox ID="txtTeacherEmail" runat="server" Font-Size="Large" Height="27px" Width="195px" placeholder="email"></asp:TextBox></h3>
                
             </div>
               <asp:Button ID="OK" runat="server" Text="儲存修改" Width="404px" OnClick="OK_Click" class="btn btn-success"/>
               　<asp:Button ID="btnWord" runat="server" Text="匯出Word檔"  class="btn btn-primary" OnClick="btnWord_Click"/>
               <br />
               <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="red"></asp:Label>
               <div style="height: 350px" class="gridAlign">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="GridView1_RowCancelingEdit"
OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="SchoolCode,ID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            CssClass="gridview" HeaderStyle-CssClass="gridview-header" 
    RowStyle-CssClass="gridview-row" AlternatingRowStyle-CssClass="gridview-row-alternate">
            <Columns>                   
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_Edit" runat="server" Text="編輯" CommandName="Edit" CssClass="gridview-button-edit"/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btn_Update" runat="server" Text="更新" CommandName="Update" CssClass="gridview-button-update"/>
                        <asp:Button ID="btn_Cancel" runat="server" Text="取消" CommandName="Cancel" CssClass="gridview-button-cancel"/>
                    </EditItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="SchoolCode">
                    <ItemTemplate>
                        <asp:Label ID="lbl_SchoolCode" runat="server" Text='<%#Eval("SchoolCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
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
                <asp:TemplateField HeaderText="指導老師(1人)">
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
  <%--          <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>
            <RowStyle BackColor="#e7ceb6"/>--%>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=LAPTOP-TN1KHR01;Initial Catalog=MagicCube;User ID=admin;Password=magiccube" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Student2024]"></asp:SqlDataSource>
            
        </div>
        
    </div>

    </form>
    

</body>
</html>