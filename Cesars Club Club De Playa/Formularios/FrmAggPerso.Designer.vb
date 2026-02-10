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
        txtboxusuario = New TextBox()
        txtboxContra = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        DgvPersonal = New DataGridView()
        btnConfirmar = New Button()
        cmbRol = New ComboBox()
        cmbTurno = New ComboBox()
        btnEdit = New Button()
        CType(DgvPersonal, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtboxusuario
        ' 
        txtboxusuario.Location = New Point(12, 104)
        txtboxusuario.Name = "txtboxusuario"
        txtboxusuario.Size = New Size(100, 23)
        txtboxusuario.TabIndex = 0
        ' 
        ' txtboxContra
        ' 
        txtboxContra.Location = New Point(12, 154)
        txtboxContra.Name = "txtboxContra"
        txtboxContra.Size = New Size(100, 23)
        txtboxContra.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label1.Location = New Point(12, 80)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 21)
        Label1.TabIndex = 4
        Label1.Text = "Usuario"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label2.Location = New Point(12, 130)
        Label2.Name = "Label2"
        Label2.Size = New Size(78, 21)
        Label2.TabIndex = 5
        Label2.Text = "Contraseña"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label3.Location = New Point(12, 180)
        Label3.Name = "Label3"
        Label3.Size = New Size(29, 21)
        Label3.TabIndex = 6
        Label3.Text = "Rol"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        Label4.Location = New Point(12, 230)
        Label4.Name = "Label4"
        Label4.Size = New Size(46, 21)
        Label4.TabIndex = 7
        Label4.Text = "Turno"
        ' 
        ' DgvPersonal
        ' 
        DgvPersonal.AllowUserToOrderColumns = True
        DgvPersonal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvPersonal.Location = New Point(144, 58)
        DgvPersonal.Name = "DgvPersonal"
        DgvPersonal.Size = New Size(277, 365)
        DgvPersonal.TabIndex = 8
        ' 
        ' btnConfirmar
        ' 
        btnConfirmar.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        btnConfirmar.Location = New Point(12, 317)
        btnConfirmar.Name = "btnConfirmar"
        btnConfirmar.Size = New Size(100, 50)
        btnConfirmar.TabIndex = 9
        btnConfirmar.Text = "Confirmar"
        btnConfirmar.UseVisualStyleBackColor = True
        ' 
        ' cmbRol
        ' 
        cmbRol.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRol.FormattingEnabled = True
        cmbRol.Location = New Point(12, 204)
        cmbRol.Name = "cmbRol"
        cmbRol.Size = New Size(100, 23)
        cmbRol.TabIndex = 10
        ' 
        ' cmbTurno
        ' 
        cmbTurno.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTurno.FormattingEnabled = True
        cmbTurno.Location = New Point(12, 254)
        cmbTurno.Name = "cmbTurno"
        cmbTurno.Size = New Size(100, 23)
        cmbTurno.TabIndex = 11
        ' 
        ' btnEdit
        ' 
        btnEdit.Font = New Font("Segoe Print", 9F, FontStyle.Bold)
        btnEdit.Location = New Point(12, 373)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(100, 50)
        btnEdit.TabIndex = 12
        btnEdit.Text = "Modificar"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' FrmAggPerso
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GradientActiveCaption
        ClientSize = New Size(433, 447)
        Controls.Add(btnEdit)
        Controls.Add(cmbTurno)
        Controls.Add(cmbRol)
        Controls.Add(btnConfirmar)
        Controls.Add(DgvPersonal)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtboxContra)
        Controls.Add(txtboxusuario)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "FrmAggPerso"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FrmAggPerso"
        CType(DgvPersonal, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtboxusuario As TextBox
    Friend WithEvents txtboxContra As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DgvPersonal As DataGridView
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents cmbRol As ComboBox
    Friend WithEvents cmbTurno As ComboBox
    Friend WithEvents btnEdit As Button
End Class
