Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmDetalleMesa
    Dim _idMesa As Integer

    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
    ' Constructor personalizado para recibir el ID
    Public Sub New(idMesa As Integer)
        InitializeComponent()
        _idMesa = idMesa
    End Sub

    Private Sub FrmDetalleMesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitulo.Text = "Gestionando Mesa ID: " & _idMesa
        ' Aquí podrías consultar la BD para ver si la mesa ya tiene una reserva activa
        ' y llenar los datos automáticamente.
    End Sub

    ' Botón para buscar cliente por Cédula (Como lo pediste)
    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        Dim cedula As String = txtCedula.Text
        ' Haces un SELECT * FROM Clientes WHERE Cedula = ...
        ' Si existe, llenas txtNombre.Text
        ' Si no, le dices que lo registre.
    End Sub

    ' Botón Confirmar Reserva / Ocupar
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' 1. INSERTAR en la tabla Reservas o Pedidos
        ' INSERT INTO Reservas (ID_Mesa, ID_Cliente, EstadoReserva...) VALUES (_idMesa, ...)

        ' 2. ACTUALIZAR el estado de la mesa en Zonas
        ' UPDATE Zonas SET Estado = 'Ocupada' WHERE ID_Mesa = _idMesa

        ActualizarEstadoMesa("Ocupada") ' Llamas a un sub que haga el UPDATE

        MessageBox.Show("Mesa asignada correctamente")
        Me.Close()
    End Sub

    Private Sub ActualizarEstadoMesa(nuevoEstado As String)
        ' Código SQL UPDATE Zonas SET Estado = @estado WHERE ID_Mesa = @id...
        ' Usando _idMesa y nuevoEstado
        ' End Using
    End Sub

End Class