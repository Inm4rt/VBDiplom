
Imports MySql.Data.MySqlClient
Public Class Start
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.ShowDialog()
        'Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
        'Dim conn As New MySqlConnection(connStr)
        'Dim cmd As New MySqlCommand("SELECT * FROM Author", conn)
        'Dim da As New MySqlDataAdapter(cmd)
        'Dim dt As New DataTable

        'da.Fill(dt)


        'If dt.Rows.Count > 0 Then
        '    Label1.Text = dt.Rows(0)(1).ToString
        'Else
        '    MessageBox.Show("No", "noo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        'Try
        '    conn.Open()
        '    cmd.CommandText = "select * from Author"
        '    Dim reader As MySqlDataReader


        '    reader = cmd.ExecuteReader()
        '    While reader.Read()
        '        'получаем и сообщаем пользователю значения первого столбца базы данных для всех выбранных запросом строк
        '        Label1.Text += reader.GetValue(0)
        '    End While
        'Catch ex As Exception
        '    Label1.Text = ex.ToString()
        'End Try
        'conn.Close()
        'Console.WriteLine("Done.")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
