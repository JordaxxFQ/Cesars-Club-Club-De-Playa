<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        DgvProductos = New DataGridView()
        cmbCategoria = New ComboBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        TxtNombre = New TextBox()
        TxtDescripcion = New TextBox()
        TxtPrecio = New TextBox()
        TxtStock = New TextBox()
        BtnAgregar = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        chkActivo = New CheckBox()
        CType(DgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvProductos
        ' 
        DgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvProductos.Location = New Point(200, 17)
        DgvProductos.Margin = New Padding(3, 4, 3, 4)
        DgvProductos.Name = "DgvProductos"
        DgvProductos.Size = New Size(831, 577)
        DgvProductos.TabIndex = 0
        ' 
        ' cmbCategoria
        ' 
        cmbCategoria.Cursor = Cursors.Hand
        cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCategoria.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        cmbCategoria.FormattingEnabled = True
        cmbCategoria.Location = New Point(9, 99)
        cmbCategoria.Margin = New Padding(3, 4, 3, 4)
        cmbCategoria.Name = "cmbCategoria"
        cmbCategoria.Size = New Size(179, 29)
        cmbCategoria.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label1.Location = New Point(9, 74)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 21)
        Label1.TabIndex = 2
        Label1.Text = "Categoría"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label2.Location = New Point(9, 10)
        Label2.Name = "Label2"
        Label2.Size = New Size(140, 21)
        Label2.TabIndex = 3
        Label2.Text = "Nombre del Producto"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label3.Location = New Point(9, 139)
        Label3.Name = "Label3"
        Label3.Size = New Size(78, 21)
        Label3.TabIndex = 4
        Label3.Text = "Descripción"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label4.Location = New Point(9, 197)
        Label4.Name = "Label4"
        Label4.Size = New Size(46, 21)
        Label4.TabIndex = 5
        Label4.Text = "Precio"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label5.Location = New Point(9, 256)
        Label5.Name = "Label5"
        Label5.Size = New Size(44, 21)
        Label5.TabIndex = 6
        Label5.Text = "Stock"
        ' 
        ' TxtNombre
        ' 
        TxtNombre.Cursor = Cursors.IBeam
        TxtNombre.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        TxtNombre.Location = New Point(9, 35)
        TxtNombre.Margin = New Padding(3, 4, 3, 4)
        TxtNombre.Name = "TxtNombre"
        TxtNombre.Size = New Size(179, 29)
        TxtNombre.TabIndex = 7
        ' 
        ' TxtDescripcion
        ' 
        TxtDescripcion.Cursor = Cursors.IBeam
        TxtDescripcion.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        TxtDescripcion.Location = New Point(9, 164)
        TxtDescripcion.Margin = New Padding(3, 4, 3, 4)
        TxtDescripcion.Name = "TxtDescripcion"
        TxtDescripcion.Size = New Size(179, 29)
        TxtDescripcion.TabIndex = 8
        ' 
        ' TxtPrecio
        ' 
        TxtPrecio.Cursor = Cursors.IBeam
        TxtPrecio.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        TxtPrecio.Location = New Point(9, 223)
        TxtPrecio.Margin = New Padding(3, 4, 3, 4)
        TxtPrecio.Name = "TxtPrecio"
        TxtPrecio.Size = New Size(179, 29)
        TxtPrecio.TabIndex = 9
        ' 
        ' TxtStock
        ' 
        TxtStock.Cursor = Cursors.IBeam
        TxtStock.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        TxtStock.Location = New Point(9, 281)
        TxtStock.Margin = New Padding(3, 4, 3, 4)
        TxtStock.Name = "TxtStock"
        TxtStock.Size = New Size(179, 29)
        TxtStock.TabIndex = 10
        ' 
        ' BtnAgregar
        ' 
        BtnAgregar.Cursor = Cursors.Hand
        BtnAgregar.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        BtnAgregar.Location = New Point(9, 353)
        BtnAgregar.Margin = New Padding(3, 4, 3, 4)
        BtnAgregar.Name = "BtnAgregar"
        BtnAgregar.Size = New Size(184, 32)
        BtnAgregar.TabIndex = 11
        BtnAgregar.Text = "Agregar"
        BtnAgregar.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Cursor = Cursors.Hand
        btnDelete.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        btnDelete.Location = New Point(9, 393)
        btnDelete.Margin = New Padding(3, 4, 3, 4)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(79, 32)
        btnDelete.TabIndex = 12
        btnDelete.Text = "Eliminar"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Cursor = Cursors.Hand
        btnEdit.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        btnEdit.Location = New Point(110, 393)
        btnEdit.Margin = New Padding(3, 4, 3, 4)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(79, 32)
        btnEdit.TabIndex = 13
        btnEdit.Text = "Modificar"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Cursor = Cursors.Hand
        chkActivo.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        chkActivo.Location = New Point(9, 322)
        chkActivo.Margin = New Padding(3, 4, 3, 4)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(127, 25)
        chkActivo.TabIndex = 14
        chkActivo.Text = "Activo en Venta"
        chkActivo.UseVisualStyleBackColor = True
        ' 
        ' FrmProductos
        ' 
        AutoScaleDimensions = New SizeF(8F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GradientActiveCaption
        ClientSize = New Size(1042, 612)
        Controls.Add(chkActivo)
        Controls.Add(btnEdit)
        Controls.Add(btnDelete)
        Controls.Add(BtnAgregar)
        Controls.Add(TxtStock)
        Controls.Add(TxtPrecio)
        Controls.Add(TxtDescripcion)
        Controls.Add(TxtNombre)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(cmbCategoria)
        Controls.Add(DgvProductos)
        Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Margin = New Padding(3, 4, 3, 4)
        Name = "FrmProductos"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmProductos"
        CType(DgvProductos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DgvProductos As DataGridView
    Friend WithEvents cmbCategoria As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents TxtDescripcion As TextBox
    Friend WithEvents TxtPrecio As TextBox
    Friend WithEvents TxtStock As TextBox
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents chkActivo As CheckBox
End Class
