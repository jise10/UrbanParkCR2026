Imports System.Data.SqlClient
Imports UrbanParkCR2026.Utils

Namespace usarios

    Public Class loginDB

        ' ============================
        ' REGISTRAR USUARIO
        ' ============================
        Public Sub RegistrarUsuario(email As String, password As String, rol As String)

            Dim db As New DbHelper()
            Dim helperHash As New Simple3Des()

            Dim passwordHash As String = helperHash.EncryptData(password)

            Dim query As String = "INSERT INTO Usuario (Username, PasswordHash, Rol, Activo) 
                                  VALUES (@user, @pass, @rol, @activo)"

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@user", email),
                New SqlParameter("@pass", passwordHash),
                New SqlParameter("@rol", rol),
                New SqlParameter("@activo", 1)
            }

            db.ExecuteNonQuery(query, parametros)

        End Sub

        ' ============================
        ' VALIDAR LOGIN
        ' ============================
        Public Function ValidarUsuario(email As String, password As String) As String

            Dim db As New DbHelper()

            Dim query As String = "SELECT * FROM Usuario 
                                  WHERE Username = @user AND Activo = 1"

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@user", email)
            }

            Dim dt As DataTable = db.ExecuteQuery(query, parametros)

            If dt.Rows.Count = 0 Then
                Return "NO_EXISTE"
            End If

            Dim hashBD As String = dt.Rows(0)("PasswordHash").ToString()
            Dim rol As String = dt.Rows(0)("Rol").ToString()

            Dim helper As New Simple3Des()

            If helper.DecryptData(password, hashBD) Then
                Return rol
            Else
                Return "ERROR_PASSWORD"
            End If

        End Function

        ' ============================
        ' OBTENER USUARIOS
        ' ============================
        Public Function ObtenerUsuarios() As DataTable

            Dim db As New DbHelper()

            ' 🔥 IMPORTANTE: evitar NULL en Activo
            Dim query As String = "SELECT IdPersona, Username, Rol, ISNULL(Activo,0) AS Activo 
                                  FROM Usuario"

            Return db.ExecuteQuery(query)

        End Function

        ' ============================
        ' ELIMINAR USUARIO
        ' ============================
        Public Function EliminarUsuario(id As Integer) As Boolean

            Dim db As New DbHelper()

            Dim query As String = "DELETE FROM Usuario WHERE IdPersona = @id"

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@id", id)
            }

            Return db.ExecuteNonQuery(query, parametros) > 0

        End Function

        ' ============================
        ' ACTUALIZAR USUARIO
        ' ============================
        Public Function ActualizarUsuario(id As Integer, email As String, rol As String, activo As Boolean) As Boolean

            Dim db As New DbHelper()

            Dim query As String = "UPDATE Usuario 
                                  SET Username = @user, 
                                      Rol = @rol, 
                                      Activo = @activo 
                                  WHERE IdPersona = @id"

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@user", email),
                New SqlParameter("@rol", rol),
                New SqlParameter("@activo", activo), ' 🔥 limpio (sin If)
                New SqlParameter("@id", id)
            }

            Return db.ExecuteNonQuery(query, parametros) > 0

        End Function

    End Class

End Namespace