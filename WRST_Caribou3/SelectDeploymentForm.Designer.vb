<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDeploymentForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectDeploymentForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SelectButton = New System.Windows.Forms.Button()
        Me.CancelFormButton = New System.Windows.Forms.Button()
        Me.LabelPanel = New System.Windows.Forms.Panel()
        Me.HeaderLabel = New System.Windows.Forms.Label()
        Me.DeploymentsGridEX = New Janus.Windows.GridEX.GridEX()
        Me.Panel1.SuspendLayout()
        Me.LabelPanel.SuspendLayout()
        CType(Me.DeploymentsGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SelectButton)
        Me.Panel1.Controls.Add(Me.CancelFormButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 259)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(785, 42)
        Me.Panel1.TabIndex = 0
        '
        'SelectButton
        '
        Me.SelectButton.Enabled = False
        Me.SelectButton.Location = New System.Drawing.Point(635, 5)
        Me.SelectButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.SelectButton.Name = "SelectButton"
        Me.SelectButton.Size = New System.Drawing.Size(56, 19)
        Me.SelectButton.TabIndex = 1
        Me.SelectButton.Text = "Select"
        Me.SelectButton.UseVisualStyleBackColor = True
        '
        'CancelFormButton
        '
        Me.CancelFormButton.Enabled = False
        Me.CancelFormButton.Location = New System.Drawing.Point(714, 5)
        Me.CancelFormButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CancelFormButton.Name = "CancelFormButton"
        Me.CancelFormButton.Size = New System.Drawing.Size(56, 19)
        Me.CancelFormButton.TabIndex = 0
        Me.CancelFormButton.Text = "Cancel"
        Me.CancelFormButton.UseVisualStyleBackColor = True
        '
        'LabelPanel
        '
        Me.LabelPanel.Controls.Add(Me.HeaderLabel)
        Me.LabelPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelPanel.Location = New System.Drawing.Point(0, 0)
        Me.LabelPanel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.LabelPanel.Name = "LabelPanel"
        Me.LabelPanel.Size = New System.Drawing.Size(785, 81)
        Me.LabelPanel.TabIndex = 1
        '
        'HeaderLabel
        '
        Me.HeaderLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HeaderLabel.AutoEllipsis = True
        Me.HeaderLabel.AutoSize = True
        Me.HeaderLabel.Location = New System.Drawing.Point(0, 0)
        Me.HeaderLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.HeaderLabel.MaximumSize = New System.Drawing.Size(450, 81)
        Me.HeaderLabel.Name = "HeaderLabel"
        Me.HeaderLabel.Size = New System.Drawing.Size(450, 78)
        Me.HeaderLabel.TabIndex = 0
        Me.HeaderLabel.Text = resources.GetString("HeaderLabel.Text")
        '
        'DeploymentsGridEX
        '
        Me.DeploymentsGridEX.AlternatingColors = True
        Me.DeploymentsGridEX.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.DeploymentsGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DeploymentsGridEX.GroupByBoxVisible = False
        Me.DeploymentsGridEX.Location = New System.Drawing.Point(0, 81)
        Me.DeploymentsGridEX.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DeploymentsGridEX.Name = "DeploymentsGridEX"
        Me.DeploymentsGridEX.Size = New System.Drawing.Size(785, 178)
        Me.DeploymentsGridEX.TabIndex = 2
        '
        'SelectDeploymentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 301)
        Me.Controls.Add(Me.DeploymentsGridEX)
        Me.Controls.Add(Me.LabelPanel)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "SelectDeploymentForm"
        Me.Text = "Select a deployment"
        Me.Panel1.ResumeLayout(False)
        Me.LabelPanel.ResumeLayout(False)
        Me.LabelPanel.PerformLayout()
        CType(Me.DeploymentsGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelPanel As Panel
    Friend WithEvents HeaderLabel As Label
    Friend WithEvents SelectButton As Button
    Friend WithEvents CancelFormButton As Button
    Friend WithEvents DeploymentsGridEX As Janus.Windows.GridEX.GridEX
End Class
