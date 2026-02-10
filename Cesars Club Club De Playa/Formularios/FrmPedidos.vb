Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmPedidos
    Dim _idClienteEncontrado As Integer = 0
    Private cedulaCliente As String = ""
    Private idReservaCliente As Integer = 0

    ' Este código se encarga de inicializar el formulario de pedidos, configurando los controles y cargando las categorías de productos disponibles.
    ' También establece el estado inicial del formulario, deshabilitando el panel de productos y el botón de guardar pedido hasta que se busque un cliente válido.
    Private Sub FrmPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InicializarFormulario()

    End Sub

    ' Esta función se encarga de configurar el formulario de pedidos
    ' Estableciendo los estados iniciales de los controles, cargando las categorías de productos, y configurando los DataGridViews para mostrar los productos y el pedido.
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

    ' Esta función se encarga de configurar el DataGridView que muestra los productos disponibles para el pedido.
    ' Se definen las columnas que se mostrarán, se oculta la columna de ID, y se establecen algunas propiedades para mejorar la apariencia y usabilidad del control.
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

    ' Esta función se encarga de configurar el DataGridView que muestra los productos agregados al pedido.
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

    ' Este código se encarga de manejar el evento de clic en el botón "Buscar Cliente" y la tecla Enter en el textbox de cédula, llamando a la función BuscarCliente para buscar un cliente en la base de datos utilizando la cédula ingresada por el usuario.
    Private Sub BtnBuscarCliente_Click(sender As Object, e As EventArgs) Handles BtnBuscarCliente.Click

        BuscarCliente()

    End Sub

    Private Sub TxtCedula_Keypress(sender As Object, e As KeyPressEventArgs) Handles TxtCedula.KeyPress
        If e.KeyChar = Chr(13) Then
            BuscarCliente()
            e.Handled = True
        End If
    End Sub

    ' Esta función se encarga de buscar un cliente en la base de datos utilizando la cédula ingresada por el usuario.

    Private Sub BuscarCliente()
        ' Validar que se ingresó una cédula
        If String.IsNullOrWhiteSpace(TxtCedula.Text) Then
            MessageBox.Show("Por favor ingrese una cédula", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtCedula.Focus()
            Return
        End If

        cedulaCliente = TxtCedula.Text.Trim()

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()

                ' Buscamos el cliente
                Dim queryCliente As String = "SELECT ID_Cliente, NombreComp FROM Clientes WHERE Cedula = ?"

                Using comandoCliente As New OleDbCommand(queryCliente, conexion)
                    comandoCliente.Parameters.Add("?", OleDbType.VarChar).Value = cedulaCliente

                    Using lector As OleDbDataReader = comandoCliente.ExecuteReader()
                        If lector.Read() Then
                            ' Cliente encontrado
                            _idClienteEncontrado = CInt(lector("ID_Cliente"))
                            Dim nombreCliente As String = lector("NombreComp").ToString()

                            lector.Close()

                            ' Buscamos la reserva del cliente
                            Dim queryReserva As String = "SELECT ID_Reserva FROM Reservas WHERE Cedula = ? AND EstadoReserva = ?"

                            Using comandoReserva As New OleDbCommand(queryReserva, conexion)
                                comandoReserva.Parameters.Add("?", OleDbType.VarChar).Value = cedulaCliente
                                comandoReserva.Parameters.Add("?", OleDbType.VarChar).Value = "Activa"

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

                                    ' Habilitamos panel de productos
                                    PnlProductos.Enabled = True
                                    BtnGuardarPedido.Enabled = True

                                    ' Cargamos los productos
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

    ' Esta función se encarga de cargar las categorías de productos disponibles para la venta en el ComboBox de categorías, obteniendo los datos de la base de datos y agregándolos a la lista. También maneja cualquier error que pueda ocurrir durante la carga.
    Private Sub CargarCategorias()

        CboCategoria.Items.Clear()
        CboCategoria.Items.Add("Todas")

        Dim query As String = "SELECT DISTINCT Categoria FROM Productos WHERE ActivoVenta = True"

        Using conexion As New OleDbConnection(cadena)
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

    ' Este código se encarga de manejar el evento de cambio de selección en el ComboBox de categorías, llamando a la función CargarProductos para actualizar la lista de productos mostrados según la categoría seleccionada.
    Private Sub CboCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboCategoria.SelectedIndexChanged
        If PnlProductos.Enabled Then
            CargarProductos()
        End If
    End Sub

    ' Esta función se encarga de cargar los productos disponibles para la venta en el DataGridView de productos, filtrando por la categoría seleccionada en el ComboBox.
    ' Si se selecciona "Todas", se muestran todos los productos activos para la venta. También maneja cualquier error que pueda ocurrir durante la carga.
    Private Sub CargarProductos()
        If CboCategoria.SelectedItem Is Nothing Then
            Return
        End If

        DgvProductos.Rows.Clear()

        Using conexion As New OleDbConnection(cadena)
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

    ' Este código se encarga de manejar el evento de clic en el botón "Agregar Producto", llamando a la función AgregarProducto para agregar el producto seleccionado al pedido.
    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        AgregarProducto()
    End Sub

    ' Este código se encarga de manejar el evento de doble clic en el DataGridView de productos, llamando a la función AgregarProducto para agregar el producto seleccionado al pedido.
    Private Sub DgvProductos_DoubleClick(sender As Object, e As EventArgs) Handles DgvProductos.DoubleClick
        AgregarProducto()
    End Sub

    ' Esta función se encarga de agregar el producto seleccionado en el DataGridView de productos al pedido, solicitando la cantidad deseada al usuario y validando que no se exceda el stock disponible. Si el producto ya existe en el pedido, se actualiza la cantidad y el subtotal correspondiente.
    ' También maneja cualquier error que pueda ocurrir durante el proceso.
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

    ' Este código se encarga de manejar el evento de edición de una celda en el DataGridView del pedido, específicamente para la columna de cantidad.
    ' Valida que la cantidad ingresada sea un número entero positivo y que no exceda el stock disponible. Si la cantidad es válida, actualiza el subtotal correspondiente y recalcula el total del pedido.
    Private Sub DgvPedido_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPedido.CellEndEdit
        If e.ColumnIndex = DgvPedido.Columns("Cantidad").Index Then
            Try
                Dim fila As DataGridViewRow = DgvPedido.Rows(e.RowIndex)
                Dim cantidad As Integer = fila.Cells("Cantidad").Value
                Dim precio As Decimal = fila.Cells("Precio").Value

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

    ' Este código se encarga de manejar el evento de clic en el botón "Quitar Producto", permitiendo al usuario eliminar un producto seleccionado del pedido.
    ' Antes de eliminar, se muestra una confirmación para evitar eliminaciones accidentales. Si el usuario confirma, se elimina la fila seleccionada del DataGridView del pedido y se recalcula el total.
    Private Sub BtnQuitar_Click(sender As Object, e As EventArgs) Handles BtnQuitar.Click
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

    ' Esta función se encarga de calcular el total del pedido sumando los subtotales de cada producto agregado al pedido, y actualizando la etiqueta que muestra el total en el formulario.
    Private Sub CalcularTotal()
        Dim total As Decimal = 0

        For Each fila As DataGridViewRow In DgvPedido.Rows
            total += CDec(fila.Cells("Subtotal").Value)
        Next

        LblTotal.Text = total.ToString("C2")
    End Sub

    ' Este código se encarga de manejar el evento de clic en el botón "Guardar Pedido", llamando a la función GuardarPedido para guardar el pedido actual en la base de datos, incluyendo los detalles del pedido y actualizando el stock de los productos correspondientes.
    Private Sub BtnGuardarPedido_Click(sender As Object, e As EventArgs) Handles BtnGuardarPedido.Click
        GuardarPedido()
    End Sub

    ' Esta función se encarga de guardar el pedido actual en la base de datos, realizando las siguientes operaciones:
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

        Using conexion As New OleDbConnection(cadena)
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

                    cmdPedido.Parameters.Add("@IDReserva", OleDbType.Integer).Value = idReservaCliente
                    cmdPedido.Parameters.Add("@Cedula", OleDbType.VarChar).Value = cedulaCliente
                    cmdPedido.Parameters.Add("@FechaHora", OleDbType.Date).Value = DateTime.Now
                    cmdPedido.Parameters.Add("@Estado", OleDbType.VarChar).Value = "Pendiente"

                    cmdPedido.Parameters.Add("@Total", OleDbType.Currency).Value = totalPedido
                    cmdPedido.Parameters.Add("@Notas", OleDbType.LongVarChar).Value = If(String.IsNullOrEmpty(TxtNotas.Text), DBNull.Value, TxtNotas.Text)

                    cmdPedido.ExecuteNonQuery()
                End Using

                ' Obtener ID del pedido
                Dim cmdGetID As New OleDbCommand("SELECT @@IDENTITY", conexion, transaction)
                Dim idPedido As Integer = CInt(cmdGetID.ExecuteScalar())

                For Each fila As DataGridViewRow In DgvPedido.Rows
                    Dim queryDetalle As String = "INSERT INTO DetallesPedidos (ID_Pedido, ID_Producto, Cantidad, PrecioUnitario, Subtotal) " &
                                           "VALUES (@IDPedido, @IDProducto, @Cantidad, @Precio, @Subtotal)"

                    Using cmdDetalle As New OleDbCommand(queryDetalle, conexion, transaction)
                        cmdDetalle.Parameters.Add("@IDPedido", OleDbType.Integer).Value = idPedido
                        cmdDetalle.Parameters.Add("@IDProducto", OleDbType.Integer).Value = CInt(fila.Cells("ID_Producto").Value)
                        cmdDetalle.Parameters.Add("@Cantidad", OleDbType.Integer).Value = CInt(fila.Cells("Cantidad").Value)
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
    ' Este código se encarga de manejar el evento de clic en el botón "Nuevo Pedido", llamando a la función LimpiarTodo para limpiar todos los campos y restablecer el formulario al estado inicial, permitiendo iniciar un nuevo pedido desde cero.
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        LimpiarTodo()
    End Sub

    ' Este código se encarga de manejar el evento de clic en el botón "Cancelar Pedido", mostrando una confirmación para cancelar el pedido actual.
    ' Si el usuario confirma, se llama a la función LimpiarPedido para limpiar los productos agregados al pedido y restablecer el total a cero, pero manteniendo la información del cliente para permitir seguir agregando productos si lo desea. 
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
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
    ' Esta función se encarga de limpiar los productos agregados al pedido y restablecer el total a cero, pero manteniendo la información del cliente para permitir seguir agregando productos si lo desea.
    Private Sub LimpiarPedido()
        DgvPedido.Rows.Clear()
        TxtNotas.Clear()
        LblTotal.Text = "S/ 0.00"
    End Sub
    ' Esta función se encarga de limpiar todos los campos y restablecer el formulario al estado inicial, permitiendo iniciar un nuevo pedido desde cero. Esto incluye limpiar la información del cliente, deshabilitar el panel de productos, limpiar los productos agregados al pedido, y restablecer el total a cero.
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