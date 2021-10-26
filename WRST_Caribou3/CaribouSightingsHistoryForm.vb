Public Class CaribouSightingsHistoryForm

    Public Sub New(Optional AnimalID As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Not AnimalID.Trim = "" Then
            Me.AnimalIDToolStripComboBox.Text = AnimalID.Trim
            LoadData(AnimalID)
        End If
    End Sub


    Private Sub CaribouSightingsHistoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Pre-load the animalids into the selector combo box
        LoadAnimalIDsComboBox()

        'Me.WindowState = FormWindowState.Maximized
    End Sub



    Private Sub LoadData(AnimalID As String)
        If AnimalID.Trim <> "" Then

            Dim Sql As String = "SELECT * FROM Dataset_Survivorship WHERE AnimalID='" & AnimalID.Trim & "' ORDER BY SightingDate Asc, AnimalID Asc"
            Try
                Dim SightingsDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
                Me.SightingsHistoryDataGridView.DataSource = SightingsDataTable
            Catch ex As Exception
                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            End Try

        End If

    End Sub

    Private Sub LoadAnimalIDsComboBox()
        Try
            Dim Sql As String = "SELECT AnimalID from tmpAnimals ORDER BY AnimalID"
            Dim AnimalIDsDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.AnimalIDToolStripComboBox.Items.Clear()

            For Each Row As DataRow In AnimalIDsDataTable.Rows
                Me.AnimalIDToolStripComboBox.Items.Add(Row.Item("AnimalID"))
            Next

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try

    End Sub

    Private Sub AnimalIDToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AnimalIDToolStripComboBox.SelectedIndexChanged
        LoadData(Me.AnimalIDToolStripComboBox.Text.Trim)
    End Sub
End Class