<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Admin.aspx.vb" Inherits="UrbanParkCR2026.Admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard Admin</title>
    <link href="~/Content/dashboard.css" rel="stylesheet" />
</head>

<body>
<form id="form1" runat="server">

    <div class="sidebar">
        <h2>🚗 UrbanPark</h2>
        <a href="Admin.aspx">🏠 Dashboard</a>
        <a href="Registro.aspx">👤 Usuarios</a>
        <a href="Tarifas.aspx">💰 Tarifas</a>
        <a href="Login.aspx">🚪 Logout</a>
    </div>

    <div class="main">

        <h1>Dashboard</h1>

        <div class="cards">
            <div class="card">
                <h3>Ganancias Hoy</h3>
                <p><asp:Label ID="lblGananciaHoy" runat="server" /></p>
            </div>

            <div class="card">
                <h3>Vehículos Hoy</h3>
                <p><asp:Label ID="lblVehiculos" runat="server" /></p>
            </div>

            <div class="card">
                <h3>Espacios Ocupados</h3>
                <p><asp:Label ID="lblEspacios" runat="server" /></p>
            </div>
        </div>

        <div class="usuarios-section">

            <h2>👤 Gestión de Usuarios</h2>
            <asp:GridView ID="gvUsuarios" runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="IdPersona">

    <Columns>

        <asp:BoundField DataField="IdPersona" HeaderText="ID" />

        <asp:TemplateField HeaderText="Correo">
            <ItemTemplate>
                <asp:Label ID="lblCorreo" runat="server"
                    Text='<%# Eval("Username") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Rol">
            <ItemTemplate>
                <asp:DropDownList ID="ddlRol" runat="server"
                    SelectedValue='<%# Eval("Rol") %>'>
                    <asp:ListItem Text="Admin" Value="ADMIN" />
                    <asp:ListItem Text="Usuario" Value="USER" />
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Activo">
            <ItemTemplate>
                <asp:CheckBox ID="chkActivo" runat="server"
                    Checked='<%# Eval("Activo") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>

                <asp:Button runat="server"
                    Text="Guardar"
                    CommandName="Editar"
                    CommandArgument='<%# Eval("IdPersona") %>' />

                <asp:Button runat="server"
                    Text="Eliminar"
                    CommandName="Eliminar"
                    CommandArgument='<%# Eval("IdPersona") %>' />

            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>


        </div>

    </div>

</form>
</body>
</html>