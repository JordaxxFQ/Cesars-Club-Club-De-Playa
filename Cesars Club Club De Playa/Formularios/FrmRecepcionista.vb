Public Class FrmRecepcionista
    Private estadosOriginales As New Dictionary(Of Control, Rectangle)
    Private Const crecimiento As Integer = 15
    Private Sub FrmRecepcionista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RegistrarEstadoOriginal(PtbPedido)
        RegistrarEstadoOriginal(PtbZonas)
    End Sub

    Private Sub RegistrarEstadoOriginal(pb As PictureBox)
        If Not estadosOriginales.ContainsKey(pb) Then
            estadosOriginales.Add(pb, pb.Bounds)
            pb.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub
    Private Sub Efecto_MouseEnter(sender As Object, e As EventArgs) Handles PtbPedido.MouseEnter, PtbZonas.MouseEnter
        Dim pb = DirectCast(sender, PictureBox)
        Dim rectOriginal = estadosOriginales(pb)

        pb.SetBounds(rectOriginal.X - crecimiento \ 2,
                 rectOriginal.Y - crecimiento \ 2,
                 rectOriginal.Width + crecimiento,
                 rectOriginal.Height + crecimiento)
    End Sub

    Private Sub Efecto_MouseLeave(sender As Object, e As EventArgs) Handles PtbPedido.MouseLeave, PtbZonas.MouseLeave
        Dim pb = DirectCast(sender, PictureBox)
        Dim rectOriginal = estadosOriginales(pb)

        pb.Bounds = rectOriginal
    End Sub
    Private Sub PtbZonas_Click(sender As Object, e As EventArgs) Handles PtbZonas.Click
        FrmPanelMesas.Show()
    End Sub
    Private Sub PtbPedido_Click(sender As Object, e As EventArgs) Handles PtbPedido.Click
        FrmPedidos.Show()
    End Sub
    Private Sub FrmRecepcionista_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

End Class