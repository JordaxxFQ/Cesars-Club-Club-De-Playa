<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroClientes
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        TxtNombre = New TextBox()
        TxtCedula = New TextBox()
        BtnGuardar = New Button()
        BtnLimpiar = New Button()
        dtpFechaRegistro = New DateTimePicker()
        DataGridView1 = New DataGridView()
        BtnEliminar = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 39)
        Label1.Name = "Label1"
        Label1.Size = New Size(107, 15)
        Label1.TabIndex = 0
        Label1.Text = "Nombre y Apellido"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 83)
        Label2.Name = "Label2"
        Label2.Size = New Size(44, 15)
        Label2.TabIndex = 1
        Label2.Text = "Cedula"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 143)
        Label3.Name = "Label3"
        Label3.Size = New Size(100, 15)
        Label3.TabIndex = 2
        Label3.Text = "Fecha de Registro"
        ' 
        ' TxtNombre
        ' 
        TxtNombre.Location = New Point(12, 57)
        TxtNombre.Name = "TxtNombre"
        TxtNombre.Size = New Size(100, 23)
        TxtNombre.TabIndex = 3
        ' 
        ' TxtCedula
        ' 
        TxtCedula.Location = New Point(12, 101)
        TxtCedula.Name = "TxtCedula"
        TxtCedula.Size = New Size(100, 23)
        TxtCedula.TabIndex = 4
        ' 
        ' BtnGuardar
        ' 
        BtnGuardar.Location = New Point(321, 161)
        BtnGuardar.Name = "BtnGuardar"
        BtnGuardar.Size = New Size(75, 23)
        BtnGuardar.TabIndex = 6
        BtnGuardar.Text = "Guardar"
        BtnGuardar.UseVisualStyleBackColor = True
        ' 
        ' BtnLimpiar
        ' 
        BtnLimpiar.Location = New Point(240, 161)
        BtnLimpiar.Name = "BtnLimpiar"
        BtnLimpiar.Size = New Size(75, 23)
        BtnLimpiar.TabIndex = 7
        BtnLimpiar.Text = "Limpiar"
        BtnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' dtpFechaRegistro
        ' 
        dtpFechaRegistro.Location = New Point(12, 161)
        dtpFechaRegistro.Name = "dtpFechaRegistro"
        dtpFechaRegistro.Size = New Size(200, 23)
        dtpFechaRegistro.TabIndex = 8
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 210)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(384, 328)
        DataGridView1.TabIndex = 9
        ' 
        ' BtnEliminar
        ' 
        BtnEliminar.Location = New Point(321, 132)
        BtnEliminar.Name = "BtnEliminar"
        BtnEliminar.Size = New Size(75, 23)
        BtnEliminar.TabIndex = 10
        BtnEliminar.Text = "Eliminar"
        BtnEliminar.UseVisualStyleBackColor = True
        ' 
        ' FrmRegistroClientes
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(417, 550)
        Controls.Add(BtnEliminar)
        Controls.Add(DataGridView1)
        Controls.Add(dtpFechaRegistro)
        Controls.Add(BtnLimpiar)
        Controls.Add(BtnGuardar)
        Controls.Add(TxtCedula)
        Controls.Add(TxtNombre)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "FrmRegistroClientes"
        Text = "FrmRegistroClientes"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents BtnLimpiar As Button
    Friend WithEvents dtpFechaRegistro As DateTimePicker
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BtnEliminar As Button
End Class
