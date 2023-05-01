<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatasetForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatasetForm))
        Me.DatasetGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DatasetGridControlToolStrip = New System.Windows.Forms.ToolStrip()
        Me.LoadDatasetToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ExportDatasetToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.DockManager = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.DatasetPivotGridControl = New DevExpress.XtraPivotGrid.PivotGridControl()
        Me.DatastePivotGridToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ExportPivotGridToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.DatasetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.DatasetSelectorToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.FooterToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SqlToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        CType(Me.DatasetGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DatasetGridControlToolStrip.SuspendLayout()
        CType(Me.DockManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.DatasetPivotGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DatastePivotGridToolStrip.SuspendLayout()
        CType(Me.DatasetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FooterToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'DatasetGridControl
        '
        Me.DatasetGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DatasetGridControl.Location = New System.Drawing.Point(0, 25)
        Me.DatasetGridControl.MainView = Me.GridView1
        Me.DatasetGridControl.Name = "DatasetGridControl"
        Me.DatasetGridControl.Size = New System.Drawing.Size(1187, 291)
        Me.DatasetGridControl.TabIndex = 0
        Me.DatasetGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DatasetGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'DatasetGridControlToolStrip
        '
        Me.DatasetGridControlToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.DatasetSelectorToolStripComboBox, Me.ToolStripSeparator3, Me.LoadDatasetToolStripButton, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.ExportDatasetToolStripComboBox, Me.ToolStripSeparator2})
        Me.DatasetGridControlToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.DatasetGridControlToolStrip.Name = "DatasetGridControlToolStrip"
        Me.DatasetGridControlToolStrip.Size = New System.Drawing.Size(1187, 25)
        Me.DatasetGridControlToolStrip.TabIndex = 1
        Me.DatasetGridControlToolStrip.Text = "ToolStrip1"
        '
        'LoadDatasetToolStripButton
        '
        Me.LoadDatasetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LoadDatasetToolStripButton.Image = CType(resources.GetObject("LoadDatasetToolStripButton.Image"), System.Drawing.Image)
        Me.LoadDatasetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadDatasetToolStripButton.Name = "LoadDatasetToolStripButton"
        Me.LoadDatasetToolStripButton.Size = New System.Drawing.Size(91, 22)
        Me.LoadDatasetToolStripButton.Text = "Refresh dataset"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(44, 22)
        Me.ToolStripLabel1.Text = "Export:"
        '
        'ExportDatasetToolStripComboBox
        '
        Me.ExportDatasetToolStripComboBox.Items.AddRange(New Object() {"", "Comma separated values text file", "Microsoft Excel"})
        Me.ExportDatasetToolStripComboBox.Name = "ExportDatasetToolStripComboBox"
        Me.ExportDatasetToolStripComboBox.Size = New System.Drawing.Size(121, 25)
        '
        'DockManager
        '
        Me.DockManager.Form = Me
        Me.DockManager.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.DockPanel1.ID = New System.Guid("9d5f8463-3ae7-43c9-b9e3-caab9103caf3")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 316)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(200, 405)
        Me.DockPanel1.Size = New System.Drawing.Size(1187, 405)
        Me.DockPanel1.Text = "Pivot table generator"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.DatasetPivotGridControl)
        Me.DockPanel1_Container.Controls.Add(Me.DatastePivotGridToolStrip)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(3, 27)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(1181, 375)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'DatasetPivotGridControl
        '
        Me.DatasetPivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DatasetPivotGridControl.Location = New System.Drawing.Point(0, 25)
        Me.DatasetPivotGridControl.Name = "DatasetPivotGridControl"
        Me.DatasetPivotGridControl.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Optimized
        Me.DatasetPivotGridControl.Size = New System.Drawing.Size(1181, 350)
        Me.DatasetPivotGridControl.TabIndex = 0
        '
        'DatastePivotGridToolStrip
        '
        Me.DatastePivotGridToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ExportPivotGridToolStripComboBox})
        Me.DatastePivotGridToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.DatastePivotGridToolStrip.Name = "DatastePivotGridToolStrip"
        Me.DatastePivotGridToolStrip.Size = New System.Drawing.Size(1181, 25)
        Me.DatastePivotGridToolStrip.TabIndex = 1
        Me.DatastePivotGridToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(44, 22)
        Me.ToolStripLabel2.Text = "Export:"
        '
        'ExportPivotGridToolStripComboBox
        '
        Me.ExportPivotGridToolStripComboBox.Items.AddRange(New Object() {"", "Comma separated values text file", "Microsoft Excel"})
        Me.ExportPivotGridToolStripComboBox.Name = "ExportPivotGridToolStripComboBox"
        Me.ExportPivotGridToolStripComboBox.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(91, 22)
        Me.ToolStripLabel3.Text = "Select a dataset:"
        '
        'DatasetSelectorToolStripComboBox
        '
        Me.DatasetSelectorToolStripComboBox.Items.AddRange(New Object() {"", "Aerial survey", "Radiotracking"})
        Me.DatasetSelectorToolStripComboBox.Name = "DatasetSelectorToolStripComboBox"
        Me.DatasetSelectorToolStripComboBox.Size = New System.Drawing.Size(121, 25)
        '
        'FooterToolStrip
        '
        Me.FooterToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FooterToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SqlToolStripLabel})
        Me.FooterToolStrip.Location = New System.Drawing.Point(0, 721)
        Me.FooterToolStrip.Name = "FooterToolStrip"
        Me.FooterToolStrip.Size = New System.Drawing.Size(1187, 25)
        Me.FooterToolStrip.TabIndex = 2
        Me.FooterToolStrip.Text = "ToolStrip1"
        '
        'SqlToolStripLabel
        '
        Me.SqlToolStripLabel.Name = "SqlToolStripLabel"
        Me.SqlToolStripLabel.Size = New System.Drawing.Size(42, 22)
        Me.SqlToolStripLabel.Text = "Query:"
        '
        'DatasetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1187, 746)
        Me.Controls.Add(Me.DatasetGridControl)
        Me.Controls.Add(Me.DatasetGridControlToolStrip)
        Me.Controls.Add(Me.DockPanel1)
        Me.Controls.Add(Me.FooterToolStrip)
        Me.Name = "DatasetForm"
        Me.Text = "WRST Caribou Dataset Explorer"
        CType(Me.DatasetGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DatasetGridControlToolStrip.ResumeLayout(False)
        Me.DatasetGridControlToolStrip.PerformLayout()
        CType(Me.DockManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        Me.DockPanel1_Container.PerformLayout()
        CType(Me.DatasetPivotGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DatastePivotGridToolStrip.ResumeLayout(False)
        Me.DatastePivotGridToolStrip.PerformLayout()
        CType(Me.DatasetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FooterToolStrip.ResumeLayout(False)
        Me.FooterToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DatasetGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DatasetGridControlToolStrip As ToolStrip
    Friend WithEvents DockManager As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents DatasetPivotGridControl As DevExpress.XtraPivotGrid.PivotGridControl
    Friend WithEvents DatasetBindingSource As BindingSource
    Friend WithEvents LoadDatasetToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ExportDatasetToolStripComboBox As ToolStripComboBox
    Friend WithEvents DatastePivotGridToolStrip As ToolStrip
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ExportPivotGridToolStripComboBox As ToolStripComboBox
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents DatasetSelectorToolStripComboBox As ToolStripComboBox
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents FooterToolStrip As ToolStrip
    Friend WithEvents SqlToolStripLabel As ToolStripLabel
End Class
