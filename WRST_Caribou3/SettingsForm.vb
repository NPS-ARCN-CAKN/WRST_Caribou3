Public Class SettingsForm
    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WRST_CaribouConnectionStringTextBox.Text = My.Settings.WRST_CaribouConnectionString
        Me.SettingsPropertyGrid.SelectedObject = My.Settings

    End Sub

    Private Sub UpdateConnectionStringButton_Click(sender As Object, e As EventArgs) Handles UpdateConnectionStringButton.Click
        My.Settings.Item("WRST_CaribouConnectionString") = Me.WRST_CaribouConnectionStringTextBox.Text
        Me.SettingsPropertyGrid.SelectedObject = My.Settings
        MsgBox("You have changed the WRST_Caribou database connection string. You must restart the application for the change to take effect.", MsgBoxStyle.Exclamation, "Warning")
    End Sub

    Private Sub SettingsPropertyGrid_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles SettingsPropertyGrid.PropertyValueChanged
        If e.ChangedItem.Label = "Animal_MovementConnectionString" Then
            MsgBox("You have changed the Animal_Movement database connection string. You must restart the application for the change to take effect.", MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub
End Class