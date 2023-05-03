Public Class RadiotrackingForm

    Private Sub LoadRadiotrackingDataset()
        'Load the radiotracking dataset into the form
        Try
            Me.RadiotrackingTableAdapter.Fill(Me.WRST_CaribouDataSet.Radiotracking)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub SaveRadiotrackingDataTableToDatabase()
        Try
            Me.Validate()
            Me.RadiotrackingBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub RadiotrackingBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub RadiotrackingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRadiotrackingDataset()

        SetUpPivotGridControl(Me.RadiotrackingPivotGridControl)
        SetUpGridControl(Me.RadiotrackingGridControl)
    End Sub
End Class