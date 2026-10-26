<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_Comercio_Libreria.Login" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Iniciar sesión - Librería Escolar</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #4e73df 0%, #224abe 100%);
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 20px;
        }

        .login-card {
            background: #ffffff;
            width: 100%;
            max-width: 380px;
            padding: 40px 32px;
            border-radius: 12px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
        }

        .login-card h1 {
            font-size: 24px;
            color: #2d3748;
            text-align: center;
            margin-bottom: 4px;
        }

        .subtitle {
            text-align: center;
            color: #718096;
            font-size: 14px;
            margin-bottom: 28px;
        }

        .form-group {
            margin-bottom: 18px;
        }

        .form-group label {
            display: block;
            font-size: 14px;
            color: #4a5568;
            margin-bottom: 6px;
            font-weight: 500;
        }

        .input {
            width: 100%;
            padding: 12px 14px;
            font-size: 15px;
            border: 1px solid #cbd5e0;
            border-radius: 8px;
            outline: none;
            transition: border-color 0.2s, box-shadow 0.2s;
            font-family: inherit;
        }

        .input:focus {
            border-color: #4e73df;
            box-shadow: 0 0 0 3px rgba(78, 115, 223, 0.15);
        }

        .btn {
            width: 100%;
            padding: 12px;
            background: #4e73df;
            color: #fff;
            border: none;
            border-radius: 8px;
            font-size: 15px;
            font-weight: 600;
            cursor: pointer;
            margin-top: 8px;
            transition: background 0.2s;
            font-family: inherit;
        }

        .btn:hover {
            background: #3b5bcc;
        }

        .error {
            display: block;
            margin-top: 16px;
            padding: 10px;
            background: #fed7d7;
            color: #c53030;
            border-radius: 8px;
            font-size: 14px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-card">
            <h1>Librería Escolar</h1>
            <p class="subtitle">Iniciar sesión</p>

            <div class="form-group">
                <label for="txtUsuario">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="input" />
            </div>

            <div class="form-group">
                <label for="txtPassword">Contraseña</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input" />
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" CssClass="btn" OnClick="btnLogin_Click" />

            <asp:Label ID="lblError" runat="server" CssClass="error" Visible="false" />
        </div>
    </form>
</body>
</html>