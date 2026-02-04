Public Class FrmCocinero
    Private Sub btnCocina_Click(sender As Object, e As EventArgs) Handles btnCocina.Click
        FrmCocina.Show()
    End Sub

    Private Sub btnPedido_Click(sender As Object, e As EventArgs) Handles btnPedido.Click
        FrmPedidos.Show()
    End Sub

    Private Sub FrmCocinero_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class