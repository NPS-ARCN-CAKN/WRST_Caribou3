''' <summary>
''' The SettingsForm allows the user to access and edit the application properties. Note: WRST_CaribouConnectionString is read only; change it by editing WRST_Caribou3.vshost.exe.config.
''' </summary>
Public Class SettingsForm

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'load the application settings into the property grid
        Me.SettingsPropertyGrid.SelectedObject = My.Settings

    End Sub

    Private Sub UpdateConnectionStringButton_Click(sender As Object, e As EventArgs)
        'The code below did not work as the application would not respect the wrst caribou connection string edits
        'edit WRST_Caribou3.vshost.exe.config to change this setting

        'My.Settings.Item("WRST_CaribouConnectionString") = Me.WRST_CaribouConnectionStringTextBox.Text
        'Me.SettingsPropertyGrid.SelectedObject = My.Settings
        'MsgBox("You have changed the WRST_Caribou database connection string. You must restart the application for the change to take effect.", MsgBoxStyle.Exclamation, "Warning")
    End Sub

    Private Sub SettingsPropertyGrid_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles SettingsPropertyGrid.PropertyValueChanged
        'the app did not seem to respect the new connectionstring when LoadDataset() was called; so workaround is to simply have the user restart the application
        If e.ChangedItem.Label = "Animal_MovementConnectionString" Then
            MsgBox("You have changed the Animal_Movement database connection string. You must restart the application for the change to take effect.", MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub
End Class