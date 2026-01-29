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
        SuspendLayout()
        ' 
        ' btnRegistro
        ' 
        btnRegistro.Location = New Point(14, 47)
        btnRegistro.Margin = New Padding(3, 4, 3, 4)
        btnRegistro.Name = "btnRegistro"
        btnRegistro.Size = New Size(134, 131)
        btnRegistro.TabIndex = 0
        btnRegistro.Text = "Personal"
        btnRegistro.UseVisualStyleBackColor = True
        ' 
        ' btnReservaciones
        ' 
        btnReservaciones.Location = New Point(277, 353)
        btnReservaciones.Margin = New Padding(3, 4, 3, 4)
        btnReservaciones.Name = "btnReservaciones"
        btnReservaciones.Size = New Size(134, 131)
        btnReservaciones.TabIndex = 1
        btnReservaciones.Text = "Reservaciones"
        btnReservaciones.UseVisualStyleBackColor = True
        ' 
        ' btnMesita
        ' 
        btnMesita.Location = New Point(608, 353)
        btnMesita.Margin = New Padding(3, 4, 3, 4)
        btnMesita.Name = "btnMesita"
        btnMesita.Size = New Size(134, 131)
        btnMesita.TabIndex = 2
        btnMesita.Text = "Mesas"
        btnMesita.UseVisualStyleBackColor = True
        ' 
        ' btnFactura
        ' 
        btnFactura.Location = New Point(861, 47)
        btnFactura.Margin = New Padding(3, 4, 3, 4)
        btnFactura.Name = "btnFactura"
        btnFactura.Size = New Size(135, 131)
        btnFactura.TabIndex = 3
        btnFactura.Text = "Factura"
        btnFactura.UseVisualStyleBackColor = True
        ' 
        ' btonPedido
        ' 
        btonPedido.Location = New Point(115, 353)
        btonPedido.Name = "btonPedido"
        btonPedido.Size = New Size(135, 131)
        btonPedido.TabIndex = 4
        btonPedido.Text = "Pedidos"
        btonPedido.UseVisualStyleBackColor = True
        ' 
        ' btnClient
        ' 
        btnClient.Location = New Point(201, 216)
        btnClient.Name = "btnClient"
        btnClient.Size = New Size(135, 131)
        btnClient.TabIndex = 5
        btnClient.Text = "Clientes"
        btnClient.UseVisualStyleBackColor = True
        ' 
        ' btnProducto
        ' 
        btnProducto.Location = New Point(782, 353)
        btnProducto.Name = "btnProducto"
        btnProducto.Size = New Size(135, 131)
        btnProducto.TabIndex = 6
        btnProducto.Text = "Productos"
        btnProducto.UseVisualStyleBackColor = True
        ' 
        ' FrmGerente
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1018, 741)
        Controls.Add(btnProducto)
        Controls.Add(btnClient)
        Controls.Add(btonPedido)
        Controls.Add(btnFactura)
        Controls.Add(btnMesita)
        Controls.Add(btnReservaciones)
        Controls.Add(btnRegistro)
        Margin = New Padding(3, 4, 3, 4)
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
End Class
