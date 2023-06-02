Imports Google.Protobuf.WellKnownTypes.Field.Types
Imports MySql.Data.MySqlClient

Public Class Restable
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Private Sub Restable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataFill()
    End Sub

    Private Sub DataFill()
        Dim cmd As New MySqlCommand("select book.id, library.name, BookEntity.name, amount_books, year, id_library, restable.id from restable join library on library.id = id_library join book on book.id = id_book join BookEntity on BookEntity.id = id_entity", conn)
        Dim daRestable As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        Dim row As ArrayList
        daRestable.Fill(dt)
        DataGridView1.Rows.Clear()
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                row = New ArrayList
                row.Add(dt.Rows(i)(2) + ", " + dt.Rows(i)(4))
                row.Add(dt.Rows(i)(1))
                row.Add(dt.Rows(i)(3))
                row.Add(dt.Rows(i)(0))
                row.Add(dt.Rows(i)(5))
                row.Add(dt.Rows(i)(6))
                DataGridView1.Rows.Add(row.ToArray())
            Next
        End If
    End Sub

    Private Sub ClearData()
        DataGridView1.Rows.Clear()
        DataGridView1.Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddRestable.ShowDialog()
        ClearData()
        DataFill()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn.Open()
        Dim cmdRestable As New MySqlCommand("delete from Restable where id = @id;", conn)
        Dim ind = DataGridView1.SelectedRows(0).Index.ToString()
        cmdRestable.Parameters.AddWithValue("@id", DataGridView1.Rows(ind).Cells(5).Value)
        cmdRestable.ExecuteReader()
        conn.Close()
        ClearData()
        DataFill()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim editForm As New EditRestable
        Dim ind = DataGridView1.SelectedRows(0).Index.ToString()

        editForm.SendData(DataGridView1.Rows(ind).Cells(3).Value,
                          DataGridView1.Rows(ind).Cells(4).Value,
                          DataGridView1.Rows(ind).Cells(2).Value)
        editForm.ShowDialog()
        ClearData()
        DataFill()
    End Sub
End Class
