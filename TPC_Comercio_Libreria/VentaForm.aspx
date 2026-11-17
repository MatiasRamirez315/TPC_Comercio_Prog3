<%@ Page Title="Nueva venta - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="VentaForm.aspx.cs" Inherits="TPC_Comercio_Libreria.VentaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Nueva venta</h1>
            <p>Registrá una venta a un cliente</p>
        </div>
        <a href="Ventas.aspx" class="btn btn-outline-secondary">← Volver al listado</a>
    </div>

    <div class="page-card">
        <asp:Label ID="lblError" runat="server"
                   CssClass="alert alert-danger d-block mb-3"
                   Visible="false" />

        <div class="row g-3">

            <div class="col-md-6">
                <label class="form-label">Cliente <span class="text-danger">*</span></label>
                <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-select" />
            </div>

            <div class="col-md-6">
                <label class="form-label">Método de pago <span class="text-danger">*</span></label>
                <asp:DropDownList ID="ddlMetodoPago" runat="server" CssClass="form-select">
                    <asp:ListItem Text="-- Seleccione --" Value="" />
                    <asp:ListItem Text="Efectivo" Value="EFECTIVO" />
                    <asp:ListItem Text="Tarjeta" Value="TARJETA" />
                    <asp:ListItem Text="Transferencia" Value="TRANSFERENCIA" />
                    <asp:ListItem Text="MercadoPago" Value="MERCADOPAGO" />
                </asp:DropDownList>
            </div>

            <div class="col-md-8">
                <label class="form-label">Producto <span class="text-danger">*</span></label>
                <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-select"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" />
            </div>

            <div class="col-md-4">
                <label class="form-label">Cantidad <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"
                    TextMode="Number" Text="1" AutoPostBack="true"
                    OnTextChanged="txtCantidad_TextChanged" />
            </div>

            <div class="col-12">
                <div class="alert alert-info mb-0">
                    <asp:Label ID="lblInfoProducto" runat="server" Text="Seleccioná un producto para ver el precio y el stock." />
                </div>
            </div>

            <div class="col-12">
                <div class="alert alert-success mb-0">
                    <asp:Label ID="lblTotal" runat="server" Text="" Font-Bold="true" Font-Size="Large" />
                </div>
            </div>

        </div>

        <div class="mt-4 d-flex gap-2">
            <asp:Button ID="btnGuardar" runat="server" Text="Registrar venta"
                        CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"
                        CssClass="btn btn-outline-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

</asp:Content>