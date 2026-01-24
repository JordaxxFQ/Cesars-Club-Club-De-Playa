Imports System.Data
Imports System.Data.OleDb

Module Module1
    Public conexion As New OleDbConnection
    Public estado As String
    Public comando As New oledbcommand

    Sub enlace()
        Try
            conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Cesars Club Club De Playa\CesarsClub.accdb"
            conexion.Open()
            estado = "Conectado"
        Catch ex As Exception
            estado = "Desconectado"
        End Try
    End Sub


End Module
