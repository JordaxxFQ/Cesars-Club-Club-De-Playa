<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetalleMesa
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
        txtCedula = New TextBox()
        txtNombre = New TextBox()
        btnBuscarCliente = New Button()
        btnGuardar = New Button()
        lblTitulo = New Label()
        Label1 = New Label()
        Label2 = New Label()
        btnLiberar = New Button()
        btnOcupar = New Button()
        btonDeleteReserv = New Button()
        TablaReserva2 = New DataGridView()
        cmbCantPeople = New ComboBox()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        cmbHoraInicio = New ComboBox()
        cmbHoraFin = New ComboBox()
        CType(TablaReserva2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtCedula
        ' 
        txtCedula.Location = New Point(28, 80)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(100, 23)
        txtCedula.TabIndex = 0
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(28, 134)
        txtNombre.Name = "txtNombre"
        txtNombre.ReadOnly = True
        txtNombre.Size = New Size(100, 23)
        txtNombre.TabIndex = 1
        ' 
        ' btnBuscarCliente
        ' 
        btnBuscarCliente.Location = New Point(28, 181)
        btnBuscarCliente.Name = "btnBuscarCliente"
        btnBuscarCliente.Size = New Size(75, 46)
        btnBuscarCliente.TabIndex = 2
        btnBuscarCliente.Text = "Buscar"
        btnBuscarCliente.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(28, 233)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(75, 46)
        btnGuardar.TabIndex = 3
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Location = New Point(87, 32)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(50, 15)
        lblTitulo.TabIndex = 4
        lblTitulo.Text = "lblTitulo"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(28, 62)
        Label1.Name = "Label1"
        Label1.Size = New Size(44, 15)
        Label1.TabIndex = 5
        Label1.Text = "Cedula"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(28, 116)
        Label2.Name = "Label2"
        Label2.Size = New Size(51, 15)
        Label2.TabIndex = 6
        Label2.Text = "Nombre"
        ' 
        ' btnLiberar
        ' 
        btnLiberar.Location = New Point(28, 285)
        btnLiberar.Name = "btnLiberar"
        btnLiberar.Size = New Size(75, 47)
        btnLiberar.TabIndex = 7
        btnLiberar.Text = "Liberar Zona"
        btnLiberar.UseVisualStyleBackColor = True
        ' 
        ' btnOcupar
        ' 
        btnOcupar.Location = New Point(28, 338)
        btnOcupar.Name = "btnOcupar"
        btnOcupar.Size = New Size(75, 47)
        btnOcupar.TabIndex = 8
        btnOcupar.Text = "Ocupada"
        btnOcupar.UseVisualStyleBackColor = True
        ' 
        ' btonDeleteReserv
        ' 
        btonDeleteReserv.Location = New Point(28, 390)
        btonDeleteReserv.Margin = New Padding(3, 2, 3, 2)
        btonDeleteReserv.Name = "btonDeleteReserv"
        btonDeleteReserv.Size = New Size(75, 47)
        btonDeleteReserv.TabIndex = 9
        btonDeleteReserv.Text = "Eliminar"
        btonDeleteReserv.UseVisualStyleBackColor = True
        ' 
        ' TablaReserva2
        ' 
        TablaReserva2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        TablaReserva2.Location = New Point(109, 192)
        TablaReserva2.Margin = New Padding(3, 2, 3, 2)
        TablaReserva2.Name = "TablaReserva2"
        TablaReserva2.RowHeadersWidth = 51
        TablaReserva2.Size = New Size(1127, 414)
        TablaReserva2.TabIndex = 10
        ' 
        ' cmbCantPeople
        ' 
        cmbCantPeople.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCantPeople.FormattingEnabled = True
        cmbCantPeople.Location = New Point(367, 134)
        cmbCantPeople.Name = "cmbCantPeople"
        cmbCantPeople.Size = New Size(121, 23)
        cmbCantPeople.TabIndex = 11
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(151, 62)
        Label3.Name = "Label3"
        Label3.Size = New Size(65, 15)
        Label3.TabIndex = 14
        Label3.Text = "Hora Inicio"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(151, 116)
        Label4.Name = "Label4"
        Label4.Size = New Size(52, 15)
        Label4.TabIndex = 15
        Label4.Text = "Hora Fin"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(367, 116)
        Label5.Name = "Label5"
        Label5.Size = New Size(121, 15)
        Label5.TabIndex = 16
        Label5.Text = "Cantidad de Personas"
        ' 
        ' cmbHoraInicio
        ' 
        cmbHoraInicio.FormattingEnabled = True
        cmbHoraInicio.Location = New Point(151, 80)
        cmbHoraInicio.Name = "cmbHoraInicio"
        cmbHoraInicio.Size = New Size(98, 23)
        cmbHoraInicio.TabIndex = 17
        ' 
        ' cmbHoraFin
        ' 
        cmbHoraFin.FormattingEnabled = True
        cmbHoraFin.Location = New Point(151, 134)
        cmbHoraFin.Name = "cmbHoraFin"
        cmbHoraFin.Size = New Size(98, 23)
        cmbHoraFin.TabIndex = 18
        ' 
        ' FrmDetalleMesa
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1248, 617)
        Controls.Add(cmbHoraFin)
        Controls.Add(cmbHoraInicio)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(cmbCantPeople)
        Controls.Add(TablaReserva2)
        Controls.Add(btonDeleteReserv)
        Controls.Add(btnOcupar)
        Controls.Add(btnLiberar)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(lblTitulo)
        Controls.Add(btnGuardar)
        Controls.Add(btnBuscarCliente)
        Controls.Add(txtNombre)
        Controls.Add(txtCedula)
        Name = "FrmDetalleMesa"
        Text = "FrmDetalleMesa"
        CType(TablaReserva2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtCedula As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnLiberar As Button
    Friend WithEvents btnOcupar As Button
    Friend WithEvents btonDeleteReserv As Button
    Friend WithEvents TablaReserva2 As DataGridView
    Friend WithEvents cmbCantPeople As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbHoraInicio As ComboBox
    Friend WithEvents cmbHoraFin As ComboBox
End Class
