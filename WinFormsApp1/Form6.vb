Imports Google.Protobuf.WellKnownTypes.Field.Types
Imports MySql.Data.MySqlClient

Public Class Form6

    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (TextBox1.Text = "") Then
            MessageBox.Show("Введите ID, а затем нажимте ""Поиск""", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cmd As New MySqlCommand("SELECT name, fio, year, amount_pages, isbn FROM book JOIN bookentity ON bookentity.id = id_entity JOIN author ON author.id = author_id WHERE book.id = @id", conn)
        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = TextBox1.Text
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            TextBox2.Text = dt.Rows(0)(0)
            TextBox3.Text = dt.Rows(0)(1)
            TextBox4.Text = dt.Rows(0)(2)
            TextBox5.Text = dt.Rows(0)(3)
            TextBox6.Text = dt.Rows(0)(4)
        Else
            MessageBox.Show("Книги с таким ID нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class