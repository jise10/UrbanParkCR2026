Imports System.Data
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

    End Class
End Namespace