<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPedidos
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
        TxtCedulaBuscar = New TextBox()
        Label1 = New Label()
        Button1 = New Button()
        Label2 = New Label()
        NombreCliente = New TextBox()
        Label3 = New Label()
        TxtMesa = New TextBox()
        Panel1 = New Panel()
        ComboBox1 = New ComboBox()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TxtCedulaBuscar
        ' 
        TxtCedulaBuscar.Location = New Point(12, 35)
        TxtCedulaBuscar.Name = "TxtCedulaBuscar"
        TxtCedulaBuscar.Size = New Size(100, 23)
        TxtCedulaBuscar.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 17)
        Label1.Name = "Label1"
        Label1.Size = New Size(44, 15)
        Label1.TabIndex = 1
        Label1.Text = "Cedula"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(12, 110)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 2
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 63)
        Label2.Name = "Label2"
        Label2.Size = New Size(51, 15)
        Label2.TabIndex = 4
        Label2.Text = "Nombre"
        ' 
        ' NombreCliente
        ' 
        NombreCliente.Location = New Point(12, 81)
        NombreCliente.Name = "NombreCliente"
        NombreCliente.Size = New Size(100, 23)
        NombreCliente.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(118, 43)
        Label3.Name = "Label3"
        Label3.Size = New Size(98, 15)
        Label3.TabIndex = 6
        Label3.Text = "Numero de Mesa"
        ' 
        ' TxtMesa
        ' 
        TxtMesa.Location = New Point(145, 63)
        TxtMesa.Name = "TxtMesa"
        TxtMesa.Size = New Size(44, 23)
        TxtMesa.TabIndex = 5
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(ComboBox1)
        Panel1.Location = New Point(12, 153)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(200, 276)
        Panel1.TabIndex = 7
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(3, 18)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(121, 23)
        ComboBox1.TabIndex = 8
        ' 
        ' FrmPedidos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(686, 624)
        Controls.Add(Panel1)
        Controls.Add(Label3)
        Controls.Add(TxtMesa)
        Controls.Add(Label2)
        Controls.Add(NombreCliente)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(TxtCedulaBuscar)
        Name = "FrmPedidos"
        Text = "FrmPedidos"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtCedulaBuscar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents NombreCliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtMesa As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ComboBox1 As ComboBox
End Class
