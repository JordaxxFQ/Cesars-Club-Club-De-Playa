Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmPanelMesas
    Private Sub FrmPanelMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarMesas()
    End Sub

    ' Esta función se encarga de cargar las mesas desde la base de datos y mostrarlas en un FlowLayoutPanel.
    ' Para cada mesa, se crea un botón con su número, tipo y estado, y se le asigna una imagen representativa según su tipo.
    ' Además, el color de fondo del botón cambia según el estado de la mesa (disponible, ocupada, reservada, mantenimiento).
    ' Al hacer clic en un botón de mesa, se abre un formulario de detalle con la información de esa mesa.
    Public Sub CargarMesas()
        flpMesas.Controls.Clear()

        Dim query As String = "SELECT ID_Mesa, NumeroMesa, Estado, Tipo FROM Zonas ORDER BY ID_Mesa"

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()
                Dim comando As New OleDbCommand(query, conexion)
                Dim lector As OleDbDataReader = comando.ExecuteReader()

                While lector.Read()
                    Dim btnMesa As New Button()
                    btnMesa.Width = 120
                    btnMesa.Height = 120
                    btnMesa.Tag = lector("ID_Mesa")

                    ' Mostramos el nombre y el tipo en el texto
                    btnMesa.Text = lector("NumeroMesa").ToString() & vbCrLf & lector("Tipo").ToString()

                    'Configuración visual del botón
                    btnMesa.TextAlign = ContentAlignment.BottomCenter
                    btnMesa.ImageAlign = ContentAlignment.TopCenter
                    btnMesa.TextImageRelation = TextImageRelation.ImageAboveText

                    Dim tipoMesa As String = lector("Tipo").ToString().Trim()

                    Dim nombreArchivo As String = ""

                    ' Elegimos qué archivo buscar
                    Select Case tipoMesa
                        Case "VIP" : nombreArchivo = "VIP.png"
                        Case "Terraza" : nombreArchivo = "Terraza.png"
                        Case "Familiar" : nombreArchivo = "Familiar.png"
                        Case Else : nombreArchivo = "General.png"
                    End Select

                    ' Cargamos la imagen de forma segura si el archivo existe
                    Dim rutaCompleta As String = IO.Path.Combine(rutaimg, nombreArchivo)



                    Try
                        If IO.File.Exists(rutaCompleta) Then
                            Using fs As New IO.FileStream(rutaCompleta, IO.FileMode.Open, IO.FileAccess.Read)
                                ' Cargamos la imagen original de 512x512
                                'Esto pq las imagenes en Recursos son de 512x512, pero el botón es de 120x120, así que las redimensionamos para que se vean bien sin distorsión
                                Dim imgOriginal As Image = Image.FromStream(fs)

                                ' Creamos una versión pequeña 
                                Dim imgRedimensionada As New Bitmap(imgOriginal, New Size(64, 64))

                                ' 3. La asignamos al botón
                                btnMesa.Image = imgRedimensionada

                                ' Liberamos la imagen original de la memoria
                                imgOriginal.Dispose()
                            End Using
                        End If
                    Catch ex As Exception
                        Debug.WriteLine("Error al redimensionar: " & ex.Message)
                    End Try


                    ' Cambia de color segun su estado
                    Dim estado As String = lector("Estado").ToString()
                    Select Case estado
                        Case "Disponible" : btnMesa.BackColor = Color.LightGreen
                        Case "Ocupada" : btnMesa.BackColor = Color.LightCoral
                        Case "Reservada" : btnMesa.BackColor = Color.Khaki
                        Case "Mantenimiento" : btnMesa.BackColor = Color.Gray
                    End Select

                    AddHandler btnMesa.Click, AddressOf BotonMesa_Click
                    flpMesas.Controls.Add(btnMesa)

                End While
            Catch ex As Exception
                MessageBox.Show("Error al cargar mesas: " & ex.Message)
            End Try
        End Using
    End Sub

    ' Este código se encarga de manejar el evento de clic en los botones de las mesas.
    ' Cuando se hace clic en un botón, se recupera el ID de la mesa desde la propiedad Tag del botón, y se abre un formulario de detalle (FrmDetalleMesa) pasando ese ID como parámetro.
    ' Después de cerrar el formulario de detalle, se recargan las mesas para reflejar cualquier cambio que se haya hecho.
    Private Sub BotonMesa_Click(sender As Object, e As EventArgs)
        ' Recuperamos qué botón fue presionado
        Dim btnPresionado As Button = CType(sender, Button)

        ' Recuperamos el ID que guardamos en la propiedad Tag
        Dim idMesaSeleccionada As Integer = CInt(btnPresionado.Tag)
        Dim estadoActual As String = btnPresionado.BackColor.ToString()

        Dim frmDetalle As New FrmDetalleMesa(idMesaSeleccionada)
        frmDetalle.ShowDialog()
        CargarMesas()

    End Sub
End Class