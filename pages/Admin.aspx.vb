Imports UrbanParkCR2026.Admindb

Public Class Admin
    Inherits System.Web.UI.Page

    Private adminDB As New AdMetodos()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CargarDashboard()
        End If

    End Sub

    Private Sub CargarDashboard()

        lblGananciaHoy.Text = "₡" & adminDB.ObtenerGananciasHoy()
        lblVehiculos.Text = adminDB.ObtenerVehiculosHoy().ToString()
        lblEspacios.Text = adminDB.ObtenerEspaciosOcupados().ToString()

    End Sub

End Class