Public Class SplashScreen
    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Version As String = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        Me.VersionLabel.Text = "Version: " & Version
        Me.UserLabel.Text = My.User.Name & " " & FormatDateTime(Now, DateFormat.LongDate) & vbNewLine & "Public Domain Software" & vbNewLine & "National Park Service, " & Year(Now)

    End Sub
End Class