﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CapturesForm
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
        Dim CapturesGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CapturesForm))
        Me.CapturesGridEX = New Janus.Windows.GridEX.GridEX()
        Me.CapturesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WRST_CaribouDataSet = New WRST_Caribou3.WRST_CaribouDataSet()
        Me.CapturesToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AllowFilteringToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AllowEditsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TableAdapterManager = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.TableAdapterManager()
        Me.CapturesTableAdapter = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.CapturesTableAdapter()
        Me.BottomToolStrip = New System.Windows.Forms.ToolStrip()
        Me.CurrentDatabaseToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ImportToolStripButton = New System.Windows.Forms.ToolStripButton()
        CType(Me.CapturesGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CapturesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WRST_CaribouDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CapturesToolStrip.SuspendLayout()
        Me.BottomToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'CapturesGridEX
        '
        Me.CapturesGridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CapturesGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.CapturesGridEX.AlternatingColors = True
        Me.CapturesGridEX.DataSource = Me.CapturesBindingSource
        CapturesGridEX_DesignTimeLayout.LayoutString = resources.GetString("CapturesGridEX_DesignTimeLayout.LayoutString")
        Me.CapturesGridEX.DesignTimeLayout = CapturesGridEX_DesignTimeLayout
        Me.CapturesGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CapturesGridEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CapturesGridEX.FrozenColumns = 5
        Me.CapturesGridEX.GroupByBoxVisible = False
        Me.CapturesGridEX.Location = New System.Drawing.Point(0, 32)
        Me.CapturesGridEX.Name = "CapturesGridEX"
        Me.CapturesGridEX.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.CapturesGridEX.RecordNavigator = True
        Me.CapturesGridEX.Size = New System.Drawing.Size(2080, 1256)
        Me.CapturesGridEX.TabIndex = 1
        '
        'CapturesBindingSource
        '
        Me.CapturesBindingSource.DataMember = "Captures"
        Me.CapturesBindingSource.DataSource = Me.WRST_CaribouDataSet
        '
        'WRST_CaribouDataSet
        '
        Me.WRST_CaribouDataSet.DataSetName = "WRST_CaribouDataSet"
        Me.WRST_CaribouDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CapturesToolStrip
        '
        Me.CapturesToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CapturesToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.ToolStripSeparator1, Me.AllowFilteringToolStripButton, Me.ToolStripSeparator2, Me.AllowEditsToolStripButton, Me.ToolStripSeparator3, Me.ImportToolStripButton})
        Me.CapturesToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.CapturesToolStrip.Name = "CapturesToolStrip"
        Me.CapturesToolStrip.Size = New System.Drawing.Size(2080, 32)
        Me.CapturesToolStrip.TabIndex = 2
        Me.CapturesToolStrip.Text = "ToolStrip1"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(53, 29)
        Me.SaveToolStripButton.Text = "Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 32)
        '
        'AllowFilteringToolStripButton
        '
        Me.AllowFilteringToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AllowFilteringToolStripButton.Image = CType(resources.GetObject("AllowFilteringToolStripButton.Image"), System.Drawing.Image)
        Me.AllowFilteringToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AllowFilteringToolStripButton.Name = "AllowFilteringToolStripButton"
        Me.AllowFilteringToolStripButton.Size = New System.Drawing.Size(170, 29)
        Me.AllowFilteringToolStripButton.Text = "Show filtering tools"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 32)
        '
        'AllowEditsToolStripButton
        '
        Me.AllowEditsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AllowEditsToolStripButton.Image = CType(resources.GetObject("AllowEditsToolStripButton.Image"), System.Drawing.Image)
        Me.AllowEditsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AllowEditsToolStripButton.Name = "AllowEditsToolStripButton"
        Me.AllowEditsToolStripButton.Size = New System.Drawing.Size(103, 29)
        Me.AllowEditsToolStripButton.Text = "Allow edits"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 32)
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CapturesTableAdapter = Nothing
        Me.TableAdapterManager.CollaredAnimalsInGroupsTableAdapter = Nothing
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.SurveyFlightsTableAdapter = Nothing
        Me.TableAdapterManager.SurveysTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WRST_Caribou3.WRST_CaribouDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CapturesTableAdapter
        '
        Me.CapturesTableAdapter.ClearBeforeFill = True
        '
        'BottomToolStrip
        '
        Me.BottomToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.BottomToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CurrentDatabaseToolStripLabel})
        Me.BottomToolStrip.Location = New System.Drawing.Point(0, 1288)
        Me.BottomToolStrip.Name = "BottomToolStrip"
        Me.BottomToolStrip.Size = New System.Drawing.Size(2080, 28)
        Me.BottomToolStrip.TabIndex = 3
        Me.BottomToolStrip.Text = "ToolStrip1"
        '
        'CurrentDatabaseToolStripLabel
        '
        Me.CurrentDatabaseToolStripLabel.Name = "CurrentDatabaseToolStripLabel"
        Me.CurrentDatabaseToolStripLabel.Size = New System.Drawing.Size(202, 25)
        Me.CurrentDatabaseToolStripLabel.Text = "Database: Disconnected"
        '
        'ImportToolStripButton
        '
        Me.ImportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ImportToolStripButton.Image = CType(resources.GetObject("ImportToolStripButton.Image"), System.Drawing.Image)
        Me.ImportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportToolStripButton.Name = "ImportToolStripButton"
        Me.ImportToolStripButton.Size = New System.Drawing.Size(155, 29)
        Me.ImportToolStripButton.Text = "Import from file..."
        '
        'CapturesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2080, 1316)
        Me.Controls.Add(Me.CapturesGridEX)
        Me.Controls.Add(Me.BottomToolStrip)
        Me.Controls.Add(Me.CapturesToolStrip)
        Me.Name = "CapturesForm"
        Me.Text = "CapturesForm"
        CType(Me.CapturesGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CapturesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WRST_CaribouDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CapturesToolStrip.ResumeLayout(False)
        Me.CapturesToolStrip.PerformLayout()
        Me.BottomToolStrip.ResumeLayout(False)
        Me.BottomToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WRST_CaribouDataSet As WRST_CaribouDataSet
    Friend WithEvents CapturesBindingSource As BindingSource
    Friend WithEvents TableAdapterManager As WRST_CaribouDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CapturesGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents CapturesToolStrip As ToolStrip
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents AllowFilteringToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents CapturesTableAdapter As WRST_CaribouDataSetTableAdapters.CapturesTableAdapter
    Friend WithEvents AllowEditsToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BottomToolStrip As ToolStrip
    Friend WithEvents CurrentDatabaseToolStripLabel As ToolStripLabel
    Friend WithEvents ImportToolStripButton As ToolStripButton
End Class
