Imports System.Data.SqlClient
Imports System.IO
Imports Janus.Windows.GridEX
Imports SkeeterDataTablesTranslator

Public Class MainForm

    Dim ProjectIDsDataTable As New DataTable 'DataTable of ProjectIDs in Animal_Movement database that are related to the collared animals in WRST_Caribou database

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'My.Settings.Item("WRST_CaribouConnectionString") = "Data Source=INPYUGA41738\SKETR;Initial Catalog=WRST_Caribou;Integrated Security=True"
        My.Settings.Item("Animal_MovementConnectionString") = "Data Source=INPAKROVMAIS;Initial Catalog=Animal_Movement;Integrated Security=True"

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
            Me.SurveyFlightsGridEX.FilterMode = FilterMode.Automatic
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


        'Load the ProjectIDs ('WRST_Caribou', 'ChisanaCH' associated with the animals in WRST_Caribou and Animal_Movement into a database
        Try
            ProjectIDsDataTable = GetAnimal_Movement_ProjectIDsDataTable()
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
            Me.CollaredAnimalsInGroupsBindingSource.EndEdit()
            Me.SurveysBindingSource.EndEdit()
            Me.SurveyFlightsBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)
            WRST_CaribouDataSet.AcceptChanges()
            'Catch DBCEx As DBConcurrencyException
            '    If MsgBox("Concurrency violation. " & DBCEx.Message & " Merge your edits into the database?", MsgBoxStyle.YesNo, "Concurrency violation.") = MsgBoxResult.Yes Then
            '        Me.WRST_CaribouDataSet.Merge(WRST_CaribouDataSet, True)
            '        SaveDataset()
            '    Else
            '        MsgBox("Save canceled.")
            '        Exit Sub
            '    End If
            '    Exit Sub
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
    Private Sub SetUpCollaredAnimalsInGroupsGridEXDropDowns(SightingDate As Date, Herd As String)
        Try
            'Set up default values
            Dim Grid As GridEX = Me.CollaredAnimalsInGroupsGridEX

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
            Dim CollaredAnimalsDataTable As DataTable = GetAvailableCollarsInventoryForADate(SightingDate, Herd)

            'get a reference to the dropdown's value list
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
        'This will run after the user selects a DeploymentID from the CollaredAnimalsInGroupsGridEX to match an animal to a frequency
        'and will put the AnimalID of the animal wearing the collar transmitting on Frequency into the grid
        Try
            Dim Grid As GridEX = sender
            If Not Grid.CurrentRow Is Nothing Then

                'Get the current DeploymentID
                Dim DeploymentID As Integer = GetCurrentGridEXCellValue(Grid, "DeploymentID")

                'Get the AnimalID for the DeploymentID from Animal_Movement
                Dim Sql As String = "Select CollarDeployments.AnimalId,  Collars.Frequency, CollarDeployments.DeploymentDate, CollarDeployments.RetrievalDate, Animals.MortalityDate, CollarDeployments.DeploymentId
From Animals INNER Join
              CollarDeployments On Animals.ProjectId = CollarDeployments.ProjectId And Animals.AnimalId = CollarDeployments.AnimalId INNER Join
              Collars On CollarDeployments.CollarManufacturer = Collars.CollarManufacturer And CollarDeployments.CollarId = Collars.CollarId
Where (CollarDeployments.DeploymentId = " & DeploymentID & ")"

                'Submit the query above to Animal_Movement and get back a DataTable of, hopefully, one deployment.
                Dim DeploymentDataTable As DataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)

                'Update the CollaredAnimalsInGroupsGridEX's current row with the AnimalID
                If DeploymentDataTable.Rows.Count = 1 Then
                    'Update the AnimalID cell with the value queried above for the DeploymentID
                    With Grid.CurrentRow
                        .Cells("AnimalID").Value = DeploymentDataTable.Rows(0).Item("AnimalID")
                        '.Cells("RecordedFrequency").Value = DeploymentDataTable.Rows(0).Item("Frequency")
                        .Cells("ActualFrequency").Value = DeploymentDataTable.Rows(0).Item("Frequency")
                        .Cells("RecordInsertedDate").Value = Now
                        .Cells("RecordInsertedBy").Value = My.User.Name
                    End With
                Else
                    MsgBox("Multiple deployments returned for this DeploymentID. " & System.Reflection.MethodBase.GetCurrentMethod.Name)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

    ''' <summary>
    ''' Returns the maximum value of GridEX's column named GroupNumber. Used to increment GroupNumber as a default value for new records by adding 1.
    ''' </summary>
    ''' <returns>Maximum GroupNumber. Integer.</returns>
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
    ''' <returns>Frequency. Double.</returns>
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
        'ReconcileFrequencies()



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
        'LockCertifiedRecords()

        'update the CollaredAnimalsInGroupsGridEX header
        UpdateCollaredAnimalsInGroupsGridEXHeader()

        'QC the number of frequencies matches the number of animalids
        ReconcileFrequencies()

    End Sub

    Private Sub CollaredAnimalsInGroupsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles CollaredAnimalsInGroupsGridEX.SelectionChanged

        'clear the animal grid caption so lingering data does not confuse user
        If Not Me.AnimalGridEX Is Nothing Then
            If Not AnimalGridEX.RootTable Is Nothing Then
                Me.AnimalGridEX.RootTable.Caption = ""
            End If
        End If

        'update the surveys grid columns that count the number of frequencies and animalids to make sure all are accounted for
        ReconcileFrequencies()

        'disallow edits on certified records
        'LockCertifiedRecords()

        'load animal movement grids
        LoadAnimalMovementGrids()
    End Sub

    ''' <summary>
    ''' LoadAnimalMovementGrids builds an Animal Object by querying the Animal Movement and WRST_Caribou databases for information about the currently selected caribou
    ''' in the Surveys grid. AnimalGridEX tree grid is loaded with the data from the Animal Object. See Animal.vb.
    ''' </summary>
    Private Sub LoadAnimalMovementGrids()
        'clear any residual data out of the animal grid
        Me.AnimalGridEX.DataSource = Nothing

        Me.AnimalGridEX.Visible = Me.ShowAnimalDetailsCheckBox.Checked

        'if the user opts to see animal details with every selection change
        If Me.ShowAnimalDetailsCheckBox.Checked = True Then
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
        End If

    End Sub




    Private Sub ImportSurveyDataFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportSurveyDataFromFileToolStripButton.Click
        Try
            'get the current flightid from the survey flights grid
            Dim CurrentFlightID As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")

            'get the current herd from the surveys grid
            Dim CurrentHerd As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd")

            'if valid flightid and herd
            If Not CurrentFlightID Is Nothing And Not CurrentHerd Is Nothing Then
                'also, both not null
                If Not IsDBNull(CurrentFlightID) And Not IsDBNull(CurrentHerd) Then
                    If Not CurrentFlightID.Trim.Length = 0 Or CurrentHerd.Trim.Length = 0 Then

                        'get the structure of the destination datatable, we only need the structure so we query only one record; translator will clear all records anyway
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
        'Dim Grid As GridEX = sender
        'DoCertificationSteps(Grid, e)
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

            'Get the current cell's SightingDate value
            Dim CurrentSightingDate As String = GetCurrentGridEXCellValue(Me.SurveysGridEX, "SightingDate")
            Dim CurrentHerd As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd").ToString.Trim

            'If it's a good date then set up the collared animals in groups drop downs.
            If IsDate(CurrentSightingDate) And CurrentHerd <> "" Then
                SetUpCollaredAnimalsInGroupsGridEXDropDowns(CDate(CurrentSightingDate), CurrentHerd)
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
            Dim Herd As String = ""
            Try
                Herd = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd").ToString.Trim()
            Catch ex As Exception
                Herd = ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name
            End Try

            'Reset grid caption
            Me.CollaredAnimalsInGroupsGridEX.RootTable.Caption = ""

            'start by getting the groupnumber and frequencies data
            If Not GetCurrentGridEXCellValue(Me.SurveysGridEX, "FrequenciesInGroup") Is Nothing Then
                If Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveysGridEX, "GroupNumber")) Then
                    Dim GroupNumber As String = GetCurrentGridEXCellValue(Me.SurveysGridEX, "GroupNumber")

                    'make the gridex caption more specific
                    Me.CollaredAnimalsInGroupsGridEX.RootTable.Caption = "No frequencies detected in group #" & GroupNumber

                    'next determine if the frequencies in group column has data
                    If Not IsDBNull(GetCurrentGridEXCellValue(Me.SurveysGridEX, "FrequenciesInGroup")) Then
                        If Not GetCurrentGridEXCellValue(Me.SurveysGridEX, "FrequenciesInGroup") Is Nothing Then
                            Dim FrequenciesInGroup As String = GetCurrentGridEXCellValue(Me.SurveysGridEX, "FrequenciesInGroup")
                            If FrequenciesInGroup.Trim.Length > 0 Then
                                'frequencies exist, update the gridex caption
                                Me.CollaredAnimalsInGroupsGridEX.RootTable.Caption = Herd & " frequencies/animals detected in group #" & GroupNumber & ": " & FrequenciesInGroup
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
    ''' Quality control check. For a Survey record this Sub counts the number of FrequenciesInGroup and the number of AnimalIDs in the CollaredAnimalsInGroups table, then loads the two counts into the
    ''' NumFrequencies and NumAnimalIDs columns in the SurveysGridEX.
    ''' </summary>
    Private Sub ReconcileFrequencies()
        'check that the number of frequencies in Surveys.FrequenciesInGroup column match the number of items in the CollaredAnimalsInGroups table for the record
        Try
            If SurveysGridEX.RowCount > 0 Then

                'loop through the surveys grid rows
                For Each Row As GridEXRow In SurveysGridEX.GetRows
                    If IsNothing(Row) = False Then
                        If IsNothing(Row.Cells("EID")) = False Then
                            If Not Row.Cells("EID").Value Is Nothing Then

                                'If Not Row.Cells("EID").Value.ToString.Trim <> "" Then 'nothing got past here when it was enabled, i don't know why
                                If Not IsDBNull(Row.Cells("EID").Value) Then
                                    Dim EID As String = Row.Cells("EID").Value

                                    'make sure the EID is not just blank instead of null
                                    If Not EID.Trim = "" Then

                                        'make the row editable
                                        Row.BeginEdit()

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

                                        'end the edit on the row
                                        Row.EndEdit()
                                    End If
                                End If
                                'End If
                            End If
                        End If
                    End If
                Next
            End If
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
    ''' Auto-matches a GPS collar Frequency to a collar deployment (and animal) in Animal Movement. Helper sub to process GridEX rows from AutomatchFrequenciesToAnimals()
    ''' </summary>
    ''' <param name="SurveyRow">DataRow from the Surveys DataTable containing EID, GroupNumber, FrequenciesInGroup and SightingDate columns.</param>
    ''' <param name="Herd">Herd associated with the Animal associated with the Collar at the time of SightingDate</param>
    Private Sub AddCollaredAnimalsRowsToSurveyRow(SurveyRow As DataRow, Herd As String)
        CollaredAnimalsInGroupsBindingSource.EndEdit()

        Try
            'extract the frequencies from the row's FrequenciesInGroup column and try to parse it, search for the collar deployment in Animal Movement and insert the DeploymentID into the collared animals in groups table
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
                            Dim DeploymentDataTable As DataTable = GetDeploymentDataTableFromFrequencyAndDate(Herd, Frequency, SightingDate, 0.001)

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
                                'ElseIf DeploymentDataTable.Rows.Count = 0 Then
                                'no deployments retrieved. the app should stick the default deployment values above in the new row
                            Else
                                'one reason we may not have gotten a deployment row above is because the frequency needs to be truncated
                                'sometimes it's recorded in the field or in Animal Movement to too many decimal places
                                'three decimal places is the usual so truncate it to 3 here.
                                Dim TruncatedFrequency As Double = Math.Round(Frequency, 3)
                                DeploymentDataTable = GetDeploymentDataTableFromFrequencyAndDate(Herd, TruncatedFrequency, SightingDate, 0.001)

                                'if there is a deployment for the date and frequency
                                If DeploymentDataTable.Rows.Count = 1 Then
                                    'we retreived a deployment. put the deployment data into variables
                                    DeploymentID = DeploymentDataTable.Rows(0).Item("DeploymentID")
                                    AnimalID = DeploymentDataTable.Rows(0).Item("AnimalID")
                                    ActualFrequency = TruncatedFrequency
                                ElseIf DeploymentDataTable.Rows.Count > 1 Then
                                    MsgBox("Multiple deployments problem (AddCollaredAnimalsRowsToSurveyRow) " & Frequency & " " & SightingDate)
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
                'Me.AnimalGridPanel.Enabled = True
                'Me.ShowAnimalDetailsCheckBox.Enabled = True
                Me.AnimalGridEX.Enabled = True
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
                'Me.AnimalGridPanel.Enabled = False
                'Me.ShowAnimalDetailsCheckBox.Enabled = False
                Me.AnimalGridEX.Enabled = False
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



    Private Sub CurrentRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CurrentRowToolStripMenuItem.Click
        'try to match any frequencies in the current survey row to animal/frequency/collar deployments in animal movements
        Try
            CollaredAnimalsInGroupsBindingSource.EndEdit()

            'confirm delete all collared caribou records associated with the flight
            If MsgBox("Existing collared animals records associated with this row may be replaced. Proceed?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                'resolve any changes to the database to avoid duplicate primary key problems
                AskToSaveChanges()

                'get a ref to the SurveysGridEX
                Dim SurveysGridEX As GridEX = Me.SurveysGridEX

                'Ensure we have a current survey flight row. 
                If Not SurveyFlightsGridEX.CurrentRow Is Nothing Then
                    'get the herd from the flight
                    If Not SurveyFlightsGridEX.CurrentRow.Cells("Herd") Is Nothing Then
                        If Not IsDBNull(SurveyFlightsGridEX.CurrentRow.Cells("Herd").Value) Then
                            Dim Herd As String = SurveyFlightsGridEX.CurrentRow.Cells("Herd").Value.ToString.Trim

                            'ensure we have a current Survey row
                            If Not SurveysGridEX.CurrentRow Is Nothing Then
                                'see if EID exists which will indicate we have a current row
                                If Not SurveysGridEX.CurrentRow.Cells("EID") Is Nothing Then
                                    If Not IsDBNull(SurveysGridEX.CurrentRow.Cells("EID").Value) Then

                                        'We need a Datarow not a GridEXRow so we need to get the current DataRow from the SurveysBindingSource
                                        Dim SurveyDataRowView As DataRowView = Me.SurveysBindingSource.Current
                                        Dim SurveyDataRow As DataRow = SurveyDataRowView.Row

                                        'get a ref to the collared caribou in groups datatable
                                        Dim CCGDataTable As DataTable = WRST_CaribouDataSet.Tables("CollaredAnimalsInGroups")

                                        'Get the Survey row's primary key
                                        Dim EID As String = SurveyDataRow.Item("EID").ToString.Trim
                                        Dim CollaredCaribouInSurveyGroupRows = CCGDataTable.Select("EID = '" & EID & "'")
                                        For Each CollaredCaribouRow In CollaredCaribouInSurveyGroupRows
                                            CollaredCaribouRow.BeginEdit()
                                            CollaredCaribouRow.Delete()
                                            CollaredCaribouRow.EndEdit()
                                        Next
                                        CollaredAnimalsInGroupsBindingSource.EndEdit()
                                        SaveDataset()

                                        'CollaredAnimalsInGroupsTableAdapter.Update(WRST_CaribouDataSet)
                                        'CCGDataTable.AcceptChanges()

                                        'WRST_CaribouDataSet.AcceptChanges()


                                        'Now add back to the Survey row Animals whose frequency was detected
                                        AddCollaredAnimalsRowsToSurveyRow(SurveyDataRow, Herd)
                                        CollaredAnimalsInGroupsBindingSource.EndEdit()
                                    End If
                                End If
                            Else
                                MsgBox("Select a row")
                            End If
                        End If
                    End If
                End If
            End If
            'SaveDataset()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub AllRowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllRowsToolStripMenuItem.Click
        'try to match any frequencies in the current survey gridex to animal/frequency/collar deployments in animal movements
        Try
            CollaredAnimalsInGroupsBindingSource.EndEdit()

            'get the flightid
            Dim FlightID As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")
            Dim Herd As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd")

            'if we have a flightid
            If FlightID.Trim.Length > 0 And (Herd = "Mentasta" Or Herd = "Chisana") Then

                'confirm delete all collared caribou records associated with the flight
                If MsgBox("Existing collared animals records associated with this flight will be replaced. Proceed?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then

                    'get the collared caribou datatable reference
                    Dim CCGDataTable As DataTable = WRST_CaribouDataSet.Tables("CollaredAnimalsInGroups")

                    'resolve any changes to the database to avoid duplicate primary key problems
                    AskToSaveChanges()

                    'now process each Survey record to match frequencies detected in groups to actual animals and insert them into the CollaredCaribouInGroups table
                    Dim DV As New DataView(Me.WRST_CaribouDataSet.Tables("Surveys"), "FlightID = '" & FlightID & "'", "", DataViewRowState.CurrentRows)
                    For Each SurveyDataRowView As DataRowView In DV

                        'Find the deployment id and animalid and fill in the cells for the row
                        Dim SurveyDataRow As DataRow = SurveyDataRowView.Row

                        'loop through and delete all records with the current EID
                        Dim EID As String = SurveyDataRow.Item("EID").ToString.Trim
                        Dim CollaredCaribouInSurveyGroupRows = CCGDataTable.Select("EID = '" & EID & "'")
                        For Each CollaredCaribouRow In CollaredCaribouInSurveyGroupRows
                            CollaredCaribouRow.BeginEdit()
                            CollaredCaribouRow.Delete()
                            CollaredCaribouRow.EndEdit()
                        Next
                        'CollaredAnimalsInGroupsBindingSource.EndEdit()
                        'CollaredAnimalsInGroupsTableAdapter.Update(WRST_CaribouDataSet)
                        SaveDataset()
                        CCGDataTable.AcceptChanges()

                        'Now add back to the survey row Animals whose frequency was detected
                        AddCollaredAnimalsRowsToSurveyRow(SurveyDataRow, Herd)
                        CollaredAnimalsInGroupsBindingSource.EndEdit()
                        SaveDataset()
                    Next
                End If
            End If
            'SaveDataset()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub



    Private Sub DatabaseQueriesToolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseQueriesToolToolStripMenuItem.Click
        Dim ResultsForm As New ResultsForm
        ResultsForm.Show()
    End Sub



    Private Sub CollaredAnimalsInGroupsGridEX_DropDown(sender As Object, e As ColumnActionEventArgs) Handles CollaredAnimalsInGroupsGridEX.DropDown
        'load the animalids from animal movements into the selector combo
        LoadAnimalIDSCombo()
    End Sub

    Private Sub CountTotalDetectedFrequenciesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CountTotalDetectedFrequenciesToolStripMenuItem.Click
        Dim QCFrequenciesForm As New QC_FrequenciesForm
        QCFrequenciesForm.Show()
    End Sub




    Private Sub ShowAnimalDetailsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowAnimalDetailsCheckBox.CheckedChanged
        'load the animal details from animal_movement
        LoadAnimalMovementGrids()
    End Sub

    Private Sub SurveysGridEX_Validated(sender As Object, e As EventArgs) Handles SurveysGridEX.Validated
        'update the surveys grid columns that count the number of frequencies and animalids to make sure all are accounted for
        ReconcileFrequencies()
    End Sub

    Private Sub CollaredAnimalsInGroupsGridEX_Validated(sender As Object, e As EventArgs) Handles CollaredAnimalsInGroupsGridEX.Validated
        'update the surveys grid columns that count the number of frequencies and animalids to make sure all are accounted for
        ReconcileFrequencies()
    End Sub

    Private Sub CaribouProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CaribouProfileToolStripMenuItem.Click
        Dim CaribouProfileForm As New CaribouProfileForm()
        CaribouProfileForm.Show()
    End Sub

    Private Sub SightingsHistoryPerAnimalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SightingsHistoryPerAnimalToolStripMenuItem.Click
        Dim CSHForm As New CaribouSightingsHistoryForm()
        CSHForm.Show()
    End Sub



    Private Sub SynchronizeDatabasesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SynchronizeDatabasesToolStripMenuItem.Click
        AskToSynchronizeDatabases()
    End Sub

    Private Sub OpenWRSTCaribouSharedNetworkDriveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenWRSTCaribouSharedNetworkDriveToolStripMenuItem.Click
        Try
            If My.Computer.FileSystem.DirectoryExists(My.Settings.SharedDirectory) Then
                Process.Start(My.Settings.SharedDirectory)
            Else
                MsgBox("Directory " & My.Settings.SharedDirectory & " does not exist. Modify the path to the WRST Caribou shared drive in the application settings.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim SettingsForm As New SettingsForm
        SettingsForm.ShowDialog()
    End Sub

    Private Sub InventoryOfCollarsForADateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryOfCollarsForADateToolStripMenuItem.Click
        Dim CollarsInventoryForm As New AvailableCollarsInventoryForADateForm()
        Dim CurrentSurveyDate As Date = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "TimeDepart")
        If Not IsDBNull(CurrentSurveyDate) Then
            CollarsInventoryForm.SurveyDate = CurrentSurveyDate
        End If
        CollarsInventoryForm.Show()
    End Sub

    Private Sub InventoryOfCollarsAvailableForADateToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CapturesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CapturesToolStripMenuItem.Click
        MsgBox("The Captures form is having problems. Temporarily unavailable.")
        'Dim CapturesForm As New CapturesForm
        'CapturesForm.ShowDialog()
    End Sub

    Private Sub OpenIRMAProjectReferenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenIRMAProjectReferenceToolStripMenuItem.Click
        Try
            Process.Start(My.Settings.IRMAProjectReference)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub IRMADataDeliverablesDatasetReferenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IRMADataDeliverablesDatasetReferenceToolStripMenuItem.Click
        Try
            Process.Start(My.Settings.IRMADataDeliverablesDatasetReference)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub ChangeCertificationLevelToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChangeCertificationLevelToolStripComboBox.SelectedIndexChanged
        Try
            'get the flightid
            Dim FlightID As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")

            'If we have a flightid
            If FlightID.Trim.Length > 0 Then

                'If we have a certification level choice made
                If Me.ChangeCertificationLevelToolStripComboBox.Text.Trim.Length > 0 Then

                    'Determine how to change certification level
                    If Me.ChangeCertificationLevelToolStripComboBox.Text.Trim.ToLower = "raw" Or Me.ChangeCertificationLevelToolStripComboBox.Text.Trim.ToLower = "provisional" Then

                        'Change the CertificationLevel to Raw or Provisional
                        If MsgBox("Proceeding will changed the records shown in the grid below to " & Me.ChangeCertificationLevelToolStripComboBox.Text.Trim & ". Proceed?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then

                            'Get a recordset of the records to be changed
                            Dim DV As New DataView(Me.WRST_CaribouDataSet.Tables("Surveys"), "FlightID = '" & FlightID & "'", "", DataViewRowState.CurrentRows)

                            'Loop through the records and see if any of them are alread certified, these should not be changed.
                            Dim RecordsetContainsCertifiedRecords As Boolean = False
                            For Each SurveyDataRowView As DataRowView In DV
                                If SurveyDataRowView.Item("FlightID") = FlightID Then
                                    If SurveyDataRowView.Item("CertificationLevel") = "Certified" Then RecordsetContainsCertifiedRecords = True
                                End If
                            Next

                            'Only proceed if the records to be changed are not already certified
                            If RecordsetContainsCertifiedRecords = True Then
                                If MsgBox("WARNING: One or more of the records you are attempting to change is certified. You should only change the certification level for these records if a serious error has been corrected. Proceed?", MsgBoxStyle.Critical, "WARNING") = MsgBoxResult.Ok Then
                                    'User confirmed warning: Change the certification level for each record
                                    For Each SurveyDataRowView As DataRowView In DV
                                        If SurveyDataRowView.Item("FlightID") = FlightID Then
                                            SurveyDataRowView.Item("CertificationLevel") = Me.ChangeCertificationLevelToolStripComboBox.Text.Trim
                                            SurveyDataRowView.Item("CertificationDate") = DBNull.Value
                                            SurveyDataRowView.Item("CertifiedBy") = DBNull.Value
                                            Me.SurveysBindingSource.EndEdit()
                                        End If
                                    Next
                                End If

                            ElseIf RecordsetContainsCertifiedRecords = False Then

                                'Update the records
                                For Each SurveyDataRowView As DataRowView In DV
                                    If SurveyDataRowView.Item("FlightID") = FlightID Then
                                        SurveyDataRowView.Item("CertificationLevel") = Me.ChangeCertificationLevelToolStripComboBox.Text.Trim
                                        SurveyDataRowView.Item("CertificationDate") = DBNull.Value
                                        SurveyDataRowView.Item("CertifiedBy") = DBNull.Value
                                        Me.SurveysBindingSource.EndEdit()
                                    End If
                                Next
                            End If
                        End If

                    ElseIf Me.ChangeCertificationLevelToolStripComboBox.Text.Trim.ToLower = "certified" Then

                        'Change the CertificationLevel to Certified
                        If MsgBox("Proceeding will changed the records shown in the grid below to " & Me.ChangeCertificationLevelToolStripComboBox.Text.Trim & ". Records should only be certified if all quality control procedures have been run and the data have been approved by the project leader, or if the data can be validated against a report or original field data collection forms. Proceed?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then

                            'Ask if the user wants to also add a data quality note
                            Dim NotePrefix As String = Now & " " & My.User.Name & ": "
                            Dim DataQualityNotes As String = InputBox("If you would like to append a data quality note to each of the records to be certified then enter it here, otherwise dismiss.", "Add data quality note to the records being certified?", NotePrefix)

                            'now process each Survey record to match frequencies detected in groups to actual animals and insert them into the CollaredCaribouInGroups table
                            Dim DV As New DataView(Me.WRST_CaribouDataSet.Tables("Surveys"), "FlightID = '" & FlightID & "'", "", DataViewRowState.CurrentRows)
                            For Each SurveyDataRowView As DataRowView In DV
                                'Execute the updates
                                If SurveyDataRowView.Item("FlightID") = FlightID Then
                                    SurveyDataRowView.Item("CertificationLevel") = "Certified"
                                    SurveyDataRowView.Item("CertificationDate") = Now
                                    SurveyDataRowView.Item("CertifiedBy") = My.User.Name
                                    If DataQualityNotes.Trim <> NotePrefix.Trim Then
                                        SurveyDataRowView.Item("DataQualityNotes") = SurveyDataRowView.Item("DataQualityNotes") & " " & DataQualityNotes
                                    End If
                                    Me.SurveysBindingSource.EndEdit()
                                End If
                            Next
                        End If
                    End If
                End If
                    'Reset the ChangeCertificationLevelToolStripComboBox
                    Me.ChangeCertificationLevelToolStripComboBox.Text = ""
                End If

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub EditDataQualityNotesToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EditDataQualityNotesToolStripComboBox.SelectedIndexChanged
        Try
            'Get the flightid
            Dim FlightID As String = GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")

            'Dim some values to use later
            Dim DataQualityNotes As String = ""
            Dim NotePrefix As String = Now & " " & My.User.Name & ": "

            'If we have a flightid
            If FlightID.Trim.Length > 0 Then

                'User opted to append a data quality note to the flight's records
                If EditDataQualityNotesToolStripComboBox.Text = "Append data quality note to all displayed records" Then

                    'Gather a data quality note from user
                    Dim InputBoxResult As String = InputBox("Enter data quality note to append to each record in the grid below: ", "Append data quality note", NotePrefix)

                    'Reset the combo box
                    Me.EditDataQualityNotesToolStripComboBox.Text = ""

                    'If user entered a data quality note
                    If InputBoxResult.Trim <> NotePrefix.Trim And InputBoxResult.Trim <> "" Then

                        'Prefix the note with name and date
                        DataQualityNotes = InputBoxResult

                        'now process each Survey record to match frequencies detected in groups to actual animals and insert them into the CollaredCaribouInGroups table
                        Dim DV As New DataView(Me.WRST_CaribouDataSet.Tables("Surveys"), "FlightID = '" & FlightID & "'", "", DataViewRowState.CurrentRows)
                        For Each SurveyDataRowView As DataRowView In DV
                            If SurveyDataRowView.Item("FlightID") = FlightID Then
                                SurveyDataRowView.Item("DataQualityNotes") = SurveyDataRowView.Item("DataQualityNotes") & " " & DataQualityNotes
                                Me.SurveysBindingSource.EndEdit()
                            End If
                        Next
                    End If
                End If

                'User opted to overwrite data quality notes for the flight's records
                If EditDataQualityNotesToolStripComboBox.Text = "Overwrite data quality notes for all displayed records" Then
                    'Gather a data quality note from user
                    Dim InputBoxResult As String = InputBox("Enter data quality note to append to each record in the grid below: ", "Append data quality note", NotePrefix)

                    'Reset the combo box
                    Me.EditDataQualityNotesToolStripComboBox.Text = ""

                    'If user entered a data quality note
                    If InputBoxResult.Trim <> NotePrefix.Trim And InputBoxResult.Trim <> "" Then

                        'Prefix the note with name and date
                        DataQualityNotes = InputBoxResult

                        'now process each Survey record to match frequencies detected in groups to actual animals and insert them into the CollaredCaribouInGroups table
                        Dim DV As New DataView(Me.WRST_CaribouDataSet.Tables("Surveys"), "FlightID = '" & FlightID & "'", "", DataViewRowState.CurrentRows)
                        For Each SurveyDataRowView As DataRowView In DV
                            If SurveyDataRowView.Item("FlightID") = FlightID Then
                                SurveyDataRowView.Item("DataQualityNotes") = DataQualityNotes
                                Me.SurveysBindingSource.EndEdit()
                            End If
                        Next
                    End If


                End If

            Else
                MsgBox("No flight has been selected.")
            End If


            '    


            '    End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub
End Class
