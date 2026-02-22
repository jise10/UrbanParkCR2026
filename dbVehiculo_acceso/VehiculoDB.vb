Imports System.Data.SqlClient
Imports UrbanParkCR2026.Models
Imports UrbanParkCR2026.Utils

Namespace dbVehiculo

    Public Class VehiculoDB

        Private dbHelper As New DbHelper()
        Public Function InsertarVehiculo(v As Vehiculo) As Integer

            Dim sql As String = "
        INSERT INTO Vehiculo (Placa, Tipo, Marca, Color, HoraEntrada)
        VALUES (@Placa, @Tipo, @Marca, @Color, @HoraEntrada);
        SELECT SCOPE_IDENTITY();
    "

            Dim parametros As New List(Of SqlParameter) From {
        New SqlParameter("@Placa", v.Placa),
        New SqlParameter("@Tipo", v.Tipo),
        New SqlParameter("@Marca", v.Marca),
        New SqlParameter("@Color", v.Color),
        New SqlParameter("@HoraEntrada", v.HoraEntrada)
    }

            Return Convert.ToInt32(dbHelper.ExecuteScalar(sql, parametros))

        End Function

        Public Function EliminarVehiculo(id As Integer) As Boolean

            Dim sql As String = "DELETE FROM Vehiculo WHERE IdVehiculo = @Id"

            Dim parametros As New List(Of SqlParameter) From {
        New SqlParameter("@Id", id)
    }

            Return dbHelper.ExecuteNonQuery(sql, parametros) > 0

        End Function








        Public Function ListarVehiculos() As DataTable

            Dim sql As String = "
        SELECT IdVehiculo, Placa, Tipo, Marca, Color, HoraEntrada
        FROM Vehiculo
        ORDER BY HoraEntrada DESC
    "

            Return dbHelper.ExecuteQuery(sql)

        End Function





    End Class

End Namespace
