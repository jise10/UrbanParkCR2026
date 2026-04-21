Imports UrbanParkCR2026.Login
Imports UrbanParkCR2026.usarios

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim servicio As New LoginDB()
        Dim resultado As String = servicio.ValidarUsuario(txtEmail.Text, txtPassword.Text)

        Select Case resultado

            Case "ADMIN"
                Response.Redirect("Admin.aspx")

            Case "USER"
                Response.Redirect("EmpleadoVehiculo.aspx")

            Case "NO_EXISTE"
                MostrarSwal("Error", "Usuario no existe", "error")

            Case "ERROR_PASSWORD"
                MostrarSwal("Error", "Contraseña incorrecta", "error")

        End Select

    End Sub

    Private Sub MostrarSwal(titulo As String, mensaje As String, tipo As String)
        ClientScript.RegisterStartupScript(Me.GetType(), "alert",
        $"Swal.fire({{icon: '{tipo}', title: '{titulo}', text: '{mensaje}'}})", True)
    End Sub

End Class