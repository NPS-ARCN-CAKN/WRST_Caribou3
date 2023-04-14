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
        Me.DatasetGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.DockManager = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.DatasetPivotGridControl = New DevExpress.XtraPivotGrid.PivotGridControl()
        CType(Me.DatasetGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.DatasetPivotGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DatasetGridControl
        '
        Me.DatasetGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DatasetGridControl.Location = New System.Drawing.Point(0, 25)
        Me.DatasetGridControl.MainView = Me.GridView1
        Me.DatasetGridControl.Name = "DatasetGridControl"
        Me.DatasetGridControl.Size = New System.Drawing.Size(1187, 316)
        Me.DatasetGridControl.TabIndex = 0
        Me.DatasetGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DatasetGridControl
        Me.GridView1.Name = "GridView1"
        '
        'ToolStrip
        '
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1187, 25)
        Me.ToolStrip.TabIndex = 1
        Me.ToolStrip.Text = "ToolStrip1"
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
        Me.DockPanel1.Location = New System.Drawing.Point(0, 341)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(200, 405)
        Me.DockPanel1.Size = New System.Drawing.Size(1187, 405)
        Me.DockPanel1.Text = "Pivot table generator"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.DatasetPivotGridControl)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(3, 27)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(1181, 375)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'DatasetPivotGridControl
        '
        Me.DatasetPivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DatasetPivotGridControl.Location = New System.Drawing.Point(0, 0)
        Me.DatasetPivotGridControl.Name = "DatasetPivotGridControl"
        Me.DatasetPivotGridControl.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Optimized
        Me.DatasetPivotGridControl.Size = New System.Drawing.Size(1181, 375)
        Me.DatasetPivotGridControl.TabIndex = 0
        '
        'DatasetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1187, 746)
        Me.Controls.Add(Me.DatasetGridControl)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "DatasetForm"
        Me.Text = "DatasetForm"
        CType(Me.DatasetGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.DatasetPivotGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DatasetGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents DockManager As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents DatasetPivotGridControl As DevExpress.XtraPivotGrid.PivotGridControl
End Class
