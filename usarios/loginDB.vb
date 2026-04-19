Imports System.Data.SqlClient
Imports UrbanParkCR2026.Utils

Namespace usarios

    Public Class loginDB

        Public Sub RegistrarUsuario(email As String, password As String, rol As String)

            Dim db As New DbHelper()
            Dim helperHash As New Simple3Des()

            Dim passwordHash As String = helperHash.EncryptData(password)

            Dim query As String = "INSERT INTO Usuario (Username, PasswordHash, Rol, Activo) VALUES (@user, @pass, @rol, @activo)"

            Dim parametros As New List(Of SqlParameter) From {
        New SqlParameter("@user", email),
        New SqlParameter("@pass", passwordHash),
        New SqlParameter("@rol", rol),
        New SqlParameter("@activo", 1)
    }

            db.ExecuteNonQuery(query, parametros)

        End Sub
        Public Function ValidarUsuario(email As String, password As String) As String

            Dim db As New DbHelper()

            Dim query As String = "SELECT * FROM Usuario WHERE Username = @user AND Activo = 1"

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
                Return rol ' ADMIN o USER
            Else
                Return "ERROR_PASSWORD"
            End If

        End Function



    End Class

End Namespace