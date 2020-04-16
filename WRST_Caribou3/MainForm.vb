Imports System.Data.SqlClient
Imports System.IO
Imports Janus.Windows.GridEX
Imports SkeeterDataTablesTranslator

Public Class MainForm

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'My.Settings.Item("WRST_CaribouConnectionString") = "Data Source=inpyugamsvm01\nuna_dev;Initial Catalog=WRST_Caribou;Integrated Security=True"
        'My.Settings.Item("Animal_MovementConnectionString") = "Data Source=INPAKROVMAIS;Initial Catalog=Animal_Movement;Integrated Security=True"

        'make the form a reasonable size if not maximized
        Me.Width = 1200
        Me.Height = 800

        Try
            'maximize
            Me.WindowState = FormWindowState.Maximized

            'load in the data from the WRST_Caribou SQL Server database
            LoadDataset()

            'format all the data grids more or less the same
            FormatGridEX(Me.SurveyFlightsGridEX)
            FormatGridEX(Me.SurveysGridEX)
            FormatGridEX(Me.CollaredAnimalsInGroupsGridEX)
            FormatGridEX(Me.AnimalGridEX)

            'set up default values for the grids
            SetSurveyFlightsGridExDefaultValues()
            SetSurveysGridEXDefaultValues()



            'for some reason the surveys grid loads data when the form first loads despite no parent record being selected.
            'visibility is reversed on the flight grid's SelectionChanged event.
            SetGridEXesVisible(True)

            'set the flights gridex caption to something generic
            Me.SurveyFlightsGridEX.RootTable.Caption = "Caribou survey flights inventory"

            'load the collared animal deployments from Animal Movement into the CollaredAnimalsGridEX
            'LoadAnimalIDSCombo()

            'load the default values for the grid columns
            SetUpSurveyFlightsGridEXDropDowns()
            SetUpSurveysGridEXDropDowns()

            'make grids readonly to start
            With Me.SurveyFlightsGridEX
                .AllowAddNew = InheritableBoolean.False
                .AllowEdit = InheritableBoolean.False
                .AllowDelete = InheritableBoolean.False
            End With
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
        'Me.DeploymentsGridEX.Visible = Visible
        'Me.CapturesGridEX.Visible = Visible
        Me.SurveysToolStrip.Visible = Visible
    End Sub



    Private Sub LoadDataset()
        Try
            'fill all the datatable adapters
            Me.SurveyFlightsTableAdapter.Fill(Me.WRST_CaribouDataSet.SurveyFlights)
            Me.SurveysTableAdapter.Fill(Me.WRST_CaribouDataSet.Surveys)
            Me.CollaredAnimalsInGroupsTableAdapter.Fill(Me.WRST_CaribouDataSet.CollaredAnimalsInGroups)
            Me.CapturesTableAdapter.Fill(Me.WRST_CaribouDataSet.Captures)

            'update the database connection label
            Me.CurrentDatabaseToolStripLabel.Text = GetDatabaseConnectionText()
        Catch ex As Exception
            Me.CurrentDatabaseToolStripLabel.Text = ex.Message
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Saves the local Dataset to the WRST_Caribou Sql Server database
    ''' </summary>
    Private Sub SaveDataset()
        Try
            Me.Validate()
        Catch ex As Exception
            MsgBox(ex.Message & "Validation (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

        Try
            Me.CollaredAnimalsInGroupsBindingSource.EndEdit()
            Me.SurveysBindingSource.EndEdit()
            Me.SurveyFlightsBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)
        Catch DBCEx As DBConcurrencyException
            If MsgBox("Concurrency violation. " & DBCEx.Message & " Merge your edits into the database?", MsgBoxStyle.YesNo, "Concurrency violation.") = MsgBoxResult.Yes Then
                Me.WRST_CaribouDataSet.Merge(WRST_CaribouDataSet.Tables("Surveys"))
                SaveDataset()
            Else
                MsgBox("Save canceled.")
                Exit Sub
            End If
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message & "Database update (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
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
            'Dim MaxSOPVersion As Integer = 0
            ''If Grid.GetRows.Count > 0 Then
            'For Each row As GridEXRow In Grid.GetRows()
            '    If Not row Is Nothing Then
            '        If Not row.Cells("SOPVersion") Is Nothing Then
            '            If Not row.Cells("SOPVersion").Value Is Nothing Then
            '                If Not IsDBNull(row.Cells("SOPVersion").Value) Then
            '                    If row.Cells("SOPVersion").Value > MaxSOPVersion Then
            '                        MaxSOPVersion = row.Cells("SOPVersion").Value
            '                    End If
            '                End If
            '            End If
            '        End If
            '    End If
            'Next
            ''End If
            'Grid.RootTable.Columns("SOPVersion").DefaultValue = MaxSOPVersion


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
                .LimitToList = False
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
                .ValueList.Add("Chisana", "Chisana")
                .ValueList.Add("Mentasta", "Mentasta")
            End With

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Sets up the SurveysGridEX default values and DropDowns/Combos
    ''' </summary>
    Private Sub SetUpSurveysGridEXDropDowns()
        Try
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
                .LimitToList = False
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
                .ValueList.Add("Raw", "Raw")
                .ValueList.Add("Provisional", "Provisional")
                .ValueList.Add("Accepted", "Accepted")
                .ValueList.Add("Certified", "Certified")
            End With

            'Mode dropdown
            With Grid.RootTable.Columns("Mode")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = True
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
                .ValueList.Add("A", "Active")
                .ValueList.Add("M", "Mortality")
            End With


            'Accuracy is recorded as a 1 (low latitude, can see caribou and collar), 2(low altitude without visual confirmation), And 3 (high altitude without visual confirmation)
            With Grid.RootTable.Columns("Accuracy")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = True
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
                .ValueList.Add("1", "1-Low altitude, can see caribou and collar")
                .ValueList.Add("2", "2-Low altitude without visual confirmation")
                .ValueList.Add("3", "3-high altitude without visual confirmation")
            End With

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Sets up the SurveysGridEX default values and DropDowns/Combos
    ''' </summary>
    Private Sub SetUpCollaredAnimalsInGroupsGridEXDropDowns(SightingDate As Date)
        Try
            'Set up default values
            Dim Grid As GridEX = Me.CollaredAnimalsInGroupsGridEX

            'set up the animalid column to accept a dropdown
            'With Grid.RootTable.Columns("AnimalID")
            '    .EditType = EditType.Combo
            '    .HasValueList = True
            '    .LimitToList = True
            '    .AllowSort = True
            '    .AutoComplete = True
            '    .ValueList.Clear()
            'End With

            'set up the deploymentid column to accept a dropdown
            With Grid.RootTable.Columns("DeploymentID")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = True
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
            End With

            'get a DataTable inventory of collars that were available on SightingDate
            Dim CollaredAnimalsDataTable As DataTable = GetAvailableCollarsInventoryForADate(SightingDate)

            'get a reference to the dropdown's value list
            'Dim AnimalsList As GridEXValueListItemCollection = Grid.RootTable.Columns("AnimalID").ValueList
            Dim DeploymentsList As GridEXValueListItemCollection = Grid.RootTable.Columns("DeploymentID").ValueList

            'load in the items into the combobox
            If CollaredAnimalsDataTable.Rows.Count > 0 Then
                For Each Row As DataRow In CollaredAnimalsDataTable.Rows
                    Dim AnimalID As String = Row.Item("AnimalID")
                    Dim DeploymentID As String = Row.Item("DeploymentID")
                    Dim CollaredCaribou As String = Row.Item("CollaredCaribou")
                    'AnimalsList.Add(AnimalID, AnimalID & " (" & CollaredCaribou & ")")
                    DeploymentsList.Add(DeploymentID, AnimalID & " " & DeploymentID & " (" & CollaredCaribou & ")")
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub CollaredAnimalsInGroupsGridEX_CellUpdated(sender As Object, e As ColumnActionEventArgs) Handles CollaredAnimalsInGroupsGridEX.CellUpdated
        Dim Grid As GridEX = sender
        If Not Grid.CurrentRow Is Nothing Then
            Dim DeploymentID As Integer = GetCurrentGridEXCellValue(Grid, "DeploymentID")
            Dim Sql As String = "Select  Collars.Frequency, CollarDeployments.DeploymentDate, CollarDeployments.AnimalId, CollarDeployments.RetrievalDate, Animals.MortalityDate, CollarDeployments.DeploymentId
From Animals INNER Join
              CollarDeployments On Animals.ProjectId = CollarDeployments.ProjectId And Animals.AnimalId = CollarDeployments.AnimalId INNER Join
              Collars On CollarDeployments.CollarManufacturer = Collars.CollarManufacturer And CollarDeployments.CollarId = Collars.CollarId
Where (CollarDeployments.DeploymentId = " & DeploymentID & ")"
            Debug.Print(Sql)
            Dim DeploymentDataTable As DataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
            If DeploymentDataTable.Rows.Count = 1 Then

                With Grid.CurrentRow
                    .Cells("AnimalID").Value = DeploymentDataTable.Rows(0).Item("AnimalID")
                    .Cells("RecordedFrequency").Value = DeploymentDataTable.Rows(0).Item("Frequency")
                    .Cells("ActualFrequency").Value = DeploymentDataTable.Rows(0).Item("Frequency")
                    .Cells("RecordInsertedDate").Value = Now
                    .Cells("RecordInsertedBy").Value = My.User.Name
                    '.Cells("EID").Value = DeploymentDataTable.Rows(0).Item("Frequency")
                    '.Cells("ActualFrequency").Value = DeploymentDataTable.Rows(0).Item("Frequency")
                End With
            End If
        End If

    End Sub

    ''' <summary>
    ''' Returns the maximum value of GridEX's column named GroupNumber. Used to increment GroupNumber as a default value for new records by adding 1.
    ''' </summary>
    ''' <returns></returns>
    Private Function GetMaximumGroupNumber(GridEX As GridEX) As Integer
        Dim MaxGroupNumber As Integer = 0
        Try
            If Not GridEX Is Nothing Then
                'determine the maximum group number
                For Each Row As GridEXRow In GridEX.GetRows()
                    If Row.Cells("GroupNumber").Value > MaxGroupNumber Then
                        MaxGroupNumber = Row.Cells("GroupNumber").Value
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return MaxGroupNumber
    End Function

    ''' <summary>
    ''' Returns the collar frequency of animal designated AnimalID on a particular sample date
    ''' </summary>
    ''' <param name="AnimalID"></param>
    ''' <param name="SampleDate"></param>
    ''' <returns>Double</returns>
    Private Function GetFrequencyFromAnimalIDAndDate(AnimalID As String, SampleDate As Date) As Double
        MsgBox("Function GetFrequencyFromAnimalIDAndDate() needs repair")
        Dim Frequency As Double = 0
        Try
            Dim AnimalsDataTable As DataTable = GetAnimalsDataTable()
            Dim Filter As String = "(AnimalID = '" & AnimalID & "') And (DeploypmentDate < '" & SampleDate & "' And RetrievalDate < '" & SampleDate & "')"
            Dim DV As New DataView(AnimalsDataTable, Filter, "", DataViewRowState.CurrentRows)
            If DV.Count = 1 Then
                Frequency = DV(0).Item("Frequency")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return Frequency
    End Function

    ''' <summary>
    ''' Untested 2019-11-06. Returns the AnimalID for a Frequency detected at a certain SampleDate
    ''' </summary>
    ''' <param name="Frequency">Frequency. Double.</param>
    ''' <param name="SampleDate">SampleDate. Date.</param>
    ''' <returns></returns>
    Private Function GetAnimalIDFromFrequencyAndDate(Frequency As Double, SampleDate As Date) As Double
        MsgBox("GetAnimalIDFromFrequencyAndDate needs repair")
        Dim AnimalID As Double = 0
        Try
            Dim AnimalsDataTable As DataTable = GetAnimalsDataTable()
            Dim Filter As String = "(Frequency = " & Frequency & ") And (DeploypmentDate < '" & SampleDate & "' And RetrievalDate < '" & SampleDate & "')"
            Dim DV As New DataView(AnimalsDataTable, Filter, "", DataViewRowState.CurrentRows)
            If DV.Count = 1 Then
                AnimalID = DV(0).Item("AnimalID")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return AnimalID
    End Function




    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        SaveDataset()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AskToSaveChanges()
    End Sub


    ''' <summary>
    ''' If the Dataset has changes ask the user for permission to save edits.
    ''' </summary>
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

            ' find out if any survey records are certified, if so then lock the parent flight GridEX so the flight record is unchanged
            'If FlightContainsCertifiedRecords(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")) = True Then

            '    'disallow survey edits
            '    With Me.SurveyFlightsGridEX
            '        .AllowAddNew = InheritableBoolean.True
            '        .AllowDelete = InheritableBoolean.False
            '        .AllowEdit = InheritableBoolean.False
            '    End With

            'Else

            '    'allow survey edits
            '    With Me.SurveyFlightsGridEX
            '        .AllowAddNew = InheritableBoolean.True
            '        .AllowDelete = InheritableBoolean.True
            '        .AllowEdit = InheritableBoolean.True
            '    End With
            'End If


            ''next, if the current Survey record is Certified then lock the GridEX
            'Dim RecordIsCertified As Boolean = GetCurrentGridEXCellValue(Me.SurveysGridEX, "CertificationLevel") = "Certified"

            ''if the record is certified
            'If RecordIsCertified = True Then

            '    'disallow survey edits
            '    With Me.SurveysGridEX
            '        .AllowAddNew = InheritableBoolean.False
            '        .AllowDelete = InheritableBoolean.False
            '        .AllowEdit = InheritableBoolean.False
            '    End With

            '    'disable the collared animals grid also
            '    With Me.CollaredAnimalsInGroupsGridEX
            '        .AllowAddNew = InheritableBoolean.False
            '        .AllowDelete = InheritableBoolean.False
            '        .AllowEdit = InheritableBoolean.False
            '    End With

            'Else

            '    'allow survey edits
            '    With Me.SurveysGridEX
            '        .AllowAddNew = InheritableBoolean.True
            '        .AllowDelete = InheritableBoolean.True
            '        .AllowEdit = InheritableBoolean.True
            '    End With

            '    'allow edits to collared animals grid also
            '    With Me.CollaredAnimalsInGroupsGridEX
            '        .AllowAddNew = InheritableBoolean.True
            '        .AllowDelete = InheritableBoolean.True
            '        .AllowEdit = InheritableBoolean.True
            '    End With
            'End If
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



        'make the grids readonly or editable according to the tool on the main form
        ReadOnlyCheck()

        'lock editing on flight records if certified survey records exist
        LockCertifiedRecords()

        'if we are on a blank survey then blank out the other grids
        'sometimes data lingers when user clicks on the new record row
        Dim Year As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Year")
        Dim Herd As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd")
        Dim SurveyType As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "SurveyType")
        If Year Is Nothing Or Herd Is Nothing Or SurveyType Is Nothing Then
            SetGridEXesVisible(False)
        Else
            SetGridEXesVisible(True)
        End If

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

        'clear the animal grid
        LoadAnimalMovementGrids()
    End Sub

    Private Sub CollaredAnimalsInGroupsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles CollaredAnimalsInGroupsGridEX.SelectionChanged
        'renew default values, especially to generate a new primary key value
        LockCertifiedRecords()

        'load animal movement grids
        LoadAnimalMovementGrids()

        'QC the number of frequencies matches the number of animalids
        ReconcileFrequencies()
    End Sub

    ''' <summary>
    ''' LoadAnimalMovementGrids builds an Animal Object by querying the Animal Movement and WRST_Caribou databases for information about the currently selected caribou
    ''' in the Surveys grid. AnimalGridEX tree grid is loaded with the data from the Animal Object. See Animal.vb.
    ''' </summary>
    Private Sub LoadAnimalMovementGrids()
        'clear any residual data out of the animal grid
        Me.AnimalGridEX.DataSource = Nothing

        'load the animal movements grids to show info about the collared animal
        Try
            'build animal object and load its data into AnimalGridEX
            'lots of ifs below to be sure we have a valid current AnimalID and current Surveys row
            If Not Me.CollaredAnimalsInGroupsGridEX.CurrentRow Is Nothing Then
                'if we have a current row with the cell AnimalID
                If Not Me.CollaredAnimalsInGroupsGridEX.CurrentRow.Cells("AnimalID") Is Nothing Then
                    'if we have a current row with a cell AnimalID with a value
                    If Not Me.CollaredAnimalsInGroupsGridEX.CurrentRow.Cells("AnimalID").Value Is Nothing Then
                        'if the current row's value is not null
                        If Not IsDBNull(Me.CollaredAnimalsInGroupsGridEX.CurrentRow.Cells("AnimalID").Value) Then
                            'if current row's value is not blank
                            If Me.CollaredAnimalsInGroupsGridEX.CurrentRow.Cells("AnimalID").Value.ToString.Trim.Length > 0 Then

                                'get the current animalid from the collared animals  gridex
                                Dim AnimalID As String = Me.CollaredAnimalsInGroupsGridEX.CurrentRow.Cells("AnimalID").Value.ToString.Trim

                                'if animalid is not null
                                If Not IsDBNull(AnimalID) Then

                                    'create an Animal object
                                    Dim CurrentAnimal As New Animal(AnimalID)

                                    'details about the animal in AM database
                                    With Me.AnimalGridEX
                                        .DataSource = CurrentAnimal.AnimalDataset.Tables("Animal")
                                        .Hierarchical = True 'this will load all the AnimalDataset's tables into a tree grid format
                                        .RetrieveStructure(True) 'true for hierarchical
                                        .RootTable.Caption = "Animal details (Animal_Movement) for " & AnimalID
                                        .TableHeaders = InheritableBoolean.True
                                        .GroupByBoxVisible = False
                                        '.AllowAddNew = InheritableBoolean.False
                                        '.AllowDelete = InheritableBoolean.False
                                        '.AllowEdit = InheritableBoolean.False
                                        .ExpandRecords()
                                        .ColumnAutoResize = False
                                        .ColumnAutoSizeMode = ColumnAutoSizeMode.ColumnHeader
                                    End With

                                    'set deployments table header (note, had to reference the table using the datarelation name, not table name)
                                    Dim TableKey As String = "AnimalToCollarDeploymentsDataRelation"
                                    If Not AnimalGridEX.Tables(TableKey) Is Nothing Then
                                        AnimalGridEX.Tables(TableKey).Caption = "Collar Deployments (Animal_Movement)"
                                    End If

                                    'Set captures table header (note, had to reference the table using the datarelation name, not table name)
                                    TableKey = "AnimalToCapturesDataRelation"
                                    If Not AnimalGridEX.Tables(TableKey) Is Nothing Then
                                        AnimalGridEX.Tables(TableKey).Caption = "Captures (WRST_Caribou)"
                                    End If

                                    'fix gridex automatic formatting problems
                                    'loop through the tables
                                    For Each GridEXTable As GridEXTable In AnimalGridEX.RootTable.ChildTables
                                        'if a table exists                                    
                                        If Not GridEXTable Is Nothing Then

                                            'loop through each of the table's columns
                                            For Each Col As GridEXColumn In GridEXTable.Columns
                                                If Not Col Is Nothing Then
                                                    'gridex is abysmal at automatically calculating column widths so do it manually so that 
                                                    'it is likely the column header is fully visible
                                                    Col.Width = Col.Key.ToString.Length * 20

                                                    'gridex likes to format all numbers as currency, fix
                                                    If Col.FormatString = "c" Then
                                                        Col.FormatString = ""
                                                        '    'and fix dates while we are in here
                                                    ElseIf Col.FormatString = "d" Then
                                                        Col.FormatString = "yyyy-MM-dd HH:mm:ss"
                                                    End If
                                                End If
                                            Next
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub




    Private Sub ImportSurveyDataFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportSurveyDataFromFileToolStripButton.Click
        Try
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
,[In]
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
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
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
                                'MsgBox(DataLossMessage, MsgBoxStyle.Information, "Important note on Excel spreadsheets")

                                'IMEX=1 means all data will be treated as text. we had problems with group frequencies column being treated as numeric so it omitted any 
                                'cells with commas separating frequencies
                                'the Excel General data type confused .NET as to what kind of data to expect.
                                'see https://www.connectionstrings.com/excel/
                                Dim ExcelConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & SourceFileInfo.FullName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"
                                Dim ExcelDataset As DataSet = GetDatasetFromExcelWorkbook(ExcelConnectionString)
                                InputDataTable = ExcelDataset.Tables(0) 'can only grab the first worksheet (tab)

                            ElseIf SourceFileInfo.Extension = ".xls" Then

                                'General data types in Excel cause big problems
                                'MsgBox(DataLossMessage, MsgBoxStyle.Information, "Important note on Excel spreadsheets")

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
        ConfirmDelete(e)
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
        Try
            'load the collared animal deployments from Animal Movement into the CollaredAnimalsGridEX
            Dim CurrentSightingDate As String = GetCurrentGridEXCellValue(Me.SurveysGridEX, "SightingDate")
            If IsDate(CurrentSightingDate) Then
                SetUpCollaredAnimalsInGroupsGridEXDropDowns(CDate(CurrentSightingDate))
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Update the CollaredAnimalsInGroupsGridEX's caption
    ''' </summary>
    Private Sub UpdateCollaredAnimalsInGroupsGridEXHeader()
        'the gridexes don't make it easy to see which parent record is selected when on the child gridex
        'Update the collared animals gridex header with the Surveys group number at least, and also frequencies if they exist
        'this makes matching frequencies to animals easier

        Try
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
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Update the SurveyFlightsGridEX's caption
    ''' </summary>
    Private Sub UpdateSurveyFlightsGridEXHeader()
        'update the collared animals gridex with any frequencies found in this caribou group. this makes matching frequencies to animals easier
        Me.SurveyFlightsGridEX.RootTable.Caption = "Flights"
        Try
            'update the caption with the info
            If Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "TimeDepart")) And Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd")) And Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "SurveyType")) And Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Observer1")) And Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "TailNo")) Then
                Dim TimeDepart As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "TimeDepart")
                Dim Herd As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd")
                Dim SurveyType As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "SurveyType")
                Dim TailNo As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "TailNo")
                Dim Observer1 As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Observer1")
                Select Case SurveyType
                    Case "CC"
                        SurveyType = "Composition Count"
                    Case "PE"
                        SurveyType = "Population Estimate"
                    Case "RT"
                        SurveyType = "Radiotracking"
                End Select


                Me.SurveyFlightsGridEX.RootTable.Caption = "Flight: " & TimeDepart & " " & Herd & " " & SurveyType & " " & TailNo '& " " & Observer1
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub


    ''' <summary>
    ''' Quality control check. Counts the number of FrequenciesInGroup and AnimalIDs in the CollaredAnimalsInGroups table. Loads the data into the SurveysGridEX.
    ''' </summary>
    Private Sub ReconcileFrequencies()
        'check that the number of frequencies in Surveys.FrequenciesInGroup column match the number of items in the CollaredAnimalsInGroups table for the record
        Try
            If SurveysGridEX.GetRows.Count > 0 Then
                For Each Row As GridEXRow In SurveysGridEX.GetRows

                    If Not Row Is Nothing Then
                        Row.BeginEdit()
                        If Not Row.Cells("EID") Is Nothing Then
                            If Not Row.Cells("EID").Value Is Nothing Then
                                'If Not Row.Cells("EID").Value.ToString.Trim <> "" Then 'nothing got past here when it was enabled, i don't know why
                                If Not IsDBNull(Row.Cells("EID").Value) Then
                                    Dim EID As String = Row.Cells("EID").Value

                                    'reset the FrequenciesCount and NumAnimalIDs columns
                                    Row.Cells("FrequenciesCount").Value = DBNull.Value
                                    Row.Cells("NumAnimalIDs").Value = DBNull.Value

                                    'count the number of comma separated frequencies in the FrequenciesInGroup column of the row.
                                    Dim NumberOfFrequencies As Integer = 0 'this will hold the number of frequencies in the group
                                    If Not IsDBNull(Row.Cells("FrequenciesInGroup").Value) Then

                                        'there were frequencies in the group, get a count of the number of frequencies in the group
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
                                    If NumberOfFrequencies > 0 Or NumberOfAnimalIDs > 0 Then
                                        Row.Cells("FrequenciesCount").Value = NumberOfFrequencies
                                        Row.Cells("NumAnimalIDs").Value = NumberOfAnimalIDs
                                    End If
                                End If
                            End If
                        End If
                        Row.EndEdit()
                    End If

                Next
                Me.SurveysBindingSource.EndEdit()
            End If
        Catch nrefex As NullReferenceException
            'ignore
            'MsgBox(nrefex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub



    '''' <summary>
    '''' Executes the spCollaredAnimalInGroups_Insert_Frequency_Date stored procedure on the WRST_Caribou database
    '''' to insert a new record from a frequency, sighting date and the EID of the animal group to which it belongs
    '''' </summary>
    '''' <param name="RecordedFrequency"></param>
    '''' <param name="SightingDate"></param>
    '''' <param name="EID"></param>
    'Private Sub InsertCollaredAnimal(RecordedFrequency As Double, SightingDate As Date, EID As String)
    '    'Dim SqlConnection As New SqlConnection(My.Settings.WRST_CaribouConnectionString)
    '    'Using (SqlConnection)
    '    '    Dim SqlCommand As New SqlCommand()
    '    '    With SqlCommand
    '    '        .Connection = SqlConnection
    '    '        .CommandText = "spCollaredAnimalInGroups_Insert_Frequency_Date"
    '    '        .CommandType = CommandType.StoredProcedure
    '    '        .Parameters.AddWithValue("RecordedFrequency", RecordedFrequency)
    '    '        .Parameters.AddWithValue("SightingDate", SightingDate)
    '    '        .Parameters.AddWithValue("EID", EID)
    '    '        SqlConnection.Open()
    '    '        .ExecuteNonQuery()
    '    '    End With
    '    'End Using
    '    'spCollaredAnimalInGroups_Insert_Frequency_Date 164.694, '2010-08-30 07:58:00.000', '00215AEC-528B-4017-93D7-EE2E68C81221'
    'End Sub







    ''' <summary>
    ''' Auto-matches a GPS collar Frequency to a collard deployment (and animal) in Animal Movement. Helper sub to process GridEX rows from AutomatchFrequenciesToAnimals()
    ''' </summary>
    ''' <param name="SurveyRow">DataRow from the Surveys DataTable containing EID, GroupNumber, FrequenciesInGroup and SightingDate columns.</param>
    Private Sub MatchFrequencyToAnimal(SurveyRow As DataRow)

        Try
            'extract the frequencies from the row's FrequenciesInGroup column and try to parse it, search for the collar deployment in Animal Movement and insert the DeploymentID into the cross reference table
            If Not SurveyRow Is Nothing Then
                If Not SurveyRow.Item("GroupNumber") Is Nothing And Not SurveyRow.Item("FrequenciesInGroup") Is Nothing And Not SurveyRow.Item("SightingDate") Is Nothing And Not SurveyRow.Item("EID") Is Nothing Then
                    If Not IsDBNull(SurveyRow.Item("FrequenciesInGroup")) And Not IsDBNull(SurveyRow.Item("SightingDate")) And Not IsDBNull(SurveyRow.Item("EID")) Then

                        'get a reference to the CollaredAnimalsInGroupsDataTable
                        Dim CollaredAnimalsInGroupsDataTable As DataTable = Me.WRST_CaribouDataSet.Tables("CollaredAnimalsInGroups")

                        'get caribou group row values into variables
                        Dim FrequenciesInGroup As String = SurveyRow.Item("FrequenciesInGroup")
                        Dim SightingDate As String = SurveyRow.Item("SightingDate")
                        Dim EID As String = SurveyRow.Item("EID")
                        Dim GroupNumber As String = SurveyRow.Item("GroupNumber")
                        Dim Frequency As Double

                        'parse the comma separated frequencies so we can deal with them individually
                        Dim FrequenciesList As List(Of Double) = GetListOfCSVFrequencies(FrequenciesInGroup)

                        'loop through each Frequency in FrequenciesInGroup
                        For Each Frequency In FrequenciesList ' FrequenciesInGroup.Split(",")

                            'get the deployment data in a table
                            Dim DeploymentDataTable As DataTable = GetDeploymentDataTableFromFrequencyAndDate(Frequency, SightingDate, 0.001)

                            'put deployment data into variables
                            Dim DeploymentID As Integer = 0
                            Dim AnimalID As String = "UNK"
                            Dim ActualFrequency As String = -999

                            'if there is a deployment for the date and frequency
                            If DeploymentDataTable.Rows.Count = 1 Then
                                'we retreived a deployment
                                ' put the deployment data into variables
                                DeploymentID = DeploymentDataTable.Rows(0).Item("DeploymentID")
                                AnimalID = DeploymentDataTable.Rows(0).Item("AnimalID")
                                ActualFrequency = DeploymentDataTable.Rows(0).Item("Frequency")
                            ElseIf DeploymentDataTable.Rows.Count = 0 Then
                                'no deployments retrieved. the app should stick the default deployment values above in the new row
                            Else
                                'one reason we may not have gotten a deployment row above is because the frequency needs to be truncated
                                'sometimes it's recorded in the field or in Animal Movement to too many decimal places
                                'three decimal places is the usual so truncate it to 3 here.
                                Dim TruncatedFrequency As Double = Math.Round(Frequency, 3)
                                DeploymentDataTable = GetDeploymentDataTableFromFrequencyAndDate(TruncatedFrequency, SightingDate, 0.001)

                                'if there is a deployment for the date and frequency
                                If DeploymentDataTable.Rows.Count = 1 Then
                                    'we retreived a deployment. put the deployment data into variables
                                    DeploymentID = DeploymentDataTable.Rows(0).Item("DeploymentID")
                                    AnimalID = DeploymentDataTable.Rows(0).Item("AnimalID")
                                    ActualFrequency = TruncatedFrequency
                                Else
                                    MsgBox("Multiple deployments problem MatchFrequencyToAnimal " & Frequency & " " & SightingDate)
                                End If
                            End If

                            'build up a new row for the data
                            Dim CollaredAnimalsInGroupsDataRow As DataRow = CollaredAnimalsInGroupsDataTable.NewRow
                            With CollaredAnimalsInGroupsDataRow
                                .Item("EID") = EID
                                .Item("AnimalID") = AnimalID
                                .Item("RecordedFrequency") = Frequency
                                .Item("ActualFrequency") = ActualFrequency
                                .Item("DeploymentID") = DeploymentID
                                .Item("RecordInsertedBy") = My.User.Name
                                .Item("RecordInsertedDate") = Now
                            End With

                            'if we have a deployment, insert the record
                            If DeploymentID > 0 Then
                                'see if the AnimalID already exists
                                Dim Filter As String = "EID" & " = '" & EID & "' And DeploymentID = " & DeploymentID
                                Dim ExistenceCheck As DataRow() = CollaredAnimalsInGroupsDataTable.Select(Filter)

                                'see if the row exists
                                If ExistenceCheck.Count = 0 Then
                                    'add the new row
                                    If DeploymentID > 0 Then
                                        CollaredAnimalsInGroupsDataTable.Rows.Add(CollaredAnimalsInGroupsDataRow)
                                    End If
                                End If
                            End If

                        Next

                        'End the bindingsource edits
                        CollaredAnimalsInGroupsBindingSource.EndEdit()

                        'reconcile the frequencies
                        ReconcileFrequencies()
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
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



    Private Sub OpenCapturesFormToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenCapturesFormToolStripButton.Click
        Dim CapturesForm As New CapturesForm
        CapturesForm.ShowDialog()
    End Sub




    Private Sub ReadOnlyCheck()
        With Me.SurveyFlightsGridEX
            If Me.AllowEditsToolStripButton.Text = "Disallow edits" Then
                .AllowAddNew = InheritableBoolean.True
                .AllowEdit = InheritableBoolean.True
                .AllowDelete = InheritableBoolean.True
                Me.SurveysGridEX.AllowAddNew = InheritableBoolean.True
                Me.SurveysGridEX.AllowEdit = InheritableBoolean.True
                Me.SurveysGridEX.AllowDelete = InheritableBoolean.True
                Me.CollaredAnimalsInGroupsGridEX.AllowAddNew = InheritableBoolean.True
                Me.CollaredAnimalsInGroupsGridEX.AllowEdit = InheritableBoolean.True
                Me.CollaredAnimalsInGroupsGridEX.AllowDelete = InheritableBoolean.True
                Me.ImportSurveyDataFromFileToolStripButton.Enabled = True
                Me.AutomatchToolStripSplitButton.Enabled = True
            ElseIf Me.AllowEditsToolStripButton.Text = "Allow edits" Then
                .AllowAddNew = InheritableBoolean.False
                .AllowEdit = InheritableBoolean.False
                .AllowDelete = InheritableBoolean.False
                Me.SurveysGridEX.AllowAddNew = InheritableBoolean.False
                Me.SurveysGridEX.AllowEdit = InheritableBoolean.False
                Me.SurveysGridEX.AllowDelete = InheritableBoolean.False
                Me.CollaredAnimalsInGroupsGridEX.AllowAddNew = InheritableBoolean.False
                Me.CollaredAnimalsInGroupsGridEX.AllowEdit = InheritableBoolean.False
                Me.CollaredAnimalsInGroupsGridEX.AllowDelete = InheritableBoolean.False
                Me.ImportSurveyDataFromFileToolStripButton.Enabled = False
                Me.AutomatchToolStripSplitButton.Enabled = False
            End If
        End With
    End Sub

    Private Sub AllowEditsToolStripButton_Click(sender As Object, e As EventArgs) Handles AllowEditsToolStripButton.Click
        '
        If Me.AllowEditsToolStripButton.Text = "Disallow edits" Then
            Me.AllowEditsToolStripButton.Text = "Allow edits"
        Else
            Me.AllowEditsToolStripButton.Text = "Disallow edits"
        End If
        ReadOnlyCheck()
    End Sub



    Private Sub SurveysGridEX_DeletingRecords(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SurveysGridEX.DeletingRecords
        ConfirmDelete(e)
    End Sub

    Private Sub CollaredAnimalsInGroupsGridEX_DeletingRecords(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CollaredAnimalsInGroupsGridEX.DeletingRecords
        ConfirmDelete(e)
    End Sub

    Private Sub OpenWRSTCaribouDirectoryToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenWRSTCaribouDirectoryToolStripButton.Click
        Try
            If My.Computer.FileSystem.DirectoryExists(My.Settings.SharedDirectory) Then
                Process.Start(My.Settings.SharedDirectory)
            Else
                MsgBox("Directory " & My.Settings.SharedDirectory & " does not exist. Modify the path to the WRST Caribou shared drive in the application settings.")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CurrentRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CurrentRowToolStripMenuItem.Click
        'try to match any frequencies in the current survey row to animal/frequency/collar deployments in animal movements
        Try
            'confirm delete all collared caribou records associated with the flight
            If MsgBox("Existing collared animals records associated with this flight may be replaced. Proceed?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                'resolve any changes to the database to avoid duplicate primary key problems
                AskToSaveChanges()

                'get a ref to the SurveysGridEX
                Dim GridEX As GridEX = Me.SurveysGridEX

                'ensure we have a current row
                If Not GridEX.CurrentRow Is Nothing Then
                    If Not GridEX.CurrentRow.Cells("EID") Is Nothing Then
                        If Not IsDBNull(GridEX.CurrentRow.Cells("EID").Value) Then
                            'We need a Datarow not a GridEXRow so we need to get the current DataRow from the SurveysBindingSource
                            Dim DRV As DataRowView = Me.SurveysBindingSource.Current

                            'The bindingsource holds the current row as a DataRowView, convert to a DataRow
                            Dim DR As DataRow = DRV.Row
                            MatchFrequencyToAnimal(DR)
                        End If
                    End If
                Else
                    MsgBox("Select a row")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub AllRowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllRowsToolStripMenuItem.Click
        'try to match any frequencies in the current survey gridex to animal/frequency/collar deployments in animal movements
        Try
            'get the flightid
            Dim FlightID As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")

            'if we have a flightid
            If FlightID.Trim.Length > 0 Then

                'confirm delete all collared caribou records associated with the flight
                If MsgBox("Existing collared animals records associated with this flight will be replaced. Proceed?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then

                    'get the collared caribou datatable reference
                    Dim CCGDataTable As DataTable = WRST_CaribouDataSet.Tables("CollaredAnimalsInGroups")

                    'loop through and delete all records with the current flightid
                    'For Each Row As DataRow In CCGDataTable.Rows
                    '    If Row.Item("FlightID") = FlightID Then
                    '        Row.Delete()
                    '    End If
                    'Next

                    'resolve any changes to the database to avoid duplicate primary key problems
                    AskToSaveChanges()

                    'now process each Survey record to match frequencies to animals and insert them into the CollaredCaribouInGroups table
                    Dim Filter As String = "FlightID = '" & FlightID & "'"
                    Dim DV As New DataView(Me.WRST_CaribouDataSet.Tables("Surveys"), Filter, "", DataViewRowState.CurrentRows)
                    For Each DVRow As DataRowView In DV
                        Dim Row As DataRow = DVRow.Row
                        MatchFrequencyToAnimal(Row)
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub SettingsToolStripButton_Click(sender As Object, e As EventArgs) Handles SettingsToolStripButton.Click
        Dim SettingsForm As New SettingsForm
        SettingsForm.ShowDialog()
    End Sub

    Private Sub DatabaseQueriesToolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseQueriesToolToolStripMenuItem.Click
        Dim ResultsForm As New ResultsForm
        ResultsForm.Show()
    End Sub



    Private Sub CollaredAnimalsInGroupsGridEX_DropDown(sender As Object, e As ColumnActionEventArgs) Handles CollaredAnimalsInGroupsGridEX.DropDown
        'load the animalids from animal movements into the selector combo
        LoadAnimalIDSCombo()
    End Sub



    ''' <summary>
    ''' The MatchAllObservedFrequenciesToCollarDeployments routine deletes all the records in the CollaredCaribouInGroups table, cycles through all the detected frequencies in the FrequenciesInGroup column of the 
    ''' Surveys table and matches the detected frequencies to Animals using the collar deployment information in Animal_Movement.
    ''' </summary>
    Private Sub MatchAllObservedFrequenciesToCollarDeployments()
        Dim Warning As String = "WARNING: This procedure is pretty drastic. The procedure will overwrite all the records in the CollaredAnimalsInGroups table. The procedure will then loop through all the frequencies ever recorded in all caribou groups and rematch them to collar deployments/animals in Animal_Movement. The procedure will take a long time and the application may appear frozen. Please do not close the application during this time. Proceed?"
        If MsgBox(Warning, MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then
            If MsgBox("In order to regenerate all the collared animals in groups records the application needs to delete all existing records in the CollaredAnimalsInGroups table. You will need to re-run all data quality checks and repairs.Proceed?", MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.Yes Then

                'ask to save the dataset
                AskToSaveChanges()

                Try
                    'delete all the records in CollaredAnimalsInGroups
                    Dim con As New SqlConnection(My.Settings.WRST_CaribouConnectionString)
                    Dim cmd As New SqlCommand("DELETE  FROM CollaredAnimalsInGroups", con)
                    Using con
                        con.Open()
                        cmd.ExecuteNonQuery()
                    End Using

                    AskToSaveChanges()

                    'because we deleted all the collared animals in groups records from the database we need to re-load the front-end app
                    LoadDataset()

                    'now loop through each survey record and regenerate the matches of frequency and date to animal deployments
                    For Each SurveyRow As DataRow In WRST_CaribouDataSet.Tables("Surveys").Rows
                        MatchFrequencyToAnimal(SurveyRow)
                    Next

                    'ask to save the dataset
                    AskToSaveChanges()

                    'reload the dataset
                    LoadDataset()

                    'update the QC highlighting on the surveys grid.
                    ReconcileFrequencies()

                Catch ex As Exception
                    MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
                End Try
            End If
        End If
    End Sub

    Private Sub CountTotalDetectedFrequenciesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CountTotalDetectedFrequenciesToolStripMenuItem.Click

        Dim QCFrequenciesForm As New QC_FrequenciesForm
        QCFrequenciesForm.Show()

    End Sub



    Private Sub CollaredAnimalsInGroupsGridEX_RecordUpdated(sender As Object, e As EventArgs) Handles CollaredAnimalsInGroupsGridEX.RecordUpdated

        '        If Not IsDBNull(DeploymentID) Then
        '            If DeploymentID > 0 Then
        '                Dim Sql As String = "SELECT        Collars.Frequency, CollarDeployments.DeploymentDate, CollarDeployments.AnimalId, CollarDeployments.RetrievalDate, Animals.MortalityDate, CollarDeployments.DeploymentId
        'FROM            Animals INNER JOIN
        '                         CollarDeployments ON Animals.ProjectId = CollarDeployments.ProjectId AND Animals.AnimalId = CollarDeployments.AnimalId INNER JOIN
        '                         Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId
        'WHERE        (CollarDeployments.DeploymentId = " & DeploymentID & ")
        'ORDER BY Collars.Frequency, CollarDeployments.DeploymentDate"
        '                Dim DeploymentDataTable As DataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
        '                If DeploymentDataTable.Rows.Count = 1 Then
        '                    With Grid.CurrentRow
        '                        .Cells("AnimalID").Value = DeploymentDataTable.Rows(0).Item("AnimalID")
        '                        .Cells("ActualFrequency").Value = DeploymentDataTable.Rows(0).Item("Frequency")
        '                    End With
        '                End If
        '            End If
        '        End If

    End Sub

    Private Sub InventoryOfAvailableCollarsOnADateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryOfAvailableCollarsOnADateToolStripMenuItem.Click
        Dim CollarsInventoryForm As New AvailableCollarsInventoryForADateForm()
        Dim CurrentSurveyDate As Date = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "TimeDepart")
        If Not IsDBNull(CurrentSurveyDate) Then
            CollarsInventoryForm.SurveyDate = CurrentSurveyDate
        End If
        CollarsInventoryForm.Show()
    End Sub

    Private Sub DMRematchAllFrequenciesToCollarDeploymentswithConfirmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DMRematchAllFrequenciesToCollarDeploymentswithConfirmToolStripMenuItem.Click
        MatchAllObservedFrequenciesToCollarDeployments()
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
