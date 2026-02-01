Imports System.Data.OleDb
Public Class FrmAggPerso


    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
    Dim idPersonalSeleccionado As Integer = 0
    Private Sub FrmAggPerso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbRol.Items.Add("Gerente")
        cmbRol.Items.Add("Cocinero")
        cmbRol.Items.Add("Recepcionista")
        cmbRol.Items.Add("Caja")
        CargarTurno()
        CargarDatos()

    End Sub
    Private Sub LimpiarCampos()
        txtboxusuario.Clear()
        cmbRol.SelectedIndex = -1
        cmbTurno.SelectedIndex = -1
        txtboxContra.Clear()
        idPersonalSeleccionado = 0
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

    Private Sub CargarDatos()
        Dim query As String = "SELECT * FROM Personal"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                Dim adaptador As New OleDbDataAdapter(query, conexion)
                Dim dataset As New DataSet()

                adaptador.Fill(dataset, "TablaAggPersonal")
                DgvPersonal.DataSource = dataset.Tables("TablaAggPersonal")

                DgvPersonal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DgvPersonal.ReadOnly = True
                DgvPersonal.AllowUserToAddRows = False
                DgvPersonal.AutoGenerateColumns = True

                If DgvPersonal.Columns.Contains("ID_Personal") Then
                    DgvPersonal.Columns("ID_Personal").Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub
    Private Sub DgvPersonal_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPersonal.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DgvPersonal.Rows(e.RowIndex)
            idPersonalSeleccionado = CInt(fila.Cells("ID_Personal").Value)

            txtboxusuario.Text = fila.Cells("Usuario").Value.ToString()
            txtboxContra.Text = fila.Cells("Contraseña").Value.ToString()
            cmbRol.Text = fila.Cells("ID_Rol").Value.ToString()
            cmbTurno.Text = fila.Cells("Turno").Value.ToString()

        End If
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

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If idPersonalSeleccionado = 0 Then
            MessageBox.Show("Seleccione el Personal a modificar.")
            Exit Sub
        End If

        Dim query As String = "UPDATE Personal SET Usuario=?, Contraseña=?, ID_Rol=?, Turno=? WHERE ID_Personal=?"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()
                Dim cmd As New OleDbCommand(query, conexion)

                cmd.Parameters.AddWithValue("@usuario", txtboxusuario.Text)
                cmd.Parameters.AddWithValue("@contra", txtboxContra.Text)
                cmd.Parameters.AddWithValue("@Rol", cmbRol.Text)
                cmd.Parameters.AddWithValue("@turno", cmbTurno.Text)

                cmd.Parameters.Add("@id", OleDbType.Integer).Value = idPersonalSeleccionado

                cmd.ExecuteNonQuery()
                MessageBox.Show("Producto actualizado con éxito, incluyendo estado de venta.")

                CargarDatos()
                LimpiarCampos()


            Catch ex As Exception
                MessageBox.Show("Error al modificar: " & ex.Message)
            End Try
        End Using
    End Sub
End Class