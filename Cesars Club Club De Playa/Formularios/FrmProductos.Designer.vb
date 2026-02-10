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
        txtNombre = New TextBox()
        txtDescripcion = New TextBox()
        txtPrecio = New TextBox()
        txtStock = New TextBox()
        btnAgg = New Button()
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
        ' txtNombre
        ' 
        txtNombre.Cursor = Cursors.IBeam
        txtNombre.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        txtNombre.Location = New Point(9, 35)
        txtNombre.Margin = New Padding(3, 4, 3, 4)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(179, 29)
        txtNombre.TabIndex = 7
        ' 
        ' txtDescripcion
        ' 
        txtDescripcion.Cursor = Cursors.IBeam
        txtDescripcion.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        txtDescripcion.Location = New Point(9, 164)
        txtDescripcion.Margin = New Padding(3, 4, 3, 4)
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Size = New Size(179, 29)
        txtDescripcion.TabIndex = 8
        ' 
        ' txtPrecio
        ' 
        txtPrecio.Cursor = Cursors.IBeam
        txtPrecio.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        txtPrecio.Location = New Point(9, 223)
        txtPrecio.Margin = New Padding(3, 4, 3, 4)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.Size = New Size(179, 29)
        txtPrecio.TabIndex = 9
        ' 
        ' txtStock
        ' 
        txtStock.Cursor = Cursors.IBeam
        txtStock.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        txtStock.Location = New Point(9, 281)
        txtStock.Margin = New Padding(3, 4, 3, 4)
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(179, 29)
        txtStock.TabIndex = 10
        ' 
        ' btnAgg
        ' 
        btnAgg.Cursor = Cursors.Hand
        btnAgg.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        btnAgg.Location = New Point(9, 353)
        btnAgg.Margin = New Padding(3, 4, 3, 4)
        btnAgg.Name = "btnAgg"
        btnAgg.Size = New Size(184, 32)
        btnAgg.TabIndex = 11
        btnAgg.Text = "Agregar"
        btnAgg.UseVisualStyleBackColor = True
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
        Controls.Add(btnAgg)
        Controls.Add(txtStock)
        Controls.Add(txtPrecio)
        Controls.Add(txtDescripcion)
        Controls.Add(txtNombre)
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
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtStock As TextBox
    Friend WithEvents btnAgg As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents chkActivo As CheckBox
End Class
