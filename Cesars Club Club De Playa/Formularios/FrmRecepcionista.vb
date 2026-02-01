Public Class FrmRecepcionista
    Private Sub btnPedido_Click(sender As Object, e As EventArgs) Handles btnPedido.Click
        FrmPedidos.Show()
    End Sub

    Private Sub btnMesas_Click(sender As Object, e As EventArgs) Handles btnMesas.Click
        FrmPanelMesas.Show()
    End Sub
End Class