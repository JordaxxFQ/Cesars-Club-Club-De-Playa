Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmLogin

    Dim ruta As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\..\..\DataBase\BD Proyecto Final.accdb"))
    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ruta

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Using conexion As New OleDbConnection(connectionString)
            Try
                conexion.Open()
                estado = "Conectado"
            Catch ex As Exception
                estado = "Desconectado"
            End Try

            If estado = "Desconectado" Then
                MsgBox("No hay conexión con la base de datos", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim query As String = "SELECT ID_Rol FROM Personal WHERE Usuario = ? AND Contraseña = ?"

            Using cmd As New OleDbCommand(query, conexion)
                Try
                    cmd.Parameters.AddWithValue("@p1", txtUsuario.Text)
                    cmd.Parameters.AddWithValue("@p2", txtContrasena.Text)

                    Dim resultado = cmd.ExecuteScalar()

                    If resultado IsNot Nothing Then
                        Dim rol As String = resultado.ToString()

                        MessageBox.Show("¡Bienvenido al sistema!")
                        System.Media.SystemSounds.Beep.Play()

                        Select Case rol
                            Case "Gerente"
                                FrmGerente.Show()
                            Case "Recepcionista"
                                FrmGerente.Show()
                            Case "Cocinero"
                                FrmGerente.Show()
                            Case Else
                                MessageBox.Show("Rol no asignado. Contacte al administrador.")
                                Exit Sub
                        End Select

                        Me.Hide()

                    Else
                        MessageBox.Show("Usuario o contraseña incorrectos.")
                        txtUsuario.Clear()
                        txtContrasena.Clear()
                        txtUsuario.Focus()
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error de sistema: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtContrasena.PasswordChar = ControlChars.NullChar
        Else
            txtContrasena.PasswordChar = "*"c
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblHora.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub txtUsuario_Keypress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = Chr(13) Then
            txtContrasena.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub txtContrasena_Keypress(sender As Object, e As KeyPressEventArgs) Handles txtContrasena.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub FrmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
End Class