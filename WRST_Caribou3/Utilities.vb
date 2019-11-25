Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
'Imports Janus.Data
Imports Janus.Windows.GridEX

Module Utilites
    ''' <summary>
    ''' Returns the list of SearchAreas in My.Settings.SearchAreas as a DataTable
    ''' </summary>
    ''' <returns>DataTable of search areas</returns>
    Public Function GetSearchAreasDataTable() As DataTable
        ' Create new DataTable instance.
        Dim MyDataTable As New DataTable("SearchAreas")

        ' Create four typed columns in the DataTable.
        With MyDataTable
            .Columns.Add("SearchArea", GetType(String))
        End With

        Try
            ' Split string based on spaces and add them as rows to the datatable
            Dim SearchAreas As String() = My.Settings.SearchAreas.Split(",")
            For Each SearchArea In SearchAreas
                MyDataTable.Rows.Add(SearchArea)
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return MyDataTable
    End Function

    ''' <summary>
    ''' Converts a tab delimited text file to a DataTable
    ''' </summary>
    ''' <param name="DelimitedTextFileInfo">Tab delimited text file. FileInfo.</param>
    ''' <returns>DataTable</returns>
    Public Function GetDataTableFromDelimitedTextFile(DelimitedTextFileInfo As FileInfo, Delimiter As String) As DataTable
        Dim TDVDataTable As New DataTable(DelimitedTextFileInfo.Name)
        Try
            Dim MyTextFileParser As New FileIO.TextFieldParser(DelimitedTextFileInfo.FullName)
            MyTextFileParser.Delimiters = New String() {Delimiter}
            TDVDataTable.Columns.AddRange(Array.ConvertAll(MyTextFileParser.ReadFields, Function(s) New DataColumn With {.Caption = s, .ColumnName = s}))
            Do While Not MyTextFileParser.EndOfData
                TDVDataTable.Rows.Add(MyTextFileParser.ReadFields)
            Loop
            MyTextFileParser.Close()
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return TDVDataTable
    End Function


    ''' <summary>
    ''' Converts a DataTable to a string of delimited values such as CSV
    ''' </summary>
    ''' <param name="DataTable">DataTable to convert. DataTable</param>
    ''' <param name="Delimiter">Values separator</param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Function DataTableToCSV(DataTable As DataTable, Delimiter As String) As String
        Dim CSV As String = ""
        Try
            'output the headers
            For Each Column As DataColumn In DataTable.Columns
                CSV = CSV & Column.ColumnName & Delimiter
            Next
            CSV = CSV.Substring(0, CSV.Trim.Length - 1) & vbNewLine

            'output the rows
            For Each Row As DataRow In DataTable.Rows
                For Each Column As DataColumn In DataTable.Columns
                    CSV = CSV & Row.Item(Column.ColumnName) & Delimiter
                Next
                CSV = CSV.Substring(0, CSV.Trim.Length - 1) & vbNewLine
            Next
        Catch ex As Exception
            MsgBox(ex.Message & "  " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return CSV
    End Function

    Public Sub ExportDataTable(DataTable As DataTable)
        'not working, freezes the app
        Try
            Dim SFD As New SaveFileDialog()
            With SFD
                .ShowHelp = True
                .Filter = "CSV file (Comma separated values text file)|*.csv"
                .OverwritePrompt = True
                .Title = "Export"
            End With
            If SFD.ShowDialog = DialogResult.OK Then
                My.Computer.FileSystem.WriteAllText(SFD.FileName, DataTableToCSV(DataTable, ","), False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

    End Sub


    ''' <summary>
    ''' Runs the query in Sql against a database using ConnectionString and returns the results as a DataTable
    ''' </summary>
    ''' <param name="ConnectionString"></param>
    ''' <param name="Sql"></param>
    ''' <returns>DataTable</returns>
    Public Function GetDataTable(ConnectionString As String, Sql As String) As DataTable

        'the DataTable to return
        Dim MyDataTable As New DataTable
        Try
            'make a SqlConnection using the supplied ConnectionString 
            Dim MySqlConnection As New SqlConnection(ConnectionString)
            Using MySqlConnection
                'make a query using the supplied Sql
                Dim MySqlCommand As SqlCommand = New SqlCommand(Sql, MySqlConnection)

                'open the connection
                MySqlConnection.Open()

                'create a DataReader and execute the SqlCommand
                Dim MyDataReader As SqlDataReader = MySqlCommand.ExecuteReader()

                'load the reader into the datatable
                MyDataTable.Load(MyDataReader)

                'clean up
                MyDataReader.Close()
                MySqlConnection.Close()
            End Using
        Catch ex As Exception
            MsgBox("Error: Query on " & ConnectionString & " failed. " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try

        'return the datatable
        Return MyDataTable
    End Function

#Region "Excel"

    ''' <summary>
    ''' Converts an Excel workbook into a DataSet. All worksheets become available as DataTables
    ''' </summary>
    ''' <param name="ExcelConnectionString">ExcelConnectionString</param>
    ''' <returns>Dataset</returns>
    Public Function GetDatasetFromExcelWorkbook(ExcelConnectionString As String) As DataSet
        Dim ExcelDataset As New DataSet()
        Try
            'Dim  = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ExcelFileInfo.FullName & ";Extended Properties='Excel 12.0 Xml;HDR=YES';"
            Dim WorksheetsDataTable As DataTable = GetExcelWorksheets(ExcelConnectionString)
            For Each WorksheetRow As DataRow In WorksheetsDataTable.Rows
                Dim WorksheetName As String = WorksheetRow.Item("TABLE_NAME")
                Dim ExcelDataTable As New DataTable(WorksheetName)
                ExcelDataTable.TableName = WorksheetName
                Dim Sql As String = "SELECT * FROM [" & WorksheetName & "]"
                Dim MyConnection As New OleDbConnection(ExcelConnectionString)
                MyConnection.Open()
                Dim MyCommand As New OleDbCommand(Sql, MyConnection)
                Dim MyDataAdapter As New OleDbDataAdapter(MyCommand)
                MyDataAdapter.Fill(ExcelDataTable)
                ExcelDataset.Tables.Add(ExcelDataTable)
                MyConnection.Close()
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return ExcelDataset
    End Function

    ''' <summary>
    ''' Returns a DataTable of worksheets in the submitted Excel workbook
    ''' </summary>
    ''' <param name="ExcelConnectionString"></param>
    ''' <returns>DataTable</returns>
    Public Function GetExcelWorksheets(ExcelConnectionString As String) As DataTable
        Dim ExcelWorksheetsDataTable As New DataTable
        Try
            Dim MyConnection As New OleDbConnection(ExcelConnectionString)
            MyConnection.Open()
            ExcelWorksheetsDataTable = MyConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            MyConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return ExcelWorksheetsDataTable
    End Function
#End Region


    ''' <summary>
    ''' Returns the path to a file.
    ''' </summary>
    ''' <param name="Title">Title.</param>
    ''' <param name="Filter">File filter. See documentation for OpenFileDialog.</param>
    ''' <returns>String. Path to the selected file.</returns>
    Public Function GetFile(Title As String, Filter As String) As String
        'allow user to open an openfiledialog to select a csv file
        Dim File As String = ""
        Try
            Dim OFD As New OpenFileDialog
            With OFD
                .ShowHelp = True
                .AddExtension = True
                .CheckFileExists = True
                .Filter = Filter
                .Multiselect = False
                .Title = Title
            End With

            'show the ofd and get the filename and path
            If OFD.ShowDialog = DialogResult.OK Then
                File = OFD.FileName
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return File
    End Function

    ''' <summary>
    ''' Returns a DataTable of the WRST caribou collar deployments from the Animal_Movement database
    ''' </summary>
    ''' <returns>DataTable</returns>
    Public Function GetCollarDeploymentsDataTable() As DataTable
        Dim CollarDeploymentsDataTable As New DataTable
        Try
            Dim Sql As String = "SELECT CONVERT(Varchar(20), Collars.Frequency) + ' - ' + Animals.AnimalId + ' Deployed: ' + CONVERT(varchar(20),DeploymentDate)  +  ISNULL(' Collar retrieved: ' + CONVERT(varchar(20), RetrievalDate),'') +  ISNULL(' DEAD: ' + CONVERT(varchar(20), MortalityDate),'') AS CollaredCaribou
,Animals.AnimalId,   Collars.Frequency,CollarDeployments.DeploymentDate, CollarDeployments.RetrievalDate, 
                         Animals.MortalityDate, Collars.DisposalDate, Collars.HasGps, CollarDeployments.CollarManufacturer, Collars.CollarModel, Collars.SerialNumber, Animals.Species, Animals.Gender, Animals.GroupName, 
                         Animals.Description, Collars.Manager, Collars.Owner, Collars.Notes AS CollarNotes,       CONVERT(Varchar(20), Collars.Frequency) + ' - ' + Animals.AnimalId AS CollaredCaribou, CollarDeployments.CollarId, Animals.ProjectId, CollarDeployments.DeploymentId
FROM            Animals INNER JOIN
                         CollarDeployments ON Animals.ProjectId = CollarDeployments.ProjectId AND Animals.AnimalId = CollarDeployments.AnimalId INNER JOIN
                         Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId
WHERE        (Animals.ProjectId = 'WRST_Caribou')
ORDER BY Frequency"

            CollarDeploymentsDataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
            CollarDeploymentsDataTable.TableName = "CollarDeployments"
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return CollarDeploymentsDataTable
    End Function

    ''' <summary>
    ''' Returns a DataTable of the WRST caribou collar deployments from the Animal_Movement database
    ''' </summary>
    ''' <returns>DataTable</returns>
    Public Function GetCurrentCollarDeploymentsDataTable(AsOfDate As Date) As DataTable
        Dim DT As New DataTable
        Try
            Dim Sql As String = "SELECT Collars.Frequency, CollarDeployments.AnimalId, CollarDeployments.DeploymentDate,CollarDeployments.RetrievalDate,iif(Animals.MortalityDate is NULL,'Alive','Dead') as Status , Animals.MortalityDate, CollarDeployments.CollarId
        FROM            CollarDeployments INNER JOIN
                                 Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId INNER JOIN
                                 Animals ON CollarDeployments.ProjectId = Animals.ProjectId AND CollarDeployments.AnimalId = Animals.AnimalId
        WHERE        (CollarDeployments.ProjectId = 'WRST_Caribou') AND 
		((DeploymentDate < '" & AsOfDate & "') AND (RetrievalDate IS NULL)) OR
		( (DeploymentDate < '" & AsOfDate & "') AND (RetrievalDate > '" & AsOfDate & "'))
        ORDER BY Frequency,DeploymentDate "
            DT = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
            DT.TableName = "CurrentCollarDeployments"
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return DT
    End Function


    ''' <summary>
    ''' Returns the AnimalID associated with a GPS collar frequency at a certain date. Data from Animal_Movement database.
    ''' </summary>
    ''' <param name="Frequency">GPS collar frequency</param>
    ''' <param name="ObservationDate">Date of observation</param>
    ''' <returns></returns>
    Public Function GetAnimalIDFromFrequencyAndObservationDate(Frequency As Double, ObservationDate As Date) As String
        Dim AnimalID As String = ""
        Try
            'query the animal movement database collar deployments to find out which collar had the requested frequency at the requested date.
            'sometimes retrievaldate is not filled in so there may be more than one record returned but the TOP 1 spec ensures only the latest deployment is returned.

            'build a query to submit to AM database
            Dim Sql As String = "SELECT TOP 1 Collars.Frequency, CollarDeployments.AnimalId, CollarDeployments.DeploymentDate,CollarDeployments.RetrievalDate,iif(Animals.MortalityDate is NULL,'Alive','Dead') as Status , Animals.MortalityDate, CollarDeployments.CollarId
FROM CollarDeployments INNER JOIN
    Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId INNER JOIN
    Animals ON CollarDeployments.ProjectId = Animals.ProjectId AND CollarDeployments.AnimalId = Animals.AnimalId
WHERE       
	(CollarDeployments.ProjectId = 'WRST_Caribou') AND (Frequency=" & Frequency & ") AND ((DeploymentDate < '" & ObservationDate & "') AND (RetrievalDate IS NULL)) 
	OR ((CollarDeployments.ProjectId = 'WRST_Caribou') AND (Frequency=" & Frequency & ") AND (DeploymentDate < '" & ObservationDate & "') AND (RetrievalDate > '" & ObservationDate & "'))
ORDER BY DeploymentDate DESC"

            'get the result into a datatable
            Dim DT As DataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
            If Not DT Is Nothing Then
                'the TOP 1 sql spec ensures only one or zero records will be returned
                If DT.Rows.Count = 1 Then
                    'assign the animalid
                    AnimalID = DT.Rows(0).Item("AnimalID")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return AnimalID
    End Function

    ''' <summary>
    ''' Returns a DataTable of the WRST caribou animals from the Animal_Movement database
    ''' </summary>
    ''' <returns>DataTable</returns>
    Public Function GetAnimalsDataTable() As DataTable
        Dim AnimalsDataTable As New DataTable()
        Try
            'query the database and build the table
            Dim Sql As String = "SELECT AnimalId, Species, Gender, MortalityDate, GroupName, Description,        ProjectId FROM            Animals WHERE        (ProjectId = 'WRST_Caribou')"
            AnimalsDataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
            AnimalsDataTable.TableName = "Animals"

            'set up the primary key(s)
            Dim PrimaryKeyColumn(1) As DataColumn
            PrimaryKeyColumn(0) = AnimalsDataTable.Columns("AnimalID")
            AnimalsDataTable.PrimaryKey = PrimaryKeyColumn
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return AnimalsDataTable
    End Function

    ''' <summary>
    ''' Returns a DataTable of the WRST caribou collars inventory from the Animal_Movement database.
    ''' </summary>
    ''' <returns>DataTable</returns>
    Public Function GetCollarsDataTable() As DataTable
        Dim CollarsDataTable As New DataTable()
        Try
            Dim Sql As String = "SELECT * FROM Collars ORDER BY Collars.Frequency"
            CollarsDataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
            CollarsDataTable.TableName = "Collars"
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return CollarsDataTable
    End Function

    ''' <summary>
    ''' Standardizes the look, feel and function of a GridEX
    ''' </summary>
    ''' <param name="GridEX">The GridEX to set up</param>
    Public Sub FormatGridEX(GridEX As GridEX)
        Try
            Dim MyFont As New Font("Sans Serif", 10, FontStyle.Regular)
            If Not GridEX Is Nothing Then
                With GridEX
                    'by default make grids readonly; toggle editability using ToggleGridEXReadOnly function
                    '.AllowAddNew = InheritableBoolean.False
                    '.AllowDelete = InheritableBoolean.False
                    '.AllowEdit = InheritableBoolean.False
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
                    '.SelectedFormatStyle.BackColor = Color.SteelBlue
                    '.SelectedFormatStyle.ForeColor = Color.White
                    '.SelectedFormatStyle.FontBold = TriState.False
                    '.SelectedInactiveFormatStyle.BackColor = Color.SteelBlue
                    '.SelectedInactiveFormatStyle.ForeColor = Color.White
                    '.SelectedInactiveFormatStyle.FontBold = TriState.False
                End With

                'gridex automotically formats doubles as currency. revert. also extend dates with time
                If Not GridEX.RootTable Is Nothing Then
                    For Each Col As GridEXColumn In GridEX.RootTable.Columns
                        'Debug.Print(GridEX.RootTable.Caption & vbTab & Col.Key & Col.FormatString)
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


    ''' <summary>
    ''' Returns the current value of the cell specified by GridEXColumnKey of the current row of GridEX.
    ''' </summary>
    ''' <param name="GridEX">GridEX to search. GridEX</param>
    ''' <param name="GridEXColumnKey">The key (name) of the GridEX column from which you would like the current value. String.</param>
    ''' <returns></returns>
    Public Function GetCurrentGridEXCellValue(GridEX As GridEX, GridEXColumnKey As String) As String
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
    ''' Loads distinct items from a DataTable's DataColumn into a GridEX GridEXColumn's DropDown ValueList
    ''' </summary>
    ''' <param name="GridEX">The GridEX containing the GridEXColumn requiring a DropDown ValueList</param>
    ''' <param name="SourceDataTable">Name of the DataTable containing the DataColumn from which distinct values will be drawn</param>
    ''' <param name="SourceColumnName">Name of the source DataTable's DataColumn from which distinct values will be drawn</param>
    ''' <param name="GridEXColumnName">Name of the GridEX column into which to load dropdown values</param>
    '''  <param name="LimitToList">Whether options for the dropdown should be limited to the list or not. Boolean.</param>
    Public Sub LoadGridEXDropDownWithDistinctDataTableValues(GridEX As GridEX, SourceDataTable As DataTable, SourceColumnName As String, GridEXColumnName As String, LimitToList As Boolean)
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
    ''' It's far to easy to accidentally delete records from a GridEX. This Sub is designed to avoid this through confirmation before deleting. Attach this Sub
    ''' to a GridEX's GridEX_DeletingRecords event.
    ''' </summary>
    ''' <param name="e"></param>
    Public Sub ConfirmDelete(e As System.ComponentModel.CancelEventArgs)
        If MsgBox("Delete this record and all related data?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            e.Cancel() = True
        End If
    End Sub


    Public Function GetDatabaseConnectionText() As String
        Dim Label As String = "Database: Disconnected"
        Try
            Dim DBConnectionStringBuilder As New SqlConnectionStringBuilder(My.Settings.WRST_CaribouConnectionString)
            Dim DB As String = DBConnectionStringBuilder.DataSource & ":" & DBConnectionStringBuilder.InitialCatalog
            Label = "Connected to " & DB.ToUpper & " as " & My.User.Name
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return Label
    End Function

    '''' <summary>
    '''' 
    '''' </summary>
    '''' <returns></returns>
    'Public Function GetAnimal_MovementDataset() As DataSet
    '    Dim AMDataset As New DataSet("Animal_Movement")
    '    Try
    '        'build the datatables from the database
    '        Dim AnimalsDataTable As DataTable = GetAnimalsDataTable()
    '        Dim CollarsDatatable As DataTable = GetCollarsDataTable()
    '        Dim CollarDeploymentsDataTable As DataTable = GetCollarDeploymentsDataTable()
    '        Dim AnimalFrequenciesLookupDataTable As DataTable = GetAnimalFrequenciesLookupDataTable()

    '        'load the datatables into the animal movement dataset
    '        With AMDataset
    '            .Tables.Add(GetCollarsDataTable)
    '            .Tables.Add(GetAnimalsDataTable)
    '            .Tables.Add(GetCollarDeploymentsDataTable)
    '            .Tables.Add(AnimalFrequenciesLookupDataTable)
    '        End With

    '        'set up relationships to show the history of collar deployments per animal
    '        Dim AnimalsToCollarDeploymentsDataRelation As New DataRelation("Animals_CollarDeploymentsDataRelation", AMDataset.Tables("Animals").Columns("AnimalID"), AMDataset.Tables("CollarDeployments").Columns("AnimalID"))
    '        AMDataset.Relations.Add(AnimalsToCollarDeploymentsDataRelation)
    '    Catch ex As Exception
    '        MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
    '    End Try
    '    Return AMDataset
    'End Function
End Module

