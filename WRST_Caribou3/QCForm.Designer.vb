<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QCForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QCForm))
        Me.QCToolStrip = New System.Windows.Forms.ToolStrip()
        Me.RunQCScriptToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OutputTextBox = New System.Windows.Forms.TextBox()
        Me.QCToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'QCToolStrip
        '
        Me.QCToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.QCToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunQCScriptToolStripButton})
        Me.QCToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.QCToolStrip.Name = "QCToolStrip"
        Me.QCToolStrip.Size = New System.Drawing.Size(2230, 32)
        Me.QCToolStrip.TabIndex = 0
        Me.QCToolStrip.Text = "ToolStrip1"
        '
        'RunQCScriptToolStripButton
        '
        Me.RunQCScriptToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.RunQCScriptToolStripButton.Image = CType(resources.GetObject("RunQCScriptToolStripButton.Image"), System.Drawing.Image)
        Me.RunQCScriptToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RunQCScriptToolStripButton.Name = "RunQCScriptToolStripButton"
        Me.RunQCScriptToolStripButton.Size = New System.Drawing.Size(134, 29)
        Me.RunQCScriptToolStripButton.Text = "Run QC checks"
        '
        'OutputTextBox
        '
        Me.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputTextBox.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputTextBox.Location = New System.Drawing.Point(0, 32)
        Me.OutputTextBox.Multiline = True
        Me.OutputTextBox.Name = "OutputTextBox"
        Me.OutputTextBox.Size = New System.Drawing.Size(2230, 1592)
        Me.OutputTextBox.TabIndex = 1
        '
        'QCForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2230, 1624)
        Me.Controls.Add(Me.OutputTextBox)
        Me.Controls.Add(Me.QCToolStrip)
        Me.Name = "QCForm"
        Me.Text = "QCForm"
        Me.QCToolStrip.ResumeLayout(False)
        Me.QCToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents QCToolStrip As ToolStrip
    Friend WithEvents RunQCScriptToolStripButton As ToolStripButton
    Friend WithEvents OutputTextBox As TextBox
End Class
