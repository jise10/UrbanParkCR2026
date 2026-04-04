<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Tarifas.aspx.vb" Inherits="UrbanParkCR2026.Tarifas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tarifas</title>

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
    .card {
        border-radius: 15px;
    }

    .table th {
        background-color: #007bff;
        color: white;
    }

    .btn-success {
        border-radius: 10px;
        transition: 0.3s;
    }

    .btn-success:hover {
        transform: scale(1.05);
    }
</style>

</head>

<body style="background:#f4f6f9;">

<form id="form1" runat="server">

<div class="container mt-5">

    <div class="card shadow-lg p-4">

        <h2 class="mb-4 text-center">💰 Gestión de Tarifas</h2>

        <asp:GridView ID="gvTarifas" runat="server" AutoGenerateColumns="False"
            CssClass="table table-bordered table-hover text-center align-middle">

            <Columns>

                <asp:BoundField DataField="TipoVehiculo" HeaderText="🚗 Tipo de Vehículo" />

                <asp:TemplateField HeaderText="💵 Precio por Hora (₡)">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPrecio" runat="server"
                            Text='<%# Eval("PrecioHora") %>'
                            CssClass="form-control text-center" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

        <div class="text-end mt-3">
            <asp:Button ID="btnGuardar" runat="server"
                Text="💾 Guardar Cambios"
                CssClass="btn btn-success px-4"
                OnClick="btnGuardar_Click" />
        </div>

    </div>

</div>

</form>

</body>
</html>