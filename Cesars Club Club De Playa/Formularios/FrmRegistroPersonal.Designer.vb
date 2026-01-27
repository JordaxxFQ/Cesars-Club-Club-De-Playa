<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroPersonal
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
        components = New ComponentModel.Container()
        btnAgg = New Button()
        btnRefresh = New Button()
        btnDelete = New Button()
        Label1 = New Label()
        ConexionBDBindingSource = New BindingSource(components)
        CType(ConexionBDBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAgg
        ' 
        btnAgg.Location = New Point(394, 92)
        btnAgg.Name = "btnAgg"
        btnAgg.Size = New Size(94, 29)
        btnAgg.TabIndex = 0
        btnAgg.Text = "Agregar"
        btnAgg.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Location = New Point(394, 144)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(94, 29)
        btnRefresh.TabIndex = 1
        btnRefresh.Text = "Actualizar"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(394, 190)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(94, 29)
        btnDelete.TabIndex = 2
        btnDelete.Text = "Eliminar"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(158, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(141, 20)
        Label1.TabIndex = 3
        Label1.Text = "Listado del Personal"
        ' 
        ' ConexionBDBindingSource
        ' 
        ConexionBDBindingSource.DataSource = GetType(DAL.ConexionBD)
        ' 
        ' FrmRegistroPersonal
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(536, 619)
        Controls.Add(Label1)
        Controls.Add(btnDelete)
        Controls.Add(btnRefresh)
        Controls.Add(btnAgg)
        Name = "FrmRegistroPersonal"
        Text = "FrmRegistroPersonal"
        CType(ConexionBDBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnAgg As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ConexionBDBindingSource As BindingSource
End Class
