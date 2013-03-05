Imports System.Text.RegularExpressions

Partial Class Verify
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Make sure that a valid querystring value was passed through
        If String.IsNullOrEmpty(Request.QueryString("ID")) OrElse Not Regex.IsMatch(Request.QueryString("ID"), "[0-9a-f]{8}\-([0-9a-f]{4}\-){3}[0-9a-f]{12}") Then
            InformationLabel.Text = "An invalid ID value was passed in through the querystring."
        Else
            'ID exists and is kosher, see if this user is already approved
            'Get the ID sent in the querystring
            Dim userId As Guid = New Guid(Request.QueryString("ID"))
            'Get information about the user
            Dim userInfo As MembershipUser = Membership.GetUser(userId)
            If userInfo Is Nothing Then
                'Could not find user!
                InformationLabel.Text = "The user account could not be found in the membership database."
            Else
                'User is valid, approve them
                userInfo.IsApproved = True
                Membership.UpdateUser(userInfo)
                'Display a message
                InformationLabel.Text = "Your account has been verified and you can now log into the site."
            End If
        End If
    End Sub
End Class
