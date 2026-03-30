Imports UrbanParkCR2026.Models
Imports UrbanParkCR2026.Utils

Namespace dbPago
    Public Class CobroDB

        Private ReadOnly dbHelper As New DbHelper()

        Public Function CalcularCobro(tipoVehiculo As String,
                                      horaEntrada As DateTime,
                                      horaSalida As DateTime,
                                      metodoPago As String) As Pago


            Dim tiempo As TimeSpan = horaSalida - horaEntrada

            Dim horasEnteras As Integer = Math.Floor(tiempo.TotalHours)

            Dim minutosExtra As Integer = CInt(Math.Round(tiempo.TotalMinutes - (horasEnteras * 60)))

            Dim horasCobradas As Integer

            If minutosExtra <= 5 Then
                horasCobradas = horasEnteras
            Else
                horasCobradas = horasEnteras + 1
            End If

            horasCobradas = Math.Max(1, horasCobradas)
            '  TARIFAS
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

            '  CÁLCULOS
            Dim subtotal As Decimal = horasCobradas * tarifa
            Dim iva As Decimal = 0
            Dim total As Decimal = subtotal

            ' IVA solo si es tarjeta
            If metodoPago = "Tarjeta" Then
                iva = subtotal * 0.13D
                total = subtotal + iva
            End If

            '  RETORNAR OBJETO
            Return New Pago With {
                .HorasCobradas = horasCobradas,
                .Tarifa = tarifa,
                .Subtotal = subtotal,
                .IVA = iva,
                .Total = total,
                .MetodoPago = metodoPago,
                .FechaPago = horaSalida ' 
            }

        End Function

    End Class
End Namespace