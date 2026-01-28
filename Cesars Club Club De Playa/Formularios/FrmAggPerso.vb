Imports System.Data.Common
Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmAggPerso


    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
    Private Sub FrmAggPerso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        enlace()
        CargarTurno()
        CargarRoles()
        CargarDatos()

    End Sub


    Private Sub CargarTurno()
        Dim query As String = "SELECT DISTINCT Turno FROM Personal"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()
                Dim comando As New OleDbCommand(query, conexion)
                Dim lector As OleDbDataReader = comando.ExecuteReader()

                While lector.Read()

                    If Not IsDBNull(lector("Turno")) Then
                        cmbTurno.Items.Add(lector("Turno").ToString())
                    End If
                End While

                lector.Close()

            Catch ex As Exception
                MessageBox.Show("Error al cargar Turnos: " & ex.Message)
            End Try
        End Using
    End Sub


    Private Sub CargarRoles()
        ' Usamos DISTINCT para evitar duplicados desde la base de datos
        Dim query As String = "SELECT DISTINCT ID_Rol FROM Personal"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()
                Dim comando As New OleDbCommand(query, conexion)
                Dim lector As OleDbDataReader = comando.ExecuteReader()

                While lector.Read()
                    ' Solo agregamos si el valor no es nulo
                    If Not IsDBNull(lector("ID_Rol")) Then
                        cmbRol.Items.Add(lector("ID_Rol").ToString())
                    End If
                End While

                lector.Close()

            Catch ex As Exception
                MessageBox.Show("Error al cargar roles: " & ex.Message)
            End Try
        End Using
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
        If txtboxusuario.Text = "" Or txtboxContra.Text = "" Or cmbRol.Text = "" Or cmbTurno.Text = "" Then
            MessageBox.Show("Por favor, complete todos los campos.")
            Exit Sub
        End If



        Dim query As String = "INSERT INTO Personal (Usuario, Contraseña, ID_Rol, Turno) VALUES (?, ?, ?, ?)"

        Using conexion As New OleDbConnection(connectionString)
            Try
                Dim comando As New OleDbCommand(query, conexion)


                comando.Parameters.AddWithValue("@usuario", txtboxusuario.Text)
                comando.Parameters.AddWithValue("@contra", txtboxContra.Text)
                comando.Parameters.AddWithValue("@Rol", cmbRol.Text)
                comando.Parameters.AddWithValue("@turno", cmbTurno.Text)
                conexion.Open()
                comando.ExecuteNonQuery()

                MessageBox.Show("¡Registro guardado exitosamente!")


                txtboxusuario.Clear()
                txtboxContra.Clear()
                cmbTurno.Items.Clear()
                cmbRol.Items.Clear()
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error al guardar: " & ex.Message)
            End Try
        End Using
    End Sub

End Class