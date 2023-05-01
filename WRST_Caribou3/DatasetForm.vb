Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters
Public Class DatasetForm

    Private SqlQueryValue As String
    Public Property SqlQuery() As String
        Get
            Return SqlQueryValue
        End Get
        Set(ByVal value As String)
            SqlQueryValue = value
            Me.SqlToolStripLabel.Text = SqlQuery
        End Set
    End Property

    Public Sub New(Optional Sql As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        Me.SqlQuery = Sql
        Me.DatasetSelectorToolStripComboBox.Text = ""
        Me.SqlToolStripLabel.Text = Sql
        LoadDataset(Me.SqlQuery)
    End Sub

    Private Sub DatasetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadDataset(Sql As String)
        Try

            'Get the entire surveys dataset into a datatable
            Dim DT As DataTable = GetDataTableFromSQLServerDatabase(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.DatasetBindingSource.DataSource = DT

            'Load the dataset into the grid control

            Me.DatasetGridControl.DataSource = Me.DatasetBindingSource
            Me.DatasetGridControl.MainView.PopulateColumns()

            'Configure the grid control in a standard way
            SetUpGridControl(Me.DatasetGridControl)

            'Load the dataset into the pivot grid
            Me.DatasetPivotGridControl.DataSource = Me.DatasetBindingSource
            Me.DatasetPivotGridControl.RetrieveFields() 'Retrieve the fields

            'Set up the pivot grid in a standard way
            SetUpPivotGridControl(Me.DatasetPivotGridControl)

            'For Each Col As DataColumn In DT.Columns
            '    Try
            '        Dim GV As GridView = Me.DatasetGridControl.MainView
            '        Dim GroupSummaryItem As New GridGroupSummaryItem
            '        With GroupSummaryItem
            '            .FieldName = Col.ColumnName
            '            .ShowInGroupColumnFooter = GV.Columns(Col.ColumnName)
            '            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            '            GV.GroupSummary.Add(GroupSummaryItem)
            '        End With
            '    Catch xex As Exception
            '        Debug.Print(xex.Message)
            '    End Try

            'Next


        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub ExportToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ExportDatasetToolStripComboBox.SelectedIndexChanged
        ExportDatasetGrid()

    End Sub

    ''' <summary>
    ''' Exports the dataset to a file.
    ''' </summary>
    Private Sub ExportDatasetGrid()
        Try
            Select Case Me.ExportDatasetToolStripComboBox.Text.Trim
                Case "Comma separated values text file"
                    Dim Options As New DevExpress.XtraPrinting.CsvExportOptions
                    With Options
                        .SkipEmptyColumns = True
                        .SkipEmptyRows = True
                    End With
                    Dim Filter As String = "Comma separated values text files (*.csv)|*.csv"
                    Dim ExportFile As String = GetSaveFile(Filter, ".csv")
                    If My.Computer.FileSystem.FileExists(ExportFile) = True Then
                        Me.DatasetGridControl.ExportToCsv(ExportFile, Options)
                    End If
                Case "Microsoft Excel"
                    Dim Filter As String = "Excel spreadsheet (*.xlsx)|*.xlsx"
                    Dim ExportFile As String = GetSaveFile(Filter, ".csv")
                    If My.Computer.FileSystem.FileExists(ExportFile) = True Then
                        Me.DatasetGridControl.ExportToXlsx(ExportFile)
                    End If
            End Select

        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Exports the dataset to a file.
    ''' </summary>
    Private Sub ExportPivotGrid()
        Try
            Select Case Me.ExportPivotGridToolStripComboBox.Text.Trim
                Case "Comma separated values text file"
                    Dim Options As New DevExpress.XtraPrinting.CsvExportOptions
                    With Options
                        .SkipEmptyColumns = True
                        .SkipEmptyRows = True
                    End With
                    Dim Filter As String = "Comma separated values text files (*.csv)|*.csv"
                    Dim ExportFile As String = GetSaveFile(Filter, ".csv")
                    If My.Computer.FileSystem.FileExists(ExportFile) = True Then
                        Me.DatasetPivotGridControl.ExportToCsv(ExportFile, Options)
                    End If
                Case "Microsoft Excel"
                    Dim Filter As String = "Excel spreadsheet (*.xlsx)|*.xlsx"
                    Dim ExportFile As String = GetSaveFile(Filter, ".csv")
                    If My.Computer.FileSystem.FileExists(ExportFile) = True Then
                        Me.DatasetPivotGridControl.ExportToXlsx(ExportFile)
                    End If
            End Select

        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ExportPivotGridToolStripComboBox.SelectedIndexChanged
        ExportPivotGrid()
    End Sub

    Private Sub DatasetSelectorToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DatasetSelectorToolStripComboBox.SelectedIndexChanged

        Try
            Select Case Me.DatasetSelectorToolStripComboBox.Text.Trim
                Case "Aerial survey"
                    Me.SqlToolStripLabel.Text = "SELECT  * FROM Dataset_Full"
                    LoadDataset(Me.SqlToolStripLabel.Text.Trim)
                Case "Radiotracking"
                    Me.SqlToolStripLabel.Text = "Select * From Dataset_Radiotracking"
                    LoadDataset(Me.SqlToolStripLabel.Text.Trim)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub LoadDatasetToolStripButton_Click(sender As Object, e As EventArgs) Handles LoadDatasetToolStripButton.Click
        Try
            LoadDataset(Me.SqlToolStripLabel.Text.Trim)
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
End Class