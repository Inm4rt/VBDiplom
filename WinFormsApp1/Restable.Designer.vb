<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Restable
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Book = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Library = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bookId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.libId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idRes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Book, Me.Library, Me.Amount, Me.bookId, Me.libId, Me.idRes})
        Me.DataGridView1.Location = New System.Drawing.Point(8, 14)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 33
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(516, 134)
        Me.DataGridView1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 163)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 27)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Добавить книгу в библиотеку"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(230, 163)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(191, 27)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Удалить книгу из библиотеки"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(127, 194)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(191, 27)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Изменить данные о книге"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Book
        '
        Me.Book.HeaderText = "Книга"
        Me.Book.MinimumWidth = 8
        Me.Book.Name = "Book"
        Me.Book.Width = 150
        '
        'Library
        '
        Me.Library.HeaderText = "Библиотека"
        Me.Library.MinimumWidth = 8
        Me.Library.Name = "Library"
        Me.Library.Width = 150
        '
        'Amount
        '
        Me.Amount.HeaderText = "Кол-во книг"
        Me.Amount.MinimumWidth = 8
        Me.Amount.Name = "Amount"
        Me.Amount.Width = 150
        '
        'bookId
        '
        Me.bookId.HeaderText = "bookId"
        Me.bookId.Name = "bookId"
        Me.bookId.ReadOnly = True
        Me.bookId.Visible = False
        '
        'libId
        '
        Me.libId.HeaderText = "libId"
        Me.libId.Name = "libId"
        Me.libId.ReadOnly = True
        Me.libId.Visible = False
        '
        'idRes
        '
        Me.idRes.HeaderText = "idRes"
        Me.idRes.Name = "idRes"
        Me.idRes.ReadOnly = True
        Me.idRes.Visible = False
        '
        'Restable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 239)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Restable"
        Me.Text = "Список книг в библиотеках"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Book As DataGridViewTextBoxColumn
    Friend WithEvents Library As DataGridViewTextBoxColumn
    Friend WithEvents Amount As DataGridViewTextBoxColumn
    Friend WithEvents bookId As DataGridViewTextBoxColumn
    Friend WithEvents libId As DataGridViewTextBoxColumn
    Friend WithEvents idRes As DataGridViewTextBoxColumn
End Class
