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

    Private Sub FrmDetalleMesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitulo.Text = "Gestionando Mesa Nro: " & _idMesa

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

                Dim cmdReserva As New OleDbCommand(queryReserva, conexion)

                cmdReserva.Parameters.Add("@idcli", OleDbType.Integer).Value = _idClienteEncontrado
                cmdReserva.Parameters.Add("@ced", OleDbType.VarWChar).Value = txtCedula.Text
                cmdReserva.Parameters.Add("@nom", OleDbType.VarWChar).Value = txtNombre.Text
                cmdReserva.Parameters.Add("@idmesa", OleDbType.Integer).Value = _idMesa
                cmdReserva.Parameters.Add("@fecha", OleDbType.Date).Value = DateTime.Now
                cmdReserva.Parameters.Add("@est", OleDbType.VarWChar).Value = "Activa"

                cmdReserva.ExecuteNonQuery()
                Dim cmdMesa As New OleDbCommand(queryMesa, conexion)
                cmdMesa.Parameters.Add("@status", OleDbType.VarWChar).Value = "Reservada"
                cmdMesa.Parameters.Add("@id", OleDbType.Integer).Value = _idMesa

                cmdMesa.ExecuteNonQuery()

                MessageBox.Show("¡Mesa reservada exitosamente con los datos del cliente!")
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

                ' IMPORTANTE: En OLEDB el orden de los parámetros debe ser el mismo que los "?"
                ' 1er "?" es el Estado (Disponible)
                cmdMesa.Parameters.Add("@est", OleDbType.VarWChar).Value = "Disponible"
                ' 2do "?" es el ID de la mesa
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
End Class