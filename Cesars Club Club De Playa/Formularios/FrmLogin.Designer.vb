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
        PtbSeePsw = New PictureBox()
        PtbDntSeePsw = New PictureBox()
        lblHora = New Label()
        CType(PtbSeePsw, ComponentModel.ISupportInitialize).BeginInit()
        CType(PtbDntSeePsw, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.ButtonHighlight
        Button1.ForeColor = SystemColors.ActiveCaptionText
        Button1.Location = New Point(28, 243)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 23)
        Button1.TabIndex = 0
        Button1.Text = "Iniciar sesión"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Location = New Point(28, 130)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(120, 23)
        txtUsuario.TabIndex = 1
        ' 
        ' txtContrasena
        ' 
        txtContrasena.Location = New Point(28, 190)
        txtContrasena.Name = "txtContrasena"
        txtContrasena.PasswordChar = "*"c
        txtContrasena.Size = New Size(120, 23)
        txtContrasena.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.ForeColor = SystemColors.ButtonHighlight
        Label1.Location = New Point(28, 112)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 15)
        Label1.TabIndex = 3
        Label1.Text = "Usuario"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.ForeColor = SystemColors.ButtonHighlight
        Label2.Location = New Point(28, 172)
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
        ' PtbSeePsw
        ' 
        PtbSeePsw.BackColor = Color.Transparent
        PtbSeePsw.Image = CType(resources.GetObject("PtbSeePsw.Image"), Image)
        PtbSeePsw.Location = New Point(154, 190)
        PtbSeePsw.Name = "PtbSeePsw"
        PtbSeePsw.Size = New Size(61, 23)
        PtbSeePsw.SizeMode = PictureBoxSizeMode.Zoom
        PtbSeePsw.TabIndex = 6
        PtbSeePsw.TabStop = False
        ' 
        ' PtbDntSeePsw
        ' 
        PtbDntSeePsw.BackColor = Color.Transparent
        PtbDntSeePsw.Image = CType(resources.GetObject("PtbDntSeePsw.Image"), Image)
        PtbDntSeePsw.Location = New Point(154, 190)
        PtbDntSeePsw.Name = "PtbDntSeePsw"
        PtbDntSeePsw.Size = New Size(61, 23)
        PtbDntSeePsw.SizeMode = PictureBoxSizeMode.Zoom
        PtbDntSeePsw.TabIndex = 7
        PtbDntSeePsw.TabStop = False
        ' 
        ' lblHora
        ' 
        lblHora.AutoSize = True
        lblHora.BackColor = Color.Transparent
        lblHora.Location = New Point(138, 9)
        lblHora.Name = "lblHora"
        lblHora.Size = New Size(10, 15)
        lblHora.TabIndex = 8
        lblHora.Text = " "
        ' 
        ' FrmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Zoom
        ClientSize = New Size(370, 529)
        Controls.Add(PtbSeePsw)
        Controls.Add(lblHora)
        Controls.Add(PtbDntSeePsw)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtContrasena)
        Controls.Add(txtUsuario)
        Controls.Add(Button1)
        Name = "FrmLogin"
        Text = "Club Playa - Acceso al Sistema v1.0"
        CType(PtbSeePsw, ComponentModel.ISupportInitialize).EndInit()
        CType(PtbDntSeePsw, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PtbSeePsw As PictureBox
    Friend WithEvents PtbDntSeePsw As PictureBox
    Friend WithEvents lblHora As Label

End Class
