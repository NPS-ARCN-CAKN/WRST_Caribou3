<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CapturesForm
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
        Dim CapturesGridEX_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CapturesForm))
        Me.WRST_CaribouDataSet = New WRST_Caribou3.WRST_CaribouDataSet()
        Me.CapturesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CapturesTableAdapter = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.CapturesTableAdapter()
        Me.TableAdapterManager = New WRST_Caribou3.WRST_CaribouDataSetTableAdapters.TableAdapterManager()
        Me.CapturesGridEX = New Janus.Windows.GridEX.GridEX()
        Me.CapturesToolStrip = New System.Windows.Forms.ToolStrip()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        CType(Me.WRST_CaribouDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CapturesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CapturesGridEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CapturesToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'WRST_CaribouDataSet
        '
        Me.WRST_CaribouDataSet.DataSetName = "WRST_CaribouDataSet"
        Me.WRST_CaribouDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CapturesBindingSource
        '
        Me.CapturesBindingSource.DataMember = "Captures"
        Me.CapturesBindingSource.DataSource = Me.WRST_CaribouDataSet
        '
        'CapturesTableAdapter
        '
        Me.CapturesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CapturesTableAdapter = Me.CapturesTableAdapter
        Me.TableAdapterManager.CollaredAnimalsInGroupsTableAdapter = Nothing
        Me.TableAdapterManager.SurveyFlightsTableAdapter = Nothing
        Me.TableAdapterManager.SurveysTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WRST_Caribou3.WRST_CaribouDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CapturesGridEX
        '
        Me.CapturesGridEX.DataSource = Me.CapturesBindingSource
        CapturesGridEX_DesignTimeLayout.LayoutString = resources.GetString("CapturesGridEX_DesignTimeLayout.LayoutString")
        Me.CapturesGridEX.DesignTimeLayout = CapturesGridEX_DesignTimeLayout
        Me.CapturesGridEX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CapturesGridEX.Location = New System.Drawing.Point(0, 32)
        Me.CapturesGridEX.Name = "CapturesGridEX"
        Me.CapturesGridEX.Size = New System.Drawing.Size(2080, 1284)
        Me.CapturesGridEX.TabIndex = 1
        '
        'CapturesToolStrip
        '
        Me.CapturesToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CapturesToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton})
        Me.CapturesToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.CapturesToolStrip.Name = "CapturesToolStrip"
        Me.CapturesToolStrip.Size = New System.Drawing.Size(2080, 32)
        Me.CapturesToolStrip.TabIndex = 2
        Me.CapturesToolStrip.Text = "ToolStrip1"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(53, 29)
        Me.SaveToolStripButton.Text = "Save"
        '
        'CapturesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2080, 1316)
        Me.Controls.Add(Me.CapturesGridEX)
        Me.Controls.Add(Me.CapturesToolStrip)
        Me.Name = "CapturesForm"
        Me.Text = "CapturesForm"
        CType(Me.WRST_CaribouDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CapturesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CapturesGridEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CapturesToolStrip.ResumeLayout(False)
        Me.CapturesToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WRST_CaribouDataSet As WRST_CaribouDataSet
    Friend WithEvents CapturesBindingSource As BindingSource
    Friend WithEvents CapturesTableAdapter As WRST_CaribouDataSetTableAdapters.CapturesTableAdapter
    Friend WithEvents TableAdapterManager As WRST_CaribouDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CapturesGridEX As Janus.Windows.GridEX.GridEX
    Friend WithEvents CapturesToolStrip As ToolStrip
    Friend WithEvents SaveToolStripButton As ToolStripButton
End Class
