Imports System.Data.OleDb

Public Class FrmFactura

    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

    Private cedulaCliente As String = ""
    Private idReserva As Integer = 0
    Private totalPedidos As Decimal = 0
    Private totalZona As Decimal = 0
    Private totalGeneral As Decimal = 0

    Private Sub FrmFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarFormulario()
    End Sub

    Private Sub InicializarFormulario()
        Try
            ' Configurar DataGridView de pedidos
            ConfigurarDGVPedidos()

            ' Estado inicial
            PnlDetalles.Enabled = False
            BtnGenerarFactura.Enabled = False

            LimpiarTotales()
            TxtCedula.Focus()

        Catch ex As Exception
            MessageBox.Show("Error al inicializar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurarDGVPedidos()
        DgvPedidos.Columns.Clear()
        DgvPedidos.Columns.Add("ID_Pedido", "#Pedido")
        DgvPedidos.Columns.Add("FechaHora", "Fecha/Hora")
        DgvPedidos.Columns.Add("Total", "Total")
        DgvPedidos.Columns.Add("Estado", "Estado")

        DgvPedidos.Columns("ID_Pedido").Width = 80
        DgvPedidos.Columns("FechaHora").Width = 140
        DgvPedidos.Columns("Total").Width = 100
        DgvPedidos.Columns("Estado").Width = 100

        DgvPedidos.Columns("Total").DefaultCellStyle.Format = "C2"
        DgvPedidos.Columns("FechaHora").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

        DgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DgvPedidos.ReadOnly = True
        DgvPedidos.AllowUserToAddRows = False
        DgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub BtnBuscarCliente_Click(sender As Object, e As EventArgs) Handles BtnBuscarCliente.Click
        BuscarCliente()
    End Sub

    Private Sub TxtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCedula.KeyPress
        If e.KeyChar = Chr(13) Then
            BuscarCliente()
            e.Handled = True
        End If
    End Sub

    Private Sub BuscarCliente()
        If String.IsNullOrWhiteSpace(TxtCedula.Text) Then
            MessageBox.Show("Por favor ingrese una cédula", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtCedula.Focus()
            Return
        End If

        cedulaCliente = TxtCedula.Text.Trim()

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                ' Buscar cliente
                Dim queryCliente As String = "SELECT NombreComp FROM Clientes WHERE Cedula = ?"
                Dim nombreCliente As String = ""

                Using cmdCliente As New OleDbCommand(queryCliente, conexion)
                    cmdCliente.Parameters.Add("?", OleDbType.VarChar).Value = cedulaCliente
                    Dim resultado As Object = cmdCliente.ExecuteScalar()

                    If resultado Is Nothing Then
                        MessageBox.Show("Cliente no encontrado. Verifique la cédula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        LimpiarFormulario()
                        Return
                    End If

                    nombreCliente = resultado.ToString()
                End Using

                ' Buscar reserva activa
                Dim queryReserva As String = "SELECT ID_Reserva, ID_Mesa, Horainicio, Horafin FROM Reservas WHERE Cedula = ? AND EstadoReserva = ?"

                Using cmdReserva As New OleDbCommand(queryReserva, conexion)
                    cmdReserva.Parameters.Add("?", OleDbType.VarChar).Value = cedulaCliente
                    cmdReserva.Parameters.Add("?", OleDbType.VarChar).Value = "Activa"

                    Using reader As OleDbDataReader = cmdReserva.ExecuteReader()
                        If reader.Read() Then
                            idReserva = CInt(reader("ID_Reserva"))
                            Dim idMesa As Integer = CInt(reader("ID_Mesa"))
                            Dim horaInicio As DateTime = CDate(reader("Horainicio"))
                            Dim horaFin As DateTime = CDate(reader("Horafin"))

                            ' Mostrar información del cliente
                            TxtNombreCliente.Text = nombreCliente
                            TxtMesa.Text = "Mesa #" & idMesa.ToString()
                            TxtHoraInicio.Text = horaInicio.ToString("hh:mm tt")
                            TxtHoraFin.Text = horaFin.ToString("hh:mm tt")

                            ' Calcular horas
                            Dim duracion As TimeSpan = horaFin - horaInicio
                            Dim totalHoras As Decimal = CDec(duracion.TotalHours)
                            TxtHorasTotales.Text = totalHoras.ToString("F2") & " hrs"

                            ' Obtener precio por hora de la zona/mesa
                            Dim precioHora As Decimal = ObtenerPrecioZona(idMesa, conexion)
                            TxtPrecioHora.Text = precioHora.ToString("C2")

                            ' Calcular total de zona
                            totalZona = precioHora * totalHoras
                            TxtTotalZona.Text = totalZona.ToString("C2")
                            TxtTotalZone.Text = totalZona.ToString("C2")

                            ' Habilitar panel
                            PnlDetalles.Enabled = True
                            BtnGenerarFactura.Enabled = True

                            ' Cargar pedidos
                            CargarPedidos()

                            MessageBox.Show($"Cliente encontrado: {nombreCliente}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Else
                            MessageBox.Show("Este cliente no tiene una reserva activa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            LimpiarFormulario()
                            Return
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error al buscar cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Function ObtenerPrecioZona(idMesa As Integer, conexion As OleDbConnection) As Decimal
        Try
            Dim query As String = "SELECT PrecioHora, ConsumoMin FROM Zonas WHERE ID_Mesa = ?"

            Using cmd As New OleDbCommand(query, conexion)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = idMesa

                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim precioHora As Decimal = 0
                        Dim consumoMin As Decimal = 0

                        If Not IsDBNull(reader("PrecioHora")) Then
                            precioHora = CDec(reader("PrecioHora"))
                        End If

                        If Not IsDBNull(reader("ConsumoMin")) Then
                            consumoMin = CDec(reader("ConsumoMin"))
                            TxtConsumoMinimo.Text = consumoMin.ToString("C2")
                        Else
                            TxtConsumoMinimo.Text = "S/ 0.00"
                        End If

                        Return precioHora
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al obtener precio de zona: " & ex.Message)
        End Try

        Return 0
    End Function

    Private Sub CargarPedidos()
        DgvPedidos.Rows.Clear()
        totalPedidos = 0

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                ' Obtener todos los pedidos del cliente (pendientes o listos, no pagados)
                Dim query As String = "SELECT ID_Pedido, FechaHora, Total, Estado " &
                                     "FROM Pedidos " &
                                     "WHERE Cedula = ? AND Estado <> ? " &
                                     "ORDER BY FechaHora"

                Using comando As New OleDbCommand(query, conexion)
                    comando.Parameters.Add("?", OleDbType.VarChar).Value = cedulaCliente
                    comando.Parameters.Add("?", OleDbType.VarChar).Value = "Pagado"

                    Using reader As OleDbDataReader = comando.ExecuteReader()
                        While reader.Read()
                            Dim total As Decimal = CDec(reader("Total"))
                            totalPedidos += total

                            DgvPedidos.Rows.Add(
                                reader("ID_Pedido"),
                                CDate(reader("FechaHora")),
                                total,
                                reader("Estado")
                            )
                        End While
                    End Using
                End Using

                ' Mostrar totales
                TxtTotalPedidos.Text = totalPedidos.ToString("C2")
                CalcularTotalGeneral()

            Catch ex As Exception
                MessageBox.Show("Error al cargar pedidos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub CalcularTotalGeneral()
        ' Verificar consumo mínimo
        Dim consumoMinimo As Decimal = 0
        If Not String.IsNullOrEmpty(TxtConsumoMinimo.Text) Then
            consumoMinimo = CDec(TxtConsumoMinimo.Text.Replace("S/", "").Replace("$", "").Trim())
        End If

        totalGeneral = totalPedidos + totalZona

        ' Aplicar consumo mínimo si es mayor
        If consumoMinimo > totalPedidos Then
            Dim diferencia As Decimal = consumoMinimo - totalPedidos
            totalGeneral += diferencia
            LblConsumoMinimo.Text = $"* Se aplicó consumo mínimo: {diferencia.ToString("C2")}"
            LblConsumoMinimo.Visible = True
        Else
            LblConsumoMinimo.Visible = False
        End If

        TxtTotalGeneral.Text = totalGeneral.ToString("C2")
    End Sub

    Private Sub BtnGenerarFactura_Click(sender As Object, e As EventArgs) Handles BtnGenerarFactura.Click
        GenerarFactura()
    End Sub

    Private Sub GenerarFactura()
        If String.IsNullOrEmpty(cedulaCliente) Then
            MessageBox.Show("Debe buscar un cliente primero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Calcular impuestos
        Dim subtotal As Decimal = totalGeneral
        Dim descuento As Decimal = 0
        Dim iva As Decimal = subtotal * 0.15D ' 15% IVA
        Dim propina As Decimal = 0

        ' Preguntar por propina (opcional)
        Dim respuestaPropina As String = InputBox("¿Desea agregar propina? (Ingrese el porcentaje, ej: 10 para 10%)", "Propina", "0")

        If Not String.IsNullOrEmpty(respuestaPropina) AndAlso IsNumeric(respuestaPropina) Then
            Dim porcentajePropina As Decimal = CDec(respuestaPropina) / 100
            propina = subtotal * porcentajePropina
        End If

        Dim totalFinal As Decimal = subtotal + iva + propina - descuento

        ' Confirmar
        Dim mensaje As String = $"RESUMEN DE FACTURA" & vbCrLf & vbCrLf &
                               $"Cliente: {TxtNombreCliente.Text}" & vbCrLf &
                               $"Cédula: {cedulaCliente}" & vbCrLf &
                               $"Mesa: {TxtMesa.Text}" & vbCrLf & vbCrLf &
                               $"Subtotal: {subtotal.ToString("C2")}" & vbCrLf &
                               $"Descuento: {descuento.ToString("C2")}" & vbCrLf &
                               $"IVA (18%): {iva.ToString("C2")}" & vbCrLf &
                               $"Propina: {propina.ToString("C2")}" & vbCrLf & vbCrLf &
                               $"TOTAL: {totalFinal.ToString("C2")}" & vbCrLf & vbCrLf &
                               "¿Confirmar y generar factura?"

        Dim respuesta As DialogResult = MessageBox.Show(mensaje, "Confirmar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = DialogResult.No Then
            Return
        End If

        Using conexion As New OleDbConnection(connectionString)
            conexion.Open()
            Dim transaction As OleDbTransaction = conexion.BeginTransaction()

            Try
                ' Insertar factura
                Dim queryFactura As String = "INSERT INTO Factura (NumeroFactura, Subtotal, Descuento, IVA, Propina, Total, FormaPago, ID_Cajero, EstadoPago) " &
                                            "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"

                Dim numeroFactura As String = GenerarNumeroFactura()

                Using cmdFactura As New OleDbCommand(queryFactura, conexion, transaction)
                    cmdFactura.Parameters.Add("?", OleDbType.VarChar).Value = numeroFactura
                    cmdFactura.Parameters.Add("?", OleDbType.Currency).Value = subtotal
                    cmdFactura.Parameters.Add("?", OleDbType.Currency).Value = descuento
                    cmdFactura.Parameters.Add("?", OleDbType.Currency).Value = iva
                    cmdFactura.Parameters.Add("?", OleDbType.Currency).Value = propina
                    cmdFactura.Parameters.Add("?", OleDbType.Currency).Value = totalFinal
                    cmdFactura.Parameters.Add("?", OleDbType.VarChar).Value = "Efectivo" ' Puedes agregar ComboBox
                    cmdFactura.Parameters.Add("?", OleDbType.Integer).Value = 1 ' ID del cajero (ajustar según tu sistema)
                    cmdFactura.Parameters.Add("?", OleDbType.VarChar).Value = "Pagada"

                    cmdFactura.ExecuteNonQuery()
                End Using

                ' Marcar todos los pedidos como pagados
                Dim queryPedidos As String = "UPDATE Pedidos SET Estado = ? WHERE Cedula = ? AND Estado <> ?"

                Using cmdPedidos As New OleDbCommand(queryPedidos, conexion, transaction)
                    cmdPedidos.Parameters.Add("?", OleDbType.VarChar).Value = "Pagado"
                    cmdPedidos.Parameters.Add("?", OleDbType.VarChar).Value = cedulaCliente
                    cmdPedidos.Parameters.Add("?", OleDbType.VarChar).Value = "Pagado"

                    cmdPedidos.ExecuteNonQuery()
                End Using

                ' Marcar reserva como finalizada
                Dim queryReserva As String = "UPDATE Reservas SET EstadoReserva = ? WHERE ID_Reserva = ?"

                Using cmdReserva As New OleDbCommand(queryReserva, conexion, transaction)
                    cmdReserva.Parameters.Add("?", OleDbType.VarChar).Value = "Finalizada"
                    cmdReserva.Parameters.Add("?", OleDbType.Integer).Value = idReserva

                    cmdReserva.ExecuteNonQuery()
                End Using

                ' Liberar mesa
                Dim idMesa As Integer = CInt(TxtMesa.Text.Replace("Mesa #", ""))
                Dim queryMesa As String = "UPDATE Zonas SET Estado = ? WHERE ID_Mesa = ?"

                Using cmdMesa As New OleDbCommand(queryMesa, conexion, transaction)
                    cmdMesa.Parameters.Add("?", OleDbType.VarChar).Value = "Disponible"
                    cmdMesa.Parameters.Add("?", OleDbType.Integer).Value = idMesa

                    cmdMesa.ExecuteNonQuery()
                End Using

                transaction.Commit()

                MessageBox.Show($"Factura generada exitosamente!" & vbCrLf & vbCrLf &
                               $"Número de factura: {numeroFactura}" & vbCrLf &
                               $"Total: {totalFinal.ToString("C2")}",
                               "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Limpiar formulario
                LimpiarFormulario()

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error al generar factura: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Function GenerarNumeroFactura() As String
        ' Formato: FACT-001-2026 (ajustar según tu necesidad)
        Dim año As String = DateTime.Now.Year.ToString()
        Dim numero As Integer = 1

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()
                Dim query As String = "SELECT MAX(ID_Facturas) FROM Factura"
                Dim cmd As New OleDbCommand(query, conexion)
                Dim resultado As Object = cmd.ExecuteScalar()

                If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                    numero = CInt(resultado) + 1
                End If

            Catch ex As Exception
                ' Si falla, usar timestamp
                numero = CInt(DateTime.Now.ToString("HHmmss"))
            End Try
        End Using

        Return $"FACT-{numero.ToString("000")}-{año}"
    End Function

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        LimpiarFormulario()
    End Sub

    Private Sub LimpiarFormulario()
        TxtCedula.Clear()
        TxtNombreCliente.Clear()
        TxtMesa.Clear()
        TxtHoraInicio.Clear()
        TxtHoraFin.Clear()
        TxtHorasTotales.Clear()
        TxtPrecioHora.Clear()
        TxtConsumoMinimo.Clear()
        TxtTotalZone.Clear()

        DgvPedidos.Rows.Clear()
        LimpiarTotales()

        cedulaCliente = ""
        idReserva = 0

        PnlDetalles.Enabled = False
        BtnGenerarFactura.Enabled = False
        LblConsumoMinimo.Visible = False

        TxtCedula.Focus()
    End Sub

    Private Sub LimpiarTotales()
        totalPedidos = 0
        totalZona = 0
        totalGeneral = 0

        TxtTotalPedidos.Text = "S/ 0.00"
        TxtTotalZona.Text = "S/ 0.00"
        TxtTotalGeneral.Text = "S/ 0.00"
    End Sub
End Class