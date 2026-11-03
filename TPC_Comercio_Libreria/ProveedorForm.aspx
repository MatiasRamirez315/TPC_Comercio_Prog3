<%@ Page Title="Proveedor - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="ProveedorForm.aspx.cs" Inherits="TPC_Comercio_Libreria.ProveedorForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1><asp:Label ID="lblTitulo" runat="server" Text="Nuevo proveedor" /></h1>
            <p><asp:Label ID="lblSubtitulo" runat="server" Text="Completá los datos para dar de alta un proveedor" /></p>
        </div>
        <a href="Proveedores.aspx" class="btn btn-outline-secondary">← Volver al listado</a>
    </div>

    <div class="page-card">
        <asp:Label ID="lblError" runat="server"
                   CssClass="alert alert-danger d-block mb-3"
                   Visible="false" />

        <div class="row g-3">
            <div class="col-md-6">
                <label class="form-label">Nombre <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="150" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" MaxLength="300"
                             placeholder="Qué productos o servicios provee" />
            </div>
            <div class="col-md-6">
                <label class="form-label">CUIT</label>
                <asp:TextBox ID="txtCuit" runat="server" CssClass="form-control" MaxLength="20" placeholder="30-71234567-1" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="50" />
            </div>
            <div class="col-12">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" MaxLength="150" />
            </div>
        </div>

        <div class="mt-4 d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

</asp:Content>