<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecepcionista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecepcionista))
        LblZonas = New Label()
        PtbZonas = New PictureBox()
        LblPedidos = New Label()
        PtbPedido = New PictureBox()
        CType(PtbZonas, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbPedido, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LblZonas
        ' 
        LblZonas.AutoSize = True
        LblZonas.Cursor = Cursors.Hand
        LblZonas.Font = New Font("Segoe Print", 10F, FontStyle.Bold)
        LblZonas.Location = New Point(118, 28)
        LblZonas.Name = "LblZonas"
        LblZonas.Size = New Size(52, 24)
        LblZonas.TabIndex = 23
        LblZonas.Text = "Zonas"
        ' 
        ' PtbZonas
        ' 
        PtbZonas.Cursor = Cursors.Hand
        PtbZonas.Image = CType(resources.GetObject("PtbZonas.Image"), Image)
        PtbZonas.Location = New Point(12, 12)
        PtbZonas.Name = "PtbZonas"
        PtbZonas.Size = New Size(113, 89)
        PtbZonas.SizeMode = PictureBoxSizeMode.Zoom
        PtbZonas.TabIndex = 22
        PtbZonas.TabStop = False
        ' 
        ' LblPedidos
        ' 
        LblPedidos.AutoSize = True
        LblPedidos.Cursor = Cursors.Hand
        LblPedidos.Font = New Font("Segoe Print", 10F, FontStyle.Bold)
        LblPedidos.Location = New Point(118, 133)
        LblPedidos.Name = "LblPedidos"
        LblPedidos.Size = New Size(63, 24)
        LblPedidos.TabIndex = 25
        LblPedidos.Text = "Pedidos"
        ' 
        ' PtbPedido
        ' 
        PtbPedido.Cursor = Cursors.Hand
        PtbPedido.Image = CType(resources.GetObject("PtbPedido.Image"), Image)
        PtbPedido.Location = New Point(12, 117)
        PtbPedido.Name = "PtbPedido"
        PtbPedido.Size = New Size(113, 89)
        PtbPedido.SizeMode = PictureBoxSizeMode.Zoom
        PtbPedido.TabIndex = 24
        PtbPedido.TabStop = False
        ' 
        ' FrmRecepcionista
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GradientActiveCaption
        ClientSize = New Size(625, 545)
        Controls.Add(LblPedidos)
        Controls.Add(PtbPedido)
        Controls.Add(LblZonas)
        Controls.Add(PtbZonas)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "FrmRecepcionista"
        Text = "FrmRecepcionista"
        CType(PtbZonas, ComponentModel.ISupportInitialize).EndInit()
        CType(PtbPedido, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents LblZonas As Label
    Friend WithEvents PtbZonas As PictureBox
    Friend WithEvents LblPedidos As Label
    Friend WithEvents PtbPedido As PictureBox
End Class
