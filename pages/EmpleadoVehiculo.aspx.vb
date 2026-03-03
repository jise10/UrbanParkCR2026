Imports UrbanParkCR2026.dbVehiculo
Imports UrbanParkCR2026.Utils

Public Class EmpleadoVehiculo
    Inherits System.Web.UI.Page

    Private dbVehiculo As New VehiculoDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarVehiculos()
        End If
    End Sub

    Private Sub CargarVehiculos()
        gvVehiculos.DataSource = dbVehiculo.ListarVehiculos()
        gvVehiculos.DataBind()
    End Sub

    Protected Sub gvVehiculos_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName = "Salida" Then

            Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
            Dim id As Integer = Convert.ToInt32(gvVehiculos.DataKeys(rowIndex).Value)

            Dim resultado As Boolean = dbVehiculo.RegistrarSalida(id)

            If resultado Then
                SwalUtils.ShowSwal(Me,
                                   "Salida registrada",
                                   "El espacio fue liberado correctamente.",
                                   "success")
            Else
                SwalUtils.ShowSwalError(Me,
                                        "Error",
                                        "No se pudo registrar la salida.")
            End If

            CargarVehiculos()

        End If

    End Sub

End Class
