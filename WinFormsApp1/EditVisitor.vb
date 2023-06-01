Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class EditVisitor
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Dim idVis As Integer

    Friend Sub SendData(ByVal id As String, ByVal fio As String, ByVal phone As String)
        TextBox1.Text = fio
        TextBox2.Text = phone
        idVis = id
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        Dim cmd As New MySqlCommand("update visitor set fio=@fio, phone=@phone where lib_card = @id", conn)
        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idVis
        cmd.Parameters.AddWithValue("@fio", TextBox1.Text)
        cmd.Parameters.AddWithValue("@phone", TextBox2.Text)
        cmd.ExecuteReader()
        conn.Close()
    End Sub
End Class