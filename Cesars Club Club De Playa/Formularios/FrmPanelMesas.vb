Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmPanelMesas
    Private Sub FrmPanelMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarMesas()
    End Sub

    Public Sub CargarMesas()
        flpMesas.Controls.Clear()

        ' Nos aseguramos de traer el campo "Tipo" (ya lo tenías, perfecto)
        Dim query As String = "SELECT ID_Mesa, NumeroMesa, Estado, Tipo FROM Zonas ORDER BY ID_Mesa"

        Using conexion As New OleDbConnection(cadena)
            Try
                conexion.Open()
                Dim comando As New OleDbCommand(query, conexion)
                Dim lector As OleDbDataReader = comando.ExecuteReader()

                While lector.Read()
                    Dim btnMesa As New Button()

                    ' --- CONFIGURACIÓN BÁSICA ---
                    btnMesa.Width = 120  ' Un poco más grande para que quepa la imagen
                    btnMesa.Height = 120
                    btnMesa.Tag = lector("ID_Mesa")

                    ' Mostramos el nombre y el tipo en el texto
                    btnMesa.Text = lector("NumeroMesa").ToString() & vbCrLf & lector("Tipo").ToString()

                    ' --- AQUI EMPIEZA EL CAMBIO DE IMÁGENES ---

                    ' --- CONFIGURACIÓN DE IMAGEN SEGÚN TIPO ---
                    ' 1. Configuración visual del botón
                    btnMesa.TextAlign = ContentAlignment.BottomCenter
                    btnMesa.ImageAlign = ContentAlignment.TopCenter
                    btnMesa.TextImageRelation = TextImageRelation.ImageAboveText

                    ' 2. Definimos la ruta de la carpeta de recursos
                    ' Asegúrate de que esta carpeta exista en: TuProyecto\bin\Debug\Recursos
                    Dim tipoMesa As String = lector("Tipo").ToString().Trim()

                    Dim nombreArchivo As String = ""

                    ' 3. Elegimos qué archivo buscar
                    Select Case tipoMesa
                        Case "VIP" : nombreArchivo = "VIP.png"
                        Case "Terraza" : nombreArchivo = "Terraza.png"
                        Case "Familiar" : nombreArchivo = "Familiar.png"
                        Case Else : nombreArchivo = "General.png"
                    End Select

                    ' 4. Cargamos la imagen de forma segura si el archivo existe
                    Dim rutaCompleta As String = IO.Path.Combine(rutaimg, nombreArchivo)



                    Try
                        If IO.File.Exists(rutaCompleta) Then
                            Using fs As New IO.FileStream(rutaCompleta, IO.FileMode.Open, IO.FileAccess.Read)
                                ' 1. Cargamos la imagen original de 512x512
                                Dim imgOriginal As Image = Image.FromStream(fs)

                                ' 2. Creamos una versión pequeña (64x64 es ideal para que sobre espacio para el texto)
                                ' Puedes probar con 80x80 si la quieres más grande
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


                    ' --- COLOR DE ESTADO (Mantenemos tu lógica) ---
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

    ' Este evento se dispara al hacer clic en CUALQUIER mesa
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