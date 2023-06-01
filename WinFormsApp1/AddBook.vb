Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class AddBook
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd_result As Integer
        Dim reader As MySqlDataReader
        conn.Open()
        Dim cmdBookE As New MySqlCommand("insert into bookentity values (null, '" & TextBox1.Text & "', '" _
                                         & ComboBox1.Text.Split(" ")(0).Trim() & "')", conn)

        cmdBookE.ExecuteNonQuery()
        Dim cmdBookMax As New MySqlCommand("select max(id) from bookentity", conn)
        reader = cmdBookMax.ExecuteReader()
        While reader.Read()
            cmd_result = reader.GetValue(0)
        End While
        reader.Close()


        Dim cmdBook As New MySqlCommand("insert into book values (null, @entity_id, @age, @count_pages, '" & TextBox4.Text & "')", conn)
        cmdBook.Parameters.AddWithValue("@entity_id", SqlDbType.Int).Value = cmd_result
        cmdBook.Parameters.AddWithValue("@age", SqlDbType.VarChar).Value = TextBox2.Text
        cmdBook.Parameters.AddWithValue("@count_pages", SqlDbType.Int).Value = TextBox3.Text
        'cmdBook.Parameters.AddWithValue("@isbn", SqlDbType.VarChar).Value = TextBox4.Text
        cmdBook.ExecuteReader()
        conn.Close()
    End Sub

    Private Sub AddBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Items.Clear()
        Dim cmd As New MySqlCommand("select id, fio from author", conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                ComboBox1.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1))
            Next
        End If
        ComboBox1.SelectedIndex = 0
    End Sub
End Class