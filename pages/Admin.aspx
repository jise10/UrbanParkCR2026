<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Admin.aspx.vb" Inherits="UrbanParkCR2026.Admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard Admin</title>

    <!-- CSS -->
    <link href="~/Content/dashboard.css" rel="stylesheet" />
</head>

<body>
<form id="form1" runat="server">

    <!-- SIDEBAR -->
    <div class="sidebar">
        <h2>🚗 UrbanPark</h2>
        <a href="Admin.aspx">🏠 Dashboard</a>
        <a href="Registro.aspx">👤 Usuarios</a>
        <a href="Tarifas.aspx">💰 Tarifas</a>
        <a href="Reportes.aspx">📊 Reportes</a>
        <a href="Logout.aspx">🚪 Logout</a>
    </div>

    <!-- MAIN -->
    <div class="main">

    <h1>Dashboard</h1>

    <!-- CARDS -->
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

    <!-- 🔥 SECCIÓN USUARIOS (AHORA SÍ BIEN UBICADA) -->
    <div class="usuarios-section">

        <h2>👤 Gestión de Usuarios</h2>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            CssClass="tabla-usuarios" DataKeyNames="IdUsuario">

            <Columns>

                <asp:BoundField DataField="IdUsuario" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" />

                <asp:TemplateField HeaderText="Rol">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlRol" runat="server" CssClass="input-tabla">
                            <asp:ListItem Text="Admin" Value="Admin" />
                            <asp:ListItem Text="Empleado" Value="Empleado" />
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Activo">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkActivo" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server"
                            Text="✏️" CssClass="btn-editar" />
                        <asp:Button ID="btnEliminar" runat="server"
                            Text="🗑" CssClass="btn-eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>

</div>
 
    <!-- 🔥 SECCIÓN USUARIOS -->
<div class="usuarios-section">

    <h2>👤 Gestión de Usuarios</h2>

    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False"
        CssClass="tabla-usuarios" DataKeyNames="IdUsuario">

        <Columns>

            <asp:BoundField DataField="IdUsuario" HeaderText="ID" ReadOnly="True" />

            <asp:BoundField DataField="Correo" HeaderText="Correo" />

            <asp:TemplateField HeaderText="Rol">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="input-tabla">
                        <asp:ListItem Text="Admin" Value="Admin" />
                        <asp:ListItem Text="Empleado" Value="Empleado" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Activo">
                <ItemTemplate>
                    <asp:CheckBox ID="chkActivo" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>

                    <asp:Button ID="btnEditar" runat="server"
                        Text="✏️"
                        CssClass="btn-editar" />

                    <asp:Button ID="btnEliminar" runat="server"
                        Text="🗑"
                        CssClass="btn-eliminar" />

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</div>

</form>
</body>
</html>