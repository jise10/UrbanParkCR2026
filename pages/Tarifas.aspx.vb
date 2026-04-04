Imports System.Data.SqlClient
Imports UrbanParkCR2026.Utils
Imports UrbanParkCR2026.dbTarifa

Public Class Tarifas
    Inherits System.Web.UI.Page

    Private tarifaDB As New TarifaDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'obteniendo  las tablas de la base de datos

        If Not IsPostBack Then
            CargarTarifas()
        End If


    End Sub


    Private Sub CargarTarifas()

        gvTarifas.DataSource = tarifaDB.ObtenerTodas()
        gvTarifas.DataBind()

    End Sub




    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        For Each row As GridViewRow In gvTarifas.Rows

            Dim tipo As String = row.Cells(0).Text
            Dim txtPrecio As TextBox = CType(row.FindControl("txtPrecio"), TextBox)

            Dim nuevoPrecio As Decimal

            If Decimal.TryParse(txtPrecio.Text, nuevoPrecio) Then
                tarifaDB.ActualizarTarifa(tipo, nuevoPrecio)
            End If

        Next

        Response.Redirect("Admin.aspx")

    End Sub

End Class