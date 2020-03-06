﻿Public Class QC_FrequenciesForm


    'Dim QCDataTable As New DataTable

    Private Sub QC_FrequenciesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.QCBindingSource.DataSource = Nothing
        Me.QCGridEX.DataSource = QCBindingSource
        Me.QCGridEX.RetrieveStructure()
    End Sub

    Private Function GetProblemFrequencies() As DataTable
        'steps: gather collar detections from the surveys table
        'loop through the frequencies in group column
        'verify the frequency relates to an animal/collar deployment
        'if not, record it in the problems table
        'then do the same for the earlyradiotracking table


        ' make a data table to hold any problem frequencies encountered
        Dim ProblemsDataTable As New DataTable("Problems")
        With ProblemsDataTable
            .Columns.Add("Table", GetType(String))
            .Columns.Add("Frequency", GetType(Double))
            .Columns.Add("SightingDate", GetType(DateTime))
            .Columns.Add("GroupNumber", GetType(String))
            '.Columns.Add("A_Frequency", GetType(Double))
            '.Columns.Add("AnimalID", GetType(String))
            .Columns.Add("Problem", GetType(String))
            .Columns.Add("PK", GetType(String))
            .Columns.Add("FlightID", GetType(String))
            '.PrimaryKey = New DataColumn() { .Columns("FlightID"), .Columns("Frequency")}
        End With

        'gather all frequency detections from the surveys and collaredanimalsingroups tables
        Dim Sql As String = "SELECT SightingDate, FrequenciesInGroup,GroupNumber,EID,FlightID FROM Dataset_Full WHERE (FrequenciesInGroup IS NOT NULL) AND (RTRIM(LTRIM(FrequenciesInGroup)) <> '')"
        Dim SurveysDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        SurveysDataTable.TableName = "Surveys"

        'loop through all the frequencies in the groups
        For Each SurveyRow As DataRow In SurveysDataTable.Rows
            Dim SightingDate As String = SurveyRow.Item("SightingDate")
            Dim GroupNumber As Integer = SurveyRow.Item("GroupNumber")
            Dim EID As String = SurveyRow.Item("EID")
            Dim FlightID As String = SurveyRow.Item("FlightID")
            Dim FrequenciesInGroup As String = SurveyRow.Item("FrequenciesInGroup")

            'parse the comma separated frequencies so we can deal with them individually
            Dim FrequenciesList As List(Of Double) = GetListOfCSVFrequencies(FrequenciesInGroup)

            For Each Frequency In FrequenciesList ' FrequenciesInGroup.Split(",")
                Dim NewRow As DataRow = ProblemsDataTable.NewRow

                'see if there is a matching collar deployment in the animal movements database
                Dim DeploymentDataTable As DataTable = GetDeploymentDataTableFromFrequencyAndDate(Frequency, SightingDate, 0.001, False)

                'take action depending on how many deployments were found
                'if only one deployment was found it implies the frequency matched one and only one collar deployment,
                'we're only interested in zero deployments or multiple deployments since these are things to fix
                If DeploymentDataTable.Rows.Count = 0 Then
                    'no frequency found for the frequency and date
                    Dim Problem As String = "No deployment in Animal Movement for this Frequency and Date"
                    With NewRow
                        .Item("Table") = SurveysDataTable.TableName
                        .Item("SightingDate") = SightingDate
                        .Item("GroupNumber") = GroupNumber
                        .Item("Frequency") = Frequency
                        '.Item("AM_Frequency") = AM_Frequency
                        '.Item("AnimalID") = AnimalID
                        .Item("PK") = EID
                        .Item("FlightID") = FlightID
                        .Item("Problem") = Problem
                    End With
                    ProblemsDataTable.Rows.Add(NewRow)
                ElseIf DeploymentDataTable.Rows.Count > 1 Then
                    'one frequency found for the frequency and date
                    'AnimalID = DeploymentDataTable.Rows(0).Item("AnimalID")
                    'AM_Frequency = DeploymentDataTable.Rows(0).Item("Frequency")
                    'Problem = "OK"
                    Dim problem As String = "Multiple deployments"
                    With NewRow
                        .Item("Table") = SurveysDataTable.TableName
                        .Item("SightingDate") = SightingDate
                        .Item("GroupNumber") = GroupNumber
                        .Item("Frequency") = Frequency
                        '.Item("AM_Frequency") = AM_Frequency
                        '.Item("AnimalID") = AnimalID
                        .Item("PK") = EID
                        .Item("FlightID") = FlightID
                        .Item("Problem") = problem
                    End With
                    ProblemsDataTable.Rows.Add(NewRow)
                End If
            Next
        Next











        'gather all frequency detections from the early radiotracking table
        Sql = "SELECT  Frequency, SightingDate, ERID FROM EarlyRadiotracking WHERE Frequency is not NULL and SightingDate is not NULL ORDER BY Frequency, SightingDate"
        Dim ERDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
        ERDataTable.TableName = "EarlyRadiotracking"

        'loop through all the frequencies in the groups
        For Each ERRow As DataRow In ERDataTable.Rows
            Dim SightingDate As String = ERRow.Item("SightingDate")
            'Dim GroupNumber As Integer = ERRow.Item("GroupNumber")
            Dim ERID As String = ERRow.Item("ERID")
            'Dim FlightID As String = ERRow.Item("FlightID")
            Dim Frequency As Double = ERRow.Item("Frequency")

            Dim NewRow As DataRow = ProblemsDataTable.NewRow

            'see if there is a matching collar deployment in the animal movements database
            Dim DeploymentDataTable As DataTable = GetDeploymentDataTableFromFrequencyAndDate(Frequency, SightingDate, 0.001, False)

            'take action depending on how many deployments were found
            'if only one deployment was found it implies the frequency matched one and only one collar deployment,
            'we're only interested in zero deployments or multiple deployments since these are things to fix
            If DeploymentDataTable.Rows.Count = 0 Then
                'no frequency found for the frequency and date
                Dim Problem As String = "No deployment in Animal Movement for this Frequency and Date"
                With NewRow
                    .Item("Table") = ERDataTable.TableName
                    .Item("SightingDate") = SightingDate
                    '.Item("GroupNumber") = GroupNumber
                    .Item("Frequency") = Frequency
                    '.Item("AM_Frequency") = AM_Frequency
                    '.Item("AnimalID") = AnimalID
                    .Item("PK") = ERID
                    '.Item("FlightID") = FlightID
                    .Item("Problem") = Problem
                End With
                ProblemsDataTable.Rows.Add(NewRow)
            ElseIf DeploymentDataTable.Rows.Count > 1 Then
                'one frequency found for the frequency and date
                'AnimalID = DeploymentDataTable.Rows(0).Item("AnimalID")
                'AM_Frequency = DeploymentDataTable.Rows(0).Item("Frequency")
                'Problem = "OK"
                Dim problem As String = "Multiple deployments"
                With NewRow
                    .Item("Table") = ERDataTable.TableName
                    .Item("SightingDate") = SightingDate
                    '.Item("GroupNumber") = GroupNumber
                    .Item("Frequency") = Frequency
                    '.Item("AM_Frequency") = AM_Frequency
                    '.Item("AnimalID") = AnimalID
                    .Item("PK") = ERID
                    '.Item("FlightID") = FlightID
                    .Item("Problem") = problem
                End With
                ProblemsDataTable.Rows.Add(NewRow)
            End If
        Next



        'sort the problems data table better
        Dim ProblemsDataView As New DataView(ProblemsDataTable, "", "Frequency,SightingDate,GroupNumber", DataViewRowState.CurrentRows)
        Return ProblemsDataView.ToTable
    End Function

    Private Sub RunToolStripButton_Click(sender As Object, e As EventArgs) Handles RunToolStripButton.Click
        Me.QCBindingSource.DataSource = Nothing

        Try
            Dim ProblemsDataTable As DataTable = GetProblemFrequencies()
            Me.QCBindingSource.DataSource = ProblemsDataTable
            Me.QCGridEX.DataSource = QCBindingSource
            Me.QCGridEX.RetrieveStructure()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub
End Class