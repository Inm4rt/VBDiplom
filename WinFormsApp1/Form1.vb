Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class Form1
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Private Sub DataFill()
        Dim cmd As New MySqlCommand("SELECT * FROM book", conn)
        Dim daBook As New MySqlDataAdapter(cmd)
        Dim dtBook As New DataTable
        Dim reader As MySqlDataReader
        Dim row As ArrayList
        DataGridView1.Rows.Clear()
        daBook.Fill(dtBook)
        If dtBook.Rows.Count > 0 Then
            For i = 0 To dtBook.Rows.Count - 1
                row = New ArrayList
                Dim author_id As Integer
                row.Add(dtBook.Rows(i)(0))
                row.Add(dtBook.Rows(i)(1))
                conn.Open()
                cmd = New MySqlCommand("SELECT name, author_id FROM bookentity where id = @id", conn)
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = dtBook.Rows(i)(1)
                reader = cmd.ExecuteReader()
                While reader.Read()
                    row.Add(reader.GetValue(0))
                    author_id = reader.GetValue(1)
                End While
                reader.Close()

                cmd = New MySqlCommand("SELECT fio FROM author where id = @id", conn)
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = author_id
                reader = cmd.ExecuteReader()
                While reader.Read()
                    row.Add(reader.GetValue(0))
                End While
                reader.Close()
                row.Add(dtBook.Rows(i)(2))
                row.Add(dtBook.Rows(i)(3))
                row.Add(dtBook.Rows(i)(4))
                row.Add(author_id)

                conn.Close()
                DataGridView1.Rows.Add(row.ToArray())
            Next
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataFill()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddBook.ShowDialog()
        DataFill()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim reader As MySqlDataReader
        conn.Open()
        Dim cmd As New MySqlCommand("delete from book where id = @id;", conn)
        Dim ind = DataGridView1.SelectedRows(0).Index.ToString()
        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = DataGridView1.Rows(ind).Cells(0).Value

        reader = cmd.ExecuteReader()
        reader.Close()

        cmd = New MySqlCommand("delete from bookentity where id = @id;", conn)
        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = DataGridView1.Rows(ind).Cells(1).Value
        reader = cmd.ExecuteReader()
        reader.Close()
        conn.Close()
        DataFill()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim editForm As New EditBook
        Dim ind = DataGridView1.SelectedRows(0).Index.ToString()

        editForm.SendData(DataGridView1.Rows(ind).Cells(0).Value,
                          DataGridView1.Rows(ind).Cells(1).Value,
                          DataGridView1.Rows(ind).Cells(2).Value,
                          DataGridView1.Rows(ind).Cells(7).Value,
                          DataGridView1.Rows(ind).Cells(4).Value,
                          DataGridView1.Rows(ind).Cells(5).Value,
                          DataGridView1.Rows(ind).Cells(6).Value)
        editForm.ShowDialog()
        DataFill()
    End Sub
End Class
