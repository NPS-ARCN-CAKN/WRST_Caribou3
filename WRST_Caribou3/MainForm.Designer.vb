﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim SurveyFlightsGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim SurveysGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim SurveysGridEX_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.FormatConditions.Condition3.FormatStyle.BackgroundImag" &
        "e")
        Dim CollaredAnimalsInGroupsGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SurveyFlightsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.SurveyFlightsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WRST_CaribouDataSet = New WRST_Caribou3.WRST_CaribouDataSet()
        Me.SurveysSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.SurveysGridEX = New Janus.Windows.GridEX.GridEX()
        Me.SurveysBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SurveysToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ImportSurveyDataFromFileToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AutomatchToolStripSplitButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.CurrentRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllRowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangeOrientationToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CollaredAnimalsSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.CollaredAnimalsInGroupsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.CollaredAnimalsInGroupsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AnimalGridEX = New Janus.Windows.GridEX.GridEX()
        Me.AnimalGridPanel = New System.Windows.Forms.Panel()
        Me.ShowAnimalDetailsCheckBox = New System.Windows.Forms.CheckBox()
        Me.MainToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ReloadDatasetToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ResultsToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.DatabaseQueriesToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryOfAvailableCollarsOnADateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenCapturesFormToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.AllowEditsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.QualityControlToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CountTotalDetectedFrequenciesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenWRSTCaribouDirectoryToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.BottomToolStrip = New System.Windows.Forms.ToolStrip()
        Me.CurrentDatabaseToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.CapturesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SurveyFlightsTableAdapter = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.SurveyFlightsTableAdapter()
        Me.TableAdapterManager = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.TableAdapterManager()
        Me.CollaredAnimalsInGroupsTableAdapter = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.CollaredAnimalsInGroupsTableAdapter()
        Me.SurveysTableAdapter = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.SurveysTableAdapter()
        Me.CapturesTableAdapter = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.CapturesTableAdapter()
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
        CType(Me.CollaredAnimalsSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CollaredAnimalsSplitContainer.Panel1.SuspendLayout()
        Me.CollaredAnimalsSplitContainer.Panel2.SuspendLayout()
        Me.CollaredAnimalsSplitContainer.SuspendLayout()
        CType(Me.CollaredAnimalsInGroupsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CollaredAnimalsInGroupsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnimalGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AnimalGridPanel.SuspendLayout()
        Me.MainToolStrip.SuspendLayout()
        Me.BottomToolStrip.SuspendLayout()
        CType(Me.CapturesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SurveyFlightsGridEX)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SurveysSplitContainer)
        Me.SplitContainer1.Size = New System.Drawing.Size(1282, 636)
        Me.SplitContainer1.SplitterDistance = 142
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 0
        '
        'SurveyFlightsGridEX
        '
        Me.SurveyFlightsGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.SurveyFlightsGridEX.DataSource = Me.SurveyFlightsBindingSource
        SurveyFlightsGridEX_DesignTimeLayout.LayoutString = resources.GetString("SurveyFlightsGridEX_DesignTimeLayout.LayoutString")
        Me.SurveyFlightsGridEX.DesignTimeLayout = SurveyFlightsGridEX_DesignTimeLayout
        Me.SurveyFlightsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveyFlightsGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.SurveyFlightsGridEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurveyFlightsGridEX.FrozenColumns = 4
        Me.SurveyFlightsGridEX.GroupByBoxVisible = False
        Me.SurveyFlightsGridEX.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed
        Me.SurveyFlightsGridEX.Location = New System.Drawing.Point(0, 0)
        Me.SurveyFlightsGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.SurveyFlightsGridEX.Name = "SurveyFlightsGridEX"
        Me.SurveyFlightsGridEX.RecordNavigator = True
        Me.SurveyFlightsGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveyFlightsGridEX.Size = New System.Drawing.Size(1282, 142)
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
        'SurveysSplitContainer
        '
        Me.SurveysSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveysSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SurveysSplitContainer.Margin = New System.Windows.Forms.Padding(2)
        Me.SurveysSplitContainer.Name = "SurveysSplitContainer"
        Me.SurveysSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SurveysSplitContainer.Panel1
        '
        Me.SurveysSplitContainer.Panel1.Controls.Add(Me.SurveysGridEX)
        Me.SurveysSplitContainer.Panel1.Controls.Add(Me.SurveysToolStrip)
        '
        'SurveysSplitContainer.Panel2
        '
        Me.SurveysSplitContainer.Panel2.AutoScroll = True
        Me.SurveysSplitContainer.Panel2.Controls.Add(Me.CollaredAnimalsSplitContainer)
        Me.SurveysSplitContainer.Size = New System.Drawing.Size(1282, 492)
        Me.SurveysSplitContainer.SplitterDistance = 130
        Me.SurveysSplitContainer.SplitterWidth = 2
        Me.SurveysSplitContainer.TabIndex = 0
        '
        'SurveysGridEX
        '
        Me.SurveysGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveysGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveysGridEX.DataSource = Me.SurveysBindingSource
        SurveysGridEX_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("SurveysGridEX_DesignTimeLayout_Reference_0.Instance"), Object)
        SurveysGridEX_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {SurveysGridEX_DesignTimeLayout_Reference_0})
        SurveysGridEX_DesignTimeLayout.LayoutString = resources.GetString("SurveysGridEX_DesignTimeLayout.LayoutString")
        Me.SurveysGridEX.DesignTimeLayout = SurveysGridEX_DesignTimeLayout
        Me.SurveysGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurveysGridEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurveysGridEX.FrozenColumns = 3
        Me.SurveysGridEX.GroupByBoxVisible = False
        Me.SurveysGridEX.Location = New System.Drawing.Point(0, 31)
        Me.SurveysGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.SurveysGridEX.Name = "SurveysGridEX"
        Me.SurveysGridEX.RecordNavigator = True
        Me.SurveysGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.SurveysGridEX.Size = New System.Drawing.Size(1282, 99)
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
        Me.SurveysToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportSurveyDataFromFileToolStripButton, Me.ToolStripSeparator1, Me.AutomatchToolStripSplitButton, Me.ToolStripSeparator2, Me.ChangeOrientationToolStripButton})
        Me.SurveysToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.SurveysToolStrip.Name = "SurveysToolStrip"
        Me.SurveysToolStrip.Size = New System.Drawing.Size(1282, 31)
        Me.SurveysToolStrip.TabIndex = 1
        Me.SurveysToolStrip.Text = "ToolStrip2"
        '
        'ImportSurveyDataFromFileToolStripButton
        '
        Me.ImportSurveyDataFromFileToolStripButton.Image = CType(resources.GetObject("ImportSurveyDataFromFileToolStripButton.Image"), System.Drawing.Image)
        Me.ImportSurveyDataFromFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportSurveyDataFromFileToolStripButton.Name = "ImportSurveyDataFromFileToolStripButton"
        Me.ImportSurveyDataFromFileToolStripButton.Size = New System.Drawing.Size(191, 28)
        Me.ImportSurveyDataFromFileToolStripButton.Text = "Import survey data from file..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'AutomatchToolStripSplitButton
        '
        Me.AutomatchToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AutomatchToolStripSplitButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CurrentRowToolStripMenuItem, Me.AllRowsToolStripMenuItem})
        Me.AutomatchToolStripSplitButton.Image = CType(resources.GetObject("AutomatchToolStripSplitButton.Image"), System.Drawing.Image)
        Me.AutomatchToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AutomatchToolStripSplitButton.Name = "AutomatchToolStripSplitButton"
        Me.AutomatchToolStripSplitButton.Size = New System.Drawing.Size(223, 28)
        Me.AutomatchToolStripSplitButton.Text = "Auto-match frequencies to AnimalIDs"
        '
        'CurrentRowToolStripMenuItem
        '
        Me.CurrentRowToolStripMenuItem.Name = "CurrentRowToolStripMenuItem"
        Me.CurrentRowToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.CurrentRowToolStripMenuItem.Text = "Current row"
        '
        'AllRowsToolStripMenuItem
        '
        Me.AllRowsToolStripMenuItem.Name = "AllRowsToolStripMenuItem"
        Me.AllRowsToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.AllRowsToolStripMenuItem.Text = "All rows shown below"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'ChangeOrientationToolStripButton
        '
        Me.ChangeOrientationToolStripButton.Image = CType(resources.GetObject("ChangeOrientationToolStripButton.Image"), System.Drawing.Image)
        Me.ChangeOrientationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ChangeOrientationToolStripButton.Name = "ChangeOrientationToolStripButton"
        Me.ChangeOrientationToolStripButton.Size = New System.Drawing.Size(137, 28)
        Me.ChangeOrientationToolStripButton.Text = "Change orientation"
        '
        'CollaredAnimalsSplitContainer
        '
        Me.CollaredAnimalsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CollaredAnimalsSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.CollaredAnimalsSplitContainer.Margin = New System.Windows.Forms.Padding(2)
        Me.CollaredAnimalsSplitContainer.Name = "CollaredAnimalsSplitContainer"
        '
        'CollaredAnimalsSplitContainer.Panel1
        '
        Me.CollaredAnimalsSplitContainer.Panel1.Controls.Add(Me.CollaredAnimalsInGroupsGridEX)
        '
        'CollaredAnimalsSplitContainer.Panel2
        '
        Me.CollaredAnimalsSplitContainer.Panel2.Controls.Add(Me.AnimalGridEX)
        Me.CollaredAnimalsSplitContainer.Panel2.Controls.Add(Me.AnimalGridPanel)
        Me.CollaredAnimalsSplitContainer.Size = New System.Drawing.Size(1282, 360)
        Me.CollaredAnimalsSplitContainer.SplitterDistance = 599
        Me.CollaredAnimalsSplitContainer.SplitterWidth = 3
        Me.CollaredAnimalsSplitContainer.TabIndex = 1
        '
        'CollaredAnimalsInGroupsGridEX
        '
        Me.CollaredAnimalsInGroupsGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CollaredAnimalsInGroupsGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CollaredAnimalsInGroupsGridEX.DataSource = Me.CollaredAnimalsInGroupsBindingSource
        CollaredAnimalsInGroupsGridEX_DesignTimeLayout.LayoutString = resources.GetString("CollaredAnimalsInGroupsGridEX_DesignTimeLayout.LayoutString")
        Me.CollaredAnimalsInGroupsGridEX.DesignTimeLayout = CollaredAnimalsInGroupsGridEX_DesignTimeLayout
        Me.CollaredAnimalsInGroupsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CollaredAnimalsInGroupsGridEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollaredAnimalsInGroupsGridEX.GroupByBoxVisible = False
        Me.CollaredAnimalsInGroupsGridEX.Location = New System.Drawing.Point(0, 0)
        Me.CollaredAnimalsInGroupsGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.CollaredAnimalsInGroupsGridEX.Name = "CollaredAnimalsInGroupsGridEX"
        Me.CollaredAnimalsInGroupsGridEX.RecordNavigator = True
        Me.CollaredAnimalsInGroupsGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CollaredAnimalsInGroupsGridEX.Size = New System.Drawing.Size(599, 360)
        Me.CollaredAnimalsInGroupsGridEX.TabIndex = 0
        Me.CollaredAnimalsInGroupsGridEX.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'CollaredAnimalsInGroupsBindingSource
        '
        Me.CollaredAnimalsInGroupsBindingSource.DataMember = "FK_CollaredAnimalsInGroups_Surveys"
        Me.CollaredAnimalsInGroupsBindingSource.DataSource = Me.SurveysBindingSource
        '
        'AnimalGridEX
        '
        Me.AnimalGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.AnimalGridEX.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AnimalGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnimalGridEX.Location = New System.Drawing.Point(0, 26)
        Me.AnimalGridEX.Margin = New System.Windows.Forms.Padding(2)
        Me.AnimalGridEX.Name = "AnimalGridEX"
        Me.AnimalGridEX.RowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AnimalGridEX.Size = New System.Drawing.Size(680, 334)
        Me.AnimalGridEX.TabIndex = 0
        Me.AnimalGridEX.TableHeaderFormatStyle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'AnimalGridPanel
        '
        Me.AnimalGridPanel.Controls.Add(Me.ShowAnimalDetailsCheckBox)
        Me.AnimalGridPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.AnimalGridPanel.Location = New System.Drawing.Point(0, 0)
        Me.AnimalGridPanel.Name = "AnimalGridPanel"
        Me.AnimalGridPanel.Size = New System.Drawing.Size(680, 26)
        Me.AnimalGridPanel.TabIndex = 1
        '
        'ShowAnimalDetailsCheckBox
        '
        Me.ShowAnimalDetailsCheckBox.AutoSize = True
        Me.ShowAnimalDetailsCheckBox.Location = New System.Drawing.Point(3, 3)
        Me.ShowAnimalDetailsCheckBox.Name = "ShowAnimalDetailsCheckBox"
        Me.ShowAnimalDetailsCheckBox.Size = New System.Drawing.Size(324, 17)
        Me.ShowAnimalDetailsCheckBox.TabIndex = 1
        Me.ShowAnimalDetailsCheckBox.Text = "Show details for the animal selected at left (slows performance):"
        Me.ShowAnimalDetailsCheckBox.UseVisualStyleBackColor = True
        '
        'MainToolStrip
        '
        Me.MainToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MainToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.ToolStripSeparator3, Me.ReloadDatasetToolStripButton, Me.ToolStripSeparator4, Me.ResultsToolStripDropDownButton, Me.ToolStripSeparator5, Me.OpenCapturesFormToolStripButton, Me.ToolStripSeparator6, Me.AllowEditsToolStripButton, Me.ToolStripSeparator7, Me.QualityControlToolStripDropDownButton, Me.ToolStripSeparator9, Me.SettingsToolStripButton, Me.ToolStripSeparator8, Me.OpenWRSTCaribouDirectoryToolStripButton, Me.ToolStripSeparator10, Me.ToolStripSeparator11})
        Me.MainToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainToolStrip.Name = "MainToolStrip"
        Me.HelpProvider.SetShowHelp(Me.MainToolStrip, True)
        Me.MainToolStrip.Size = New System.Drawing.Size(1282, 25)
        Me.MainToolStrip.TabIndex = 1
        Me.MainToolStrip.Text = "ToolStrip1"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(63, 22)
        Me.SaveToolStripButton.Text = "Save edits"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ReloadDatasetToolStripButton
        '
        Me.ReloadDatasetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ReloadDatasetToolStripButton.Image = CType(resources.GetObject("ReloadDatasetToolStripButton.Image"), System.Drawing.Image)
        Me.ReloadDatasetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ReloadDatasetToolStripButton.Name = "ReloadDatasetToolStripButton"
        Me.ReloadDatasetToolStripButton.Size = New System.Drawing.Size(88, 22)
        Me.ReloadDatasetToolStripButton.Text = "Reload dataset"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ResultsToolStripDropDownButton
        '
        Me.ResultsToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ResultsToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatabaseQueriesToolToolStripMenuItem, Me.InventoryOfAvailableCollarsOnADateToolStripMenuItem})
        Me.ResultsToolStripDropDownButton.Image = CType(resources.GetObject("ResultsToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.ResultsToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ResultsToolStripDropDownButton.Name = "ResultsToolStripDropDownButton"
        Me.ResultsToolStripDropDownButton.Size = New System.Drawing.Size(124, 22)
        Me.ResultsToolStripDropDownButton.Text = "Results and analysis"
        '
        'DatabaseQueriesToolToolStripMenuItem
        '
        Me.DatabaseQueriesToolToolStripMenuItem.Name = "DatabaseQueriesToolToolStripMenuItem"
        Me.DatabaseQueriesToolToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.DatabaseQueriesToolToolStripMenuItem.Text = "Database queries tool..."
        '
        'InventoryOfAvailableCollarsOnADateToolStripMenuItem
        '
        Me.InventoryOfAvailableCollarsOnADateToolStripMenuItem.Name = "InventoryOfAvailableCollarsOnADateToolStripMenuItem"
        Me.InventoryOfAvailableCollarsOnADateToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.InventoryOfAvailableCollarsOnADateToolStripMenuItem.Text = "Inventory of available collars on a date..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'OpenCapturesFormToolStripButton
        '
        Me.OpenCapturesFormToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.OpenCapturesFormToolStripButton.Image = CType(resources.GetObject("OpenCapturesFormToolStripButton.Image"), System.Drawing.Image)
        Me.OpenCapturesFormToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenCapturesFormToolStripButton.Name = "OpenCapturesFormToolStripButton"
        Me.OpenCapturesFormToolStripButton.Size = New System.Drawing.Size(67, 22)
        Me.OpenCapturesFormToolStripButton.Text = "Captures..."
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'AllowEditsToolStripButton
        '
        Me.AllowEditsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AllowEditsToolStripButton.Image = CType(resources.GetObject("AllowEditsToolStripButton.Image"), System.Drawing.Image)
        Me.AllowEditsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AllowEditsToolStripButton.Name = "AllowEditsToolStripButton"
        Me.AllowEditsToolStripButton.Size = New System.Drawing.Size(69, 22)
        Me.AllowEditsToolStripButton.Tag = "False"
        Me.AllowEditsToolStripButton.Text = "Allow edits"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'QualityControlToolStripDropDownButton
        '
        Me.QualityControlToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.QualityControlToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CountTotalDetectedFrequenciesToolStripMenuItem})
        Me.QualityControlToolStripDropDownButton.Image = CType(resources.GetObject("QualityControlToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.QualityControlToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.QualityControlToolStripDropDownButton.Name = "QualityControlToolStripDropDownButton"
        Me.QualityControlToolStripDropDownButton.Size = New System.Drawing.Size(99, 22)
        Me.QualityControlToolStripDropDownButton.Text = "Quality control"
        '
        'CountTotalDetectedFrequenciesToolStripMenuItem
        '
        Me.CountTotalDetectedFrequenciesToolStripMenuItem.Enabled = False
        Me.CountTotalDetectedFrequenciesToolStripMenuItem.Name = "CountTotalDetectedFrequenciesToolStripMenuItem"
        Me.CountTotalDetectedFrequenciesToolStripMenuItem.Size = New System.Drawing.Size(231, 22)
        Me.CountTotalDetectedFrequenciesToolStripMenuItem.Text = "Frequency matching checks..."
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'SettingsToolStripButton
        '
        Me.SettingsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SettingsToolStripButton.Image = CType(resources.GetObject("SettingsToolStripButton.Image"), System.Drawing.Image)
        Me.SettingsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SettingsToolStripButton.Name = "SettingsToolStripButton"
        Me.SettingsToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.SettingsToolStripButton.Text = "Settings..."
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'OpenWRSTCaribouDirectoryToolStripButton
        '
        Me.OpenWRSTCaribouDirectoryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.OpenWRSTCaribouDirectoryToolStripButton.Image = CType(resources.GetObject("OpenWRSTCaribouDirectoryToolStripButton.Image"), System.Drawing.Image)
        Me.OpenWRSTCaribouDirectoryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenWRSTCaribouDirectoryToolStripButton.Name = "OpenWRSTCaribouDirectoryToolStripButton"
        Me.OpenWRSTCaribouDirectoryToolStripButton.Size = New System.Drawing.Size(116, 22)
        Me.OpenWRSTCaribouDirectoryToolStripButton.Text = "Open shared drive..."
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'HelpProvider
        '
        Me.HelpProvider.HelpNamespace = "C:\Work\Code\WRST_Caribou3\WRST_Caribou3\WRST Caribou Monitoring Database Applica" &
    "tion.chm"
        '
        'BottomToolStrip
        '
        Me.BottomToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.BottomToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CurrentDatabaseToolStripLabel})
        Me.BottomToolStrip.Location = New System.Drawing.Point(0, 661)
        Me.BottomToolStrip.Name = "BottomToolStrip"
        Me.BottomToolStrip.Size = New System.Drawing.Size(1282, 25)
        Me.BottomToolStrip.TabIndex = 1
        Me.BottomToolStrip.Text = "ToolStrip1"
        '
        'CurrentDatabaseToolStripLabel
        '
        Me.CurrentDatabaseToolStripLabel.Name = "CurrentDatabaseToolStripLabel"
        Me.CurrentDatabaseToolStripLabel.Size = New System.Drawing.Size(133, 22)
        Me.CurrentDatabaseToolStripLabel.Text = "Database: Disconnected"
        '
        'CapturesBindingSource
        '
        Me.CapturesBindingSource.DataMember = "Captures"
        Me.CapturesBindingSource.DataSource = Me.WRST_CaribouDataSet
        '
        'SurveyFlightsTableAdapter
        '
        Me.SurveyFlightsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CapturesTableAdapter = Nothing
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
        'CapturesTableAdapter
        '
        Me.CapturesTableAdapter.ClearBeforeFill = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1282, 686)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BottomToolStrip)
        Me.Controls.Add(Me.MainToolStrip)
        Me.HelpButton = True
        Me.HelpProvider.SetHelpKeyword(Me, "")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.HelpProvider.SetHelpString(Me, "Data entry")
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MainForm"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "NPS Alaska Caribou Monitoring Database Application"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
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
        Me.CollaredAnimalsSplitContainer.Panel1.ResumeLayout(False)
        Me.CollaredAnimalsSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.CollaredAnimalsSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CollaredAnimalsSplitContainer.ResumeLayout(False)
        CType(Me.CollaredAnimalsInGroupsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CollaredAnimalsInGroupsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnimalGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AnimalGridPanel.ResumeLayout(False)
        Me.AnimalGridPanel.PerformLayout()
        Me.MainToolStrip.ResumeLayout(False)
        Me.MainToolStrip.PerformLayout()
        Me.BottomToolStrip.ResumeLayout(False)
        Me.BottomToolStrip.PerformLayout()
        CType(Me.CapturesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ChangeOrientationToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ReloadDatasetToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents CollaredAnimalsSplitContainer As SplitContainer
    Friend WithEvents AnimalGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents HelpProvider As HelpProvider
    Friend WithEvents CapturesBindingSource As BindingSource
    Friend WithEvents CapturesTableAdapter As WRST_CaribouDataSetTableAdapters.CapturesTableAdapter
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents OpenCapturesFormToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents AllowEditsToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents BottomToolStrip As ToolStrip
    Friend WithEvents CurrentDatabaseToolStripLabel As ToolStripLabel
    Friend WithEvents OpenWRSTCaribouDirectoryToolStripButton As ToolStripButton
    Friend WithEvents AutomatchToolStripSplitButton As ToolStripSplitButton
    Friend WithEvents CurrentRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllRowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents SettingsToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents ResultsToolStripDropDownButton As ToolStripDropDownButton
    Friend WithEvents DatabaseQueriesToolToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QualityControlToolStripDropDownButton As ToolStripDropDownButton
    Friend WithEvents CountTotalDetectedFrequenciesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryOfAvailableCollarsOnADateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents AnimalGridPanel As Panel
    Friend WithEvents ShowAnimalDetailsCheckBox As CheckBox
End Class
