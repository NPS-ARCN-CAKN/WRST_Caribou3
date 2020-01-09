Public Class SurvivorshipForm

    'Dim SurvivorshipDataset As New DataSet("Survivorship") 
    Dim SurvivorshipDataTable As New DataTable()
    Dim AnimalsDataTable As New DataTable()
    Private Sub SurvivorshipForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SurvivorshipDataTable = GetSurvivorshipDataTable()
        'AnimalsDataTable = GetAnimalsDataTable()



        With Me.SurvivorshipGridEX
            .DataSource = SurvivorshipDataTable
            .Hierarchical = False
            .RetrieveStructure()
            .ExpandRecords()
        End With



        'Me.SurvivorshipDataGridView.DataSource = GetSurvivorshipMatrix()
    End Sub


    Public Function GetSurvivorshipDataTable() As DataTable
        'Get the collared animals into a datatable

        Dim Sql As String = "SELECT AnimalId, Species, Gender, MortalityDate, GroupName, Description,        ProjectId FROM            Animals WHERE        (ProjectId = 'WRST_Caribou') ORDER BY AnimalID"
        AnimalsDataTable = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
        AnimalsDataTable.TableName = "Animals"
        'SurvivorshipDataset.Tables.Add(AnimalsDataTable)

        'get the tracking data into a datatable
        Dim TrackingQuery As String = "SELECT CollaredAnimalsInGroups.AnimalID,Dataset_Full.SightingDate, Year(SightingDate) as [Year], Month(SightingDate) as [Month],Dataset_Full.[In], Dataset_Full.Seen
FROM            CollaredAnimalsInGroups INNER JOIN Dataset_Full ON CollaredAnimalsInGroups.EID = Dataset_Full.EID 
ORDER BY AnimalID,[Month]"

        'get all the animal sightings into a table and add in the mortality info from animal movement animalsdatatable
        SurvivorshipDataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, TrackingQuery)
        With SurvivorshipDataTable
            .TableName = "Tracking"
            .Columns.Add(New DataColumn("MortalityDate", GetType(Date)))
            .Columns.Add(New DataColumn("Alive", GetType(Boolean)))
        End With
        For Each Row As DataRow In SurvivorshipDataTable.Rows
            Row.Item("Alive") = True
            Dim AnimalID As String = Row.Item("AnimalID")
            Dim SightingDate As Date
            Dim MortalityDate As Date
            If Not IsDBNull(Row.Item("SightingDate")) Then SightingDate = Row.Item("SightingDate")

            'add the mortality date to the survivorship table
            Dim MortDataView As New DataView(AnimalsDataTable, "AnimalID='" & AnimalID & "'", "", DataViewRowState.CurrentRows)
            If MortDataView.Count = 1 And IsDate(MortDataView(0).Item("MortalityDate")) Then
                MortalityDate = CDate(MortDataView(0).Item("MortalityDate"))
                Row.Item("MortalityDate") = MortalityDate
            End If

            'was it alive at the time of the sighting?
            If Not IsDBNull(MortalityDate) Then
                If SightingDate >= MortalityDate Then
                    Row.Item("Alive") = False
                End If
            End If
        Next

        'SurvivorshipDataset.Tables.Add(SurvivorshipDataTable)


        'create a datarelation between tracklogs and loon observations

        'Dim AnimalsDataRelation As New DataRelation("AnimalsDataRelation", SurvivorshipDataset.Tables("Animals").Columns("AnimalID"), SurvivorshipDataset.Tables("Tracking").Columns("AnimalID"), False)
        'SurvivorshipDataset.Relations.Add(AnimalsDataRelation)

        'create a bindingsource for tracking data
        'Dim TrackingBindingSource As New BindingSource(SurvivorshipDataset, "Tracking")
        'TrackingBindingSource.DataSource = SurvivorshipDataset.Tables("Tracking") '

        'Dim AnimalsBindingSource As New BindingSource(SurvivorshipDataset, "Animals")


        Return SurvivorshipDataTable
    End Function
















    'Public Function GetSurvivorshipMatrix() As DataTable


    '        'get all the tracking results from wrst_caribou
    '        Dim TrackingQuery As String = "SELECT        CollaredAnimalsInGroups.AnimalID, Year(SightingDate) as [Year], Month(SightingDate) as [Month],Dataset_Full.SightingDate, Dataset_Full.Seen, Dataset_Full.[In], Dataset_Full.FlightID
    'FROM            CollaredAnimalsInGroups INNER JOIN
    '                         Dataset_Full ON CollaredAnimalsInGroups.EID = Dataset_Full.EID 
    'ORDER BY AnimalID,[Month]"
    '        Dim SurvivorshipDataTable As New DataTable()
    '        SurvivorshipDataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, TrackingQuery)

    '        Try

    '        Catch ex As Exception
    '            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
    '        End Try
    '        Return SurvivorshipDataTable
    '    End Function

    '    ''' <summary>
    '    ''' Returns a DataTable with all the caribou tracking data over time for all collared animals.
    '    ''' </summary>
    '    ''' <returns>DataTable</returns>
    '    Public Function GetSurvivorshipDataTable() As DataTable
    '        'get all the tracking results from wrst_caribou


    '        Try

    '        Catch ex As Exception
    '            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
    '        End Try
    '        Return SurvivorshipDataTable
    '    End Function

End Class