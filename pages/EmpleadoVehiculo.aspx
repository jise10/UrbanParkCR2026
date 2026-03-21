<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EmpleadoVehiculo.aspx.vb" Inherits="UrbanParkCR2026.EmpleadoVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvVehiculos"
    runat="server"
    AutoGenerateColumns="False"
   
    DataKeyNames="IdVehiculo,HoraEntrada"
    CssClass="table table-bordered table-striped"
    Width="100%"
    OnRowCommand="gvVehiculos_RowCommand">

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

        <asp:BoundField DataField="Codigo"
            HeaderText="Espacio" />

        <asp:BoundField DataField="HoraEntrada"
            HeaderText="Hora Entrada"
            DataFormatString="{0:dd/MM/yyyy HH:mm}" />

        <asp:TemplateField HeaderText="Acción">
            <ItemTemplate>
                <asp:Button ID="btnSalida"
                    runat="server"
                    Text="Registrar Salida"
                    CommandName="Salida"
                    CommandArgument='<%# Container.DataItemIndex %>'
                    CssClass="btn btn-danger btn-sm" />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>

</asp:Content>
