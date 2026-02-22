<%@ Page Title="Registrar Espacio" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    CodeBehind="RegistrarEspacio.aspx.vb"
    Inherits="UrbanParkCR2026.RegistrarEspacio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registrar Entrada Vehículo</h2>

    <%-- PLACA --%>
    <div class="form-group">
        <asp:Label ID="lblPlaca" runat="server" Text="Placa:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtPlaca" runat="server" CssClass="form-control"
            placeholder="Ej: ABC123"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvPlaca" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="txtPlaca"
        ErrorMessage=" Debe ingresar la placa">
    </asp:RequiredFieldValidator>


    <%-- TIPO --%>
    <div class="form-group">
        <asp:Label ID="lblTipo" runat="server" Text="Tipo Vehículo:" CssClass="control-label"></asp:Label>

        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione un tipo" Value="0"></asp:ListItem>
            <asp:ListItem Text="Automóvil" Value="Automóvil"></asp:ListItem>
            <asp:ListItem Text="Moto" Value="Moto"></asp:ListItem>
            <asp:ListItem Text="Camión" Value="Camión"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:RequiredFieldValidator ID="rfvTipo" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        InitialValue="0"
        ControlToValidate="ddlTipo"
        ErrorMessage=" Seleccione el tipo de vehículo">
    </asp:RequiredFieldValidator>


    <%-- MARCA --%>
    <div class="form-group">
        <asp:Label ID="lblMarca" runat="server" Text="Marca:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control"
            placeholder="Ej: Toyota"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvMarca" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="txtMarca"
        ErrorMessage=" Debe ingresar la marca">
    </asp:RequiredFieldValidator>


    <%-- COLOR --%>
    <div class="form-group">
        <asp:Label ID="lblColor" runat="server" Text="Color:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtColor" runat="server" CssClass="form-control"
            placeholder="Ej: Rojo"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvColor" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="txtColor"
        ErrorMessage=" Debe ingresar el color">
    </asp:RequiredFieldValidator>


    <%-- HORA ENTRADA --%>
    <div class="form-group">
        <asp:Label ID="lblHora" runat="server" Text="Hora Entrada:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtHoraEntrada" runat="server"
            CssClass="form-control"
            TextMode="DateTimeLocal"></asp:TextBox>
    </div>

    <asp:RequiredFieldValidator ID="rfvHora" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="txtHoraEntrada"
        ErrorMessage=" Debe ingresar la hora de entrada">
    </asp:RequiredFieldValidator>


    <%-- BOTÓN GUARDAR --%>
    <div class="py-3">
        <asp:Button ID="btnGuardar" runat="server"
            Text="Registrar"
            CssClass="btn btn-primary"
            OnClick="btnGuardar_Click" />
    </div>

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
