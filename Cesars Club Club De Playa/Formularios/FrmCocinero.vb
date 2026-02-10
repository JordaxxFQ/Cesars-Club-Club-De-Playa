Public Class FrmCocinero
    Private Sub FrmCocinero_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PtbPedido_Click(sender As Object, e As EventArgs) Handles PtbPedido.Click, LblPedidos.Click
        FrmPedidos.Show()
    End Sub
    Private Sub PtbCocina_Click(sender As Object, e As EventArgs) Handles PtbCocina.Click, LblCocina.Click
        FrmCocina.Show()
    End Sub
    Private Sub FrmCocinero_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Sub FrmCocinero_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
End Class