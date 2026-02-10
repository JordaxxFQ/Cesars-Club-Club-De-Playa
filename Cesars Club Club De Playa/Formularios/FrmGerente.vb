Public Class FrmGerente

    Private estadosOriginales As New Dictionary(Of Control, Rectangle)
    Private Const crecimiento As Integer = 15
    ' Este código se encarga de registrar el estado original de cada PictureBox en el formulario, para luego aplicar un efecto de crecimiento al pasar el mouse sobre ellos.
    Private Sub FrmGerente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RegistrarEstadoOriginal(PtbClientes)
        RegistrarEstadoOriginal(PtbPedido)
        RegistrarEstadoOriginal(PtbPersonal)
        RegistrarEstadoOriginal(PtbProducto)
        RegistrarEstadoOriginal(PtbFactura)
        RegistrarEstadoOriginal(PtbZonas)
        RegistrarEstadoOriginal(PtbCocina)
        RegistrarEstadoOriginal(PtbReservas)

    End Sub
    ' Esta función se encarga de registrar el estado original de un PictureBox en un diccionario, para luego poder restaurarlo después de aplicar un efecto de crecimiento al pasar el mouse sobre él.
    Private Sub RegistrarEstadoOriginal(pb As PictureBox)
        If Not estadosOriginales.ContainsKey(pb) Then
            estadosOriginales.Add(pb, pb.Bounds)
            pb.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub

    ' Este código se encarga de aplicar un efecto de crecimiento a un PictureBox cuando el mouse entra en él, y restaurar su tamaño original cuando el mouse sale. El efecto se aplica desde el centro del PictureBox, aumentando su tamaño en una cantidad definida por la constante "crecimiento".
    Private Sub Efecto_MouseEnter(sender As Object, e As EventArgs) Handles PtbClientes.MouseEnter, PtbPersonal.MouseEnter, PtbProducto.MouseEnter, PtbPedido.MouseEnter, PtbFactura.MouseEnter, PtbZonas.MouseEnter, PtbCocina.MouseEnter, PtbReservas.MouseEnter
        ' El "sender" es el PictureBox que activó el evento
        Dim pb = DirectCast(sender, PictureBox)
        Dim rectOriginal = estadosOriginales(pb)

        ' Aplicamos el crecimiento desde el centro
        pb.SetBounds(rectOriginal.X - crecimiento \ 2,
                 rectOriginal.Y - crecimiento \ 2,
                 rectOriginal.Width + crecimiento,
                 rectOriginal.Height + crecimiento)
    End Sub

    ' Este código se encarga de restaurar el tamaño original de un PictureBox cuando el mouse sale de él, utilizando el estado registrado en el diccionario "estadosOriginales". El efecto de crecimiento se aplica desde el centro del PictureBox, aumentando su tamaño en una cantidad definida por la constante "crecimiento".
    Private Sub Efecto_MouseLeave(sender As Object, e As EventArgs) Handles PtbClientes.MouseLeave, PtbPersonal.MouseLeave, PtbProducto.MouseLeave, PtbPedido.MouseLeave, PtbFactura.MouseLeave, PtbZonas.MouseLeave, PtbCocina.MouseLeave, PtbReservas.MouseLeave
        ' El "sender" nos dice cuál restaurar
        Dim pb = DirectCast(sender, PictureBox)
        Dim rectOriginal = estadosOriginales(pb)

        ' Restauramos sus valores originales exactos
        pb.Bounds = rectOriginal
    End Sub

    ' Este código se encarga de mostrar el formulario correspondiente al hacer clic en cada PictureBox o Label asociado. Cada evento de clic está vinculado a un formulario específico que se muestra al usuario.
    Private Sub PtbPersonal_Click_1(sender As Object, e As EventArgs) Handles PtbPersonal.Click, LblPersonal.Click
        FrmRegistroPersonal.Show()
    End Sub

    Private Sub PtbCliente_Click(sender As Object, e As EventArgs) Handles PtbClientes.Click, LblClientes.Click
        FrmRegistroClientes.Show()
    End Sub

    Private Sub PtbProducto_Click(sender As Object, e As EventArgs) Handles PtbProducto.Click, LblProducto.Click
        FrmProductos.Show()
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

    Private Sub PtbCocina_Click(sender As Object, e As EventArgs) Handles PtbCocina.Click, LblCocina.Click
        FrmCocina.Show()
    End Sub

    Private Sub PtbReservas_Click(sender As Object, e As EventArgs) Handles PtbReservas.Click, LblReserva.Click
        FrmReserva.Show()
    End Sub
    Private Sub FrmGerente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Sub FrmGerente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
End Class