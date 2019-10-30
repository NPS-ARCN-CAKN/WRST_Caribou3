Partial Class WRST_CaribouDataSet
    Partial Public Class SurveysDataTable
        'Private Sub SurveysDataTable_SurveysRowChanging(sender As Object, e As SurveysRowChangeEvent) Handles Me.SurveysRowChanging
        '    'Try
        '    If Not IsDBNull(e.Row.CertificationLevel) Then
        '        If e.Row.CertificationLevel = "Certified" Then
        '            e.Row.RowState = DataRowState.Unchanged
        '            'Throw New System.Exception("Record is certified")

        '            'MsgBox("Record is certified and may not be edited")
        '        End If
        '    End If
        '    'Catch ex As Exception
        '    '    'e.Row.EndEdit()
        '    '    'e.Row.CancelEdit()
        '    '    MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        '    'End Try
        'End Sub

    End Class
End Class
