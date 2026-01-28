<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAggPerso
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
        txtboxusuario = New TextBox()
        txtboxContra = New TextBox()
        txtRol = New TextBox()
        txtTurno = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        DataGridView1 = New DataGridView()
        ConexionBDBindingSource = New BindingSource(components)
        btnConfirmar = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(ConexionBDBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtboxusuario
        ' 
        txtboxusuario.Location = New Point(12, 76)
        txtboxusuario.Name = "txtboxusuario"
        txtboxusuario.Size = New Size(100, 23)
        txtboxusuario.TabIndex = 0
        ' 
        ' txtboxContra
        ' 
        txtboxContra.Location = New Point(12, 136)
        txtboxContra.Name = "txtboxContra"
        txtboxContra.Size = New Size(100, 23)
        txtboxContra.TabIndex = 1
        ' 
        ' txtRol
        ' 
        txtRol.Location = New Point(12, 199)
        txtRol.Name = "txtRol"
        txtRol.Size = New Size(100, 23)
        txtRol.TabIndex = 2
        ' 
        ' txtTurno
        ' 
        txtTurno.Location = New Point(12, 252)
        txtTurno.Name = "txtTurno"
        txtTurno.Size = New Size(100, 23)
        txtTurno.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 58)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 15)
        Label1.TabIndex = 4
        Label1.Text = "Usuario"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 118)
        Label2.Name = "Label2"
        Label2.Size = New Size(67, 15)
        Label2.TabIndex = 5
        Label2.Text = "Contraseña"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 181)
        Label3.Name = "Label3"
        Label3.Size = New Size(24, 15)
        Label3.TabIndex = 6
        Label3.Text = "Rol"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 234)
        Label4.Name = "Label4"
        Label4.Size = New Size(38, 15)
        Label4.TabIndex = 7
        Label4.Text = "Turno"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToOrderColumns = True
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.DataSource = ConexionBDBindingSource
        DataGridView1.Location = New Point(144, 58)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(277, 365)
        DataGridView1.TabIndex = 8
        ' 
        ' ConexionBDBindingSource
        ' 
        ConexionBDBindingSource.DataSource = GetType(DAL.ConexionBD)
        ' 
        ' btnConfirmar
        ' 
        btnConfirmar.Location = New Point(12, 323)
        btnConfirmar.Name = "btnConfirmar"
        btnConfirmar.Size = New Size(100, 50)
        btnConfirmar.TabIndex = 9
        btnConfirmar.Text = "Confirmar"
        btnConfirmar.UseVisualStyleBackColor = True
        ' 
        ' FrmAggPerso
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(433, 447)
        Controls.Add(btnConfirmar)
        Controls.Add(DataGridView1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtTurno)
        Controls.Add(txtRol)
        Controls.Add(txtboxContra)
        Controls.Add(txtboxusuario)
        Name = "FrmAggPerso"
        Text = "FrmAggPerso"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(ConexionBDBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtboxusuario As TextBox
    Friend WithEvents txtboxContra As TextBox
    Friend WithEvents txtRol As TextBox
    Friend WithEvents txtTurno As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ConexionBDBindingSource As BindingSource
    Friend WithEvents btnConfirmar As Button
End Class
