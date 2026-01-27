Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmRegistroClientes
    Dim ruta As String = IO.Path.Combine(Application.StartupPath, "DataBase", "BD Proyecto Final.accdb")

    Private Sub FrmRegistroClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        enlace()
        dtpFechaRegistro.Value = Date.Today

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim query As String = "SELECT * FROM Clientes"

        Using conexion As New OleDbConnection(ruta)
            Try
                ' Crear adaptador y dataset
                Dim adaptador As New OleDbDataAdapter(query, conexion)
                Dim dataset As New DataSet()

                ' Llenar dataset
                adaptador.Fill(dataset, "TablaClientes")

                ' Asignar al DataGridView
                DataGridView1.DataSource = dataset.Tables("TablaClientes")

                ' Configurar DataGridView (opcional)
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ReadOnly = True ' Solo lectura

            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub FrmRegistroClientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub
End Class