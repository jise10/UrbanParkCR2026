Imports UrbanParkCR2026.Admindb
Imports UrbanParkCR2026.usarios

Public Class Admin
    Inherits System.Web.UI.Page

    Private adminDB As New AdMetodos()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CargarDashboard()
            CargarUsuarios()
        End If

    End Sub

    Private Sub CargarDashboard()
        lblGananciaHoy.Text = "₡" & adminDB.ObtenerGananciasHoy()
        lblVehiculos.Text = adminDB.ObtenerVehiculosHoy().ToString()
        lblEspacios.Text = adminDB.ObtenerEspaciosOcupados().ToString()
    End Sub

    Private Sub CargarUsuarios()
        Dim login As New loginDB()
        Dim dt As DataTable = login.ObtenerUsuarios()
        gvUsuarios.DataSource = dt
        gvUsuarios.DataBind()
    End Sub

    Protected Sub gvUsuarios_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvUsuarios.RowCommand

        Dim id As Integer = Convert.ToInt32(e.CommandArgument)
        Dim login As New loginDB()

        If e.CommandName = "Eliminar" Then

            login.EliminarUsuario(id)

        ElseIf e.CommandName = "Editar" Then

            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)

            Dim correo As String = CType(row.FindControl("lblCorreo"), Label).Text
            Dim rol As String = CType(row.FindControl("ddlRol"), DropDownList).SelectedValue
            Dim activo As Boolean = CType(row.FindControl("chkActivo"), CheckBox).Checked

            login.actualizarUsuario(id, correo, rol, activo)

        End If

        CargarUsuarios()

    End Sub



End Class