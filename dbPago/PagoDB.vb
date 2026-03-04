Imports System.Data.SqlClient
Imports UrbanParkCR2026.Models
Imports UrbanParkCR2026.Utils

Namespace dbPago
    Public Class PagoDB
        Private dbHelper As New DbHelper()
        Public Function RegistrarPago(p As Pago) As Integer

            Dim sql As String = "
        INSERT INTO Pago 
        (IdVehiculo, HorasCobradas, Tarifa, Subtotal, IVA, Total, MetodoPago, FechaPago)
        VALUES 
        (@IdVehiculo, @HorasCobradas, @Tarifa, @Subtotal, @IVA, @Total, @MetodoPago, @FechaPago);
        SELECT SCOPE_IDENTITY();
    "

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@IdVehiculo", p.IdVehiculo),
                New SqlParameter("@HorasCobradas", p.HorasCobradas),
                New SqlParameter("@Tarifa", p.Tarifa),
                New SqlParameter("@Subtotal", p.Subtotal),
                New SqlParameter("@IVA", p.IVA),
                New SqlParameter("@Total", p.Total),
                New SqlParameter("@MetodoPago", p.MetodoPago),
                New SqlParameter("@FechaPago", p.FechaPago)
            }

            Dim result = dbHelper.ExecuteScalar(sql, parametros)

            Return Convert.ToInt32(result)

        End Function

    End Class
End Namespace