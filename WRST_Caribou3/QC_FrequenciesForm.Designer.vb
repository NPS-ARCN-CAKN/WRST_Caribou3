<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QC_FrequenciesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QC_FrequenciesForm))
        Me.QCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.QCToolStrip = New System.Windows.Forms.ToolStrip()
        Me.RunToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.QCGridEX = New Janus.Windows.GridEX.GridEX()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportResultsToolStripButton = New System.Windows.Forms.ToolStripButton()
        CType(Me.QCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.QCToolStrip.SuspendLayout()
        CType(Me.QCGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QCToolStrip
        '
        Me.QCToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.QCToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunToolStripButton, Me.ToolStripSeparator1, Me.ExportResultsToolStripButton})
        Me.QCToolStrip.Location = New System.Drawing.Point(0, 135)
        Me.QCToolStrip.Name = "QCToolStrip"
        Me.QCToolStrip.Size = New System.Drawing.Size(1781, 32)
        Me.QCToolStrip.TabIndex = 2
        Me.QCToolStrip.Text = "ToolStrip1"
        '
        'RunToolStripButton
        '
        Me.RunToolStripButton.Image = CType(resources.GetObject("RunToolStripButton.Image"), System.Drawing.Image)
        Me.RunToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RunToolStripButton.Name = "RunToolStripButton"
        Me.RunToolStripButton.Size = New System.Drawing.Size(442, 29)
        Me.RunToolStripButton.Text = "Run Frequencies to Animals quality control checker"
        '
        'QCGridEX
        '
        Me.QCGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.QCGridEX.AlternatingColors = True
        Me.QCGridEX.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.QCGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.QCGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.QCGridEX.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed
        Me.QCGridEX.Location = New System.Drawing.Point(0, 167)
        Me.QCGridEX.Name = "QCGridEX"
        Me.QCGridEX.RecordNavigator = True
        Me.QCGridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection
        Me.QCGridEX.Size = New System.Drawing.Size(1781, 1287)
        Me.QCGridEX.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(0, 35)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(1781, 100)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'TextBox2
        '
        Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(0, 0)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(1781, 35)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = "Quality control check: Field detected frequencies to Animals matching"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 32)
        '
        'ExportResultsToolStripButton
        '
        Me.ExportResultsToolStripButton.Image = CType(resources.GetObject("ExportResultsToolStripButton.Image"), System.Drawing.Image)
        Me.ExportResultsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExportResultsToolStripButton.Name = "ExportResultsToolStripButton"
        Me.ExportResultsToolStripButton.Size = New System.Drawing.Size(218, 29)
        Me.ExportResultsToolStripButton.Text = "Export results to CSV..."
        '
        'QC_FrequenciesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1781, 1454)
        Me.Controls.Add(Me.QCGridEX)
        Me.Controls.Add(Me.QCToolStrip)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "QC_FrequenciesForm"
        CType(Me.QCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.QCToolStrip.ResumeLayout(False)
        Me.QCToolStrip.PerformLayout()
        CType(Me.QCGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QCBindingSource As BindingSource
    Friend WithEvents QCToolStrip As ToolStrip
    Friend WithEvents RunToolStripButton As ToolStripButton
    Friend WithEvents QCGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ExportResultsToolStripButton As ToolStripButton
End Class
