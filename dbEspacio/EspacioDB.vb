Imports System.Data
Imports System.Data.SqlClient
Imports UrbanParkCR2026.Utils

Namespace dbEspacio
    Public Class EspacioDB

        Private dbHelper As New DbHelper()

        Public Function ListarEspacios() As DataTable
            Dim sql As String = "
                SELECT IdEspacio, Codigo, Zona, Nivel, Estado
                FROM Espacio
                ORDER BY Nivel, Zona, Codigo;"
            Return dbHelper.ExecuteQuery(sql)
        End Function

        Public Function ObtenerTipoPermitido(idEspacio As Integer) As String

            Dim sql As String = "SELECT TipoPermitido FROM Espacio WHERE IdEspacio=@Id"

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Id", idEspacio)
            }

            Dim dt As DataTable = dbHelper.ExecuteQuery(sql, parametros)

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("TipoPermitido").ToString()
            End If

            Return ""
        End Function




    End Class
End Namespace