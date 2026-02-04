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
        btonDeleteReserv = New Button()
        Button2 = New Button()
        CType(TablaReserva, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TablaReserva
        ' 
        TablaReserva.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        TablaReserva.Location = New Point(12, 116)
        TablaReserva.Name = "TablaReserva"
        TablaReserva.RowHeadersWidth = 51
        TablaReserva.Size = New Size(860, 322)
        TablaReserva.TabIndex = 0
        ' 
        ' btonDeleteReserv
        ' 
        btonDeleteReserv.Location = New Point(12, 36)
        btonDeleteReserv.Name = "btonDeleteReserv"
        btonDeleteReserv.Size = New Size(114, 74)
        btonDeleteReserv.TabIndex = 1
        btonDeleteReserv.Text = "Eliminar"
        btonDeleteReserv.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(132, 36)
        Button2.Name = "Button2"
        Button2.Size = New Size(117, 74)
        Button2.TabIndex = 2
        Button2.Text = "Agregar "
        Button2.UseVisualStyleBackColor = True
        ' 
        ' FrmReserva
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(884, 450)
        Controls.Add(Button2)
        Controls.Add(btonDeleteReserv)
        Controls.Add(TablaReserva)
        Name = "FrmReserva"
        Text = "FrmReserva"
        CType(TablaReserva, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TablaReserva As DataGridView
    Friend WithEvents btonDeleteReserv As Button
    Friend WithEvents Button2 As Button
End Class
