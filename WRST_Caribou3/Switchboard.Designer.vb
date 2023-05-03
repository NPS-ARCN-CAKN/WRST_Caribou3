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
        Me.EditRadiotrackingDatasetButton = New System.Windows.Forms.Button()
        Me.AccessRadiotrackingDatasetButton = New System.Windows.Forms.Button()
        Me.RadiotrackingLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GetDeploymentsForHerdFrequencyAndDateButton = New System.Windows.Forms.Button()
        Me.OpenCaribouProfileFormButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'EditSurveysDatasetButton
        '
        Me.EditSurveysDatasetButton.Location = New System.Drawing.Point(16, 75)
        Me.EditSurveysDatasetButton.Name = "EditSurveysDatasetButton"
        Me.EditSurveysDatasetButton.Size = New System.Drawing.Size(173, 23)
        Me.EditSurveysDatasetButton.TabIndex = 1
        Me.EditSurveysDatasetButton.Text = "Edit surveys dataset..."
        Me.EditSurveysDatasetButton.UseVisualStyleBackColor = True
        '
        'AccessSurveysDatasetButton
        '
        Me.AccessSurveysDatasetButton.Location = New System.Drawing.Point(16, 46)
        Me.AccessSurveysDatasetButton.Name = "AccessSurveysDatasetButton"
        Me.AccessSurveysDatasetButton.Size = New System.Drawing.Size(173, 23)
        Me.AccessSurveysDatasetButton.TabIndex = 2
        Me.AccessSurveysDatasetButton.Text = "Access surveys dataset..."
        Me.AccessSurveysDatasetButton.UseVisualStyleBackColor = True
        '
        'EditRadiotrackingDatasetButton
        '
        Me.EditRadiotrackingDatasetButton.Location = New System.Drawing.Point(16, 170)
        Me.EditRadiotrackingDatasetButton.Name = "EditRadiotrackingDatasetButton"
        Me.EditRadiotrackingDatasetButton.Size = New System.Drawing.Size(173, 24)
        Me.EditRadiotrackingDatasetButton.TabIndex = 3
        Me.EditRadiotrackingDatasetButton.Text = "Edit radiotracking dataset..."
        Me.EditRadiotrackingDatasetButton.UseVisualStyleBackColor = True
        '
        'AccessRadiotrackingDatasetButton
        '
        Me.AccessRadiotrackingDatasetButton.Enabled = False
        Me.AccessRadiotrackingDatasetButton.Location = New System.Drawing.Point(16, 141)
        Me.AccessRadiotrackingDatasetButton.Name = "AccessRadiotrackingDatasetButton"
        Me.AccessRadiotrackingDatasetButton.Size = New System.Drawing.Size(173, 23)
        Me.AccessRadiotrackingDatasetButton.TabIndex = 4
        Me.AccessRadiotrackingDatasetButton.Text = "Access radiotracking dataset..."
        Me.AccessRadiotrackingDatasetButton.UseVisualStyleBackColor = True
        '
        'RadiotrackingLabel
        '
        Me.RadiotrackingLabel.AutoSize = True
        Me.RadiotrackingLabel.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadiotrackingLabel.Location = New System.Drawing.Point(12, 116)
        Me.RadiotrackingLabel.Name = "RadiotrackingLabel"
        Me.RadiotrackingLabel.Size = New System.Drawing.Size(139, 22)
        Me.RadiotrackingLabel.TabIndex = 5
        Me.RadiotrackingLabel.Text = "Radiotracking"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(412, 22)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Aerial composition and abundance surveys"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 211)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 22)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Quality control"
        '
        'GetDeploymentsForHerdFrequencyAndDateButton
        '
        Me.GetDeploymentsForHerdFrequencyAndDateButton.Location = New System.Drawing.Point(16, 236)
        Me.GetDeploymentsForHerdFrequencyAndDateButton.Name = "GetDeploymentsForHerdFrequencyAndDateButton"
        Me.GetDeploymentsForHerdFrequencyAndDateButton.Size = New System.Drawing.Size(412, 23)
        Me.GetDeploymentsForHerdFrequencyAndDateButton.TabIndex = 7
        Me.GetDeploymentsForHerdFrequencyAndDateButton.Text = "Get a list of possible GPS collar deployments for a herd, frequency and date..."
        Me.GetDeploymentsForHerdFrequencyAndDateButton.UseVisualStyleBackColor = True
        '
        'OpenCaribouProfileFormButton
        '
        Me.OpenCaribouProfileFormButton.Location = New System.Drawing.Point(16, 265)
        Me.OpenCaribouProfileFormButton.Name = "OpenCaribouProfileFormButton"
        Me.OpenCaribouProfileFormButton.Size = New System.Drawing.Size(412, 23)
        Me.OpenCaribouProfileFormButton.TabIndex = 9
        Me.OpenCaribouProfileFormButton.Text = "Get a caribou profile..."
        Me.OpenCaribouProfileFormButton.UseVisualStyleBackColor = True
        '
        'Switchboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 531)
        Me.Controls.Add(Me.OpenCaribouProfileFormButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GetDeploymentsForHerdFrequencyAndDateButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RadiotrackingLabel)
        Me.Controls.Add(Me.AccessRadiotrackingDatasetButton)
        Me.Controls.Add(Me.EditRadiotrackingDatasetButton)
        Me.Controls.Add(Me.AccessSurveysDatasetButton)
        Me.Controls.Add(Me.EditSurveysDatasetButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Switchboard"
        Me.Text = "WRST Caribou Monitoring Database Application"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EditSurveysDatasetButton As Button
    Friend WithEvents AccessSurveysDatasetButton As Button
    Friend WithEvents EditRadiotrackingDatasetButton As Button
    Friend WithEvents AccessRadiotrackingDatasetButton As Button
    Friend WithEvents RadiotrackingLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GetDeploymentsForHerdFrequencyAndDateButton As Button
    Friend WithEvents OpenCaribouProfileFormButton As Button
End Class
