<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SurvivorshipForm
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
        Me.SurvivorshipGridEX = New Janus.Windows.GridEX.GridEX()
        CType(Me.SurvivorshipGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SurvivorshipGridEX
        '
        Me.SurvivorshipGridEX.AlternatingColors = True
        Me.SurvivorshipGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SurvivorshipGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.SurvivorshipGridEX.GroupByBoxVisible = False
        Me.SurvivorshipGridEX.Location = New System.Drawing.Point(0, 0)
        Me.SurvivorshipGridEX.Name = "SurvivorshipGridEX"
        Me.SurvivorshipGridEX.RecordNavigator = True
        Me.SurvivorshipGridEX.Size = New System.Drawing.Size(1599, 954)
        Me.SurvivorshipGridEX.TabIndex = 0
        '
        'SurvivorshipForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1599, 954)
        Me.Controls.Add(Me.SurvivorshipGridEX)
        Me.Name = "SurvivorshipForm"
        Me.Text = "SurvivorshipForm"
        CType(Me.SurvivorshipGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SurvivorshipGridEX As Janus.Windows.GridEX.GridEX
End Class
