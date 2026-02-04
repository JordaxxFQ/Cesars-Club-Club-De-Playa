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
        btnPedido = New Button()
        btnCocina = New Button()
        SuspendLayout()
        ' 
        ' btnPedido
        ' 
        btnPedido.Location = New Point(80, 30)
        btnPedido.Name = "btnPedido"
        btnPedido.Size = New Size(112, 87)
        btnPedido.TabIndex = 0
        btnPedido.Text = "Pedidos"
        btnPedido.UseVisualStyleBackColor = True
        ' 
        ' btnCocina
        ' 
        btnCocina.Location = New Point(198, 30)
        btnCocina.Name = "btnCocina"
        btnCocina.Size = New Size(112, 87)
        btnCocina.TabIndex = 1
        btnCocina.Text = "Cocina"
        btnCocina.UseVisualStyleBackColor = True
        ' 
        ' FrmCocinero
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnCocina)
        Controls.Add(btnPedido)
        Name = "FrmCocinero"
        Text = "FrmCocinero"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnPedido As Button
    Friend WithEvents btnCocina As Button
End Class
