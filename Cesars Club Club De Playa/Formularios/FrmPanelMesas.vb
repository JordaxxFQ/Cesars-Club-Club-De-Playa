Imports System.Data.OleDb

Public Class FrmPanelMesas
    ' Tu cadena de conexión habitual
    Dim ruta As String = IO.Path.Combine(Application.StartupPath, "DataBase", "BD Proyecto Final.accdb")
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

    Private Sub FrmPanelMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarMesas()
    End Sub

    Public Sub CargarMesas()
        flpMesas.Controls.Clear() ' Limpiamos el panel antes de cargar

        Dim query As String = "SELECT ID_Mesa, NumeroMesa, Estado, Tipo FROM Zonas ORDER BY ID_Mesa"

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()
                Dim comando As New OleDbCommand(query, conexion)
                Dim lector As OleDbDataReader = comando.ExecuteReader()

                While lector.Read()
                    ' 1. Crear un nuevo botón por código
                    Dim btnMesa As New Button()

                    ' 2. Configurar su apariencia (Tamaño, Texto)
                    btnMesa.Width = 100
                    btnMesa.Height = 100
                    btnMesa.Text = lector("NumeroMesa").ToString() & vbCrLf & lector("Tipo").ToString()
                    btnMesa.TextAlign = ContentAlignment.BottomCenter

                    ' Puedes poner una imagen de mesa aquí si tienes una en tus Recursos
                    ' btnMesa.Image = My.Resources.imagen_mesa 

                    ' 3. GUARDAR EL ID DE LA MESA EN EL BOTÓN (Truco vital)
                    btnMesa.Tag = lector("ID_Mesa")

                    ' 4. Asignar color según el estado
                    Dim estado As String = lector("Estado").ToString()
                    Select Case estado
                        Case "Disponible" : btnMesa.BackColor = Color.DodgerBlue
                        Case "Ocupada" : btnMesa.BackColor = Color.Red
                        Case "Reservada" : btnMesa.BackColor = Color.Yellow
                        Case "Mantenimiento" : btnMesa.BackColor = Color.Gray
                    End Select

                    ' 5. Agregar el evento Click dinámicamente
                    AddHandler btnMesa.Click, AddressOf BotonMesa_Click

                    ' 6. Agregar el botón al panel
                    flpMesas.Controls.Add(btnMesa)
                End While
            Catch ex As Exception
                MessageBox.Show("Error al cargar mesas: " & ex.Message)
            End Try
        End Using
    End Sub

    ' Este evento se dispara al hacer clic en CUALQUIER mesa
    Private Sub BotonMesa_Click(sender As Object, e As EventArgs)
        ' Recuperamos qué botón fue presionado
        Dim btnPresionado As Button = CType(sender, Button)

        ' Recuperamos el ID que guardamos en la propiedad Tag
        Dim idMesaSeleccionada As Integer = CInt(btnPresionado.Tag)
        Dim estadoActual As String = btnPresionado.BackColor.ToString()

        ' Abrimos el formulario de detalle enviando el ID
        Dim frmDetalle As New FrmDetalleMesa(idMesaSeleccionada)
        frmDetalle.ShowDialog()

        ' Al volver, recargamos el panel para ver si cambió de color
        CargarMesas()
    End Sub
End Class