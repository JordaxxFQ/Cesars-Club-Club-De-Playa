Imports System.Data.OleDb

Public Class FrmCocina
    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
    Private idPedidoSeleccionado As Integer = 0

    Private Sub FrmCocina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarFormulario()
    End Sub

    Private Sub InicializarFormulario()
        Try

            ' Configurar DataGridViews
            ConfigurarDGVPedidos()
            ConfigurarDGVDetalle()

            ' Configurar estados en ComboBox
            CboEstado.Items.Clear()
            CboEstado.Items.AddRange({"Todos", "Pendiente", "En Preparacion", "Listo"})
            CboEstado.SelectedIndex = 1 ' Por defecto "Pendiente"

            ' Cargar pedidos pendientes
            CargarPedidos()

        Catch ex As Exception
            MessageBox.Show("Error al inicializar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurarDGVPedidos()
        DgvPedidos.Columns.Clear()
        DgvPedidos.Columns.Add("ID_Pedido", "#Pedido")
        DgvPedidos.Columns.Add("FechaHora", "Fecha/Hora")
        DgvPedidos.Columns.Add("Cliente", "Cliente")
        DgvPedidos.Columns.Add("Mesa", "Mesa")
        DgvPedidos.Columns.Add("Total", "Total")
        DgvPedidos.Columns.Add("Estado", "Estado")
        DgvPedidos.Columns.Add("Notas", "Comentarios")

        DgvPedidos.Columns("ID_Pedido").Width = 80
        DgvPedidos.Columns("FechaHora").Width = 140
        DgvPedidos.Columns("Cliente").Width = 150
        DgvPedidos.Columns("Mesa").Width = 80
        DgvPedidos.Columns("Total").Width = 90
        DgvPedidos.Columns("Estado").Width = 120
        DgvPedidos.Columns("Notas").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DgvPedidos.Columns("Total").DefaultCellStyle.Format = "C2"
        DgvPedidos.Columns("FechaHora").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"

        DgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        DgvPedidos.ReadOnly = True
        DgvPedidos.AllowUserToAddRows = False
        DgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvPedidos.MultiSelect = False
    End Sub

    Private Sub ConfigurarDGVDetalle()
        DgvDetalle.Columns.Clear()
        DgvDetalle.Columns.Add("Cantidad", "Cant.")
        DgvDetalle.Columns.Add("Producto", "Producto")
        DgvDetalle.Columns.Add("Categoria", "Categoría")
        DgvDetalle.Columns.Add("PrecioUnitario", "Precio Unit.")
        DgvDetalle.Columns.Add("Subtotal", "Subtotal")

        DgvDetalle.Columns("Cantidad").Width = 80
        DgvDetalle.Columns("Producto").Width = 250
        DgvDetalle.Columns("Categoria").Width = 150
        DgvDetalle.Columns("PrecioUnitario").Width = 120
        DgvDetalle.Columns("Subtotal").Width = 120

        DgvDetalle.Columns("PrecioUnitario").DefaultCellStyle.Format = "C2"
        DgvDetalle.Columns("Subtotal").DefaultCellStyle.Format = "C2"

        DgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DgvDetalle.ReadOnly = True
        DgvDetalle.AllowUserToAddRows = False
        DgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub CboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEstado.SelectedIndexChanged
        CargarPedidos()
    End Sub

    Private Sub CargarPedidos()
        If CboEstado.SelectedItem Is Nothing Then
            Return
        End If

        DgvPedidos.Rows.Clear()
        DgvDetalle.Rows.Clear()
        LimpiarInfoPedido()

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                Dim estadoSeleccionado As String = CboEstado.SelectedItem.ToString()

                ' Query para obtener pedidos con información del cliente
                Dim query As String = "SELECT p.ID_Pedido, p.FechaHora, c.NombreComp, r.ID_Reserva, p.Total, p.Estado, p.NotasEspeciales " &
                                     "FROM (Pedidos p INNER JOIN Clientes c ON p.Cedula = c.Cedula) " &
                                     "INNER JOIN Reservas r ON p.ID_Reserva = r.ID_Reserva"

                If estadoSeleccionado <> "Todos" Then
                    query &= " WHERE p.Estado = ?"
                End If

                query &= " ORDER BY p.FechaHora DESC"

                Using comando As New OleDbCommand(query, conexion)
                    If estadoSeleccionado <> "Todos" Then
                        comando.Parameters.Add("?", OleDbType.VarChar).Value = estadoSeleccionado
                    End If

                    Using reader As OleDbDataReader = comando.ExecuteReader()
                        While reader.Read()
                            Dim notas As String = ""
                            If Not IsDBNull(reader("NotasEspeciales")) Then
                                notas = reader("NotasEspeciales").ToString()
                            End If

                            DgvPedidos.Rows.Add(
                                reader("ID_Pedido"),
                                CDate(reader("FechaHora")),
                                reader("NombreComp"),
                                "Mesa #" & reader("ID_Reserva").ToString(),
                                CDec(reader("Total")),
                                reader("Estado"),
                                notas
                            )

                            ' Colorear según estado
                            Dim ultimaFila As Integer = DgvPedidos.Rows.Count - 1
                            Select Case reader("Estado").ToString()
                                Case "Pendiente"
                                    DgvPedidos.Rows(ultimaFila).DefaultCellStyle.BackColor = Color.LightBlue
                                Case "En Preparacion"
                                    DgvPedidos.Rows(ultimaFila).DefaultCellStyle.BackColor = Color.LightYellow
                                Case "Listo"
                                    DgvPedidos.Rows(ultimaFila).DefaultCellStyle.BackColor = Color.LightGreen
                            End Select
                        End While
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error al cargar pedidos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub DgvPedidos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPedidos.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DgvPedidos.Rows(e.RowIndex)

            If fila.Cells("ID_Pedido").Value IsNot Nothing Then
                idPedidoSeleccionado = CInt(fila.Cells("ID_Pedido").Value)
                CargarDetallePedido(idPedidoSeleccionado)
                MostrarInfoPedido(fila)
            End If
        End If
    End Sub

    Private Sub MostrarInfoPedido(fila As DataGridViewRow)
        Try
            LblNumPedido.Text = "PEDIDO #" & fila.Cells("ID_Pedido").Value.ToString()
            LblCliente.Text = "Cliente: " & fila.Cells("Cliente").Value.ToString()
            LblMesa.Text = fila.Cells("Mesa").Value.ToString()
            LblFechaHora.Text = "Hora: " & CDate(fila.Cells("FechaHora").Value).ToString("HH:mm")

            If fila.Cells("Notas").Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(fila.Cells("Notas").Value.ToString()) Then
                TxtComentarios.Text = fila.Cells("Notas").Value.ToString()
                TxtComentarios.BackColor = Color.LightYellow
            Else
                TxtComentarios.Text = "Sin comentarios especiales"
                TxtComentarios.BackColor = Color.White
            End If

            LblTotal.Text = "TOTAL: " & CDec(fila.Cells("Total").Value).ToString("C2")

        Catch ex As Exception
            MessageBox.Show("Error al mostrar información: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarDetallePedido(idPedido As Integer)
        DgvDetalle.Rows.Clear()

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                ' Query para obtener detalles con nombre del producto y categoría
                Dim query As String = "SELECT dp.Cantidad, pr.NombreProducto, pr.Categoria, dp.PrecioUnitario, dp.Subtotal " &
                                     "FROM DetallesPedidos dp INNER JOIN Productos pr ON dp.ID_Producto = pr.ID_Producto " &
                                     "WHERE dp.ID_Pedido = ? " &
                                     "ORDER BY pr.Categoria, pr.NombreProducto"

                Using comando As New OleDbCommand(query, conexion)
                    comando.Parameters.Add("?", OleDbType.Integer).Value = idPedido

                    Using reader As OleDbDataReader = comando.ExecuteReader()
                        While reader.Read()
                            DgvDetalle.Rows.Add(
                                reader("Cantidad"),
                                reader("NombreProducto"),
                                reader("Categoria"),
                                CDec(reader("PrecioUnitario")),
                                CDec(reader("Subtotal"))
                            )
                        End While
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error al cargar detalle: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub LimpiarInfoPedido()
        LblNumPedido.Text = "SELECCIONE UN PEDIDO"
        LblCliente.Text = ""
        LblMesa.Text = ""
        LblFechaHora.Text = ""
        TxtComentarios.Text = ""
        LblTotal.Text = "TOTAL: S/ 0.00"
        idPedidoSeleccionado = 0
    End Sub

    Private Sub BtnIniciarPreparacion_Click(sender As Object, e As EventArgs) Handles BtnIniciarPreparacion.Click
        CambiarEstadoPedido("En Preparacion")
    End Sub

    Private Sub BtnMarcarListo_Click(sender As Object, e As EventArgs) Handles BtnMarcarListo.Click
        CambiarEstadoPedido("Listo")
    End Sub

    Private Sub CambiarEstadoPedido(nuevoEstado As String)
        If idPedidoSeleccionado = 0 Then
            MessageBox.Show("Por favor seleccione un pedido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                Dim query As String = "UPDATE Pedidos SET Estado = ? WHERE ID_Pedido = ?"

                Using comando As New OleDbCommand(query, conexion)
                    comando.Parameters.Add("?", OleDbType.VarChar).Value = nuevoEstado
                    comando.Parameters.Add("?", OleDbType.Integer).Value = idPedidoSeleccionado

                    Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                    If filasAfectadas > 0 Then
                        MessageBox.Show($"Pedido #{idPedidoSeleccionado} marcado como: {nuevoEstado}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CargarPedidos()
                        LimpiarInfoPedido()
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show("Error al cambiar estado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        CargarPedidos()
        MessageBox.Show("Pedidos actualizados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'Possssiiiiiible timer para actualizar automaticamente cada 30 seg :)
    'Private Sub TimerActualizacion_Tick(sender As Object, e As EventArgs) Handles TimerActualizacion.Tick
    'CargarPedidos()
    ' End Sub
End Class