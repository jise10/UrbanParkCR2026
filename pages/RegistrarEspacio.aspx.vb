Imports System.Data
Imports System.Data.SqlClient
Imports UrbanParkCR2026.dbVehiculo
Imports UrbanParkCR2026.dbEspacio ' 
Imports UrbanParkCR2026.Models
Imports UrbanParkCR2026.Utils

Public Class RegistrarEspacio
    Inherits System.Web.UI.Page

    Private dbVehiculo As New VehiculoDB()
    Private dbHelper As New DbHelper()
    Private dbEspacio As New EspacioDB() ' 

    ' 🔥 MÉTODO PARA ABRIR MODAL
    Private Sub AbrirModal()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "modal",
        "var myModal = new bootstrap.Modal(document.getElementById('modalVehiculo')); myModal.show();", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarEspacios()
            hfEspacioId.Value = ""
            lblEspacioSeleccionado.Text = "Seleccione un espacio para habilitar el formulario"
            lblEspacioSeleccionado.CssClass = "badge bg-secondary"
        End If
    End Sub

    '========================
    ' CARGAR ESPACIOS
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

    '========================
    ' SELECCIONAR ESPACIO
    '========================
    Protected Sub rptEspacios_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptEspacios.ItemCommand

        If e.CommandName = "select" Then

            ' 🔥 Separar ID y Tipo
            Dim datos() As String = e.CommandArgument.ToString().Split("|"c)

            Dim idEspacio As String = datos(0)
            Dim tipo As String = datos(1)

            ' Guardar ID
            hfEspacioId.Value = idEspacio

            ' Mostrar info
            lblEspacioSeleccionado.Text = "Espacio seleccionado: " & idEspacio & " (" & tipo & ")"
            lblEspacioSeleccionado.CssClass = "badge bg-success"

            ' 🔥 Seleccionar automáticamente el tipo
            ddlTipo.SelectedValue = tipo

            ' 🔥 Bloquear dropdown (para que no sea redundante)
            ddlTipo.Enabled = False

            ' Abrir modal
            AbrirModal()

        End If

    End Sub


    '========================
    ' GUARDAR VEHÍCULO
    '========================
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        '  VALIDACIONES WEBFORMS
        If Not Page.IsValid Then
            AbrirModal()
            Return
        End If

        ' 1) Validar espacio
        If String.IsNullOrWhiteSpace(hfEspacioId.Value) Then
            SwalUtils.ShowSwalError(Me, "Error", "Debe seleccionar un espacio antes de registrar.")
            AbrirModal()
            Return
        End If

        Dim idEspacio As Integer
        If Not Integer.TryParse(hfEspacioId.Value, idEspacio) Then
            SwalUtils.ShowSwalError(Me, "Error", "Espacio inválido.")
            AbrirModal()
            Return
        End If

        ' 2) Crear objeto
        Dim vehiculo As New Vehiculo()
        vehiculo.Placa = txtPlaca.Text.Trim()
        vehiculo.Tipo = ddlTipo.SelectedValue
        vehiculo.Marca = txtMarca.Text.Trim()
        vehiculo.Color = txtColor.Text.Trim()
        vehiculo.HoraEntrada = Convert.ToDateTime(txtHoraEntrada.Text)
        vehiculo.IdEspacio = idEspacio

        '  VALIDAR TIPO (CAPA DB)
        Dim tipoPermitido As String = dbEspacio.ObtenerTipoPermitido(idEspacio)

        If vehiculo.Tipo <> tipoPermitido Then
            SwalUtils.ShowSwalError(Me, "Error", "Este espacio es solo para: " & tipoPermitido)
            AbrirModal()
            Return
        End If

        ' 3) Ocupar espacio
        Dim sqlOcupar As String = "
            UPDATE Espacio
            SET Estado='Ocupado', FechaActualizacion=SYSDATETIME()
            WHERE IdEspacio=@IdEspacio AND Estado='Disponible';"

        Dim parametrosOcupar As New List(Of SqlParameter) From {
            New SqlParameter("@IdEspacio", idEspacio)
        }

        Dim filas As Integer = dbHelper.ExecuteNonQuery(sqlOcupar, parametrosOcupar)

        If filas = 0 Then
            SwalUtils.ShowSwalError(Me, "Espacio no disponible", "Ese espacio ya fue ocupado.")
            CargarEspacios()

            hfEspacioId.Value = ""
            lblEspacioSeleccionado.Text = "Seleccione un espacio"
            lblEspacioSeleccionado.CssClass = "badge bg-secondary"

            Return
        End If

        ' 4) Insertar
        Dim id As Integer = dbVehiculo.InsertarVehiculo(vehiculo)

        If id > 0 Then
            SwalUtils.ShowSwal(Me, "Registro exitoso",
                              $"Vehículo {vehiculo.Placa} registrado con ID {id}.",
                              "success")

            CargarEspacios()

            hfEspacioId.Value = ""
            lblEspacioSeleccionado.Text = "Seleccione un espacio"
            lblEspacioSeleccionado.CssClass = "badge bg-secondary"

            txtPlaca.Text = ""
            ddlTipo.SelectedValue = "0"
            txtMarca.Text = ""
            txtColor.Text = ""
            txtHoraEntrada.Text = ""

        Else
            Dim sqlLiberar As String = "
                UPDATE Espacio
                SET Estado='Disponible', FechaActualizacion=SYSDATETIME()
                WHERE IdEspacio=@IdEspacio;"

            dbHelper.ExecuteNonQuery(sqlLiberar, parametrosOcupar)

            SwalUtils.ShowSwalError(Me, "Error", "No se pudo registrar.")
            AbrirModal()
        End If

    End Sub

End Class