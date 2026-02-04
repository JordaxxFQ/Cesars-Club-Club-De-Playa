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
        btnReservar = New Button()
        btonDeleteReserv = New Button()
        TablaReserva2 = New DataGridView()
        cmbCantPeople = New ComboBox()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        DtpHoraInicio = New DateTimePicker()
        DtpHoraFin = New DateTimePicker()
        CType(TablaReserva2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtCedula
        ' 
        txtCedula.Location = New Point(32, 107)
        txtCedula.Margin = New Padding(3, 4, 3, 4)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(114, 27)
        txtCedula.TabIndex = 0
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(32, 179)
        txtNombre.Margin = New Padding(3, 4, 3, 4)
        txtNombre.Name = "txtNombre"
        txtNombre.ReadOnly = True
        txtNombre.Size = New Size(114, 27)
        txtNombre.TabIndex = 1
        ' 
        ' btnBuscarCliente
        ' 
        btnBuscarCliente.Location = New Point(32, 241)
        btnBuscarCliente.Margin = New Padding(3, 4, 3, 4)
        btnBuscarCliente.Name = "btnBuscarCliente"
        btnBuscarCliente.Size = New Size(86, 61)
        btnBuscarCliente.TabIndex = 2
        btnBuscarCliente.Text = "Buscar"
        btnBuscarCliente.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(32, 311)
        btnGuardar.Margin = New Padding(3, 4, 3, 4)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(86, 61)
        btnGuardar.TabIndex = 3
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' lblTitulo
        ' 
        lblTitulo.AutoSize = True
        lblTitulo.Location = New Point(99, 43)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(64, 20)
        lblTitulo.TabIndex = 4
        lblTitulo.Text = "lblTitulo"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(32, 83)
        Label1.Name = "Label1"
        Label1.Size = New Size(55, 20)
        Label1.TabIndex = 5
        Label1.Text = "Cedula"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(32, 155)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 20)
        Label2.TabIndex = 6
        Label2.Text = "Nombre"
        ' 
        ' btnLiberar
        ' 
        btnLiberar.Location = New Point(32, 380)
        btnLiberar.Margin = New Padding(3, 4, 3, 4)
        btnLiberar.Name = "btnLiberar"
        btnLiberar.Size = New Size(86, 63)
        btnLiberar.TabIndex = 7
        btnLiberar.Text = "Liberar Zona"
        btnLiberar.UseVisualStyleBackColor = True
        ' 
        ' btnReservar
        ' 
        btnReservar.Location = New Point(32, 451)
        btnReservar.Margin = New Padding(3, 4, 3, 4)
        btnReservar.Name = "btnReservar"
        btnReservar.Size = New Size(86, 63)
        btnReservar.TabIndex = 8
        btnReservar.Text = "Reservar"
        btnReservar.UseVisualStyleBackColor = True
        ' 
        ' btonDeleteReserv
        ' 
        btonDeleteReserv.Location = New Point(32, 520)
        btonDeleteReserv.Name = "btonDeleteReserv"
        btonDeleteReserv.Size = New Size(86, 63)
        btonDeleteReserv.TabIndex = 9
        btonDeleteReserv.Text = "Eliminar"
        btonDeleteReserv.UseVisualStyleBackColor = True
        ' 
        ' TablaReserva2
        ' 
        TablaReserva2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        TablaReserva2.Location = New Point(125, 256)
        TablaReserva2.Name = "TablaReserva2"
        TablaReserva2.RowHeadersWidth = 51
        TablaReserva2.Size = New Size(1288, 552)
        TablaReserva2.TabIndex = 10
        ' 
        ' cmbCantPeople
        ' 
        cmbCantPeople.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCantPeople.FormattingEnabled = True
        cmbCantPeople.Location = New Point(419, 179)
        cmbCantPeople.Margin = New Padding(3, 4, 3, 4)
        cmbCantPeople.Name = "cmbCantPeople"
        cmbCantPeople.Size = New Size(138, 28)
        cmbCantPeople.TabIndex = 11
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(173, 83)
        Label3.Name = "Label3"
        Label3.Size = New Size(82, 20)
        Label3.TabIndex = 14
        Label3.Text = "Hora Inicio"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(173, 155)
        Label4.Name = "Label4"
        Label4.Size = New Size(65, 20)
        Label4.TabIndex = 15
        Label4.Text = "Hora Fin"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(419, 155)
        Label5.Name = "Label5"
        Label5.Size = New Size(151, 20)
        Label5.TabIndex = 16
        Label5.Text = "Cantidad de Personas"
        ' 
        ' DtpHoraInicio
        ' 
        DtpHoraInicio.Location = New Point(173, 107)
        DtpHoraInicio.Margin = New Padding(3, 4, 3, 4)
        DtpHoraInicio.Name = "DtpHoraInicio"
        DtpHoraInicio.Size = New Size(228, 27)
        DtpHoraInicio.TabIndex = 19
        ' 
        ' DtpHoraFin
        ' 
        DtpHoraFin.Location = New Point(173, 179)
        DtpHoraFin.Margin = New Padding(3, 4, 3, 4)
        DtpHoraFin.Name = "DtpHoraFin"
        DtpHoraFin.Size = New Size(228, 27)
        DtpHoraFin.TabIndex = 20
        ' 
        ' FrmDetalleMesa
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1426, 823)
        Controls.Add(DtpHoraFin)
        Controls.Add(DtpHoraInicio)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(cmbCantPeople)
        Controls.Add(TablaReserva2)
        Controls.Add(btonDeleteReserv)
        Controls.Add(btnReservar)
        Controls.Add(btnLiberar)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(lblTitulo)
        Controls.Add(btnGuardar)
        Controls.Add(btnBuscarCliente)
        Controls.Add(txtNombre)
        Controls.Add(txtCedula)
        Margin = New Padding(3, 4, 3, 4)
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
    Friend WithEvents btnReservar As Button
    Friend WithEvents btonDeleteReserv As Button
    Friend WithEvents TablaReserva2 As DataGridView
    Friend WithEvents cmbCantPeople As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DtpHoraInicio As DateTimePicker
    Friend WithEvents DtpHoraFin As DateTimePicker
End Class
