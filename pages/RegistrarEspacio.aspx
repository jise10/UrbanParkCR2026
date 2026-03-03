<%@ Page Title="Registrar Espacio" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    CodeBehind="RegistrarEspacio.aspx.vb"
    Inherits="UrbanParkCR2026.RegistrarEspacio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registrar Entrada Vehículo</h2>

    <%-- =========================
         1) ESPACIOS (CARDS)
         ========================= --%>

    <h4 class="mt-3">1) Selecciona un espacio</h4>

    <div class="mb-2">
        <span class="badge bg-success">Disponible</span>
        <span class="badge bg-danger ms-1">Ocupado</span>
    </div>

    <asp:HiddenField ID="hfEspacioId" runat="server" />

    <div class="mb-3">
        <asp:Label ID="lblEspacioSeleccionado" runat="server"
            CssClass="badge bg-secondary"
            Text="Seleccione un espacio para habilitar el formulario"></asp:Label>
    </div>

    <asp:Repeater ID="rptEspacios" runat="server">

        <ItemTemplate>

            <div class='card d-inline-block m-2 shadow-sm
                <%# If(Eval("Estado").ToString() = "Disponible", "border-success", "border-danger") %>'
                style="width: 13rem;">

                <div class="card-body">
                    <div class="d-flex justify-content-between align-items-center">

                        <div>
                            <h5 class="card-title mb-0">
                                <%# Eval("Codigo") %>
                            </h5>

                            <span class="badge bg-dark">
                                <%# Eval("TipoPermitido") %>
                            </span>
                        </div>

                        <span class='badge <%# If(Eval("Estado").ToString() = "Disponible", "bg-success", "bg-danger") %>'>
                            <%# Eval("Estado") %>
                        </span>

                    </div>




                    <div class="mt-2 small text-muted">
                        Zona: <%# Eval("Zona") %><br />
                        Nivel: <%# Eval("Nivel") %>
                    </div>

                    <asp:Button
                        ID="btnSeleccionar"
                        runat="server"
                        Text="Seleccionar"
                        CommandName="select"
                        CommandArgument='<%# Eval("IdEspacio") %>'
                        Enabled='<%# Eval("Estado").ToString() = "Disponible" %>'
                        CssClass='btn btn-sm w-100 mt-3
                            <%# If(Eval("Estado").ToString() = "Disponible", "btn-outline-primary", "btn-secondary") %>' />
                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>

    <hr class="my-4" />

    <%-- =========================
         2) FORMULARIO
         ========================= --%>

    <h4>2) Completa los datos del vehículo</h4>

    <asp:Panel ID="pnlFormulario" runat="server">

        <%-- PLACA --%>
        <div class="form-group">
            <asp:Label ID="lblPlaca" runat="server" Text="Placa:" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtPlaca" runat="server" CssClass="form-control" placeholder="Ej: ABC123"></asp:TextBox>
        </div>

        <asp:RequiredFieldValidator ID="rfvPlaca" runat="server"
            CssClass="text-danger" Display="Dynamic"
            ControlToValidate="txtPlaca"
            ErrorMessage="Debe ingresar la placa" />


        <%-- TIPO --%>
        <div class="form-group">
            <asp:Label ID="lblTipo" runat="server" Text="Tipo Vehículo:" CssClass="control-label"></asp:Label>


            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                <asp:ListItem Text="Seleccione un tipo" Value="0"></asp:ListItem>
                <asp:ListItem Text="Automóvil" Value="Automóvil"></asp:ListItem>
                <asp:ListItem Text="Moto" Value="Moto"></asp:ListItem>
                <asp:ListItem Text="Camión" Value="Camión"></asp:ListItem>


            </asp:DropDownList>
        </div>

        <asp:RequiredFieldValidator ID="rfvTipo" runat="server"
            CssClass="text-danger" Display="Dynamic"
            InitialValue="0"
            ControlToValidate="ddlTipo"
            ErrorMessage="Seleccione el tipo de vehículo" />


        <%-- MARCA --%>
        <div class="form-group">
            <asp:Label ID="lblMarca" runat="server" Text="Marca:" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" placeholder="Ej: Toyota"></asp:TextBox>
        </div>

        <asp:RequiredFieldValidator ID="rfvMarca" runat="server"
            CssClass="text-danger" Display="Dynamic"
            ControlToValidate="txtMarca"
            ErrorMessage="Debe ingresar la marca" />


        <%-- COLOR --%>
        <div class="form-group">
            <asp:Label ID="lblColor" runat="server" Text="Color:" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtColor" runat="server" CssClass="form-control" placeholder="Ej: Rojo"></asp:TextBox>
        </div>

        <asp:RequiredFieldValidator ID="rfvColor" runat="server"
            CssClass="text-danger" Display="Dynamic"
            ControlToValidate="txtColor"
            ErrorMessage="Debe ingresar el color" />


        <%-- HORA ENTRADA --%>
        <div class="form-group">
            <asp:Label ID="lblHora" runat="server" Text="Hora Entrada:" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtHoraEntrada" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
        </div>

        <asp:RequiredFieldValidator ID="rfvHora" runat="server"
            CssClass="text-danger" Display="Dynamic"
            ControlToValidate="txtHoraEntrada"
            ErrorMessage="Debe ingresar la hora de entrada" />


        <%-- BOTÓN GUARDAR --%>
        <div class="py-3">
            <asp:Button ID="btnGuardar" runat="server"
                Text="Registrar"
                CssClass="btn btn-primary"
                OnClick="btnGuardar_Click" />
        </div>

    </asp:Panel>

    <%-- MENSAJE --%>
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>

    <div class="py-2">
        <asp:Button ID="btnVerVehiculos"
            runat="server"
            Text="Ver Vehículos Registrados"
            CssClass="btn btn-secondary"
            OnClick="btnVerVehiculos_Click" />
    </div>

</asp:Content>
