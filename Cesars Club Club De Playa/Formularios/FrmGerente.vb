Public Class FrmGerente

    Private estadosOriginales As New Dictionary(Of Control, Rectangle)
    Private Const crecimiento As Integer = 15
    Private Sub FrmGerente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RegistrarEstadoOriginal(PtbClientes)
        RegistrarEstadoOriginal(PtbPedido)
        RegistrarEstadoOriginal(PtbPersonal)
        RegistrarEstadoOriginal(PtbProducto)
        RegistrarEstadoOriginal(PtbFactura)
        RegistrarEstadoOriginal(PtbZonas)

    End Sub

    Private Sub RegistrarEstadoOriginal(pb As PictureBox)
        If Not estadosOriginales.ContainsKey(pb) Then
            estadosOriginales.Add(pb, pb.Bounds)
            pb.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub
    Private Sub Efecto_MouseEnter(sender As Object, e As EventArgs) Handles PtbClientes.MouseEnter, PtbPersonal.MouseEnter, PtbProducto.MouseEnter, PtbPedido.MouseEnter, PtbFactura.MouseEnter, PtbZonas.MouseEnter
        ' El "sender" es el PictureBox que activó el evento
        Dim pb As PictureBox = DirectCast(sender, PictureBox)
        Dim rectOriginal As Rectangle = estadosOriginales(pb)

        ' Aplicamos el crecimiento desde el centro
        pb.SetBounds(rectOriginal.X - (crecimiento \ 2),
                 rectOriginal.Y - (crecimiento \ 2),
                 rectOriginal.Width + crecimiento,
                 rectOriginal.Height + crecimiento)
    End Sub

    Private Sub Efecto_MouseLeave(sender As Object, e As EventArgs) Handles PtbClientes.MouseLeave, PtbPersonal.MouseLeave, PtbProducto.MouseLeave, PtbPedido.MouseLeave, PtbFactura.MouseLeave, PtbZonas.MouseLeave
        ' El "sender" nos dice cuál restaurar
        Dim pb As PictureBox = DirectCast(sender, PictureBox)
        Dim rectOriginal As Rectangle = estadosOriginales(pb)

        ' Restauramos sus valores originales exactos
        pb.Bounds = rectOriginal
    End Sub
    Private Sub PtbPersonal_Click_1(sender As Object, e As EventArgs) Handles PtbPersonal.Click, LblPersonal.Click
        FrmRegistroPersonal.Show()
    End Sub

    Private Sub PtbCliente_Click(sender As Object, e As EventArgs) Handles PtbClientes.Click, LblClientes.Click
        FrmRegistroClientes.Show()
    End Sub

    Private Sub PtbProducto_Click(sender As Object, e As EventArgs) Handles PtbProducto.Click, LblProducto.Click
        FrmProductos.Show()
    End Sub

    Private Sub FrmGerente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Sub FrmGerente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub PtbPedido_Click(sender As Object, e As EventArgs) Handles PtbPedido.Click, LblPedidos.Click
        FrmPedidos.Show()
    End Sub

    Private Sub PtbFactura_Click(sender As Object, e As EventArgs) Handles PtbFactura.Click, LblFactura.Click
        FrmFactura.Show()
    End Sub

    Private Sub PtbZonas_Click(sender As Object, e As EventArgs) Handles PtbZonas.Click, LblZonas.Click
        FrmPanelMesas.Show()
    End Sub
End Class