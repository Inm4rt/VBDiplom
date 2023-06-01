Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class EditLibrary
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Dim idLib As Integer

    Friend Sub SendData(ByVal id As String, ByVal name As String, ByVal address As String, ByVal phone As String, ByVal work As String)
        TextBox1.Text = name
        TextBox2.Text = address
        TextBox3.Text = phone
        TextBox4.Text = work
        idLib = id
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        Dim cmd As New MySqlCommand("update library set name = @name, address = @address, phone = @phone, time = @time where id = @id", conn)
        cmd.Parameters.AddWithValue("@id", idLib)
        cmd.Parameters.AddWithValue("@name", TextBox1.Text)
        cmd.Parameters.AddWithValue("@address", TextBox2.Text)
        cmd.Parameters.AddWithValue("@phone", TextBox3.Text)
        cmd.Parameters.AddWithValue("@time", TextBox4.Text)
        cmd.ExecuteReader()
        conn.Close()
    End Sub
End Class