
Namespace Admindb
    Public Class AdMetodos
        Private dbHelper As New Utils.DbHelper()
        Public Function ObtenerGananciasHoy() As Decimal

            Dim sql As String = "
                SELECT ISNULL(SUM(Total),0) 
                FROM Pago 
                WHERE CAST(FechaPago AS DATE) = CAST(GETDATE() AS DATE)
            "

            Return Convert.ToDecimal(dbHelper.ExecuteScalar(sql, Nothing))

        End Function

        Public Function ObtenerVehiculosHoy() As Integer

            Dim sql As String = "
                SELECT COUNT(*) 
                FROM Vehiculo 
                WHERE CAST(HoraEntrada AS DATE) = CAST(GETDATE() AS DATE)
            "

            Return Convert.ToInt32(dbHelper.ExecuteScalar(sql, Nothing))

        End Function

        Public Function ObtenerEspaciosOcupados() As Integer

            Dim sql As String = "
                SELECT COUNT(*) 
                FROM Espacio 
                WHERE Estado = 'Ocupado'
            "

            Return Convert.ToInt32(dbHelper.ExecuteScalar(sql, Nothing))

        End Function



    End Class
End Namespace