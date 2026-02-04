Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmProductos

    Dim _idProductoSeleccionado As Integer = 0
    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductos()
        Dim queryCategoria As String = "SELECT DISTINCT Categoria FROM Productos ORDER BY Categoria"
    End Sub

    Private Sub CargarProductos()
        Dim query As String = "SELECT * FROM Productos ORDER BY NombreProducto ASC"

        Using conexion As New OleDbConnection(cadena)
            Try
                Dim adaptador As New OleDbDataAdapter(query, conexion)
                Dim tabla As New DataTable()
                adaptador.Fill(tabla)

                DgvProductos.DataSource = tabla

                If DgvProductos.Columns.Contains("ID_Producto") Then
                    DgvProductos.Columns("ID_Producto").Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show("Error al cargar productos: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub DgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvProductos.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DgvProductos.Rows(e.RowIndex)
            _idProductoSeleccionado = CInt(fila.Cells("ID_Producto").Value)

            txtNombre.Text = fila.Cells("NombreProducto").Value.ToString()
            cmbCategoria.Text = fila.Cells("Categoria").Value.ToString()
            txtDescripcion.Text = fila.Cells("Descripcion").Value.ToString()
            txtPrecio.Text = fila.Cells("Precio").Value.ToString()
            txtStock.Text = fila.Cells("Stock").Value.ToString()

            If DgvProductos.Columns.Contains("ActivoVenta") Then
                Dim valorCheck = fila.Cells("ActivoVenta").Value
                ' Verificamos si no es nulo antes de asignar
                If IsDBNull(valorCheck) Then
                    chkActivo.Checked = False
                Else
                    chkActivo.Checked = DirectCast(valorCheck, Boolean)
                End If
            End If
        End If
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgg.Click
        If ValidarCampos() = False Then Exit Sub

        Dim query As String = "INSERT INTO Productos (NombreProducto, Categoria, Descripcion, Precio, Stock, ActivoVenta) VALUES (?, ?, ?, ?, ?, ?)"

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()
                Dim cmd As New OleDbCommand(query, conexion)

                cmd.Parameters.Add("@nom", OleDbType.VarWChar).Value = txtNombre.Text
                cmd.Parameters.Add("@cat", OleDbType.VarWChar).Value = cmbCategoria.Text
                cmd.Parameters.Add("@desc", OleDbType.LongVarWChar).Value = txtDescripcion.Text
                cmd.Parameters.Add("@prec", OleDbType.Currency).Value = Decimal.Parse(txtPrecio.Text)
                cmd.Parameters.Add("@stk", OleDbType.Integer).Value = CInt(txtStock.Text)
                cmd.Parameters.Add("@act", OleDbType.Boolean).Value = chkActivo.Checked

                cmd.ExecuteNonQuery()
                MessageBox.Show("Producto agregado correctamente.")

                LimpiarCampos()
                CargarProductos()

            Catch ex As Exception
                MessageBox.Show("Error al agregar: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If _idProductoSeleccionado = 0 Then
            MessageBox.Show("Seleccione un producto primero.")
            Exit Sub
        End If

        ' Agregamos ActivoVenta=? a la consulta SQL
        Dim query As String = "UPDATE Productos SET NombreProducto=?, Categoria=?, Descripcion=?, Precio=?, Stock=?, ActivoVenta=? WHERE ID_Producto=?"

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()
                Dim cmd As New OleDbCommand(query, conexion)

                ' Los parámetros DEBEN seguir el orden exacto del Query arriba
                cmd.Parameters.Add("@nom", OleDbType.VarWChar).Value = txtNombre.Text
                cmd.Parameters.Add("@cat", OleDbType.VarWChar).Value = cmbCategoria.Text
                cmd.Parameters.Add("@desc", OleDbType.LongVarWChar).Value = txtDescripcion.Text
                cmd.Parameters.Add("@prec", OleDbType.Currency).Value = Decimal.Parse(txtPrecio.Text)
                cmd.Parameters.Add("@stk", OleDbType.Integer).Value = CInt(txtStock.Text)

                ' --- NUEVO: Parámetro para el campo Yes/No ---
                cmd.Parameters.Add("@act", OleDbType.Boolean).Value = chkActivo.Checked

                ' El ID siempre al final por el WHERE
                cmd.Parameters.Add("@id", OleDbType.Integer).Value = _idProductoSeleccionado

                cmd.ExecuteNonQuery()
                MessageBox.Show("Producto actualizado con éxito, incluyendo estado de venta.")

                CargarProductos()
                LimpiarCampos()

            Catch ex As Exception
                MessageBox.Show("Error al modificar: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _idProductoSeleccionado = 0 Then
            MessageBox.Show("Seleccione un producto para eliminar.")
            Exit Sub
        End If

        Dim respuesta As DialogResult = MessageBox.Show("¿Seguro que desea eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If respuesta = DialogResult.Yes Then
            Dim query As String = "DELETE FROM Productos WHERE ID_Producto = ?"

            Using conexion As New OleDbConnection(cadena)
                Try
                    conexion.Open()
                    Dim cmd As New OleDbCommand(query, conexion)
                    cmd.Parameters.Add("@id", OleDbType.Integer).Value = _idProductoSeleccionado

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Producto eliminado.")

                    LimpiarCampos()
                    CargarProductos()

                Catch ex As Exception
                    MessageBox.Show("Error al eliminar: " & ex.Message)
                End Try
            End Using
        End If
    End Sub

    ' --- FUNCIONES DE AYUDA (LIMPIEZA Y VALIDACIÓN) ---
    Private Sub LimpiarCampos()
        txtNombre.Clear()
        cmbCategoria.SelectedIndex = -1
        txtDescripcion.Clear()
        txtPrecio.Clear()
        txtStock.Clear()
        _idProductoSeleccionado = 0
    End Sub

    Private Function ValidarCampos() As Boolean
        If txtNombre.Text = "" Or cmbCategoria.Text = "" Or txtPrecio.Text = "" Then
            MessageBox.Show("Nombre, Categoría y Precio son obligatorios.")
            Return False
        End If

        ' Validar que Precio sea número
        If Not IsNumeric(txtPrecio.Text) Then
            MessageBox.Show("El Precio debe ser un número válido.")
            Return False
        End If

        ' Validar que Stock sea número
        If txtStock.Text <> "" AndAlso Not IsNumeric(txtStock.Text) Then
            MessageBox.Show("El Stock debe ser un número entero.")
            Return False
        End If

        Return True
    End Function

End Class