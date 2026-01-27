Public Class FrmGerente
    Private Sub FrmGerente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmGerente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Sub FrmGerente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

End Class