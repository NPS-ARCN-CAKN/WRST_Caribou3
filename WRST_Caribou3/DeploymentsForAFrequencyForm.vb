Imports System.Data.SqlClient

Public Class DeploymentsForAFrequencyForm

    Public Sub New(Optional Frequency As Double = 0.000, Optional Tolerance As Double = 0.000)

        ' This call is required by the designer.
        InitializeComponent()

        Me.FrequencyToolStripComboBox.Text = Frequency
        Me.ToleranceToolStripTextBox.Text = Tolerance

        GetFrequencies()
    End Sub

    Private Sub GetFrequencies()
        If IsNumeric(Me.FrequencyToolStripComboBox.Text) = True Then

            Me.FrequenciesDataGridView.DataSource = Nothing


            'This is the stored procedure and frequency to look for
            Dim QueryString As String = "GetDeploymentsForAFrequency " & CDbl(Me.FrequencyToolStripComboBox.Text) & " " & IIf(IsNumeric(Me.ToleranceToolStripTextBox.Text) = True, ", " & Me.ToleranceToolStripTextBox.Text.Trim, ",0.000")

            Try
                Using Connection As New SqlConnection(My.Settings.WRST_CaribouConnectionString)
                    Connection.Open()
                    Dim Command As New SqlCommand(QueryString, Connection)
                    Dim Reader As SqlDataReader = Command.ExecuteReader()
                    Dim FrequenciesDataTable As New DataTable

                    'Load the data table from the data reader
                    FrequenciesDataTable.Load(Reader)

                    Me.FrequenciesDataGridView.DataSource = FrequenciesDataTable

                End Using
            Catch ex As Exception
                MessageBox.Show("Error while executing .. " & ex.Message, "")
            End Try
        Else
            MsgBox("The collar frequency must be numeric. Canceled.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub FrequencyToolStripComboBox_TextChanged(sender As Object, e As EventArgs) Handles FrequencyToolStripComboBox.TextChanged
        GetFrequencies()
    End Sub

    Private Sub DeploymentsForAFrequencyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAvailableFrequenciesIntoComboBox()
    End Sub

    Private Sub LoadAvailableFrequenciesIntoComboBox()
        Try
            Using Connection As New SqlConnection(My.Settings.WRST_CaribouConnectionString)
                Connection.Open()
                Dim Command As New SqlCommand("SELECT DISTINCT Frequency FROM tmpCollarDeployments ORDER BY Frequency", Connection)
                Dim Reader As SqlDataReader = Command.ExecuteReader()
                Dim FrequenciesDataTable As New DataTable

                'Load the data table from the data reader
                FrequenciesDataTable.Load(Reader)

                For Each FrequencyRow As DataRow In FrequenciesDataTable.Rows
                    Me.FrequencyToolStripComboBox.Items.Add(FrequencyRow.Item("Frequency"))
                Next

            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading frequencies from database. " & ex.Message, "")
        End Try
    End Sub

    Private Sub ToleranceToolStripTextBox_TextChanged(sender As Object, e As EventArgs) Handles ToleranceToolStripTextBox.TextChanged
        If IsNumeric(Me.ToleranceToolStripTextBox.Text) = True Then
            GetFrequencies()
        Else
            MsgBox("Tolerance must be numeric")
        End If
    End Sub
End Class