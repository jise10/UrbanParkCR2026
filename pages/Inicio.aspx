<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="UrbanParkCR2026.Inicio" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Inicio</title>
    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: linear-gradient(rgba(0,0,0,0.8), rgba(0,0,0,0.8)), url('https://images.unsplash.com/photo-1506521781263-d8422e82f27a');
            background-size: cover;
            background-position: center;
            height: 100vh;
        }

        .card-inicio {
            background: rgba(0,0,0,0.7);
            border-radius: 15px;
            padding: 40px;
            color: white;
        }

        .btn-custom {
            background-color: #ffc107;
            border: none;
            font-weight: bold;
            transition: 0.3s;
        }

            .btn-custom:hover {
                transform: scale(1.05);
                box-shadow: 0px 4px 10px rgba(255,193,7,0.6);
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
            <div class="card-inicio text-center shadow">
                <h1 style="color: #ffc107;">SISTEMA DE PARQUEO</h1>
                <p class="mb-4">Bienvenido al sistema de UrbanParkCR</p>
                <asp:Button ID="btnRegistrar" runat="server" Text="🚗 Registrar Espacio" CssClass="btn btn-custom btn-lg w-100" OnClick="btnRegistrar_Click" /></div>
        </div>
    </form>
</body>
</html>
