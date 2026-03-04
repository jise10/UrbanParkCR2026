Imports UrbanParkCR2026.Models
Imports UrbanParkCR2026.Utils

Namespace dbPago
    Public Class CobroDB
        Private dbHelper As New DbHelper()

        Public Function CalcularCobro(tipoVehiculo As String,
                                   horaEntrada As DateTime,
                                   metodoPago As String) As Pago

            Dim horaSalida As DateTime = DateTime.Now

            ' Calcular minutos totales
            Dim minutos As Double = (horaSalida - horaEntrada).TotalMinutes

            ' Redondear horas hacia arriba
            Dim horasCobradas As Integer = Math.Ceiling(minutos / 60)

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

            Dim subtotal As Decimal = horasCobradas * tarifa
            Dim iva As Decimal = 0
            Dim total As Decimal = subtotal

            If metodoPago = "Tarjeta" Then
                iva = subtotal * 0.13D
                total = subtotal + iva
            End If

            Return New Pago With {
                .horasCobradas = horasCobradas,
                .tarifa = tarifa,
                .subtotal = subtotal,
                .iva = iva,
                .total = total,
                .metodoPago = metodoPago
            }

        End Function


    End Class
End Namespace