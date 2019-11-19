Imports Janus.Windows.GridEX

Public Class CapturesForm

    Private Sub CapturesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            'load the captures table from database
            Me.CapturesTableAdapter.Fill(Me.WRST_CaribouDataSet.Captures)

            'standard gridex formatting
            FormatGridEX(Me.CapturesGridEX)

            'turn off group by box, add filtering
            With Me.CapturesGridEX
                .GroupByBoxVisible = False
                .FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
            End With

            'set up dropdowns
            SetUpCapturesGridEXDropDowns(Me.CapturesGridEX)

            'set captures grid default values
            SetCapturesGridEXDefaultValues()

            'load the animal movements frequencies into the captures grid
            ' LoadAnimalMovementFrequenciesIntoCapturesGrid()

            'set up filtering tools
            Me.CapturesGridEX.FilterMode = FilterMode.None

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub SaveCapturesData()
        Try
            If WRST_CaribouDataSet.HasChanges = True Then
                Me.Validate()
                Me.CapturesBindingSource.EndEdit()
                'Me.TableAdapterManager.UpdateAll(Me.WRST_CaribouDataSet)
                Dim CapturesDataTable As DataTable = WRST_CaribouDataSet.Tables("Captures")
                Me.CapturesTableAdapter.Update(CapturesDataTable)
                Debug.Print(Me.CapturesTableAdapter.Adapter.UpdateCommand.CommandText)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub


    Private Sub AskToSaveChanges()
        If WRST_CaribouDataSet.HasChanges = True Then
            If MsgBox("You have unsaved changes. Save to database?", MsgBoxStyle.YesNo, "Save changes?") = MsgBoxResult.Yes Then
                SaveCapturesData()
            End If
        End If
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        SaveCapturesData()
    End Sub

    Private Sub CapturesForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AskToSaveChanges()
    End Sub

    ''' <summary>
    ''' Sets default values for CapturesGridEX columns requiring them
    ''' </summary>
    Private Sub SetCapturesGridEXDefaultValues()
        Try
            'Set up default values
            Dim Grid As GridEX = Me.CapturesGridEX
            Grid.RootTable.Columns("CaptureID").DefaultValue = Guid.NewGuid.ToString
            Grid.RootTable.Columns("SOPNumber").DefaultValue = 0
            Grid.RootTable.Columns("RecordInsertedDate").DefaultValue = Now
            Grid.RootTable.Columns("RecordInsertedBy").DefaultValue = My.User.Name
            Grid.RootTable.Columns("CertificationLevel").DefaultValue = "Raw"

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
    ''' Loads GridEX's columns with dropdown options
    ''' </summary>
    ''' <param name="Grid"></param>
    Private Sub SetUpCapturesGridEXDropDowns(Grid As GridEX)
        Try
            'load AnimalIDs from Animal Movements:Animals table into the AnimalID drop downs
            Dim AnimalsDataTable As DataTable = GetAnimalsDataTable()
            Dim AnimalsDataView As DataView = AnimalsDataTable.DefaultView
            AnimalsDataView.Sort = "AnimalID"
            With Grid.RootTable.Columns("AnimalID")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = False
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
            End With
            Dim AnimalsList As GridEXValueListItemCollection = Grid.RootTable.Columns("AnimalID").ValueList
            For Each Row As DataRowView In AnimalsDataView
                Dim AnimalID As String = Row.Item("AnimalID")
                AnimalsList.Add(AnimalID, AnimalID)
            Next

            'add options to CapturesGridEXColumn dropdowns
            'body condition
            AddDropdownValues(Grid.RootTable.Columns("BodyCondition"), "Fat, Good, Poor, Emaciated", True)

            'AnestheticReversalRoute
            With Grid.RootTable.Columns("AnestheticReversalRoute")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = False
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
                ' Route of sedative reversal dose (IV, SC, IM.IV = Intravenous, SC = Subcutaneous, IM = Intramuscular)
                .ValueList.Add("IV", "Intravenous")
                .ValueList.Add("SC", "Subcutaneous")
                .ValueList.Add("IM", "Intramuscular")
            End With

            'AnestheticReversalRoute
            With Grid.RootTable.Columns("AnestheticReversalRoute")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = False
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
                .ValueList.Add("IV", "Intravenous")
                .ValueList.Add("SC", "Subcutaneous")
                .ValueList.Add("IM", "Intramuscular")
            End With

            'SedativeReversalRoute
            With Grid.RootTable.Columns("SedativeReversalRoute")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = False
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
                .ValueList.Add("IV", "Intravenous")
                .ValueList.Add("SC", "Subcutaneous")
                .ValueList.Add("IM", "Intramuscular")
            End With

            'DrugEffect
            With Grid.RootTable.Columns("DrugEffect")
                .EditType = EditType.Combo
                .HasValueList = True
                .LimitToList = False
                .AllowSort = True
                .AutoComplete = True
                .ValueList.Clear()
                .ValueList.Add("1", "1-Light")
                .ValueList.Add("2", "2-Light-medium")
                .ValueList.Add("3", "3-Medium")
                .ValueList.Add("4", "4-Medium-heavy")
                .ValueList.Add("5", "5-Heavy")
            End With

            'Set up dropdowns to regurgitate previous data entry options
            Dim CapturesDataTable As DataTable = Me.WRST_CaribouDataSet.Tables("Captures")
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "AdditionalDrugs", "AdditionalDrugs", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "AircraftType", "AircraftType", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "Anesthetic", "Anesthetic", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "AnestheticReversal", "AnestheticReversal", False)
            'LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "AnestheticReversalRoute", "AnestheticReversalRoute", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "CaptureDate", "CaptureDate", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "Comments", "Comments", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "Crew", "Crew", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "DartLocation", "DartLocation", False)
            'LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "DrugEffect", "DrugEffect", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "GeneralLocation", "GeneralLocation", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "Handler", "Handler", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "Park", "Park", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "Pilot", "Pilot", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "ProjectID", "ProjectID", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "ProtocolIRMAReference", "ProtocolIRMAReference", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "ProtocolVersion", "ProtocolVersion", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "Sedative", "Sedative", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "SedativeReversal", "SedativeReversal", False)
            'LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "SedativeReversalRoute", "SedativeReversalRoute", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "Sex", "Sex", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "Shooter", "Shooter", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "SOPNumber", "SOPNumber", False)
            LoadGridEXDropDownWithDistinctDataTableValues(Grid, CapturesDataTable, "SOPVersion", "SOPVersion", False)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub


    ''' <summary>
    ''' Adds Options to the GridEXColumn's dropdown items
    ''' </summary>
    ''' <param name="GridEXColumn">GridEX column to which the options should be added</param>
    ''' <param name="Options">Comma separated list of Strings. String.</param>
    ''' <param name="LimitToList">Limit the column to Options. Boolean.</param>
    Private Sub AddDropdownValues(GridEXColumn As GridEXColumn, Options As String, LimitToList As Boolean)
        Try
            If Not GridEXColumn Is Nothing Then
                With GridEXColumn
                    .EditType = EditType.Combo
                    .HasValueList = True
                    .LimitToList = LimitToList
                    .AllowSort = True
                    .AutoComplete = True
                    .ValueList.Clear()
                    Dim MyList() As String = Options.Split(",")
                    For Each Item As String In MyList
                        .ValueList.Add(Item.Trim, Item.Trim)
                    Next
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    'Private Sub ViewToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ViewToolStripComboBox.SelectedIndexChanged
    '    ToggleView()
    'End Sub

    'Private Sub ToggleView()
    '    If Me.ViewToolStripComboBox.Text = "Table" Then
    '        Me.CapturesGridEX.View = View.TableView
    '    Else
    '        Me.CapturesGridEX.View = View.SingleCard
    '        Me.ViewToolStripComboBox.Text = "Card"
    '    End If
    'End Sub



    '  Private Sub ImportFromFileToolStripButton_Click(sender As Object, e As EventArgs) Handles ImportFromFileToolStripButton.Click
    '      MsgBox("This import tool has not been working well. It's choking on the Sql Server time formats. Recommend a different import method for now.")
    '      Exit Sub
    '      Dim DataLossMessage As String = "Update this message"

    '      'get the structure of the destination datatable, we only need one record since the translator will clear all records anyway
    '      Dim Sql As String = "SELECT TOP (1) [AnimalID]
    '    ,[CaptureDate]
    '    ,[Crew]
    '    ,[Shooter]
    '    ,[Frequency]
    '    ,[VisualCollar]
    '    ,[SerialNumber]
    '    ,[CaptureLatitude]
    '    ,[CaptureLongitude]
    '    ,[OldFrequency]
    '    ,[OldVisualCollar]
    '    ,[GeneralLocation]
    '    ,[TimeStartChase]
    '    ,[TimeFirstHitBounce]
    '    ,[TimeSecordHitBounce]
    '    ,[TimeThirdHitBounce]
    '    ,[TimeVisibleEffect]
    '    ,[TimeAnimalDown]
    '    ,[DartLocation]
    '    ,[Anesthetic]
    '    ,[AnestheticDosage_mg]
    '    ,[AnestheticConcentration_mg_ml]
    '    ,[Sedative]
    '    ,[SedativeDosage_mg]
    '    ,[SedativeConcentration_mg_ml]
    '    ,[NumHits]
    '    ,[NumMisses]
    '    ,[DrugEffect]
    '    ,[InitialBodyTemp]
    '    ,[InitialBodyTempTime]
    '    ,[FinalBodyTemperature]
    '    ,[FinalBodyTemperatureTime]
    '    ,[AdditionalDrugs]
    '    ,[Sex]
    '    ,[EstimatedAge]
    '    ,[WithCalf]
    '    ,[Lactating]
    '    ,[BodyCondition]
    '    ,[Weight_Kg]
    '    ,[BodyLength]
    '    ,[NeckCircumference]
    '    ,[Jaw]
    '    ,[MetatarsusLength]
    '    ,[HindfootLength]
    '    ,[ChestGirth]
    '    ,[BloodSampleRed]
    '    ,[BloodSamplePurple]
    '    ,[BloodSampleGreen]
    '    ,[AnestheticReversal]
    '    ,[AnestheticReversalDosage_mg]
    '    ,[AnestheticReversalConcentration_mg_ml]
    '    ,[AnestheticReversalRoute]
    '    ,[AnestheticReversalTime]
    '    ,[SedativeReversal]
    '    ,[SedativeReversalDosage_mg]
    '    ,[SedativeReversalConcentration_mg_ml]
    '    ,[SedativeReversalRoute]
    '    ,[SedativeReversalTime]
    '    ,[TimeStanding]
    '    ,[TimeMobile]
    '    ,[Comments]
    '    ,[CaptureID]
    '    ,[RecordInsertedDate]
    '    ,[RecordInsertedBy]
    '    ,[ProjectID]
    '    ,[AnestheticDosage_ml]
    '    ,[SedativeDosage_ml]
    '    ,[AnestheticReversalDosage_ml]
    '    ,[SedativeReversalDosage_ml]
    '    ,[ProtocolVersion]
    '    ,[SOPNumber]
    '    ,[SOPVersion]
    '    ,[CertificationDate]
    '    ,[CertifiedBy]
    '    ,[ProtocolIRMAReference]
    '    ,[CertificationLevel]
    'FROM [WRST_Caribou].[dbo].[Captures]"

    '      'use the structure of the query above to build a skeleton datatable
    '      Dim DestinationDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)

    '      'import the data from the selected file
    '      If Not DestinationDataTable Is Nothing Then
    '          'get the data fileinfo to import
    '          Dim SourceFileInfo As New FileInfo(GetFile("Select a data file to open. If Excel workbook the data to be imported must be in the first worksheet (tab).", "Survey data file (.csv;.xls;.xlsx)|*.csv;*.xls;*.xlsx|Comma separated values (.csv)|*.csv|Excel worksheet (.xlsx)|*.xlsx|Excel worksheet (.xls)|*.xls"))

    '          'convert the file into a datatable so we can work with it
    '          Dim InputDataTable As DataTable = Nothing

    '          'determine if the input file is csv or excel
    '          If SourceFileInfo.Extension = ".csv" Then
    '              'convert the data file into a datatable
    '              InputDataTable = GetDataTableFromDelimitedTextFile(SourceFileInfo, ",")
    '          ElseIf SourceFileInfo.Extension = ".xlsx" Then
    '              'MsgBox(DataLossMessage, MsgBoxStyle.Information, "Important note on Excel spreadsheets")
    '              'Me.HelpProvider.SetHelpKeyword(Me, "Import")
    '              'convert the excel sheet into a datatable

    '              'IMEX=1 means all data will be treated as text. we had problems with group frequencies column being treated as numeric so it omitted any cells with commas separating frequencies
    '              'the Excel General data type confused .NET as to what kind of data to expect.
    '              'see https://www.connectionstrings.com/excel/
    '              Dim ExcelConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & SourceFileInfo.FullName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"
    '              Dim ExcelDataset As DataSet = GetDatasetFromExcelWorkbook(ExcelConnectionString)
    '              InputDataTable = ExcelDataset.Tables(0) 'can only grab the first worksheet (tab)
    '          ElseIf SourceFileInfo.Extension = ".xls" Then
    '              MsgBox(DataLossMessage, MsgBoxStyle.Information, "Important note on Excel spreadsheets")

    '              'convert the excel sheet into a datatable
    '              Dim ExcelConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & SourceFileInfo.FullName & ";Extended Properties=""Excel 8.0;HDR=YES;IMEX=1"";"
    '              Dim ExcelDataset As DataSet = GetDatasetFromExcelWorkbook(ExcelConnectionString)
    '              InputDataTable = ExcelDataset.Tables(0) 'first worksheet
    '          End If

    '          'make a list of desired default values to pass into the data tables translator form
    '          'these items will show up in the mappings datagridview's default values column to make things a little easier
    '          Dim DefaultValuesList As New List(Of String)
    '          With DefaultValuesList
    '              'add the search areas from my.settings to the default values
    '              For Each Item In My.Settings.SearchAreas.Split(",")
    '                  .Add(Item)
    '              Next
    '              '.Add("TRUE")
    '              '.Add("FALSE")

    '              'common default values
    '              '.Add(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "FlightID")) 'the primary key of the currently selected flight
    '              '.Add(GetCurrentGridEXCellValue(Me.SurveyFlightsGridEX, "Herd")) 'the currently selected herd in the campaigns table
    '              .Add(SourceFileInfo.Name) 'the import file name
    '          End With

    '          'open up a datatable translator form to allow the user to map fields from the csv file to the destination datatable
    '          Dim TranslatorForm As New SkeeterDataTablesTranslatorForm(InputDataTable, DestinationDataTable, "Import data", "Use the tool on the left to map the fields from your source data table to the destination data table.", DefaultValuesList)
    '          TranslatorForm.ShowDialog()

    '          'at this point we have transformed the csv into a clone of the destination datatable
    '          Dim ImportDataTable As DataTable = TranslatorForm.DestinationDataTable

    '          'the next step is to get the transformed data into the Surveys GridEX DataTable
    '          'loop through the waypoints datatable and try to insert them into the datatable
    '          Dim TableName As String = SourceFileInfo.Name
    '          For Each Row As DataRow In ImportDataTable.Rows

    '              'make a new row
    '              Dim NewRow As DataRow = Me.WRST_CaribouDataSet.Tables("Captures").NewRow
    '              For Each Column As DataColumn In ImportDataTable.Columns
    '                  NewRow.Item(Column.ColumnName) = Row.Item(Column.ColumnName)
    '              Next

    '              'override any selections made on the translator form
    '              'NewRow.Item("FlightID") = FlightID
    '              NewRow.Item("RecordInsertedDate") = Now
    '              NewRow.Item("RecordInsertedBy") = My.User.Name
    '              NewRow.Item("CaptureID") = Guid.NewGuid.ToString

    '              'add the row
    '              Me.WRST_CaribouDataSet.Tables("Captures").Rows.Add(NewRow)

    '              'end the edit
    '              Me.CapturesBindingSource.EndEdit()
    '          Next
    '      End If
    '  End Sub

    Private Sub LoadAnimalMovementFrequenciesIntoCapturesGrid()
        'i can propbably make this more efficient by pulling all the am frequencies into a table and querying that rather
        'than issuing a query per row loop
        Try
            'captures grid
            Dim Grid As GridEX = Me.CapturesGridEX

            'loop through the rows in the captures grid
            For Each Row As GridEXRow In Me.CapturesGridEX.GetRows

                If Not Row Is Nothing Then

                    'get the values of various cells in Row
                    Dim AnimalID As String = GetGridEXCellValue(Row, "AnimalID")

                    ' Dim FrequencyString As String = GetGridEXCellValue(Row, "Frequency")
                    'Dim Frequency As Double = 0
                    'If IsNumeric(FrequencyString) = True Then Frequency = CDbl(FrequencyString)

                    'capturedate
                    Dim CaptureDateString As String = GetGridEXCellValue(Row, "CaptureDate")
                    Dim CaptureDate As Date
                    If IsDate(CaptureDateString) = True Then

                        'get the caribou capture date
                        CaptureDate = CDate(CaptureDateString)

                        'now query animal movement to get the frequency of the collar deployed on the caribou on the date it was captured
                        Dim Sql As String = "SELECT CollarDeployments.AnimalId, CollarDeployments.DeploymentDate, CollarDeployments.RetrievalDate, CollarDeployments.DeploymentId, Collars.Frequency
FROM CollarDeployments INNER JOIN Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId
WHERE (CollarDeployments.AnimalId = '" & AnimalID & "') AND ('" & CaptureDate & "' = Convert(Date,CollarDeployments.DeploymentDate))"

                        'get the above query into a data table
                        Dim FreqDataTable As DataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
                        'Debug.Print(vbNewLine & AnimalID & vbTab & CaptureDate.ToString & vbTab & Frequency & vbTab & FreqDataTable.Rows.Count)
                        'Debug.Print(Sql)

                        'we should have at most one frequency for an animal on its capture date
                        If FreqDataTable.Rows.Count = 1 Then

                            'get the frequency from animal movement
                            Dim AM_Frequency As Double = CDbl(FreqDataTable.Rows(0).Item("Frequency"))

                            'load the animalmovement frequency cell with the value
                            Me.CapturesGridEX.CurrentRow.Cells("AnimalMovementFrequency").Value = AM_Frequency

                        End If
                        'End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Returns the string value of Row's ColumnName's cell value
    ''' </summary>
    ''' <param name="Row">Row to interrogate. GridEXRow.</param>
    ''' <param name="ColumnName">Name of the cell to interrogate. String</param>
    ''' <returns></returns>
    Private Function GetGridEXCellValue(Row As GridEXRow, ColumnName As String) As String
        Dim CellValue As String = ""
        Try
            If Not Row Is Nothing Then
                If Not Row.Cells(ColumnName) Is Nothing Then
                    If Not IsDBNull(Row.Cells(ColumnName).Value) = True Then
                        CellValue = Row.Cells(ColumnName).Value
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return CellValue
    End Function

    Private Sub CapturesGridEX_EditingCell(sender As Object, e As EditingCellEventArgs) Handles CapturesGridEX.EditingCell
        ' this works but isn't ready for prime time and using FrequenciesCheck might be a better way. disabled for now
        'load data into a column
        '        Dim AnimalID As String = GetCurrentGridEXCellValue(Me.CapturesGridEX, "AnimalID")
        '        Dim CaptureDate As String = GetCurrentGridEXCellValue(Me.CapturesGridEX, "CaptureDate")
        '        Dim CurrentFrequency As String = ""
        '        If Not IsDBNull(GetCurrentGridEXCellValue(Me.CapturesGridEX, "Frequency")) Then
        '            If Not IsDBNull(AnimalID) And Not IsDBNull(CaptureDate) Then
        '                CurrentFrequency = GetCurrentGridEXCellValue(Me.CapturesGridEX, "Frequency")
        '            End If

        '            If IsDate(CaptureDate) Then
        '                Dim Sql As String = "SELECT        CollarDeployments.AnimalId, CollarDeployments.DeploymentDate, CollarDeployments.RetrievalDate, CollarDeployments.DeploymentId, Collars.Frequency
        'FROM CollarDeployments INNER JOIN Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId
        'WHERE (CollarDeployments.AnimalId = '" & AnimalID & "') AND ('" & CaptureDate & "' = Convert(Date,CollarDeployments.DeploymentDate))"

        '                Dim FreqDataTable As DataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
        '                'Debug.Print(vbNewLine & AnimalID & vbTab & CaptureDate.ToString & vbTab & FreqDataTable.Rows.Count)
        '                'Debug.Print(Sql)
        '                If FreqDataTable.Rows.Count = 1 Then
        '                    Dim AM_Frequency As Double = FreqDataTable.Rows(0).Item("Frequency")
        '                    If CurrentFrequency <> "" And AM_Frequency > 0 Then
        '                        If AM_Frequency <> CurrentFrequency Then
        '                            If MsgBox("A different frequency exists for this AnimalID for " & CaptureDate & ". Replace " & CurrentFrequency & " with " & AM_Frequency & "? ", MsgBoxStyle.YesNo, "Frequency found") = MsgBoxResult.Yes Then
        '                                Me.CapturesGridEX.CurrentRow.Cells("Frequency").Value = AM_Frequency
        '                            End If
        '                        End If
        '                        If MsgBox("The frequency for this AnimalID and Capture Date as queried from Animal Movement is " & AM_Frequency & ". Auto-populate the Frequency cell with this value? ", MsgBoxStyle.YesNo, "Frequency found") = MsgBoxResult.Yes Then
        '                            Me.CapturesGridEX.CurrentRow.Cells("Frequency").Value = AM_Frequency
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        End If



        'Dim ColumnName As String = "Frequency"
        'Dim Grid As GridEX = Me.CapturesGridEX

        'Dim AnimalsDataTable As DataTable = GetAnimalsDataTable()
        'Dim AnimalsDataView As DataView = AnimalsDataTable.DefaultView
        'AnimalsDataView.Sort = ColumnName
        'With Grid.RootTable.Columns(ColumnName)
        '    .EditType = EditType.Combo
        '    .HasValueList = True
        '    .LimitToList = False
        '    .AllowSort = True
        '    .AutoComplete = True
        '    .ValueList.Clear()
        'End With
        'Dim AnimalsList As GridEXValueListItemCollection = Grid.RootTable.Columns(ColumnName).ValueList
        'For Each Row As DataRowView In AnimalsDataView
        '    Dim AnimalID As String = Row.Item(ColumnName)
        '    AnimalsList.Add(AnimalID, AnimalID)
        'Next
        'Me.CapturesGridEX.RootTable.Columns("Frequency")
    End Sub

    Private Sub AllowFilteringToolStripButton_Click(sender As Object, e As EventArgs) Handles AllowFilteringToolStripButton.Click
        ToggleFilteringTools()
    End Sub

    ''' <summary>
    ''' Allows user to turn the CapturesGridEX's filtering tools on or off.
    ''' </summary>
    Private Sub ToggleFilteringTools()
        If Me.AllowFilteringToolStripButton.Text = "Hide filtering tools" Then
            Me.CapturesGridEX.FilterMode = FilterMode.None
            Me.AllowFilteringToolStripButton.Text = "Show filtering tools"
        Else
            Me.CapturesGridEX.FilterMode = FilterMode.Automatic
            Me.AllowFilteringToolStripButton.Text = "Hide filtering tools"
        End If
    End Sub

    Private Sub CapturesGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles CapturesGridEX.SelectionChanged
        SetUpCapturesGridEXDropDowns(Me.CapturesGridEX)
        SetCapturesGridEXDefaultValues()
    End Sub



    'Private Sub CheckFrequenciesToolStripButton_Click(sender As Object, e As EventArgs) Handles CheckFrequenciesToolStripButton.Click
    '    LoadAnimalMovementFrequenciesIntoCapturesGrid()
    'End Sub
End Class