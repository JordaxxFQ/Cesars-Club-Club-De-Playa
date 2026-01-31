<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReserva
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
        TablaReserva = New DataGridView()
        CType(TablaReserva, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TablaReserva
        ' 
        TablaReserva.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        TablaReserva.Location = New Point(12, 11)
        TablaReserva.Margin = New Padding(3, 2, 3, 2)
        TablaReserva.Name = "TablaReserva"
        TablaReserva.RowHeadersWidth = 51
        TablaReserva.Size = New Size(926, 551)
        TablaReserva.TabIndex = 0
        ' 
        ' FrmReserva
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(950, 573)
        Controls.Add(TablaReserva)
        Margin = New Padding(3, 2, 3, 2)
        Name = "FrmReserva"
        Text = "FrmReserva"
        CType(TablaReserva, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TablaReserva As DataGridView
End Class
