Imports Janus.Windows.GridEX

Public Class ResultsForm

    Dim ResultsDataTable As DataTable 'This reusable datatable will contain the data to be displayed in the Me.SurveyResultsDataGridView of the Results tab

    Private Sub ResultsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDatabaseViewsComboBox()

        Me.ResultsGridEX.GroupByBoxVisible = False
        Me.CollapseGroupsCheckBox.Visible = False
    End Sub


    ''' <summary>
    ''' Queries the database for a list of Views. Loads the View names into Me.DatabaseViewsToolStripComboBox
    ''' </summary>
    Private Sub LoadDatabaseViewsComboBox()
        Try
            Dim DatabaseViewsDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, "SELECT Name FROM sys.views ORDER BY Name")
            With Me.ViewsListBox
                .Items.Clear()
                .Items.Add("")
                For Each Row As DataRow In DatabaseViewsDataTable.Rows
                    .Items.Add(Row.Item("Name"))
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Fetches the data from the View selected in Me.DatabaseViewsToolStripComboBox and loads it into the SurveyResultsDataGridView
    ''' </summary>
    Private Sub LoadResultsGrid()

        'get the view name
        Dim ViewName As String = Me.ViewsListBox.Text
        If ViewName.Trim.Length > 0 Then
            Try
                Me.DataSummariesLabel.Text = ViewName

                'get the view description
                Dim ViewDescription As String = ViewName
                Dim ViewDT As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, "SELECT [Table],[TableDescription] FROM [WRST_Caribou].[dbo].[DatabaseTableDescriptions] where [table]='dbo." & ViewName & "'")
                If ViewDT.Rows.Count = 1 Then
                    ViewDescription = ViewDT.Rows(0).Item("TableDescription")
                End If
                Me.ViewDescriptionTextBox.Text = ViewDescription

                'get the data from the selected view into a datatable
                Dim Filter As String = ""
                Dim Sql As String = "SELECT * FROM " & ViewName.Trim & Filter
                ResultsDataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)

                'load the datatable into the gridex
                With Me.ResultsGridEX
                    .DataSource = ResultsDataTable
                    .RetrieveStructure()
                    .GroupTotals = GroupTotals.Always
                End With

                'format total rows
                For Each Col As GridEXColumn In Me.ResultsGridEX.RootTable.Columns
                    If Col.Key <> "Year" And Col.Key <> "Lat" And Col.Key <> "Long" Then
                        If Col.DataTypeCode = TypeCode.Int16 Or Col.DataTypeCode = TypeCode.Int32 Or Col.DataTypeCode = TypeCode.Int64 Then
                            Col.AggregateFunction = AggregateFunction.Sum
                        ElseIf Col.DataTypeCode = TypeCode.Double Or Col.DataTypeCode = TypeCode.Decimal Or Col.DataTypeCode Then
                            Col.AggregateFunction = AggregateFunction.Average
                        Else
                            Col.AggregateFunction = AggregateFunction.None
                        End If
                    End If

                    'other things
                    Col.FormatString = ""
                Next
            Catch ex As Exception
                MsgBox("Could not load the database view " & ViewName.Trim & ". " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & " a)")
            End Try
        Else
            MsgBox("Select a database view.", MsgBoxStyle.Information, "View not selected")
            End If
        Try
        Catch ex As Exception
            MsgBox("Query failed: " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub ViewsListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ViewsListBox.SelectedIndexChanged
        LoadResultsGrid()
        Me.ResultsGridEX.CollapseGroups()
        Me.ResultsGridEX.CollapseRecords()
    End Sub

    Private Sub CollapseGroupsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CollapseGroupsCheckBox.CheckedChanged
        ToggleCollapseGroups()
    End Sub

    Private Sub ResultsGridEX_GroupsChanged(sender As Object, e As GroupsChangedEventArgs) Handles ResultsGridEX.GroupsChanged
        Me.ResultsGridEX.CollapseGroups()
        Me.ResultsGridEX.CollapseRecords()
        Me.CollapseGroupsCheckBox.Text = "Expand groups"
    End Sub

    Private Sub ToggleCollapseGroups()
        If Me.CollapseGroupsCheckBox.Checked = True Then
            Me.ResultsGridEX.CollapseGroups()
            Me.ResultsGridEX.CollapseRecords()
            Me.CollapseGroupsCheckBox.Text = "Expand groups"
        Else
            Me.ResultsGridEX.ExpandGroups()
            Me.ResultsGridEX.ExpandRecords()
            Me.CollapseGroupsCheckBox.Text = "Collapse groups"
        End If
    End Sub

    Private Sub GroupByBoxVisibleCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles GroupByBoxVisibleCheckBox.CheckedChanged
        Me.ResultsGridEX.GroupByBoxVisible = Me.GroupByBoxVisibleCheckBox.Checked
        Me.CollapseGroupsCheckBox.Visible = Me.GroupByBoxVisibleCheckBox.Checked
    End Sub
End Class