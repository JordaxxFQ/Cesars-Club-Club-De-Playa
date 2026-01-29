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

        ' Asumo que tu tabla de clientes tiene campos: ID_Cliente, Cedula, Nombre, Apellido
        Dim query As String = "SELECT ID_Cliente, NombreComp FROM Clientes WHERE Cedula = ?"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()
                Dim comando As New OleDbCommand(query, conexion)
                comando.Parameters.AddWithValue("?", txtCedula.Text)

                Dim lector As OleDbDataReader = comando.ExecuteReader()

                If lector.Read() Then
                    ' ¡ENCONTRADO!
                    ' 1. Guardamos el ID en la variable oculta para usarla al reservar
                    _idClienteEncontrado = CInt(lector("ID_Cliente"))

                    ' 2. Mostramos el nombre en el TextBox visual
                    txtNombre.Text = lector("NombreComp").ToString() & " "
                Else
                    ' NO ENCONTRADO
                    MessageBox.Show("Cliente no registrado. Por favor regístrelo primero.")
                    _idClienteEncontrado = 0
                    txtNombre.Clear()

                    ' Opcional: Aquí podrías abrir el formulario de agregar cliente
                    FrmRegistroClientes.Show()
                End If

            Catch ex As Exception
                MessageBox.Show("Error al buscar: " & ex.Message)
            End Try
        End Using
    End Sub

    ' Botón Confirmar Reserva / Ocupar
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Validaciones previas
        If _idClienteEncontrado = 0 Then
            MessageBox.Show("Debe buscar y seleccionar un cliente válido primero.")
            Exit Sub
        End If

        ' Consulta para insertar en tu tabla RESERVAS (Segun tu imagen)
        ' Access pone la fecha/hora actual con la función Now()
        Dim queryReserva As String = "INSERT INTO Reservas (ID_Cliente, ID_Mesa, FechaReserva, EstadoReserva) VALUES (?, ?, ?, ?)"

        ' Consulta para cambiar el color de la mesa en ZONAS
        Dim queryMesa As String = "UPDATE Zonas SET Estado = 'Reservada' WHERE ID_Mesa = ?"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                ' 1. Guardamos la Reserva
                Dim cmdReserva As New OleDbCommand(queryReserva, conexion)
                cmdReserva.Parameters.AddWithValue("@cli", _idClienteEncontrado)
                cmdReserva.Parameters.AddWithValue("@mesa", _idMesa)
                cmdReserva.Parameters.AddWithValue("@fecha", DateTime.Now) ' Fecha de hoy
                cmdReserva.Parameters.AddWithValue("@estado", "Activa")
                cmdReserva.ExecuteNonQuery()

                ' 2. Actualizamos el estado de la mesa (Para que se ponga Amarilla/Roja)
                Dim cmdMesa As New OleDbCommand(queryMesa, conexion)
                cmdMesa.Parameters.AddWithValue("@id", _idMesa)
                cmdMesa.ExecuteNonQuery()

                MessageBox.Show("Reserva creada con éxito.")
                Me.Close() ' Cerramos para volver al panel de mesas

            Catch ex As Exception
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