<%@ Page Title="Registrar Espacio" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    CodeBehind="RegistrarEspacio.aspx.vb"
    Inherits="UrbanParkCR2026.RegistrarEspacio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <!-- BOTÓN VOLVER -->
        <div class="d-flex justify-content-end mb-2">
            <asp:Button ID="btnVolver" runat="server" Text="← Volver"
                CssClass="btn btn-secondary"
                PostBackUrl="Inicio.aspx" />
        </div>

        <!-- CONTENEDOR PRINCIPAL -->
        <div class="card p-4 contenedor-transparente">

            <h2>Registrar Entrada Vehículo</h2>

            <h4 class="mt-3">1 ) Selecciona un espacio</h4>
            <h4 class="mt-3">Tarifas</h4>
            <asp:GridView ID="gvTarifasCliente" runat="server"
                CssClass="table table-bordered"
                AutoGenerateColumns="False">

                <Columns>

                    <asp:BoundField DataField="TipoVehiculo" HeaderText="Tipo" />

                    <asp:BoundField DataField="PrecioHora" HeaderText="Precio por Hora (₡)" />

                </Columns>

            </asp:GridView>



            <div class="mb-2">
                <span class="badge bg-success">Disponible</span>
                <span class="badge bg-danger ms-1">Ocupado</span>
            </div>

            <asp:HiddenField ID="hfEspacioId" runat="server" />

            <div class="mb-3">
                <asp:Label ID="lblEspacioSeleccionado" runat="server"
                    CssClass="badge bg-secondary"
                    Text="Seleccione un espacio"></asp:Label>
            </div>

            <!-- ESPACIOS -->

            <div class="row">

                <asp:Repeater ID="rptEspacios" runat="server">
                    <ItemTemplate>

                        <div class="col-md-3 mb-3">

                            <div class='card shadow-sm h-100 espacio-card
<%# If(Eval("Estado").ToString() = "Disponible", "borde-disponible", "borde-ocupado") %>'>

                                <div class="card-body">

                                    <h5><%# Eval("Codigo") %></h5>

                                    <span class="badge bg-dark">
                                        <%# Eval("TipoPermitido") %>
                </span>

                                    <span class='badge <%# If(Eval("Estado").ToString() = "Disponible", "bg-success", "bg-danger") %>'>
                                        <%# Eval("Estado") %>
                </span>

                                    <div class="mt-2 small text-muted">
                                        Zona: <%# Eval("Zona") %><br />
                                        Nivel: <%# Eval("Nivel") %>
                                    </div>
                                    <asp:Button
                                        ID="btnSeleccionar"
                                        runat="server"
                                        Text="Seleccionar"
                                        CommandName="select"
                                        CommandArgument='<%# Eval("IdEspacio") & "|" & Eval("TipoPermitido") %>'
                                        Enabled='<%# Eval("Estado").ToString() = "Disponible" %>'
                                        CausesValidation="False"
                                        CssClass="btn btn-sm btn-outline-primary w-100 mt-3" />



                                </div>
                            </div>

                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>

    </div>

    <!--  MODAL (SE DEJA FUERA DEL CARD) -->
    <div class="modal fade" id="modalVehiculo" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <h5 class="modal-title">Registrar Vehículo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>

                <div class="modal-body">

                    <asp:ValidationSummary
                        ID="vsResumen"
                        runat="server"
                        CssClass="alert alert-danger"
                        DisplayMode="BulletList"
                        ValidationGroup="vgVehiculo" />

                    <asp:Panel ID="pnlFormulario" runat="server">

                        <asp:TextBox ID="txtPlaca" runat="server"
                            CssClass="form-control"
                            placeholder="Placa"></asp:TextBox>

                        <asp:RequiredFieldValidator
                            ID="rfvPlaca"
                            runat="server"
                            ControlToValidate="txtPlaca"
                            ErrorMessage="Ingrese la placa"
                            CssClass="text-danger"
                            ValidationGroup="vgVehiculo" />

                        <asp:DropDownList ID="ddlTipo" runat="server"
                            CssClass="form-control mt-2">
                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Automóvil"></asp:ListItem>
                            <asp:ListItem Text="Moto"></asp:ListItem>
                            <asp:ListItem Text="Camión"></asp:ListItem>
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator
                            ID="rfvTipo"
                            runat="server"
                            ControlToValidate="ddlTipo"
                            InitialValue="0"
                            ErrorMessage="Seleccione el tipo"
                            CssClass="text-danger"
                            ValidationGroup="vgVehiculo" />

                        <asp:TextBox ID="txtMarca" runat="server"
                            CssClass="form-control mt-2"
                            placeholder="Marca"></asp:TextBox>

                        <asp:RequiredFieldValidator
                            ID="rfvMarca"
                            runat="server"
                            ControlToValidate="txtMarca"
                            ErrorMessage="Ingrese la marca"
                            CssClass="text-danger"
                            ValidationGroup="vgVehiculo" />

                        <asp:TextBox ID="txtColor" runat="server"
                            CssClass="form-control mt-2"
                            placeholder="Color"></asp:TextBox>

                        <asp:RequiredFieldValidator
                            ID="rfvColor"
                            runat="server"
                            ControlToValidate="txtColor"
                            ErrorMessage="Ingrese el color"
                            CssClass="text-danger"
                            ValidationGroup="vgVehiculo" />

                        <asp:TextBox ID="txtHoraEntrada" runat="server"
                            CssClass="form-control mt-2"
                            TextMode="DateTimeLocal"></asp:TextBox>

                        <asp:RequiredFieldValidator
                            ID="rfvHora"
                            runat="server"
                            ControlToValidate="txtHoraEntrada"
                            ErrorMessage="Ingrese la hora"
                            CssClass="text-danger"
                            ValidationGroup="vgVehiculo" />

                        <asp:Button ID="btnGuardar" runat="server"
                            Text="Registrar"
                            CssClass="btn btn-primary w-100 mt-3"
                            ValidationGroup="vgVehiculo"
                            CausesValidation="true"
                            OnClick="btnGuardar_Click" />

                    </asp:Panel>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
