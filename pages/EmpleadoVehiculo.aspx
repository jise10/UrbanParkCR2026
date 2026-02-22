<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EmpleadoVehiculo.aspx.vb" Inherits="UrbanParkCR2026.EmpleadoVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Listado de Vehículos Registrados</h2>

<br />

<asp:GridView ID="gvVehiculos"
    runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="IdVehiculo"
    CssClass="table table-bordered table-striped"
    Width="100%"
    OnRowDeleting="gvVehiculos_RowDeleting">

    <Columns>

        <asp:BoundField DataField="IdVehiculo"
            HeaderText="ID"
            ReadOnly="True" />

        <asp:BoundField DataField="Placa"
            HeaderText="Placa" />

        <asp:BoundField DataField="Tipo"
            HeaderText="Tipo" />

        <asp:BoundField DataField="Marca"
            HeaderText="Marca" />

        <asp:BoundField DataField="Color"
            HeaderText="Color" />

        <asp:BoundField DataField="HoraEntrada"
            HeaderText="Hora Entrada"
            DataFormatString="{0:dd/MM/yyyy HH:mm}" />

        <asp:CommandField ShowDeleteButton="True" />

    </Columns>

</asp:GridView>

<br />

<asp:Label ID="lblMensaje" runat="server"></asp:Label>

</asp:Content>
