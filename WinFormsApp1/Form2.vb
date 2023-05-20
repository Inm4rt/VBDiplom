Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class Form2
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataFill()
    End Sub

    Private Sub DataFill()
        Dim cmd As New MySqlCommand("SELECT * FROM library", conn)
        Dim daBook As New MySqlDataAdapter(cmd)
        Dim dtBook As New DataTable
        Dim row As ArrayList
        DataGridView1.Rows.Clear()
        daBook.Fill(dtBook)
        If dtBook.Rows.Count > 0 Then
            For i = 0 To dtBook.Rows.Count - 1
                row = New ArrayList
                row.Add(dtBook.Rows(i)(0))
                row.Add(dtBook.Rows(i)(1))
                row.Add(dtBook.Rows(i)(2))
                row.Add(dtBook.Rows(i)(3))
                row.Add(dtBook.Rows(i)(4))

                conn.Close()
                DataGridView1.Rows.Add(row.ToArray())
            Next

        Else
            MessageBox.Show("No", "noo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddLibrary.ShowDialog()
        DataFill()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn.Open()
        Dim cmd As New MySqlCommand("delete from library where id = @id;", conn)
        Dim ind = DataGridView1.SelectedRows(0).Index.ToString()
        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = DataGridView1.Rows(ind).Cells(0).Value
        cmd.ExecuteReader()
        conn.Close()
        DataFill()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim editForm As New EditLibrary
        Dim ind = DataGridView1.SelectedRows(0).Index.ToString()

        editForm.SendData(DataGridView1.Rows(ind).Cells(0).Value,
                          DataGridView1.Rows(ind).Cells(1).Value,
                          DataGridView1.Rows(ind).Cells(2).Value,
                          DataGridView1.Rows(ind).Cells(3).Value,
                          DataGridView1.Rows(ind).Cells(4).Value)
        editForm.ShowDialog()
        DataFill()
    End Sub
End Class