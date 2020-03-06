Imports System.Data.SqlClient

Public Class AvailableCollarsInventoryForADateForm

    Private SurveyDateValue As Date
    Public Property SurveyDate() As Date
        Get
            Return SurveyDateValue
        End Get
        Set(ByVal value As Date)
            SurveyDateValue = value
        End Set
    End Property





    Private Sub GetAvailableCollarsInventoryForADate(InventoryDate As Date)
        Dim CollarsDataTable As New DataTable("Collars")
        Try
            If IsDate(InventoryDate) Then
                Dim SqlCommand As New SqlCommand("spAvailableCollarsInventoryForADate", New SqlConnection(My.Settings.WRST_CaribouConnectionString))
                With SqlCommand
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@SurveyDate", InventoryDate))
                End With

                Dim SqlAdapter As New SqlDataAdapter(SqlCommand)
                Dim CollarsDataset As New DataSet("Collars")
                SqlAdapter.Fill(CollarsDataset, "Collars")
                Me.InventoryBindingSource.DataSource = CollarsDataset.Tables("Collars")
                Me.CollarsDataGridView.DataSource = Me.InventoryBindingSource
            Else
                Me.InventoryBindingSource.DataSource = Nothing
                Me.CollarsDataGridView.DataSource = Me.InventoryBindingSource
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        GetAvailableCollarsInventoryForADate(Me.InventoryDateTimePicker.Value)
    End Sub

    Private Sub AvailableCollarsInventoryForADateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.InventoryBindingNavigator.BindingSource = Me.InventoryBindingSource
        If IsDate(Me.SurveyDate) Then
            Me.InventoryDateTimePicker.Value = Me.SurveyDate
            GetAvailableCollarsInventoryForADate(Me.SurveyDate)
        End If
    End Sub
End Class