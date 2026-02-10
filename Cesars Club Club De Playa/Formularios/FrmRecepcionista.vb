Public Class FrmRecepcionista
    Private Sub btnPedido_Click(sender As Object, e As EventArgs) Handles btnPedido.Click
        FrmPedidos.Show()
    End Sub

    Private Sub btnMesas_Click(sender As Object, e As EventArgs) Handles btnMesas.Click
        FrmPanelMesas.Show()
    End Sub

    Private Sub FrmRecepcionista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub FrmRecepcionista_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Sub FrmRecepcionista_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
End Class