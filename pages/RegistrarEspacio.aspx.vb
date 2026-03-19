Imports System.Data
Imports System.Data.SqlClient
Imports UrbanParkCR2026.dbVehiculo
Imports UrbanParkCR2026.Models
Imports UrbanParkCR2026.Utils

Public Class RegistrarEspacio
    Inherits System.Web.UI.Page

    Private dbVehiculo As New VehiculoDB()
    Private dbHelper As New DbHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarEspacios()
            pnlFormulario.Visible = False
            hfEspacioId.Value = ""
            lblEspacioSeleccionado.Text = "Seleccione un espacio para habilitar el formulario"
            lblEspacioSeleccionado.CssClass = "badge bg-secondary"
        End If
    End Sub

    '========================
    ' CARGAR ESPACIOS (Cards)
    '========================


    Private Sub CargarEspacios(Optional tipo As String = "")

        Dim sql As String = "
        SELECT IdEspacio, Codigo, Zona, Nivel, Estado, TipoPermitido
        FROM Espacio
        WHERE (@Tipo = '' OR TipoPermitido = @Tipo)
        ORDER BY Nivel, Zona, Codigo;"

        Dim parametros As New List(Of SqlParameter) From {
        New SqlParameter("@Tipo", tipo)
    }

        Dim dt As DataTable = dbHelper.ExecuteQuery(sql, parametros)

        rptEspacios.DataSource = dt
        rptEspacios.DataBind()

    End Sub
    ' esto hace que al cambiar el tipo, se recarguen los espacios filtrados por ese tipo (o todos si es "0")

    Protected Sub ddlTipo_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim tipoSeleccionado As String = ddlTipo.SelectedValue

        If tipoSeleccionado = "0" Then
            CargarEspacios("")
        Else
            CargarEspacios(tipoSeleccionado)
        End If

        hfEspacioId.Value = ""
        lblEspacioSeleccionado.Text = "Seleccione un espacio para habilitar el formulario"
        lblEspacioSeleccionado.CssClass = "badge bg-secondary"
        pnlFormulario.Visible = False

    End Sub
    '========================
    ' SELECCIONAR ESPACIO
    '========================
    Protected Sub rptEspacios_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptEspacios.ItemCommand

        If e.CommandName = "select" Then

            hfEspacioId.Value = e.CommandArgument.ToString()
            lblEspacioSeleccionado.Text = "Espacio seleccionado (Id): " & hfEspacioId.Value
            lblEspacioSeleccionado.CssClass = "badge bg-success"
            pnlFormulario.Visible = True
            pnlFormulario.Enabled = True ' habilitamos el panel para que se pueda interactuar

        End If

    End Sub


    '========================
    ' GUARDAR VEHÍCULO + OCUPAR ESPACIO
    '========================
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        ' 1) Validar espacio seleccionado
        If String.IsNullOrWhiteSpace(hfEspacioId.Value) Then
            SwalUtils.ShowSwalError(Me, "Error", "Debe seleccionar un espacio antes de registrar.")
            Return
        End If

        Dim idEspacio As Integer
        If Not Integer.TryParse(hfEspacioId.Value, idEspacio) Then
            SwalUtils.ShowSwalError(Me, "Error", "Espacio inválido.")
            Return
        End If

        ' 2) Validar hora
        If Not IsDate(txtHoraEntrada.Text) Then
            SwalUtils.ShowSwalError(Me, "Error", "Hora inválida.")
            Return
        End If

        ' 3) Crear objeto vehículo
        Dim vehiculo As New Vehiculo()
        vehiculo.Placa = txtPlaca.Text.Trim()
        vehiculo.Tipo = ddlTipo.SelectedValue
        vehiculo.Marca = txtMarca.Text.Trim()
        vehiculo.Color = txtColor.Text.Trim()
        vehiculo.HoraEntrada = Convert.ToDateTime(txtHoraEntrada.Text)
        vehiculo.IdEspacio = idEspacio

        ' 4) Antes de insertar, intentar ocupar el espacio (evita duplicados)
        '    Si otro ya lo ocupó, el UPDATE no afecta filas.
        Dim sqlOcupar As String = "
            UPDATE Espacio
            SET Estado='Ocupado', FechaActualizacion=SYSDATETIME()
            WHERE IdEspacio=@IdEspacio AND Estado='Disponible';"

        Dim parametrosOcupar As New List(Of SqlParameter) From {
            New SqlParameter("@IdEspacio", idEspacio)
        }

        Dim filas As Integer = dbHelper.ExecuteNonQuery(sqlOcupar, parametrosOcupar)

        If filas = 0 Then
            SwalUtils.ShowSwalError(Me, "Espacio no disponible", "Ese espacio ya fue ocupado. Seleccione otro.")
            CargarEspacios()
            pnlFormulario.Enabled = False
            hfEspacioId.Value = ""
            lblEspacioSeleccionado.Text = "Seleccione un espacio para habilitar el formulario"
            lblEspacioSeleccionado.CssClass = "badge bg-secondary"
            Return
        End If

        ' 5) Insertar vehículo (DEBES actualizar VehiculoDB para que inserte IdEspacio)
        Dim id As Integer = dbVehiculo.InsertarVehiculo(vehiculo)

        If id > 0 Then
            SwalUtils.ShowSwal(Me, "Registro exitoso",
                              $"Vehículo {vehiculo.Placa} registrado con ID {id}.",
                              "success")

            ' refrescar cards y reset
            CargarEspacios()
            pnlFormulario.Enabled = False
            hfEspacioId.Value = ""
            lblEspacioSeleccionado.Text = "Seleccione un espacio para habilitar el formulario"
            lblEspacioSeleccionado.CssClass = "badge bg-secondary"

            ' limpiar inputs
            txtPlaca.Text = ""
            ddlTipo.SelectedValue = "0"
            txtMarca.Text = ""
            txtColor.Text = ""
            txtHoraEntrada.Text = ""

        Else
            ' Si falló el INSERT, volvemos a dejar el espacio disponible (para no “bloquearlo”)
            Dim sqlLiberar As String = "
                UPDATE Espacio
                SET Estado='Disponible', FechaActualizacion=SYSDATETIME()
                WHERE IdEspacio=@IdEspacio;"

            dbHelper.ExecuteNonQuery(sqlLiberar, parametrosOcupar)

            SwalUtils.ShowSwalError(Me, "Error", "No se pudo registrar.")
        End If

    End Sub

    Protected Sub btnVerVehiculos_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/pages/EmpleadoVehiculo.aspx")
    End Sub

    Protected Sub btnVerEspacios_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/pages/EmpleadoEspacio.aspx")
    End Sub

End Class