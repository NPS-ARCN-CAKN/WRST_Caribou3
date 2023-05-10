<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CaribouProfileForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaribouProfileForm))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.AnimalIDToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SyncDatabasesToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SightingsSurveysGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RadiotrackingGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CollarFixesGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AnimalVGridControl = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.AnimalHeaderLabel = New System.Windows.Forms.Label()
        Me.DeploymentsGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DeploymentsLabel = New System.Windows.Forms.Label()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.hideContainerBottom = New DevExpress.XtraBars.Docking.AutoHideContainer()
        Me.CollarDeploymentsDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.CollarDeploymentsDockPanel_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.SightingsDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.ControlContainer1 = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.RadiotrackingDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.ControlContainer2 = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.CollarFixesDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.ControlContainer3 = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.CapturesDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.CapturesGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AnimalDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.AnimalDockPanel_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.SurvivorshipDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.ControlContainer4 = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.SurvivorshipGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CaribouMapControl = New DevExpress.XtraMap.MapControl()
        Me.MainToolStrip.SuspendLayout()
        CType(Me.SightingsSurveysGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadiotrackingGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CollarFixesGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnimalVGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeploymentsGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hideContainerBottom.SuspendLayout()
        Me.CollarDeploymentsDockPanel.SuspendLayout()
        Me.CollarDeploymentsDockPanel_Container.SuspendLayout()
        Me.SightingsDockPanel.SuspendLayout()
        Me.ControlContainer1.SuspendLayout()
        Me.RadiotrackingDockPanel.SuspendLayout()
        Me.ControlContainer2.SuspendLayout()
        Me.CollarFixesDockPanel.SuspendLayout()
        Me.ControlContainer3.SuspendLayout()
        Me.CapturesDockPanel.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.CapturesGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AnimalDockPanel.SuspendLayout()
        Me.AnimalDockPanel_Container.SuspendLayout()
        Me.SurvivorshipDockPanel.SuspendLayout()
        Me.ControlContainer4.SuspendLayout()
        CType(Me.SurvivorshipGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaribouMapControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.AnimalIDToolStripComboBox, Me.ToolStripSeparator1, Me.SyncDatabasesToolStripButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(202, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(982, 25)
        Me.MainToolStrip.TabIndex = 0
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(147, 22)
        Me.ToolStripLabel1.Text = "Select an animal to profile:"
        '
        'AnimalIDToolStripComboBox
        '
        Me.AnimalIDToolStripComboBox.Name = "AnimalIDToolStripComboBox"
        Me.AnimalIDToolStripComboBox.Size = New System.Drawing.Size(180, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'SyncDatabasesToolStripButton
        '
        Me.SyncDatabasesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SyncDatabasesToolStripButton.Image = CType(resources.GetObject("SyncDatabasesToolStripButton.Image"), System.Drawing.Image)
        Me.SyncDatabasesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SyncDatabasesToolStripButton.Name = "SyncDatabasesToolStripButton"
        Me.SyncDatabasesToolStripButton.Size = New System.Drawing.Size(139, 22)
        Me.SyncDatabasesToolStripButton.Text = "Synchronize databases..."
        '
        'SightingsSurveysGridControl
        '
        Me.SightingsSurveysGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SightingsSurveysGridControl.Location = New System.Drawing.Point(0, 0)
        Me.SightingsSurveysGridControl.MainView = Me.GridView2
        Me.SightingsSurveysGridControl.Name = "SightingsSurveysGridControl"
        Me.SightingsSurveysGridControl.Size = New System.Drawing.Size(1178, 294)
        Me.SightingsSurveysGridControl.TabIndex = 3
        Me.SightingsSurveysGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.SightingsSurveysGridControl
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.ReadOnly = True
        Me.GridView2.OptionsSelection.MultiSelect = True
        Me.GridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView2.OptionsView.ShowFooter = True
        '
        'RadiotrackingGridControl
        '
        Me.RadiotrackingGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadiotrackingGridControl.Location = New System.Drawing.Point(0, 0)
        Me.RadiotrackingGridControl.MainView = Me.GridView3
        Me.RadiotrackingGridControl.Name = "RadiotrackingGridControl"
        Me.RadiotrackingGridControl.Size = New System.Drawing.Size(1178, 295)
        Me.RadiotrackingGridControl.TabIndex = 4
        Me.RadiotrackingGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.RadiotrackingGridControl
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.ReadOnly = True
        Me.GridView3.OptionsSelection.MultiSelect = True
        Me.GridView3.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView3.OptionsView.ShowFooter = True
        '
        'CollarFixesGridControl
        '
        Me.CollarFixesGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CollarFixesGridControl.Location = New System.Drawing.Point(0, 0)
        Me.CollarFixesGridControl.MainView = Me.GridView4
        Me.CollarFixesGridControl.Name = "CollarFixesGridControl"
        Me.CollarFixesGridControl.Size = New System.Drawing.Size(1178, 294)
        Me.CollarFixesGridControl.TabIndex = 5
        Me.CollarFixesGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.CollarFixesGridControl
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.ReadOnly = True
        Me.GridView4.OptionsSelection.MultiSelect = True
        Me.GridView4.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView4.OptionsView.ShowFooter = True
        '
        'AnimalVGridControl
        '
        Me.AnimalVGridControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.AnimalVGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimalVGridControl.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.AnimalVGridControl.Location = New System.Drawing.Point(0, 44)
        Me.AnimalVGridControl.Name = "AnimalVGridControl"
        Me.AnimalVGridControl.OptionsBehavior.Editable = False
        Me.AnimalVGridControl.Size = New System.Drawing.Size(195, 667)
        Me.AnimalVGridControl.TabIndex = 0
        '
        'AnimalHeaderLabel
        '
        Me.AnimalHeaderLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.AnimalHeaderLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnimalHeaderLabel.Location = New System.Drawing.Point(0, 0)
        Me.AnimalHeaderLabel.Name = "AnimalHeaderLabel"
        Me.AnimalHeaderLabel.Size = New System.Drawing.Size(195, 44)
        Me.AnimalHeaderLabel.TabIndex = 3
        Me.AnimalHeaderLabel.Text = "AnimalID"
        '
        'DeploymentsGridControl
        '
        Me.DeploymentsGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeploymentsGridControl.Location = New System.Drawing.Point(0, 28)
        Me.DeploymentsGridControl.MainView = Me.GridView1
        Me.DeploymentsGridControl.Name = "DeploymentsGridControl"
        Me.DeploymentsGridControl.Size = New System.Drawing.Size(1178, 266)
        Me.DeploymentsGridControl.TabIndex = 2
        Me.DeploymentsGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DeploymentsGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'DeploymentsLabel
        '
        Me.DeploymentsLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.DeploymentsLabel.Location = New System.Drawing.Point(0, 0)
        Me.DeploymentsLabel.Name = "DeploymentsLabel"
        Me.DeploymentsLabel.Size = New System.Drawing.Size(1178, 28)
        Me.DeploymentsLabel.TabIndex = 1
        Me.DeploymentsLabel.Text = "Collar deployments"
        '
        'DockManager1
        '
        Me.DockManager1.AutoHideContainers.AddRange(New DevExpress.XtraBars.Docking.AutoHideContainer() {Me.hideContainerBottom})
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.AnimalDockPanel})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'hideContainerBottom
        '
        Me.hideContainerBottom.BackColor = System.Drawing.SystemColors.Control
        Me.hideContainerBottom.Controls.Add(Me.CollarDeploymentsDockPanel)
        Me.hideContainerBottom.Controls.Add(Me.SightingsDockPanel)
        Me.hideContainerBottom.Controls.Add(Me.RadiotrackingDockPanel)
        Me.hideContainerBottom.Controls.Add(Me.CollarFixesDockPanel)
        Me.hideContainerBottom.Controls.Add(Me.CapturesDockPanel)
        Me.hideContainerBottom.Controls.Add(Me.SurvivorshipDockPanel)
        Me.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.hideContainerBottom.Location = New System.Drawing.Point(0, 740)
        Me.hideContainerBottom.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.hideContainerBottom.Name = "hideContainerBottom"
        Me.hideContainerBottom.Size = New System.Drawing.Size(1184, 21)
        '
        'CollarDeploymentsDockPanel
        '
        Me.CollarDeploymentsDockPanel.Controls.Add(Me.CollarDeploymentsDockPanel_Container)
        Me.CollarDeploymentsDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CollarDeploymentsDockPanel.ID = New System.Guid("83a4e7e0-a5fe-4c7b-b794-14c82fed3b5a")
        Me.CollarDeploymentsDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.CollarDeploymentsDockPanel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CollarDeploymentsDockPanel.Name = "CollarDeploymentsDockPanel"
        Me.CollarDeploymentsDockPanel.OriginalSize = New System.Drawing.Size(200, 400)
        Me.CollarDeploymentsDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CollarDeploymentsDockPanel.SavedIndex = 1
        Me.CollarDeploymentsDockPanel.Size = New System.Drawing.Size(1184, 325)
        Me.CollarDeploymentsDockPanel.Text = "Collar deployments"
        Me.CollarDeploymentsDockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'CollarDeploymentsDockPanel_Container
        '
        Me.CollarDeploymentsDockPanel_Container.Controls.Add(Me.DeploymentsGridControl)
        Me.CollarDeploymentsDockPanel_Container.Controls.Add(Me.DeploymentsLabel)
        Me.CollarDeploymentsDockPanel_Container.Location = New System.Drawing.Point(3, 28)
        Me.CollarDeploymentsDockPanel_Container.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CollarDeploymentsDockPanel_Container.Name = "CollarDeploymentsDockPanel_Container"
        Me.CollarDeploymentsDockPanel_Container.Size = New System.Drawing.Size(1178, 294)
        Me.CollarDeploymentsDockPanel_Container.TabIndex = 0
        '
        'SightingsDockPanel
        '
        Me.SightingsDockPanel.Controls.Add(Me.ControlContainer1)
        Me.SightingsDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.SightingsDockPanel.ID = New System.Guid("a6fcc7a3-b95a-4b55-887d-ebd5553d22c8")
        Me.SightingsDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.SightingsDockPanel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SightingsDockPanel.Name = "SightingsDockPanel"
        Me.SightingsDockPanel.OriginalSize = New System.Drawing.Size(200, 400)
        Me.SightingsDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.SightingsDockPanel.SavedIndex = 2
        Me.SightingsDockPanel.Size = New System.Drawing.Size(1184, 325)
        Me.SightingsDockPanel.Text = "Sightings"
        Me.SightingsDockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'ControlContainer1
        '
        Me.ControlContainer1.Controls.Add(Me.SightingsSurveysGridControl)
        Me.ControlContainer1.Location = New System.Drawing.Point(3, 28)
        Me.ControlContainer1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ControlContainer1.Name = "ControlContainer1"
        Me.ControlContainer1.Size = New System.Drawing.Size(1178, 294)
        Me.ControlContainer1.TabIndex = 0
        '
        'RadiotrackingDockPanel
        '
        Me.RadiotrackingDockPanel.Controls.Add(Me.ControlContainer2)
        Me.RadiotrackingDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.RadiotrackingDockPanel.ID = New System.Guid("65483a37-2711-4c35-ba1a-3827756e5b9f")
        Me.RadiotrackingDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.RadiotrackingDockPanel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RadiotrackingDockPanel.Name = "RadiotrackingDockPanel"
        Me.RadiotrackingDockPanel.OriginalSize = New System.Drawing.Size(200, 400)
        Me.RadiotrackingDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.RadiotrackingDockPanel.SavedIndex = 2
        Me.RadiotrackingDockPanel.Size = New System.Drawing.Size(1184, 325)
        Me.RadiotrackingDockPanel.Text = "Radiotracking"
        Me.RadiotrackingDockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'ControlContainer2
        '
        Me.ControlContainer2.Controls.Add(Me.RadiotrackingGridControl)
        Me.ControlContainer2.Location = New System.Drawing.Point(3, 27)
        Me.ControlContainer2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ControlContainer2.Name = "ControlContainer2"
        Me.ControlContainer2.Size = New System.Drawing.Size(1178, 295)
        Me.ControlContainer2.TabIndex = 0
        '
        'CollarFixesDockPanel
        '
        Me.CollarFixesDockPanel.Controls.Add(Me.ControlContainer3)
        Me.CollarFixesDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CollarFixesDockPanel.FloatVertical = True
        Me.CollarFixesDockPanel.ID = New System.Guid("4d9aaa43-bb7c-40ca-9a5b-30faf153743b")
        Me.CollarFixesDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.CollarFixesDockPanel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CollarFixesDockPanel.Name = "CollarFixesDockPanel"
        Me.CollarFixesDockPanel.OriginalSize = New System.Drawing.Size(200, 400)
        Me.CollarFixesDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CollarFixesDockPanel.SavedIndex = 2
        Me.CollarFixesDockPanel.Size = New System.Drawing.Size(1184, 325)
        Me.CollarFixesDockPanel.Text = "Collar fixes"
        Me.CollarFixesDockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'ControlContainer3
        '
        Me.ControlContainer3.Controls.Add(Me.CollarFixesGridControl)
        Me.ControlContainer3.Location = New System.Drawing.Point(3, 28)
        Me.ControlContainer3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ControlContainer3.Name = "ControlContainer3"
        Me.ControlContainer3.Size = New System.Drawing.Size(1178, 294)
        Me.ControlContainer3.TabIndex = 0
        '
        'CapturesDockPanel
        '
        Me.CapturesDockPanel.Controls.Add(Me.DockPanel1_Container)
        Me.CapturesDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CapturesDockPanel.FloatVertical = True
        Me.CapturesDockPanel.ID = New System.Guid("421664d4-2bce-4a99-bef3-f5ffe40525a1")
        Me.CapturesDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.CapturesDockPanel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CapturesDockPanel.Name = "CapturesDockPanel"
        Me.CapturesDockPanel.OriginalSize = New System.Drawing.Size(200, 400)
        Me.CapturesDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CapturesDockPanel.SavedIndex = 0
        Me.CapturesDockPanel.Size = New System.Drawing.Size(1184, 325)
        Me.CapturesDockPanel.Text = "Captures"
        Me.CapturesDockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.CapturesGridControl)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(3, 27)
        Me.DockPanel1_Container.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(1178, 295)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'CapturesGridControl
        '
        Me.CapturesGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CapturesGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CapturesGridControl.Location = New System.Drawing.Point(0, 0)
        Me.CapturesGridControl.MainView = Me.GridView5
        Me.CapturesGridControl.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CapturesGridControl.Name = "CapturesGridControl"
        Me.CapturesGridControl.Size = New System.Drawing.Size(1178, 295)
        Me.CapturesGridControl.TabIndex = 0
        Me.CapturesGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'GridView5
        '
        Me.GridView5.DetailHeight = 284
        Me.GridView5.GridControl = Me.CapturesGridControl
        Me.GridView5.Name = "GridView5"
        '
        'AnimalDockPanel
        '
        Me.AnimalDockPanel.Controls.Add(Me.AnimalDockPanel_Container)
        Me.AnimalDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.AnimalDockPanel.ID = New System.Guid("2fe40c9b-6fbd-4185-a5e1-4e1555659d62")
        Me.AnimalDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.AnimalDockPanel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.AnimalDockPanel.Name = "AnimalDockPanel"
        Me.AnimalDockPanel.OriginalSize = New System.Drawing.Size(269, 200)
        Me.AnimalDockPanel.Size = New System.Drawing.Size(202, 740)
        Me.AnimalDockPanel.Text = "Animal details"
        '
        'AnimalDockPanel_Container
        '
        Me.AnimalDockPanel_Container.Controls.Add(Me.AnimalVGridControl)
        Me.AnimalDockPanel_Container.Controls.Add(Me.AnimalHeaderLabel)
        Me.AnimalDockPanel_Container.Location = New System.Drawing.Point(3, 26)
        Me.AnimalDockPanel_Container.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.AnimalDockPanel_Container.Name = "AnimalDockPanel_Container"
        Me.AnimalDockPanel_Container.Size = New System.Drawing.Size(195, 711)
        Me.AnimalDockPanel_Container.TabIndex = 0
        '
        'SurvivorshipDockPanel
        '
        Me.SurvivorshipDockPanel.Controls.Add(Me.ControlContainer4)
        Me.SurvivorshipDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.SurvivorshipDockPanel.ID = New System.Guid("7a4e046e-e425-4fc3-828c-b281f1e70ab1")
        Me.SurvivorshipDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.SurvivorshipDockPanel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SurvivorshipDockPanel.Name = "SurvivorshipDockPanel"
        Me.SurvivorshipDockPanel.OriginalSize = New System.Drawing.Size(200, 200)
        Me.SurvivorshipDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.SurvivorshipDockPanel.SavedIndex = 1
        Me.SurvivorshipDockPanel.Size = New System.Drawing.Size(1184, 162)
        Me.SurvivorshipDockPanel.Text = "Survivorship"
        Me.SurvivorshipDockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'ControlContainer4
        '
        Me.ControlContainer4.Controls.Add(Me.SurvivorshipGridControl)
        Me.ControlContainer4.Location = New System.Drawing.Point(3, 27)
        Me.ControlContainer4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ControlContainer4.Name = "ControlContainer4"
        Me.ControlContainer4.Size = New System.Drawing.Size(1178, 132)
        Me.ControlContainer4.TabIndex = 0
        '
        'SurvivorshipGridControl
        '
        Me.SurvivorshipGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurvivorshipGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SurvivorshipGridControl.Location = New System.Drawing.Point(0, 0)
        Me.SurvivorshipGridControl.MainView = Me.GridView6
        Me.SurvivorshipGridControl.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SurvivorshipGridControl.Name = "SurvivorshipGridControl"
        Me.SurvivorshipGridControl.Size = New System.Drawing.Size(1178, 132)
        Me.SurvivorshipGridControl.TabIndex = 1
        Me.SurvivorshipGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView6})
        '
        'GridView6
        '
        Me.GridView6.DetailHeight = 284
        Me.GridView6.GridControl = Me.SurvivorshipGridControl
        Me.GridView6.Name = "GridView6"
        '
        'CaribouMapControl
        '
        Me.CaribouMapControl.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CaribouMapControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CaribouMapControl.Location = New System.Drawing.Point(202, 25)
        Me.CaribouMapControl.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CaribouMapControl.Name = "CaribouMapControl"
        Me.CaribouMapControl.Size = New System.Drawing.Size(982, 715)
        Me.CaribouMapControl.TabIndex = 8
        '
        'CaribouProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.CaribouMapControl)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Controls.Add(Me.AnimalDockPanel)
        Me.Controls.Add(Me.hideContainerBottom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CaribouProfileForm"
        Me.Text = "Caribou profile"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        CType(Me.SightingsSurveysGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadiotrackingGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CollarFixesGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnimalVGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeploymentsGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hideContainerBottom.ResumeLayout(False)
        Me.CollarDeploymentsDockPanel.ResumeLayout(False)
        Me.CollarDeploymentsDockPanel_Container.ResumeLayout(False)
        Me.SightingsDockPanel.ResumeLayout(False)
        Me.ControlContainer1.ResumeLayout(False)
        Me.RadiotrackingDockPanel.ResumeLayout(False)
        Me.ControlContainer2.ResumeLayout(False)
        Me.CollarFixesDockPanel.ResumeLayout(False)
        Me.ControlContainer3.ResumeLayout(False)
        Me.CapturesDockPanel.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.CapturesGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AnimalDockPanel.ResumeLayout(False)
        Me.AnimalDockPanel_Container.ResumeLayout(False)
        Me.SurvivorshipDockPanel.ResumeLayout(False)
        Me.ControlContainer4.ResumeLayout(False)
        CType(Me.SurvivorshipGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaribouMapControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents AnimalIDToolStripComboBox As ToolStripComboBox
    Friend WithEvents AnimalVGridControl As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents DeploymentsLabel As Label
    Friend WithEvents AnimalHeaderLabel As Label
    Friend WithEvents DeploymentsGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SightingsSurveysGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RadiotrackingGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CollarFixesGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SyncDatabasesToolStripButton As ToolStripButton
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents CollarDeploymentsDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents CollarDeploymentsDockPanel_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents AnimalDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents AnimalDockPanel_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents CapturesDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents CapturesGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CollarFixesDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents ControlContainer3 As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents RadiotrackingDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents ControlContainer2 As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents SightingsDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents ControlContainer1 As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents hideContainerBottom As DevExpress.XtraBars.Docking.AutoHideContainer
    Friend WithEvents CaribouMapControl As DevExpress.XtraMap.MapControl
    Friend WithEvents SurvivorshipDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents ControlContainer4 As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents SurvivorshipGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
