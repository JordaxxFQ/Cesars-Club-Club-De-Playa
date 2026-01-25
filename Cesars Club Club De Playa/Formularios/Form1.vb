Imports System.Data.OleDb

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        enlace()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rutaBD As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\elism\source\repos\Cesars-Club-Club-De-Playa\Cesars Club Club De Playa\bin\Debug\BD Proyecto Final.accdb"
        Dim sql As String = "SELECT COUNT(*) FROM Personal WHERE Usuario = ? AND Contraseña = ?"

        Using conn As New OleDbConnection(rutaBD)
            Try
                conn.Open()
                Using cmd As New OleDbCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@p1", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@p2", TextBox2.Text)

                    Dim resultado As Integer = Convert.ToInt32(cmd.ExecuteScalar())


                    If resultado > 0 Then
                        MessageBox.Show("¡Bienvenido al sistema!")
                        Form2.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("Usuario o contraseña incorrectos.")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error de conexión: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        conexion.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.PasswordChar = ControlChars.NullChar
        Else
            TextBox2.PasswordChar = "*"c
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
End Class
