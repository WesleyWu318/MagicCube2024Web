Public Class WebForm2_post
    Inherits System.Web.UI.Page


    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If IsPostBack Then
            Debug.Print("1")

        Else
            Debug.Print("2")

            Dim keys As String() = Request.Form.AllKeys
            Dim ctlAllPostbackData As Literal = New Literal()
            ctlAllPostbackData.Text = "<div class='well well-lg' style='border:1px solid black;z-index:99999;position:absolute;'><h3>All postback data:</h3><br />"

            For i As Integer = 0 To keys.Length - 1
                ctlAllPostbackData.Text += "<b>" & keys(i) & "</b>: " & Request(keys(i)) & "<br />"


            Next

            ctlAllPostbackData.Text += "</div>"
            Me.Controls.Add(ctlAllPostbackData)

        End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim keys As String() = Request.Form.AllKeys
        'For i As Integer = 0 To keys.Length - 1

        '    Response.Write(keys(i) + ": " + Request.Form(keys(i)) + "<br>")
        'Next

        'ShowAllPostBackData()

        If IsPostBack Then
            Dim keys As String() = Request.Form.AllKeys
            Dim ctlAllPostbackData As Literal = New Literal()
            ctlAllPostbackData.Text = "<div class='well well-lg' style='border:1px solid black;z-index:99999;position:absolute;'><h3>All postback data:</h3><br />"

            For i As Integer = 0 To keys.Length - 1
                ctlAllPostbackData.Text += "<b>" & keys(i) & "</b>: " & Request(keys(i)) & "<br />"
            Next

            ctlAllPostbackData.Text += "</div>"
            Me.Controls.Add(ctlAllPostbackData)
        End If


    End Sub


    Public Sub ShowAllPostBackData()
        If IsPostBack Then
            Dim keys As String() = Request.Form.AllKeys
            Dim ctlAllPostbackData As Literal = New Literal()
            ctlAllPostbackData.Text = "<div class='well well-lg' style='border:1px solid black;z-index:99999;position:absolute;'><h3>All postback data:</h3><br />"

            For i As Integer = 0 To keys.Length - 1
                ctlAllPostbackData.Text += "<b>" & keys(i) & "</b>: " & Request(keys(i)) & "<br />"
            Next

            ctlAllPostbackData.Text += "</div>"
            Me.Controls.Add(ctlAllPostbackData)
        End If
    End Sub

End Class