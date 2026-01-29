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
        SuspendLayout()
        ' 
        ' txtCedula
        ' 
        txtCedula.Location = New Point(32, 106)
        txtCedula.Margin = New Padding(3, 4, 3, 4)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(114, 27)
        txtCedula.TabIndex = 0
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(32, 178)
        txtNombre.Margin = New Padding(3, 4, 3, 4)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(114, 27)
        txtNombre.TabIndex = 1
        ' 
        ' btnBuscarCliente
        ' 
        btnBuscarCliente.Location = New Point(201, 176)
        btnBuscarCliente.Margin = New Padding(3, 4, 3, 4)
        btnBuscarCliente.Name = "btnBuscarCliente"
        btnBuscarCliente.Size = New Size(86, 31)
        btnBuscarCliente.TabIndex = 2
        btnBuscarCliente.Text = "Buscar"
        btnBuscarCliente.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(201, 277)
        btnGuardar.Margin = New Padding(3, 4, 3, 4)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(86, 31)
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
        Label1.Location = New Point(32, 82)
        Label1.Name = "Label1"
        Label1.Size = New Size(55, 20)
        Label1.TabIndex = 5
        Label1.Text = "Cedula"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(32, 154)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 20)
        Label2.TabIndex = 6
        Label2.Text = "Nombre"
        ' 
        ' FrmDetalleMesa
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(914, 600)
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
End Class
