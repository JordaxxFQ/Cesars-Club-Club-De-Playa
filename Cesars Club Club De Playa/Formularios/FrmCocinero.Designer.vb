<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCocinero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCocinero))
        LblCocina = New Label()
        PtbCocina = New PictureBox()
        LblPedidos = New Label()
        PtbPedido = New PictureBox()
        CType(PtbCocina, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbPedido, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LblCocina
        ' 
        LblCocina.AutoSize = True
        LblCocina.Cursor = Cursors.Hand
        LblCocina.Font = New Font("Segoe Print", 10F, FontStyle.Bold)
        LblCocina.Location = New Point(118, 28)
        LblCocina.Name = "LblCocina"
        LblCocina.Size = New Size(56, 24)
        LblCocina.TabIndex = 25
        LblCocina.Text = "Cocina"
        ' 
        ' PtbCocina
        ' 
        PtbCocina.Cursor = Cursors.Hand
        PtbCocina.Image = CType(resources.GetObject("PtbCocina.Image"), Image)
        PtbCocina.Location = New Point(12, 12)
        PtbCocina.Name = "PtbCocina"
        PtbCocina.Size = New Size(113, 89)
        PtbCocina.SizeMode = PictureBoxSizeMode.Zoom
        PtbCocina.TabIndex = 24
        PtbCocina.TabStop = False
        ' 
        ' LblPedidos
        ' 
        LblPedidos.AutoSize = True
        LblPedidos.Cursor = Cursors.Hand
        LblPedidos.Font = New Font("Segoe Print", 10F, FontStyle.Bold)
        LblPedidos.Location = New Point(118, 136)
        LblPedidos.Name = "LblPedidos"
        LblPedidos.Size = New Size(63, 24)
        LblPedidos.TabIndex = 27
        LblPedidos.Text = "Pedidos"
        ' 
        ' PtbPedido
        ' 
        PtbPedido.Cursor = Cursors.Hand
        PtbPedido.Image = CType(resources.GetObject("PtbPedido.Image"), Image)
        PtbPedido.Location = New Point(12, 120)
        PtbPedido.Name = "PtbPedido"
        PtbPedido.Size = New Size(113, 89)
        PtbPedido.SizeMode = PictureBoxSizeMode.Zoom
        PtbPedido.TabIndex = 26
        PtbPedido.TabStop = False
        ' 
        ' FrmCocinero
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GradientActiveCaption
        ClientSize = New Size(800, 450)
        Controls.Add(LblPedidos)
        Controls.Add(PtbPedido)
        Controls.Add(LblCocina)
        Controls.Add(PtbCocina)
        Name = "FrmCocinero"
        Text = "FrmCocinero"
        CType(PtbCocina, ComponentModel.ISupportInitialize).EndInit()
        CType(PtbPedido, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents LblCocina As Label
    Friend WithEvents PtbCocina As PictureBox
    Friend WithEvents LblPedidos As Label
    Friend WithEvents PtbPedido As PictureBox
End Class
