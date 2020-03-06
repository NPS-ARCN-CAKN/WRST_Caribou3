<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrequenciesNotFoundInAnimalMovementForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrequenciesNotFoundInAnimalMovementForm))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.OutputTextBox = New System.Windows.Forms.TextBox()
        Me.DuplicatesGridEX = New Janus.Windows.GridEX.GridEX()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ExportResultsToolStripButton = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DuplicatesGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 32)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.OutputTextBox)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DuplicatesGridEX)
        Me.SplitContainer1.Size = New System.Drawing.Size(1458, 792)
        Me.SplitContainer1.SplitterDistance = 268
        Me.SplitContainer1.TabIndex = 0
        '
        'OutputTextBox
        '
        Me.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputTextBox.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputTextBox.Location = New System.Drawing.Point(0, 0)
        Me.OutputTextBox.Multiline = True
        Me.OutputTextBox.Name = "OutputTextBox"
        Me.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.OutputTextBox.Size = New System.Drawing.Size(268, 792)
        Me.OutputTextBox.TabIndex = 0
        Me.OutputTextBox.WordWrap = False
        '
        'DuplicatesGridEX
        '
        Me.DuplicatesGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.DuplicatesGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DuplicatesGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.DuplicatesGridEX.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed
        Me.DuplicatesGridEX.Location = New System.Drawing.Point(0, 0)
        Me.DuplicatesGridEX.Name = "DuplicatesGridEX"
        Me.DuplicatesGridEX.Size = New System.Drawing.Size(1186, 792)
        Me.DuplicatesGridEX.TabIndex = 0
        Me.DuplicatesGridEX.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportResultsToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1458, 32)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ExportResultsToolStripButton
        '
        Me.ExportResultsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ExportResultsToolStripButton.Image = CType(resources.GetObject("ExportResultsToolStripButton.Image"), System.Drawing.Image)
        Me.ExportResultsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExportResultsToolStripButton.Name = "ExportResultsToolStripButton"
        Me.ExportResultsToolStripButton.Size = New System.Drawing.Size(182, 29)
        Me.ExportResultsToolStripButton.Text = "Export results to CSV"
        '
        'FrequenciesNotFoundInAnimalMovementForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1458, 824)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrequenciesNotFoundInAnimalMovementForm"
        Me.Text = "Survey frequencies not found in Animal Movement"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DuplicatesGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents OutputTextBox As TextBox
    Friend WithEvents DuplicatesGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ExportResultsToolStripButton As ToolStripButton
End Class
