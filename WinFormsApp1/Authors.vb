Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class Authors
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Private Sub Authors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataFill()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddAuthor.ShowDialog()
        DataFill()
    End Sub

    Private Sub DataFill()
        Dim cmd As New MySqlCommand("SELECT * FROM author", conn)
        Dim daAuth As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        Dim row As ArrayList
        DataGridView1.Rows.Clear()
        daAuth.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                row = New ArrayList
                row.Add(dt.Rows(i)(0))
                row.Add(dt.Rows(i)(1))
                DataGridView1.Rows.Add(row.ToArray())
            Next

        Else
            MessageBox.Show("No", "noo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn.Open()
        Dim cmdBook As New MySqlCommand("delete from author where id = @id;", conn)
        Dim ind = DataGridView1.SelectedRows(0).Index.ToString()
        cmdBook.Parameters.AddWithValue("@id", SqlDbType.Int).Value = DataGridView1.Rows(ind).Cells(0).Value
        cmdBook.ExecuteReader()
        conn.Close()
        DataFill()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim editForm As New EditAuthor
        Dim ind = DataGridView1.SelectedRows(0).Index.ToString()
        editForm.SendData(DataGridView1.Rows(ind).Cells(0).Value, DataGridView1.Rows(ind).Cells(1).Value)
        editForm.ShowDialog()
        DataFill()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) 

    End Sub
End Class