Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters
Public Class DatasetForm
    Private Sub DatasetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'Get the entire surveys dataset into a datatable
            Dim DT As DataTable = GetDataTableFromSQLServerDatabase(My.Settings.WRST_CaribouConnectionString, "SELECT  * FROM Dataset_Full")
            Me.DatasetBindingSource.DataSource = DT

            'Load the dataset into the grid control
            Me.DatasetGridControl.DataSource = Me.DatasetBindingSource

            'Configure the grid control in a standard way
            SetUpGridControl(Me.DatasetGridControl)

            'Load the dataset into the pivot grid
            Me.DatasetPivotGridControl.DataSource = Me.DatasetBindingSource
            Me.DatasetPivotGridControl.RetrieveFields() 'Retrieve the fields

            'Set up the pivot grid in a standard way
            SetUpPivotGridControl(Me.DatasetPivotGridControl)

            For Each Col As DataColumn In DT.Columns
                Try
                    Dim GV As GridView = Me.DatasetGridControl.MainView
                    Dim GroupSummaryItem As New GridGroupSummaryItem
                    With GroupSummaryItem
                        .FieldName = Col.ColumnName
                        .ShowInGroupColumnFooter = GV.Columns(Col.ColumnName)
                        .SummaryType = DevExpress.Data.SummaryItemType.Sum
                        GV.GroupSummary.Add(GroupSummaryItem)
                    End With
                Catch xex As Exception
                    Debug.Print(xex.Message)
                End Try

            Next


        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub ExportToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ExportToolStripComboBox.SelectedIndexChanged
        MsgBox("This function not written yet")
        'If Me.ExportToolStripComboBox.Text.Trim <> "" Then
        '    Dim Options As New DevExpress.XtraPrinting.CsvExportOptions
        '    With Options
        '        .SkipEmptyColumns = True
        '        .SkipEmptyRows = True
        '    End With
        '    Me.DatasetGridControl.ExportToCsv("C:\temp\zcsv.csv", Options)
        'End If
    End Sub
End Class