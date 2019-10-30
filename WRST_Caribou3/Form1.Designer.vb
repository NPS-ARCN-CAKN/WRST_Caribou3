<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim SurveyFlightsGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim SurveysGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim CollaredAnimalsInGroupsGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SurveyFlightsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.SurveyFlightsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WRST_CaribouDataSet = New WRST_Caribou3.WRST_CaribouDataSet()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SurveysGridEX = New Janus.Windows.GridEX.GridEX()
        Me.SurveysBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SurveysToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ImportSurveyDataFromFileToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CollaredAnimalsInGroupsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.CollaredAnimalsInGroupsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SurveyFlightsTableAdapter = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.SurveyFlightsTableAdapter()
        Me.TableAdapterManager = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.TableAdapterManager()
        Me.CollaredAnimalsInGroupsTableAdapter = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.CollaredAnimalsInGroupsTableAdapter()
        Me.SurveysTableAdapter = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.SurveysTableAdapter()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SurveyFlightsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SurveyFlightsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WRST_CaribouDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SurveysGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SurveysBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SurveysToolStrip.SuspendLayout()
        CType(Me.CollaredAnimalsInGroupsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CollaredAnimalsInGroupsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 32)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SurveyFlightsGridEX)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(2323, 1452)
        Me.SplitContainer1.SplitterDistance = 457
        Me.SplitContainer1.TabIndex = 0
        '
        'SurveyFlightsGridEX
        '
        Me.SurveyFlightsGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveyFlightsGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveyFlightsGridEX.DataSource = Me.SurveyFlightsBindingSource
        SurveyFlightsGridEX_DesignTimeLayout.LayoutString = resources.GetString("SurveyFlightsGridEX_DesignTimeLayout.LayoutString")
        Me.SurveyFlightsGridEX.DesignTimeLayout = SurveyFlightsGridEX_DesignTimeLayout
        Me.SurveyFlightsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveyFlightsGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.SurveyFlightsGridEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurveyFlightsGridEX.Location = New System.Drawing.Point(0, 0)
        Me.SurveyFlightsGridEX.Name = "SurveyFlightsGridEX"
        Me.SurveyFlightsGridEX.RecordNavigator = True
        Me.SurveyFlightsGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveyFlightsGridEX.Size = New System.Drawing.Size(2323, 457)
        Me.SurveyFlightsGridEX.TabIndex = 0
        Me.SurveyFlightsGridEX.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'SurveyFlightsBindingSource
        '
        Me.SurveyFlightsBindingSource.DataMember = "SurveyFlights"
        Me.SurveyFlightsBindingSource.DataSource = Me.WRST_CaribouDataSet
        '
        'WRST_CaribouDataSet
        '
        Me.WRST_CaribouDataSet.DataSetName = "WRST_CaribouDataSet"
        Me.WRST_CaribouDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SurveysGridEX)
        Me.SplitContainer2.Panel1.Controls.Add(Me.SurveysToolStrip)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.Controls.Add(Me.CollaredAnimalsInGroupsGridEX)
        Me.SplitContainer2.Size = New System.Drawing.Size(2323, 991)
        Me.SplitContainer2.SplitterDistance = 1281
        Me.SplitContainer2.TabIndex = 0
        '
        'SurveysGridEX
        '
        Me.SurveysGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveysGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveysGridEX.DataSource = Me.SurveysBindingSource
        SurveysGridEX_DesignTimeLayout.LayoutString = resources.GetString("SurveysGridEX_DesignTimeLayout.LayoutString")
        Me.SurveysGridEX.DesignTimeLayout = SurveysGridEX_DesignTimeLayout
        Me.SurveysGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveysGridEX.GroupByBoxVisible = False
        Me.SurveysGridEX.Location = New System.Drawing.Point(0, 32)
        Me.SurveysGridEX.Name = "SurveysGridEX"
        Me.SurveysGridEX.RecordNavigator = True
        Me.SurveysGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveysGridEX.Size = New System.Drawing.Size(1281, 959)
        Me.SurveysGridEX.TabIndex = 0
        Me.SurveysGridEX.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveysGridEX.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveysGridEX.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.SurveysGridEX.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        '
        'SurveysBindingSource
        '
        Me.SurveysBindingSource.DataMember = "FK_Surveys_SurveyFlights"
        Me.SurveysBindingSource.DataSource = Me.SurveyFlightsBindingSource
        '
        'SurveysToolStrip
        '
        Me.SurveysToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.SurveysToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportSurveyDataFromFileToolStripButton})
        Me.SurveysToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.SurveysToolStrip.Name = "SurveysToolStrip"
        Me.SurveysToolStrip.Size = New System.Drawing.Size(1281, 32)
        Me.SurveysToolStrip.TabIndex = 1
        Me.SurveysToolStrip.Text = "ToolStrip2"
        '
        'ImportSurveyDataFromFileToolStripButton
        '
        Me.ImportSurveyDataFromFileToolStripButton.Image = CType(resources.GetObject("ImportSurveyDataFromFileToolStripButton.Image"), System.Drawing.Image)
        Me.ImportSurveyDataFromFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportSurveyDataFromFileToolStripButton.Name = "ImportSurveyDataFromFileToolStripButton"
        Me.ImportSurveyDataFromFileToolStripButton.Size = New System.Drawing.Size(275, 29)
        Me.ImportSurveyDataFromFileToolStripButton.Text = "Import survey data from file..."
        '
        'CollaredAnimalsInGroupsGridEX
        '
        Me.CollaredAnimalsInGroupsGridEX.DataSource = Me.CollaredAnimalsInGroupsBindingSource
        CollaredAnimalsInGroupsGridEX_DesignTimeLayout.LayoutString = resources.GetString("CollaredAnimalsInGroupsGridEX_DesignTimeLayout.LayoutString")
        Me.CollaredAnimalsInGroupsGridEX.DesignTimeLayout = CollaredAnimalsInGroupsGridEX_DesignTimeLayout
        Me.CollaredAnimalsInGroupsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CollaredAnimalsInGroupsGridEX.GroupByBoxVisible = False
        Me.CollaredAnimalsInGroupsGridEX.Location = New System.Drawing.Point(0, 0)
        Me.CollaredAnimalsInGroupsGridEX.Name = "CollaredAnimalsInGroupsGridEX"
        Me.CollaredAnimalsInGroupsGridEX.RecordNavigator = True
        Me.CollaredAnimalsInGroupsGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CollaredAnimalsInGroupsGridEX.Size = New System.Drawing.Size(1038, 991)
        Me.CollaredAnimalsInGroupsGridEX.TabIndex = 0
        Me.CollaredAnimalsInGroupsGridEX.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'CollaredAnimalsInGroupsBindingSource
        '
        Me.CollaredAnimalsInGroupsBindingSource.DataMember = "FK_CollaredAnimalsInGroups_Surveys"
        Me.CollaredAnimalsInGroupsBindingSource.DataSource = Me.SurveysBindingSource
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(2323, 32)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(96, 29)
        Me.SaveToolStripButton.Text = "Save edits"
        '
        'SurveyFlightsTableAdapter
        '
        Me.SurveyFlightsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CollaredAnimalsInGroupsTableAdapter = Me.CollaredAnimalsInGroupsTableAdapter
        Me.TableAdapterManager.SurveyFlightsTableAdapter = Me.SurveyFlightsTableAdapter
        Me.TableAdapterManager.SurveysTableAdapter = Me.SurveysTableAdapter
        Me.TableAdapterManager.UpdateOrder = WRST_Caribou3.WRST_CaribouDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CollaredAnimalsInGroupsTableAdapter
        '
        Me.CollaredAnimalsInGroupsTableAdapter.ClearBeforeFill = True
        '
        'SurveysTableAdapter
        '
        Me.SurveysTableAdapter.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2323, 1484)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Form1"
        Me.Text = "WRST Caribou Monitoring Database Application"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.SurveyFlightsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SurveyFlightsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WRST_CaribouDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.SurveysGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SurveysBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SurveysToolStrip.ResumeLayout(False)
        Me.SurveysToolStrip.PerformLayout()
        CType(Me.CollaredAnimalsInGroupsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CollaredAnimalsInGroupsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents WRST_CaribouDataSet As WRST_CaribouDataSet
    Friend WithEvents SurveyFlightsBindingSource As BindingSource
    Friend WithEvents SurveyFlightsTableAdapter As WRST_CaribouDataSetTableAdapters.SurveyFlightsTableAdapter
    Friend WithEvents TableAdapterManager As WRST_CaribouDataSetTableAdapters.TableAdapterManager
    Friend WithEvents SurveyFlightsGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents SurveysTableAdapter As WRST_CaribouDataSetTableAdapters.SurveysTableAdapter
    Friend WithEvents SurveysBindingSource As BindingSource
    Friend WithEvents SurveysGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents CollaredAnimalsInGroupsTableAdapter As WRST_CaribouDataSetTableAdapters.CollaredAnimalsInGroupsTableAdapter
    Friend WithEvents CollaredAnimalsInGroupsBindingSource As BindingSource
    Friend WithEvents CollaredAnimalsInGroupsGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents SurveysToolStrip As ToolStrip
    Friend WithEvents ImportSurveyDataFromFileToolStripButton As ToolStripButton
End Class
