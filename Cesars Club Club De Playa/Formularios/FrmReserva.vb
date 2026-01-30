Imports System.Data.Common
Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmReserva
    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
    Private Sub FrmReserva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enlace()

        CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Dim query As String = "SELECT * FROM Reservas"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                Dim adaptador As New OleDbDataAdapter(query, conexion)
                Dim dataset As New DataSet()


                adaptador.Fill(dataset, "TablaReserva")
                TablaReserva.DataSource = dataset.Tables("TablaReserva")

                TablaReserva.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                TablaReserva.ReadOnly = True
                TablaReserva.AllowUserToAddRows = False
                TablaReserva.AutoGenerateColumns = True
            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub
End Class