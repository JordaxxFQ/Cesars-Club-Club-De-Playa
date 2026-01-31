<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGerente
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
        btnRegistro = New Button()
        btnReservaciones = New Button()
        btnMesita = New Button()
        btnFactura = New Button()
        btonPedido = New Button()
        btnClient = New Button()
        btnProducto = New Button()
        BtnCocina = New Button()
        SuspendLayout()
        ' 
        ' btnRegistro
        ' 
        btnRegistro.Location = New Point(12, 35)
        btnRegistro.Name = "btnRegistro"
        btnRegistro.Size = New Size(117, 98)
        btnRegistro.TabIndex = 0
        btnRegistro.Text = "Personal"
        btnRegistro.UseVisualStyleBackColor = True
        ' 
        ' btnReservaciones
        ' 
        btnReservaciones.Location = New Point(242, 265)
        btnReservaciones.Name = "btnReservaciones"
        btnReservaciones.Size = New Size(117, 98)
        btnReservaciones.TabIndex = 1
        btnReservaciones.Text = "Reservaciones"
        btnReservaciones.UseVisualStyleBackColor = True
        ' 
        ' btnMesita
        ' 
        btnMesita.Location = New Point(532, 265)
        btnMesita.Name = "btnMesita"
        btnMesita.Size = New Size(117, 98)
        btnMesita.TabIndex = 2
        btnMesita.Text = "Mesas"
        btnMesita.UseVisualStyleBackColor = True
        ' 
        ' btnFactura
        ' 
        btnFactura.Location = New Point(753, 35)
        btnFactura.Name = "btnFactura"
        btnFactura.Size = New Size(118, 98)
        btnFactura.TabIndex = 3
        btnFactura.Text = "Factura"
        btnFactura.UseVisualStyleBackColor = True
        ' 
        ' btonPedido
        ' 
        btonPedido.Location = New Point(101, 265)
        btonPedido.Margin = New Padding(3, 2, 3, 2)
        btonPedido.Name = "btonPedido"
        btonPedido.Size = New Size(118, 98)
        btonPedido.TabIndex = 4
        btonPedido.Text = "Pedidos"
        btonPedido.UseVisualStyleBackColor = True
        ' 
        ' btnClient
        ' 
        btnClient.Location = New Point(176, 162)
        btnClient.Margin = New Padding(3, 2, 3, 2)
        btnClient.Name = "btnClient"
        btnClient.Size = New Size(118, 98)
        btnClient.TabIndex = 5
        btnClient.Text = "Clientes"
        btnClient.UseVisualStyleBackColor = True
        ' 
        ' btnProducto
        ' 
        btnProducto.Location = New Point(684, 265)
        btnProducto.Margin = New Padding(3, 2, 3, 2)
        btnProducto.Name = "btnProducto"
        btnProducto.Size = New Size(118, 98)
        btnProducto.TabIndex = 6
        btnProducto.Text = "Productos"
        btnProducto.UseVisualStyleBackColor = True
        ' 
        ' BtnCocina
        ' 
        BtnCocina.Location = New Point(374, 35)
        BtnCocina.Margin = New Padding(3, 2, 3, 2)
        BtnCocina.Name = "BtnCocina"
        BtnCocina.Size = New Size(118, 98)
        BtnCocina.TabIndex = 7
        BtnCocina.Text = "Cocina"
        BtnCocina.UseVisualStyleBackColor = True
        ' 
        ' FrmGerente
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(891, 556)
        Controls.Add(BtnCocina)
        Controls.Add(btnProducto)
        Controls.Add(btnClient)
        Controls.Add(btonPedido)
        Controls.Add(btnFactura)
        Controls.Add(btnMesita)
        Controls.Add(btnReservaciones)
        Controls.Add(btnRegistro)
        Name = "FrmGerente"
        Text = "Menú"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnRegistro As Button
    Friend WithEvents btnReservaciones As Button
    Friend WithEvents btnMesita As Button
    Friend WithEvents btnFactura As Button
    Friend WithEvents btonPedido As Button
    Friend WithEvents btnClient As Button
    Friend WithEvents btnProducto As Button
    Friend WithEvents BtnCocina As Button
End Class
