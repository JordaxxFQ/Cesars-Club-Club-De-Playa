Imports System.Data.OleDb

Public Class FrmPedidos
    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
    Dim _idClienteEncontrado As Integer = 0
    Private cedulaCliente As String = ""
    Private idReservaCliente As Integer = 0


    Private Sub FrmPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InicializarFormulario()

    End Sub

    Private Sub InicializarFormulario()
        Try
            ' Configurar estados
            CboCategoria.Items.Clear()
            CboCategoria.Items.Add("Todas")
            CargarCategorias()
            CboCategoria.SelectedIndex = 0

            ' Configurar DataGridViews
            ConfigurarDGVProductos()
            ConfigurarDGVPedido()

            ' Estado inicial
            PnlProductos.Enabled = False
            BtnGuardarPedido.Enabled = False
            LblTotal.Text = "S/ 0.00"

            TxtCedula.Focus()

        Catch ex As Exception
            MessageBox.Show("Error al inicializar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurarDGVProductos()
        DgvProductos.Columns.Clear()
        DgvProductos.Columns.Add("ID_Producto", "ID")
        DgvProductos.Columns.Add("Nombre", "Producto")
        DgvProductos.Columns.Add("Precio", "Precio")
        DgvProductos.Columns.Add("Stock", "Stock")

        DgvProductos.Columns("ID_Producto").Visible = False
        DgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DgvProductos.ReadOnly = True
        DgvProductos.AllowUserToAddRows = False
        DgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvProductos.MultiSelect = False
    End Sub

    Private Sub ConfigurarDGVPedido()
        DgvPedido.Columns.Clear()
        DgvPedido.Columns.Add("ID_Producto", "ID")
        DgvPedido.Columns.Add("Producto", "Producto")
        DgvPedido.Columns.Add("Precio", "Precio Unit.")

        Dim colCantidad As New DataGridViewTextBoxColumn With {.Name = "Cantidad", .HeaderText = "Cantidad"}
        DgvPedido.Columns.Add(colCantidad)

        DgvPedido.Columns.Add("Subtotal", "Subtotal")

        DgvPedido.Columns("ID_Producto").Visible = False
        DgvPedido.Columns("Precio").DefaultCellStyle.Format = "C2"
        DgvPedido.Columns("Subtotal").DefaultCellStyle.Format = "C2"
        DgvPedido.Columns("Subtotal").ReadOnly = True

        DgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DgvPedido.AllowUserToAddRows = False
        DgvPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub BtnBuscarCliente_Click(sender As Object, e As EventArgs) Handles BtnBuscarCliente.Click

        BuscarCliente()

    End Sub

    Private Sub TxtCedula_Keypress(sender As Object, e As KeyPressEventArgs) Handles TxtCedula.KeyPress
        If e.KeyChar = Chr(13) Then
            BuscarCliente()
            e.Handled = True
        End If
    End Sub

    Private Sub BuscarCliente()
        ' Validar que se ingresó una cédula
        If String.IsNullOrWhiteSpace(TxtCedula.Text) Then
            MessageBox.Show("Por favor ingrese una cédula", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtCedula.Focus()
            Return
        End If

        cedulaCliente = TxtCedula.Text.Trim()

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                ' Paso 1: Buscar el cliente
                Dim queryCliente As String = "SELECT ID_Cliente, NombreComp FROM Clientes WHERE Cedula = ?"

                Using comandoCliente As New OleDbCommand(queryCliente, conexion)
                    comandoCliente.Parameters.Add("?", OleDbType.VarChar).Value = cedulaCliente

                    Using lector As OleDbDataReader = comandoCliente.ExecuteReader()
                        If lector.Read() Then
                            ' Cliente encontrado
                            _idClienteEncontrado = CInt(lector("ID_Cliente"))
                            Dim nombreCliente As String = lector("NombreComp").ToString()

                            lector.Close()

                            ' Paso 2: Buscar la reserva del cliente
                            Dim queryReserva As String = "SELECT ID_Reserva FROM Reservas WHERE Cedula = ?"

                            Using comandoReserva As New OleDbCommand(queryReserva, conexion)
                                comandoReserva.Parameters.Add("?", OleDbType.VarChar).Value = cedulaCliente

                                Dim idReserva As Object = comandoReserva.ExecuteScalar()

                                If idReserva Is Nothing Then
                                    MessageBox.Show("Este cliente no tiene una reserva activa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    LimpiarCliente()
                                    Return
                                End If

                                ' Cliente y reserva encontrados
                                idReservaCliente = CInt(idReserva)

                                Dim queryMesa As String = "SELECT ID_Mesa FROM Reservas WHERE ID_Reserva = ?"
                                Using comandoMesa As New OleDbCommand(queryMesa, conexion)
                                    comandoMesa.Parameters.Add("?", OleDbType.Integer).Value = idReservaCliente

                                    Dim idMesa As Object = comandoMesa.ExecuteScalar()
                                    idMesa = CInt(idMesa)


                                    TxtNombreCliente.Text = "Cliente: " & nombreCliente
                                    TxtMesa.Text = "Mesa: #" & idMesa.ToString()

                                    ' Habilitar panel de productos
                                    PnlProductos.Enabled = True
                                    BtnGuardarPedido.Enabled = True

                                    ' Cargar productos
                                    CargarProductos()

                                    MessageBox.Show("¡Bienvenido " & nombreCliente & "!", "Cliente Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End Using
                            End Using

                        Else
                            ' Cliente no encontrado
                            MessageBox.Show("Cliente no registrado. Por favor regístrelo primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            _idClienteEncontrado = 0
                            TxtNombreCliente.Clear()
                            LimpiarCliente()
                            FrmRegistroClientes.Show()
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error al buscar cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub LimpiarCliente()
        TxtNombreCliente.Text = ""
        TxtMesa.Text = ""
        cedulaCliente = ""
        idReservaCliente = 0
        PnlProductos.Enabled = False
        BtnGuardarPedido.Enabled = False
    End Sub

    Private Sub CargarCategorias()

        CboCategoria.Items.Clear()
        CboCategoria.Items.Add("Todas")

        Dim query As String = "SELECT DISTINCT Categoria FROM Productos WHERE ActivoVenta = True"

        Using conexion As New OleDbConnection(connectionString)
            Try
                Dim comando As New OleDbCommand(query, conexion)
                conexion.Open()
                Dim reader As OleDbDataReader = comando.ExecuteReader()

                While reader.Read()
                    ' Agregamos cada categoría encontrada a la lista
                    If Not reader.IsDBNull(0) Then
                        CboCategoria.Items.Add(reader("Categoria").ToString())
                    End If
                End While

                ' Seleccionamos "Todas" por defecto
                CboCategoria.SelectedIndex = 0

            Catch ex As Exception
                MessageBox.Show("Error al cargar categorías: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub cboCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboCategoria.SelectedIndexChanged
        If PnlProductos.Enabled Then
            CargarProductos()
        End If
    End Sub

    Private Sub CargarProductos()
        If CboCategoria.SelectedItem Is Nothing Then
            Return
        End If

        DgvProductos.Rows.Clear()

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                Dim categoriaSeleccionada As String = CboCategoria.SelectedItem.ToString()
                Dim query As String = "SELECT ID_Producto, NombreProducto, Precio, Stock " & "FROM Productos WHERE ActivoVenta = True"

                If categoriaSeleccionada <> "Todas" Then
                    query &= " AND Categoria = ?"
                End If

                query &= " ORDER BY NombreProducto"

                Using comando As New OleDbCommand(query, conexion)
                    If categoriaSeleccionada <> "Todas" Then
                        comando.Parameters.Add("?", OleDbType.VarChar).Value = categoriaSeleccionada
                    End If

                    Using reader As OleDbDataReader = comando.ExecuteReader()
                        While reader.Read()
                            DgvProductos.Rows.Add(
                                reader("ID_Producto"),
                                reader("NombreProducto"),
                                FormatCurrency(reader("Precio"), 2),
                                reader("Stock")
                            )
                        End While
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error al cargar productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        AgregarProducto()
    End Sub

    Private Sub dgvProductos_DoubleClick(sender As Object, e As EventArgs) Handles DgvProductos.DoubleClick
        AgregarProducto()
    End Sub

    Private Sub AgregarProducto()
        If DgvProductos.SelectedRows.Count = 0 Then
            MessageBox.Show("Por favor seleccione un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim fila As DataGridViewRow = DgvProductos.SelectedRows(0)
            Dim idProducto As Integer = CInt(fila.Cells("ID_Producto").Value)
            Dim nombreProducto As String = fila.Cells("Nombre").Value.ToString()
            Dim precioTexto As String = fila.Cells("Precio").Value.ToString()
            Dim precio As Decimal = CDec(precioTexto.Replace("S/", "").Replace("$", "").Trim())
            Dim stockDisponible As Integer = CInt(fila.Cells("Stock").Value)

            If stockDisponible <= 0 Then
                MessageBox.Show("Producto sin stock disponible", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Solicitar cantidad
            Dim cantidadStr As String = InputBox("Ingrese la cantidad:", "Cantidad", "1")
            If String.IsNullOrEmpty(cantidadStr) Then Return

            Dim cantidad As Integer
            If Not Integer.TryParse(cantidadStr, cantidad) OrElse cantidad <= 0 Then
                MessageBox.Show("Cantidad inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If cantidad > stockDisponible Then
                MessageBox.Show("Stock insuficiente. Disponible: " & stockDisponible.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Verificar si ya existe en el pedido
            Dim productoExiste As Boolean = False
            For Each pedidoRow As DataGridViewRow In DgvPedido.Rows
                If CInt(pedidoRow.Cells("ID_Producto").Value) = idProducto Then
                    Dim cantidadActual As Integer = CInt(pedidoRow.Cells("Cantidad").Value)
                    Dim nuevaCantidad As Integer = cantidadActual + cantidad

                    If nuevaCantidad > stockDisponible Then
                        MessageBox.Show("Stock insuficiente. Disponible: " & stockDisponible.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If

                    pedidoRow.Cells("Cantidad").Value = nuevaCantidad
                    pedidoRow.Cells("Subtotal").Value = precio * nuevaCantidad
                    productoExiste = True
                    Exit For
                End If
            Next

            ' Si no existe, agregar nuevo
            If Not productoExiste Then
                Dim subtotal As Decimal = precio * cantidad
                DgvPedido.Rows.Add(idProducto, nombreProducto, precio, cantidad, subtotal)
            End If

            CalcularTotal()

        Catch ex As Exception
            MessageBox.Show("Error al agregar producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvPedido_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPedido.CellEndEdit
        If e.ColumnIndex = DgvPedido.Columns("Cantidad").Index Then
            Try
                Dim fila As DataGridViewRow = DgvPedido.Rows(e.RowIndex)
                Dim cantidad As Integer = CInt(fila.Cells("Cantidad").Value)
                Dim precio As Decimal = CDec(fila.Cells("Precio").Value)

                If cantidad <= 0 Then
                    MessageBox.Show("La cantidad debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    fila.Cells("Cantidad").Value = 1
                    cantidad = 1
                End If

                fila.Cells("Subtotal").Value = precio * cantidad
                CalcularTotal()

            Catch ex As Exception
                MessageBox.Show("Error al actualizar cantidad: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles BtnQuitar.Click
        If DgvPedido.SelectedRows.Count = 0 Then
            MessageBox.Show("Por favor seleccione un producto del pedido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim respuesta As DialogResult = MessageBox.Show("¿Está seguro de quitar este producto del pedido?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = DialogResult.Yes Then
            DgvPedido.Rows.Remove(DgvPedido.SelectedRows(0))
            CalcularTotal()
        End If
    End Sub

    Private Sub CalcularTotal()
        Dim total As Decimal = 0

        For Each fila As DataGridViewRow In DgvPedido.Rows
            total += CDec(fila.Cells("Subtotal").Value)
        Next

        LblTotal.Text = total.ToString("C2")
    End Sub

    Private Sub btnGuardarPedido_Click(sender As Object, e As EventArgs) Handles BtnGuardarPedido.Click
        GuardarPedido()
    End Sub

    Private Sub GuardarPedido()
        ' Validaciones previas...
        If String.IsNullOrEmpty(cedulaCliente) Then
            MessageBox.Show("Debe buscar un cliente primero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DgvPedido.Rows.Count = 0 Then
            MessageBox.Show("Agregue al menos un producto al pedido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conexion As New OleDbConnection(connectionString)
            conexion.Open()
            Dim transaction As OleDbTransaction = conexion.BeginTransaction()

            Try
                ' Calcular total
                Dim totalPedido As Decimal = 0
                For Each fila As DataGridViewRow In DgvPedido.Rows
                    totalPedido += CDec(fila.Cells("Subtotal").Value)
                Next

                ' --- PASO 1: INSERTAR PEDIDO ---
                Dim queryPedido As String = "INSERT INTO Pedidos (ID_Reserva, Cedula, FechaHora, Estado, Total, NotasEspeciales) " &
                                      "VALUES (@IDReserva, @Cedula, @FechaHora, @Estado, @Total, @Notas)"

                Using cmdPedido As New OleDbCommand(queryPedido, conexion, transaction)
                    ' IMPORTANTE: El orden de los parámetros debe coincidir con la consulta SQL
                    cmdPedido.Parameters.Add("@IDReserva", OleDbType.Integer).Value = idReservaCliente
                    cmdPedido.Parameters.Add("@Cedula", OleDbType.VarChar).Value = cedulaCliente
                    cmdPedido.Parameters.Add("@FechaHora", OleDbType.Date).Value = DateTime.Now
                    cmdPedido.Parameters.Add("@Estado", OleDbType.VarChar).Value = "Pendiente"

                    ' CORRECCIÓN CLAVE: Usar OleDbType.Currency para dinero en Access
                    cmdPedido.Parameters.Add("@Total", OleDbType.Currency).Value = totalPedido

                    cmdPedido.Parameters.Add("@Notas", OleDbType.LongVarChar).Value = If(String.IsNullOrEmpty(TxtNotas.Text), DBNull.Value, TxtNotas.Text)

                    cmdPedido.ExecuteNonQuery()
                End Using

                ' Obtener ID del pedido
                Dim cmdGetID As New OleDbCommand("SELECT @@IDENTITY", conexion, transaction)
                Dim idPedido As Integer = CInt(cmdGetID.ExecuteScalar())

                ' --- PASO 2: INSERTAR DETALLES Y ACTUALIZAR STOCK ---
                For Each fila As DataGridViewRow In DgvPedido.Rows
                    Dim queryDetalle As String = "INSERT INTO DetallesPedidos (ID_Pedido, ID_Producto, Cantidad, PrecioUnitario, Subtotal) " &
                                           "VALUES (@IDPedido, @IDProducto, @Cantidad, @Precio, @Subtotal)"

                    Using cmdDetalle As New OleDbCommand(queryDetalle, conexion, transaction)
                        cmdDetalle.Parameters.Add("@IDPedido", OleDbType.Integer).Value = idPedido
                        cmdDetalle.Parameters.Add("@IDProducto", OleDbType.Integer).Value = CInt(fila.Cells("ID_Producto").Value)
                        cmdDetalle.Parameters.Add("@Cantidad", OleDbType.Integer).Value = CInt(fila.Cells("Cantidad").Value)

                        ' CORRECCIÓN CLAVE: Usar Currency también aquí
                        cmdDetalle.Parameters.Add("@Precio", OleDbType.Currency).Value = CDec(fila.Cells("Precio").Value)
                        cmdDetalle.Parameters.Add("@Subtotal", OleDbType.Currency).Value = CDec(fila.Cells("Subtotal").Value)

                        cmdDetalle.ExecuteNonQuery()
                    End Using

                    ' Actualizar stock
                    Dim queryStock As String = "UPDATE Productos SET Stock = Stock - @Cantidad WHERE ID_Producto = @IDProducto"
                    Using cmdStock As New OleDbCommand(queryStock, conexion, transaction)
                        cmdStock.Parameters.Add("@Cantidad", OleDbType.Integer).Value = CInt(fila.Cells("Cantidad").Value)
                        cmdStock.Parameters.Add("@IDProducto", OleDbType.Integer).Value = CInt(fila.Cells("ID_Producto").Value)
                        cmdStock.ExecuteNonQuery()
                    End Using
                Next

                transaction.Commit()

                MessageBox.Show("Pedido #" & idPedido.ToString() & " guardado exitosamente" & vbCrLf & "Total: " & totalPedido.ToString("C2"),
                           "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LimpiarPedido()
                CargarProductos()

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error al guardar pedido: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        LimpiarTodo()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        If DgvPedido.Rows.Count > 0 Then
            Dim respuesta As DialogResult = MessageBox.Show(
                "¿Está seguro de cancelar el pedido actual?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If respuesta = DialogResult.Yes Then
                LimpiarPedido()
            End If
        End If
    End Sub

    Private Sub LimpiarPedido()
        DgvPedido.Rows.Clear()
        TxtNotas.Clear()
        LblTotal.Text = "S/ 0.00"
    End Sub

    Private Sub LimpiarTodo()
        LimpiarPedido()
        TxtCedula.Clear()
        TxtNombreCliente.Text = ""
        TxtMesa.Text = ""
        cedulaCliente = ""
        idReservaCliente = 0
        PnlProductos.Enabled = False
        BtnGuardarPedido.Enabled = False
        DgvProductos.Rows.Clear()
        CboCategoria.SelectedIndex = 0
        TxtCedula.Focus()
    End Sub
End Class