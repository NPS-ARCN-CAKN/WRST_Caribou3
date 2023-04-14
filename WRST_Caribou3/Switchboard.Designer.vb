<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Switchboard
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
        Me.EditSurveysDatasetButton = New System.Windows.Forms.Button()
        Me.AccessSurveysDatasetButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'EditSurveysDatasetButton
        '
        Me.EditSurveysDatasetButton.Location = New System.Drawing.Point(55, 59)
        Me.EditSurveysDatasetButton.Name = "EditSurveysDatasetButton"
        Me.EditSurveysDatasetButton.Size = New System.Drawing.Size(173, 23)
        Me.EditSurveysDatasetButton.TabIndex = 1
        Me.EditSurveysDatasetButton.Text = "Edit surveys dataset..."
        Me.EditSurveysDatasetButton.UseVisualStyleBackColor = True
        '
        'AccessSurveysDatasetButton
        '
        Me.AccessSurveysDatasetButton.Location = New System.Drawing.Point(55, 30)
        Me.AccessSurveysDatasetButton.Name = "AccessSurveysDatasetButton"
        Me.AccessSurveysDatasetButton.Size = New System.Drawing.Size(173, 23)
        Me.AccessSurveysDatasetButton.TabIndex = 2
        Me.AccessSurveysDatasetButton.Text = "Access surveys dataset..."
        Me.AccessSurveysDatasetButton.UseVisualStyleBackColor = True
        '
        'Switchboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 529)
        Me.Controls.Add(Me.AccessSurveysDatasetButton)
        Me.Controls.Add(Me.EditSurveysDatasetButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Switchboard"
        Me.Text = "WRST Caribou Monitoring Database Application"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EditSurveysDatasetButton As Button
    Friend WithEvents AccessSurveysDatasetButton As Button
End Class
