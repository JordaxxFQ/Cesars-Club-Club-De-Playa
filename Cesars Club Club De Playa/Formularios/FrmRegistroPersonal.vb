Imports System.Data.Common
Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmRegistroPersonal

    Private Sub FrmRegistroPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarTablaDesdeCero()

        enlace()

    End Sub

    ' 2. CADENA DE CONEXIÓN PARA ACCESS
    ' Reemplaza RUTA_DE_TU_ARCHIVO por la ubicación real (ej: C:\BD\MiBase.accdb)
    Dim cadenaConexion As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\source\repos\Cesars-Club-Club-De-Playa\Cesars Club Club De Playa\DataBase\BD Proyecto Final.accdb;Persist Security Info=False;"

    Dim dsPersonal As DataSet
    Dim daPersonal As OleDbDataAdapter ' Cambiado a OleDb


    Public Sub CargarTablaDesdeCero()
        Try
            dsPersonal = New DataSet()

            ' Usamos OleDbConnection en lugar de SqlConnection
            Using conexion As New OleDbConnection(cadenaConexion)
                Dim sql As String = "SELECT * FROM Personal"
                daPersonal = New OleDbDataAdapter(sql, conexion)

                ' Llenar el DataSet
                daPersonal.Fill(dsPersonal, "Personal")

                ' Vincular al DataGridView (Asegúrate que se llame dgvPersonal en el diseño)
                dgvPersonal.DataSource = dsPersonal.Tables("Personal")

                dgvPersonal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar Access: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAgg_Click(sender As Object, e As EventArgs) Handles btnAgg.Click

    End Sub
End Class