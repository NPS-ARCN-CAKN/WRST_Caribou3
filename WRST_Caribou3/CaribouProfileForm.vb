Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data.SqlClient

Public Class CaribouProfileForm


    Private Sub CaribouProfileForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAnimalIDsComboBox()

        Me.AnimalDockPanel.Options.ShowCloseButton = False
        Me.CapturesDockPanel.Options.ShowCloseButton = False
        Me.CollarDeploymentsDockPanel.Options.ShowCloseButton = False
        Me.CollarFixesDockPanel.Options.ShowCloseButton = False
        Me.EarlyRadiotrackingDockPanel.Options.ShowCloseButton = False
        Me.SightingsDockPanel.Options.ShowCloseButton = False
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

        'Captures
        Try
            Sql = "SELECT AnimalID, CaptureDate, ProjectID, Park, Pilot, Shooter, Handler, AircraftType, Crew, CaptureGroupSize, Frequency, VisualCollar, SerialNumber, OldFrequency, OldVisualCollar, CaptureLatitude, CaptureLongitude, GeneralLocation, 
                  TimeStartChase, TimeFirstHitBounce, TimeSecordHitBounce, TimeThirdHitBounce, TimeVisibleEffect, TimeAnimalDown, DartLocation, NumHits, NumMisses, Anesthetic, AnestheticDosage_mg, AnestheticDosage_ml, 
                  AnestheticConcentration_mg_ml, DrugEffect, Sedative, SedativeDosage_mg, SedativeDosage_ml, SedativeConcentration_mg_ml, InitialBodyTemp, InitialBodyTempTime, AdditionalDrugs, Sex, EstimatedAge, WithCalf, Lactating, 
                  BodyCondition, Weight_Kg, BodyLength, NeckCircumference, Jaw, MetatarsusLength, HindfootLength, ChestGirth, NasalSwab, HairSample, BloodSampleRed, BloodSamplePurple, BloodSampleGreen, AnestheticReversal, 
                  AnestheticReversalDosage_mg, AnestheticReversalDosage_ml, AnestheticReversalConcentration_mg_ml, AnestheticReversalRoute, AnestheticReversalTime, SedativeReversal, SedativeReversalDosage_mg, 
                  SedativeReversalDosage_ml, SedativeReversalConcentration_mg_ml, SedativeReversalRoute, SedativeReversalTime, FinalBodyTemperature, FinalBodyTemperatureTime, TimeStanding, TimeMobile, ProtocolVersion, SOPNumber, 
                  SOPVersion, Comments, CertificationLevel, CertificationDate, CertifiedBy, ProtocolIRMAReference, RecordInsertedDate, RecordInsertedBy, CaptureID
FROM     Captures WHERE AnimalID='" & AnimalID & "' "
            Dim CapturesDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.CapturesGridControl.DataSource = CapturesDataTable
            SetUpGridControl(Me.CapturesGridControl)
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
        Try
            GC.UseEmbeddedNavigator = True
            Dim GV As GridView = TryCast(GC.MainView, GridView)
            GV.OptionsBehavior.Editable = False
            GV.OptionsBehavior.AllowAddRows = False
            GV.OptionsBehavior.AllowDeleteRows = False
            GV.OptionsBehavior.ReadOnly = True
            GV.BestFitColumns(True)
            GV.OptionsView.BestFitMode = GridBestFitMode.Fast
            GV.OptionsView.ColumnAutoWidth = False
            GV.OptionsView.ShowFooter = True
            GV.OptionsDetail.EnableMasterViewMode = False 'True to show sub-tables
        Catch ex As Exception
        MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub AnimalIDToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AnimalIDToolStripComboBox.SelectedIndexChanged
        Dim AnimalID As String = Me.AnimalIDToolStripComboBox.Text.Trim
        Me.AnimalHeaderLabel.Text = AnimalID
        LoadData(AnimalID)
    End Sub

    Private Sub SyncDatabasesToolStripButton_Click(sender As Object, e As EventArgs) Handles SyncDatabasesToolStripButton.Click
        AskToSynchronizeDatabases()
    End Sub
End Class