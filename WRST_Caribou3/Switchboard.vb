Public Class Switchboard


    Private Sub EditSurveysDatasetButton_Click(sender As Object, e As EventArgs) Handles EditSurveysDatasetButton.Click
        Try
            Dim MainForm As New MainForm
            MainForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub AccessSurveysDatasetButton_Click(sender As Object, e As EventArgs) Handles AccessSurveysDatasetButton.Click
        Try
            Dim DatasetForm As New DatasetForm
            DatasetForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub EditRadiotrackingDatasetButton_Click(sender As Object, e As EventArgs) Handles EditRadiotrackingDatasetButton.Click
        Dim RadiotrackingForm As New RadiotrackingForm
        RadiotrackingForm.Show()

    End Sub

    Private Sub GetDeploymentsForHerdFrequencyAndDateButton_Click(sender As Object, e As EventArgs) Handles GetDeploymentsForHerdFrequencyAndDateButton.Click
        Dim DeploymentsForAFrequencyForm As New DeploymentsForAFrequencyForm
        DeploymentsForAFrequencyForm.Show()
    End Sub

    Private Sub OpenCaribouProfileFormButton_Click(sender As Object, e As EventArgs) Handles OpenCaribouProfileFormButton.Click
        Dim CaribouProfileForm As New CaribouProfileForm()
        CaribouProfileForm.Show()
    End Sub
End Class