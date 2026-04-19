<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="UrbanParkCR2026.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>UrbanParkCR - Login</title>
    <link href="~/Content/login.css" rel="stylesheet" runat="server" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</head>
<body>

<form id="form1" runat="server">

    <div class="container">

        <!-- LADO IZQUIERDO -->
        <div class="left">

            <h2 class="logo">UrbanParkCR</h2>

            <h1>
                Enter Your <br />
                <span>Email & Password</span>
            </h1>

            <label>Email Address</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input" placeholder="example@gmail.com"></asp:TextBox>

            <label>Password</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="input" TextMode="Password" placeholder="********"></asp:TextBox>

            <div class="options">
                <label>
                    <asp:CheckBox ID="chkRecordar" runat="server" />
                    Keep me logged in
                </label>

                <a href="Registro.aspx">Forgot Password?</a>
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" />

        </div>

        <!-- LADO DERECHO -->
        <div class="right">
    <div class="image-container">
        <img src='<%= ResolveUrl("~/Content/images/fondo7.jpg") %>' />
    </div>
</div>
    

    </div>

</form>

</body>
</html>