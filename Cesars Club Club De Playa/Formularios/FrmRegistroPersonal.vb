Imports System.Data.Common
Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmRegistroPersonal

    Dim ruta As String = IO.Path.Combine(Application.StartupPath, "DataBase", "BD Proyecto Final.accdb")
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

    Private Sub FrmRegistroPersonal_Load(sender As Object, e As EventArgs) Handles Me.Load
        enlace()

        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        Dim query As String = "SELECT * FROM Personal"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                Dim adaptador As New OleDbDataAdapter(query, conexion)
                Dim dataset As New DataSet()


                adaptador.Fill(dataset, "TablaPersonal")
                DataGridView1.DataSource = dataset.Tables("TablaPersonal")

                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ReadOnly = True
                DataGridView1.AllowUserToAddRows = False
                DataGridView1.AutoGenerateColumns = True
            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnAgg_Click(sender As Object, e As EventArgs) Handles btnAgg.Click

    End Sub
End Class