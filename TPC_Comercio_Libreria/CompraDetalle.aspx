<%@ Page Title="Detalle Compra - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="CompraDetalle.aspx.cs" Inherits="TPC_Comercio_Libreria.CompraDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Compra #<asp:Label ID="lblNumeroCompra" runat="server"></asp:Label></h1>
            <p>
                <asp:Label ID="lblFecha" runat="server" />
                &nbsp;·&nbsp;
             <asp:Label ID="lblEstado" runat="server" />
            </p>
        </div>
        <div class="d-flex gap-2">
            <button type="button" class="btn btn-outline-secondary"
                onclick="window.print();">
                🖨 Imprimir</button>
            <a href="Compras.aspx" class="btn btn-outline-secondary">← Volver al listado</a>
        </div>
    </div>

    <div class="page-card mb-3">
        <h2 class="menu-seccion" style="margin-top: 0;">Datos del proveedor</h2>
        <div class="row g-3">
            <div class="col-md-6">
                <label class="form-label">Proveedor</label>
                <div>
                    <asp:Label ID="lblProveedor" runat="server" Font-Bold="true" />
                </div>
            </div>
            <div class="col-md-6">
                <label class="form-label">CUIT</label>
                <div>
                    <asp:Label ID="lblCuit" runat="server" />
                </div>
            </div>
            <div class="col-md-6">
                <label class="form-label">Nº de factura</label>
                <div>
                    <asp:Label ID="lblNumeroFactura" runat="server" />
                </div>
            </div>
            <div class="col-md-6">
                <label class="form-label">Total</label>
                <div>
                    <asp:Label ID="lblTotal" runat="server" Font-Bold="true" Font-Size="Large" />
                </div>
            </div>
        </div>
    </div>

    <div class="page-card mb-3">
        <h2 class="menu-seccion" style="margin-top: 0;">Productos Ingresados</h2>
        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead>
                    <tr>
                        <th>Código</th>
                        <th>Producto</th>
                        <th class="text-center">Cantidad</th>
                        <th class="text-end">Precio Unitario</th>
                        <th class="text-end">Subtotal</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repDetalle" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("CodigoProducto") %></td>
                                <td><%# Eval("NombreProducto") %></td>
                                <td class="text-center"><%# Eval("Cantidad") %></td>
                                <td class="text-end">$ <%# Eval("PrecioCompra", "{0:N2}") %></td>
                                <td class="text-end">$ <%# Eval("Subtotal", "{0:N2}") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="4" class="text-end fw-bold">Total:</td>
                        <td class="text-end fw-bold">$
                            <asp:Label ID="lblTotalProd" runat="server" />
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>

        <style>
        @media print {
            .navbar, .page-header .btn, .page-header button { display: none !important; }
            .page-card { box-shadow: none !important; border: none !important; }
            body { background: white !important; }
        }
    </style>

</asp:Content>
