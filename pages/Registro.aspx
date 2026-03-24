<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="UrbanParkCR2026.Registro" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title>Registro</title>
    <link href="~/Content/registro.css" rel="stylesheet" runat="server" />
</head>
<body>

<form id="form1" runat="server">

    <div class="container">

        <!-- IZQUIERDA (FORMULARIO) -->
        <div class="left">

            <h2 class="logo">UrbanParkCR</h2>

            <h1>
                Create Your <br />
                <span>Account</span>
            </h1>

            <!-- NOMBRE -->
            <label>Nombre Completo</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="input" placeholder="Tu nombre"></asp:TextBox>

            <!-- EMAIL -->
            <label>Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input" placeholder="example@gmail.com"></asp:TextBox>

            <!-- PASSWORD -->
            <label>Contraseña</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="input" TextMode="Password" placeholder="********"></asp:TextBox>

            <!-- CONFIRMAR -->
            <label>Confirmar Contraseña</label>
            <asp:TextBox ID="txtConfirmar" runat="server" CssClass="input" TextMode="Password" placeholder="********"></asp:TextBox>

            <!-- BOTÓN -->
            <asp:Button ID="btnRegistrar" runat="server" Text="Crear Cuenta" CssClass="btn" />

            <!-- LINK LOGIN -->
            <p class="login-link">
                ¿Ya tienes cuenta?
                <a href="Login.aspx">Iniciar sesión</a>
            </p>

        </div>

        <!-- DERECHA (IMAGEN) -->
        <div class="right">
            <img src='<%= ResolveUrl("~/Content/images/1.webp") %>' />
        </div>

    </div>

</form>

</body>
</html>