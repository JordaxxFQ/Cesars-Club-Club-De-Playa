<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPanelMesas
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
        flpMesas = New FlowLayoutPanel()
        SuspendLayout()
        ' 
        ' flpMesas
        ' 
        flpMesas.AutoScroll = True
        flpMesas.Dock = DockStyle.Fill
        flpMesas.Location = New Point(0, 0)
        flpMesas.Name = "flpMesas"
        flpMesas.Size = New Size(800, 450)
        flpMesas.TabIndex = 0
        ' 
        ' FrmPanelMesas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(flpMesas)
        Name = "FrmPanelMesas"
        Text = "FrmPanelMesas"
        ResumeLayout(False)
    End Sub

    Friend WithEvents flpMesas As FlowLayoutPanel
End Class
