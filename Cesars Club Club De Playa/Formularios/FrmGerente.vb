Public Class FrmGerente
    Private Sub FrmGerente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnRegistro_Click(sender As Object, e As EventArgs) Handles btnRegistro.Click
        FrmRegistroPersonal.Show()
    End Sub


    Private Sub btnClient_Click(sender As Object, e As EventArgs) Handles btnClient.Click
        FrmRegistroClientes.Show()
    End Sub

    Private Sub btnMesita_Click(sender As Object, e As EventArgs) Handles btnMesita.Click
        FrmPanelMesas.Show()
    End Sub
    Private Sub FrmGerente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Sub FrmGerente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub btnReservaciones_Click(sender As Object, e As EventArgs) Handles btnReservaciones.Click
        FrmReserva.Show()
    End Sub

    Private Sub btonPedido_Click(sender As Object, e As EventArgs) Handles btonPedido.Click
        FrmPedidos.Show()
    End Sub

    Private Sub BtnCocina_Click(sender As Object, e As EventArgs) Handles BtnCocina.Click
        FrmCocina.Show()
    End Sub
End Class