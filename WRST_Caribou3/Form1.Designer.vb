﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.SurveyFlightsToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SurveysSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.SurveysGridEX = New Janus.Windows.GridEX.GridEX()
        Me.SurveysBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SurveysToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ImportSurveyDataFromFileToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AutoMatchFrequenciesToAnimalsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangeOrientationToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CollaredAnimalsInGroupsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.CollaredAnimalsInGroupsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReloadDatasetToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
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
        CType(Me.SurveysSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SurveysSplitContainer.Panel1.SuspendLayout()
        Me.SurveysSplitContainer.Panel2.SuspendLayout()
        Me.SurveysSplitContainer.SuspendLayout()
        CType(Me.SurveysGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SurveysBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SurveysToolStrip.SuspendLayout()
        CType(Me.CollaredAnimalsInGroupsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CollaredAnimalsInGroupsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainToolStrip.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.SurveyFlightsToolStrip)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SurveysSplitContainer)
        Me.SplitContainer1.Size = New System.Drawing.Size(1178, 712)
        Me.SplitContainer1.SplitterDistance = 224
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
        Me.SurveyFlightsGridEX.GroupByBoxVisible = False
        Me.SurveyFlightsGridEX.Location = New System.Drawing.Point(0, 25)
        Me.SurveyFlightsGridEX.Name = "SurveyFlightsGridEX"
        Me.SurveyFlightsGridEX.RecordNavigator = True
        Me.SurveyFlightsGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveyFlightsGridEX.Size = New System.Drawing.Size(1178, 199)
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
        'SurveyFlightsToolStrip
        '
        Me.SurveyFlightsToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.SurveyFlightsToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.SurveyFlightsToolStrip.Name = "SurveyFlightsToolStrip"
        Me.SurveyFlightsToolStrip.Size = New System.Drawing.Size(1178, 25)
        Me.SurveyFlightsToolStrip.TabIndex = 1
        Me.SurveyFlightsToolStrip.Text = "ToolStrip2"
        '
        'SurveysSplitContainer
        '
        Me.SurveysSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveysSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SurveysSplitContainer.Name = "SurveysSplitContainer"
        '
        'SurveysSplitContainer.Panel1
        '
        Me.SurveysSplitContainer.Panel1.Controls.Add(Me.SurveysGridEX)
        Me.SurveysSplitContainer.Panel1.Controls.Add(Me.SurveysToolStrip)
        '
        'SurveysSplitContainer.Panel2
        '
        Me.SurveysSplitContainer.Panel2.AutoScroll = True
        Me.SurveysSplitContainer.Panel2.Controls.Add(Me.CollaredAnimalsInGroupsGridEX)
        Me.SurveysSplitContainer.Size = New System.Drawing.Size(1178, 484)
        Me.SurveysSplitContainer.SplitterDistance = 745
        Me.SurveysSplitContainer.TabIndex = 0
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
        Me.SurveysGridEX.Size = New System.Drawing.Size(745, 452)
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
        Me.SurveysToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportSurveyDataFromFileToolStripButton, Me.ToolStripSeparator1, Me.AutoMatchFrequenciesToAnimalsToolStripButton, Me.ToolStripSeparator2, Me.ChangeOrientationToolStripButton})
        Me.SurveysToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.SurveysToolStrip.Name = "SurveysToolStrip"
        Me.SurveysToolStrip.Size = New System.Drawing.Size(745, 32)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 32)
        '
        'AutoMatchFrequenciesToAnimalsToolStripButton
        '
        Me.AutoMatchFrequenciesToAnimalsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AutoMatchFrequenciesToAnimalsToolStripButton.Image = CType(resources.GetObject("AutoMatchFrequenciesToAnimalsToolStripButton.Image"), System.Drawing.Image)
        Me.AutoMatchFrequenciesToAnimalsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AutoMatchFrequenciesToAnimalsToolStripButton.Name = "AutoMatchFrequenciesToAnimalsToolStripButton"
        Me.AutoMatchFrequenciesToAnimalsToolStripButton.Size = New System.Drawing.Size(314, 29)
        Me.AutoMatchFrequenciesToAnimalsToolStripButton.Text = "Auto-match frequencies to AnimalIDs"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 32)
        '
        'ChangeOrientationToolStripButton
        '
        Me.ChangeOrientationToolStripButton.Image = CType(resources.GetObject("ChangeOrientationToolStripButton.Image"), System.Drawing.Image)
        Me.ChangeOrientationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ChangeOrientationToolStripButton.Name = "ChangeOrientationToolStripButton"
        Me.ChangeOrientationToolStripButton.Size = New System.Drawing.Size(191, 29)
        Me.ChangeOrientationToolStripButton.Text = "Change orientation"
        '
        'CollaredAnimalsInGroupsGridEX
        '
        Me.CollaredAnimalsInGroupsGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CollaredAnimalsInGroupsGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CollaredAnimalsInGroupsGridEX.DataSource = Me.CollaredAnimalsInGroupsBindingSource
        CollaredAnimalsInGroupsGridEX_DesignTimeLayout.LayoutString = resources.GetString("CollaredAnimalsInGroupsGridEX_DesignTimeLayout.LayoutString")
        Me.CollaredAnimalsInGroupsGridEX.DesignTimeLayout = CollaredAnimalsInGroupsGridEX_DesignTimeLayout
        Me.CollaredAnimalsInGroupsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CollaredAnimalsInGroupsGridEX.GroupByBoxVisible = False
        Me.CollaredAnimalsInGroupsGridEX.Location = New System.Drawing.Point(0, 0)
        Me.CollaredAnimalsInGroupsGridEX.Name = "CollaredAnimalsInGroupsGridEX"
        Me.CollaredAnimalsInGroupsGridEX.RecordNavigator = True
        Me.CollaredAnimalsInGroupsGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CollaredAnimalsInGroupsGridEX.Size = New System.Drawing.Size(429, 484)
        Me.CollaredAnimalsInGroupsGridEX.TabIndex = 0
        Me.CollaredAnimalsInGroupsGridEX.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'CollaredAnimalsInGroupsBindingSource
        '
        Me.CollaredAnimalsInGroupsBindingSource.DataMember = "FK_CollaredAnimalsInGroups_Surveys"
        Me.CollaredAnimalsInGroupsBindingSource.DataSource = Me.SurveysBindingSource
        '
        'MainToolStrip
        '
        Me.MainToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.ToolStripSeparator3, Me.ReloadDatasetToolStripButton, Me.ToolStripSeparator4})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.MainToolStrip.Size = New System.Drawing.Size(1178, 32)
        Me.MainToolStrip.TabIndex = 1
        Me.MainToolStrip.Text = "ToolStrip1"
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 32)
        '
        'ReloadDatasetToolStripButton
        '
        Me.ReloadDatasetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ReloadDatasetToolStripButton.Image = CType(resources.GetObject("ReloadDatasetToolStripButton.Image"), System.Drawing.Image)
        Me.ReloadDatasetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ReloadDatasetToolStripButton.Name = "ReloadDatasetToolStripButton"
        Me.ReloadDatasetToolStripButton.Size = New System.Drawing.Size(133, 29)
        Me.ReloadDatasetToolStripButton.Text = "Reload dataset"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 32)
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
        Me.ClientSize = New System.Drawing.Size(1178, 744)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MainToolStrip)
        Me.Name = "Form1"
        Me.Text = "WRST Caribou Monitoring Database Application"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.SurveyFlightsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SurveyFlightsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WRST_CaribouDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SurveysSplitContainer.Panel1.ResumeLayout(False)
        Me.SurveysSplitContainer.Panel1.PerformLayout()
        Me.SurveysSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SurveysSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SurveysSplitContainer.ResumeLayout(False)
        CType(Me.SurveysGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SurveysBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SurveysToolStrip.ResumeLayout(False)
        Me.SurveysToolStrip.PerformLayout()
        CType(Me.CollaredAnimalsInGroupsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CollaredAnimalsInGroupsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SurveysSplitContainer As SplitContainer
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
    Friend WithEvents MainToolStrip As ToolStrip
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents SurveysToolStrip As ToolStrip
    Friend WithEvents ImportSurveyDataFromFileToolStripButton As ToolStripButton
    Friend WithEvents SurveyFlightsToolStrip As ToolStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents AutoMatchFrequenciesToAnimalsToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ChangeOrientationToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ReloadDatasetToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
End Class
