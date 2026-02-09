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
        BtnCocina = New Button()
        PtbProducto = New PictureBox()
        LblProducto = New Label()
        PtbPersonal = New PictureBox()
        LblPersonal = New Label()
        PtbClientes = New PictureBox()
        LblClientes = New Label()
        PtbPedido = New PictureBox()
        LblPedidos = New Label()
        LblFactura = New Label()
        PtbFactura = New PictureBox()
        LblZonas = New Label()
        PtbZonas = New PictureBox()
        CType(PtbProducto, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbPersonal, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbClientes, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbPedido, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbFactura, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbZonas, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnReservaciones
        ' 
        btnReservaciones.Location = New Point(803, 231)
        btnReservaciones.Name = "btnReservaciones"
        btnReservaciones.Size = New Size(117, 98)
        btnReservaciones.TabIndex = 1
        btnReservaciones.Text = "Reservaciones"
        btnReservaciones.UseVisualStyleBackColor = True
        ' 
        ' BtnCocina
        ' 
        BtnCocina.Location = New Point(803, 334)
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
        PtbProducto.Location = New Point(12, 194)
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
        LblProducto.Location = New Point(118, 210)
        LblProducto.Name = "LblProducto"
        LblProducto.Size = New Size(81, 24)
        LblProducto.TabIndex = 9
        LblProducto.Text = "Productos"
        ' 
        ' PtbPersonal
        ' 
        PtbPersonal.Image = CType(resources.GetObject("PtbPersonal.Image"), Image)
        PtbPersonal.Location = New Point(10, 4)
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
        LblPersonal.Location = New Point(123, 47)
        LblPersonal.Name = "LblPersonal"
        LblPersonal.Size = New Size(69, 24)
        LblPersonal.TabIndex = 11
        LblPersonal.Text = "Personal"
        ' 
        ' PtbClientes
        ' 
        PtbClientes.Image = CType(resources.GetObject("PtbClientes.Image"), Image)
        PtbClientes.Location = New Point(10, 99)
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
        LblClientes.Location = New Point(118, 136)
        LblClientes.Name = "LblClientes"
        LblClientes.Size = New Size(64, 24)
        LblClientes.TabIndex = 13
        LblClientes.Text = "Clientes"
        ' 
        ' PtbPedido
        ' 
        PtbPedido.Image = CType(resources.GetObject("PtbPedido.Image"), Image)
        PtbPedido.Location = New Point(12, 289)
        PtbPedido.Name = "PtbPedido"
        PtbPedido.Size = New Size(113, 89)
        PtbPedido.SizeMode = PictureBoxSizeMode.Zoom
        PtbPedido.TabIndex = 16
        PtbPedido.TabStop = False
        ' 
        ' LblPedidos
        ' 
        LblPedidos.AutoSize = True
        LblPedidos.Font = New Font("Segoe Print", 10F, FontStyle.Bold)
        LblPedidos.Location = New Point(118, 305)
        LblPedidos.Name = "LblPedidos"
        LblPedidos.Size = New Size(63, 24)
        LblPedidos.TabIndex = 17
        LblPedidos.Text = "Pedidos"
        ' 
        ' LblFactura
        ' 
        LblFactura.AutoSize = True
        LblFactura.Font = New Font("Segoe Print", 10F, FontStyle.Bold)
        LblFactura.Location = New Point(118, 400)
        LblFactura.Name = "LblFactura"
        LblFactura.Size = New Size(70, 24)
        LblFactura.TabIndex = 19
        LblFactura.Text = "Facturas"
        ' 
        ' PtbFactura
        ' 
        PtbFactura.Image = CType(resources.GetObject("PtbFactura.Image"), Image)
        PtbFactura.Location = New Point(12, 384)
        PtbFactura.Name = "PtbFactura"
        PtbFactura.Size = New Size(113, 89)
        PtbFactura.SizeMode = PictureBoxSizeMode.Zoom
        PtbFactura.TabIndex = 18
        PtbFactura.TabStop = False
        ' 
        ' LblZonas
        ' 
        LblZonas.AutoSize = True
        LblZonas.Font = New Font("Segoe Print", 10F, FontStyle.Bold)
        LblZonas.Location = New Point(118, 495)
        LblZonas.Name = "LblZonas"
        LblZonas.Size = New Size(52, 24)
        LblZonas.TabIndex = 21
        LblZonas.Text = "Zonas"
        ' 
        ' PtbZonas
        ' 
        PtbZonas.Image = CType(resources.GetObject("PtbZonas.Image"), Image)
        PtbZonas.Location = New Point(12, 479)
        PtbZonas.Name = "PtbZonas"
        PtbZonas.Size = New Size(113, 89)
        PtbZonas.SizeMode = PictureBoxSizeMode.Zoom
        PtbZonas.TabIndex = 20
        PtbZonas.TabStop = False
        ' 
        ' FrmGerente
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GradientActiveCaption
        ClientSize = New Size(1279, 622)
        Controls.Add(LblZonas)
        Controls.Add(PtbZonas)
        Controls.Add(LblFactura)
        Controls.Add(PtbFactura)
        Controls.Add(LblPedidos)
        Controls.Add(PtbPedido)
        Controls.Add(LblClientes)
        Controls.Add(LblPersonal)
        Controls.Add(LblProducto)
        Controls.Add(BtnCocina)
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
        CType(PtbPedido, ComponentModel.ISupportInitialize).EndInit()
        CType(PtbFactura, ComponentModel.ISupportInitialize).EndInit()
        CType(PtbZonas, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnReservaciones As Button
    Friend WithEvents BtnCocina As Button
    Friend WithEvents PtbProducto As PictureBox
    Friend WithEvents LblProducto As Label
    Friend WithEvents PtbPersonal As PictureBox
    Friend WithEvents LblPersonal As Label
    Friend WithEvents PtbClientes As PictureBox
    Friend WithEvents LblClientes As Label
    Friend WithEvents PtbPedido As PictureBox
    Friend WithEvents LblPedidos As Label
    Friend WithEvents LblFactura As Label
    Friend WithEvents PtbFactura As PictureBox
    Friend WithEvents LblZonas As Label
    Friend WithEvents PtbZonas As PictureBox
End Class
