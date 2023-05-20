Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class EditRestable
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Dim bookId As Integer
    Dim libId As Integer
    Dim amount_ As Integer
    Friend Sub SendData(ByVal id_book As Integer, ByVal id_lib As Integer, ByVal amount As Integer)
        bookId = id_book
        libId = id_lib
        amount_ = amount

        Dim cmd As New MySqlCommand("select book.id, bookentity.name from book join bookentity on bookentity.id = book.id_entity", conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        Dim index As Integer
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)(0) = bookId Then
                    index = i
                End If
                ComboBox3.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1))
            Next
        End If
        ComboBox3.SelectedIndex = index

        cmd = New MySqlCommand("select id, name from library", conn)
        da = New MySqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)(0) = libId Then
                    index = i
                End If
                ComboBox1.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1))
            Next
        End If
        ComboBox1.SelectedIndex = index
        TextBox3.Text = amount_
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        Dim cmd As New MySqlCommand("update restable set amount_books = @amount where id_library = @idLib and id_book = @idBook", conn)
        cmd.Parameters.AddWithValue("@amount", SqlDbType.Int).Value = TextBox3.Text
        cmd.Parameters.AddWithValue("@idLib", SqlDbType.Int).Value = ComboBox1.Text.Split(" ")(0)
        cmd.Parameters.AddWithValue("@idBook", SqlDbType.Int).Value = ComboBox3.Text.Split(" ")(0)
        cmd.ExecuteReader()
        conn.Close()
    End Sub
End Class