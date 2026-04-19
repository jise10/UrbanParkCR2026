Imports UrbanParkCR2026.Login
Imports UrbanParkCR2026.usarios

Public Class Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        ' Validar contraseñas
        If txtPassword.Text <> txtConfirmar.Text Then

            ClientScript.RegisterStartupScript(Me.GetType(), "error",
            "Swal.fire({icon: 'error', title: 'Error', text: 'Las contraseñas no coinciden'})", True)

            Exit Sub
        End If

        ' Validar rol
        If ddlRol.SelectedValue = "" Then

            ClientScript.RegisterStartupScript(Me.GetType(), "error",
            "Swal.fire({icon: 'error', title: 'Error', text: 'Seleccione un rol'})", True)

            Exit Sub
        End If

        Try
            Dim servicio As New LoginDB()
            servicio.RegistrarUsuario(txtEmail.Text, txtPassword.Text, ddlRol.SelectedValue)

            ' Éxito + redirección
            ClientScript.RegisterStartupScript(Me.GetType(), "ok",
            "Swal.fire({
                icon: 'success',
                title: 'Registro exitoso',
                text: 'Usuario creado correctamente'
            }).then(() => {
                window.location = 'Login.aspx';
            });", True)

        Catch ex As Exception

            Dim mensaje As String = ex.Message.Replace("'", "")

            ClientScript.RegisterStartupScript(Me.GetType(), "error",
            "Swal.fire({icon: 'error', title: 'Error', text: '" & mensaje & "'})", True)

        End Try

    End Sub

End Class