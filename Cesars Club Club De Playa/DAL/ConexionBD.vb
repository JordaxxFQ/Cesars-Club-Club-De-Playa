Imports System.Data.OleDb

Namespace DAL
    Public Module ConexionBD

        'Variable publica de conexion
        Public conexion As New OleDbConnection
        'Variable publica del estado de la conexion con la BD
        Public estado As String
        'Variable publica ruta hacia la BD
        Public ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
        'Variable publica de la cadena para conectar con la BD
        Public cadena As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta
        'Variable publica de la ruta a los recursos
        Public rutaimg As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\Recursos\"))
    End Module
End Namespace
