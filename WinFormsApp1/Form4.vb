Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class Form4
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim reader As MySqlDataReader
        conn.Open()
        Dim cmd As New MySqlCommand("delete from takenbook where id_library = @libId and id_book=@bookId;", conn)
        Dim ind = DataGridView1.SelectedRows(0).Index.ToString()
        cmd.Parameters.AddWithValue("@libId", SqlDbType.Int).Value = DataGridView1.Rows(ind).Cells(5).Value
        cmd.Parameters.AddWithValue("@bookId", SqlDbType.Int).Value = DataGridView1.Rows(ind).Cells(6).Value
        reader = cmd.ExecuteReader()
        reader.Close()
        cmd = New MySqlCommand("update restable set amount_books = amount_books + 1 where id_library = @libId and id_book=@bookId;", conn)
        cmd.Parameters.AddWithValue("@libId", SqlDbType.Int).Value = DataGridView1.Rows(ind).Cells(5).Value
        cmd.Parameters.AddWithValue("@bookId", SqlDbType.Int).Value = DataGridView1.Rows(ind).Cells(6).Value
        reader = cmd.ExecuteReader()
        reader.Close()
        conn.Close()
        DataClear()
        DataFill()
    End Sub
    Private Sub DataFill()
        Dim cmd As New MySqlCommand("SELECT * FROM takenbook", conn)
        Dim daTakenBook As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        Dim row As ArrayList
        Dim reader As MySqlDataReader
        daTakenBook.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                Dim idLib = dt.Rows(i)(2)
                Dim idBook = dt.Rows(i)(3)
                Dim libcard = dt.Rows(i)(1)
                Dim idTaken = dt.Rows(i)(0)

                row = New ArrayList
                conn.Open()
                Dim cmdBook As New MySqlCommand("select name from bookentity where bookentity.id = 
                                                ( select id_entity from book where book.id = @idbook);", conn)
                cmdBook.Parameters.AddWithValue("@idbook", SqlDbType.Int).Value = idBook
                reader = cmdBook.ExecuteReader()
                While reader.Read()
                    ' DataGridView1.Rows(i).Cells(0).Value = reader.GetValue(0)
                    row.Add(reader.GetValue(0))
                End While
                reader.Close()

                'DataGridView1.Rows(i).Cells(3).Value = dt.Rows(i)(4)
                'DataGridView1.Rows(i).Cells(4).Value = dt.Rows(i)(5)
                Dim cmdLib As New MySqlCommand("SELECT * FROM library WHERE id = @id", conn)
                cmdLib.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idLib
                reader = cmdLib.ExecuteReader()
                While reader.Read()
                    row.Add(reader.GetValue(1))
                    'DataGridView1.Rows(i).Cells(1).Value = reader.GetValue(1)
                End While
                reader.Close()

                Dim cmdReader As New MySqlCommand("SELECT * FROM visitor WHERE lib_card = @card", conn)
                cmdReader.Parameters.AddWithValue("@card", SqlDbType.Int).Value = libcard
                reader = cmdReader.ExecuteReader()
                While reader.Read()
                    row.Add(reader.GetValue(1))
                    'DataGridView1.Rows(i).Cells(2).Value = reader.GetValue(1)
                End While
                reader.Close()
                conn.Close()
                row.Add(dt.Rows(i)(4))
                row.Add(dt.Rows(i)(5))
                row.Add(dt.Rows(i)(2))
                row.Add(dt.Rows(i)(3))
                row.Add(dt.Rows(i)(1))
                row.Add(idTaken)
                DataGridView1.Rows.Add(row.ToArray())
            Next
        End If
    End Sub

    Private Sub DataClear()
        DataGridView1.Rows.Clear()
        DataGridView1.Refresh()
    End Sub
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataFill()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form7.ShowDialog()
        DataClear()
        DataFill()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim editForm As New Form9
        Dim ind = DataGridView1.SelectedRows(0).Index.ToString()

        editForm.SendData(DataGridView1.Rows(ind).Cells(6).Value,
                          DataGridView1.Rows(ind).Cells(5).Value,
                          DataGridView1.Rows(ind).Cells(7).Value,
                          DataGridView1.Rows(ind).Cells(3).Value,
                          DataGridView1.Rows(ind).Cells(4).Value,
                          DataGridView1.Rows(ind).Cells(8).Value)
        editForm.ShowDialog()
        DataClear()
        DataFill()
    End Sub
End Class