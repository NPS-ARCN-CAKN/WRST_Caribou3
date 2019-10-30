Imports System.Data.SqlClient
Imports System.IO
Imports Janus.Windows.GridEX
Imports SkeeterDataTablesTranslator

Public Class Form1
    Private Sub SurveyFlightsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataset()
        FormatGridEX(Me.SurveyFlightsGridEX)
        FormatGridEX(Me.SurveysGridEX)
        FormatGridEX(Me.CollaredAnimalsInGroupsGridEX)

        'set up default values for the flights grid
        SetSurveyFlightsGridExDefaultValues()
        SetSurveysGridEXDefaultValues()

        'load the survey flights gridex dropdowns
        SetSurveyFlightsGridEXDropDowns()
        SetUpSurveysGridEXDropDowns()

        'load the collared animal deployments from Animal Movement into the CollaredAnimalsGridEX
        SetUpCollaredAnimalsInGroupsGridEXDropDowns()
    End Sub

    Private Sub LoadDataset()
        Try
            Me.SurveyFlightsTableAdapter.Fill(Me.WRST_CaribouDataSet.SurveyFlights)
            Me.SurveysTableAdapter.Fill(Me.WRST_CaribouDataSet.Surveys)
            Me.CollaredAnimalsInGroupsTableAdapter.Fill(Me.WRST_CaribouDataSet.CollaredAnimalsInGroups)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub SaveDataset()
        Try
            Me.Validate()
            Me.CollaredAnimalsInGroupsBindingSource.EndEdit()
            Me.SurveysBindingSource.EndEdit()
            Me.SurveyFlightsBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
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

            'set up default values for child tables and also set up a header for user context
            'If Not Me.SurveyFlightsGridEX.CurrentRow Is Nothing Then
            '    If Not Me.SurveyFlightsGridEX.CurrentRow.Cells("FlightID") Is Nothing Then

            '        'set up flightid default values for child tables
            '        Dim FlightID As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")
            '        Me.SurveysGridEX.RootTable.Columns("FlightID").DefaultValue = FlightID
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Sets up the population data grid default values
    ''' </summary>
    Private Sub SetSurveysGridEXDefaultValues()
        Try
            Dim GridEX As GridEX = Me.SurveysGridEX
            GridEX.RootTable.Columns("EID").DefaultValue = Guid.NewGuid.ToString
            GridEX.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            GridEX.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
            GridEX.RootTable.Columns("GroupNumber").DefaultValue = GetMaximumGroupNumber(GridEX) + 1
            GridEX.RootTable.Columns("CertificationLevel").DefaultValue = "Raw"
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
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
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Sets up the SurveysGridEX default values and DropDowns/Combos
    ''' </summary>
    Private Sub SetUpSurveysGridEXDropDowns()

        'Set up default values
        Dim Grid As GridEX = Me.SurveysGridEX
        Grid.RootTable.Columns("EID").DefaultValue = Guid.NewGuid.ToString
        Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
        Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name

        'search areas dropdown
        'this line loads the csv list of search areas from my.settings into a datatable
        Dim SearchAreasDataTable As DataTable = GetSearchAreasDataTable()

        'set up the search area column to accept a dropdown
        With Grid.RootTable.Columns("SearchArea")
            .EditType = EditType.Combo
            .HasValueList = True
            .LimitToList = True
            .AllowSort = True
            .AutoComplete = True
            .ValueList.Clear()
        End With
        Dim SearchAreasList As GridEXValueListItemCollection = Grid.RootTable.Columns("SearchArea").ValueList
        'load in the searcharea items into the combobox
        For Each Row As DataRow In SearchAreasDataTable.Rows
            Dim SearchArea As String = Row.Item("SearchArea")
            SearchAreasList.Add(SearchArea, SearchArea)
        Next

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

    End Sub

    ''' <summary>
    ''' Sets up the SurveysGridEX default values and DropDowns/Combos
    ''' </summary>
    Private Sub SetUpCollaredAnimalsInGroupsGridEXDropDowns()
        'Try
        'Set up default values
        Dim Grid As GridEX = Me.CollaredAnimalsInGroupsGridEX

            'search areas dropdown
            'this line loads the csv list of search areas from my.settings into a datatable
            Dim Sql As String = ""
            Dim CollaredAnimalsDataTable As DataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)

        'set up the search area column to accept a dropdown
        With Grid.RootTable.Columns("AnimalID")
            .EditType = EditType.Combo
            .HasValueList = True
            .LimitToList = True
            .AllowSort = True
            .AutoComplete = True
            .ValueList.Clear()
        End With
        Dim AnimalsList As GridEXValueListItemCollection = Grid.RootTable.Columns("AnimalID").ValueList
        'load in the searcharea items into the combobox
        If CollaredAnimalsDataTable.Rows.Count > 0 Then
                For Each Row As DataRow In CollaredAnimalsDataTable.Rows
                    Dim AnimalID As String = Row.Item("AnimalID")
                    Dim Frequency As String = Row.Item("Frequency")
                    AnimalsList.Add(AnimalID, AnimalID)
                Next
            Else
                AnimalsList.Add("", "No collared animals found")
            End If
        'Catch ex As Exception
        '    MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        'End Try
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
    ''' Returns the maximum value of GridEX's column named GroupNumber. Used to increment GroupNumber as a default value for new records by adding 1.
    ''' </summary>
    ''' <returns></returns>
    Private Function GetMaximumGroupNumber(GridEX As GridEX) As Integer
        Dim MaxGroupNumber As Integer = 0
        If Not GridEX Is Nothing Then
            'determine the maximum group number
            For Each Row As GridEXRow In GridEX.GetRows()
                If Row.Cells("GroupNumber").Value > MaxGroupNumber Then
                    MaxGroupNumber = Row.Cells("GroupNumber").Value
                End If
            Next
        End If
        Return MaxGroupNumber
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

    Private Sub SurveysGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles SurveysGridEX.SelectionChanged
        'renew default values, especially to generate a new primary key value
        SetSurveysGridEXDefaultValues()
    End Sub

    Private Sub SurveyFlightsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.SelectionChanged
        'renew default values, especially to generate a new primary key value
        SetSurveyFlightsGridExDefaultValues()
    End Sub

    Private Sub CollaredAnimalsInGroupsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles CollaredAnimalsInGroupsGridEX.SelectionChanged
        'renew default values, especially to generate a new primary key value

    End Sub


    Private Sub ImportSurveyDataFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportSurveyDataFromFileToolStripButton.Click

        'get the current flightid from the survey flights grid
        Dim CurrentFlightID As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")

        'get the current herd from the surveys grid
        Dim CurrentHerd As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd")

        'if valid
        If Not CurrentFlightID Is Nothing And Not CurrentHerd Is Nothing Then

            If Not IsDBNull(CurrentFlightID) And Not IsDBNull(CurrentHerd) Then
                If Not CurrentFlightID.Trim.Length = 0 Or CurrentHerd.Trim.Length = 0 Then

                    'get the structure of the destination datatable, we only need one record since the translator will clear all records anyway
                    Dim Sql As String = "SELECT TOP 1 [SightingDate],[SearchArea],[GroupNumber],[SmallBull],[MediumBull],[LargeBull],[Bull],[Cow],[Calf],[Adult],[FrequenciesInGroup],[Lat],[Lon],[Out]
,[Seen],[Marked],[Mode],[Accuracy],[RetainedAntler],[DistendedUdders],[CalvesAtHeel],[WaypointName],[Comment],[SourceFilename],[FlightID],[RecordInsertedDate],[RecordInsertedBy],[EID]
  FROM [dbo].[Surveys]"

                    'use the structure of the query above to build a skeleton datatable
                    Dim DestinationDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)

                    'import the data from the selected file
                    ImportSurveyDataFromFile(DestinationDataTable, SurveyType.PopulationEstimate, CurrentHerd, CurrentFlightID)

                    'save the dataset
                    'SaveDataset()

                    'convert any animal counts of zero to null
                    ExecuteStoredProcedure("SP_CaribouGroupsZeroesToNulls")

                    'reload the corrected dataset
                    'LoadDataset()
                Else
                    MsgBox("There is no currently selected Flight to associate with any imported points (Zero length FlightID or Herd).")
                End If
            Else
                MsgBox("There is no currently selected Flight to associate with any imported points (FlightID or Herd is Null).")
            End If
        Else
            MsgBox("There is no currently selected Flight to associate with any imported points (FlightID or Herd is Nothing).")
        End If
    End Sub

    ''' <summary>
    ''' Survey types
    ''' </summary>
    Public Enum SurveyType
        CompositionCounts
        PopulationEstimate
        Radiotracking
    End Enum

    ''' <summary>
    ''' Loads a source file of waypoints and an intended destination DataTable, then opens a translator form to map the source columns into the destination datatable schema.
    ''' Finally, loads the transformed data into the DestinationDataTable.
    ''' </summary>
    ''' <param name="DestinationDataTable">DataTable. The DataTable schema into which the source DataTable's columns should be matched.</param>
    Private Sub ImportSurveyDataFromFile(DestinationDataTable As DataTable, SurveyType As SurveyType, Herd As String, FlightID As String)
        Dim DataLossMessage As String = "Important warning! The Excel driver used in this import tool may cause data loss. To avoid data loss make sure the data type of each column in the source Excel sheet is explicitly set. Do not use the Excel 'General' data type."
        Try
            If Not DestinationDataTable Is Nothing Then
                If SurveyType.ToString = "PopulationEstimate" Or SurveyType.ToString = "CompositionCounts" Or SurveyType.ToString = "Radiotracking" Then
                    If Herd = "Mentasta" Or Herd = "Chisana" Then
                        If FlightID.Trim.Length > 0 Then
                            Try
                                'get the data fileinfo to import
                                Dim SourceFileInfo As New FileInfo(GetFile("Select a data file to open. If Excel workbook the data to be imported must be in the first worksheet (tab).", "Survey data file (.csv;.xls;.xlsx)|*.csv;*.xls;*.xlsx|Comma separated values (.csv)|*.csv|Excel worksheet (.xlsx)|*.xlsx|Excel worksheet (.xls)|*.xls"))

                                'convert the file into a datatable so we can work with it
                                Dim InputDataTable As DataTable = Nothing

                                'determine if the input file is csv or excel
                                If SourceFileInfo.Extension = ".csv" Then
                                    'convert the data file into a datatable
                                    InputDataTable = GetDataTableFromDelimitedTextFile(SourceFileInfo, ",")
                                ElseIf SourceFileInfo.Extension = ".xlsx" Then
                                    'MsgBox(DataLossMessage, MsgBoxStyle.Information, "Important note on Excel spreadsheets")
                                    'Me.HelpProvider.SetHelpKeyword(Me, "Import")
                                    'convert the excel sheet into a datatable

                                    'IMEX=1 means all data will be treated as text. we had problems with group frequencies column being treated as numeric so it omitted any cells with commas separating frequencies
                                    'the Excel General data type confused .NET as to what kind of data to expect.
                                    'see https://www.connectionstrings.com/excel/
                                    Dim ExcelConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & SourceFileInfo.FullName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"
                                    Dim ExcelDataset As DataSet = GetDatasetFromExcelWorkbook(ExcelConnectionString)
                                    InputDataTable = ExcelDataset.Tables(0) 'can only grab the first worksheet (tab)
                                ElseIf SourceFileInfo.Extension = ".xls" Then
                                    MsgBox(DataLossMessage, MsgBoxStyle.Information, "Important note on Excel spreadsheets")

                                    'convert the excel sheet into a datatable
                                    Dim ExcelConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & SourceFileInfo.FullName & ";Extended Properties=""Excel 8.0;HDR=YES;IMEX=1"";"
                                    Dim ExcelDataset As DataSet = GetDatasetFromExcelWorkbook(ExcelConnectionString)
                                    InputDataTable = ExcelDataset.Tables(0) 'first worksheet
                                End If

                                'make a list of desired default values to pass into the data tables translator form
                                'these items will show up in the mappings datagridview's default values column to make things a little easier
                                Dim DefaultValuesList As New List(Of String)
                                With DefaultValuesList
                                    'add the search areas from my.settings to the default values
                                    For Each Item In My.Settings.SearchAreas.Split(",")
                                        .Add(Item)
                                    Next
                                    .Add("TRUE")
                                    .Add("FALSE")

                                    'common default values
                                    .Add(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")) 'the primary key of the currently selected flight
                                    .Add(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd")) 'the currently selected herd in the campaigns table
                                    .Add(SourceFileInfo.Name) 'the import file name
                                End With

                                'open up a datatable translator form to allow the user to map fields from the csv file to the destination datatable
                                Dim TranslatorForm As New SkeeterDataTablesTranslatorForm(InputDataTable, DestinationDataTable, "Import data", "Use the tool on the left to map the fields from your source data table to the destination data table.", DefaultValuesList)
                                TranslatorForm.ShowDialog()

                                'at this point we have transformed the csv into a clone of the destination datatable
                                Dim ImportDataTable As DataTable = TranslatorForm.DestinationDataTable

                                'the next step is to get the transformed data into the Surveys GridEX DataTable
                                'loop through the waypoints datatable and try to insert them into the datatable
                                Dim TableName As String = SurveyType.ToString
                                For Each Row As DataRow In ImportDataTable.Rows

                                    'make a new row
                                    Dim NewRow As DataRow = Me.WRST_CaribouDataSet.Tables("Surveys").NewRow
                                    For Each Column As DataColumn In ImportDataTable.Columns
                                        NewRow.Item(Column.ColumnName) = Row.Item(Column.ColumnName)
                                    Next

                                    'override any selections made on the translator form
                                    NewRow.Item("FlightID") = FlightID
                                    NewRow.Item("RecordInsertedDate") = Now
                                    NewRow.Item("RecordInsertedBy") = My.User.Name
                                    NewRow.Item("EID") = Guid.NewGuid.ToString

                                    'add the row
                                    Me.WRST_CaribouDataSet.Tables("Surveys").Rows.Add(NewRow)

                                    'end the edit
                                    Me.SurveysBindingSource.EndEdit()
                                Next

                            Catch ex As Exception
                                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
                            End Try
                        Else
                            MsgBox("FlightID is required")
                        End If
                    Else
                        MsgBox("Herd must be Mentasta or Chisana")
                    End If
                Else
                    MsgBox("SurveyType must be PopulationEstimate Object CompositionCount Or Radiotracking")
                End If
            Else
                MsgBox("DestinationDataTable cannot be nothing.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Executes the stored procedure on the WRST_Caribou database.
    ''' </summary>
    ''' <param name="ProcedureName">Name of the stored procedure to execute. String.</param>
    Private Sub ExecuteStoredProcedure(ProcedureName As String)
        Try
            Dim MySqlConnection As New SqlConnection(My.Settings.WRST_CaribouConnectionString)
            MySqlConnection.Open()

            Dim MySqlCommand As New SqlCommand(ProcedureName, MySqlConnection)
            MySqlCommand.CommandType = CommandType.StoredProcedure
            MySqlCommand.ExecuteNonQuery()
            MySqlCommand.Dispose()
            MySqlConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub



    '    ''' <summary>
    '    ''' Returns a DataTable of the WRST caribou collar deployments from the Animal_Movement database
    '    ''' </summary>
    '    ''' <returns>DataTable</returns>
    '    Public Function GetCollarDeploymentsDataTable() As DataTable
    '        Dim CollarDeploymentsDataTable As New DataTable
    '        Try
    '            Dim Sql As String = "SELECT Animals.AnimalId,   Collars.Frequency,CollarDeployments.DeploymentDate, CollarDeployments.RetrievalDate, 
    '                         Animals.MortalityDate, Collars.DisposalDate, Collars.HasGps, CollarDeployments.CollarManufacturer, Collars.CollarModel, Collars.SerialNumber, Animals.Species, Animals.Gender, Animals.GroupName, 
    '                         Animals.Description, Collars.Manager, Collars.Owner, Collars.Notes AS CollarNotes,       CONVERT(Varchar(20), Collars.Frequency) + ' - ' + Animals.AnimalId AS CollaredCaribou, CollarDeployments.CollarId, Animals.ProjectId, CollarDeployments.DeploymentId
    'FROM            Animals INNER JOIN
    '                         CollarDeployments ON Animals.ProjectId = CollarDeployments.ProjectId AND Animals.AnimalId = CollarDeployments.AnimalId INNER JOIN
    '                         Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId
    'WHERE        (Animals.ProjectId = 'WRST_Caribou')
    'ORDER BY Frequency"
    '            CollarDeploymentsDataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
    '            CollarDeploymentsDataTable.TableName = "CollarDeployments"
    '        Catch ex As Exception
    '            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
    '        End Try
    '        Return CollarDeploymentsDataTable
    '    End Function


End Class
