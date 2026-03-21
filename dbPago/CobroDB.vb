Imports UrbanParkCR2026.Models
Imports UrbanParkCR2026.Utils

Namespace dbPago
    Public Class CobroDB
        Private dbHelper As New DbHelper()
        Public Function CalcularCobro(tipoVehiculo As String,
                      horaEntrada As DateTime,
                      metodoPago As String) As Pago

            Dim horaSalida As DateTime = DateTime.Now

            ' 🔥 SOLUCIÓN REAL: cortar decimales (NO redondear)
            Dim minutos As Integer = Math.Floor((horaSalida - horaEntrada).TotalMinutes)

            ' Calcular horas
            Dim horasCobradas As Integer = Math.Ceiling(minutos / 60.0)

            ' Mínimo 1 hora
            If horasCobradas = 0 Then
                horasCobradas = 1
            End If

            ' Tarifas por tipo
            Dim tarifa As Decimal

            Select Case tipoVehiculo
                Case "Moto"
                    tarifa = 800
                Case "Automóvil"
                    tarifa = 1200
                Case "Camión"
                    tarifa = 2000
                Case Else
                    tarifa = 1000
            End Select

            ' Cálculo
            Dim subtotal As Decimal = horasCobradas * tarifa
            Dim iva As Decimal = 0
            Dim total As Decimal = subtotal

            If metodoPago = "Tarjeta" Then
                iva = subtotal * 0.13D
                total = subtotal + iva
            End If

            Return New Pago With {
                .HorasCobradas = horasCobradas,
                .Tarifa = tarifa,
                .Subtotal = subtotal,
                .IVA = iva,
                .Total = total,
                .MetodoPago = metodoPago
            }

        End Function

    End Class
End Namespace