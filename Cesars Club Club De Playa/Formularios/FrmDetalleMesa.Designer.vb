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
        SuspendLayout()
        ' 
        ' txtCedula
        ' 
        txtCedula.Location = New Point(87, 81)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(100, 23)
        txtCedula.TabIndex = 0
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(87, 151)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(100, 23)
        txtNombre.TabIndex = 1
        ' 
        ' btnBuscarCliente
        ' 
        btnBuscarCliente.Location = New Point(369, 228)
        btnBuscarCliente.Name = "btnBuscarCliente"
        btnBuscarCliente.Size = New Size(75, 23)
        btnBuscarCliente.TabIndex = 2
        btnBuscarCliente.Text = "Button1"
        btnBuscarCliente.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(369, 165)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(75, 23)
        btnGuardar.TabIndex = 3
        btnGuardar.Text = "Button2"
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
        ' FrmDetalleMesa
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
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
End Class
