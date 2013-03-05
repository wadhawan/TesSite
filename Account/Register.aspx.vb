
Partial Class Account_Register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'RegisterUser.ContinueDestinationPageUrl = Request.QueryString("ReturnUrl")
    End Sub

    Protected Sub RegisterUser_CreatedUser(ByVal sender As Object, ByVal e As EventArgs) Handles RegisterUser.CreatedUser
        'FormsAuthentication.SetAuthCookie(RegisterUser.UserName, False)

        'Dim continueUrl As String = RegisterUser.ContinueDestinationPageUrl
        'If String.IsNullOrEmpty(continueUrl) Then
        'continueUrl = "~/"
        'End If

        'Response.Redirect(continueUrl)
    End Sub

    Protected Sub RegisterUser_SendingMail(sender As Object, e As System.Web.UI.WebControls.MailMessageEventArgs) Handles RegisterUser.SendingMail
        Dim userInfo As MembershipUser = Membership.GetUser(RegisterUser.UserName)
        'Construct the verification URL
        Dim verifyUrl As String = Request.Url.GetLeftPart(UriPartial.Authority) & Page.ResolveUrl("~/Verify.aspx?ID=" & userInfo.ProviderUserKey.ToString())
        'Replace <%VerifyUrl%> placeholder with verifyUrl value
        e.Message.Body = e.Message.Body.Replace("<%VerifyUrl%>", verifyUrl)
    End Sub
End Class
