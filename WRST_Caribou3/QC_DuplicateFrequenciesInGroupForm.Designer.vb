<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QC_DuplicateFrequenciesInGroupForm
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
        Me.OutputTextBox = New System.Windows.Forms.TextBox()
        Me.DuplicatesGridEX = New Janus.Windows.GridEX.GridEX()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DuplicatesGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.OutputTextBox)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DuplicatesGridEX)
        Me.SplitContainer1.Size = New System.Drawing.Size(1458, 824)
        Me.SplitContainer1.SplitterDistance = 628
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
        Me.OutputTextBox.Size = New System.Drawing.Size(628, 824)
        Me.OutputTextBox.TabIndex = 0
        Me.OutputTextBox.WordWrap = False
        '
        'DuplicatesGridEX
        '
        Me.DuplicatesGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.DuplicatesGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DuplicatesGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.DuplicatesGridEX.Location = New System.Drawing.Point(0, 0)
        Me.DuplicatesGridEX.Name = "DuplicatesGridEX"
        Me.DuplicatesGridEX.Size = New System.Drawing.Size(826, 824)
        Me.DuplicatesGridEX.TabIndex = 0
        Me.DuplicatesGridEX.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'QC_DuplicateFrequenciesInGroupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1458, 824)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "QC_DuplicateFrequenciesInGroupForm"
        Me.Text = "Duplicate frequencies in Surveys table"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DuplicatesGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents OutputTextBox As TextBox
    Friend WithEvents DuplicatesGridEX As Janus.Windows.GridEX.GridEX
End Class
