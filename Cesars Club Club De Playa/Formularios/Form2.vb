Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
End Class