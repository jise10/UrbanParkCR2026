Imports UrbanParkCR2026.dbVehiculo
Imports UrbanParkCR2026.Models
Imports UrbanParkCR2026.Utils

Public Class RegistrarEspacio
    Inherits System.Web.UI.Page

    Private dbVehiculo As New VehiculoDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not IsDate(txtHoraEntrada.Text) Then
            SwalUtils.ShowSwalError(Me, "Error", "Hora inválida.")
            Return
        End If

        ' CREAR OBJETO VEHÍCULO
        Dim vehiculo As New Models.Vehiculo()

        vehiculo.Placa = txtPlaca.Text.Trim()
        vehiculo.Tipo = ddlTipo.SelectedValue
        vehiculo.Marca = txtMarca.Text.Trim()
        vehiculo.Color = txtColor.Text.Trim()
        vehiculo.HoraEntrada = Convert.ToDateTime(txtHoraEntrada.Text)

        ' GUARDAR EN BD
        Dim id As Integer = dbVehiculo.InsertarVehiculo(vehiculo)
        If id > 0 Then

            SwalUtils.ShowSwal(Me,
                      "Registro exitoso",
                      $"Vehículo {vehiculo.Placa} registrado con ID {id}.",
                      "success")

        Else

            SwalUtils.ShowSwalError(Me,
                           "Error",
                           "No se pudo registrar.")

        End If






    End Sub

    Protected Sub btnVerVehiculos_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/pages/EmpleadoVehiculo.aspx")
    End Sub





End Class