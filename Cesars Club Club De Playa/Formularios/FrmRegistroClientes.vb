Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmRegistroClientes
    ' Asegúrate de que esta ruta sea correcta. 
    ' Application.StartupPath suele ser la carpeta bin/Debug
    Dim ruta As String = IO.Path.Combine(Application.StartupPath, "DataBase", "BD Proyecto Final.accdb")

    ' Cadena de conexión (necesitas definir el Provider correctamente)
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

    Private Sub FrmRegistroClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        enlace() ' Asumo que esto configura algo global, lo dejamos.
        dtpFechaRegistro.Value = Date.Today

        ' LLAMAMOS AL MÉTODO PARA CARGAR DATOS AL INICIAR
        CargarDatos()
    End Sub

    ' Creamos un Sub dedicado solo a cargar la tabla
    Private Sub CargarDatos()
        Dim query As String = "SELECT * FROM Clientes"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open() ' Es buena práctica abrir la conexión explícitamente

                ' Crear adaptador y dataset
                Dim adaptador As New OleDbDataAdapter(query, conexion)
                Dim dataset As New DataSet()

                ' Llenar dataset
                adaptador.Fill(dataset, "TablaClientes")

                ' Asignar al DataGridView
                DataGridView1.DataSource = dataset.Tables("TablaClientes")

                ' Configurar DataGridView
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ReadOnly = True
                DataGridView1.AllowUserToAddRows = False ' Evita la fila vacía al final

            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub

    ' Este evento ya no se necesita para cargar, puedes dejarlo vacío o borrarlo
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub FrmRegistroClientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub
End Class