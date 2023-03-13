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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.AnimalTabControl = New System.Windows.Forms.TabControl()
        Me.SurveySightingsTabPage = New System.Windows.Forms.TabPage()
        Me.SightingsSurveysGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.EarlyRadiotrackingTabPage = New System.Windows.Forms.TabPage()
        Me.EarlyRadiotrackingGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AnimalFixesTabPage = New System.Windows.Forms.TabPage()
        Me.CollarFixesGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CapturesTabPage = New System.Windows.Forms.TabPage()
        Me.AnimalVGridControl = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.AnimalLabel = New System.Windows.Forms.Label()
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
        Me.MainToolStrip.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.AnimalTabControl.SuspendLayout()
        Me.SurveySightingsTabPage.SuspendLayout()
        CType(Me.SightingsSurveysGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EarlyRadiotrackingTabPage.SuspendLayout()
        CType(Me.EarlyRadiotrackingGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AnimalFixesTabPage.SuspendLayout()
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
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.AnimalIDToolStripComboBox, Me.ToolStripSeparator1, Me.SyncDatabasesToolStripButton})
        Me.MainToolStrip.Location = New System.Drawing.Point(403, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(1176, 28)
        Me.MainToolStrip.TabIndex = 0
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(187, 25)
        Me.ToolStripLabel1.Text = "Select an animal to profile:"
        '
        'AnimalIDToolStripComboBox
        '
        Me.AnimalIDToolStripComboBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.AnimalIDToolStripComboBox.Name = "AnimalIDToolStripComboBox"
        Me.AnimalIDToolStripComboBox.Size = New System.Drawing.Size(239, 28)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 28)
        '
        'SyncDatabasesToolStripButton
        '
        Me.SyncDatabasesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SyncDatabasesToolStripButton.Image = CType(resources.GetObject("SyncDatabasesToolStripButton.Image"), System.Drawing.Image)
        Me.SyncDatabasesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SyncDatabasesToolStripButton.Name = "SyncDatabasesToolStripButton"
        Me.SyncDatabasesToolStripButton.Size = New System.Drawing.Size(172, 25)
        Me.SyncDatabasesToolStripButton.Text = "Synchronize databases..."
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(403, 28)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.AnimalTabControl)
        Me.SplitContainer1.Size = New System.Drawing.Size(1176, 509)
        Me.SplitContainer1.SplitterDistance = 391
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 1
        '
        'AnimalTabControl
        '
        Me.AnimalTabControl.Controls.Add(Me.SurveySightingsTabPage)
        Me.AnimalTabControl.Controls.Add(Me.EarlyRadiotrackingTabPage)
        Me.AnimalTabControl.Controls.Add(Me.AnimalFixesTabPage)
        Me.AnimalTabControl.Controls.Add(Me.CapturesTabPage)
        Me.AnimalTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimalTabControl.Location = New System.Drawing.Point(0, 0)
        Me.AnimalTabControl.Margin = New System.Windows.Forms.Padding(4)
        Me.AnimalTabControl.Name = "AnimalTabControl"
        Me.AnimalTabControl.SelectedIndex = 0
        Me.AnimalTabControl.Size = New System.Drawing.Size(780, 509)
        Me.AnimalTabControl.TabIndex = 0
        '
        'SurveySightingsTabPage
        '
        Me.SurveySightingsTabPage.Controls.Add(Me.SightingsSurveysGridControl)
        Me.SurveySightingsTabPage.Location = New System.Drawing.Point(4, 25)
        Me.SurveySightingsTabPage.Margin = New System.Windows.Forms.Padding(4)
        Me.SurveySightingsTabPage.Name = "SurveySightingsTabPage"
        Me.SurveySightingsTabPage.Padding = New System.Windows.Forms.Padding(4)
        Me.SurveySightingsTabPage.Size = New System.Drawing.Size(772, 480)
        Me.SurveySightingsTabPage.TabIndex = 1
        Me.SurveySightingsTabPage.Text = "Sightings (surveys)"
        Me.SurveySightingsTabPage.UseVisualStyleBackColor = True
        '
        'SightingsSurveysGridControl
        '
        Me.SightingsSurveysGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SightingsSurveysGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.SightingsSurveysGridControl.Location = New System.Drawing.Point(4, 4)
        Me.SightingsSurveysGridControl.MainView = Me.GridView2
        Me.SightingsSurveysGridControl.Margin = New System.Windows.Forms.Padding(4)
        Me.SightingsSurveysGridControl.Name = "SightingsSurveysGridControl"
        Me.SightingsSurveysGridControl.Size = New System.Drawing.Size(764, 472)
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
        'EarlyRadiotrackingTabPage
        '
        Me.EarlyRadiotrackingTabPage.Controls.Add(Me.EarlyRadiotrackingGridControl)
        Me.EarlyRadiotrackingTabPage.Location = New System.Drawing.Point(4, 25)
        Me.EarlyRadiotrackingTabPage.Margin = New System.Windows.Forms.Padding(4)
        Me.EarlyRadiotrackingTabPage.Name = "EarlyRadiotrackingTabPage"
        Me.EarlyRadiotrackingTabPage.Padding = New System.Windows.Forms.Padding(4)
        Me.EarlyRadiotrackingTabPage.Size = New System.Drawing.Size(772, 680)
        Me.EarlyRadiotrackingTabPage.TabIndex = 2
        Me.EarlyRadiotrackingTabPage.Text = "Sightings (early radiotracking)"
        Me.EarlyRadiotrackingTabPage.UseVisualStyleBackColor = True
        '
        'EarlyRadiotrackingGridControl
        '
        Me.EarlyRadiotrackingGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EarlyRadiotrackingGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.EarlyRadiotrackingGridControl.Location = New System.Drawing.Point(4, 4)
        Me.EarlyRadiotrackingGridControl.MainView = Me.GridView3
        Me.EarlyRadiotrackingGridControl.Margin = New System.Windows.Forms.Padding(4)
        Me.EarlyRadiotrackingGridControl.Name = "EarlyRadiotrackingGridControl"
        Me.EarlyRadiotrackingGridControl.Size = New System.Drawing.Size(764, 672)
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
        'AnimalFixesTabPage
        '
        Me.AnimalFixesTabPage.Controls.Add(Me.CollarFixesGridControl)
        Me.AnimalFixesTabPage.Location = New System.Drawing.Point(4, 25)
        Me.AnimalFixesTabPage.Margin = New System.Windows.Forms.Padding(4)
        Me.AnimalFixesTabPage.Name = "AnimalFixesTabPage"
        Me.AnimalFixesTabPage.Padding = New System.Windows.Forms.Padding(4)
        Me.AnimalFixesTabPage.Size = New System.Drawing.Size(772, 680)
        Me.AnimalFixesTabPage.TabIndex = 3
        Me.AnimalFixesTabPage.Text = "Collar fixes"
        Me.AnimalFixesTabPage.UseVisualStyleBackColor = True
        '
        'CollarFixesGridControl
        '
        Me.CollarFixesGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CollarFixesGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.CollarFixesGridControl.Location = New System.Drawing.Point(4, 4)
        Me.CollarFixesGridControl.MainView = Me.GridView4
        Me.CollarFixesGridControl.Margin = New System.Windows.Forms.Padding(4)
        Me.CollarFixesGridControl.Name = "CollarFixesGridControl"
        Me.CollarFixesGridControl.Size = New System.Drawing.Size(764, 672)
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
        'CapturesTabPage
        '
        Me.CapturesTabPage.Location = New System.Drawing.Point(4, 25)
        Me.CapturesTabPage.Name = "CapturesTabPage"
        Me.CapturesTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.CapturesTabPage.Size = New System.Drawing.Size(772, 680)
        Me.CapturesTabPage.TabIndex = 4
        Me.CapturesTabPage.Text = "Captures"
        Me.CapturesTabPage.UseVisualStyleBackColor = True
        '
        'AnimalVGridControl
        '
        Me.AnimalVGridControl.BandsInterval = 3
        Me.AnimalVGridControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.AnimalVGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimalVGridControl.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.AnimalVGridControl.Location = New System.Drawing.Point(0, 139)
        Me.AnimalVGridControl.Margin = New System.Windows.Forms.Padding(4)
        Me.AnimalVGridControl.Name = "AnimalVGridControl"
        Me.AnimalVGridControl.OptionsBehavior.Editable = False
        Me.AnimalVGridControl.OptionsView.FixedLineWidth = 3
        Me.AnimalVGridControl.OptionsView.MinRowAutoHeight = 12
        Me.AnimalVGridControl.Size = New System.Drawing.Size(393, 762)
        Me.AnimalVGridControl.TabIndex = 0
        '
        'AnimalLabel
        '
        Me.AnimalLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.AnimalLabel.Location = New System.Drawing.Point(0, 54)
        Me.AnimalLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.AnimalLabel.Name = "AnimalLabel"
        Me.AnimalLabel.Size = New System.Drawing.Size(393, 85)
        Me.AnimalLabel.TabIndex = 2
        Me.AnimalLabel.Text = "Animal details"
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
        Me.DeploymentsGridControl.Size = New System.Drawing.Size(1168, 128)
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
        Me.DeploymentsLabel.Size = New System.Drawing.Size(1168, 34)
        Me.DeploymentsLabel.TabIndex = 1
        Me.DeploymentsLabel.Text = "Collar deployments"
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.AnimalDockPanel, Me.CollarDeploymentsDockPanel, Me.CapturesDockPanel})
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
        Me.AnimalDockPanel.Size = New System.Drawing.Size(403, 937)
        Me.AnimalDockPanel.Text = "Animal details"
        '
        'AnimalDockPanel_Container
        '
        Me.AnimalDockPanel_Container.Controls.Add(Me.AnimalVGridControl)
        Me.AnimalDockPanel_Container.Controls.Add(Me.AnimalLabel)
        Me.AnimalDockPanel_Container.Controls.Add(Me.AnimalHeaderLabel)
        Me.AnimalDockPanel_Container.Location = New System.Drawing.Point(4, 32)
        Me.AnimalDockPanel_Container.Name = "AnimalDockPanel_Container"
        Me.AnimalDockPanel_Container.Size = New System.Drawing.Size(393, 901)
        Me.AnimalDockPanel_Container.TabIndex = 0
        '
        'CollarDeploymentsDockPanel
        '
        Me.CollarDeploymentsDockPanel.Controls.Add(Me.CollarDeploymentsDockPanel_Container)
        Me.CollarDeploymentsDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CollarDeploymentsDockPanel.ID = New System.Guid("83a4e7e0-a5fe-4c7b-b794-14c82fed3b5a")
        Me.CollarDeploymentsDockPanel.Location = New System.Drawing.Point(403, 737)
        Me.CollarDeploymentsDockPanel.Name = "CollarDeploymentsDockPanel"
        Me.CollarDeploymentsDockPanel.OriginalSize = New System.Drawing.Size(200, 200)
        Me.CollarDeploymentsDockPanel.Size = New System.Drawing.Size(1176, 200)
        Me.CollarDeploymentsDockPanel.Text = "Collar deployments"
        '
        'CollarDeploymentsDockPanel_Container
        '
        Me.CollarDeploymentsDockPanel_Container.Controls.Add(Me.DeploymentsGridControl)
        Me.CollarDeploymentsDockPanel_Container.Controls.Add(Me.DeploymentsLabel)
        Me.CollarDeploymentsDockPanel_Container.Location = New System.Drawing.Point(4, 34)
        Me.CollarDeploymentsDockPanel_Container.Name = "CollarDeploymentsDockPanel_Container"
        Me.CollarDeploymentsDockPanel_Container.Size = New System.Drawing.Size(1168, 162)
        Me.CollarDeploymentsDockPanel_Container.TabIndex = 0
        '
        'CapturesDockPanel
        '
        Me.CapturesDockPanel.Controls.Add(Me.DockPanel1_Container)
        Me.CapturesDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.CapturesDockPanel.ID = New System.Guid("421664d4-2bce-4a99-bef3-f5ffe40525a1")
        Me.CapturesDockPanel.Location = New System.Drawing.Point(403, 537)
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
        'CaribouProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1579, 937)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Controls.Add(Me.CapturesDockPanel)
        Me.Controls.Add(Me.CollarDeploymentsDockPanel)
        Me.Controls.Add(Me.AnimalDockPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CaribouProfileForm"
        Me.Text = "Caribou profile"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.AnimalTabControl.ResumeLayout(False)
        Me.SurveySightingsTabPage.ResumeLayout(False)
        CType(Me.SightingsSurveysGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EarlyRadiotrackingTabPage.ResumeLayout(False)
        CType(Me.EarlyRadiotrackingGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AnimalFixesTabPage.ResumeLayout(False)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents AnimalIDToolStripComboBox As ToolStripComboBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents AnimalVGridControl As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents AnimalTabControl As TabControl
    Friend WithEvents SurveySightingsTabPage As TabPage
    Friend WithEvents EarlyRadiotrackingTabPage As TabPage
    Friend WithEvents AnimalLabel As Label
    Friend WithEvents DeploymentsLabel As Label
    Friend WithEvents AnimalHeaderLabel As Label
    Friend WithEvents DeploymentsGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SightingsSurveysGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents EarlyRadiotrackingGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents AnimalFixesTabPage As TabPage
    Friend WithEvents CollarFixesGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SyncDatabasesToolStripButton As ToolStripButton
    Friend WithEvents CapturesTabPage As TabPage
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents CollarDeploymentsDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents CollarDeploymentsDockPanel_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents AnimalDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents AnimalDockPanel_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents CapturesDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents CapturesGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
