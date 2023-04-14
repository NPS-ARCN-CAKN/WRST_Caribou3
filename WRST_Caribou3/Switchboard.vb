Public Class Switchboard


    Private Sub EditSurveysDatasetButton_Click(sender As Object, e As EventArgs) Handles EditSurveysDatasetButton.Click
        Try
            Dim MainForm As New MainForm
            MainForm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub AccessSurveysDatasetButton_Click(sender As Object, e As EventArgs) Handles AccessSurveysDatasetButton.Click
        Try
            Dim DatasetForm As New DatasetForm
            DatasetForm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
End Class