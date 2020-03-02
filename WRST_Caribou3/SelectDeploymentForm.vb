Public Class SelectDeploymentForm

    Private DeploymentIDValue As Integer
    ''' <summary>
    ''' User selected DeploymentID.
    ''' </summary>
    ''' <returns>Integer.</returns>
    Public Property DeploymentID() As Integer
        Get
            Return DeploymentIDValue
        End Get
        Set(ByVal value As Integer)
            DeploymentIDValue = value
        End Set
    End Property

    ''' <summary>
    ''' Creates a new SelectDeploymentForm allowing the user to select the preferred collar deployment where Animal Movement returns multiple possible deployments
    ''' for a Frequency and Date.
    ''' </summary>
    ''' <param name="DeploymentsDataTable"></param>
    Public Sub New(DeploymentsDataTable As DataTable)
        InitializeComponent()

        If Not DeploymentsDataTable Is Nothing Then
            If DeploymentsDataTable.Rows.Count > 1 Then
                With DeploymentsGridEX
                    .DataSource = DeploymentsDataTable
                    .RetrieveStructure()
                End With
            Else
                MsgBox("DeploymentsDataTable must contain multiple rows.")
            End If
        Else
            MsgBox("DeploymentsDataTable cannot be Nothing")
        End If

    End Sub
    Private Sub SelectDeploymentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.HeaderLabel.Width = Me.LabelPanel.Width = 50
        Me.HeaderLabel.Height = Me.LabelPanel.Height
        Me.HeaderLabel.AutoSize = True
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub


    Private Sub DeploymentsGridEX_SelectionChanged(sender As Object, e As EventArgs) Handles DeploymentsGridEX.SelectionChanged
        Try
            Me.DeploymentID = GetCurrentGridEXCellValue(Me.DeploymentsGridEX, "DeploymentID")
            If Me.DeploymentID > 0 Then
                Me.SelectButton.Enabled = True
            Else
                Me.SelectButton.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub SelectButton_Click(sender As Object, e As EventArgs) Handles SelectButton.Click
        Try
            Me.DeploymentID = GetCurrentGridEXCellValue(Me.DeploymentsGridEX, "DeploymentID")
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
        Me.Close()
    End Sub
End Class