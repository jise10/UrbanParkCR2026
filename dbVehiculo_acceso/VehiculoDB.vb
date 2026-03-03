Imports System.Data
Imports System.Data.SqlClient
Imports UrbanParkCR2026.Models
Imports UrbanParkCR2026.Utils

Namespace dbVehiculo

    Public Class VehiculoDB

        Private dbHelper As New DbHelper()

        Public Function InsertarVehiculo(v As Vehiculo) As Integer

            Dim sql As String = "
                INSERT INTO Vehiculo (Placa, Tipo, Marca, Color, HoraEntrada, IdEspacio)
                VALUES (@Placa, @Tipo, @Marca, @Color, @HoraEntrada, @IdEspacio);
                SELECT SCOPE_IDENTITY();
            "

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Placa", v.Placa),
                New SqlParameter("@Tipo", v.Tipo),
                New SqlParameter("@Marca", v.Marca),
                New SqlParameter("@Color", v.Color),
                New SqlParameter("@HoraEntrada", v.HoraEntrada),
                New SqlParameter("@IdEspacio", v.IdEspacio)
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
        Public Function RegistrarSalida(idVehiculo As Integer) As Boolean

            ' Obtener espacio del vehículo
            Dim sqlGet As String = "SELECT IdEspacio FROM Vehiculo WHERE IdVehiculo = @Id"

            Dim parametrosGet As New List(Of SqlParameter) From {
        New SqlParameter("@Id", idVehiculo)
    }

            Dim idEspacio As Object = dbHelper.ExecuteScalar(sqlGet, parametrosGet)

            If idEspacio Is Nothing Then
                Return False
            End If

            ' Actualizar HoraSalida
            Dim sqlSalida As String = "
        UPDATE Vehiculo
        SET HoraSalida = SYSDATETIME()
        WHERE IdVehiculo = @Id"

            Dim parametrosSalida As New List(Of SqlParameter) From {
        New SqlParameter("@Id", idVehiculo)
    }

            dbHelper.ExecuteNonQuery(sqlSalida, parametrosSalida)

            ' Liberar espacio
            Dim sqlLiberar As String = "
        UPDATE Espacio
        SET Estado = 'Disponible'
        WHERE IdEspacio = @IdEspacio"

            Dim parametrosLiberar As New List(Of SqlParameter) From {
        New SqlParameter("@IdEspacio", idEspacio)
    }

            dbHelper.ExecuteNonQuery(sqlLiberar, parametrosLiberar)

            Return True

        End Function






        Public Function ListarVehiculos() As DataTable

            Dim sql As String = "
        SELECT V.IdVehiculo, V.Placa, V.Tipo, V.Marca, V.Color,
               V.HoraEntrada, V.IdEspacio, E.Codigo
        FROM Vehiculo V
        INNER JOIN Espacio E ON V.IdEspacio = E.IdEspacio
        WHERE V.HoraSalida IS NULL
        ORDER BY V.HoraEntrada DESC
    "

            Return dbHelper.ExecuteQuery(sql)

        End Function



    End Class

End Namespace