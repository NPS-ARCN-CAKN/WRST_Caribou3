Imports Janus.Windows.GridEX

Public Class Form1
    Private Sub SurveyFlightsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataset()
        FormatGridEX(Me.SurveyFlightsGridEX)
        FormatGridEX(Me.SurveysGridEX)
        FormatGridEX(Me.SurveysGridEX)

        'set up default values for the flights grid
        SetSurveyFlightsGridExDefaultValues()

        'load the survey flights gridex dropdowns
        SetSurveyFlightsGridEXDropDowns()
    End Sub

    Private Sub LoadDataset()
        Me.SurveyFlightsTableAdapter.Fill(Me.WRST_CaribouDataSet.SurveyFlights)
        Me.SurveysTableAdapter.Fill(Me.WRST_CaribouDataSet.Surveys)
        Me.CollaredAnimalsInGroupsTableAdapter.Fill(Me.WRST_CaribouDataSet.CollaredAnimalsInGroups)
    End Sub

    Private Sub SaveDataset()
        Me.Validate()
        Me.CollaredAnimalsInGroupsBindingSource.EndEdit()
        Me.SurveysBindingSource.EndEdit()
        Me.SurveyFlightsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)
    End Sub

    ''' <summary>
    ''' Sets up the Flights GridEX's default values
    ''' </summary>
    Private Sub SetSurveyFlightsGridExDefaultValues()
        Try
            'Set up default values
            Dim Grid As GridEX = Me.SurveyFlightsGridEX
            Grid.RootTable.Columns("FlightID").DefaultValue = Guid.NewGuid.ToString
            Grid.RootTable.Columns("IsFollowUpFlight").DefaultValue = 0
            Grid.RootTable.Columns("SOPNumber").DefaultValue = 0
            Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
            Grid.RootTable.Columns("CertificationLevel").DefaultValue = "Raw"


            'CrewNumber default value
            Dim MaxCrewNumber As Integer = 0
            For Each row As GridEXRow In Grid.GetRows()
                If row.Cells("CrewNumber").Value > MaxCrewNumber Then
                    MaxCrewNumber = row.Cells("CrewNumber").Value
                End If
            Next
            Grid.RootTable.Columns("CrewNumber").DefaultValue = MaxCrewNumber + 1

            'SOPVersion default value
            Dim MaxSOPVersion As Integer = 0
            For Each row As GridEXRow In Grid.GetRows()
                If row.Cells("SOPVersion").Value > MaxSOPVersion Then
                    MaxSOPVersion = row.Cells("SOPVersion").Value
                End If
            Next
            Grid.RootTable.Columns("SOPVersion").DefaultValue = MaxSOPVersion

            ''set up default values for child tables and also set up a header for user context
            'If Not Me.SurveyFlightsGridEX.CurrentRow Is Nothing Then
            '    If Not Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID") Is Nothing Then

            '        'set up flightid default values for child tables
            '        Dim FlightID As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")
            '        Me.RadioTrackingGridEX.RootTable.Columns("FlightID").DefaultValue = FlightID
            '        Me.CompositionCountsGridEX.RootTable.Columns("FlightID").DefaultValue = FlightID
            '        Me.PopulationEstimateGridEX.RootTable.Columns("FlightID").DefaultValue = FlightID
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Sets up the Flights GridEX dropdowns
    ''' </summary>
    Private Sub SetSurveyFlightsGridEXDropDowns()
        Try
            Dim Grid As GridEX = Me.SurveyFlightsGridEX
            'Set up dropdowns
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Pilot", "Pilot", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "TailNo", "TailNo", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "AircraftType", "AircraftType", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Observer1", "Observer1", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Observer2", "Observer2", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "SOPNumber", "SOPNumber", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "SOPVersion", "SOPVersion", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "Pilot", "SpotterPlanePilot", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "TailNo", "SpotterPlaneTailNo", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, Me.WRST_CaribouDataSet.Tables("SurveyFlights"), "AircraftType", "SpotterPlaneType", False)

            'SurveyType dropdown
            With Grid.RootTable.Columns("SurveyType")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = True
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
            End With
            Dim SurveysSurveyTypeList As GridEXValueListItemCollection = Grid.RootTable.Columns("SurveyType").ValueList
            SurveysSurveyTypeList.Add("CC", "Composition count")
            SurveysSurveyTypeList.Add("PE", "Population estimate")
            SurveysSurveyTypeList.Add("RT", "Radiotracking")

            'Herd dropdown
            With Grid.RootTable.Columns("Herd")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = True
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
            End With
            Dim SurveysHerdList As GridEXValueListItemCollection = Grid.RootTable.Columns("Herd").ValueList
            SurveysHerdList.Add("Chisana", "Chisana")
            SurveysHerdList.Add("Mentasta", "Mentasta")

            'CertificationLevel dropdown
            With Grid.RootTable.Columns("CertificationLevel")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = True
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
            End With
            Dim CertificationLevelList As GridEXValueListItemCollection = Grid.RootTable.Columns("CertificationLevel").ValueList
            CertificationLevelList.Add("Raw", "Raw")
            CertificationLevelList.Add("Provisional", "Provisional")
            CertificationLevelList.Add("Accepted", "Accepted")
            CertificationLevelList.Add("Certified", "Certified")

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Returns the current value of the cell specified by GridEXColumnKey of the current row of GridEX.
    ''' </summary>
    ''' <param name="GridEX">GridEX to search. GridEX</param>
    ''' <param name="GridEXColumnKey">The key (name) of the GridEX column from which you would like the current value. String.</param>
    ''' <returns></returns>
    Private Function GetCurrentGridEXCellValue(GridEX As GridEX, GridEXColumnKey As String) As String
        Dim CellValue As String = ""
        Try
            'get the current row of the VS GridEX
            If Not GridEX.CurrentRow Is Nothing Then
                Dim CurrentRow As GridEXRow = GridEX.CurrentRow
                If Not CurrentRow.Cells(GridEXColumnKey) Is Nothing Then
                    If Not IsDBNull(CurrentRow.Cells(GridEXColumnKey)) Then
                        CellValue = CurrentRow.Cells(GridEXColumnKey).Value
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return CellValue
    End Function

    ''' <summary>
    ''' Loads distinct items from a DataTable's DataColumn into a GridEX GridEXColumn's DropDown ValueList
    ''' </summary>
    ''' <param name="GridEX">The GridEX containing the GridEXColumn requiring a DropDown ValueList</param>
    ''' <param name="SourceDataTable">Name of the DataTable containing the DataColumn from which distinct values will be drawn</param>
    ''' <param name="SourceColumnName">Name of the source DataTable's DataColumn from which distinct values will be drawn</param>
    ''' <param name="GridEXColumnName">Name of the GridEX column into which to load dropdown values</param>
    '''  <param name="LimitToList">Whether options for the dropdown should be limited to the list or not. Boolean.</param>
    Private Sub LoadGridEXDropDownWithDistinctDataTableValues(GridEX As GridEX, SourceDataTable As DataTable, SourceColumnName As String, GridEXColumnName As String, LimitToList As Boolean)
        Try
            'Ensure the GridEXColumn is configured for a DropDown
            With GridEX.RootTable.Columns(GridEXColumnName)
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = LimitToList
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
            End With

            'Get the distinct items from a DataTable
            Dim DistinctItemsDataTable As DataTable = SourceDataTable.DefaultView.ToTable(True, SourceColumnName)

            'Sort the DataView
            Dim DistinctItemsDataView As New DataView(DistinctItemsDataTable, "", SourceColumnName, DataRowState.Unchanged)

            'Make a GridEXValueListItemCollection to hold the distinct items
            Dim ItemsList As GridEXValueListItemCollection = GridEX.RootTable.Columns(GridEXColumnName).ValueList

            'Add the distinct items from the DataView into the GridEXValueListItemCollection
            If DistinctItemsDataView.Table.Rows.Count > 0 Then
                For Each Row As DataRow In DistinctItemsDataView.Table.Rows
                    If Not IsDBNull(Row.Item(SourceColumnName)) Then
                        Dim Item As String = Row.Item(SourceColumnName)
                        ItemsList.Add(Item, Item)
                    End If
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Standardizes the look, feel and function of a GridEX
    ''' </summary>
    ''' <param name="GridEX">The GridEX to set up</param>
    Private Sub FormatGridEX(GridEX As GridEX)
        Try
            Dim MyFont As New Font("Sans Serif", 10, FontStyle.Regular)
            With GridEX
                'by default make grids readonly; toggle editability using ToggleGridEXReadOnly function
                .AllowAddNew = InheritableBoolean.True
                .AllowDelete = InheritableBoolean.True
                .AllowEdit = InheritableBoolean.True
                .AlternatingColors = True
                .AutoEdit = False
                .AutomaticSort = True
                .CardBorders = False
                .CardHeaders = True
                .ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells
                .ColumnHeaders = InheritableBoolean.True
                .Font = MyFont
                .FilterMode = FilterMode.None
                .NewRowPosition = NewRowPosition.BottomRow
                .RecordNavigator = True
                .RowHeaders = InheritableBoolean.True
                .SelectionMode = SelectionMode.MultipleSelection
                .SelectOnExpand = False
                .TotalRowPosition = TotalRowPosition.BottomFixed
                .SelectedFormatStyle.BackColor = Color.SteelBlue
                .SelectedFormatStyle.ForeColor = Color.White
                .SelectedFormatStyle.FontBold = TriState.False
                .SelectedInactiveFormatStyle.BackColor = Color.SteelBlue
                .SelectedInactiveFormatStyle.ForeColor = Color.White
                .SelectedInactiveFormatStyle.FontBold = TriState.False
            End With
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        SaveDataset()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If WRST_CaribouDataSet.HasChanges = True Then
            If MsgBox("You have unsaved changes. Save to database?", MsgBoxStyle.YesNo, "Save changes?") = MsgBoxResult.Yes Then
                SaveDataset()
            End If
        End If
    End Sub
End Class
