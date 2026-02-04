<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPedidos
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
        TxtCedula = New TextBox()
        Label1 = New Label()
        BtnBuscarCliente = New Button()
        Label2 = New Label()
        TxtNombreCliente = New TextBox()
        Label3 = New Label()
        TxtMesa = New TextBox()
        PnlProductos = New Panel()
        CboCategoria = New ComboBox()
        DgvProductos = New DataGridView()
        BtnAgregar = New Button()
        DgvPedido = New DataGridView()
        BtnQuitar = New Button()
        TxtNotas = New TextBox()
        Label = New Label()
        BtnGuardarPedido = New Button()
        BtnCancelar = New Button()
        Label4 = New Label()
        LblTotal = New Label()
        BtnNuevo = New Button()
        PnlProductos.SuspendLayout()
        CType(DgvProductos, ComponentModel.ISupportInitialize).BeginInit()
        CType(DgvPedido, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TxtCedula
        ' 
        TxtCedula.Location = New Point(12, 35)
        TxtCedula.Name = "TxtCedula"
        TxtCedula.Size = New Size(100, 23)
        TxtCedula.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 17)
        Label1.Name = "Label1"
        Label1.Size = New Size(44, 15)
        Label1.TabIndex = 1
        Label1.Text = "Cedula"
        ' 
        ' BtnBuscarCliente
        ' 
        BtnBuscarCliente.Location = New Point(12, 110)
        BtnBuscarCliente.Name = "BtnBuscarCliente"
        BtnBuscarCliente.Size = New Size(75, 23)
        BtnBuscarCliente.TabIndex = 2
        BtnBuscarCliente.Text = "Buscar"
        BtnBuscarCliente.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 63)
        Label2.Name = "Label2"
        Label2.Size = New Size(51, 15)
        Label2.TabIndex = 4
        Label2.Text = "Nombre"
        ' 
        ' TxtNombreCliente
        ' 
        TxtNombreCliente.Location = New Point(12, 81)
        TxtNombreCliente.Name = "TxtNombreCliente"
        TxtNombreCliente.Size = New Size(100, 23)
        TxtNombreCliente.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(118, 43)
        Label3.Name = "Label3"
        Label3.Size = New Size(98, 15)
        Label3.TabIndex = 6
        Label3.Text = "Numero de Mesa"
        ' 
        ' TxtMesa
        ' 
        TxtMesa.Location = New Point(145, 63)
        TxtMesa.Name = "TxtMesa"
        TxtMesa.Size = New Size(44, 23)
        TxtMesa.TabIndex = 5
        ' 
        ' PnlProductos
        ' 
        PnlProductos.Controls.Add(CboCategoria)
        PnlProductos.Controls.Add(DgvProductos)
        PnlProductos.Controls.Add(BtnAgregar)
        PnlProductos.Enabled = False
        PnlProductos.Location = New Point(12, 153)
        PnlProductos.Name = "PnlProductos"
        PnlProductos.Size = New Size(310, 432)
        PnlProductos.TabIndex = 7
        ' 
        ' CboCategoria
        ' 
        CboCategoria.DropDownStyle = ComboBoxStyle.DropDownList
        CboCategoria.FormattingEnabled = True
        CboCategoria.Location = New Point(3, 4)
        CboCategoria.Name = "CboCategoria"
        CboCategoria.Size = New Size(223, 23)
        CboCategoria.TabIndex = 8
        ' 
        ' DgvProductos
        ' 
        DgvProductos.AllowUserToAddRows = False
        DgvProductos.AllowUserToDeleteRows = False
        DgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvProductos.Location = New Point(3, 32)
        DgvProductos.MultiSelect = False
        DgvProductos.Name = "DgvProductos"
        DgvProductos.ReadOnly = True
        DgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvProductos.Size = New Size(304, 397)
        DgvProductos.TabIndex = 8
        ' 
        ' BtnAgregar
        ' 
        BtnAgregar.Location = New Point(232, 3)
        BtnAgregar.Name = "BtnAgregar"
        BtnAgregar.Size = New Size(75, 23)
        BtnAgregar.TabIndex = 9
        BtnAgregar.Text = "Agregar"
        BtnAgregar.UseVisualStyleBackColor = True
        ' 
        ' DgvPedido
        ' 
        DgvPedido.AllowUserToAddRows = False
        DgvPedido.AllowUserToDeleteRows = False
        DgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvPedido.Location = New Point(370, 188)
        DgvPedido.MultiSelect = False
        DgvPedido.Name = "DgvPedido"
        DgvPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvPedido.Size = New Size(304, 300)
        DgvPedido.TabIndex = 9
        ' 
        ' BtnQuitar
        ' 
        BtnQuitar.Location = New Point(599, 516)
        BtnQuitar.Name = "BtnQuitar"
        BtnQuitar.Size = New Size(75, 23)
        BtnQuitar.TabIndex = 10
        BtnQuitar.Text = "Quitar"
        BtnQuitar.UseVisualStyleBackColor = True
        ' 
        ' TxtNotas
        ' 
        TxtNotas.Location = New Point(451, 491)
        TxtNotas.Name = "TxtNotas"
        TxtNotas.Size = New Size(223, 23)
        TxtNotas.TabIndex = 11
        ' 
        ' Label
        ' 
        Label.AutoSize = True
        Label.Location = New Point(370, 494)
        Label.Name = "Label"
        Label.Size = New Size(75, 15)
        Label.TabIndex = 12
        Label.Text = "Comentarios"
        ' 
        ' BtnGuardarPedido
        ' 
        BtnGuardarPedido.Location = New Point(528, 599)
        BtnGuardarPedido.Name = "BtnGuardarPedido"
        BtnGuardarPedido.Size = New Size(75, 23)
        BtnGuardarPedido.TabIndex = 13
        BtnGuardarPedido.Text = "Guardar"
        BtnGuardarPedido.UseVisualStyleBackColor = True
        ' 
        ' BtnCancelar
        ' 
        BtnCancelar.Location = New Point(609, 599)
        BtnCancelar.Name = "BtnCancelar"
        BtnCancelar.Size = New Size(75, 23)
        BtnCancelar.TabIndex = 14
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(370, 524)
        Label4.Name = "Label4"
        Label4.Size = New Size(39, 15)
        Label4.TabIndex = 15
        Label4.Text = "Total: "
        ' 
        ' LblTotal
        ' 
        LblTotal.AutoSize = True
        LblTotal.Location = New Point(404, 524)
        LblTotal.Name = "LblTotal"
        LblTotal.Size = New Size(41, 15)
        LblTotal.TabIndex = 16
        LblTotal.Text = "Label5"
        ' 
        ' BtnNuevo
        ' 
        BtnNuevo.Location = New Point(12, 599)
        BtnNuevo.Name = "BtnNuevo"
        BtnNuevo.Size = New Size(75, 23)
        BtnNuevo.TabIndex = 17
        BtnNuevo.Text = "Nuevo"
        BtnNuevo.UseVisualStyleBackColor = True
        ' 
        ' FrmPedidos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(686, 624)
        Controls.Add(BtnNuevo)
        Controls.Add(LblTotal)
        Controls.Add(Label4)
        Controls.Add(BtnCancelar)
        Controls.Add(BtnGuardarPedido)
        Controls.Add(Label)
        Controls.Add(TxtNotas)
        Controls.Add(BtnQuitar)
        Controls.Add(DgvPedido)
        Controls.Add(PnlProductos)
        Controls.Add(Label3)
        Controls.Add(TxtMesa)
        Controls.Add(Label2)
        Controls.Add(TxtNombreCliente)
        Controls.Add(BtnBuscarCliente)
        Controls.Add(Label1)
        Controls.Add(TxtCedula)
        Name = "FrmPedidos"
        Text = "FrmPedidos"
        PnlProductos.ResumeLayout(False)
        CType(DgvProductos, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvPedido, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnBuscarCliente As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtNombreCliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtMesa As TextBox
    Friend WithEvents PnlProductos As Panel
    Friend WithEvents CboCategoria As ComboBox
    Friend WithEvents DgvProductos As DataGridView
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents DgvPedido As DataGridView
    Friend WithEvents BtnQuitar As Button
    Friend WithEvents TxtNotas As TextBox
    Friend WithEvents Label As Label
    Friend WithEvents BtnGuardarPedido As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents LblTotal As Label
    Friend WithEvents BtnNuevo As Button
End Class
