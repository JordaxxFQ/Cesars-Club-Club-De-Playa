Imports System.Data.OleDb

Public Class FrmRegistroClientes

    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

    Private Sub FrmRegistroClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtpFechaRegistro.Value = Date.Today
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        Dim query As String = "SELECT * FROM Clientes"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                Dim adaptador As New OleDbDataAdapter(query, conexion)
                Dim dataset As New DataSet()

                adaptador.Fill(dataset, "TablaClientes")

                DgvCliente.DataSource = dataset.Tables("TablaClientes")

                DgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DgvCliente.ReadOnly = True
                DgvCliente.AllowUserToAddRows = False
                If DgvCliente.Columns.Contains("ID_Cliente") Then
                    DgvCliente.Columns("ID_Cliente").Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If String.IsNullOrEmpty(TxtNombre.Text) Then
            MessageBox.Show("Por favor ingrese el nombre completo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtNombre.Focus()
            Return
        End If

        If String.IsNullOrEmpty(TxtCedula.Text) Then
            MessageBox.Show("Por favor ingrese la cédula", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtCedula.Focus()
            Return
        End If

        Using conexion As New OleDbConnection(connectionString)
            conexion.Open()
            Try
                Dim query2 As String = "INSERT INTO Clientes (NombreComp, Cedula, FechaRegistro) VALUES (@Nombre, @Cedula, @Fecha)"
                Using comando As New OleDbCommand(query2, conexion)
                    comando.Parameters.AddWithValue("@Nombre", TxtNombre.Text)
                    comando.Parameters.AddWithValue("@Cedula", TxtCedula.Text)
                    comando.Parameters.AddWithValue("@Fecha", dtpFechaRegistro.Value)

                    Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                    If filasAfectadas > 0 Then
                        MessageBox.Show("Cliente guardado exitosamente. Filas afectadas: " & filasAfectadas.ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LimpiarCampos()
                        CargarDatos()
                    Else
                        MessageBox.Show("No se pudo guardar el cliente. Filas afectadas: " & filasAfectadas.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al guardar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub LimpiarCampos()
        TxtNombre.Clear()
        TxtCedula.Clear()
        dtpFechaRegistro.Value = Date.Today
        TxtNombre.Focus()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click

        If DgvCliente.SelectedRows.Count = 0 Then
            MessageBox.Show("Por favor seleccione un cliente para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cedulaCliente As String = ""
        Dim idCliente As Integer = 0
        Dim nombreCliente As String = ""
        Dim filaSeleccionada As DataGridViewRow = DgvCliente.SelectedRows(0)

        If filaSeleccionada.Cells("ID_Cliente").Value IsNot Nothing Then
            idCliente = CInt(filaSeleccionada.Cells("ID_Cliente").Value)
        End If

        If filaSeleccionada.Cells("NombreComp").Value IsNot Nothing Then
            nombreCliente = filaSeleccionada.Cells("NombreComp").Value.ToString()
        End If

        If filaSeleccionada.Cells("Cedula").Value IsNot Nothing Then
            cedulaCliente = filaSeleccionada.Cells("Cedula").Value.ToString()
        End If

        Dim respuesta As DialogResult = MessageBox.Show(
            "¿Está seguro de eliminar al cliente: " & nombreCliente & "?" & vbCrLf &
            "Cédula: " & cedulaCliente,
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If respuesta = DialogResult.Yes Then
            EliminarCliente(idCliente)
        End If
    End Sub

    Private Sub EliminarCliente(idCliente As Integer)
        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                Dim query As String = "DELETE FROM Clientes WHERE ID_Cliente = @ID"

                Using comando As New OleDbCommand(query, conexion)
                    comando.Parameters.AddWithValue("@ID", idCliente)

                    Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                    If filasAfectadas > 0 Then
                        MessageBox.Show("Cliente eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LimpiarCampos()
                        CargarDatos()
                    Else
                        MessageBox.Show("No se encontró el cliente para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al eliminar cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub DgvClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCliente.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DgvCliente.Rows(e.RowIndex)
            Dim idClienteSeleccionado As Integer = 0

            If fila.Cells("ID_Cliente").Value IsNot Nothing Then
                idClienteSeleccionado = CInt(fila.Cells("ID_Cliente").Value)
            Else
                idClienteSeleccionado = 0
            End If


            If fila.Cells("NombreComp").Value IsNot Nothing Then
                TxtNombre.Text = fila.Cells("NombreComp").Value.ToString()
            Else
                TxtNombre.Text = ""
            End If


            If fila.Cells("Cedula").Value IsNot Nothing Then
                TxtCedula.Text = fila.Cells("Cedula").Value.ToString()
            Else
                TxtCedula.Text = ""
            End If


            If fila.Cells("FechaRegistro").Value IsNot Nothing AndAlso IsDate(fila.Cells("FechaRegistro").Value) Then
                dtpFechaRegistro.Value = CDate(fila.Cells("FechaRegistro").Value)
            Else
                dtpFechaRegistro.Value = Date.Today
            End If
        End If
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        LimpiarCampos()
    End Sub
End Class