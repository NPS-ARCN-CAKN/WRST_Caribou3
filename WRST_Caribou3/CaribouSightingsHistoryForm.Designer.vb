<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CaribouSightingsHistoryForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaribouSightingsHistoryForm))
        Me.SightingsHistoryDataGridView = New System.Windows.Forms.DataGridView()
        Me.SightingsToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.AnimalIDToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        CType(Me.SightingsHistoryDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SightingsToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'SightingsHistoryDataGridView
        '
        Me.SightingsHistoryDataGridView.AllowUserToAddRows = False
        Me.SightingsHistoryDataGridView.AllowUserToDeleteRows = False
        Me.SightingsHistoryDataGridView.AllowUserToOrderColumns = True
        Me.SightingsHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SightingsHistoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SightingsHistoryDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.SightingsHistoryDataGridView.Name = "SightingsHistoryDataGridView"
        Me.SightingsHistoryDataGridView.ReadOnly = True
        Me.SightingsHistoryDataGridView.Size = New System.Drawing.Size(800, 425)
        Me.SightingsHistoryDataGridView.TabIndex = 0
        '
        'SightingsToolStrip
        '
        Me.SightingsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.AnimalIDToolStripComboBox})
        Me.SightingsToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.SightingsToolStrip.Name = "SightingsToolStrip"
        Me.SightingsToolStrip.Size = New System.Drawing.Size(800, 25)
        Me.SightingsToolStrip.TabIndex = 1
        Me.SightingsToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(235, 22)
        Me.ToolStripLabel1.Text = "Select a caribou to see it's sightings history:"
        '
        'AnimalIDToolStripComboBox
        '
        Me.AnimalIDToolStripComboBox.Name = "AnimalIDToolStripComboBox"
        Me.AnimalIDToolStripComboBox.Size = New System.Drawing.Size(180, 25)
        '
        'CaribouSightingsHistoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SightingsHistoryDataGridView)
        Me.Controls.Add(Me.SightingsToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CaribouSightingsHistoryForm"
        Me.Text = "Caribou Sightings History"
        CType(Me.SightingsHistoryDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SightingsToolStrip.ResumeLayout(False)
        Me.SightingsToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SightingsHistoryDataGridView As DataGridView
    Friend WithEvents SightingsToolStrip As ToolStrip
    Friend WithEvents AnimalIDToolStripComboBox As ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
End Class
