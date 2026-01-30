Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmDetalleMesa
    ' Variables para guardar los datos que recibimos y encontramos
    Dim _idMesa As Integer
    Dim _idClienteEncontrado As Integer = 0 ' Aquí guardaremos el ID si lo encontramos

    ' Tu cadena de conexión
    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

    ' Constructor que recibe el ID de la mesa
    Public Sub New(idMesa As Integer)
        InitializeComponent()
        _idMesa = idMesa
    End Sub

    Private Sub FrmDetalleMesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Asignamos el título ahora que ya creaste el Label
        lblTitulo.Text = "Gestionando Mesa Nro: " & _idMesa

        ' Bloqueamos el campo nombre para que no lo escriban manual, solo por búsqueda
        txtNombre.ReadOnly = True
    End Sub

    ' ==========================================
    ' BOTÓN BUSCAR CLIENTE
    ' ==========================================
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

    ' Botón Confirmar Reserva / Ocupar
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' 1. Validaciones de seguridad
        If _idClienteEncontrado = 0 Then
            MessageBox.Show("Debe buscar un cliente válido primero.")
            Exit Sub
        End If

        ' IMPORTANTE: Revisa que los nombres 'Cedula' y 'Nombre' sean exactos a tu tabla Access
        Dim queryReserva As String = "INSERT INTO Reservas (ID_Cliente, Cedula, NombreComp, ID_Mesa, FechaReserva, EstadoReserva) VALUES (?, ?, ?, ?, ?, ?)"
        Dim queryMesa As String = "UPDATE Zonas SET Estado = ? WHERE ID_Mesa = ?"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                ' --- GUARDAR LA RESERVA ---
                Dim cmdReserva As New OleDbCommand(queryReserva, conexion)

                ' Agregamos los parámetros en el orden exacto de los "?" en el INSERT
                cmdReserva.Parameters.Add("@idcli", OleDbType.Integer).Value = _idClienteEncontrado
                cmdReserva.Parameters.Add("@ced", OleDbType.VarWChar).Value = txtCedula.Text ' <--- Captura directa del TextBox
                cmdReserva.Parameters.Add("@nom", OleDbType.VarWChar).Value = txtNombre.Text ' <--- Captura directa del TextBox
                cmdReserva.Parameters.Add("@idmesa", OleDbType.Integer).Value = _idMesa
                cmdReserva.Parameters.Add("@fecha", OleDbType.Date).Value = DateTime.Now
                cmdReserva.Parameters.Add("@est", OleDbType.VarWChar).Value = "Activa"

                cmdReserva.ExecuteNonQuery()

                ' --- ACTUALIZAR EL ESTADO DE LA MESA EN EL PANEL ---
                Dim cmdMesa As New OleDbCommand(queryMesa, conexion)

                ' En el UPDATE: primer "?" es Estado, segundo "?" es ID_Mesa
                cmdMesa.Parameters.Add("@status", OleDbType.VarWChar).Value = "Reservada"
                cmdMesa.Parameters.Add("@id", OleDbType.Integer).Value = _idMesa

                cmdMesa.ExecuteNonQuery()

                MessageBox.Show("¡Mesa reservada exitosamente con los datos del cliente!")
                Me.Close()

            Catch ex As Exception
                ' Si sale "Data type mismatch", verifica que los campos en Access sean 'Texto corto'
                MessageBox.Show("Error al reservar: " & ex.Message)
            End Try
        End Using
    End Sub


    Private Sub ActualizarEstadoMesa(nuevoEstado As String)
        ' Código SQL UPDATE Zonas SET Estado = @estado WHERE ID_Mesa = @id...
        ' Usando _idMesa y nuevoEstado
        ' End Using
    End Sub

End Class