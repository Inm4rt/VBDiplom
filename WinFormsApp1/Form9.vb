Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Form9
    Dim takenId As Integer
    Dim connStr As String = "server=localhost;user=root;database=LIB;port=3306;password=1234;"
    Dim conn As New MySqlConnection(connStr)
    Dim bookId As Integer
    Dim libId As Integer
    Dim visId As Integer
    Dim start As Date
    Dim End_ As Date

    Friend Sub SendData(ByVal idBook As Integer, ByVal idlLib As Integer, ByVal idVis As Integer, ByVal startD As Date, ByVal endD As Date, ByVal idTaken As Integer)
        bookId = idBook
        libId = idlLib
        visId = idVis
        start = startD
        End_ = endD
        takenId = idTaken
    End Sub
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New MySqlCommand("select book.id, name, year from book join bookentity on book.id_entity = bookentity.id", conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        Dim bookI As Integer
        Dim libI As Integer
        Dim visI As Integer
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                If bookId = dt.Rows(i)(0) Then
                    bookI = i
                End If
                ComboBox3.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1) & ", " & dt.Rows(i)(2))
            Next
        End If
        ComboBox3.SelectedIndex = bookI
        cmd = New MySqlCommand("SELECT id, name FROM library", conn)
        da = New MySqlDataAdapter(cmd)
        dt.Reset()
        dt.Clear()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                If libId = dt.Rows(i)(0) Then
                    libI = i
                End If
                ComboBox1.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1))
            Next
        End If
        ComboBox1.SelectedIndex = libI
        cmd = New MySqlCommand("SELECT lib_card, fio FROM visitor", conn)
        da = New MySqlDataAdapter(cmd)
        dt.Reset()
        dt.Clear()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                If visId = dt.Rows(i)(0) Then
                    visI = i
                End If
                ComboBox2.Items.Add(dt.Rows(i)(0) & " " & dt.Rows(i)(1))
            Next
        End If
        ComboBox2.SelectedIndex = visI

        DateTimePicker1.Value = start
        DateTimePicker2.Value = End_
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()
        Dim cmdBook As New MySqlCommand("update takenbook set lib_card = " & ComboBox2.Text.Split(" ")(0) &
                                        ", id_library = " & ComboBox1.Text.Split(" ")(0) &
                                        ", id_book = " & ComboBox3.Text.Split(" ")(0) &
                                        ", taking_date = '" & DateTimePicker1.Value.Date.ToString("yyyy-MM-dd") &
                                        "', return_date = '" & DateTimePicker2.Value.Date.ToString("yyyy-MM-dd") &
                                        "' where id = " & takenId, conn)
        cmdBook.ExecuteReader()
        conn.Close()
    End Sub
End Class