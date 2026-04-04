Imports System.Data.SqlClient
Imports UrbanParkCR2026.Utils

Namespace dbTarifa
    Public Class TarifaDB

        Private dbHelper As New DbHelper()

        Public Function ObtenerTarifa(tipo As String) As Decimal
            Dim sql As String = "SELECT PrecioHora FROM Tarifa WHERE TipoVehiculo = @tipo"

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@tipo", tipo)
            }

            Dim result = dbHelper.ExecuteScalar(sql, parametros)

            If result IsNot Nothing Then
                Return Convert.ToDecimal(result)
            End If

            Return 0
        End Function

        Public Sub ActualizarTarifa(tipo As String, nuevoPrecio As Decimal)
            Dim sql As String = "
                UPDATE Tarifa 
                SET PrecioHora = @precio 
                WHERE TipoVehiculo = @tipo
            "

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@precio", nuevoPrecio),
                New SqlParameter("@tipo", tipo)
            }

            dbHelper.ExecuteNonQuery(sql, parametros)
        End Sub

        Public Function ObtenerTodas() As DataTable

            Dim sql As String = "SELECT TipoVehiculo, PrecioHora FROM Tarifa"

            Return dbHelper.ExecuteDataTable(sql)

        End Function

    End Class
End Namespace