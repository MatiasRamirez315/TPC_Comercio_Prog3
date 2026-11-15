<%@ Page Title="Detalle de venta - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="VentaDetalle.aspx.cs" Inherits="TPC_Comercio_Libreria.VentaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Venta #<asp:Label ID="lblNumeroVenta" runat="server" /></h1>
            <p>
                <asp:Label ID="lblFecha" runat="server" />
                &nbsp;·&nbsp;
                <asp:Label ID="lblEstado" runat="server" />
            </p>
        </div>
        <div class="d-flex gap-2">
            <button type="button" class="btn btn-outline-secondary"
                    onclick="window.print();">🖨 Imprimir</button>
            <a href="Ventas.aspx" class="btn btn-outline-secondary">← Volver al listado</a>
        </div>
    </div>

    <div class="page-card mb-3">
        <h2 class="menu-seccion" style="margin-top:0;">Datos del cliente</h2>
        <div class="row g-3">
            <div class="col-md-6">
                <label class="form-label">Cliente</label>
                <div><asp:Label ID="lblCliente" runat="server" Font-Bold="true" /></div>
            </div>
            <div class="col-md-6">
                <label class="form-label">Vendedor</label>
                <div><asp:Label ID="lblVendedor" runat="server" /></div>
            </div>
            <div class="col-md-6">
                <label class="form-label">Método de pago</label>
                <div><asp:Label ID="lblMetodoPago" runat="server" /></div>
            </div>
            <div class="col-md-6">
                <label class="form-label">Total</label>
                <div><asp:Label ID="lblTotalCabecera" runat="server" Font-Bold="true" Font-Size="Large" /></div>
            </div>
        </div>
    </div>

    <div class="page-card">
        <h2 class="menu-seccion" style="margin-top:0;">Productos vendidos</h2>

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
                                <td class="text-end">$ <%# Eval("PrecioUnitario", "{0:N2}") %></td>
                                <td class="text-end">$ <%# Eval("Subtotal", "{0:N2}") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="4" class="text-end fw-bold">Total:</td>
                        <td class="text-end fw-bold">
                            $ <asp:Label ID="lblTotalPie" runat="server" />
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