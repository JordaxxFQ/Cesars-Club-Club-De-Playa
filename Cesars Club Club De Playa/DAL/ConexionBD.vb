Imports System.Data.OleDb

Namespace DAL
    Public Module ConexionBD
        Public conexion As New OleDbConnection
        Public estado As String
        Public comando As New OleDbCommand
        Public ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
        Public cadena As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
    End Module
End Namespace
