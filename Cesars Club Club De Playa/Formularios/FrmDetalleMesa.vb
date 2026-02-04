Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmDetalleMesa

    Dim _idMesa As Integer
    Dim _idClienteEncontrado As Integer = 0

    Public Sub New(idMesa As Integer)
        InitializeComponent()
        _idMesa = idMesa
    End Sub

    Private Sub FrmDetalleMesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitulo.Text = "Gestionando Mesa Nro: " & _idMesa
        CargarDatos()
        CargarCapacidadMesa()
        ConfigurarDateTimePickers()
    End Sub

    Private Sub ConfigurarDateTimePickers()

        DtpHoraInicio.Format = DateTimePickerFormat.Time
        DtpHoraInicio.ShowUpDown = True ' Muestra flechitas arriba/abajo
        DtpHoraInicio.Value = DateTime.Today.AddHours(8) ' 8:00 AM por defecto
        DtpHoraInicio.CustomFormat = "hh:mm tt"

        ' Configurar DateTimePicker para Hora de Fin
        DtpHoraFin.Format = DateTimePickerFormat.Time
        DtpHoraFin.ShowUpDown = True
        DtpHoraFin.Value = DateTime.Today.AddHours(12) ' 12:00 PM por defecto
        DtpHoraFin.CustomFormat = "hh:mm tt"

        ' Opcional: Puedes usar CustomFormat para más control
        ' dtpHoraInicio.CustomFormat = "hh:mm tt"
        ' dtpHoraFin.CustomFormat = "hh:mm tt"
    End Sub

    Private Sub EliminarRegistro(id As Integer)
        Dim query As String = "DELETE FROM Reservas WHERE ID_Reserva = ?"

        Using conexion As New OleDbConnection(cadena)
            Try
                Dim comando As New OleDbCommand(query, conexion)
                comando.Parameters.AddWithValue("?", id)

                conexion.Open()
                Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                If filasAfectadas > 0 Then
                    MessageBox.Show("Se ha eliminado la reserva correctamente.")
                Else
                    MessageBox.Show("No se encontró el registro para eliminar.")
                End If

                CargarDatos()

            Catch ex As Exception
                MessageBox.Show("Error al eliminar: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub CargarDatos()
        Dim query As String = "SELECT * FROM Reservas"

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()

                Dim adaptador As New OleDbDataAdapter(query, conexion)
                Dim dataset As New DataSet()

                adaptador.Fill(dataset, "TablaReserva")
                TablaReserva2.DataSource = dataset.Tables("TablaReserva")

                TablaReserva2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                TablaReserva2.ReadOnly = True
                TablaReserva2.AllowUserToAddRows = False
                TablaReserva2.AutoGenerateColumns = True
            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub CargarCapacidadMesa()
        cmbCantPeople.Items.Clear()
        Dim capacidadMaxima As Integer = 0

        Dim query As String = "SELECT CantPersona FROM Zonas WHERE ID_Mesa = ?"

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()
                Dim cmd As New OleDbCommand(query, conexion)

                If _idMesa = 0 Then
                    MessageBox.Show("Error: No ha llegado el ID de la mesa al formulario.")
                    Exit Sub
                End If

                cmd.Parameters.Add("@id", OleDbType.Integer).Value = _idMesa

                Dim resultado = cmd.ExecuteScalar()

                If resultado IsNot Nothing AndAlso IsNumeric(resultado) Then
                    capacidadMaxima = CInt(resultado)
                Else
                    capacidadMaxima = 4
                End If

            Catch ex As Exception
                MessageBox.Show("Error leyendo capacidad: " & ex.Message)
                capacidadMaxima = 4
            End Try
        End Using

        If capacidadMaxima > 0 Then
            For i As Integer = 1 To capacidadMaxima
                cmbCantPeople.Items.Add(i.ToString())
            Next
            cmbCantPeople.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        If txtCedula.Text = "" Then
            MessageBox.Show("Por favor ingrese una cédula.")
            Exit Sub
        End If

        Dim query As String = "SELECT ID_Cliente, NombreComp FROM Clientes WHERE Cedula = ?"

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()
                Dim comando As New OleDbCommand(query, conexion)
                comando.Parameters.AddWithValue("?", txtCedula.Text)

                Dim lector As OleDbDataReader = comando.ExecuteReader()

                If lector.Read() Then
                    _idClienteEncontrado = CInt(lector("ID_Cliente"))
                    txtNombre.Text = lector("NombreComp").ToString()
                Else
                    Dim resultado = MessageBox.Show("Cliente no registrado. ¿Desea registrarlo ahora?", "Cliente no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If resultado = DialogResult.Yes Then
                        FrmRegistroClientes.ShowDialog()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error al buscar: " & ex.Message)
            End Try
        End Using
    End Sub

    ' ========== GUARDAR CON DATETIMEPICKER ==========
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If _idClienteEncontrado = 0 Then
            MessageBox.Show("Debe buscar un cliente válido primero.")
            Exit Sub
        End If

        If cmbCantPeople.Text = "" Then
            MessageBox.Show("Por favor seleccione la cantidad de personas.")
            Exit Sub
        End If

        ' USAR DateTimePicker directamente
        Dim horaInicio As DateTime = DtpHoraInicio.Value
        Dim horaFin As DateTime = DtpHoraFin.Value

        ' Validar que hora fin sea posterior a hora inicio
        If horaFin <= horaInicio Then
            MessageBox.Show("La hora de finalización debe ser posterior a la de inicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Calcular duración
        Dim duracion As TimeSpan = horaFin - horaInicio

        ' Opcional: Validar duración mínima y máxima
        If duracion.TotalMinutes < 30 Then
            MessageBox.Show("La reserva debe ser de al menos 30 minutos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If duracion.TotalHours > 8 Then
            MessageBox.Show("La reserva no puede exceder 8 horas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim queryReserva As String = "INSERT INTO Reservas (Cedula, NombreComp, ID_Cliente, ID_Mesa, FechaReserva, Horainicio, Horafin, EstadoReserva, CantPersona) " &
                                     "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim queryMesa As String = "UPDATE Zonas SET Estado = ? WHERE ID_Mesa = ?"

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()

                Dim cmdReserva As New OleDbCommand(queryReserva, conexion)

                cmdReserva.Parameters.Add("@ced", OleDbType.VarWChar).Value = txtCedula.Text
                cmdReserva.Parameters.Add("@nom", OleDbType.VarWChar).Value = txtNombre.Text
                cmdReserva.Parameters.Add("@idcli", OleDbType.Integer).Value = _idClienteEncontrado
                cmdReserva.Parameters.Add("@idmesa", OleDbType.Integer).Value = _idMesa
                cmdReserva.Parameters.Add("@fecha", OleDbType.Date).Value = DateTime.Now
                cmdReserva.Parameters.Add("@ini", OleDbType.Date).Value = horaInicio
                cmdReserva.Parameters.Add("@fin", OleDbType.Date).Value = horaFin
                cmdReserva.Parameters.Add("@est", OleDbType.VarWChar).Value = "Activa"
                cmdReserva.Parameters.Add("@pers", OleDbType.Integer).Value = CInt(cmbCantPeople.Text)

                cmdReserva.ExecuteNonQuery()

                Dim cmdMesa As New OleDbCommand(queryMesa, conexion)
                cmdMesa.Parameters.Add("@status", OleDbType.VarWChar).Value = "Reservada"
                cmdMesa.Parameters.Add("@id", OleDbType.Integer).Value = _idMesa

                cmdMesa.ExecuteNonQuery()

                MessageBox.Show($"¡Mesa reservada exitosamente!" & vbCrLf &
                               $"Duración: {duracion.Hours}h {duracion.Minutes}min",
                               "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error al reservar: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnLiberar_Click(sender As Object, e As EventArgs) Handles btnLiberar.Click
        Dim queryMesa As String = "UPDATE Zonas SET Estado = ? WHERE ID_Mesa = ?"

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()
                Dim cmdMesa As New OleDbCommand(queryMesa, conexion)

                cmdMesa.Parameters.Add("@est", OleDbType.VarWChar).Value = "Disponible"
                cmdMesa.Parameters.Add("@id", OleDbType.Integer).Value = _idMesa

                Dim filasAfectadas As Integer = cmdMesa.ExecuteNonQuery()

                If filasAfectadas > 0 Then
                    MessageBox.Show("Mesa liberada en la base de datos.")
                    Me.Close()
                Else
                    MessageBox.Show("No se encontró la mesa para actualizar.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error al liberar: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnOcupar_Click(sender As Object, e As EventArgs) Handles btnOcupar.Click
        Dim query As String = "UPDATE Zonas SET Estado = ? WHERE ID_Mesa = ?"

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()
                Dim cmd As New OleDbCommand(query, conexion)

                cmd.Parameters.Add("@est", OleDbType.VarWChar).Value = "Ocupada"
                cmd.Parameters.Add("@id", OleDbType.Integer).Value = _idMesa

                Dim filas As Integer = cmd.ExecuteNonQuery()

                If filas > 0 Then
                    MessageBox.Show("Mesa marcada como Ocupada")
                    Me.Close()
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btonDeleteReserv_Click(sender As Object, e As EventArgs) Handles btonDeleteReserv.Click
        If TablaReserva2.SelectedRows.Count > 0 Then

            Dim idSeleccionado As Integer = Convert.ToInt32(TablaReserva2.SelectedRows(0).Cells("ID_Reserva").Value)
            Dim nombreUsuario As String = TablaReserva2.SelectedRows(0).Cells("NombreComp").Value.ToString()

            Dim respuesta As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar a " & nombreUsuario & " de la mesa?",
                                                            "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If respuesta = DialogResult.Yes Then
                EliminarRegistro(idSeleccionado)

                Dim queryMesa As String = "UPDATE Zonas SET Estado = ? WHERE ID_Mesa = ?"
                Using conexion As New OleDbConnection(cadena)
                    conexion.Open()
                    Dim cmdMesa As New OleDbCommand(queryMesa, conexion)
                    cmdMesa.Parameters.Add("@status", OleDbType.VarWChar).Value = "Mantenimiento"
                    cmdMesa.Parameters.Add("@id", OleDbType.Integer).Value = _idMesa
                    cmdMesa.ExecuteNonQuery()
                End Using
            End If

        Else
            MessageBox.Show("Por favor, seleccione una fila completa haciendo clic en la barra de la izquierda.")
        End If
    End Sub

End Class