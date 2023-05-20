Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class AddRestable
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Private Sub AddRestable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        ComboBox3.Items.Clear()
        Dim cmd As New MySqlCommand("select book.id, name from book join bookentity on book.id_entity = bookentity.id", conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                ComboBox3.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1))
            Next
        End If

        cmd = New MySqlCommand("SELECT id, name FROM library", conn)
        da = New MySqlDataAdapter(cmd)
        dt.Reset()
        dt.Clear()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                ComboBox1.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1))
            Next
        End If
        ComboBox1.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        TextBox3.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        Dim cmd As New MySqlCommand("insert into restable values (null, @lib_id, @book_id, @amoun_books)", conn)
        cmd.Parameters.AddWithValue("@lib_id", SqlDbType.Int).Value = ComboBox1.Text.Split(" ")(0)
        cmd.Parameters.AddWithValue("@book_id", SqlDbType.Int).Value = ComboBox3.Text.Split(" ")(0)
        cmd.Parameters.AddWithValue("@amoun_books", SqlDbType.Int).Value = TextBox3.Text
        cmd.ExecuteReader()
        conn.Close()
    End Sub
End Class