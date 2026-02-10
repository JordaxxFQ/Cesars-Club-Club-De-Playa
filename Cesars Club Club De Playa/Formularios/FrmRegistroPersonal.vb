Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmRegistroPersonal

    Private Sub FrmRegistroPersonal_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarDatos()
    End Sub
    ' Este método carga los datos de la tabla "Personal" y los muestra en el DgvPersonal
    Private Sub CargarDatos()
        Dim query As String = "SELECT * FROM Personal"

        Using conexion As New OleDbConnection(cadena)
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
                If DgvPersonal.Columns.Contains("ID_Personal") Then
                    DgvPersonal.Columns("ID_Personal").Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show("Error al cargar datos: " & ex.Message)
            End Try
        End Using
    End Sub

    'Cuando se hace clic en el botón "Eliminar". Verifica si hay una fila seleccionada, muestra un mensaje de confirmación y llama a la función para eliminar el registro si el usuario confirma.
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DgvPersonal.SelectedRows.Count > 0 Then
            Dim idSeleccionado As Integer = Convert.ToInt32(DgvPersonal.SelectedRows(0).Cells("ID_Personal").Value)
            Dim nombreUsuario As String = DgvPersonal.SelectedRows(0).Cells("Usuario").Value.ToString()


            Dim respuesta As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar a " & nombreUsuario & "?",
                                                            "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If respuesta = DialogResult.Yes Then
                EliminarPersonal(idSeleccionado)
            End If
        Else
            MessageBox.Show("Por favor, seleccione una fila completa haciendo clic en la barra de la izquierda.")
        End If
    End Sub
    'Esta función se encarga de eliminar el registro del personal en la base de datos utilizando el ID proporcionado.
    'Después de eliminar, se recarga la tabla para reflejar los cambios.
    Private Sub EliminarPersonal(id As Integer)
        Dim query As String = "DELETE FROM Personal WHERE ID_Personal = ?"

        Using conexion As New OleDbConnection(cadena)
            Try
                Dim comando As New OleDbCommand(query, conexion)
                comando.Parameters.AddWithValue("?", id)
                conexion.Open()
                Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                If filasAfectadas > 0 Then
                    MessageBox.Show("Usuario eliminado correctamente.")
                Else
                    MessageBox.Show("No se encontró el registro para eliminar.")
                End If

                CargarDatos() ' Refrescamos la tabla paraa que se actualice la vista después de eliminar

            Catch ex As Exception
                MessageBox.Show("Error al eliminar: " & ex.Message)
            End Try
        End Using
    End Sub

    'Este evento se activa al hacer clic en el botón "Agregar".
    'Abre el formulario FrmAggPerso para agregar un nuevo registro. Después de cerrar ese formulario, se recarga la tabla para mostrar el nuevo registro agregado.
    Private Sub BtnAgg_Click(sender As Object, e As EventArgs) Handles btnAgg.Click

        Dim ventanaAgregar As New FrmAggPerso()
        ventanaAgregar.ShowDialog()
        CargarDatos()
    End Sub

End Class