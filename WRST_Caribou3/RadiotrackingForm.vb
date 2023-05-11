Imports DevExpress.XtraGrid.Views.Grid

Public Class RadiotrackingForm

    Private Sub LoadDataset()
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



    Private Sub RadiotrackingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadDataset()

        SetUpPivotGridControl(Me.RadiotrackingPivotGridControl)
        SetUpGridControl(Me.RadiotrackingGridControl)

        'SetFormReadOnly(True)
    End Sub

    ''' <summary>
    ''' Sets data driven controls to read-only.
    ''' </summary>
    ''' <param name="MakeFormReadOnly">Make the form's data controls read-only. Boolean.</param>
    Private Sub SetFormReadOnly(MakeFormReadOnly As Boolean)

        'For Each MyGridView As GridView In RadiotrackingGridControl.ViewCollection
        '    With MyGridView
        '        .OptionsBehavior.ReadOnly = MakeFormReadOnly
        '    End With
        'Next

    End Sub



    Private Sub ReadOnlyToolStripComboBox_TextChanged(sender As Object, e As EventArgs) Handles ReadOnlyToolStripComboBox.TextChanged
        If Me.ReadOnlyToolStripComboBox.Text.Trim = "True" Then
            SetFormReadOnly(True)
        Else
            SetFormReadOnly(False)
        End If
    End Sub

    Private Sub RefreshToolStripButton_Click(sender As Object, e As EventArgs) Handles RefreshToolStripButton.Click
        LoadDataset()
    End Sub

    Private Sub SaveEditsToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveEditsToolStripButton.Click
        SaveRadiotrackingDataTableToDatabase()
    End Sub
End Class