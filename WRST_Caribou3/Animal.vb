''' <summary>
''' Represents an animal in the NPS Alaska Region GIS Animal Movements Database
''' </summary>
Public Class Animal

    Private _AnimalID As String
    Public Property AnimalID() As String
        Get
            Return _AnimalID
        End Get
        Set(ByVal value As String)
            _AnimalID = value
        End Set
    End Property

    Private _AnimalDataTable As DataTable
    Public Property AnimalDetails() As DataTable
        Get
            Return _AnimalDataTable
        End Get
        Set(ByVal value As DataTable)
            _AnimalDataTable = value
        End Set
    End Property

    Private _AnimalDataset As DataSet
    Public Property AnimalDataset() As DataSet
        Get
            Return _AnimalDataset
        End Get
        Set(ByVal value As DataSet)
            _AnimalDataset = value
        End Set
    End Property

    Private _DeploymentsDataTable As DataTable
    Public Property Captures() As DataTable
        Get
            Return _DeploymentsDataTable
        End Get
        Set(ByVal value As DataTable)
            _DeploymentsDataTable = value
        End Set
    End Property

    Private _CapturesDataTable As DataTable
    Public Property Deployments() As DataTable
        Get
            Return _CapturesDataTable
        End Get
        Set(ByVal value As DataTable)
            _CapturesDataTable = value
        End Set
    End Property

    Public Sub New(AnimalID As String)
        If Not AnimalID Is Nothing Then
            If Not IsDBNull(AnimalID) Then
                _AnimalID = AnimalID
                If AnimalID.Trim.Length > 0 Then
                    Me.AnimalDetails = GetAnimalDataTable(_AnimalID)
                    Me.Deployments = GetCollarDeploymentsDataTable(_AnimalID)
                    Me.Captures = GetCapturesDataTable(_AnimalID)
                    Me.AnimalDataset = GetAnimalDataset(_AnimalID)
                End If
            End If
        End If
    End Sub

    Private Function GetCollarDeploymentsDataTable(AnimalID) As DataTable
        Dim DT As New DataTable("CollarDeployments")
        DT.TableName = "CollarDeployments"
        Try
            If Not AnimalID Is Nothing Then
                If Not IsDBNull(AnimalID) Then
                    If AnimalID.Trim.Length > 0 Then
                        Dim Sql As String = "SELECT        CollarDeployments.AnimalId, Collars.Frequency, CollarDeployments.DeploymentDate, CollarDeployments.RetrievalDate, Collars.DisposalDate, CollarDeployments.CollarManufacturer, Collars.CollarModel, Collars.HasGps, Collars.SerialNumber, 
CollarDeployments.CollarId, Collars.Manager, Collars.Owner, Collars.Notes, CollarDeployments.ProjectId, CollarDeployments.DeploymentId
FROM            CollarDeployments INNER JOIN
Collars ON CollarDeployments.CollarManufacturer = Collars.CollarManufacturer AND CollarDeployments.CollarId = Collars.CollarId
WHERE ProjectID='WRST_Caribou' AND AnimalID='" & _AnimalID & "' ORDER BY DeploymentDate DESC;"
                        DT = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return DT
    End Function

    Private Function GetAnimalDataTable(AnimalID) As DataTable
        Dim DT As New DataTable("Animal")
        DT.TableName = "Animal"
        Try
            If Not AnimalID Is Nothing Then
                If Not IsDBNull(AnimalID) Then
                    If AnimalID.Trim.Length > 0 Then
                        Dim Sql As String = "SELECT * From Animals WHERE AnimalID='" & _AnimalID & "'"
                        DT = GetDataTable(My.Settings.Animal_MovementConnectionString, Sql)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return DT
    End Function

    Private Function GetAnimalDataset(AnimalID As String) As DataSet
        Dim AnimalDataset As New DataSet(AnimalID)
        Try
            Dim AnimalDataTable As DataTable = GetAnimalDataTable(AnimalID)
            AnimalDataTable.TableName = "Animal"
            Dim CollarDeploymentsDataTable As DataTable = GetCollarDeploymentsDataTable(AnimalID)
            CollarDeploymentsDataTable.TableName = "CollarDeployments"
            Dim CapturesDataTable As DataTable = GetCapturesDataTable(AnimalID)
            CapturesDataTable.TableName = "Captures"
            With AnimalDataset
                .Tables.Add(AnimalDataTable)
                .Tables.Add(CollarDeploymentsDataTable)
                .Tables.Add(CapturesDataTable)
            End With
            Dim AnimalDataRelation As New DataRelation("AnimalToCollarDeploymentsDataRelation", AnimalDataTable.Columns("AnimalID"), CollarDeploymentsDataTable.Columns("AnimalID"), False)
            Dim CapturesDataRelation As New DataRelation("AnimalToCapturesDataRelation", AnimalDataTable.Columns("AnimalID"), CapturesDataTable.Columns("AnimalID"), False)
            AnimalDataset.Relations.Add(AnimalDataRelation)
            AnimalDataset.Relations.Add(CapturesDataRelation)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return AnimalDataset
    End Function

    Private Function GetCapturesDataTable(AnimalID As String) As DataTable
        Dim DT As New DataTable("Captures")
        DT.TableName = "Captures"
        Try
            If Not AnimalID Is Nothing Then
                If Not IsDBNull(AnimalID) Then
                    If AnimalID.Trim.Length > 0 Then
                        Dim Sql As String = "SELECT * From Captures WHERE AnimalID='" & _AnimalID & "' ORDER BY CaptureDate DESC;"
                        DT = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Return DT
    End Function

End Class
