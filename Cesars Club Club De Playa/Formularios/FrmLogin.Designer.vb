<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Button1 = New Button()
        txtUsuario = New TextBox()
        txtContrasena = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Timer1 = New Timer(components)
        CheckBox1 = New CheckBox()
        PtbDntSeePsw = New PictureBox()
        PtbSeePsw = New PictureBox()
        lblHora = New Label()
        CType(PtbDntSeePsw, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbSeePsw, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(36, 191)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 23)
        Button1.TabIndex = 0
        Button1.Text = "Iniciar sesión"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Location = New Point(36, 48)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(120, 23)
        txtUsuario.TabIndex = 1
        ' 
        ' txtContrasena
        ' 
        txtContrasena.Location = New Point(36, 125)
        txtContrasena.Name = "txtContrasena"
        txtContrasena.PasswordChar = "*"c
        txtContrasena.Size = New Size(120, 23)
        txtContrasena.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(36, 30)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 15)
        Label1.TabIndex = 3
        Label1.Text = "Usuario"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(36, 107)
        Label2.Name = "Label2"
        Label2.Size = New Size(67, 15)
        Label2.TabIndex = 4
        Label2.Text = "Contraseña"
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 1000
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(164, 85)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(15, 14)
        CheckBox1.TabIndex = 5
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' PtbDntSeePsw
        ' 
        PtbDntSeePsw.Image = CType(resources.GetObject("PtbDntSeePsw.Image"), Image)
        PtbDntSeePsw.Location = New Point(162, 125)
        PtbDntSeePsw.Name = "PtbDntSeePsw"
        PtbDntSeePsw.Size = New Size(45, 23)
        PtbDntSeePsw.SizeMode = PictureBoxSizeMode.Zoom
        PtbDntSeePsw.TabIndex = 6
        PtbDntSeePsw.TabStop = False
        ' 
        ' PtbSeePsw
        ' 
        PtbSeePsw.Image = CType(resources.GetObject("PtbSeePsw.Image"), Image)
        PtbSeePsw.Location = New Point(162, 125)
        PtbSeePsw.Name = "PtbSeePsw"
        PtbSeePsw.Size = New Size(45, 23)
        PtbSeePsw.SizeMode = PictureBoxSizeMode.Zoom
        PtbSeePsw.TabIndex = 7
        PtbSeePsw.TabStop = False
        ' 
        ' lblHora
        ' 
        lblHora.AutoSize = True
        lblHora.Location = New Point(93, 9)
        lblHora.Name = "lblHora"
        lblHora.Size = New Size(10, 15)
        lblHora.TabIndex = 8
        lblHora.Text = " "
        ' 
        ' FrmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(210, 266)
        Controls.Add(lblHora)
        Controls.Add(PtbSeePsw)
        Controls.Add(PtbDntSeePsw)
        Controls.Add(CheckBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtContrasena)
        Controls.Add(txtUsuario)
        Controls.Add(Button1)
        Name = "FrmLogin"
        Text = "Club Playa - Acceso al Sistema v1.0"
        CType(PtbDntSeePsw, ComponentModel.ISupportInitialize).EndInit()
        CType(PtbSeePsw, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents PtbDntSeePsw As PictureBox
    Friend WithEvents PtbSeePsw As PictureBox
    Friend WithEvents lblHora As Label

End Class
