Public Class FrequenciesNotFoundInAnimalMovementForm
    Private SurveysDataTableValue As DataTable
    Public Property SurveysDataTable() As DataTable
        Get
            Return SurveysDataTableValue
        End Get
        Set(ByVal value As DataTable)
            SurveysDataTableValue = value
        End Set
    End Property

    Public Sub New(SurveysDataTable As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SurveysDataTable = SurveysDataTable
    End Sub

    Public Function QC_GetUnmatchedCaribouInGroups() As DataTable
        Dim FrequenciesDataTable As New DataTable

        Try
            ' Create four typed columns in the DataTable.
            With FrequenciesDataTable
                .Columns.Add("SightingDate", GetType(DateTime))
                .Columns.Add("GroupNumber", GetType(String))
                .Columns.Add("Frequency", GetType(Double))
                .Columns.Add("AM_Frequency", GetType(Double))
                .Columns.Add("AnimalID", GetType(String))
                .Columns.Add("Problem", GetType(String))
                .Columns.Add("EID", GetType(String))
                .Columns.Add("FlightID", GetType(String))
                .PrimaryKey = New DataColumn() { .Columns("FlightID"), .Columns("Frequency")}
            End With

            Dim i As Integer = 1
            'now loop through each survey record and regenerate the matches of frequency and date to animal deployments
            For Each SurveyRow As DataRow In Me.SurveysDataTable.Rows

                Dim SightingDate As String = SurveyRow.Item("SightingDate")
                Dim GroupNumber As Integer = SurveyRow.Item("GroupNumber")
                Dim EID As String = SurveyRow.Item("EID")
                Dim FlightID As String = SurveyRow.Item("FlightID")
                Dim FrequenciesInGroup As String = ""

                If IsDBNull(SurveyRow.Item("FrequenciesInGroup")) = False And SurveyRow.Item("FrequenciesInGroup").ToString.Trim <> "" Then
                    FrequenciesInGroup = SurveyRow.Item("FrequenciesInGroup").ToString.Trim
                End If

                If Not FrequenciesInGroup.Trim = "" Then
                    'parse the comma separated frequencies so we can deal with them individually
                    Dim FrequenciesList As List(Of Double) = GetListOfCSVFrequencies(FrequenciesInGroup)

                    For Each Frequency In FrequenciesList ' FrequenciesInGroup.Split(",")
                        Dim NewRow As DataRow = FrequenciesDataTable.NewRow

                        'get info from animal movement
                        Dim DeploymentDataTable As DataTable = GetDeploymentDataTableFromFrequencyAndDate(Frequency, SightingDate, 0.001)
                        Dim AnimalID As String = ""
                        Dim AM_Frequency As String = -999
                        Dim Problem As String = ""

                        If DeploymentDataTable.Rows.Count = 0 Then
                            AnimalID = ""
                            AM_Frequency = -999
                            Problem = "No deployment in Animal Movement for this Frequency and Date"
                        ElseIf DeploymentDataTable.Rows.Count = 1 Then
                            AnimalID = DeploymentDataTable.Rows(0).Item("AnimalID")
                            AM_Frequency = DeploymentDataTable.Rows(0).Item("Frequency")
                            Problem = "OK"
                        Else
                            Problem = "Multiple deployments"
                        End If

                        With NewRow
                            .Item("SightingDate") = SightingDate
                            .Item("GroupNumber") = GroupNumber
                            .Item("Frequency") = Frequency
                            .Item("AM_Frequency") = AM_Frequency
                            .Item("AnimalID") = AnimalID
                            .Item("EID") = EID
                            .Item("FlightID") = FlightID
                            .Item("Problem") = Problem
                        End With
                        Try
                            FrequenciesDataTable.Rows.Add(NewRow)
                        Catch ex2 As System.Data.ConstraintException
                            Me.OutputTextBox.AppendText(SightingDate & "," & GroupNumber & "," & Frequency & "," & ex2.Message & vbNewLine)
                        End Try



                        i = i + 1
                    Next
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try

        'sort
        Dim DV As New DataView(FrequenciesDataTable, "", "SightingDate,GroupNumber,Frequency", DataViewRowState.CurrentRows)
        Return DV.ToTable

    End Function

    Private Sub QC_DuplicateFrequenciesInGroupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.OutputTextBox.Text = "Looking for survey frequencies that are not in Animal Movement..." & vbNewLine
        Dim FrequenciesMatchingDataTable As DataTable = QC_GetUnmatchedCaribouInGroups()
        With Me.DuplicatesGridEX
            .DataSource = FrequenciesMatchingDataTable
            .RetrieveStructure()
            .AlternatingColors = True
            .RecordNavigator = True
            .RootTable.Columns(0).AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Count
            .GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed
            .GroupTotals = Janus.Windows.GridEX.GroupTotals.ExpandedGroup
        End With
        Me.OutputTextBox.AppendText("Found " & FrequenciesMatchingDataTable.Rows.Count & " survey frequencies" & vbNewLine)
        Dim DV As New DataView(FrequenciesMatchingDataTable, "Problem <> 'OK'", "Frequency,SightingDate", DataViewRowState.CurrentRows)
        Dim ProblemsDataTable As DataTable = DV.ToTable
        Me.OutputTextBox.AppendText("Found " & ProblemsDataTable.Rows.Count & " frequencies not available in Animal Movement" & vbNewLine)
        Me.OutputTextBox.AppendText(vbNewLine)
        Me.OutputTextBox.AppendText("Frequency,SightingDate,GroupNumber,Problem" & vbNewLine)
        For Each DVRow As DataRow In ProblemsDataTable.Rows
            Me.OutputTextBox.AppendText(DVRow.Item("Frequency") & "," & DVRow.Item("SightingDate") & "," & DVRow.Item("GroupNumber") & "," & DVRow.Item("Problem") & vbNewLine)
        Next
        Me.OutputTextBox.AppendText(vbNewLine)
    End Sub

    Private Sub ExportResultsToolStripButton_Click(sender As Object, e As EventArgs) Handles ExportResultsToolStripButton.Click
        ExportProblemRecords()
    End Sub

    Private Sub ExportProblemRecords()
        Try
            Dim ResultsDataTable As DataTable = Me.DuplicatesGridEX.DataSource
            Dim ResultsDV As New DataView(ResultsDataTable, "Problem <> 'OK'", "Frequency", DataViewRowState.CurrentRows)
        Dim Results As String = DataTableToCSV(ResultsDV.ToTable, "|")
            Dim SFD As New SaveFileDialog
            With SFD
                .AddExtension = True
                .InitialDirectory = "C:\"
                .OverwritePrompt = True
                .Title = "Save results"
                .Filter = "Pipe separated values (.txt)|*.txt"
                If .ShowDialog = DialogResult.OK Then
                    My.Computer.FileSystem.WriteAllText(SFD.FileName, Results, False)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub
End Class