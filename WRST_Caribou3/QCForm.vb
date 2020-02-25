Public Class QCForm
    Private Sub RunQCScriptToolStripButton_Click(sender As Object, e As EventArgs) Handles RunQCScriptToolStripButton.Click
        RunQC()
    End Sub

    Private Sub RunQC()
        Output("WRST Caribou Database Quality Checks")
        Output(vbNewLine)


    End Sub

    Private Sub Output(Text As String)
        Me.OutputTextBox.AppendText(Text & vbNewLine)
    End Sub


End Class