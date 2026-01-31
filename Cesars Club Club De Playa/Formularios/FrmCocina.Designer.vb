<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCocina
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
        CboEstado = New ComboBox()
        BtnActualizar = New Button()
        DgvPedidos = New DataGridView()
        LblNumPedido = New Label()
        LblCliente = New Label()
        LblMesa = New Label()
        LblFechaHora = New Label()
        LblTotal = New Label()
        DgvDetalle = New DataGridView()
        TxtComentarios = New TextBox()
        BtnIniciarPreparacion = New Button()
        BtnMarcarListo = New Button()
        LblComent = New Label()
        TimerActualizacion = New Timer(components)
        CType(DgvPedidos, ComponentModel.ISupportInitialize).BeginInit()
        CType(DgvDetalle, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' CboEstado
        ' 
        CboEstado.DropDownStyle = ComboBoxStyle.DropDownList
        CboEstado.FormattingEnabled = True
        CboEstado.Location = New Point(12, 12)
        CboEstado.Name = "CboEstado"
        CboEstado.Size = New Size(167, 23)
        CboEstado.TabIndex = 0
        ' 
        ' BtnActualizar
        ' 
        BtnActualizar.Location = New Point(185, 12)
        BtnActualizar.Name = "BtnActualizar"
        BtnActualizar.Size = New Size(75, 23)
        BtnActualizar.TabIndex = 1
        BtnActualizar.Text = "Actualizar"
        BtnActualizar.UseVisualStyleBackColor = True
        ' 
        ' DgvPedidos
        ' 
        DgvPedidos.AllowUserToAddRows = False
        DgvPedidos.BorderStyle = BorderStyle.Fixed3D
        DgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvPedidos.Location = New Point(12, 97)
        DgvPedidos.MultiSelect = False
        DgvPedidos.Name = "DgvPedidos"
        DgvPedidos.ReadOnly = True
        DgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvPedidos.Size = New Size(248, 321)
        DgvPedidos.TabIndex = 2
        ' 
        ' LblNumPedido
        ' 
        LblNumPedido.AutoSize = True
        LblNumPedido.Font = New Font("Segoe UI", 14F)
        LblNumPedido.Location = New Point(305, 97)
        LblNumPedido.Name = "LblNumPedido"
        LblNumPedido.Size = New Size(194, 25)
        LblNumPedido.TabIndex = 3
        LblNumPedido.Text = "Seleccione Un Pedido"
        ' 
        ' LblCliente
        ' 
        LblCliente.AutoSize = True
        LblCliente.Font = New Font("Segoe UI", 11F)
        LblCliente.Location = New Point(275, 136)
        LblCliente.Name = "LblCliente"
        LblCliente.Size = New Size(55, 20)
        LblCliente.TabIndex = 4
        LblCliente.Text = "Cliente"
        ' 
        ' LblMesa
        ' 
        LblMesa.AutoSize = True
        LblMesa.Font = New Font("Segoe UI", 11F)
        LblMesa.Location = New Point(275, 165)
        LblMesa.Name = "LblMesa"
        LblMesa.Size = New Size(44, 20)
        LblMesa.TabIndex = 5
        LblMesa.Text = "Mesa"
        ' 
        ' LblFechaHora
        ' 
        LblFechaHora.AutoSize = True
        LblFechaHora.Font = New Font("Segoe UI", 10F)
        LblFechaHora.Location = New Point(275, 195)
        LblFechaHora.Name = "LblFechaHora"
        LblFechaHora.Size = New Size(39, 19)
        LblFechaHora.TabIndex = 6
        LblFechaHora.Text = "Hora"
        ' 
        ' LblTotal
        ' 
        LblTotal.AutoSize = True
        LblTotal.Font = New Font("Segoe UI", 16F)
        LblTotal.Location = New Point(275, 388)
        LblTotal.Name = "LblTotal"
        LblTotal.Size = New Size(138, 30)
        LblTotal.TabIndex = 7
        LblTotal.Text = "Total: S/ 0.00"
        ' 
        ' DgvDetalle
        ' 
        DgvDetalle.AllowUserToAddRows = False
        DgvDetalle.BorderStyle = BorderStyle.Fixed3D
        DgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDetalle.Location = New Point(540, 97)
        DgvDetalle.MultiSelect = False
        DgvDetalle.Name = "DgvDetalle"
        DgvDetalle.ReadOnly = True
        DgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvDetalle.Size = New Size(248, 321)
        DgvDetalle.TabIndex = 8
        ' 
        ' TxtComentarios
        ' 
        TxtComentarios.Font = New Font("Segoe UI", 10F)
        TxtComentarios.Location = New Point(275, 297)
        TxtComentarios.Multiline = True
        TxtComentarios.Name = "TxtComentarios"
        TxtComentarios.ReadOnly = True
        TxtComentarios.ScrollBars = ScrollBars.Vertical
        TxtComentarios.Size = New Size(205, 26)
        TxtComentarios.TabIndex = 9
        ' 
        ' BtnIniciarPreparacion
        ' 
        BtnIniciarPreparacion.Location = New Point(12, 424)
        BtnIniciarPreparacion.Name = "BtnIniciarPreparacion"
        BtnIniciarPreparacion.Size = New Size(120, 23)
        BtnIniciarPreparacion.TabIndex = 10
        BtnIniciarPreparacion.Text = "Iniciar Preparacion"
        BtnIniciarPreparacion.UseVisualStyleBackColor = True
        ' 
        ' BtnMarcarListo
        ' 
        BtnMarcarListo.Location = New Point(140, 424)
        BtnMarcarListo.Name = "BtnMarcarListo"
        BtnMarcarListo.Size = New Size(120, 23)
        BtnMarcarListo.TabIndex = 11
        BtnMarcarListo.Text = "Marcar Como Listo"
        BtnMarcarListo.UseVisualStyleBackColor = True
        ' 
        ' LblComent
        ' 
        LblComent.AutoSize = True
        LblComent.Font = New Font("Segoe UI", 10F)
        LblComent.Location = New Point(275, 275)
        LblComent.Name = "LblComent"
        LblComent.Size = New Size(90, 19)
        LblComent.TabIndex = 12
        LblComent.Text = "Comentarios:"
        ' 
        ' TimerActualizacion
        ' 
        TimerActualizacion.Enabled = True
        TimerActualizacion.Interval = 30000
        ' 
        ' FrmCocina
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(LblComent)
        Controls.Add(BtnMarcarListo)
        Controls.Add(BtnIniciarPreparacion)
        Controls.Add(TxtComentarios)
        Controls.Add(DgvDetalle)
        Controls.Add(LblTotal)
        Controls.Add(LblFechaHora)
        Controls.Add(LblMesa)
        Controls.Add(LblCliente)
        Controls.Add(LblNumPedido)
        Controls.Add(DgvPedidos)
        Controls.Add(BtnActualizar)
        Controls.Add(CboEstado)
        Name = "FrmCocina"
        Text = "FrmCocina"
        CType(DgvPedidos, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvDetalle, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CboEstado As ComboBox
    Friend WithEvents BtnActualizar As Button
    Friend WithEvents DgvPedidos As DataGridView
    Friend WithEvents LblNumPedido As Label
    Friend WithEvents LblCliente As Label
    Friend WithEvents LblMesa As Label
    Friend WithEvents LblFechaHora As Label
    Friend WithEvents LblTotal As Label
    Friend WithEvents DgvDetalle As DataGridView
    Friend WithEvents TxtComentarios As TextBox
    Friend WithEvents BtnIniciarPreparacion As Button
    Friend WithEvents BtnMarcarListo As Button
    Friend WithEvents LblComent As Label
    Friend WithEvents TimerActualizacion As Timer
End Class
