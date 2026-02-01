Imports System.Data.Common
Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmRegistroPersonal

    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

    Private Sub FrmRegistroPersonal_Load(sender As Object, e As EventArgs) Handles Me.Load
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
                DgvPersonal.DataSource = dataset.Tables("TablaPersonal")

                DgvPersonal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DgvPersonal.ReadOnly = True
                DgvPersonal.AllowUserToAddRows = False
                DgvPersonal.AutoGenerateColumns = True
                ' Ocultamos la columna ID para que se vea más limpio (opcional)
                If DgvPersonal.Columns.Contains("ID_Personal") Then
                    DgvPersonal.Columns("ID_Personal").Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DgvPersonal.SelectedRows.Count > 0 Then

            ' 2. Obtener el ID de la fila seleccionada (ID_Perso está en la primera columna, índice 0)
            Dim idSeleccionado As Integer = Convert.ToInt32(DgvPersonal.SelectedRows(0).Cells("ID_Personal").Value)
            Dim nombreUsuario As String = DgvPersonal.SelectedRows(0).Cells("Usuario").Value.ToString()

            ' 3. Preguntar al usuario si está seguro (Validación de seguridad)
            Dim respuesta As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar a " & nombreUsuario & "?",
                                                            "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If respuesta = DialogResult.Yes Then
                EliminarRegistro(idSeleccionado)
            End If

        Else
            MessageBox.Show("Por favor, seleccione una fila completa haciendo clic en la barra de la izquierda.")
        End If
    End Sub
    Private Sub EliminarRegistro(id As Integer)
        ' En Access, a veces es mejor no usar nombres en los parámetros, sino solo el signo ?
        Dim query As String = "DELETE FROM Personal WHERE ID_Personal = ?"

        Using conexion As New OleDbConnection(connectionString)
            Try
                Dim comando As New OleDbCommand(query, conexion)

                ' IMPORTANTE: El nombre del parámetro aquí no importa tanto como el ORDEN
                ' Pero nos aseguramos de que el ID sea un entero claro
                comando.Parameters.AddWithValue("?", id)

                conexion.Open()
                Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                If filasAfectadas > 0 Then
                    MessageBox.Show("Usuario eliminado correctamente.")
                Else
                    MessageBox.Show("No se encontró el registro para eliminar.")
                End If

                CargarDatos() ' Refrescar la tabla

            Catch ex As Exception
                MessageBox.Show("Error al eliminar: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnAgg_Click(sender As Object, e As EventArgs) Handles btnAgg.Click

        Dim ventanaAgregar As New FrmAggPerso()

        ventanaAgregar.ShowDialog()

        CargarDatos()
    End Sub

End Class