Public Class QC_FrequenciesForm


    Dim ProblemsDataTable As New DataTable("Problems") 'Data table to hold any problem frequencies encountered
    Dim ProjectIDsDataTable As New DataTable 'DataTable of ProjectIDs in Animal_Movement database that are related to the collared animals in WRST_Caribou database

    Private Sub QC_FrequenciesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Me.ExportResultsToolStripButton.Enabled = False

        With ProblemsDataTable
            .Columns.Add("Table", GetType(String))
            .Columns.Add("Frequency", GetType(Double))
            .Columns.Add("SightingDate", GetType(DateTime))
            .Columns.Add("GroupNumber", GetType(String))
            .Columns.Add("AM_Frequency", GetType(Double))
            .Columns.Add("AnimalID", GetType(String))
            .Columns.Add("AM_AnimalID", GetType(String))
            .Columns.Add("Problem", GetType(String))
            .Columns.Add("Details", GetType(String))
            .Columns.Add("PK", GetType(String))
            .Columns.Add("FlightID", GetType(String))
            .Columns.Add("Herd", GetType(String))
            '.PrimaryKey = New DataColumn() { .Columns("FlightID"), .Columns("Frequency")}
        End With


        Me.QCBindingSource.DataSource = Nothing
        Me.QCGridEX.DataSource = QCBindingSource
        Me.QCGridEX.RetrieveStructure()

        'get a list of acceptable Herd/ProjectIDs for the monitoring in the Animal_Movement database
        Dim ProjectIDsDataTable As DataTable = GetAnimal_Movement_ProjectIDsDataTable()

    End Sub

    Private Function GetProblemFrequencies(FrequencyTolerance As Double) As DataTable
        'steps: gather collar detections from the surveys table
        'loop through the frequencies in group column
        'verify the frequency relates to an animal/collar deployment
        'if not, record it in the problems table
        'then do the same for the earlyradiotracking table

        Dim Sql As String = ""
        'Try
        '    'process all frequencies detected in comp count, population, radiotracking surveys
        '    'add any problems to the problems data table

        '    'gather all frequency detections from the surveys and collaredanimalsingroups tables
        '  Sql = "SELECT Herd,SightingDate, FrequenciesInGroup,GroupNumber,EID,FlightID FROM Dataset_Full WHERE (FrequenciesInGroup IS NOT NULL) AND (RTRIM(LTRIM(FrequenciesInGroup)) <> '')"
        '    Dim SurveysDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        '    SurveysDataTable.TableName = "Surveys"


        '    'loop through all the frequencies in the groups
        '    For Each SurveyRow As DataRow In SurveysDataTable.Rows
        '        Dim SightingDate As String = SurveyRow.Item("SightingDate")
        '        Dim GroupNumber As Integer = SurveyRow.Item("GroupNumber")
        '        Dim EID As String = SurveyRow.Item("EID")
        '        Dim FlightID As String = SurveyRow.Item("FlightID")
        '        Dim FrequenciesInGroup As String = SurveyRow.Item("FrequenciesInGroup")
        '        Dim Herd As String = SurveyRow.Item("Herd")

        '        'parse the comma separated frequencies so we can deal with them individually
        '        Dim FrequenciesList As List(Of Double) = GetListOfCSVFrequencies(FrequenciesInGroup)

        '        For Each Frequency In FrequenciesList ' FrequenciesInGroup.Split(",")
        '            Dim NewRow As DataRow = ProblemsDataTable.NewRow

        '            'see if there is a matching collar deployment in the animal movements database
        '            Dim DeploymentDataTable As DataTable = GetDeploymentDataTableFromFrequencyAndDate(ProjectIDsDataTable, Herd, Frequency, SightingDate, 0.001, False)

        '            'take action depending on how many deployments were found
        '            'if only one deployment was found it implies the frequency matched one and only one collar deployment,
        '            'we're only interested in zero deployments or multiple deployments since these are things to fix
        '            If DeploymentDataTable.Rows.Count = 0 Then
        '                'no frequency found for the frequency and date
        '                Dim Problem As String = "No deployment in Animal Movement for this Frequency and Date"
        '                With NewRow
        '                    .Item("Table") = SurveysDataTable.TableName
        '                    .Item("SightingDate") = SightingDate
        '                    .Item("GroupNumber") = GroupNumber
        '                    .Item("Frequency") = Frequency
        '                    '.Item("AM_Frequency") = AM_Frequency
        '                    '.Item("AnimalID") = AnimalID
        '                    .Item("PK") = EID
        '                    .Item("FlightID") = FlightID
        '                    .Item("Problem") = Problem
        '                    .Item("Herd") = Herd
        '                End With
        '                ProblemsDataTable.Rows.Add(NewRow)
        '            ElseIf DeploymentDataTable.Rows.Count > 1 Then
        '                'one frequency found for the frequency and date
        '                'AnimalID = DeploymentDataTable.Rows(0).Item("AnimalID")
        '                'AM_Frequency = DeploymentDataTable.Rows(0).Item("Frequency")
        '                'Problem = "OK"
        '                Dim problem As String = "Multiple deployments"
        '                With NewRow
        '                    .Item("Table") = SurveysDataTable.TableName
        '                    .Item("SightingDate") = SightingDate
        '                    .Item("GroupNumber") = GroupNumber
        '                    .Item("Frequency") = Frequency
        '                    '.Item("AM_Frequency") = AM_Frequency
        '                    '.Item("AnimalID") = AnimalID
        '                    .Item("PK") = EID
        '                    .Item("FlightID") = FlightID
        '                    .Item("Problem") = problem
        '                    .Item("Herd") = Herd
        '                End With
        '                ProblemsDataTable.Rows.Add(NewRow)
        '            End If
        '        Next
        '    Next










        'process all frequencies detected in early radiotracking surveys
        'add any problems to the problems data table

        'gather all frequency detections from the early radiotracking table
        Sql = "SELECT Herd, FrequencyCorrectedForDrift, SightingDate,AnimalID,ERID FROM EarlyRadiotracking WHERE Frequency is not NULL and SightingDate is not NULL ORDER BY Frequency, SightingDate"
        Dim ERDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        ERDataTable.TableName = "EarlyRadiotracking"

        'loop through all the frequencies in the groups
        For Each ERRow As DataRow In ERDataTable.Rows
            Dim SightingDate As String = ERRow.Item("SightingDate")
            Dim ERID As String = ERRow.Item("ERID")
            Dim AnimalID As String = ERRow.Item("AnimalID")
            Dim Frequency As Double = ERRow.Item("FrequencyCorrectedForDrift")
            Dim Herd As String = ERRow.Item("Herd")
            Dim NewRow As DataRow = ProblemsDataTable.NewRow

            'see if there is a matching collar deployment in the animal movements database
            Dim DeploymentDataTable As DataTable = GetDeploymentDataTableFromFrequencyAndDate(Herd, Frequency, SightingDate, FrequencyTolerance, False)

            'take action depending on how many deployments were found
            'if only one deployment was found it implies the frequency matched one and only one collar deployment,
            'we're only interested in zero deployments or multiple deployments since these are things to fix
            If DeploymentDataTable.Rows.Count = 0 Then
                'no frequency found for the frequency and date
                Dim Problem As String = "No deployment in Animal Movement for this Frequency and Date"
                With NewRow
                    .Item("Table") = ERDataTable.TableName
                    .Item("SightingDate") = SightingDate
                    .Item("Frequency") = Frequency
                    .Item("PK") = ERID
                    .Item("Problem") = Problem
                    .Item("Herd") = Herd
                End With
                ProblemsDataTable.Rows.Add(NewRow)
            ElseIf DeploymentDataTable.Rows.Count > 1 Then
                'multiple deployments found. this is not allowed. probably an earlier deployment was not closed with a retrievaldate or mortalitydate
                'or the collar was entered twice in AM with frequencies of different precision 164.18 vs 164.180
                Dim problem As String = "Multiple deployments"
                With NewRow
                    .Item("Table") = ERDataTable.TableName
                    .Item("SightingDate") = SightingDate
                    .Item("Frequency") = Frequency
                    .Item("PK") = ERID
                    .Item("Problem") = problem
                    .Item("Herd") = Herd
                    .Item("Details") = "This happens when a collar deployment is not terminated with a RetrievalDate so the app cannot determine which animal was wearing the collar at the sighting date. Possibly the collar was entered into AM twice with slightly different frequency values."
                End With
                ProblemsDataTable.Rows.Add(NewRow)
            End If



            'do another check: make sure animalids match between the EarlyRadiotracking table and animal movements database deployment record
            If DeploymentDataTable.Rows.Count >= 1 Then
                'we have one or more deployment matches
                For Each DRow As DataRow In DeploymentDataTable.Rows
                    If Not IsDBNull(DRow.Item("AnimalID")) Then

                        'look for records where the frequency may be correct but the animalid is incorrect
                        Dim AM_AnimalID As String = DRow.Item("AnimalID")
                        If AnimalID.Trim <> AM_AnimalID.Trim Then
                            'we found a mismatch. somehow the deployment's animalid does not match the early radiotracking recorded animalid
                            Dim problem As String = "AnimalID mismatched between EarlyRadiotracking table and Animal_Movement.Animals table."
                            With NewRow
                                .Item("Table") = ERDataTable.TableName
                                .Item("SightingDate") = SightingDate
                                .Item("Frequency") = Frequency
                                .Item("AM_AnimalID") = AM_AnimalID
                                .Item("AnimalID") = AnimalID
                                .Item("PK") = ERID
                                .Item("Problem") = problem
                                .Item("Herd") = Herd
                            End With
                            ProblemsDataTable.Rows.Add(NewRow)
                        End If
                    End If
                Next
            End If
        Next

        Try
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try

        'sort the problems data table better
        Dim ProblemsDataView As New DataView(ProblemsDataTable, "", "Frequency,SightingDate,GroupNumber", DataViewRowState.CurrentRows)
        Return ProblemsDataView.ToTable
    End Function

    Private Sub RunToolStripButton_Click(sender As Object, e As EventArgs) Handles RunToolStripButton.Click
        Me.QCBindingSource.DataSource = Nothing
        Me.ExportResultsToolStripButton.Enabled = False
        Try
            Dim ProblemsDataTable As DataTable = GetProblemFrequencies(0.01)
            If ProblemsDataTable.Rows.Count > 0 Then Me.ExportResultsToolStripButton.Enabled = True
            Me.QCBindingSource.DataSource = ProblemsDataTable
            Me.QCGridEX.DataSource = QCBindingSource
            Me.QCGridEX.RetrieveStructure()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub ExportResultsToolStripButton_Click(sender As Object, e As EventArgs) Handles ExportResultsToolStripButton.Click
        'export the problems datatable to csv
        ExportDataTableToCSV(ProblemsDataTable)
    End Sub



End Class