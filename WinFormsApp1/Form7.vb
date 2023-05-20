Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class Form7
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New MySqlCommand("select book.id, name, year from book join bookentity on book.id_entity = bookentity.id", conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                ComboBoxBook.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1))
            Next
        End If

        cmd = New MySqlCommand("SELECT id, name FROM library", conn)
        da = New MySqlDataAdapter(cmd)
        dt.Reset()
        dt.Clear()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                ComboBoxLib.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1))
            Next
        End If

        cmd = New MySqlCommand("SELECT lib_card, fio FROM visitor", conn)
        da = New MySqlDataAdapter(cmd)
        dt.Reset()
        dt.Clear()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                ComboBoxVis.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1))
            Next
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim amount As Integer
        Dim reader As MySqlDataReader
        conn.Open()
        Dim q As New MySqlCommand("select amount_books from restable where id_library = @libId and id_book=@bookId", conn)
        q.Parameters.AddWithValue("@libId", SqlDbType.Int).Value = ComboBoxLib.Text.Split(" ")(0)
        q.Parameters.AddWithValue("@bookId", SqlDbType.Int).Value = ComboBoxBook.Text.Split(" ")(0)
        reader = q.ExecuteReader()
        While reader.Read()
            ' DataGridView1.Rows(i).Cells(0).Value = reader.GetValue(0)
            amount = reader.GetValue(0)
        End While
        reader.Close()
        If amount > 0 Then
            Dim cmd As New MySqlCommand("insert into TakenBook values (null, '" _
                                        & ComboBoxVis.Text.Split(" ")(0) & "', '" _
                                        & ComboBoxLib.Text.Split(" ")(0) & "', '" _
                                        & ComboBoxBook.Text.Split(" ")(0) & "', '" _
                                        & DateTimePicker1.Value.Date.ToString("yyyy-MM-dd") _
                                        & "', '" & DateTimePicker2.Value.Date.ToString("yyyy-MM-dd") _
                                        & "');", conn)
            cmd.ExecuteNonQuery()

            cmd = New MySqlCommand("update restable set amount_books = amount_books - 1 where id_library = @libId and id_book=@bookId", conn)
            cmd.Parameters.AddWithValue("@libId", SqlDbType.Int).Value = ComboBoxLib.Text.Split(" ")(0)
            cmd.Parameters.AddWithValue("@bookId", SqlDbType.Int).Value = ComboBoxBook.Text.Split(" ")(0)
            reader = cmd.ExecuteReader()
            reader.Close()

        Else
            MessageBox.Show("В данной библиотеке нет такой книги", "УВЫ JOKERGE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        conn.Close()
    End Sub
End Class