<%@ Page Title="Tipo - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="TipoForm.aspx.cs" Inherits="TPC_Comercio_Libreria.TipoForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1><asp:Label ID="lblTitulo" runat="server" Text="Nuevo tipo" /></h1>
            <p><asp:Label ID="lblSubtitulo" runat="server" Text="Completá los datos para dar de alta un tipo" /></p>
        </div>
        <a href="Tipos.aspx" class="btn btn-outline-secondary">← Volver al listado</a>
    </div>

    <div class="page-card">
        <asp:Label ID="lblError" runat="server"
                   CssClass="alert alert-danger d-block mb-3"
                   Visible="false" />

        <div class="row g-3">
            <div class="col-md-8">
                <label class="form-label">Descripción <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" MaxLength="100" />
            </div>
        </div>

        <div class="mt-4 d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

</asp:Content>