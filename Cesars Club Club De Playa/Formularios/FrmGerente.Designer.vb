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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGerente))
        btnReservaciones = New Button()
        btnMesita = New Button()
        btnFactura = New Button()
        btonPedido = New Button()
        btnClient = New Button()
        BtnCocina = New Button()
        PtbProducto = New PictureBox()
        LblProducto = New Label()
        PtbPersonal = New PictureBox()
        LblPersonal = New Label()
        PtbClientes = New PictureBox()
        LblClientes = New Label()
        LblPedido = New Label()
        PtbPedidos = New PictureBox()
        CType(PtbProducto, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbPersonal, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbClientes, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbPedidos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnReservaciones
        ' 
        btnReservaciones.Location = New Point(882, 157)
        btnReservaciones.Name = "btnReservaciones"
        btnReservaciones.Size = New Size(117, 98)
        btnReservaciones.TabIndex = 1
        btnReservaciones.Text = "Reservaciones"
        btnReservaciones.UseVisualStyleBackColor = True
        ' 
        ' btnMesita
        ' 
        btnMesita.Location = New Point(882, 461)
        btnMesita.Name = "btnMesita"
        btnMesita.Size = New Size(117, 98)
        btnMesita.TabIndex = 2
        btnMesita.Text = "Mesas"
        btnMesita.UseVisualStyleBackColor = True
        ' 
        ' btnFactura
        ' 
        btnFactura.Location = New Point(826, 336)
        btnFactura.Name = "btnFactura"
        btnFactura.Size = New Size(118, 98)
        btnFactura.TabIndex = 3
        btnFactura.Text = "Factura"
        btnFactura.UseVisualStyleBackColor = True
        ' 
        ' btonPedido
        ' 
        btonPedido.Location = New Point(998, 308)
        btonPedido.Margin = New Padding(3, 2, 3, 2)
        btonPedido.Name = "btonPedido"
        btonPedido.Size = New Size(118, 98)
        btonPedido.TabIndex = 4
        btonPedido.Text = "Pedidos"
        btonPedido.UseVisualStyleBackColor = True
        ' 
        ' btnClient
        ' 
        btnClient.Location = New Point(642, 308)
        btnClient.Margin = New Padding(3, 2, 3, 2)
        btnClient.Name = "btnClient"
        btnClient.Size = New Size(118, 98)
        btnClient.TabIndex = 5
        btnClient.Text = "Clientes"
        btnClient.UseVisualStyleBackColor = True
        ' 
        ' BtnCocina
        ' 
        BtnCocina.Location = New Point(651, 461)
        BtnCocina.Margin = New Padding(3, 2, 3, 2)
        BtnCocina.Name = "BtnCocina"
        BtnCocina.Size = New Size(118, 98)
        BtnCocina.TabIndex = 7
        BtnCocina.Text = "Cocina"
        BtnCocina.UseVisualStyleBackColor = True
        ' 
        ' PtbProducto
        ' 
        PtbProducto.Image = CType(resources.GetObject("PtbProducto.Image"), Image)
        PtbProducto.Location = New Point(289, 234)
        PtbProducto.Name = "PtbProducto"
        PtbProducto.Size = New Size(113, 89)
        PtbProducto.SizeMode = PictureBoxSizeMode.Zoom
        PtbProducto.TabIndex = 8
        PtbProducto.TabStop = False
        ' 
        ' LblProducto
        ' 
        LblProducto.AutoSize = True
        LblProducto.Font = New Font("Segoe Print", 10F, FontStyle.Bold)
        LblProducto.Location = New Point(395, 250)
        LblProducto.Name = "LblProducto"
        LblProducto.Size = New Size(81, 24)
        LblProducto.TabIndex = 9
        LblProducto.Text = "Productos"
        ' 
        ' PtbPersonal
        ' 
        PtbPersonal.Image = CType(resources.GetObject("PtbPersonal.Image"), Image)
        PtbPersonal.Location = New Point(287, 44)
        PtbPersonal.Name = "PtbPersonal"
        PtbPersonal.Size = New Size(115, 89)
        PtbPersonal.SizeMode = PictureBoxSizeMode.Zoom
        PtbPersonal.TabIndex = 10
        PtbPersonal.TabStop = False
        ' 
        ' LblPersonal
        ' 
        LblPersonal.AutoSize = True
        LblPersonal.Font = New Font("Segoe Print", 10F, FontStyle.Bold)
        LblPersonal.Location = New Point(400, 87)
        LblPersonal.Name = "LblPersonal"
        LblPersonal.Size = New Size(69, 24)
        LblPersonal.TabIndex = 11
        LblPersonal.Text = "Personal"
        ' 
        ' PtbClientes
        ' 
        PtbClientes.Image = CType(resources.GetObject("PtbClientes.Image"), Image)
        PtbClientes.Location = New Point(287, 139)
        PtbClientes.Name = "PtbClientes"
        PtbClientes.Size = New Size(115, 89)
        PtbClientes.SizeMode = PictureBoxSizeMode.Zoom
        PtbClientes.TabIndex = 12
        PtbClientes.TabStop = False
        ' 
        ' LblClientes
        ' 
        LblClientes.AutoSize = True
        LblClientes.Font = New Font("Segoe Print", 10F, FontStyle.Bold)
        LblClientes.Location = New Point(395, 176)
        LblClientes.Name = "LblClientes"
        LblClientes.Size = New Size(64, 24)
        LblClientes.TabIndex = 13
        LblClientes.Text = "Clientes"
        ' 
        ' LblPedido
        ' 
        LblPedido.AutoSize = True
        LblPedido.Font = New Font("Segoe Print", 10F, FontStyle.Bold)
        LblPedido.Location = New Point(395, 345)
        LblPedido.Name = "LblPedido"
        LblPedido.Size = New Size(63, 24)
        LblPedido.TabIndex = 15
        LblPedido.Text = "Pedidos"
        ' 
        ' PtbPedidos
        ' 
        PtbPedidos.Image = CType(resources.GetObject("PtbPedidos.Image"), Image)
        PtbPedidos.Location = New Point(289, 336)
        PtbPedidos.Name = "PtbPedidos"
        PtbPedidos.Size = New Size(113, 89)
        PtbPedidos.SizeMode = PictureBoxSizeMode.Zoom
        PtbPedidos.TabIndex = 14
        PtbPedidos.TabStop = False
        ' 
        ' FrmGerente
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GradientActiveCaption
        ClientSize = New Size(1279, 622)
        Controls.Add(LblPedido)
        Controls.Add(PtbPedidos)
        Controls.Add(LblClientes)
        Controls.Add(LblPersonal)
        Controls.Add(LblProducto)
        Controls.Add(BtnCocina)
        Controls.Add(btnClient)
        Controls.Add(btonPedido)
        Controls.Add(btnFactura)
        Controls.Add(btnMesita)
        Controls.Add(btnReservaciones)
        Controls.Add(PtbClientes)
        Controls.Add(PtbPersonal)
        Controls.Add(PtbProducto)
        Name = "FrmGerente"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Menú"
        CType(PtbProducto, ComponentModel.ISupportInitialize).EndInit()
        CType(PtbPersonal, ComponentModel.ISupportInitialize).EndInit()
        CType(PtbClientes, ComponentModel.ISupportInitialize).EndInit()
        CType(PtbPedidos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnReservaciones As Button
    Friend WithEvents btnMesita As Button
    Friend WithEvents btnFactura As Button
    Friend WithEvents btonPedido As Button
    Friend WithEvents btnClient As Button
    Friend WithEvents BtnCocina As Button
    Friend WithEvents PtbProducto As PictureBox
    Friend WithEvents LblProducto As Label
    Friend WithEvents PtbPersonal As PictureBox
    Friend WithEvents LblPersonal As Label
    Friend WithEvents PtbClientes As PictureBox
    Friend WithEvents LblClientes As Label
    Friend WithEvents LblPedido As Label
    Friend WithEvents PtbPedidos As PictureBox
End Class
