<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Book = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Library = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Visitor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lending = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Surraund = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idLib = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idBook = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idVis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Book, Me.Library, Me.Visitor, Me.Lending, Me.Surraund, Me.idLib, Me.idBook, Me.idVis})
        Me.DataGridView1.Location = New System.Drawing.Point(8, 7)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 33
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(814, 487)
        Me.DataGridView1.TabIndex = 0
        '
        'Book
        '
        Me.Book.HeaderText = "Книга"
        Me.Book.MinimumWidth = 8
        Me.Book.Name = "Book"
        Me.Book.ReadOnly = True
        Me.Book.Width = 150
        '
        'Library
        '
        Me.Library.HeaderText = "Библиотека"
        Me.Library.MinimumWidth = 8
        Me.Library.Name = "Library"
        Me.Library.ReadOnly = True
        Me.Library.Width = 150
        '
        'Visitor
        '
        Me.Visitor.HeaderText = "Читатель"
        Me.Visitor.MinimumWidth = 8
        Me.Visitor.Name = "Visitor"
        Me.Visitor.ReadOnly = True
        Me.Visitor.Width = 150
        '
        'Lending
        '
        Me.Lending.HeaderText = "Дата выдачи"
        Me.Lending.MinimumWidth = 8
        Me.Lending.Name = "Lending"
        Me.Lending.ReadOnly = True
        Me.Lending.Width = 150
        '
        'Surraund
        '
        Me.Surraund.HeaderText = "Дата сдачи"
        Me.Surraund.MinimumWidth = 8
        Me.Surraund.Name = "Surraund"
        Me.Surraund.ReadOnly = True
        Me.Surraund.Width = 150
        '
        'idLib
        '
        Me.idLib.HeaderText = "idLib"
        Me.idLib.Name = "idLib"
        Me.idLib.ReadOnly = True
        Me.idLib.Visible = False
        '
        'idBook
        '
        Me.idBook.HeaderText = "idBook"
        Me.idBook.Name = "idBook"
        Me.idBook.ReadOnly = True
        Me.idBook.Visible = False
        '
        'idVis
        '
        Me.idVis.HeaderText = "idVis"
        Me.idVis.Name = "idVis"
        Me.idVis.ReadOnly = True
        Me.idVis.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 520)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 27)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Выдать книгу"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(160, 520)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(78, 27)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Принять книгу"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(242, 520)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(78, 27)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Изменить данные о выдаче книги"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 559)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form4"
        Me.Text = "Выдачи книг"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Book As DataGridViewTextBoxColumn
    Friend WithEvents Library As DataGridViewTextBoxColumn
    Friend WithEvents Visitor As DataGridViewTextBoxColumn
    Friend WithEvents Lending As DataGridViewTextBoxColumn
    Friend WithEvents Surraund As DataGridViewTextBoxColumn
    Friend WithEvents idLib As DataGridViewTextBoxColumn
    Friend WithEvents idBook As DataGridViewTextBoxColumn
    Friend WithEvents idVis As DataGridViewTextBoxColumn
End Class
