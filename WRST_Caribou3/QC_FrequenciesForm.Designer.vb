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
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportResultsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ProblemsDataGridView = New System.Windows.Forms.DataGridView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PossibleFrequenciesDataGridView = New System.Windows.Forms.DataGridView()
        CType(Me.QCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.QCToolStrip.SuspendLayout()
        CType(Me.ProblemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PossibleFrequenciesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QCBindingSource
        '
        '
        'QCToolStrip
        '
        Me.QCToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.QCToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunToolStripButton, Me.ToolStripSeparator1, Me.ExportResultsToolStripButton})
        Me.QCToolStrip.Location = New System.Drawing.Point(0, 111)
        Me.QCToolStrip.Name = "QCToolStrip"
        Me.QCToolStrip.Size = New System.Drawing.Size(1583, 31)
        Me.QCToolStrip.TabIndex = 2
        Me.QCToolStrip.Text = "ToolStrip1"
        '
        'RunToolStripButton
        '
        Me.RunToolStripButton.Image = CType(resources.GetObject("RunToolStripButton.Image"), System.Drawing.Image)
        Me.RunToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RunToolStripButton.Name = "RunToolStripButton"
        Me.RunToolStripButton.Size = New System.Drawing.Size(373, 28)
        Me.RunToolStripButton.Text = "Run Frequencies to Animals quality control checker"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ExportResultsToolStripButton
        '
        Me.ExportResultsToolStripButton.Image = CType(resources.GetObject("ExportResultsToolStripButton.Image"), System.Drawing.Image)
        Me.ExportResultsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExportResultsToolStripButton.Name = "ExportResultsToolStripButton"
        Me.ExportResultsToolStripButton.Size = New System.Drawing.Size(183, 28)
        Me.ExportResultsToolStripButton.Text = "Export results to CSV..."
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(0, 30)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(1583, 81)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'TextBox2
        '
        Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(0, 0)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(1583, 30)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = "Quality control check: Field detected frequencies to Animals matching"
        '
        'ProblemsDataGridView
        '
        Me.ProblemsDataGridView.AllowUserToAddRows = False
        Me.ProblemsDataGridView.AllowUserToDeleteRows = False
        Me.ProblemsDataGridView.AllowUserToOrderColumns = True
        Me.ProblemsDataGridView.AutoGenerateColumns = False
        Me.ProblemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProblemsDataGridView.DataSource = Me.QCBindingSource
        Me.ProblemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProblemsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.ProblemsDataGridView.Name = "ProblemsDataGridView"
        Me.ProblemsDataGridView.ReadOnly = True
        Me.ProblemsDataGridView.RowHeadersWidth = 51
        Me.ProblemsDataGridView.RowTemplate.Height = 24
        Me.ProblemsDataGridView.Size = New System.Drawing.Size(1128, 918)
        Me.ProblemsDataGridView.TabIndex = 5
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 142)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ProblemsDataGridView)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PossibleFrequenciesDataGridView)
        Me.SplitContainer1.Size = New System.Drawing.Size(1583, 918)
        Me.SplitContainer1.SplitterDistance = 1128
        Me.SplitContainer1.TabIndex = 6
        '
        'PossibleFrequenciesDataGridView
        '
        Me.PossibleFrequenciesDataGridView.AllowUserToAddRows = False
        Me.PossibleFrequenciesDataGridView.AllowUserToDeleteRows = False
        Me.PossibleFrequenciesDataGridView.AllowUserToOrderColumns = True
        Me.PossibleFrequenciesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PossibleFrequenciesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PossibleFrequenciesDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.PossibleFrequenciesDataGridView.Name = "PossibleFrequenciesDataGridView"
        Me.PossibleFrequenciesDataGridView.ReadOnly = True
        Me.PossibleFrequenciesDataGridView.RowHeadersWidth = 51
        Me.PossibleFrequenciesDataGridView.RowTemplate.Height = 24
        Me.PossibleFrequenciesDataGridView.Size = New System.Drawing.Size(451, 918)
        Me.PossibleFrequenciesDataGridView.TabIndex = 0
        '
        'QC_FrequenciesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1583, 1060)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.QCToolStrip)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "QC_FrequenciesForm"
        CType(Me.QCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.QCToolStrip.ResumeLayout(False)
        Me.QCToolStrip.PerformLayout()
        CType(Me.ProblemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PossibleFrequenciesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QCBindingSource As BindingSource
    Friend WithEvents QCToolStrip As ToolStrip
    Friend WithEvents RunToolStripButton As ToolStripButton
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ExportResultsToolStripButton As ToolStripButton
    Friend WithEvents ProblemsDataGridView As DataGridView
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PossibleFrequenciesDataGridView As DataGridView
End Class
