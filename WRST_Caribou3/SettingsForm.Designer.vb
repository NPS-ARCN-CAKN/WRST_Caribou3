<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
        Me.SettingsPropertyGrid = New System.Windows.Forms.PropertyGrid()
        Me.WRST_CaribouConnectionStringPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WRST_CaribouConnectionStringTextBox = New System.Windows.Forms.TextBox()
        Me.UpdateConnectionStringButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.WRST_CaribouConnectionStringPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'SettingsPropertyGrid
        '
        Me.SettingsPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SettingsPropertyGrid.Location = New System.Drawing.Point(0, 186)
        Me.SettingsPropertyGrid.Name = "SettingsPropertyGrid"
        Me.SettingsPropertyGrid.Size = New System.Drawing.Size(983, 573)
        Me.SettingsPropertyGrid.TabIndex = 0
        '
        'WRST_CaribouConnectionStringPanel
        '
        Me.WRST_CaribouConnectionStringPanel.Controls.Add(Me.Label2)
        Me.WRST_CaribouConnectionStringPanel.Controls.Add(Me.UpdateConnectionStringButton)
        Me.WRST_CaribouConnectionStringPanel.Controls.Add(Me.WRST_CaribouConnectionStringTextBox)
        Me.WRST_CaribouConnectionStringPanel.Controls.Add(Me.Label1)
        Me.WRST_CaribouConnectionStringPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.WRST_CaribouConnectionStringPanel.Location = New System.Drawing.Point(0, 0)
        Me.WRST_CaribouConnectionStringPanel.Name = "WRST_CaribouConnectionStringPanel"
        Me.WRST_CaribouConnectionStringPanel.Size = New System.Drawing.Size(983, 186)
        Me.WRST_CaribouConnectionStringPanel.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(643, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter the connection string to the WRST_Caribou SQL Server database and click Upd" &
    "ate:"
        '
        'WRST_CaribouConnectionStringTextBox
        '
        Me.WRST_CaribouConnectionStringTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WRST_CaribouConnectionStringTextBox.Location = New System.Drawing.Point(17, 37)
        Me.WRST_CaribouConnectionStringTextBox.Multiline = True
        Me.WRST_CaribouConnectionStringTextBox.Name = "WRST_CaribouConnectionStringTextBox"
        Me.WRST_CaribouConnectionStringTextBox.Size = New System.Drawing.Size(844, 105)
        Me.WRST_CaribouConnectionStringTextBox.TabIndex = 1
        '
        'UpdateConnectionStringButton
        '
        Me.UpdateConnectionStringButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UpdateConnectionStringButton.Location = New System.Drawing.Point(867, 74)
        Me.UpdateConnectionStringButton.Name = "UpdateConnectionStringButton"
        Me.UpdateConnectionStringButton.Size = New System.Drawing.Size(104, 30)
        Me.UpdateConnectionStringButton.TabIndex = 2
        Me.UpdateConnectionStringButton.Text = "Update"
        Me.UpdateConnectionStringButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(683, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Update other application settings using the property grid below. Your changes wil" &
    "l be immediate."
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 759)
        Me.Controls.Add(Me.SettingsPropertyGrid)
        Me.Controls.Add(Me.WRST_CaribouConnectionStringPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "SettingsForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.WRST_CaribouConnectionStringPanel.ResumeLayout(False)
        Me.WRST_CaribouConnectionStringPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SettingsPropertyGrid As PropertyGrid
    Friend WithEvents WRST_CaribouConnectionStringPanel As Panel
    Friend WithEvents UpdateConnectionStringButton As Button
    Friend WithEvents WRST_CaribouConnectionStringTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
