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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaribouProfileForm))
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.AnimalIDToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.AnimalSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.AnimalVGridControl = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.AnimalLabel = New System.Windows.Forms.Label()
        Me.AnimalHeaderLabel = New System.Windows.Forms.Label()
        Me.DeploymentsGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DeploymentsLabel = New System.Windows.Forms.Label()
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
        Me.MainToolStrip.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.AnimalSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AnimalSplitContainer.Panel1.SuspendLayout()
        Me.AnimalSplitContainer.Panel2.SuspendLayout()
        Me.AnimalSplitContainer.SuspendLayout()
        CType(Me.AnimalVGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeploymentsGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuspendLayout()
        '
        'MainToolStrip
        '
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.AnimalIDToolStripComboBox})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(1184, 25)
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.AnimalSplitContainer)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.AnimalTabControl)
        Me.SplitContainer1.Size = New System.Drawing.Size(1184, 736)
        Me.SplitContainer1.SplitterDistance = 394
        Me.SplitContainer1.TabIndex = 1
        '
        'AnimalSplitContainer
        '
        Me.AnimalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimalSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.AnimalSplitContainer.Name = "AnimalSplitContainer"
        Me.AnimalSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'AnimalSplitContainer.Panel1
        '
        Me.AnimalSplitContainer.Panel1.Controls.Add(Me.AnimalVGridControl)
        Me.AnimalSplitContainer.Panel1.Controls.Add(Me.AnimalLabel)
        Me.AnimalSplitContainer.Panel1.Controls.Add(Me.AnimalHeaderLabel)
        '
        'AnimalSplitContainer.Panel2
        '
        Me.AnimalSplitContainer.Panel2.Controls.Add(Me.DeploymentsGridControl)
        Me.AnimalSplitContainer.Panel2.Controls.Add(Me.DeploymentsLabel)
        Me.AnimalSplitContainer.Size = New System.Drawing.Size(394, 736)
        Me.AnimalSplitContainer.SplitterDistance = 327
        Me.AnimalSplitContainer.TabIndex = 1
        '
        'AnimalVGridControl
        '
        Me.AnimalVGridControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.AnimalVGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimalVGridControl.Location = New System.Drawing.Point(0, 44)
        Me.AnimalVGridControl.Name = "AnimalVGridControl"
        Me.AnimalVGridControl.OptionsBehavior.Editable = False
        Me.AnimalVGridControl.Size = New System.Drawing.Size(394, 283)
        Me.AnimalVGridControl.TabIndex = 0
        '
        'AnimalLabel
        '
        Me.AnimalLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.AnimalLabel.Location = New System.Drawing.Point(0, 22)
        Me.AnimalLabel.Name = "AnimalLabel"
        Me.AnimalLabel.Size = New System.Drawing.Size(394, 22)
        Me.AnimalLabel.TabIndex = 2
        Me.AnimalLabel.Text = "Animal details"
        '
        'AnimalHeaderLabel
        '
        Me.AnimalHeaderLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.AnimalHeaderLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnimalHeaderLabel.Location = New System.Drawing.Point(0, 0)
        Me.AnimalHeaderLabel.Name = "AnimalHeaderLabel"
        Me.AnimalHeaderLabel.Size = New System.Drawing.Size(394, 22)
        Me.AnimalHeaderLabel.TabIndex = 3
        Me.AnimalHeaderLabel.Text = "AnimalID"
        '
        'DeploymentsGridControl
        '
        Me.DeploymentsGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeploymentsGridControl.Location = New System.Drawing.Point(0, 22)
        Me.DeploymentsGridControl.MainView = Me.GridView1
        Me.DeploymentsGridControl.Name = "DeploymentsGridControl"
        Me.DeploymentsGridControl.Size = New System.Drawing.Size(394, 383)
        Me.DeploymentsGridControl.TabIndex = 2
        Me.DeploymentsGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DeploymentsGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'DeploymentsLabel
        '
        Me.DeploymentsLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.DeploymentsLabel.Location = New System.Drawing.Point(0, 0)
        Me.DeploymentsLabel.Name = "DeploymentsLabel"
        Me.DeploymentsLabel.Size = New System.Drawing.Size(394, 22)
        Me.DeploymentsLabel.TabIndex = 1
        Me.DeploymentsLabel.Text = "Collar deployments"
        '
        'AnimalTabControl
        '
        Me.AnimalTabControl.Controls.Add(Me.SurveySightingsTabPage)
        Me.AnimalTabControl.Controls.Add(Me.EarlyRadiotrackingTabPage)
        Me.AnimalTabControl.Controls.Add(Me.AnimalFixesTabPage)
        Me.AnimalTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimalTabControl.Location = New System.Drawing.Point(0, 0)
        Me.AnimalTabControl.Name = "AnimalTabControl"
        Me.AnimalTabControl.SelectedIndex = 0
        Me.AnimalTabControl.Size = New System.Drawing.Size(786, 736)
        Me.AnimalTabControl.TabIndex = 0
        '
        'SurveySightingsTabPage
        '
        Me.SurveySightingsTabPage.Controls.Add(Me.SightingsSurveysGridControl)
        Me.SurveySightingsTabPage.Location = New System.Drawing.Point(4, 22)
        Me.SurveySightingsTabPage.Name = "SurveySightingsTabPage"
        Me.SurveySightingsTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SurveySightingsTabPage.Size = New System.Drawing.Size(778, 710)
        Me.SurveySightingsTabPage.TabIndex = 1
        Me.SurveySightingsTabPage.Text = "Sightings (surveys)"
        Me.SurveySightingsTabPage.UseVisualStyleBackColor = True
        '
        'SightingsSurveysGridControl
        '
        Me.SightingsSurveysGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SightingsSurveysGridControl.Location = New System.Drawing.Point(3, 3)
        Me.SightingsSurveysGridControl.MainView = Me.GridView2
        Me.SightingsSurveysGridControl.Name = "SightingsSurveysGridControl"
        Me.SightingsSurveysGridControl.Size = New System.Drawing.Size(772, 704)
        Me.SightingsSurveysGridControl.TabIndex = 3
        Me.SightingsSurveysGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.SightingsSurveysGridControl
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.MultiSelect = True
        Me.GridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView2.OptionsView.ShowFooter = True
        '
        'EarlyRadiotrackingTabPage
        '
        Me.EarlyRadiotrackingTabPage.Controls.Add(Me.EarlyRadiotrackingGridControl)
        Me.EarlyRadiotrackingTabPage.Location = New System.Drawing.Point(4, 22)
        Me.EarlyRadiotrackingTabPage.Name = "EarlyRadiotrackingTabPage"
        Me.EarlyRadiotrackingTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.EarlyRadiotrackingTabPage.Size = New System.Drawing.Size(778, 710)
        Me.EarlyRadiotrackingTabPage.TabIndex = 2
        Me.EarlyRadiotrackingTabPage.Text = "Sightings (early radiotracking)"
        Me.EarlyRadiotrackingTabPage.UseVisualStyleBackColor = True
        '
        'EarlyRadiotrackingGridControl
        '
        Me.EarlyRadiotrackingGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EarlyRadiotrackingGridControl.Location = New System.Drawing.Point(3, 3)
        Me.EarlyRadiotrackingGridControl.MainView = Me.GridView3
        Me.EarlyRadiotrackingGridControl.Name = "EarlyRadiotrackingGridControl"
        Me.EarlyRadiotrackingGridControl.Size = New System.Drawing.Size(772, 704)
        Me.EarlyRadiotrackingGridControl.TabIndex = 4
        Me.EarlyRadiotrackingGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.EarlyRadiotrackingGridControl
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.MultiSelect = True
        Me.GridView3.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView3.OptionsView.ShowFooter = True
        '
        'AnimalFixesTabPage
        '
        Me.AnimalFixesTabPage.Controls.Add(Me.CollarFixesGridControl)
        Me.AnimalFixesTabPage.Location = New System.Drawing.Point(4, 22)
        Me.AnimalFixesTabPage.Name = "AnimalFixesTabPage"
        Me.AnimalFixesTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.AnimalFixesTabPage.Size = New System.Drawing.Size(778, 710)
        Me.AnimalFixesTabPage.TabIndex = 3
        Me.AnimalFixesTabPage.Text = "Collar fixes"
        Me.AnimalFixesTabPage.UseVisualStyleBackColor = True
        '
        'CollarFixesGridControl
        '
        Me.CollarFixesGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CollarFixesGridControl.Location = New System.Drawing.Point(3, 3)
        Me.CollarFixesGridControl.MainView = Me.GridView4
        Me.CollarFixesGridControl.Name = "CollarFixesGridControl"
        Me.CollarFixesGridControl.Size = New System.Drawing.Size(772, 704)
        Me.CollarFixesGridControl.TabIndex = 5
        Me.CollarFixesGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.CollarFixesGridControl
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.MultiSelect = True
        Me.GridView4.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView4.OptionsView.ShowFooter = True
        '
        'CaribouProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CaribouProfileForm"
        Me.Text = "Caribou profile"
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.AnimalSplitContainer.Panel1.ResumeLayout(False)
        Me.AnimalSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.AnimalSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AnimalSplitContainer.ResumeLayout(False)
        CType(Me.AnimalVGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeploymentsGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents AnimalSplitContainer As SplitContainer
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
End Class
