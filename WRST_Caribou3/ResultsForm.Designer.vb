﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ResultsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResultsForm))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ViewsListBox = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ResultsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.ResultsToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ExportToCSVToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CollapseGroupsCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupByBoxVisibleCheckBox = New System.Windows.Forms.CheckBox()
        Me.DataSummariesLabel = New System.Windows.Forms.Label()
        Me.ViewDescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ReloadQueryToolStripButton = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ResultsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ResultsToolStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 94)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ViewsListBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ResultsGridEX)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ResultsToolStrip)
        Me.SplitContainer1.Size = New System.Drawing.Size(1548, 750)
        Me.SplitContainer1.SplitterDistance = 248
        Me.SplitContainer1.TabIndex = 0
        '
        'ViewsListBox
        '
        Me.ViewsListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewsListBox.FormattingEnabled = True
        Me.ViewsListBox.ItemHeight = 16
        Me.ViewsListBox.Location = New System.Drawing.Point(0, 29)
        Me.ViewsListBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ViewsListBox.Name = "ViewsListBox"
        Me.ViewsListBox.Size = New System.Drawing.Size(248, 721)
        Me.ViewsListBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Label1.Size = New System.Drawing.Size(117, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select a query:"
        '
        'ResultsGridEX
        '
        Me.ResultsGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.ResultsGridEX.AlternatingColors = True
        Me.ResultsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResultsGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.ResultsGridEX.GroupByBoxFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.ResultsGridEX.GroupByBoxFormatStyle.ForeColor = System.Drawing.Color.Red
        Me.ResultsGridEX.GroupByBoxInfoFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.ResultsGridEX.GroupByBoxInfoFormatStyle.ForeColor = System.Drawing.Color.Black
        Me.ResultsGridEX.GroupRowFormatStyle.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ResultsGridEX.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.ResultsGridEX.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Black
        Me.ResultsGridEX.GroupTotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.ResultsGridEX.GroupTotals = Janus.Windows.GridEX.GroupTotals.ExpandedGroup
        Me.ResultsGridEX.Location = New System.Drawing.Point(0, 31)
        Me.ResultsGridEX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ResultsGridEX.Name = "ResultsGridEX"
        Me.ResultsGridEX.RecordNavigator = True
        Me.ResultsGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.ResultsGridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.ResultsGridEX.Size = New System.Drawing.Size(1296, 719)
        Me.ResultsGridEX.TabIndex = 0
        Me.ResultsGridEX.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.ResultsGridEX.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        '
        'ResultsToolStrip
        '
        Me.ResultsToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ResultsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReloadQueryToolStripButton, Me.ToolStripSeparator1, Me.ExportToCSVToolStripButton})
        Me.ResultsToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ResultsToolStrip.Name = "ResultsToolStrip"
        Me.ResultsToolStrip.Size = New System.Drawing.Size(1296, 31)
        Me.ResultsToolStrip.TabIndex = 1
        Me.ResultsToolStrip.Text = "ToolStrip1"
        '
        'ExportToCSVToolStripButton
        '
        Me.ExportToCSVToolStripButton.Image = CType(resources.GetObject("ExportToCSVToolStripButton.Image"), System.Drawing.Image)
        Me.ExportToCSVToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExportToCSVToolStripButton.Name = "ExportToCSVToolStripButton"
        Me.ExportToCSVToolStripButton.Size = New System.Drawing.Size(137, 28)
        Me.ExportToCSVToolStripButton.Text = "Export to CSV..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'CollapseGroupsCheckBox
        '
        Me.CollapseGroupsCheckBox.AutoSize = True
        Me.CollapseGroupsCheckBox.Checked = True
        Me.CollapseGroupsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CollapseGroupsCheckBox.Location = New System.Drawing.Point(517, 5)
        Me.CollapseGroupsCheckBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CollapseGroupsCheckBox.Name = "CollapseGroupsCheckBox"
        Me.CollapseGroupsCheckBox.Size = New System.Drawing.Size(132, 21)
        Me.CollapseGroupsCheckBox.TabIndex = 0
        Me.CollapseGroupsCheckBox.Text = "Collapse groups"
        Me.CollapseGroupsCheckBox.UseVisualStyleBackColor = True
        '
        'GroupByBoxVisibleCheckBox
        '
        Me.GroupByBoxVisibleCheckBox.AutoSize = True
        Me.GroupByBoxVisibleCheckBox.Checked = True
        Me.GroupByBoxVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.GroupByBoxVisibleCheckBox.Location = New System.Drawing.Point(389, 5)
        Me.GroupByBoxVisibleCheckBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupByBoxVisibleCheckBox.Name = "GroupByBoxVisibleCheckBox"
        Me.GroupByBoxVisibleCheckBox.Size = New System.Drawing.Size(122, 21)
        Me.GroupByBoxVisibleCheckBox.TabIndex = 1
        Me.GroupByBoxVisibleCheckBox.Text = "Allow grouping"
        Me.GroupByBoxVisibleCheckBox.UseVisualStyleBackColor = True
        '
        'DataSummariesLabel
        '
        Me.DataSummariesLabel.AutoSize = True
        Me.DataSummariesLabel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataSummariesLabel.Location = New System.Drawing.Point(0, 0)
        Me.DataSummariesLabel.Name = "DataSummariesLabel"
        Me.DataSummariesLabel.Size = New System.Drawing.Size(197, 24)
        Me.DataSummariesLabel.TabIndex = 2
        Me.DataSummariesLabel.Text = "Data summarization"
        '
        'ViewDescriptionTextBox
        '
        Me.ViewDescriptionTextBox.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ViewDescriptionTextBox.Location = New System.Drawing.Point(0, 37)
        Me.ViewDescriptionTextBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ViewDescriptionTextBox.Multiline = True
        Me.ViewDescriptionTextBox.Name = "ViewDescriptionTextBox"
        Me.ViewDescriptionTextBox.ReadOnly = True
        Me.ViewDescriptionTextBox.Size = New System.Drawing.Size(1548, 57)
        Me.ViewDescriptionTextBox.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataSummariesLabel)
        Me.Panel1.Controls.Add(Me.ViewDescriptionTextBox)
        Me.Panel1.Controls.Add(Me.CollapseGroupsCheckBox)
        Me.Panel1.Controls.Add(Me.GroupByBoxVisibleCheckBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1548, 94)
        Me.Panel1.TabIndex = 2
        '
        'ReloadQueryToolStripButton
        '
        Me.ReloadQueryToolStripButton.Image = CType(resources.GetObject("ReloadQueryToolStripButton.Image"), System.Drawing.Image)
        Me.ReloadQueryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ReloadQueryToolStripButton.Name = "ReloadQueryToolStripButton"
        Me.ReloadQueryToolStripButton.Size = New System.Drawing.Size(125, 28)
        Me.ReloadQueryToolStripButton.Text = "Reload query"
        '
        'ResultsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1548, 844)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ResultsForm"
        Me.Text = "Queries explorer"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ResultsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResultsToolStrip.ResumeLayout(False)
        Me.ResultsToolStrip.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ViewsListBox As ListBox
    Friend WithEvents ResultsGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents ResultsToolStrip As ToolStrip
    Friend WithEvents CollapseGroupsCheckBox As CheckBox
    Friend WithEvents DataSummariesLabel As Label
    Friend WithEvents GroupByBoxVisibleCheckBox As CheckBox
    Friend WithEvents ExportToCSVToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ViewDescriptionTextBox As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents ReloadQueryToolStripButton As ToolStripButton
End Class
