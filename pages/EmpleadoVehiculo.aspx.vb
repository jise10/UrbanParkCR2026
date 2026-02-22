Imports UrbanParkCR2026.dbVehiculo
Imports UrbanParkCR2026.Models
Imports UrbanParkCR2026.Utils

Public Class EmpleadoVehiculo
    Inherits System.Web.UI.Page

    Private dbVehiculo As New VehiculoDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarVehiculos()
        End If
    End Sub

    ' =========================
    ' CARGAR GRID
    ' =========================
    Private Sub CargarVehiculos()
        gvVehiculos.DataSource = dbVehiculo.ListarVehiculos()
        gvVehiculos.DataBind()
    End Sub

    ' =========================
    ' ELIMINAR
    ' =========================
    Protected Sub gvVehiculos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        Dim id As Integer = Convert.ToInt32(gvVehiculos.DataKeys(e.RowIndex).Value)

        Dim resultado As Boolean = dbVehiculo.EliminarVehiculo(id)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Eliminado", "Vehículo eliminado correctamente.", "success")
        Else
            SwalUtils.ShowSwalError(Me, "Error", "No se pudo eliminar.")
        End If

        CargarVehiculos()
        e.Cancel = True

    End Sub


End Class
