Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmDetalleMesa

    Dim _idMesa As Integer
    Dim _idClienteEncontrado As Integer = 0
    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

    Public Sub New(idMesa As Integer)
        InitializeComponent()
        _idMesa = idMesa
    End Sub
    Private Sub EliminarRegistro(id As Integer)
        Dim query As String = "DELETE FROM Reservas WHERE ID_Reserva = ?"

        Using conexion As New OleDbConnection(connectionString)
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

                CargarDatos() ' Refrescar la tabla

            Catch ex As Exception
                MessageBox.Show("Error al eliminar: " & ex.Message)
            End Try
        End Using
    End Sub
    Private Sub CargarDatos()
        Dim query As String = "SELECT * FROM Reservas"

        Using conexion As New OleDbConnection(connectionString)
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

        ' VERIFICA QUE "ID_Mesa" y "Capacidad" ESTÉN ESCRITOS IGUAL QUE EN TU ACCESS
        Dim query As String = "SELECT CantPersona FROM Zonas WHERE ID_Mesa = ?"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()
                Dim cmd As New OleDbCommand(query, conexion)

                ' Aseguramos que _idMesa tenga valor. Si es 0, fallará.
                If _idMesa = 0 Then
                    MessageBox.Show("Error: No ha llegado el ID de la mesa al formulario.")
                    Exit Sub
                End If

                ' Enviamos el parámetro explícitamente como Entero
                cmd.Parameters.Add("@id", OleDbType.Integer).Value = _idMesa

                Dim resultado = cmd.ExecuteScalar()

                ' Validación extra por si devuelve Nulo
                If resultado IsNot Nothing AndAlso IsNumeric(resultado) Then
                    capacidadMaxima = CInt(resultado)
                Else
                    capacidadMaxima = 4 ' Valor por defecto si la celda está vacía en Access
                End If

            Catch ex As Exception
                MessageBox.Show("Error leyendo capacidad (Verifique nombres de columnas en Access): " & ex.Message)
                capacidadMaxima = 4
            End Try
        End Using

        ' Llenar el combo
        If capacidadMaxima > 0 Then
            For i As Integer = 1 To capacidadMaxima
                cmbCantPeople.Items.Add(i.ToString())
            Next
            cmbCantPeople.SelectedIndex = 0
        End If
    End Sub
    Private Sub CargarHorarios()
        cmbHoraInicio.Items.Clear()
        cmbHoraFin.Items.Clear()

        ' Definimos desde qué hora abre y cierra el local (Formato 24h para el ciclo)
        Dim horaApertura As Integer = 8  ' 8:00 AM
        Dim horaCierre As Integer = 23   ' 11:00 PM

        For i As Integer = horaApertura To horaCierre
            ' Convertimos formato 24h a formato 12h AM/PM
            Dim horaTexto As String = DateTime.Today.AddHours(i).ToString("hh:00 tt")

            cmbHoraInicio.Items.Add(horaTexto)
            cmbHoraFin.Items.Add(horaTexto)
        Next
    End Sub

    Private Sub FrmDetalleMesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitulo.Text = "Gestionando Mesa Nro: " & _idMesa
        enlace()
        CargarDatos()
        CargarCapacidadMesa()
        CargarHorarios()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        If txtCedula.Text = "" Then
            MessageBox.Show("Por favor ingrese una cédula.")
            Exit Sub
        End If

        Dim query As String = "SELECT ID_Cliente, NombreComp FROM Clientes WHERE Cedula = ?"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()
                Dim comando As New OleDbCommand(query, conexion)
                comando.Parameters.AddWithValue("?", txtCedula.Text)

                Dim lector As OleDbDataReader = comando.ExecuteReader()

                If lector.Read() Then
                    _idClienteEncontrado = CInt(lector("ID_Cliente"))
                    txtNombre.Text = lector("NombreComp").ToString() & " "
                Else
                    MessageBox.Show("Cliente no registrado. Por favor regístrelo primero.")
                    _idClienteEncontrado = 0
                    txtNombre.Clear()
                    FrmRegistroClientes.Show()
                End If

            Catch ex As Exception
                MessageBox.Show("Error al buscar: " & ex.Message)
            End Try
        End Using
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If _idClienteEncontrado = 0 Then
            MessageBox.Show("Debe buscar un cliente válido primero.")
            Exit Sub
        End If

        If cmbHoraInicio.Text = "" Or cmbHoraFin.Text = "" Or cmbCantPeople.Text = "" Then
            MessageBox.Show("Por favor complete todos los campos de horario y personas.")
            Exit Sub
        End If

        Dim horaIni As DateTime = DateTime.Parse(cmbHoraInicio.Text)
        Dim horaFn As DateTime = DateTime.Parse(cmbHoraFin.Text)
        Dim queryReserva As String = "INSERT INTO Reservas (Cedula, NombreComp, ID_Cliente, ID_Mesa, FechaReserva,  Horainicio, Horafin, EstadoReserva, CantPersona) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim queryMesa As String = "UPDATE Zonas SET Estado = ? WHERE ID_Mesa = ?"

        If horaFn <= horaIni Then
            MessageBox.Show("La hora de finalización debe ser posterior a la de inicio.")
            Exit Sub
        End If

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                Dim cmdReserva As New OleDbCommand(queryReserva, conexion)


                cmdReserva.Parameters.Add("@ced", OleDbType.VarWChar).Value = txtCedula.Text
                cmdReserva.Parameters.Add("@nom", OleDbType.VarWChar).Value = txtNombre.Text
                cmdReserva.Parameters.Add("@idcli", OleDbType.Integer).Value = _idClienteEncontrado
                cmdReserva.Parameters.Add("@idmesa", OleDbType.Integer).Value = _idMesa
                cmdReserva.Parameters.Add("@fecha", OleDbType.Date).Value = DateTime.Now
                cmdReserva.Parameters.Add("@ini", OleDbType.Date).Value = DateTime.Parse(cmbHoraInicio.Text)
                cmdReserva.Parameters.Add("@fin", OleDbType.Date).Value = DateTime.Parse(cmbHoraFin.Text)
                cmdReserva.Parameters.Add("@est", OleDbType.VarWChar).Value = "Activa"
                cmdReserva.Parameters.Add("@pers", OleDbType.Integer).Value = CInt(cmbCantPeople.Text)

                cmdReserva.ExecuteNonQuery()
                Dim cmdMesa As New OleDbCommand(queryMesa, conexion)
                cmdMesa.Parameters.Add("@status", OleDbType.VarWChar).Value = "Reservada"
                cmdMesa.Parameters.Add("@id", OleDbType.Integer).Value = _idMesa

                cmdMesa.ExecuteNonQuery()

                MessageBox.Show("¡Mesa reservada exitosamente en el sistema!")
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error al reservar: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnLiberar_Click(sender As Object, e As EventArgs) Handles btnLiberar.Click
        Dim queryMesa As String = "UPDATE Zonas SET Estado = ? WHERE ID_Mesa = ?"

        Using conexion As New OleDbConnection(connectionString)
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

        Using conexion As New OleDbConnection(connectionString)
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
        Dim queryMesa As String = "UPDATE Zonas SET Estado = ? WHERE ID_Mesa = ?"
        If TablaReserva2.SelectedRows.Count > 0 Then

            ' 2. Obtener el ID de la fila seleccionada (ID_Perso está en la primera columna, índice 0)
            Dim idSeleccionado As Integer = Convert.ToInt32(TablaReserva2.SelectedRows(0).Cells("ID_Reserva").Value)
            Dim nombreUsuario As String = TablaReserva2.SelectedRows(0).Cells("NombreComp").Value.ToString()
            ' 3. Preguntar al usuario si está seguro (Validación de seguridad)
            Dim respuesta As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar a " & nombreUsuario & "de la mesa?",
                                                            "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)


            If respuesta = DialogResult.Yes Then
                EliminarRegistro(idSeleccionado)
                Dim cmdMesa As New OleDbCommand(queryMesa, conexion)
                cmdMesa.Parameters.Add("@status", OleDbType.VarWChar).Value = "Mantenimiento"
                cmdMesa.Parameters.Add("@id", OleDbType.Integer).Value = _idMesa

                cmdMesa.ExecuteNonQuery()
            End If

        Else
            MessageBox.Show("Por favor, seleccione una fila completa haciendo clic en la barra de la izquierda.")
        End If


    End Sub

End Class