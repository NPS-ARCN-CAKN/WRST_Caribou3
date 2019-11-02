<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResultsForm
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ViewsListBox = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ResultsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.ResultsToolStrip = New System.Windows.Forms.ToolStrip()
        Me.CollapseGroupsCheckBox = New System.Windows.Forms.CheckBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ResultsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 100)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ViewsListBox)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ResultsGridEX)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ResultsToolStrip)
        Me.SplitContainer1.Size = New System.Drawing.Size(1741, 1265)
        Me.SplitContainer1.SplitterDistance = 118
        Me.SplitContainer1.TabIndex = 0
        '
        'ViewsListBox
        '
        Me.ViewsListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewsListBox.FormattingEnabled = True
        Me.ViewsListBox.ItemHeight = 20
        Me.ViewsListBox.Location = New System.Drawing.Point(0, 0)
        Me.ViewsListBox.Name = "ViewsListBox"
        Me.ViewsListBox.Size = New System.Drawing.Size(118, 1265)
        Me.ViewsListBox.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CollapseGroupsCheckBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1741, 100)
        Me.Panel1.TabIndex = 1
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
        Me.ResultsGridEX.GroupRowFormatStyle.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultsGridEX.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.ResultsGridEX.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Black
        Me.ResultsGridEX.GroupTotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.ResultsGridEX.GroupTotals = Janus.Windows.GridEX.GroupTotals.ExpandedGroup
        Me.ResultsGridEX.Location = New System.Drawing.Point(0, 25)
        Me.ResultsGridEX.Name = "ResultsGridEX"
        Me.ResultsGridEX.RecordNavigator = True
        Me.ResultsGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.ResultsGridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.ResultsGridEX.Size = New System.Drawing.Size(1619, 1240)
        Me.ResultsGridEX.TabIndex = 0
        Me.ResultsGridEX.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.ResultsGridEX.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        '
        'ResultsToolStrip
        '
        Me.ResultsToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ResultsToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ResultsToolStrip.Name = "ResultsToolStrip"
        Me.ResultsToolStrip.Size = New System.Drawing.Size(1619, 25)
        Me.ResultsToolStrip.TabIndex = 1
        Me.ResultsToolStrip.Text = "ToolStrip1"
        '
        'CollapseGroupsCheckBox
        '
        Me.CollapseGroupsCheckBox.AutoSize = True
        Me.CollapseGroupsCheckBox.Location = New System.Drawing.Point(184, 70)
        Me.CollapseGroupsCheckBox.Name = "CollapseGroupsCheckBox"
        Me.CollapseGroupsCheckBox.Size = New System.Drawing.Size(149, 24)
        Me.CollapseGroupsCheckBox.TabIndex = 0
        Me.CollapseGroupsCheckBox.Text = "Collapse groups"
        Me.CollapseGroupsCheckBox.UseVisualStyleBackColor = True
        '
        'ResultsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1741, 1365)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ResultsForm"
        Me.Text = "WRST Caribou Monitoring Results"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ResultsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ViewsListBox As ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ResultsGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents ResultsToolStrip As ToolStrip
    Friend WithEvents CollapseGroupsCheckBox As CheckBox
End Class
