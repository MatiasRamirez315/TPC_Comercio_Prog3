<%@ Page Title="Usuario - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="UsuarioForm.aspx.cs" Inherits="TPC_Comercio_Libreria.UsuarioForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1><asp:Label ID="lblTitulo" runat="server" Text="Nuevo usuario" /></h1>
            <p><asp:Label ID="lblSubtitulo" runat="server" Text="Completá los datos para dar de alta un usuario" /></p>
        </div>
        <a href="Usuarios.aspx" class="btn btn-outline-secondary">← Volver al listado</a>
    </div>

    <div class="page-card">
        <asp:Label ID="lblError" runat="server"
                   CssClass="alert alert-danger d-block mb-3"
                   Visible="false" />

        <div class="row g-3">
            <div class="col-md-6">
                <label class="form-label">Nombre de usuario <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" MaxLength="50" />
            </div>
            <div class="col-md-6">
                <label class="form-label">
                    Contraseña
                    <asp:Label ID="lblObligatoriaPass" runat="server" Text="*" CssClass="text-danger" />
                </label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" MaxLength="100" />
                <small class="text-muted d-block mt-1" id="pwdHelp" runat="server" visible="false">
                    Dejala vacía para conservar la contraseña actual.
                </small>
            </div>
            <div class="col-md-6">
                <label class="form-label">Rol <span class="text-danger">*</span></label>
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Vendedor" Value="VENDEDOR" />
                    <asp:ListItem Text="Administrador" Value="ADMIN" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="mt-4 d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

</asp:Content>