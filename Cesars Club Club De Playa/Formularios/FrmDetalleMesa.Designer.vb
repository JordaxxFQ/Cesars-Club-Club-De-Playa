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
        btnBuscarCliente.Location = New Point(28, 182)
        btnBuscarCliente.Name = "btnBuscarCliente"
        btnBuscarCliente.Size = New Size(75, 23)
        btnBuscarCliente.TabIndex = 2
        btnBuscarCliente.Text = "Buscar"
        btnBuscarCliente.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(109, 182)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(75, 23)
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
        btnLiberar.Location = New Point(28, 211)
        btnLiberar.Name = "btnLiberar"
        btnLiberar.Size = New Size(156, 23)
        btnLiberar.TabIndex = 7
        btnLiberar.Text = "Liberar Zona"
        btnLiberar.UseVisualStyleBackColor = True
        ' 
        ' btnOcupar
        ' 
        btnOcupar.Location = New Point(28, 240)
        btnOcupar.Name = "btnOcupar"
        btnOcupar.Size = New Size(156, 23)
        btnOcupar.TabIndex = 8
        btnOcupar.Text = "Ocupada"
        btnOcupar.UseVisualStyleBackColor = True
        ' 
        ' FrmDetalleMesa
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
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
End Class
