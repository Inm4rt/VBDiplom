Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class AddVisitor
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()

        Dim cmd As New MySqlCommand("insert into visitor values (null, @fio, @phone)", conn)
        cmd.Parameters.AddWithValue("@fio", SqlDbType.VarChar).Value = TextBox1.Text
        cmd.Parameters.AddWithValue("@phone", SqlDbType.VarChar).Value = TextBox2.Text
        cmd.ExecuteReader()
        conn.Close()
    End Sub

    Private Sub AddVisitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class