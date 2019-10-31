Imports System.Data.SqlClient
Imports System.IO
Imports Janus.Windows.GridEX
Imports SkeeterDataTablesTranslator

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'maximize
            Me.WindowState = FormWindowState.Maximized

            'load in the data from the WRST_Caribou SQL Server database
            LoadDataset()

            'For Each col As DataColumn In WRST_CaribouDataSet.Tables("Surveys").Columns
            '    Debug.Print("UPDATE Surveys SET " & col.ColumnName & " = NULL Where  " & col.ColumnName & " = 0;")
            'Next

            'format all the data grids more or less the same
            FormatGridEX(Me.SurveyFlightsGridEX)
            FormatGridEX(Me.SurveysGridEX)
            FormatGridEX(Me.CollaredAnimalsInGroupsGridEX)

            'set up default values for the grids
            SetSurveyFlightsGridExDefaultValues()
            SetSurveysGridEXDefaultValues()

            'load the default values for the grid columns
            SetUpSurveyFlightsGridEXDropDowns()
            SetUpSurveysGridEXDropDowns()

            'for some reason the surveys grid loads data when the form first loads despite no parent record being selected.
            'visibility is reversed on the flight grid's SelectionChanged event.
            Me.SurveysGridEX.Visible = False

            'load the collared animal deployments from Animal Movement into the CollaredAnimalsGridEX
            LoadAnimalIDSCombo()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try



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

            'set the collaredanimalsingroupsgridex eid value to the current group EID
            'Dim EID As String = GetCurrentGridEXCellValue(Me.SurveysGridEX, "EID")
            'If EID.Trim.Length > 0 Then
            '    Me.CollaredAnimalsInGroupsGridEX.RootTable.Columns("EID").DefaultValue = EID.Trim
            'End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Sets up the Flights GridEX dropdowns
    ''' </summary>
    Private Sub SetUpSurveyFlightsGridEXDropDowns()
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
    Private Sub SetUpCollaredAnimalsInGroupsGridEXDropDowns(SightingDate As Date)
        'Try
        'Set up default values
        Dim Grid As GridEX = Me.CollaredAnimalsInGroupsGridEX


        Dim Sql As String = "SELECT Animals.AnimalId
, CONVERT(Varchar(20), Collars.Frequency) + ' - ' + Animals.AnimalId + ' Deployed: ' + CONVERT(varchar(20),DeploymentDate)  +  ISNULL(' Collar retrieved: ' + CONVERT(varchar(20), RetrievalDate),'') +  ISNULL(' DEAD: ' + CONVERT(varchar(20), MortalityDate),'') AS CollaredCaribou
,Collars.Frequency,CollarDeployments.DeploymentDate, CollarDeployments.RetrievalDate, 
Animals.MortalityDate, Collars.DisposalDate, Collars.HasGps, CollarDeployments.CollarManufacturer, Collars.CollarModel, Collars.SerialNumber, Animals.Species, Animals.Gender, Animals.GroupName, 
Animals.Description, Collars.Manager, Collars.Owner, Collars.Notes AS CollarNotes

, CollarDeployments.CollarId, Animals.ProjectId, CollarDeployments.DeploymentId
FROM            Animals INNER JOIN
CollarDeployments ON Animals.ProjectId = CollarDeployments.ProjectId AND Animals.AnimalId = CollarDeployments.AnimalId INNER JOIN
Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId
WHERE        (Animals.ProjectId = 'WRST_Caribou') 
And (DeploymentDate < '" & SightingDate & "') and (RetrievalDate IS NULL Or RetrievalDate > '" & SightingDate & "')
ORDER BY Frequency"

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
                Dim CollaredCaribou As String = Row.Item("CollaredCaribou")
                AnimalsList.Add(AnimalID, AnimalID & " (" & CollaredCaribou & ")")
            Next
            'Else
            '    For i As Integer = 1 To 10
            '        AnimalsList.Add("TEST " & i, "TEST " & i & " (Frequency: " & i & i + 6 & i + 5 & "." & i + 456789 & ")")
            '    Next
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
        'Try
        'get the current row of the VS GridEX
        If Not GridEX Is Nothing Then
                If Not GridEX.CurrentRow Is Nothing Then
                    Dim CurrentRow As GridEXRow = GridEX.CurrentRow
                    If Not CurrentRow.Cells(GridEXColumnKey) Is Nothing Then
                        If Not IsDBNull(CurrentRow.Cells(GridEXColumnKey).Value) Then
                            CellValue = CurrentRow.Cells(GridEXColumnKey).Value
                        Else
                            CellValue = ""
                        End If
                    End If
                End If
            End If
            'Catch ex As Exception
            '    MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
            'End Try
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
        AskToSaveChanges()
    End Sub


    Private Sub AskToSaveChanges()
        If WRST_CaribouDataSet.HasChanges = True Then
            If MsgBox("You have unsaved changes. Save to database?", MsgBoxStyle.YesNo, "Save changes?") = MsgBoxResult.Yes Then
                SaveDataset()
            End If
        End If
    End Sub


    ''' <summary>
    ''' If the current Surveys record CertificationLevel value is Certified then lock all the Gridexes so nothing can be edited.
    ''' </summary>
    Private Sub LockCertifiedRecords()
        Try
            'first find out if any survey records are certified, if so then lock the parent flight GridEX so the flight record is unchanged
            If FlightContainsCertifiedRecords(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")) = True Then

                'disallow survey edits
                With Me.SurveyFlightsGridEX
                    .AllowAddNew = InheritableBoolean.True
                    .AllowDelete = InheritableBoolean.False
                    .AllowEdit = InheritableBoolean.False
                End With

            Else

                'allow survey edits
                With Me.SurveyFlightsGridEX
                    .AllowAddNew = InheritableBoolean.True
                    .AllowDelete = InheritableBoolean.True
                    .AllowEdit = InheritableBoolean.True
                End With
            End If


            'next, if the current Survey record is Certified then lock the GridEX
            Dim RecordIsCertified As Boolean = GetCurrentGridEXCellValue(Me.SurveysGridEX, "CertificationLevel") = "Certified"

            'if the record is certified
            If RecordIsCertified = True Then

                'disallow survey edits
                With Me.SurveysGridEX
                    .AllowAddNew = InheritableBoolean.False
                    .AllowDelete = InheritableBoolean.False
                    .AllowEdit = InheritableBoolean.False
                End With

                'disable the collared animals grid also
                With Me.CollaredAnimalsInGroupsGridEX
                    .AllowAddNew = InheritableBoolean.False
                    .AllowDelete = InheritableBoolean.False
                    .AllowEdit = InheritableBoolean.False
                End With

            Else

                'allow survey edits
                With Me.SurveysGridEX
                    .AllowAddNew = InheritableBoolean.True
                    .AllowDelete = InheritableBoolean.True
                    .AllowEdit = InheritableBoolean.True
                End With

                'allow edits to collared animals grid also
                With Me.CollaredAnimalsInGroupsGridEX
                    .AllowAddNew = InheritableBoolean.True
                    .AllowDelete = InheritableBoolean.True
                    .AllowEdit = InheritableBoolean.True
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Returns True if the current Survey record is Certified
    ''' </summary>
    ''' <param name="FlightID"></param>
    ''' <returns>Boolean</returns>
    Private Function FlightContainsCertifiedRecords(FlightID As String) As Boolean
        Dim ContainsCertifiedRecords As Boolean = False
        Try
            Dim Filter As String = "FlightID='" & FlightID & "' And CertificationLevel = 'Certified'"
            Dim DV As New DataView(WRST_CaribouDataSet.Tables("Surveys"), Filter, "", DataViewRowState.CurrentRows)
            If DV.Count > 0 Then ContainsCertifiedRecords = True
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return ContainsCertifiedRecords
    End Function

    Private Sub SurveyFlightsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles SurveyFlightsGridEX.SelectionChanged

        'make the surveys grid visible
        Me.SurveysGridEX.Visible = True

        'renew default values, especially to generate a new primary key value
        SetSurveyFlightsGridExDefaultValues()

        'renew the dropdowns
        SetUpSurveyFlightsGridEXDropDowns()

        'update the SurveyFlights header
        UpdateSurveyFlightsGridEXHeader()

        'lock editing on flight records if certified survey records exist
        LockCertifiedRecords()
    End Sub

    Private Sub SurveysGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles SurveysGridEX.SelectionChanged
        'renew default values, especially to generate a new primary key value
        SetSurveysGridEXDefaultValues()

        'disallow edits on certified records
        LockCertifiedRecords()

        'update the CollaredAnimalsInGroupsGridEX header
        UpdateCollaredAnimalsInGroupsGridEXHeader()

        PerformQCChecks()
    End Sub

    Private Sub CollaredAnimalsInGroupsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles CollaredAnimalsInGroupsGridEX.SelectionChanged
        'renew default values, especially to generate a new primary key value
        LockCertifiedRecords()

        'load the animalids from animal movements into the selector combo
        LoadAnimalIDSCombo()
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
                    Dim Sql As String = "SELECT TOP 1 [SightingDate]
,[SearchArea]
,[GroupNumber]
,[SmallBull]
,[MediumBull]
,[LargeBull]
,[Bull]
,[Cow]
,[Calf]
,[Adult]
,[FrequenciesInGroup]
,[Lat]
,[Lon]
,[Out]
,[Seen]
,[Marked]
,[Mode]
,[Accuracy]
,[RetainedAntler]
,[DistendedUdders]
,[CalvesAtHeel]
,[WaypointName]
,[Comment]
,[SourceFilename]
,[FlightID]
,[RecordInsertedDate]
,[RecordInsertedBy]
,[EID]
,[CertificationDate]
,[CertifiedBy]
,[CertificationLevel]
  FROM [dbo].[Surveys];"

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

    Private Sub SurveyFlightsGridEX_DeletingRecords(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SurveyFlightsGridEX.DeletingRecords
        If MsgBox("Delete this flight record and all related survey data?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            e.Cancel() = True
        End If
    End Sub

    Private Sub SurveysGridEX_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles SurveysGridEX.CellEdited

        'See if the user changed the CertificationLevel cell, if so, issue warnings and record metadata
        Dim Grid As GridEX = sender
        DoCertificationSteps(Grid, e)
    End Sub

    Private Sub DoCertificationSteps(GridEX As GridEX, e As ColumnActionEventArgs)
        'if the user changed CertificationLevel then the action must be logged in CertificationDate and CertifiedBy
        Try
            Dim Row As GridEXRow = GridEX.CurrentRow
            'make sure the cells exist
            If Not Row.Cells("CertificationLevel") Is Nothing And Not Row.Cells("CertifiedBy") Is Nothing And Not Row.Cells("CertificationDate") Is Nothing Then
                'if the edit changed CertificationLevel to 'Certified' and the CertifiedBy and CertificationDate cells are empty then fill them out so we know who certified the record and when
                If Row.Cells("CertificationLevel").Value.trim = "Certified" And (IsDBNull(Row.Cells("CertifiedBy").Value) And IsDBNull(Row.Cells("CertificationDate").Value)) Then
                    'if we get this far then the user certified the record, add the metadata
                    If MsgBox("IMPORTANT: Certification should be the very last step of the data processing life cycle as it will lock the current record against future changes. You will not be able to undo this action using this interface.

Also note that the parent Flight record and any related collared caribou association records will become locked as well. 

Ensure this record and any related records are of finished analytical quality, with any defects addressed and documented, before proceeding.

Click Yes to certify and lock the current record. Click No to cancel.", MsgBoxStyle.YesNo, "Certify this record?") = MsgBoxResult.Yes Then
                        Row.Cells("CertificationDate").Value = Now
                        Row.Cells("CertifiedBy").Value = My.User.Name
                    Else
                        'user chose not to certify the record. reset the certification columns
                        Row.Cells("CertificationLevel").Value = "Raw"
                        Row.CancelEdit()
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Pulls Animals and collar deployments from Animal Movements database and loads them into the 
    ''' combo selector of the CollaredAnimalsInGroupsGridEX
    ''' </summary>
    Private Sub LoadAnimalIDSCombo()
        'load the collared animal deployments from Animal Movement into the CollaredAnimalsGridEX
        Dim CurrentSightingDate As String = GetCurrentGridEXCellValue(Me.SurveysGridEX, "SightingDate")
        If IsDate(CurrentSightingDate) Then
            SetUpCollaredAnimalsInGroupsGridEXDropDowns(CDate(CurrentSightingDate))
        End If
    End Sub

    ''' <summary>
    ''' Update the CollaredAnimalsInGroupsGridEX's caption
    ''' </summary>
    Private Sub UpdateCollaredAnimalsInGroupsGridEXHeader()
        'update the collared animals gridex with any frequencies found in this caribou group. this makes matching frequencies to animals easier
        Me.CollaredAnimalsInGroupsGridEX.RootTable.Caption = "Collared animals in group"
        If Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveysGridEX, "FrequenciesInGroup")) Then
            If Not GetCurrentGridEXCellValue(Me.SurveysGridEX, "FrequenciesInGroup") Is Nothing Then
                Dim FrequenciesInGroup As String = GetCurrentGridEXCellValue(Me.SurveysGridEX, "FrequenciesInGroup")
                If FrequenciesInGroup.Trim.Length > 0 Then
                    Me.CollaredAnimalsInGroupsGridEX.RootTable.Caption = "Collared animals in group (Current frequencies: " & FrequenciesInGroup
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Update the SurveyFlightsGridEX's caption
    ''' </summary>
    Private Sub UpdateSurveyFlightsGridEXHeader()
        'update the collared animals gridex with any frequencies found in this caribou group. this makes matching frequencies to animals easier
        Me.SurveyFlightsGridEX.RootTable.Caption = "Flights"

        'update the caption with the info
        If Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "TimeDepart")) And Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd")) And Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "SurveyType")) And Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Observer1")) And Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "TailNo")) Then
            Dim TimeDepart As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "TimeDepart")
            Dim Herd As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd")
            Dim SurveyType As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "SurveyType")
            Dim TailNo As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "TailNo")
            Dim Observer1 As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Observer1")
            Me.SurveyFlightsGridEX.RootTable.Caption = "Flight: " & TimeDepart & " " & Herd & " " & SurveyType & " " & TailNo & " " & Observer1
        End If
    End Sub

    Private Sub ReconcileFrequencies()

    End Sub

    ''' <summary>
    ''' Returns the number of comma separated frequencies in FrequenciesInGroup
    ''' </summary>
    ''' <param name="EID"></param>
    ''' <returns></returns>
    Private Function GetNumberOfFrequenciesInGroup(EID As String) As Integer

    End Function

    Private Sub PerformQCChecks()
        'check that the number of frequencies in Surveys.FrequenciesInGroup column match the number of items in the CollaredAnimalsInGroups table for the record
        'Try
        For Each Row As GridEXRow In SurveysGridEX.GetRows
            If Not IsDBNull(Row.Cells("FrequenciesInGroup").Value) Then
                Dim FrequenciesInGroup As String = Row.Cells("FrequenciesInGroup").Value
                Dim EID As String = Row.Cells("EID").Value
                Dim NumberOfFrequencies As Integer = 0
                Dim NumberOfAnimalIDs As Integer = 0
                For Each Frequency In FrequenciesInGroup.Split(",")
                    Frequency = Frequency.Trim
                    If IsNumeric(Frequency.Trim) = True Then
                        NumberOfFrequencies = NumberOfFrequencies + 1
                        Dim Filter As String = "EID = '" & EID & "'"
                        Dim AnimalIDsDataView As New DataView(WRST_CaribouDataSet.Tables("CollaredAnimalsInGroups"), Filter, "", DataViewRowState.CurrentRows)
                        NumberOfAnimalIDs = AnimalIDsDataView.Count
                    End If
                Next
                Row.BeginEdit()
                Row.Cells("FrequenciesCount").Value = NumberOfFrequencies
                Row.Cells("NumAnimalIDs").Value = NumberOfAnimalIDs
                Row.EndEdit()
            End If
        Next

        'Catch ex As Exception
        '    Debug.Print(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        'End Try
    End Sub

    ''' <summary>
    ''' Auto-matches a GPS collar Frequency to an AnimalID in the Animal Movement database. Helper sub to process GridEX rows from AutomatchFrequenciesToAnimals()
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <param name="MissingFrequenciesArrayList"></param>
    Private Sub AutomatchFrequencyToAnimal(Row As GridEXRow, MissingFrequenciesArrayList As ArrayList)

        'resolve any changes to the database to avoid duplicate primary key problems
        AskToSaveChanges()

        Try
            'extract the frequencies from the row's FrequenciesInGroup column and try to parse it, search for the correct animalid and insert it into the cross reference table
            If Not Row Is Nothing Then
                If Not Row.Cells("FrequenciesInGroup") Is Nothing And Not Row.Cells("SightingDate") Is Nothing And Not Row.Cells("EID") Is Nothing Then
                    If Not IsDBNull(Row.Cells("FrequenciesInGroup").Value) And Not IsDBNull(Row.Cells("SightingDate").Value) And Not IsDBNull(Row.Cells("EID").Value) Then

                        'get caribou group row values into variables
                        Dim FrequenciesInGroup As String = Row.Cells("FrequenciesInGroup").Value
                        Dim SightingDate As String = Row.Cells("SightingDate").Value

                        'parse the comma separated frequencies so we can deal with them individually
                        For Each Frequency In FrequenciesInGroup.Split(",")
                            Frequency = Frequency.Trim
                            If IsNumeric(Frequency.Trim) = True Then
                                Dim AnimalID As String = GetAnimalIDFromFrequencyAndObservationDate(Frequency, SightingDate)
                                'Dim Comment As String = ""
                                'If AnimalID.Length = 0 Then
                                '    'the collar was not found in the AM database, add to the list so we can inform the user of data quality issues.
                                '    MissingFrequenciesArrayList.Add(Frequency & "," & SightingDate)
                                '    AnimalID = "FRQ: " & Frequency
                                '    Comment = "Frequency not found in AM at time of insertion (" & My.User.Name & " " & Now & ")"
                                'End If

                                'add the animalid to the XrefDataTable
                                Dim XrefDataTable As DataTable = Me.WRST_CaribouDataSet.Tables("CollaredAnimalsInGroups")
                                'see if the AnimalID already exists
                                Dim Filter As String = "EID" & " = '" & Row.Cells("EID").Value & "' And AnimalID='" & AnimalID & "'"
                                Dim ExistenceCheck As DataRow() = XrefDataTable.Select(Filter)
                                If ExistenceCheck.Count = 0 Then
                                    'the animalid does not exist for the animal group
                                    Dim XrefDataRow As DataRow = XrefDataTable.NewRow
                                    With XrefDataRow
                                        .Item("AnimalID") = AnimalID
                                        .Item("EID") = Row.Cells("EID").Value
                                        '.Item("Comment") = Comment
                                    End With
                                    If AnimalID.Trim.Length > 0 Then
                                        XrefDataTable.Rows.Add(XrefDataRow)
                                    End If

                                End If
                            End If
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub AutoMatchFrequenciesToAnimalsToolStripButton_Click(sender As Object, e As EventArgs) Handles AutoMatchFrequenciesToAnimalsToolStripButton.Click
        Dim Explanation As String = "The application will cross reference the Group Frequencies for this record with GPS collar deployments found in the Animal Movement database.
            Frequency records matching collar deployments will be inserted into the matching collared caribou table to the right. 
            No existing records will be deleted. No duplicate records will be added.  
            Yes to Continue. No to cancel."
        If MsgBox(Explanation, MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                'this arraylist will hold any frequencies not found in animal movement tool
                Dim MissingFrequenciesArrayList As New ArrayList
                Dim GridEX As GridEX = Me.SurveysGridEX
                If Not GridEX.CurrentRow Is Nothing Then
                    AutomatchFrequencyToAnimal(GridEX.CurrentRow, MissingFrequenciesArrayList)
                    ShowMissingFrequenciesList(MissingFrequenciesArrayList)
                Else
                    MsgBox("Select a row")
                End If
            Catch ex As Exception
                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Helper Sub to show which GPS collar frequencies were not matched to animal groups, most likely because the collar is not registered or deployed in the Animal Movement database.
    ''' </summary>
    ''' <param name="MissingFrequenciesArrayList"></param>
    Private Sub ShowMissingFrequenciesList(MissingFrequenciesArrayList As ArrayList)
        If MissingFrequenciesArrayList.Count > 1 Then
            Dim Warning As String = "WARNING: The following Frequencies were not associated with any deployed collar on the date the caribou group was observed" & vbNewLine
            Dim Message As String = ""
            For Each Freq In MissingFrequenciesArrayList
                Message = Message & Freq & vbNewLine
            Next
            Message = Message & vbNewLine & vbNewLine & "Ctl-C to copy this message to your clipboard."
            MsgBox(Warning & Message, MsgBoxStyle.Exclamation, "WARNING")
        End If
    End Sub

    Private Sub ChangeOrientationToolStripButton_Click(sender As Object, e As EventArgs) Handles ChangeOrientationToolStripButton.Click
        If SurveysSplitContainer.Orientation = Orientation.Vertical Then
            SurveysSplitContainer.Orientation = Orientation.Horizontal
        Else
            SurveysSplitContainer.Orientation = Orientation.Vertical
        End If
    End Sub

    Private Sub ReloadDatasetToolStripButton_Click(sender As Object, e As EventArgs) Handles ReloadDatasetToolStripButton.Click
        AskToSaveChanges()
        LoadDataset()
    End Sub
End Class
