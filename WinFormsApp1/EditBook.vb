Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class EditBook
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Dim id_auth As Integer
    Dim entId As Integer
    Dim bookId As Integer
    Friend Sub SendData(ByVal book_id As String, ByVal ent_id As String, ByVal name As String, ByVal auth_id As Integer,
                        ByVal up_date As String, ByVal pages As String, ByVal isbn As String)
        TextBox1.Text = name
        TextBox2.Text = up_date
        TextBox3.Text = pages
        TextBox4.Text = isbn
        id_auth = auth_id
        entId = ent_id
        bookId = book_id
        Dim cmd As New MySqlCommand("select id, fio from author", conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        Dim index As Integer
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                If dt.Rows(i)(0) = id_auth Then
                    index = i
                End If
                ComboBox1.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1))
            Next
        End If
        ComboBox1.SelectedIndex = index
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reader As MySqlDataReader
        conn.Open()
        Dim cmd As New MySqlCommand("update bookentity set name = @name, author_id = @auth_id where id = @id", conn)
        cmd.Parameters.AddWithValue("@name", TextBox1.Text)
        cmd.Parameters.AddWithValue("@auth_id", SqlDbType.Int).Value = ComboBox1.Text.Split(" ")(0)
        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = entId
        reader = cmd.ExecuteReader()
        reader.Close()

        cmd = New MySqlCommand("update book set year = @year, amount_pages = @pages, isbn = @isbn where id = @id", conn)
        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = bookId
        cmd.Parameters.AddWithValue("@year", TextBox2.Text)
        cmd.Parameters.AddWithValue("@pages", SqlDbType.Int).Value = TextBox3.Text
        cmd.Parameters.AddWithValue("@isbn", TextBox4.Text)
        reader = cmd.ExecuteReader()
        reader.Close()
        conn.Close()
    End Sub
End Class