<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFactura
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
        TxtCedula = New TextBox()
        TxtNombreCliente = New TextBox()
        BtnBuscarCliente = New Button()
        PnlDetalles = New Panel()
        DgvPedidos = New DataGridView()
        TxtConsumoMinimo = New TextBox()
        TxtTotalZona = New TextBox()
        TxtPrecioHora = New TextBox()
        Label3 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        TxtHorasTotales = New TextBox()
        TxtHoraFin = New TextBox()
        TxtHoraInicio = New TextBox()
        TxtMesa = New TextBox()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Mesa = New Label()
        TxtTotalPedidos = New TextBox()
        TotalZone = New TextBox()
        TxtTotalGeneral = New TextBox()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        LblConsumoMinimo = New Label()
        BtnGenerarFactura = New Button()
        BtnLimpiar = New Button()
        Label12 = New Label()
        PnlDetalles.SuspendLayout()
        CType(DgvPedidos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(50, 15)
        Label1.TabIndex = 0
        Label1.Text = "Cedula: "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 64)
        Label2.Name = "Label2"
        Label2.Size = New Size(57, 15)
        Label2.TabIndex = 1
        Label2.Text = "Nombre: "
        ' 
        ' TxtCedula
        ' 
        TxtCedula.Location = New Point(12, 27)
        TxtCedula.Name = "TxtCedula"
        TxtCedula.Size = New Size(100, 23)
        TxtCedula.TabIndex = 2
        ' 
        ' TxtNombreCliente
        ' 
        TxtNombreCliente.Location = New Point(12, 82)
        TxtNombreCliente.Name = "TxtNombreCliente"
        TxtNombreCliente.ReadOnly = True
        TxtNombreCliente.Size = New Size(100, 23)
        TxtNombreCliente.TabIndex = 3
        ' 
        ' BtnBuscarCliente
        ' 
        BtnBuscarCliente.Location = New Point(109, 53)
        BtnBuscarCliente.Name = "BtnBuscarCliente"
        BtnBuscarCliente.Size = New Size(75, 23)
        BtnBuscarCliente.TabIndex = 4
        BtnBuscarCliente.Text = "Buscar"
        BtnBuscarCliente.UseVisualStyleBackColor = True
        ' 
        ' PnlDetalles
        ' 
        PnlDetalles.Controls.Add(DgvPedidos)
        PnlDetalles.Controls.Add(TxtConsumoMinimo)
        PnlDetalles.Controls.Add(TxtTotalZona)
        PnlDetalles.Controls.Add(TxtPrecioHora)
        PnlDetalles.Controls.Add(Label3)
        PnlDetalles.Controls.Add(Label7)
        PnlDetalles.Controls.Add(Label8)
        PnlDetalles.Controls.Add(TxtHorasTotales)
        PnlDetalles.Controls.Add(TxtHoraFin)
        PnlDetalles.Controls.Add(TxtHoraInicio)
        PnlDetalles.Controls.Add(TxtMesa)
        PnlDetalles.Controls.Add(Label6)
        PnlDetalles.Controls.Add(Label5)
        PnlDetalles.Controls.Add(Label4)
        PnlDetalles.Controls.Add(Mesa)
        PnlDetalles.Location = New Point(12, 145)
        PnlDetalles.Name = "PnlDetalles"
        PnlDetalles.Size = New Size(549, 373)
        PnlDetalles.TabIndex = 5
        ' 
        ' DgvPedidos
        ' 
        DgvPedidos.AllowUserToAddRows = False
        DgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvPedidos.Location = New Point(3, 172)
        DgvPedidos.Name = "DgvPedidos"
        DgvPedidos.ReadOnly = True
        DgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvPedidos.Size = New Size(543, 199)
        DgvPedidos.TabIndex = 19
        ' 
        ' TxtConsumoMinimo
        ' 
        TxtConsumoMinimo.Location = New Point(383, 83)
        TxtConsumoMinimo.Name = "TxtConsumoMinimo"
        TxtConsumoMinimo.ReadOnly = True
        TxtConsumoMinimo.Size = New Size(100, 23)
        TxtConsumoMinimo.TabIndex = 18
        ' 
        ' TxtTotalZona
        ' 
        TxtTotalZona.Location = New Point(383, 53)
        TxtTotalZona.Name = "TxtTotalZona"
        TxtTotalZona.ReadOnly = True
        TxtTotalZona.Size = New Size(100, 23)
        TxtTotalZona.TabIndex = 17
        ' 
        ' TxtPrecioHora
        ' 
        TxtPrecioHora.Location = New Point(383, 21)
        TxtPrecioHora.Name = "TxtPrecioHora"
        TxtPrecioHora.ReadOnly = True
        TxtPrecioHora.Size = New Size(100, 23)
        TxtPrecioHora.TabIndex = 16
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(273, 88)
        Label3.Name = "Label3"
        Label3.Size = New Size(104, 15)
        Label3.TabIndex = 15
        Label3.Text = "Consumo Minimo"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(307, 56)
        Label7.Name = "Label7"
        Label7.Size = New Size(63, 15)
        Label7.TabIndex = 14
        Label7.Text = "Total Zona"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(301, 24)
        Label8.Name = "Label8"
        Label8.Size = New Size(69, 15)
        Label8.TabIndex = 13
        Label8.Text = "Precio Hora"
        ' 
        ' TxtHorasTotales
        ' 
        TxtHorasTotales.Location = New Point(85, 115)
        TxtHorasTotales.Name = "TxtHorasTotales"
        TxtHorasTotales.ReadOnly = True
        TxtHorasTotales.Size = New Size(100, 23)
        TxtHorasTotales.TabIndex = 12
        ' 
        ' TxtHoraFin
        ' 
        TxtHoraFin.Location = New Point(85, 85)
        TxtHoraFin.Name = "TxtHoraFin"
        TxtHoraFin.ReadOnly = True
        TxtHoraFin.Size = New Size(100, 23)
        TxtHoraFin.TabIndex = 11
        ' 
        ' TxtHoraInicio
        ' 
        TxtHoraInicio.Location = New Point(85, 53)
        TxtHoraInicio.Name = "TxtHoraInicio"
        TxtHoraInicio.ReadOnly = True
        TxtHoraInicio.Size = New Size(100, 23)
        TxtHoraInicio.TabIndex = 10
        ' 
        ' TxtMesa
        ' 
        TxtMesa.Location = New Point(85, 16)
        TxtMesa.Name = "TxtMesa"
        TxtMesa.ReadOnly = True
        TxtMesa.Size = New Size(100, 23)
        TxtMesa.TabIndex = 6
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(3, 118)
        Label6.Name = "Label6"
        Label6.Size = New Size(78, 15)
        Label6.TabIndex = 9
        Label6.Text = "Horas Totales"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(3, 85)
        Label5.Name = "Label5"
        Label5.Size = New Size(52, 15)
        Label5.TabIndex = 8
        Label5.Text = "Hora Fin"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(3, 53)
        Label4.Name = "Label4"
        Label4.Size = New Size(65, 15)
        Label4.TabIndex = 7
        Label4.Text = "Hora Inicio"
        ' 
        ' Mesa
        ' 
        Mesa.AutoSize = True
        Mesa.Location = New Point(3, 24)
        Mesa.Name = "Mesa"
        Mesa.Size = New Size(35, 15)
        Mesa.TabIndex = 6
        Mesa.Text = "Mesa"
        ' 
        ' TxtTotalPedidos
        ' 
        TxtTotalPedidos.Location = New Point(97, 540)
        TxtTotalPedidos.Name = "TxtTotalPedidos"
        TxtTotalPedidos.ReadOnly = True
        TxtTotalPedidos.Size = New Size(100, 23)
        TxtTotalPedidos.TabIndex = 20
        ' 
        ' TotalZone
        ' 
        TotalZone.Location = New Point(97, 569)
        TotalZone.Name = "TotalZone"
        TotalZone.ReadOnly = True
        TotalZone.Size = New Size(100, 23)
        TotalZone.TabIndex = 21
        ' 
        ' TxtTotalGeneral
        ' 
        TxtTotalGeneral.Location = New Point(97, 598)
        TxtTotalGeneral.Name = "TxtTotalGeneral"
        TxtTotalGeneral.ReadOnly = True
        TxtTotalGeneral.Size = New Size(100, 23)
        TxtTotalGeneral.TabIndex = 22
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(15, 601)
        Label9.Name = "Label9"
        Label9.Size = New Size(76, 15)
        Label9.TabIndex = 22
        Label9.Text = "Total General"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(17, 572)
        Label10.Name = "Label10"
        Label10.Size = New Size(63, 15)
        Label10.TabIndex = 21
        Label10.Text = "Total Zona"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(15, 543)
        Label11.Name = "Label11"
        Label11.Size = New Size(78, 15)
        Label11.TabIndex = 20
        Label11.Text = "Total Pedidos"
        ' 
        ' LblConsumoMinimo
        ' 
        LblConsumoMinimo.AutoSize = True
        LblConsumoMinimo.ForeColor = Color.Red
        LblConsumoMinimo.Location = New Point(339, 606)
        LblConsumoMinimo.Name = "LblConsumoMinimo"
        LblConsumoMinimo.Size = New Size(26, 15)
        LblConsumoMinimo.TabIndex = 23
        LblConsumoMinimo.Text = "CM"
        LblConsumoMinimo.Visible = False
        ' 
        ' BtnGenerarFactura
        ' 
        BtnGenerarFactura.Location = New Point(12, 662)
        BtnGenerarFactura.Name = "BtnGenerarFactura"
        BtnGenerarFactura.Size = New Size(100, 23)
        BtnGenerarFactura.TabIndex = 24
        BtnGenerarFactura.Text = "Generar Factura"
        BtnGenerarFactura.UseVisualStyleBackColor = True
        ' 
        ' BtnLimpiar
        ' 
        BtnLimpiar.Location = New Point(486, 662)
        BtnLimpiar.Name = "BtnLimpiar"
        BtnLimpiar.Size = New Size(75, 23)
        BtnLimpiar.TabIndex = 25
        BtnLimpiar.Text = "Limpiar"
        BtnLimpiar.UseVisualStyleBackColor = True
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(226, 606)
        Label12.Name = "Label12"
        Label12.Size = New Size(107, 15)
        Label12.TabIndex = 26
        Label12.Text = "Consumo Minimo:"
        ' 
        ' FrmFactura
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(573, 687)
        Controls.Add(Label12)
        Controls.Add(BtnLimpiar)
        Controls.Add(BtnGenerarFactura)
        Controls.Add(LblConsumoMinimo)
        Controls.Add(Label9)
        Controls.Add(TxtTotalGeneral)
        Controls.Add(Label10)
        Controls.Add(PnlDetalles)
        Controls.Add(Label11)
        Controls.Add(TotalZone)
        Controls.Add(BtnBuscarCliente)
        Controls.Add(TxtTotalPedidos)
        Controls.Add(TxtNombreCliente)
        Controls.Add(TxtCedula)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "FrmFactura"
        Text = "FrmFactura"
        PnlDetalles.ResumeLayout(False)
        PnlDetalles.PerformLayout()
        CType(DgvPedidos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCedula As TextBox
    Friend WithEvents TxtNombreCliente As TextBox
    Friend WithEvents BtnBuscarCliente As Button
    Friend WithEvents PnlDetalles As Panel
    Friend WithEvents TxtHoraInicio As TextBox
    Friend WithEvents TxtMesa As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Mesa As Label
    Friend WithEvents TxtHorasTotales As TextBox
    Friend WithEvents TxtHoraFin As TextBox
    Friend WithEvents TxtConsumoMinimo As TextBox
    Friend WithEvents TxtTotalZona As TextBox
    Friend WithEvents TxtPrecioHora As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents DgvPedidos As DataGridView
    Friend WithEvents TxtTotalPedidos As TextBox
    Friend WithEvents TotalZone As TextBox
    Friend WithEvents TxtTotalGeneral As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LblConsumoMinimo As Label
    Friend WithEvents BtnGenerarFactura As Button
    Friend WithEvents BtnLimpiar As Button
    Friend WithEvents Label12 As Label
End Class
