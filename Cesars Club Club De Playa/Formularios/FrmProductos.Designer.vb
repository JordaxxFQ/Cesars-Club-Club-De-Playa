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
        DgvProductos.Location = New Point(175, 12)
        DgvProductos.Name = "DgvProductos"
        DgvProductos.Size = New Size(727, 412)
        DgvProductos.TabIndex = 0
        ' 
        ' cmbCategoria
        ' 
        cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCategoria.FormattingEnabled = True
        cmbCategoria.Location = New Point(8, 71)
        cmbCategoria.Name = "cmbCategoria"
        cmbCategoria.Size = New Size(157, 23)
        cmbCategoria.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(8, 53)
        Label1.Name = "Label1"
        Label1.Size = New Size(58, 15)
        Label1.TabIndex = 2
        Label1.Text = "Categoría"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(8, 7)
        Label2.Name = "Label2"
        Label2.Size = New Size(122, 15)
        Label2.TabIndex = 3
        Label2.Text = "Nombre del Producto"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(8, 99)
        Label3.Name = "Label3"
        Label3.Size = New Size(69, 15)
        Label3.TabIndex = 4
        Label3.Text = "Descripción"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(8, 141)
        Label4.Name = "Label4"
        Label4.Size = New Size(40, 15)
        Label4.TabIndex = 5
        Label4.Text = "Precio"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(8, 183)
        Label5.Name = "Label5"
        Label5.Size = New Size(36, 15)
        Label5.TabIndex = 6
        Label5.Text = "Stock"
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(8, 25)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(157, 23)
        txtNombre.TabIndex = 7
        ' 
        ' txtDescripcion
        ' 
        txtDescripcion.Location = New Point(8, 117)
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Size = New Size(157, 23)
        txtDescripcion.TabIndex = 8
        ' 
        ' txtPrecio
        ' 
        txtPrecio.Location = New Point(8, 159)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.Size = New Size(157, 23)
        txtPrecio.TabIndex = 9
        ' 
        ' txtStock
        ' 
        txtStock.Location = New Point(8, 201)
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(157, 23)
        txtStock.TabIndex = 10
        ' 
        ' btnAgg
        ' 
        btnAgg.Location = New Point(8, 252)
        btnAgg.Name = "btnAgg"
        btnAgg.Size = New Size(161, 23)
        btnAgg.TabIndex = 11
        btnAgg.Text = "Agregar"
        btnAgg.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(8, 281)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(69, 23)
        btnDelete.TabIndex = 12
        btnDelete.Text = "Eliminar"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Location = New Point(96, 281)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(69, 23)
        btnEdit.TabIndex = 13
        btnEdit.Text = "Modificar"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Location = New Point(8, 230)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(108, 19)
        chkActivo.TabIndex = 14
        chkActivo.Text = "Activo en Venta"
        chkActivo.UseVisualStyleBackColor = True
        ' 
        ' FrmProductos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(912, 437)
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
        Name = "FrmProductos"
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
