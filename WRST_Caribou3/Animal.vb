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



    Private _DeploymentsDataTable As DataTable
    Public Property Deployments() As DataTable
        Get
            Return _DeploymentsDataTable
        End Get
        Set(ByVal value As DataTable)
            _DeploymentsDataTable = value
        End Set
    End Property


    Public Sub New(AnimalID As String)
        If Not IsDBNull(AnimalID) Then
            _AnimalID = AnimalID
            If AnimalID.Trim.Length > 0 Then
                Me.AnimalDetails = GetAnimalDataTable(_AnimalID)
                Me.Deployments = GetCollarDeploymentsDataTable(_AnimalID)
            End If
        End If
    End Sub

    Private Function GetCollarDeploymentsDataTable(AnimalID) As DataTable
        Dim DT As New DataTable
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
        Dim DT As New DataTable
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

End Class
