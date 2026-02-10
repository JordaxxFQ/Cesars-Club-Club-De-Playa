Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmAggPerso

    Dim idPersonalSeleccionado As Integer = 0
    Private Sub FrmAggPerso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbRol.Items.Add("Gerente")
        cmbRol.Items.Add("Cocinero")
        cmbRol.Items.Add("Recepcionista")
        cmbRol.Items.Add("Caja")
        cmbTurno.Items.Add("Diurno")
        cmbTurno.Items.Add("Nocturno")
        CargarDatos()

    End Sub
    Private Sub LimpiarCampos()
        txtboxusuario.Clear()
        cmbRol.SelectedIndex = -1
        cmbTurno.SelectedIndex = -1
        TxtContraseña.Clear()
        idPersonalSeleccionado = 0
    End Sub
    Private Sub CargarDatos()
        Dim query As String = "SELECT * FROM Personal"

        Using conexion As New OleDbConnection(cadena)
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

    Private Function UsuarioExiste(usuario As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM Personal WHERE Usuario = ?"
        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()
                Dim cmd As New OleDbCommand(query, conexion)
                cmd.Parameters.AddWithValue("@usuario", usuario)
                Return CInt(cmd.ExecuteScalar()) > 0
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function

    Private Sub DgvPersonal_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPersonal.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = DgvPersonal.Rows(e.RowIndex)
            idPersonalSeleccionado = CInt(fila.Cells("ID_Personal").Value)

            txtboxusuario.Text = fila.Cells("Usuario").Value.ToString()
            TxtContraseña.Text = fila.Cells("Contraseña").Value.ToString()
            cmbRol.Text = fila.Cells("ID_Rol").Value.ToString()
            cmbTurno.Text = fila.Cells("Turno").Value.ToString()

        End If
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles BtnConfirmar.Click

        ' 1. Validar que los campos no estén vacíos
        If UsuarioExiste(txtboxusuario.Text) = True Then
            MessageBox.Show("El nombre de usuario ya existe. Por favor, elija otro.")
            txtboxusuario.Focus()
            Exit Sub ' Aquí detenemos el código para que no guarde
        End If

        Dim query As String = "INSERT INTO Personal (Usuario, Contraseña, ID_Rol, Turno) VALUES (?, ?, ?, ?)"

        Using conexion As New OleDbConnection(cadena)
            Try

                Dim comando As New OleDbCommand(query, conexion)

                comando.Parameters.AddWithValue("@usuario", txtboxusuario.Text)
                comando.Parameters.AddWithValue("@contra", TxtContraseña.Text)
                comando.Parameters.AddWithValue("@Rol", cmbRol.Text)
                comando.Parameters.AddWithValue("@turno", cmbTurno.Text)
                conexion.Open()
                comando.ExecuteNonQuery()

                MessageBox.Show("¡Registro guardado exitosamente!")


                txtboxusuario.Clear()
                TxtContraseña.Clear()
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

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()
                Dim cmd As New OleDbCommand(query, conexion)

                cmd.Parameters.AddWithValue("@usuario", txtboxusuario.Text)
                cmd.Parameters.AddWithValue("@contra", TxtContraseña.Text)
                cmd.Parameters.AddWithValue("@Rol", cmbRol.Text)
                cmd.Parameters.AddWithValue("@turno", cmbTurno.Text)

                cmd.Parameters.Add("@id", OleDbType.Integer).Value = idPersonalSeleccionado

                cmd.ExecuteNonQuery()
                MessageBox.Show("Personal actualizado con éxito.")

                CargarDatos()
                LimpiarCampos()


            Catch ex As Exception
                MessageBox.Show("Error al modificar: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub txtboxusuario_keypress(sender As Object, e As KeyPressEventArgs) Handles txtboxusuario.KeyPress
        If e.KeyChar = Chr(13) Then
            TxtContraseña.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub TxtContraseña_Keypress(sender As Object, e As KeyPressEventArgs) Handles TxtContraseña.KeyPress
        If e.KeyChar = Chr(13) Then
            btnConfirmar_Click(sender, e)
            e.Handled = True
        End If
    End Sub
End Class