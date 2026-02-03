Imports System.Data.OleDb
Imports Cesars_Club_Club_De_Playa.DAL

Public Class FrmLogin

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Using conexion As New OleDbConnection(cadena)

            Try
                conexion.Open()
                estado = "Conectado"

            Catch ex As Exception

                estado = "Desconectado"
                MsgBox("No hay conexión con la base de datos", MsgBoxStyle.Critical)

                Exit Sub
            End Try

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
                                FrmRecepcionista.Show()
                            Case "Cocinero"
                                FrmCocinero.Show()
                            Case "Caja"
                                FrmFactura.Show()
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


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblHora.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub TxtUsuario_Keypress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = Chr(13) Then
            txtContrasena.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub TxtContrasena_Keypress(sender As Object, e As KeyPressEventArgs) Handles txtContrasena.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub FrmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub


    Private Sub PtbSeePsw_Click(sender As Object, e As EventArgs) Handles PtbSeePsw.Click
        txtContrasena.PasswordChar = "*"
        PtbSeePsw.Visible = False
        PtbDntSeePsw.Visible = True
    End Sub
    Private Sub PtbDntSeePsw_Click(sender As Object, e As EventArgs) Handles PtbDntSeePsw.Click
        txtContrasena.PasswordChar = ""
        PtbSeePsw.Visible = True
        PtbDntSeePsw.Visible = False
    End Sub


End Class