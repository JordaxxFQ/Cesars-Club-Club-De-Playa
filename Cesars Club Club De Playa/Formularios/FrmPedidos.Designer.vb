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
        TxtCedula.Cursor = Cursors.IBeam
        TxtCedula.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        TxtCedula.Location = New Point(14, 49)
        TxtCedula.Margin = New Padding(3, 4, 3, 4)
        TxtCedula.Name = "TxtCedula"
        TxtCedula.Size = New Size(114, 29)
        TxtCedula.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label1.Location = New Point(14, 24)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 21)
        Label1.TabIndex = 1
        Label1.Text = "Cedula"
        ' 
        ' BtnBuscarCliente
        ' 
        BtnBuscarCliente.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        BtnBuscarCliente.Location = New Point(14, 154)
        BtnBuscarCliente.Margin = New Padding(3, 4, 3, 4)
        BtnBuscarCliente.Name = "BtnBuscarCliente"
        BtnBuscarCliente.Size = New Size(86, 32)
        BtnBuscarCliente.TabIndex = 2
        BtnBuscarCliente.Text = "Buscar"
        BtnBuscarCliente.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label2.Location = New Point(14, 88)
        Label2.Name = "Label2"
        Label2.Size = New Size(58, 21)
        Label2.TabIndex = 4
        Label2.Text = "Nombre"
        ' 
        ' TxtNombreCliente
        ' 
        TxtNombreCliente.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        TxtNombreCliente.Location = New Point(14, 113)
        TxtNombreCliente.Margin = New Padding(3, 4, 3, 4)
        TxtNombreCliente.Name = "TxtNombreCliente"
        TxtNombreCliente.Size = New Size(114, 29)
        TxtNombreCliente.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label3.Location = New Point(135, 60)
        Label3.Name = "Label3"
        Label3.Size = New Size(111, 21)
        Label3.TabIndex = 6
        Label3.Text = "Numero de Mesa"
        ' 
        ' TxtMesa
        ' 
        TxtMesa.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        TxtMesa.Location = New Point(166, 88)
        TxtMesa.Margin = New Padding(3, 4, 3, 4)
        TxtMesa.Name = "TxtMesa"
        TxtMesa.Size = New Size(50, 29)
        TxtMesa.TabIndex = 5
        ' 
        ' PnlProductos
        ' 
        PnlProductos.Controls.Add(CboCategoria)
        PnlProductos.Controls.Add(DgvProductos)
        PnlProductos.Controls.Add(BtnAgregar)
        PnlProductos.Enabled = False
        PnlProductos.Location = New Point(14, 214)
        PnlProductos.Margin = New Padding(3, 4, 3, 4)
        PnlProductos.Name = "PnlProductos"
        PnlProductos.Size = New Size(354, 605)
        PnlProductos.TabIndex = 7
        ' 
        ' CboCategoria
        ' 
        CboCategoria.DropDownStyle = ComboBoxStyle.DropDownList
        CboCategoria.FormattingEnabled = True
        CboCategoria.Location = New Point(3, 6)
        CboCategoria.Margin = New Padding(3, 4, 3, 4)
        CboCategoria.Name = "CboCategoria"
        CboCategoria.Size = New Size(254, 29)
        CboCategoria.TabIndex = 8
        ' 
        ' DgvProductos
        ' 
        DgvProductos.AllowUserToAddRows = False
        DgvProductos.AllowUserToDeleteRows = False
        DgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvProductos.Location = New Point(3, 45)
        DgvProductos.Margin = New Padding(3, 4, 3, 4)
        DgvProductos.MultiSelect = False
        DgvProductos.Name = "DgvProductos"
        DgvProductos.ReadOnly = True
        DgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvProductos.Size = New Size(347, 556)
        DgvProductos.TabIndex = 8
        ' 
        ' BtnAgregar
        ' 
        BtnAgregar.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        BtnAgregar.Location = New Point(265, 4)
        BtnAgregar.Margin = New Padding(3, 4, 3, 4)
        BtnAgregar.Name = "BtnAgregar"
        BtnAgregar.Size = New Size(86, 32)
        BtnAgregar.TabIndex = 9
        BtnAgregar.Text = "Agregar"
        BtnAgregar.UseVisualStyleBackColor = True
        ' 
        ' DgvPedido
        ' 
        DgvPedido.AllowUserToAddRows = False
        DgvPedido.AllowUserToDeleteRows = False
        DgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvPedido.Location = New Point(423, 263)
        DgvPedido.Margin = New Padding(3, 4, 3, 4)
        DgvPedido.MultiSelect = False
        DgvPedido.Name = "DgvPedido"
        DgvPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvPedido.Size = New Size(347, 420)
        DgvPedido.TabIndex = 9
        ' 
        ' BtnQuitar
        ' 
        BtnQuitar.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        BtnQuitar.Location = New Point(685, 722)
        BtnQuitar.Margin = New Padding(3, 4, 3, 4)
        BtnQuitar.Name = "BtnQuitar"
        BtnQuitar.Size = New Size(86, 32)
        BtnQuitar.TabIndex = 10
        BtnQuitar.Text = "Quitar"
        BtnQuitar.UseVisualStyleBackColor = True
        ' 
        ' TxtNotas
        ' 
        TxtNotas.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        TxtNotas.Location = New Point(515, 687)
        TxtNotas.Margin = New Padding(3, 4, 3, 4)
        TxtNotas.Name = "TxtNotas"
        TxtNotas.Size = New Size(254, 29)
        TxtNotas.TabIndex = 11
        ' 
        ' Label
        ' 
        Label.AutoSize = True
        Label.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label.Location = New Point(423, 692)
        Label.Name = "Label"
        Label.Size = New Size(85, 21)
        Label.TabIndex = 12
        Label.Text = "Comentarios"
        ' 
        ' BtnGuardarPedido
        ' 
        BtnGuardarPedido.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        BtnGuardarPedido.Location = New Point(603, 839)
        BtnGuardarPedido.Margin = New Padding(3, 4, 3, 4)
        BtnGuardarPedido.Name = "BtnGuardarPedido"
        BtnGuardarPedido.Size = New Size(86, 32)
        BtnGuardarPedido.TabIndex = 13
        BtnGuardarPedido.Text = "Guardar"
        BtnGuardarPedido.UseVisualStyleBackColor = True
        ' 
        ' BtnCancelar
        ' 
        BtnCancelar.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        BtnCancelar.Location = New Point(696, 839)
        BtnCancelar.Margin = New Padding(3, 4, 3, 4)
        BtnCancelar.Name = "BtnCancelar"
        BtnCancelar.Size = New Size(86, 32)
        BtnCancelar.TabIndex = 14
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label4.Location = New Point(423, 734)
        Label4.Name = "Label4"
        Label4.Size = New Size(50, 21)
        Label4.TabIndex = 15
        Label4.Text = "Total: "
        ' 
        ' LblTotal
        ' 
        LblTotal.AutoSize = True
        LblTotal.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        LblTotal.Location = New Point(462, 734)
        LblTotal.Name = "LblTotal"
        LblTotal.Size = New Size(50, 21)
        LblTotal.TabIndex = 16
        LblTotal.Text = "Label5"
        ' 
        ' BtnNuevo
        ' 
        BtnNuevo.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        BtnNuevo.Location = New Point(14, 839)
        BtnNuevo.Margin = New Padding(3, 4, 3, 4)
        BtnNuevo.Name = "BtnNuevo"
        BtnNuevo.Size = New Size(86, 32)
        BtnNuevo.TabIndex = 17
        BtnNuevo.Text = "Nuevo"
        BtnNuevo.UseVisualStyleBackColor = True
        ' 
        ' FrmPedidos
        ' 
        AutoScaleDimensions = New SizeF(8F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GradientActiveCaption
        ClientSize = New Size(784, 874)
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
        Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Margin = New Padding(3, 4, 3, 4)
        Name = "FrmPedidos"
        StartPosition = FormStartPosition.CenterScreen
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
