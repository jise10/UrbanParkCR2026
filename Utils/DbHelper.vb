Imports System.Data.SqlClient

Namespace Utils
    Public Class DbHelper
        Private ReadOnly connectionString As String =
            ConfigurationManager.ConnectionStrings("ParqueoConnectionString").ConnectionString

        Public Function GetConnection() As SqlConnection
            Return New SqlConnection(connectionString)
        End Function

        Public Function ExecuteNonQuery(query As String,
                                        Optional parameters As List(Of SqlParameter) = Nothing) As Integer

            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)

                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters.ToArray())
                    End If

                    conn.Open()
                    Return cmd.ExecuteNonQuery()
                End Using
            End Using

        End Function

        Public Function ExecuteQuery(query As String) As DataTable

            Dim dt As New DataTable()

            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)

                    conn.Open()
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using

                End Using
            End Using

            Return dt

        End Function

        '==============================
        ' EXECUTE SCALAR
        ' Devuelve un solo valor (Ej: ID)
        '==============================

        Public Function ExecuteScalar(query As String, Optional parameters As List(Of SqlParameter) = Nothing) As Object

            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)

                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters.ToArray())
                    End If

                    Try
                        conn.Open()
                        Return cmd.ExecuteScalar()

                    Catch ex As Exception
                        Throw New Exception("Error al ejecutar ExecuteScalar: " & ex.Message)
                    End Try

                End Using
            End Using

        End Function
        ' nuevo metodo para ejecutar consultas con parámetros y devolver un DataTable
        Public Function ExecuteQuery(query As String, Optional parameters As List(Of SqlParameter) = Nothing) As DataTable

            Dim dt As New DataTable()

            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)

                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters.ToArray())
                    End If

                    conn.Open()
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using

                End Using
            End Using

            Return dt

        End Function


    End Class





End Namespace