<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeploymentsForAFrequencyForm
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.FrequencyToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToleranceToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FrequenciesDataGridView = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.FrequenciesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.FrequencyToolStripComboBox, Me.ToolStripLabel2, Me.ToleranceToolStripTextBox, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1064, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(154, 22)
        Me.ToolStripLabel1.Text = "Deployments for frequency:"
        '
        'FrequencyToolStripComboBox
        '
        Me.FrequencyToolStripComboBox.Name = "FrequencyToolStripComboBox"
        Me.FrequencyToolStripComboBox.Size = New System.Drawing.Size(121, 25)
        Me.FrequencyToolStripComboBox.Text = "0.000"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(25, 22)
        Me.ToolStripLabel2.Text = "+/-"
        '
        'ToleranceToolStripTextBox
        '
        Me.ToleranceToolStripTextBox.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToleranceToolStripTextBox.Name = "ToleranceToolStripTextBox"
        Me.ToleranceToolStripTextBox.Size = New System.Drawing.Size(100, 25)
        Me.ToleranceToolStripTextBox.Text = "0"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'FrequenciesDataGridView
        '
        Me.FrequenciesDataGridView.AllowUserToAddRows = False
        Me.FrequenciesDataGridView.AllowUserToDeleteRows = False
        Me.FrequenciesDataGridView.AllowUserToOrderColumns = True
        Me.FrequenciesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FrequenciesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FrequenciesDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.FrequenciesDataGridView.Name = "FrequenciesDataGridView"
        Me.FrequenciesDataGridView.ReadOnly = True
        Me.FrequenciesDataGridView.Size = New System.Drawing.Size(1064, 628)
        Me.FrequenciesDataGridView.TabIndex = 1
        '
        'DeploymentsForAFrequencyForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1064, 653)
        Me.Controls.Add(Me.FrequenciesDataGridView)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "DeploymentsForAFrequencyForm"
        Me.Text = "GPS Collar Deployments For A Frequency"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.FrequenciesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents FrequencyToolStripComboBox As ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToleranceToolStripTextBox As ToolStripTextBox
    Friend WithEvents FrequenciesDataGridView As DataGridView
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
