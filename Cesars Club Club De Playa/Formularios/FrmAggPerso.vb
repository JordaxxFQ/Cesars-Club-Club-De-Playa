Imports System.Data.Common
Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmAggPerso


    Dim ruta As String = IO.Path.Combine(Application.StartupPath, "DataBase", "BD Proyecto Final.accdb")
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
    Private Sub FrmAggPerso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


                adaptador.Fill(dataset, "TablaAgg")
                DataGridView1.DataSource = dataset.Tables("TablaAgg")

                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ReadOnly = True
                DataGridView1.AllowUserToAddRows = False
                DataGridView1.AutoGenerateColumns = True
            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        ' 1. Validar que los campos no estén vacíos
        If txtboxusuario.Text = "" Or txtboxContra.Text = "" Or txtRol.Text = "" Or txtTurno.Text = "" Then
            MessageBox.Show("Por favor, complete todos los campos.")
            Exit Sub
        End If

        ' 2. Definir la consulta SQL (Asegúrate de que los nombres coincidan con tu tabla en Access)
        ' Nota: No incluimos ID_Perso si es Autonumérico en Access
        Dim query As String = "INSERT INTO Personal (Usuario, Contraseña, Turno, ID_Rol) VALUES (?, ?, ?, ?)"

        Using conexion As New OleDbConnection(connectionString)
            Try
                Dim comando As New OleDbCommand(query, conexion)

                ' 3. Agregar los parámetros en el MISMO ORDEN que en el INSERT
                ' El "?" es un marcador de posición que evita errores de caracteres especiales
                comando.Parameters.AddWithValue("@usuario", txtboxusuario.Text)
                comando.Parameters.AddWithValue("@contra", txtboxContra.Text)
                comando.Parameters.AddWithValue("@Rol", txtRol.Text)
                comando.Parameters.AddWithValue("@turno", txtTurno.Text)
                conexion.Open()
                comando.ExecuteNonQuery() ' Ejecuta la inserción

                MessageBox.Show("¡Registro guardado exitosamente!")


                txtboxusuario.Clear()
                txtboxContra.Clear()
                txtRol.Clear()
                txtTurno.Clear()

                ' Opcional: Cerrar este formulario al terminar
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error al guardar: " & ex.Message)
            End Try
        End Using
    End Sub

End Class