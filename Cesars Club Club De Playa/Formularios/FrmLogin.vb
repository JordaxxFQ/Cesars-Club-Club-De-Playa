Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmLogin

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        enlace()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If estado = "Desconectado" Then
            MsgBox("No hay conexión con la base de datos", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim sql As String = "SELECT ID_Rol FROM Personal WHERE Usuario = ? AND Contraseña = ?"

        Using cmd As New OleDbCommand(sql, conexion)
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

    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtContrasena.PasswordChar = ControlChars.NullChar
        Else
            txtContrasena.PasswordChar = "*"c
        End If
    End Sub

    Private Sub lblHora_Click(sender As Object, e As EventArgs) Handles lblHora.Click
        lblHora.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub FrmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If conexion.State = ConnectionState.Open Then
            conexion.Close()
        End If
        Application.Exit()
    End Sub

End Class