Imports UrbanParkCR2026.dbVehiculo
Imports UrbanParkCR2026.dbPago
Imports UrbanParkCR2026.Models
Imports UrbanParkCR2026.Utils

Public Class EmpleadoVehiculo
    Inherits System.Web.UI.Page

    Private dbVehiculo As New VehiculoDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CargarVehiculos()
        End If

        ' 🔥 CAPTURAR EL POSTBACK DEL MODAL (AQUÍ VA TODO)
        Dim metodo As String = Request("__EVENTARGUMENT")

        If metodo = "Efectivo" Or metodo = "Tarjeta" Then

            Dim idVehiculo As Integer = Convert.ToInt32(Session("IdVehiculo"))
            Dim pagoCalculado As Pago = CType(Session("PagoCalculado"), Pago)

            ' Completar datos
            pagoCalculado.IdVehiculo = idVehiculo
            pagoCalculado.MetodoPago = metodo
            pagoCalculado.FechaPago = DateTime.Now

            ' Guardar pago
            Dim pagoDB As New PagoDB()
            pagoDB.RegistrarPago(pagoCalculado)

            ' Registrar salida
            dbVehiculo.RegistrarSalida(idVehiculo)

            ' Mensaje éxito
            SwalUtils.ShowSwal(Me,
                               "Pago realizado",
                               "Salida registrada correctamente.",
                               "success")

            CargarVehiculos()

        End If

    End Sub

    Private Sub CargarVehiculos()
        gvVehiculos.DataSource = dbVehiculo.ListarVehiculos()
        gvVehiculos.DataBind()
    End Sub

    ' 🔥 BOTÓN REGISTRAR SALIDA
    Protected Sub gvVehiculos_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName = "Salida" Then

            Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Convert.ToInt32(gvVehiculos.DataKeys(rowIndex).Value)

            Dim row As GridViewRow = gvVehiculos.Rows(rowIndex)

            Dim tipo As String = row.Cells(2).Text
            Dim horaEntrada As DateTime

            DateTime.TryParse(row.Cells(6).Text, horaEntrada)

            ' 🔥 Calcular cobro
            Dim cobroDB As New CobroDB()
            Dim pagoCalculado As Pago = cobroDB.CalcularCobro(tipo, horaEntrada, "Efectivo")

            ' Guardar en Session
            Session("IdVehiculo") = id
            Session("PagoCalculado") = pagoCalculado

            ' 🔥 Modal SweetAlert
            Dim script As String = "
            Swal.fire({
                title: 'Confirmar pago',
                html: '<b>Horas:</b> " & pagoCalculado.HorasCobradas & "<br>' +
                      '<b>Total:</b> ₡" & pagoCalculado.Total & "',
                input: 'select',
                inputOptions: {
                    'Efectivo': 'Efectivo',
                    'Tarjeta': 'Tarjeta'
                },
                inputPlaceholder: 'Seleccione método de pago',
                showCancelButton: true,
                confirmButtonText: 'Cobrar y salir'
            }).then((result) => {
                if (result.isConfirmed) {
                    __doPostBack('', result.value);
                }
            });
            "

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "modalPago", script, True)

        End If

    End Sub

End Class