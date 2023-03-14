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
        Me.EarlyRadiotrackingGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CollarFixesGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AnimalVGridControl = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.AnimalHeaderLabel = New System.Windows.Forms.Label()
        Me.DeploymentsGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DeploymentsLabel = New System.Windows.Forms.Label()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.AnimalDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.AnimalDockPanel_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.CollarDeploymentsDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.CollarDeploymentsDockPanel_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.CapturesDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.CapturesGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SightingsDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.ControlContainer1 = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.EarlyRadiotrackingDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.ControlContainer2 = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.CollarFixesDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.ControlContainer3 = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.CaribouMapControl = New DevExpress.XtraMap.MapControl()
        Me.hideContainerBottom = New DevExpress.XtraBars.Docking.AutoHideContainer()
        Me.MainToolStrip.SuspendLayout()
        CType(Me.SightingsSurveysGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EarlyRadiotrackingGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CollarFixesGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnimalVGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeploymentsGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AnimalDockPanel.SuspendLayout()
        Me.AnimalDockPanel_Container.SuspendLayout()
        Me.CollarDeploymentsDockPanel.SuspendLayout()
        Me.CollarDeploymentsDockPanel_Container.SuspendLayout()
        Me.CapturesDockPanel.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.CapturesGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SightingsDockPanel.SuspendLayout()
        Me.ControlContainer1.SuspendLayout()
        Me.EarlyRadiotrackingDockPanel.SuspendLayout()
        Me.ControlContainer2.SuspendLayout()
        Me.CollarFixesDockPanel.SuspendLayout()
        Me.ControlContainer3.SuspendLayout()
        CType(Me.CaribouMapControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hideContainerBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.AnimalIDToolStripComboBox, Me.ToolStripSeparator1, Me.SyncDatabasesToolStripButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(403, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(1075, 39)
        Me.MainToolStrip.TabIndex = 0
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(187, 36)
        Me.ToolStripLabel1.Text = "Select an animal to profile:"
        '
        'AnimalIDToolStripComboBox
        '
        Me.AnimalIDToolStripComboBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.AnimalIDToolStripComboBox.Name = "AnimalIDToolStripComboBox"
        Me.AnimalIDToolStripComboBox.Size = New System.Drawing.Size(239, 39)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'SyncDatabasesToolStripButton
        '
        Me.SyncDatabasesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SyncDatabasesToolStripButton.Image = CType(resources.GetObject("SyncDatabasesToolStripButton.Image"), System.Drawing.Image)
        Me.SyncDatabasesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SyncDatabasesToolStripButton.Name = "SyncDatabasesToolStripButton"
        Me.SyncDatabasesToolStripButton.Size = New System.Drawing.Size(172, 36)
        Me.SyncDatabasesToolStripButton.Text = "Synchronize databases..."
        '
        'SightingsSurveysGridControl
        '
        Me.SightingsSurveysGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SightingsSurveysGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.SightingsSurveysGridControl.Location = New System.Drawing.Point(0, 0)
        Me.SightingsSurveysGridControl.MainView = Me.GridView2
        Me.SightingsSurveysGridControl.Margin = New System.Windows.Forms.Padding(4)
        Me.SightingsSurveysGridControl.Name = "SightingsSurveysGridControl"
        Me.SightingsSurveysGridControl.Size = New System.Drawing.Size(1571, 162)
        Me.SightingsSurveysGridControl.TabIndex = 3
        Me.SightingsSurveysGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.DetailHeight = 431
        Me.GridView2.GridControl = Me.SightingsSurveysGridControl
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.ReadOnly = True
        Me.GridView2.OptionsSelection.MultiSelect = True
        Me.GridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView2.OptionsView.ShowFooter = True
        '
        'EarlyRadiotrackingGridControl
        '
        Me.EarlyRadiotrackingGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EarlyRadiotrackingGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.EarlyRadiotrackingGridControl.Location = New System.Drawing.Point(0, 0)
        Me.EarlyRadiotrackingGridControl.MainView = Me.GridView3
        Me.EarlyRadiotrackingGridControl.Margin = New System.Windows.Forms.Padding(4)
        Me.EarlyRadiotrackingGridControl.Name = "EarlyRadiotrackingGridControl"
        Me.EarlyRadiotrackingGridControl.Size = New System.Drawing.Size(1571, 73)
        Me.EarlyRadiotrackingGridControl.TabIndex = 4
        Me.EarlyRadiotrackingGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.DetailHeight = 431
        Me.GridView3.GridControl = Me.EarlyRadiotrackingGridControl
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.ReadOnly = True
        Me.GridView3.OptionsSelection.MultiSelect = True
        Me.GridView3.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView3.OptionsView.ShowFooter = True
        '
        'CollarFixesGridControl
        '
        Me.CollarFixesGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CollarFixesGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.CollarFixesGridControl.Location = New System.Drawing.Point(0, 0)
        Me.CollarFixesGridControl.MainView = Me.GridView4
        Me.CollarFixesGridControl.Margin = New System.Windows.Forms.Padding(4)
        Me.CollarFixesGridControl.Name = "CollarFixesGridControl"
        Me.CollarFixesGridControl.Size = New System.Drawing.Size(1571, 95)
        Me.CollarFixesGridControl.TabIndex = 5
        Me.CollarFixesGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.DetailHeight = 431
        Me.GridView4.GridControl = Me.CollarFixesGridControl
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.ReadOnly = True
        Me.GridView4.OptionsSelection.MultiSelect = True
        Me.GridView4.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView4.OptionsView.ShowFooter = True
        '
        'AnimalVGridControl
        '
        Me.AnimalVGridControl.BandsInterval = 3
        Me.AnimalVGridControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.AnimalVGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimalVGridControl.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.AnimalVGridControl.Location = New System.Drawing.Point(0, 54)
        Me.AnimalVGridControl.Margin = New System.Windows.Forms.Padding(4)
        Me.AnimalVGridControl.Name = "AnimalVGridControl"
        Me.AnimalVGridControl.OptionsBehavior.Editable = False
        Me.AnimalVGridControl.OptionsView.FixedLineWidth = 3
        Me.AnimalVGridControl.OptionsView.MinRowAutoHeight = 12
        Me.AnimalVGridControl.Size = New System.Drawing.Size(393, 821)
        Me.AnimalVGridControl.TabIndex = 0
        '
        'AnimalHeaderLabel
        '
        Me.AnimalHeaderLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.AnimalHeaderLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnimalHeaderLabel.Location = New System.Drawing.Point(0, 0)
        Me.AnimalHeaderLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.AnimalHeaderLabel.Name = "AnimalHeaderLabel"
        Me.AnimalHeaderLabel.Size = New System.Drawing.Size(393, 54)
        Me.AnimalHeaderLabel.TabIndex = 3
        Me.AnimalHeaderLabel.Text = "AnimalID"
        '
        'DeploymentsGridControl
        '
        Me.DeploymentsGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeploymentsGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.DeploymentsGridControl.Location = New System.Drawing.Point(0, 34)
        Me.DeploymentsGridControl.MainView = Me.GridView1
        Me.DeploymentsGridControl.Margin = New System.Windows.Forms.Padding(4)
        Me.DeploymentsGridControl.Name = "DeploymentsGridControl"
        Me.DeploymentsGridControl.Size = New System.Drawing.Size(1571, 128)
        Me.DeploymentsGridControl.TabIndex = 2
        Me.DeploymentsGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.DetailHeight = 431
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
        Me.DeploymentsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DeploymentsLabel.Name = "DeploymentsLabel"
        Me.DeploymentsLabel.Size = New System.Drawing.Size(1571, 34)
        Me.DeploymentsLabel.TabIndex = 1
        Me.DeploymentsLabel.Text = "Collar deployments"
        '
        'DockManager1
        '
        Me.DockManager1.AutoHideContainers.AddRange(New DevExpress.XtraBars.Docking.AutoHideContainer() {Me.hideContainerBottom})
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.AnimalDockPanel, Me.CapturesDockPanel})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'AnimalDockPanel
        '
        Me.AnimalDockPanel.Controls.Add(Me.AnimalDockPanel_Container)
        Me.AnimalDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.AnimalDockPanel.ID = New System.Guid("2fe40c9b-6fbd-4185-a5e1-4e1555659d62")
        Me.AnimalDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.AnimalDockPanel.Name = "AnimalDockPanel"
        Me.AnimalDockPanel.OriginalSize = New System.Drawing.Size(403, 200)
        Me.AnimalDockPanel.Size = New System.Drawing.Size(403, 911)
        Me.AnimalDockPanel.Text = "Animal details"
        '
        'AnimalDockPanel_Container
        '
        Me.AnimalDockPanel_Container.Controls.Add(Me.AnimalVGridControl)
        Me.AnimalDockPanel_Container.Controls.Add(Me.AnimalHeaderLabel)
        Me.AnimalDockPanel_Container.Location = New System.Drawing.Point(4, 32)
        Me.AnimalDockPanel_Container.Name = "AnimalDockPanel_Container"
        Me.AnimalDockPanel_Container.Size = New System.Drawing.Size(393, 875)
        Me.AnimalDockPanel_Container.TabIndex = 0
        '
        'CollarDeploymentsDockPanel
        '
        Me.CollarDeploymentsDockPanel.Controls.Add(Me.CollarDeploymentsDockPanel_Container)
        Me.CollarDeploymentsDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CollarDeploymentsDockPanel.ID = New System.Guid("83a4e7e0-a5fe-4c7b-b794-14c82fed3b5a")
        Me.CollarDeploymentsDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.CollarDeploymentsDockPanel.Name = "CollarDeploymentsDockPanel"
        Me.CollarDeploymentsDockPanel.OriginalSize = New System.Drawing.Size(200, 200)
        Me.CollarDeploymentsDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CollarDeploymentsDockPanel.SavedIndex = 1
        Me.CollarDeploymentsDockPanel.Size = New System.Drawing.Size(1579, 200)
        Me.CollarDeploymentsDockPanel.Text = "Collar deployments"
        Me.CollarDeploymentsDockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'CollarDeploymentsDockPanel_Container
        '
        Me.CollarDeploymentsDockPanel_Container.Controls.Add(Me.DeploymentsGridControl)
        Me.CollarDeploymentsDockPanel_Container.Controls.Add(Me.DeploymentsLabel)
        Me.CollarDeploymentsDockPanel_Container.Location = New System.Drawing.Point(4, 34)
        Me.CollarDeploymentsDockPanel_Container.Name = "CollarDeploymentsDockPanel_Container"
        Me.CollarDeploymentsDockPanel_Container.Size = New System.Drawing.Size(1571, 162)
        Me.CollarDeploymentsDockPanel_Container.TabIndex = 0
        '
        'CapturesDockPanel
        '
        Me.CapturesDockPanel.Controls.Add(Me.DockPanel1_Container)
        Me.CapturesDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CapturesDockPanel.ID = New System.Guid("421664d4-2bce-4a99-bef3-f5ffe40525a1")
        Me.CapturesDockPanel.Location = New System.Drawing.Point(403, 711)
        Me.CapturesDockPanel.Name = "CapturesDockPanel"
        Me.CapturesDockPanel.OriginalSize = New System.Drawing.Size(200, 200)
        Me.CapturesDockPanel.Size = New System.Drawing.Size(1176, 200)
        Me.CapturesDockPanel.Text = "Captures"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.CapturesGridControl)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 34)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(1168, 162)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'CapturesGridControl
        '
        Me.CapturesGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CapturesGridControl.Location = New System.Drawing.Point(0, 0)
        Me.CapturesGridControl.MainView = Me.GridView5
        Me.CapturesGridControl.Name = "CapturesGridControl"
        Me.CapturesGridControl.Size = New System.Drawing.Size(1168, 162)
        Me.CapturesGridControl.TabIndex = 0
        Me.CapturesGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.CapturesGridControl
        Me.GridView5.Name = "GridView5"
        '
        'SightingsDockPanel
        '
        Me.SightingsDockPanel.Controls.Add(Me.ControlContainer1)
        Me.SightingsDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.SightingsDockPanel.ID = New System.Guid("a6fcc7a3-b95a-4b55-887d-ebd5553d22c8")
        Me.SightingsDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.SightingsDockPanel.Name = "SightingsDockPanel"
        Me.SightingsDockPanel.OriginalSize = New System.Drawing.Size(200, 200)
        Me.SightingsDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.SightingsDockPanel.SavedIndex = 2
        Me.SightingsDockPanel.Size = New System.Drawing.Size(1579, 200)
        Me.SightingsDockPanel.Text = "Sightings"
        Me.SightingsDockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'ControlContainer1
        '
        Me.ControlContainer1.Controls.Add(Me.SightingsSurveysGridControl)
        Me.ControlContainer1.Location = New System.Drawing.Point(4, 34)
        Me.ControlContainer1.Name = "ControlContainer1"
        Me.ControlContainer1.Size = New System.Drawing.Size(1571, 162)
        Me.ControlContainer1.TabIndex = 0
        '
        'EarlyRadiotrackingDockPanel
        '
        Me.EarlyRadiotrackingDockPanel.Controls.Add(Me.ControlContainer2)
        Me.EarlyRadiotrackingDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.EarlyRadiotrackingDockPanel.ID = New System.Guid("65483a37-2711-4c35-ba1a-3827756e5b9f")
        Me.EarlyRadiotrackingDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.EarlyRadiotrackingDockPanel.Name = "EarlyRadiotrackingDockPanel"
        Me.EarlyRadiotrackingDockPanel.OriginalSize = New System.Drawing.Size(200, 111)
        Me.EarlyRadiotrackingDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.EarlyRadiotrackingDockPanel.SavedIndex = 2
        Me.EarlyRadiotrackingDockPanel.Size = New System.Drawing.Size(1579, 111)
        Me.EarlyRadiotrackingDockPanel.Text = "Early radiotracking"
        Me.EarlyRadiotrackingDockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'ControlContainer2
        '
        Me.ControlContainer2.Controls.Add(Me.EarlyRadiotrackingGridControl)
        Me.ControlContainer2.Location = New System.Drawing.Point(4, 34)
        Me.ControlContainer2.Name = "ControlContainer2"
        Me.ControlContainer2.Size = New System.Drawing.Size(1571, 73)
        Me.ControlContainer2.TabIndex = 0
        '
        'CollarFixesDockPanel
        '
        Me.CollarFixesDockPanel.Controls.Add(Me.ControlContainer3)
        Me.CollarFixesDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CollarFixesDockPanel.FloatVertical = True
        Me.CollarFixesDockPanel.ID = New System.Guid("4d9aaa43-bb7c-40ca-9a5b-30faf153743b")
        Me.CollarFixesDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.CollarFixesDockPanel.Name = "CollarFixesDockPanel"
        Me.CollarFixesDockPanel.OriginalSize = New System.Drawing.Size(200, 133)
        Me.CollarFixesDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CollarFixesDockPanel.SavedIndex = 2
        Me.CollarFixesDockPanel.Size = New System.Drawing.Size(1579, 133)
        Me.CollarFixesDockPanel.Text = "Collar fixes"
        Me.CollarFixesDockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'ControlContainer3
        '
        Me.ControlContainer3.Controls.Add(Me.CollarFixesGridControl)
        Me.ControlContainer3.Location = New System.Drawing.Point(4, 34)
        Me.ControlContainer3.Name = "ControlContainer3"
        Me.ControlContainer3.Size = New System.Drawing.Size(1571, 95)
        Me.ControlContainer3.TabIndex = 0
        '
        'CaribouMapControl
        '
        Me.CaribouMapControl.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CaribouMapControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CaribouMapControl.Location = New System.Drawing.Point(504, 49)
        Me.CaribouMapControl.Name = "CaribouMapControl"
        Me.CaribouMapControl.Size = New System.Drawing.Size(1075, 558)
        Me.CaribouMapControl.TabIndex = 8
        '
        'hideContainerBottom
        '
        Me.hideContainerBottom.BackColor = System.Drawing.SystemColors.Control
        Me.hideContainerBottom.Controls.Add(Me.CollarDeploymentsDockPanel)
        Me.hideContainerBottom.Controls.Add(Me.SightingsDockPanel)
        Me.hideContainerBottom.Controls.Add(Me.EarlyRadiotrackingDockPanel)
        Me.hideContainerBottom.Controls.Add(Me.CollarFixesDockPanel)
        Me.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.hideContainerBottom.Location = New System.Drawing.Point(0, 873)
        Me.hideContainerBottom.Name = "hideContainerBottom"
        Me.hideContainerBottom.Size = New System.Drawing.Size(1579, 64)
        '
        'CaribouProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1579, 937)
        Me.Controls.Add(Me.CaribouMapControl)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Controls.Add(Me.CapturesDockPanel)
        Me.Controls.Add(Me.AnimalDockPanel)
        Me.Controls.Add(Me.hideContainerBottom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CaribouProfileForm"
        Me.Text = "Caribou profile"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        CType(Me.SightingsSurveysGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EarlyRadiotrackingGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CollarFixesGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnimalVGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeploymentsGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AnimalDockPanel.ResumeLayout(False)
        Me.AnimalDockPanel_Container.ResumeLayout(False)
        Me.CollarDeploymentsDockPanel.ResumeLayout(False)
        Me.CollarDeploymentsDockPanel_Container.ResumeLayout(False)
        Me.CapturesDockPanel.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.CapturesGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SightingsDockPanel.ResumeLayout(False)
        Me.ControlContainer1.ResumeLayout(False)
        Me.EarlyRadiotrackingDockPanel.ResumeLayout(False)
        Me.ControlContainer2.ResumeLayout(False)
        Me.CollarFixesDockPanel.ResumeLayout(False)
        Me.ControlContainer3.ResumeLayout(False)
        CType(Me.CaribouMapControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hideContainerBottom.ResumeLayout(False)
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
    Friend WithEvents EarlyRadiotrackingGridControl As DevExpress.XtraGrid.GridControl
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
    Friend WithEvents EarlyRadiotrackingDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents ControlContainer2 As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents SightingsDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents ControlContainer1 As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents hideContainerBottom As DevExpress.XtraBars.Docking.AutoHideContainer
    Friend WithEvents CaribouMapControl As DevExpress.XtraMap.MapControl
End Class
