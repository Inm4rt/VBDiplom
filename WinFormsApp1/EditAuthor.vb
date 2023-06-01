Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class EditAuthor
    Dim data As Integer
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Friend Sub SendData(ByVal id As Integer, ByVal fio As String)
        TextBox1.Text = fio
        data = id
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        Dim cmdBook As New MySqlCommand("update author set fio = @fio where id = @id", conn)
        cmdBook.Parameters.AddWithValue("@fio", TextBox1.Text)
        cmdBook.Parameters.AddWithValue("@id", SqlDbType.Int).Value = data
        cmdBook.ExecuteReader()
        conn.Close()
    End Sub
End Class