﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.WRST_CaribouConnectionStringTextBox = New System.Windows.Forms.TextBox()
        Me.WRST_CaribouConnectionStringPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'SettingsPropertyGrid
        '
        Me.SettingsPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SettingsPropertyGrid.Location = New System.Drawing.Point(0, 104)
        Me.SettingsPropertyGrid.Name = "SettingsPropertyGrid"
        Me.SettingsPropertyGrid.Size = New System.Drawing.Size(1178, 640)
        Me.SettingsPropertyGrid.TabIndex = 0
        '
        'WRST_CaribouConnectionStringPanel
        '
        Me.WRST_CaribouConnectionStringPanel.Controls.Add(Me.Label2)
        Me.WRST_CaribouConnectionStringPanel.Controls.Add(Me.WRST_CaribouConnectionStringTextBox)
        Me.WRST_CaribouConnectionStringPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.WRST_CaribouConnectionStringPanel.Location = New System.Drawing.Point(0, 0)
        Me.WRST_CaribouConnectionStringPanel.Name = "WRST_CaribouConnectionStringPanel"
        Me.WRST_CaribouConnectionStringPanel.Size = New System.Drawing.Size(1178, 104)
        Me.WRST_CaribouConnectionStringPanel.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(850, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Update other application settings using the property grid below. Your changes may" &
    " require you to restart the application."
        '
        'WRST_CaribouConnectionStringTextBox
        '
        Me.WRST_CaribouConnectionStringTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WRST_CaribouConnectionStringTextBox.Enabled = False
        Me.WRST_CaribouConnectionStringTextBox.Location = New System.Drawing.Point(17, 12)
        Me.WRST_CaribouConnectionStringTextBox.Multiline = True
        Me.WRST_CaribouConnectionStringTextBox.Name = "WRST_CaribouConnectionStringTextBox"
        Me.WRST_CaribouConnectionStringTextBox.Size = New System.Drawing.Size(1149, 49)
        Me.WRST_CaribouConnectionStringTextBox.TabIndex = 1
        Me.WRST_CaribouConnectionStringTextBox.Text = "To change the WRST_Caribou database connection string you must edit WRST_Caribou3" &
    ".vshost.exe.config in the application's installation directory."
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 744)
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
    Friend WithEvents WRST_CaribouConnectionStringTextBox As TextBox
    Friend WithEvents Label2 As Label
End Class
