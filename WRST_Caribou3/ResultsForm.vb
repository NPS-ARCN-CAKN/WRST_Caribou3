Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraMap
Imports Janus.Windows.GridEX

Public Class ResultsForm

    Dim ResultsDataTable As DataTable 'This reusable datatable will contain the data to be displayed in the Me.SurveyResultsDataGridView of the Results tab

    Private Sub ResultsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDatabaseViewsComboBox()


        Me.ResultsGridEX.GroupByBoxVisible = True
        Me.CollapseGroupsCheckBox.Visible = True
        Me.ResultsGridEX.FilterMode = FilterMode.Automatic
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
                    Dim ViewName As String = Row.Item("Name")

                    .Items.Add(ViewName)
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

                'Clear data sources
                Me.DatasetGridControl.DataSource = Nothing
                Me.DatasetVGridControl.DataSource = Nothing
                Me.DatasetPivotGridControl.DataSource = Nothing
                Me.DatasetMapControl.Layers.Clear()

                'Show the query name in the header
                Me.DataSummariesLabel.Text = ViewName


                'get the view description
                Try
                    Dim ViewDescription As String = ViewName
                    Dim DescriptionQuery As String = "SELECT [Table],[TableDescription] FROM [WRST_Caribou].[dbo].[DatabaseTableDescriptions] where [table]='" & ViewName & "'"
                    Dim ViewDT As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, DescriptionQuery)
                    If ViewDT.Rows.Count = 1 Then
                        ViewDescription = ViewDT.Rows(0).Item("TableDescription")
                    End If
                    Me.ViewDescriptionTextBox.Text = ViewDescription

                Catch ex As Exception
                    Me.ViewDescriptionTextBox.Text = ex.Message
                End Try


                'get the data from the selected view into a datatable
                Dim Filter As String = ""
                Dim Sql As String = "SELECT * FROM " & ViewName.Trim & Filter
                ResultsDataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)

                'Set the DatasetBindingSource to ResultsDataTable
                Me.DatasetBindingSource.DataSource = ResultsDataTable

                'Set up the GridControl
                Me.DatasetGridControl.DataSource = DatasetBindingSource
                SetUpGridControl(Me.DatasetGridControl)

                'Populate the main GridControl's main GridView
                Dim GV As GridView = TryCast(Me.DatasetGridControl.MainView, GridView)
                GV.PopulateColumns()

                'Bind the data to the VGridControl
                With Me.DatasetVGridControl
                    .DataSource = Me.DatasetBindingSource
                    .RetrieveFields()
                End With


                'Set up the pivot grid
                With Me.DatasetPivotGridControl
                    .DataSource = ResultsDataTable
                    .RetrieveFields()
                End With
                SetUpPivotGridControl(Me.DatasetPivotGridControl)

                'Set up the ChartControl
                Me.DatasetChartControl.DataSource = Me.DatasetPivotGridControl


                'Map
                Dim LatColumnExists As Boolean = False
                Dim LonColumnExists As Boolean = False
                Dim LatColumnName As String = ""
                Dim LonColumnName As String = ""
                For Each Col As DataColumn In ResultsDataTable.Columns
                    If Col.ColumnName.Trim.ToLower = "lat" Or Col.ColumnName.Trim.ToLower = "latitude" Then
                        LatColumnExists = True
                        LatColumnName = Col.ColumnName
                    End If

                    If Col.ColumnName.Trim.ToLower = "lon" Or Col.ColumnName.Trim.ToLower = "longitude" Then
                        LonColumnExists = True
                        LonColumnName = Col.ColumnName
                    End If
                Next

                If LatColumnExists = True And LonColumnExists = True Then
                    Try
                        Dim MapLayer As VectorItemsLayer = GetBubbleVectorItemsLayerFromPointsDataTable(ResultsDataTable, LatColumnName, LonColumnName, 4, MarkerType.Circle, Color.Red)
                        Me.DatasetMapControl.Layers.Add(MapLayer)
                    Catch ex As Exception
                        MsgBox("Map layer costruction failed: " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
                    End Try
                End If




                ''load the datatable into the GridEX
                'With Me.ResultsGridEX
                '    .DataSource = DatasetBindingSource
                '    .RetrieveStructure()
                '    .GroupTotals = GroupTotals.Always
                'End With

                ''format total rows
                'For Each Col As GridEXColumn In Me.ResultsGridEX.RootTable.Columns
                '    'If Col.Key <> "Year" And Col.Key <> "Lat" And Col.Key <> "Long" Then
                '    '    If Col.DataTypeCode = TypeCode.Int16 Or Col.DataTypeCode = TypeCode.Int32 Or Col.DataTypeCode = TypeCode.Int64 Then
                '    '        Col.AggregateFunction = AggregateFunction.Sum
                '    '    ElseIf Col.DataTypeCode = TypeCode.Double Or Col.DataTypeCode = TypeCode.Decimal Or Col.DataTypeCode Then
                '    '        Col.AggregateFunction = AggregateFunction.Average
                '    '    Else
                '    '        Col.AggregateFunction = AggregateFunction.None
                '    '    End If
                '    'End If

                '    'other things
                '    Col.FormatString = ""
                'Next
            Catch ex As Exception
                MsgBox("Could not load the database view " & ViewName.Trim & ". " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & " a)")
                Me.DatasetMapControl.Layers.Clear()
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

    Private Sub ExportToCSVToolStripButton_Click(sender As Object, e As EventArgs) Handles ExportToCSVToolStripButton.Click
        Try
            ExportDataTable(ResultsDataTable)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub ReloadQueryToolStripButton_Click(sender As Object, e As EventArgs) Handles ReloadQueryToolStripButton.Click
        LoadResultsGrid()
        Me.ResultsGridEX.CollapseGroups()
        Me.ResultsGridEX.CollapseRecords()
    End Sub

    ''' <summary>
    ''' Returns a DevExpress VectorItemsLayer of MapBubble points derived a DataTable containing Lat/Lon pairs.
    ''' </summary>
    ''' <param name="PointsDataTable">DataTable containing points spatial data. DataTable</param>
    ''' <param name="LatitudeColumnName">Name of the latitude column. String.</param>
    ''' <param name="LongitudeColumnName">Name of the longitude column. String.</param>
    ''' <returns>VectorItemLayer of points from WKT.</returns>
    Public Function GetBubbleVectorItemsLayerFromPointsDataTable(PointsDataTable As DataTable, LatitudeColumnName As String, LongitudeColumnName As String, FeatureSize As Integer, MarkerType As MarkerType, FillColor As Color) As DevExpress.XtraMap.VectorItemsLayer
        Dim MyMapItemStorage As New MapItemStorage

        Dim MyPointsVectorItemsLayer As New VectorItemsLayer()
        If LatitudeColumnName.Trim <> "" And LongitudeColumnName.Trim <> "" Then
            For Each MyPointDataRow As DataRow In PointsDataTable.Rows
                If Not MyPointDataRow Is Nothing Then
                    If Not IsDBNull(MyPointDataRow.Item(LatitudeColumnName)) And Not IsDBNull(MyPointDataRow.Item(LongitudeColumnName)) Then
                        Dim Lat As Double = CDbl(MyPointDataRow.Item(LatitudeColumnName))
                        Dim Lon As Double = CDbl(MyPointDataRow.Item(LongitudeColumnName))
                        Dim MyMapBubble As New MapBubble()
                        With MyMapBubble
                            .Location = New GeoPoint(Lat, Lon)
                            .Value = 400

                            'Add the DataRow's attributes to the MapBubble object
                            For Each Col As DataColumn In PointsDataTable.Columns
                                Dim MIA As New MapItemAttribute
                                With MIA
                                    .Name = Col.ColumnName
                                    .Value = MyPointDataRow.Item(Col.ColumnName)
                                End With
                                .Attributes.Add(MIA)
                            Next
                            .MarkerType = MarkerType
                            .Fill = FillColor
                        End With
                        MyMapItemStorage.Items.Add(MyMapBubble)
                    End If
                End If
            Next
            With MyPointsVectorItemsLayer
                .Data = MyMapItemStorage
                .Name = PointsDataTable.TableName & "Bubbles"
            End With
        End If
        Return MyPointsVectorItemsLayer
    End Function
End Class