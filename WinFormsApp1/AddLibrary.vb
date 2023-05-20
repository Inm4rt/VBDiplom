Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class AddLibrary
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        Dim cmd As New MySqlCommand("insert into library values (null, @name, @address, @phone, @time)", conn)
        cmd.Parameters.AddWithValue("@name", SqlDbType.VarChar).Value = TextBox1.Text
        cmd.Parameters.AddWithValue("@address", SqlDbType.VarChar).Value = TextBox2.Text
        cmd.Parameters.AddWithValue("@phone", SqlDbType.VarChar).Value = TextBox3.Text
        cmd.Parameters.AddWithValue("@time", SqlDbType.VarChar).Value = TextBox4.Text

        cmd.ExecuteReader()
        conn.Close()
    End Sub

    Private Sub AddLibrary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub
End Class