﻿Imports SkeeterUtilities.DataFileToDataTableConverters.DataFileToDataTableConverters
Public Class DatasetForm
    Private Sub DatasetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'Get the entire surveys dataset into a datatable
            Dim DT As DataTable = GetDataTableFromSQLServerDatabase(My.Settings.WRST_CaribouConnectionString, "SELECT * FROM Dataset_Full")

            'Load the dataset into the grid control
            Me.DatasetGridControl.DataSource = DT

            'Configure the grid control in a standard way
            SetUpGridControl(Me.DatasetGridControl)

            'Load the dataset into the pivot grid
            Me.DatasetPivotGridControl.DataSource = DT

            'Set up the pivot grid in a standard way
            SetUpPivotGridControl(Me.DatasetPivotGridControl)

        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub
End Class