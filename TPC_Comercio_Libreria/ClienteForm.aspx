<%@ Page Title="Nuevo cliente - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="ClienteForm.aspx.cs" Inherits="TPC_Comercio_Libreria.ClienteForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Nuevo cliente</h1>
            <p>Completá los datos para dar de alta un cliente</p>
        </div>
        <a href="Clientes.aspx" class="btn btn-outline-secondary">← Volver al listado</a>
    </div>

    <div class="page-card">
        <asp:Label ID="lblError" runat="server"
                   CssClass="alert alert-danger d-block mb-3"
                   Visible="false" />

        <div class="row g-3">
            <div class="col-md-6">
                <label class="form-label">Nombre <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100" />
            </div>
            <div class="col-md-6">
                <label class="form-label">CUIT</label>
                <asp:TextBox ID="txtCuit" runat="server" CssClass="form-control" MaxLength="20" placeholder="30-71234567-1" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="20" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" MaxLength="100" />
            </div>
            <div class="col-12">
                <label class="form-label">Dirección</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="200" />
            </div>
        </div>

        <div class="mt-4 d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

</asp:Content>