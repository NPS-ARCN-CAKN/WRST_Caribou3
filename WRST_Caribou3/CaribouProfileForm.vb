Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraMap
Imports System.Data.SqlClient

Public Class CaribouProfileForm


    Private Sub CaribouProfileForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAnimalIDsComboBox()

        Me.AnimalDockPanel.Options.ShowCloseButton = False
        Me.CapturesDockPanel.Options.ShowCloseButton = False
        Me.CollarDeploymentsDockPanel.Options.ShowCloseButton = False
        Me.CollarFixesDockPanel.Options.ShowCloseButton = False
        Me.RadiotrackingDockPanel.Options.ShowCloseButton = False
        Me.SightingsDockPanel.Options.ShowCloseButton = False



    End Sub

    Private Sub LoadNationalMapIntoMapControl()
        'Add a WMS map layer to a DevExpress MapControl 
        Try
            Dim LayerName As String = "0"
            Dim URL As String = "https://basemap.nationalmap.gov:443/arcgis/services/USGSTopo/MapServer/WmsServer?"
            Dim ShadedReliefWMSImageLayer As ImageLayer = GetWMSImageLayer(LayerName, URL)
            Me.CaribouMapControl.Layers.Add(ShadedReliefWMSImageLayer)
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
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

        'Clear the map
        Me.CaribouMapControl.Layers.Clear()
        LoadNationalMapIntoMapControl()

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

            'Load the points into the map control
            Dim CapturesVectorItemsLayer As VectorItemsLayer = GetBubbleVectorItemsLayerFromPointsDataTable(CapturesDataTable, "CaptureLatitude", "CaptureLongitude", 1, MarkerType.Star5, Color.Orange)
            Me.CaribouMapControl.Layers.Add(CapturesVectorItemsLayer)

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
            Sql = "SELECT SightingDate, SurveyType, GroupNumber, TailNo, SearchArea, SmallBull, MediumBull, LargeBull, Bull, Cow, Calf
, Adult, FrequenciesInGroup, [In], Seen, Marked, Mode, Accuracy, Herd, Lat, Lon, Comment, SourceFilename, 
                  RecordedFrequency, ActualFrequency, AnimalID, CaribouGroupComment, FlightID, EID, DeploymentID, Year
FROM     Dataset_SurveySightingsHistory WHERE AnimalID = '" & AnimalID & "' order by sightingdate"
            Dim SurveySightingsDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.SightingsSurveysGridControl.DataSource = SurveySightingsDataTable
            SetUpGridControl(Me.SightingsSurveysGridControl)

            'Load the points into the map control
            Dim SurveySightingsVectorItemsLayer As VectorItemsLayer = GetBubbleVectorItemsLayerFromPointsDataTable(SurveySightingsDataTable, "Lat", "Lon", 1, MarkerType.Triangle, Color.Green)
            Me.CaribouMapControl.Layers.Add(SurveySightingsVectorItemsLayer)

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try

        'Survivorship
        Try
            Sql = "SELECT AnimalId, SightingDate, Year, Month, [In], Seen, AliveAtSightingDate, SightingType, Lat, Lon
FROM     Dataset_Survivorship
WHERE AnimalID = '" & AnimalID & "' ORDER BY SightingDate "
            Dim SurvivorshipDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.SurvivorshipGridControl.DataSource = SurvivorshipDataTable
            SetUpGridControl(Me.SightingsSurveysGridControl)

            'Load the points into the map control
            'Dim SurvivorshipVectorItemsLayer As VectorItemsLayer = GetBubbleVectorItemsLayerFromPointsDataTable(SurvivorshipDataTable, "Lat", "Lon", 1, MarkerType.Triangle, Color.Green)
            'Me.CaribouMapControl.Layers.Add(SurvivorshipVectorItemsLayer)

        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try


        'Radiotracking
        Try
            Sql = "SELECT * FROM Radiotracking WHERE (AnimalID = '" & AnimalID.Trim & "')"
            Dim RadiotrackingDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.RadiotrackingGridControl.DataSource = RadiotrackingDataTable
            SetUpGridControl(Me.RadiotrackingGridControl)

            'Load the points into the map control
            Dim RadiotrackingVectorItemsLayer As VectorItemsLayer = GetBubbleVectorItemsLayerFromPointsDataTable(RadiotrackingDataTable, "Lat", "Lon", 1, MarkerType.Square, Color.Blue)
            Me.CaribouMapControl.Layers.Add(RadiotrackingVectorItemsLayer)

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
        'Collar fixes
        Try
            Dim Sql As String = "SELECT FixDate, Lat, Lon, DeploymentDate, RetrievalDate, MortalityDate, DisposalDate, FixId, HiddenBy
, FileId, LineNumber, CollarManufacturer, CollarId, ProjectId, DateThisViewWasRefreshed, RetrievedBy, AnimalId
FROM     tmpCollarFixes
 WHERE        (AnimalID = '" & AnimalID & "')"
            Dim FixesDataTable As DataTable = GetDataTable(My.Settings.WRST_CaribouConnectionString, Sql)
            Me.CollarFixesGridControl.DataSource = FixesDataTable
            SetUpGridControl(Me.CollarFixesGridControl)

            'Load the points into the map control
            Dim CaribouLocationsVectorItemsLayer As VectorItemsLayer = GetBubbleVectorItemsLayerFromPointsDataTable(FixesDataTable, "Lat", "Lon", 1, MarkerType.Circle, Color.Red)
            Me.CaribouMapControl.Layers.Add(CaribouLocationsVectorItemsLayer)

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

    Private Sub AnimalIDToolStripComboBox_TextChanged(sender As Object, e As EventArgs) Handles AnimalIDToolStripComboBox.TextChanged
        Dim AnimalID As String = Me.AnimalIDToolStripComboBox.Text.Trim
        Me.AnimalHeaderLabel.Text = AnimalID
        LoadData(AnimalID)
    End Sub
End Class