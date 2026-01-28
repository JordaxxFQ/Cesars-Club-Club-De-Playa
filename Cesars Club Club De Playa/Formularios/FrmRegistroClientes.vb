Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmRegistroClientes

    Dim ruta As String = IO.Path.Combine(Application.StartupPath, "DataBase", "BD Proyecto Final.accdb")
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

    Private Sub FrmRegistroClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtpFechaRegistro.Value = Date.Today
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        Dim query As String = "SELECT * FROM Clientes"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                Dim adaptador As New OleDbDataAdapter(query, conexion)
                Dim dataset As New DataSet()

                adaptador.Fill(dataset, "TablaClientes")

                DataGridView1.DataSource = dataset.Tables("TablaClientes")

                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ReadOnly = True
                DataGridView1.AllowUserToAddRows = False

            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        If String.IsNullOrEmpty(TxtNombre.Text) Then
            MessageBox.Show("Por favor ingrese el nombre completo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtNombre.Focus()
            Return
        End If

        If String.IsNullOrEmpty(TxtCedula.Text) Then
            MessageBox.Show("Por favor ingrese la cédula", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtCedula.Focus()
            Return
        End If

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()

                Dim query2 As String = "INSERT INTO Clientes (NombreComp, Cedula, FechaRegistro) VALUES (@Nombre, @Cedula, @Fecha)"

                Using comando As New OleDbCommand(query2, conexion)

                    comando.Parameters.AddWithValue("@Nombre", TxtNombre.Text)
                    comando.Parameters.AddWithValue("@Cedula", TxtCedula.Text)
                    comando.Parameters.AddWithValue("@Fecha", dtpFechaRegistro.Value)

                    Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                    If filasAfectadas > 0 Then
                        MessageBox.Show("Cliente guardado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        LimpiarCampos()
                        CargarDatos()
                    Else
                        MessageBox.Show("No se pudo guardar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show("Error al guardar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub LimpiarCampos()
        TxtNombre.Clear()
        TxtCedula.Clear()
        dtpFechaRegistro.Value = Date.Today
        TxtNombre.Focus()
    End Sub

    Private Sub FrmRegistroClientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If conexion.State = ConnectionState.Open Then
            conexion.Close()
        End If

    End Sub

End Class