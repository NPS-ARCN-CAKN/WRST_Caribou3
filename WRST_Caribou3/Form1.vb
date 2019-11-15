Imports System.Data.SqlClient
Imports System.IO
Imports Janus.Windows.GridEX
Imports SkeeterDataTablesTranslator

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'make the form a reasonable size if not maximized
        Me.Width = 1200
        Me.Height = 800

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
            FormatGridEX(Me.AnimalGridEX)
            FormatGridEX(Me.CapturesGridEX)

            'set up default values for the grids
            SetSurveyFlightsGridExDefaultValues()
            SetSurveysGridEXDefaultValues()



            'for some reason the surveys grid loads data when the form first loads despite no parent record being selected.
            'visibility is reversed on the flight grid's SelectionChanged event.
            SetGridEXesVisible(False)

            'set the flights gridex caption to something generic
            Me.SurveyFlightsGridEX.RootTable.Caption = "Caribou survey flights inventory"

            'load the collared animal deployments from Animal Movement into the CollaredAnimalsGridEX
            LoadAnimalIDSCombo()

            'load the default values for the grid columns
            SetUpSurveyFlightsGridEXDropDowns()
            SetUpSurveysGridEXDropDowns()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try



    End Sub

    ''' <summary>
    ''' The GridEXes tend to show data before any parent or related records have been selected. I like to set the child GridEXes invisible at start up and then toggle them visible as the first parent record is selected.
    ''' </summary>
    ''' <param name="Visible"></param>
    Private Sub SetGridEXesVisible(Visible As Boolean)
        Me.SurveysGridEX.Visible = Visible
        Me.CollaredAnimalsInGroupsGridEX.Visible = Visible
        Me.AnimalGridEX.Visible = Visible
        Me.DeploymentsGridEX.Visible = Visible
        Me.CapturesGridEX.Visible = Visible
        Me.SurveysToolStrip.Visible = Visible
    End Sub



    Private Sub LoadDataset()
        Try
            Me.SurveyFlightsTableAdapter.Fill(Me.WRST_CaribouDataSet.SurveyFlights)
            Me.SurveysTableAdapter.Fill(Me.WRST_CaribouDataSet.Surveys)
            Me.CollaredAnimalsInGroupsTableAdapter.Fill(Me.WRST_CaribouDataSet.CollaredAnimalsInGroups)
            Me.CapturesTableAdapter.Fill(Me.WRST_CaribouDataSet.Captures)
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
            Grid.RootTable.Columns("SOPNumber").DefaultValue = 0
            Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name

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
            If Not Me.SurveysGridEX Is Nothing Then
                Dim GridEX As GridEX = Me.SurveysGridEX
                GridEX.RootTable.Columns("EID").DefaultValue = Guid.NewGuid.ToString
                GridEX.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
                GridEX.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
                GridEX.RootTable.Columns("GroupNumber").DefaultValue = GetMaximumGroupNumber(GridEX) + 1
                GridEX.RootTable.Columns("CertificationLevel").DefaultValue = "Raw"

                'set the default survey date to the current surveyflights date  
                Dim FlightDate As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "TimeDepart")
                If Not IsDBNull(FlightDate) Then
                    If IsDate(FlightDate) = True Then
                        Me.SurveysGridEX.RootTable.Columns("SightingDate").DefaultValue = FlightDate
                    End If
                End If
            End If
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
        Try
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
    ''' Returns the collar frequency of animal designated AnimalID on a particular sample date
    ''' </summary>
    ''' <param name="AnimalID"></param>
    ''' <param name="SampleDate"></param>
    ''' <returns>Double</returns>
    Private Function GetFrequencyFromAnimalIDAndDate(AnimalID As String, SampleDate As Date) As Double
        Dim Frequency As Double = 0
        Dim AnimalsDataTable As DataTable = GetAnimalsDataTable()
        Dim Filter As String = "(AnimalID = '" & AnimalID & "') And (DeploypmentDate < '" & SampleDate & "' And RetrievalDate < '" & SampleDate & "')"
        Dim DV As New DataView(AnimalsDataTable, Filter, "", DataViewRowState.CurrentRows)
        If DV.Count = 1 Then
            Frequency = DV(0).Item("Frequency")
        End If
        Return Frequency
    End Function

    ''' <summary>
    ''' Untested 2019-11-06. Returns the AnimalID for a Frequency detected at a certain SampleDate
    ''' </summary>
    ''' <param name="Frequency">Frequency. Double.</param>
    ''' <param name="SampleDate">SampleDate. Date.</param>
    ''' <returns></returns>
    Private Function GetAnimalIDFromFrequencyAndDate(Frequency As Double, SampleDate As Date) As Double
        Dim AnimalID As Double = 0
        Dim AnimalsDataTable As DataTable = GetAnimalsDataTable()
        Dim Filter As String = "(Frequency = " & Frequency & ") And (DeploypmentDate < '" & SampleDate & "' And RetrievalDate < '" & SampleDate & "')"
        Dim DV As New DataView(AnimalsDataTable, Filter, "", DataViewRowState.CurrentRows)
        If DV.Count = 1 Then
            AnimalID = DV(0).Item("AnimalID")
        End If
        Return AnimalID
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
            If Not GridEX Is Nothing Then
                If Not SourceDataTable Is Nothing Then
                    If Not SourceColumnName Is Nothing Then
                        If Not SourceColumnName.Trim.Length = 0 Then
                            If Not GridEXColumnName Is Nothing Then
                                If Not GridEXColumnName.Trim.Length = 0 Then
                                    'Ensure the GridEXColumn is configured for a DropDown
                                    With GridEX.RootTable.Columns(GridEXColumnName)
                                        .EditType = EditType.Combo
                                        .HasValueList = True
                                        .LimitToList = LimitToList
                                        .AllowSort = True
                                        .AutoComplete = True
                                        .ValueList.Clear()
                                        .Key = GridEXColumnName
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
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            'this conditional is a workaround for a problem where when the dataset is refreshed from the database we get errors: ""Value cannot be null. Parameter Name: key"
            If ex.Message = "Value cannot be null.
Parameter name: key" Then
                'do nothing, it seems to work fine failing
                'Debug.Print(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            Else
                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            End If
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
                .ColumnAutoResize = False
                .ColumnAutoSizeMode = ColumnAutoSizeMode.DiaplayedCells
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

            'gridex automotically formats doubles as currency. revert. also extend dates with time
            If Not GridEX Is Nothing Then
                If Not GridEX.RootTable Is Nothing Then
                    For Each Col As GridEXColumn In GridEX.RootTable.Columns

                        If Col.FormatString = "c" Then
                            Col.FormatString = ""
                        ElseIf Col.FormatString = "d" Then
                            Col.FormatString = "yyyy-MM-dd HH:mm:ss"
                        End If
                    Next
                End If
            End If

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
        SetGridEXesVisible(True)

        'renew default values, especially to generate a new primary key value
        SetSurveyFlightsGridExDefaultValues()

        'renew the dropdowns
        SetUpSurveyFlightsGridEXDropDowns()

        'update the SurveyFlights header
        UpdateSurveyFlightsGridEXHeader()

        'renew default values, especially to generate a new primary key value
        SetSurveysGridEXDefaultValues()

        'QC the number of frequencies matches the number of animalids
        ReconcileFrequencies()

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

        'QC the number of frequencies matches the number of animalids
        ReconcileFrequencies()
    End Sub

    Private Sub CollaredAnimalsInGroupsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles CollaredAnimalsInGroupsGridEX.SelectionChanged
        'renew default values, especially to generate a new primary key value
        LockCertifiedRecords()

        'load the animalids from animal movements into the selector combo
        LoadAnimalIDSCombo()

        'load animal movement grids
        LoadAnimalMovementGrids()




        'QC the number of frequencies matches the number of animalids
        ReconcileFrequencies()
    End Sub

    Private Sub LoadAnimalMovementGrids()
        'load the animal movements grids to show info about the collared animal
        Try
            'build animal object and load its data into AnimalGridEX
            Me.AnimalGridEX.DataSource = Nothing
            Me.DeploymentsGridEX.DataSource = Nothing
            Me.CapturesGridEX.DataSource = Nothing

            'if we have a valid animalid
            If Not IsDBNull(Me.CollaredAnimalsInGroupsGridEX.CurrentRow.Cells("AnimalID").Value) Then

                'get the current animalid from the collared animals  gridex
                Dim AnimalID As String = GetCurrentGridEXCellValue(Me.CollaredAnimalsInGroupsGridEX, "AnimalID")

                'if animalid is not null
                If Not IsDBNull(AnimalID) Then

                    'create an Animal object
                    Dim CurrentAnimal As New Animal(AnimalID)

                    'details about the animal in AM database
                    With Me.AnimalGridEX
                        .DataSource = CurrentAnimal.AnimalDetails
                        .RetrieveStructure()
                        .RootTable.Caption = "Animal details (Animal Movement)"
                        .TableHeaders = InheritableBoolean.True
                        .GroupByBoxVisible = False
                        .AllowAddNew = InheritableBoolean.False
                        .AllowDelete = InheritableBoolean.False
                        .AllowEdit = InheritableBoolean.False
                    End With

                    'collar deployments history
                    With Me.DeploymentsGridEX
                        .DataSource = CurrentAnimal.Deployments
                        .RetrieveStructure()
                        .RootTable.Caption = "Collar Deployments (Animal Movement)"
                        .TableHeaders = InheritableBoolean.True
                        .GroupByBoxVisible = False
                        .AllowAddNew = InheritableBoolean.False
                        .AllowDelete = InheritableBoolean.False
                        .AllowEdit = InheritableBoolean.False
                    End With

                    'captures
                    Dim Filter As String = "AnimalID = '" & CurrentAnimal.AnimalID & "'"
                    Dim CapturesDataView As New DataView(WRST_CaribouDataSet.Tables("Captures"), Filter, "CaptureDate DESC", DataViewRowState.CurrentRows)

                    'load the captures grid header with info
                    Dim CapturesCaption As String = "No capture data is available for caribou " & AnimalID
                    If CapturesDataView.Count > 0 Then
                        CapturesCaption = CapturesDataView.Count & " capture records are available for caribou " & AnimalID
                    End If

                    'set up the captures grid
                    With Me.CapturesGridEX
                        .RootTable.Columns("AnimalID").DefaultValue = AnimalID
                        .DataSource = CapturesDataView
                        .RetrieveStructure()
                        .RootTable.Caption = CapturesCaption
                        .TableHeaders = InheritableBoolean.True
                        .GroupByBoxVisible = False
                        .AllowAddNew = InheritableBoolean.False
                        .AllowDelete = InheritableBoolean.False
                        .AllowEdit = InheritableBoolean.False
                    End With
                End If
            End If
        Catch nrefex As NullReferenceException
            'can't seem to prevent this so ignore
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
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
                    ImportSurveyDataFromFile(DestinationDataTable, CurrentHerd, CurrentFlightID)

                    'save the dataset
                    'SaveDataset()

                    'convert any animal counts of zero to null
                    'ExecuteStoredProcedure("SP_CaribouGroupsZeroesToNulls")

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
    ''' Loads a source file of waypoints and an intended destination DataTable, then opens a translator form to map the source columns into the destination datatable schema.
    ''' Finally, loads the transformed data into the DestinationDataTable.
    ''' </summary>
    ''' <param name="DestinationDataTable">DataTable. The DataTable schema into which the source DataTable's columns should be matched.</param>
    Private Sub ImportSurveyDataFromFile(DestinationDataTable As DataTable, Herd As String, FlightID As String)

        'we should have a clean dataset matching the database before we import points
        AskToSaveChanges()

        'General data types in Excel cause problems, this message will appear if user tries to import from Excel
        Dim DataLossMessage As String = "For best results when importing from Excel spreadsheets set each column's data type explicitly (Text, Date, Number, etc). 
Avoid the General data type. You may proceed but if you have problems importing data try modifying your spreadsheet and re-importing."

        Try
            'destination datatable is the structure of the table into which we'd like to import waypoints, cannot be nothing
            If Not DestinationDataTable Is Nothing Then

                'herd must be mentasta or chisana
                If Herd = "Mentasta" Or Herd = "Chisana" Then

                    'make sure we have a flightid to associate the caribou groups with
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

                                'General data types in Excel cause big problems
                                MsgBox(DataLossMessage, MsgBoxStyle.Information, "Important note on Excel spreadsheets")

                                'IMEX=1 means all data will be treated as text. we had problems with group frequencies column being treated as numeric so it omitted any 
                                'cells with commas separating frequencies
                                'the Excel General data type confused .NET as to what kind of data to expect.
                                'see https://www.connectionstrings.com/excel/
                                Dim ExcelConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & SourceFileInfo.FullName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"
                                Dim ExcelDataset As DataSet = GetDatasetFromExcelWorkbook(ExcelConnectionString)
                                InputDataTable = ExcelDataset.Tables(0) 'can only grab the first worksheet (tab)

                            ElseIf SourceFileInfo.Extension = ".xls" Then

                                'General data types in Excel cause big problems
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
                                .Add("Raw")

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
                            'loop through the imported data datatable and try to insert them into the datatable
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
                                NewRow.Item("CertificationLevel") = "Raw"

                                'add the row
                                Me.WRST_CaribouDataSet.Tables("Surveys").Rows.Add(NewRow)

                                'end the edit
                                Me.SurveysBindingSource.EndEdit()
                            Next

                            'end any remaining edits
                            Me.SurveysBindingSource.EndEdit()

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
        'the gridexes don't make it easy to see which parent record is selected when on the child gridex
        'Update the collared animals gridex header with the Surveys group number at least, and also frequencies if they exist
        'this makes matching frequencies to animals easier

        'generic starting caption
        Me.CollaredAnimalsInGroupsGridEX.RootTable.Caption = "Collared caribou in group"

        'start by getting the groupnumber and frequencies data
        If Not GetCurrentGridEXCellValue(Me.SurveysGridEX, "FrequenciesInGroup") Is Nothing Then
            If Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveysGridEX, "GroupNumber")) Then
                Dim GroupNumber As String = GetCurrentGridEXCellValue(Me.SurveysGridEX, "GroupNumber")

                'make the gridex caption more specific
                Me.CollaredAnimalsInGroupsGridEX.RootTable.Caption = "No collared caribou detected in group " & GroupNumber

                'next determine if the frequencies in group column has data
                If Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveysGridEX, "FrequenciesInGroup")) Then
                    If Not GetCurrentGridEXCellValue(Me.SurveysGridEX, "FrequenciesInGroup") Is Nothing Then
                        Dim FrequenciesInGroup As String = GetCurrentGridEXCellValue(Me.SurveysGridEX, "FrequenciesInGroup")
                        If FrequenciesInGroup.Trim.Length > 0 Then
                            'frequencies exist, update the gridex caption
                            Me.CollaredAnimalsInGroupsGridEX.RootTable.Caption = "Collared caribou in group " & GroupNumber & " by frequency: " & FrequenciesInGroup
                        End If
                    End If
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


    ''' <summary>
    ''' Counts the number of FrequenciesInGroup and AnimalIDs in the CollaredAnimalsInGroups table. Loads the data into the SurveysGridEX.
    ''' </summary>
    Private Sub ReconcileFrequencies()
        'check that the number of frequencies in Surveys.FrequenciesInGroup column match the number of items in the CollaredAnimalsInGroups table for the record
        Try
            If SurveysGridEX.GetRows.Count > 0 Then
                For Each Row As GridEXRow In SurveysGridEX.GetRows
                    If Not Row.Cells("EID") Is Nothing Then
                        If Not IsDBNull(Not IsDBNull(Row.Cells("EID").Value)) Then
                            Dim EID As String = Row.Cells("EID").Value
                            Dim NumberOfFrequencies As Integer = 0
                            If Not IsDBNull(Row.Cells("FrequenciesInGroup").Value) Then

                                'get a count of the number of frequencies in the group
                                Dim FrequenciesInGroup As String = Row.Cells("FrequenciesInGroup").Value

                                'count the frequencies
                                Dim FrequenciesList As List(Of Double) = GetListOfCSVFrequencies(FrequenciesInGroup)
                                NumberOfFrequencies = FrequenciesList.Count
                            End If

                            'now query the number of AnimalIDs in the CollaredAnimalsInGroups table
                            Dim NumberOfAnimalIDs As Integer = 0
                            Dim Filter As String = "EID = '" & EID & "'"
                            Dim AnimalIDsDataView As New DataView(WRST_CaribouDataSet.Tables("CollaredAnimalsInGroups"), Filter, "", DataViewRowState.CurrentRows)
                            NumberOfAnimalIDs = AnimalIDsDataView.Count

                            'update the number of frequencies and number of animalids columns
                            Row.BeginEdit()
                            If NumberOfAnimalIDs > 0 Or NumberOfFrequencies > 0 Then
                                Row.Cells("FrequenciesCount").Value = NumberOfFrequencies
                                Row.Cells("NumAnimalIDs").Value = NumberOfAnimalIDs
                            End If
                            Row.EndEdit()
                        End If
                    End If
                Next
                Me.SurveysBindingSource.EndEdit()
            End If
        Catch nrefex As NullReferenceException
            'ignore
            Debug.Print(nrefex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Converts a comma separated list of frequencies (typically FrequenciesInGroup from the Surveys table) to a List of numeric frequencies
    ''' </summary>
    ''' <param name="FrequenciesCSV"></param>
    ''' <returns>List(Of Double)</returns>
    Private Function GetListOfCSVFrequencies(FrequenciesCSV As String) As List(Of Double)
        Dim FrequenciesList As New List(Of Double)
        If Not FrequenciesCSV Is Nothing Then
            If Not IsDBNull(FrequenciesCSV) Then
                For Each Frequency In FrequenciesCSV.Split(",")
                    Frequency = Frequency.Trim
                    If IsNumeric(Frequency.Trim) = True Then
                        FrequenciesList.Add(Frequency)
                    End If
                Next
            End If
        End If
            Return FrequenciesList
    End Function

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
                        Dim FrequenciesList As List(Of Double) = GetListOfCSVFrequencies(FrequenciesInGroup)
                        For Each Frequency In FrequenciesList ' FrequenciesInGroup.Split(",")
                            Dim AnimalID As String = GetAnimalIDFromFrequencyAndObservationDate(Frequency, SightingDate)
                            Dim Comment As String = ""
                            If AnimalID.Length = 0 Then
                                'the collar was not found in the AM database, add to the list so we can inform the user of data quality issues.
                                MissingFrequenciesArrayList.Add(Frequency & "," & SightingDate)
                                AnimalID = Frequency
                                Comment = "Frequency Not found In AM at time Of insertion (" & My.User.Name & " " & Now & ")"
                            End If

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
                        Next
                        CollaredAnimalsInGroupsBindingSource.EndEdit()
                        ReconcileFrequencies()
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

    Private Sub ResultsViewerToolStripButton_Click(sender As Object, e As EventArgs) Handles ResultsViewerToolStripButton.Click
        Dim ResultsForm As New ResultsForm
        ResultsForm.ShowDialog()
    End Sub

    'Private Sub AutoLoadSurveyFlightCells()
    'THIS JUST DIDN'T WORK WELL, HARD TO TELL IF YOU ARE ON A NEW RECORD OR NOT TO AVOID OVERWRITING EXISTING DATA
    '    'CrewNumber default value. figure out the maximum crewnumber for a given year/herd/surveytype and increment by one
    '    Dim Grid As GridEX = Me.SurveyFlightsGridEX
    '    Dim MaxCrewNumber As Integer = 0
    '    Dim Year As String = GetCurrentGridEXCellValue(Grid, "Year")
    '    Dim Herd As String = GetCurrentGridEXCellValue(Grid, "Herd")
    '    Dim SurveyType As String = GetCurrentGridEXCellValue(Grid, "SurveyType")
    '    Dim TimeDepart As String = GetCurrentGridEXCellValue(Grid, "TimeDepart")
    '    Dim TimeReturn As String = GetCurrentGridEXCellValue(Grid, "TimeReturn")

    '    'if crew number is null or blank (we don't want to overwrite existing values)
    '    If Grid.CurrentRow.Cells("CrewNumber").Value Is Nothing Then
    '        If Not Year Is Nothing And Not Herd Is Nothing And Not SurveyType Is Nothing Then
    '            ' if the other parts are available then auto fill crewnumber with the highest value plus one
    '            If Not Year.Trim = "" And IsNumeric(Year) And Not Herd.Trim = "" And Not SurveyType = "" Then
    '                Dim CrewNumberDataView As New DataView(WRST_CaribouDataSet.Tables("SurveyFlights"), "Year=" & CInt(Year) & " And Herd='" & Herd & "' and SurveyType='" & SurveyType & "'", "CrewNumber", DataViewRowState.CurrentRows)
    '                For Each Row As DataRowView In CrewNumberDataView
    '                    If Row.Item("CrewNumber") > MaxCrewNumber Then
    '                        MaxCrewNumber = Row.Item("CrewNumber")
    '                    End If
    '                Next
    '                Grid.CurrentRow.EndEdit()
    '                Grid.CurrentRow.Cells("CrewNumber").Value = MaxCrewNumber + 1
    '            End If
    '        End If
    '    End If

    '    ''set TimeReturn to be the same day as timedepart
    '    'If Not TimeDepart Is Nothing Then
    '    '    'if we have a valid timedepart
    '    '    If (Not IsDBNull(TimeDepart) And IsDate(TimeDepart)) And TimeReturn.Trim = "" Then
    '    '        Grid.CurrentRow.Cells("TimeReturn").Value = TimeDepart
    '    '    End If
    '    'End If
    'End Sub

    'Private Sub SurveyFlightsGridEX_CellUpdated(sender As Object, e As ColumnActionEventArgs) Handles SurveyFlightsGridEX.CellUpdated
    '    'pre-load cells on data entry
    '    AutoLoadSurveyFlightCells()
    'End Sub
End Class
