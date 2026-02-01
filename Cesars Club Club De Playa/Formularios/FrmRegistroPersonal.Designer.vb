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
        btnDelete = New Button()
        Label1 = New Label()
        ConexionBDBindingSource = New BindingSource(components)
        ConexionBDBindingSource1 = New BindingSource(components)
        DgvPersonal = New DataGridView()
        CType(ConexionBDBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(ConexionBDBindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DgvPersonal, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAgg
        ' 
        btnAgg.Location = New Point(345, 125)
        btnAgg.Margin = New Padding(3, 2, 3, 2)
        btnAgg.Name = "btnAgg"
        btnAgg.Size = New Size(82, 43)
        btnAgg.TabIndex = 0
        btnAgg.Text = "Agregar"
        btnAgg.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(345, 69)
        btnDelete.Margin = New Padding(3, 2, 3, 2)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(82, 43)
        btnDelete.TabIndex = 2
        btnDelete.Text = "Eliminar"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(105, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(112, 15)
        Label1.TabIndex = 3
        Label1.Text = "Listado del Personal"
        ' 
        ' ConexionBDBindingSource
        ' 
        ConexionBDBindingSource.DataSource = GetType(DAL.ConexionBD)
        ' 
        ' ConexionBDBindingSource1
        ' 
        ConexionBDBindingSource1.DataSource = GetType(DAL.ConexionBD)
        ' 
        ' DgvPersonal
        ' 
        DgvPersonal.AllowUserToOrderColumns = True
        DgvPersonal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvPersonal.Location = New Point(21, 69)
        DgvPersonal.Name = "DgvPersonal"
        DgvPersonal.Size = New Size(308, 383)
        DgvPersonal.TabIndex = 10
        ' 
        ' FrmRegistroPersonal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(469, 464)
        Controls.Add(DgvPersonal)
        Controls.Add(Label1)
        Controls.Add(btnDelete)
        Controls.Add(btnAgg)
        Margin = New Padding(3, 2, 3, 2)
        Name = "FrmRegistroPersonal"
        Text = "FrmRegistroPersonal"
        CType(ConexionBDBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(ConexionBDBindingSource1, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvPersonal, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnAgg As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ConexionBDBindingSource As BindingSource
    Friend WithEvents ConexionBDBindingSource1 As BindingSource
    Friend WithEvents DgvPersonal As DataGridView
End Class
