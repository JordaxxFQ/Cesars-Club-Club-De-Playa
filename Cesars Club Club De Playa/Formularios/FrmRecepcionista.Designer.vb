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
        btnMesas = New Button()
        btnPedido = New Button()
        SuspendLayout()
        ' 
        ' btnMesas
        ' 
        btnMesas.Location = New Point(12, 12)
        btnMesas.Name = "btnMesas"
        btnMesas.Size = New Size(297, 521)
        btnMesas.TabIndex = 0
        btnMesas.Text = "Mesas"
        btnMesas.UseVisualStyleBackColor = True
        ' 
        ' btnPedido
        ' 
        btnPedido.Location = New Point(315, 12)
        btnPedido.Name = "btnPedido"
        btnPedido.Size = New Size(298, 521)
        btnPedido.TabIndex = 1
        btnPedido.Text = "Pedido"
        btnPedido.UseVisualStyleBackColor = True
        ' 
        ' FrmRecepcionista
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(625, 545)
        Controls.Add(btnPedido)
        Controls.Add(btnMesas)
        Name = "FrmRecepcionista"
        Text = "FrmRecepcionista"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnMesas As Button
    Friend WithEvents btnPedido As Button
End Class
