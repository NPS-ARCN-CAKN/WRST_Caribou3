Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class CaribouProfileForm

    'Private AnimalIDValue As String
    'Public Property AnimalID() As String
    '    Get
    '        Return AnimalIDValue
    '    End Get
    '    Set(ByVal value As String)
    '        AnimalIDValue = value.Trim
    '    End Set
    'End Property

    'Public Sub New(AnimalID As String)

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    If Not AnimalID.Trim = "" Then
    '        Me.AnimalID = AnimalID
    '        'Me.Text = Me.AnimalID
    '    End If

    'End Sub

    Private Sub CaribouProfileForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAnimalIDsComboBox()


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

    Private Sub LoadData(AnimalID As String)

        'Animal details
        Dim Sql As String = "SELECT * FROM tmpAnimals WHERE AnimalID='" & AnimalID & "'"
        Try
            Dim AnimalDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.AnimalVGridControl.DataSource = AnimalDataTable
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try

        'Deployments
        Try
            Sql = "SELECT Frequency, DeploymentDate, RetrievalDate, RetrievedBy, DisposalDate, CollarManufacturer, CollarId, HasGps, DeploymentId, DateThisViewWasRefreshed
FROM            tmpCollarDeployments
 WHERE AnimalID='" & AnimalID & "' ORDER BY DeploymentDate"
            Dim DeploymentsDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.DeploymentsGridControl.DataSource = DeploymentsDataTable
            SetUpGridControl(Me.DeploymentsGridControl)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try

        'Survey sightings
        Try
            Sql = "select * from Dataset_SurveySightingsHistory where animalid = '" & AnimalID & "' order by sightingdate"
            Dim SurveySightingsDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            'Me.SurveySightingsDataGridView.DataSource = SurveySightingsDataTable
            Me.SightingsSurveysGridControl.DataSource = SurveySightingsDataTable
            SetUpGridControl(Me.SightingsSurveysGridControl)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try


        'Early radiotracking
        Try
            Sql = "SELECT * from EarlyRadiotracking WHERE        (AnimalID = '" & AnimalID & "')"
            Dim EarlyRadiotrackingDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.EarlyRadiotrackingGridControl.DataSource = EarlyRadiotrackingDataTable
            SetUpGridControl(Me.EarlyRadiotrackingGridControl)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try

        LoadCollarFixes(AnimalID)
    End Sub

    ''' <summary>
    ''' Loads collar fixes data into the collar fixes grid control
    ''' </summary>
    ''' <param name="AnimalID"></param>
    Private Sub LoadCollarFixes(AnimalID As String)
        'Early radiotracking
        Try
            Dim Sql As String = "SELECT * from tmpCollarFixes WHERE        (AnimalID = '" & AnimalID & "')"
            Dim DT As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.CollarFixesGridControl.DataSource = DT
            SetUpGridControl(Me.CollarFixesGridControl)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub SetUpGridControl(GC As GridControl)
        GC.UseEmbeddedNavigator = True
        Dim GV As GridView = TryCast(GC.MainView, GridView)
        GV.OptionsBehavior.Editable = False
        GV.OptionsBehavior.AllowAddRows = False
        GV.OptionsBehavior.AllowDeleteRows = False
        GV.BestFitColumns(True)
        GV.OptionsView.BestFitMode = GridBestFitMode.Fast
        GV.OptionsView.ColumnAutoWidth = False
        GV.OptionsView.ShowFooter = True
        GV.OptionsDetail.EnableMasterViewMode = False 'True to show sub-tables
    End Sub

    Private Sub AnimalIDToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AnimalIDToolStripComboBox.SelectedIndexChanged
        Dim AnimalID As String = Me.AnimalIDToolStripComboBox.Text.Trim
        Me.AnimalHeaderLabel.Text = AnimalID
        LoadData(AnimalID)

    End Sub
End Class