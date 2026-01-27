Imports System.Data.Common
Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL
Public Class FrmRegistroPersonal

    Private Sub FrmRegistroPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        enlace()

    End Sub

    Dim sql As String = "SELECT COUNT(*) FROM Personal WHERE Usuario = ? AND Contraseña = ?"
End Class