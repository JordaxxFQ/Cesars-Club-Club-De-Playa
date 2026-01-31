Imports System.Data.OleDb

Namespace DAL
    Public Module ConexionBD
        Public conexion As New OleDbConnection
        Public estado As String
        Public comando As New OleDbCommand

        Sub enlace()
            Try
                Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))

                If Not IO.File.Exists(ruta) Then
                    estado = "Desconectado"
                    Exit Sub
                End If

                Dim cadena As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

                conexion = New OleDbConnection(cadena)
                conexion.Open()
                estado = "Conectado"

            Catch ex As Exception
                estado = "Desconectado"
                MsgBox("Error de conexión: " & ex.Message)
            End Try
        End Sub

    End Module
End Namespace
