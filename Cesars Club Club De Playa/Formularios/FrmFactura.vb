Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmFactura

    Private cedulaCliente As String = ""
    Private idReserva As Integer = 0
    Private totalPedidos As Decimal = 0
    Private totalZona As Decimal = 0
    Private totalGeneral As Decimal = 0

    Private Sub FrmFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarFormulario()
    End Sub

    'Este código se encarga de inicializar el formulario de facturación, configurando el DataGridView para mostrar los pedidos, estableciendo el estado inicial de los controles, y preparando el formulario para la búsqueda de clientes y generación de facturas.
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
    'Esta función se encarga de configurar el DataGridView que muestra los pedidos asociados a la reserva del cliente. Define las columnas, sus anchos, formatos y propiedades para asegurar una presentación clara y funcional de los datos.
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

    'Este código se encarga de manejar el evento de clic en el botón "Buscar Cliente" y la tecla Enter en el campo de cédula para iniciar la búsqueda del cliente en la base de datos. Llama a la función BuscarCliente() que realiza la consulta y muestra los detalles del cliente, su reserva activa, y los pedidos asociados.
    Private Sub BtnBuscarCliente_Click(sender As Object, e As EventArgs) Handles BtnBuscarCliente.Click
        BuscarCliente()
    End Sub

    Private Sub TxtCedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCedula.KeyPress
        If e.KeyChar = Chr(13) Then
            BuscarCliente()
            e.Handled = True
        End If
    End Sub

    'Esta función se encarga de buscar un cliente en la base de datos utilizando la cédula ingresada. Si el cliente existe y tiene una reserva activa, muestra los detalles del cliente, la mesa asignada, las horas de reserva, el precio por hora, y carga los pedidos asociados a esa reserva.
    'Si no se encuentra el cliente o no tiene una reserva activa, muestra mensajes de advertencia y limpia el formulario.
    Private Sub BuscarCliente()
        If String.IsNullOrWhiteSpace(TxtCedula.Text) Then
            MessageBox.Show("Por favor ingrese una cédula", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtCedula.Focus()
            Return
        End If

        cedulaCliente = TxtCedula.Text.Trim()

        Using conexion As New OleDbConnection(cadena)
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

    'Esta función se encarga de obtener el precio por hora y el consumo mínimo asociado a la mesa reservada por el cliente. Realiza una consulta a la tabla Zonas utilizando el ID de la mesa para recuperar esta información, que luego se muestra en el formulario y se utiliza para calcular el total de zona.
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

    'Esta función se encarga de cargar los pedidos asociados a la reserva activa del cliente.
    'Realiza una consulta a la tabla Pedidos utilizando el ID de la reserva para recuperar los pedidos que no estén marcados como "Pagado". Los pedidos se muestran en un DataGridView, y se calcula el total de los pedidos para mostrarlo en el formulario.
    Private Sub CargarPedidos()
        DgvPedidos.Rows.Clear()
        totalPedidos = 0

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()

                ' Cargar pedidos de la reserva activa únicamente
                Dim query As String = "SELECT ID_Pedido, FechaHora, Total, Estado " &
                                 "FROM Pedidos " &
                                 "WHERE ID_Reserva = ? AND Estado <> ? " &
                                 "ORDER BY FechaHora"

                Using comando As New OleDbCommand(query, conexion)
                    comando.Parameters.Add("?", OleDbType.Integer).Value = idReserva
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

    'Esta función se encarga de calcular el total general a pagar por el cliente, sumando el total de los pedidos y el total de la zona (mesa).
    'Además, verifica si hay un consumo mínimo establecido para la mesa y, si el total de los pedidos es menor que ese consumo mínimo, ajusta el total general para reflejar el consumo mínimo aplicado.
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
    'Este código se encarga de manejar el evento de clic en el botón "Generar Factura".
    'Al hacer clic, se llama a la función GenerarFactura() que realiza todo el proceso de generación de la factura, incluyendo el cálculo de impuestos, propina, total final, confirmación con el usuario, inserción de la factura en la base de datos, actualización del estado de los pedidos y reserva, y liberación de la mesa.
    Private Sub BtnGenerarFactura_Click(sender As Object, e As EventArgs) Handles BtnGenerarFactura.Click
        GenerarFactura()
    End Sub

    'Esta función se encarga de generar la factura para el cliente.
    'Realiza los cálculos necesarios para determinar el subtotal, impuestos, propina y total final. Luego, muestra un resumen de la factura para que el usuario confirme antes de proceder.
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

        ' Preguntar por propina 
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

        Using conexion As New OleDbConnection(cadena)
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

    'Esta función se encarga de generar un número de factura único para cada factura creada.
    'Intenta obtener el último ID de factura registrado en la base de datos y lo incrementa para crear un nuevo número de factura. Si ocurre algún error al acceder a la base de datos, utiliza un timestamp para garantizar la unicidad del número de factura.
    Private Function GenerarNumeroFactura() As String
        ' Formato: FACT-001-2026 (ajustar según tu necesidad)
        Dim año As String = DateTime.Now.Year.ToString()
        Dim numero As Integer = 1

        Using conexion As New OleDbConnection(cadena)
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

    'Esta función se encarga de limpiar todos los campos del formulario, restablecer los totales a cero, y preparar el formulario para una nueva búsqueda de cliente y generación de factura.
    'También deshabilita el panel de detalles y el botón de generar factura hasta que se realice una nueva búsqueda exitosa.
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