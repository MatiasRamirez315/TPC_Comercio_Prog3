<%@ Page Title="Nueva venta - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="VentaForm.aspx.cs" Inherits="TPC_Comercio_Libreria.VentaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Nueva venta</h1>
            <p>Agregá productos al carrito y confirmá la venta</p>
        </div>
        <a href="Ventas.aspx" class="btn btn-outline-secondary">← Volver al listado</a>
    </div>

    <asp:Label ID="lblError" runat="server"
               CssClass="alert alert-danger d-block mb-3"
               Visible="false" />

    <div class="page-card mb-3">
        <h2 class="menu-seccion" style="margin-top:0;">Datos de la venta</h2>
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
        </div>
    </div>

    <div class="page-card mb-3">
        <h2 class="menu-seccion" style="margin-top:0;">Agregar producto</h2>
        <div class="row g-3">
            <div class="col-md-7">
                <label class="form-label">Producto</label>
                <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-select"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" />
            </div>
            <div class="col-md-2">
                <label class="form-label">Cantidad</label>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"
                    TextMode="Number" Text="1" AutoPostBack="true"
                    OnTextChanged="txtCantidad_TextChanged" />
            </div>
            <div class="col-md-3 d-flex align-items-end">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar al carrito"
                            CssClass="btn btn-success w-100" OnClick="btnAgregar_Click" />
            </div>
            <div class="col-12">
                <div class="alert alert-info mb-0">
                    <asp:Label ID="lblInfoProducto" runat="server"
                               Text="Seleccioná un producto para ver el precio y el stock." />
                </div>
            </div>
        </div>
    </div>

    <div class="page-card">
        <h2 class="menu-seccion" style="margin-top:0;">Carrito</h2>

        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead>
                    <tr>
                        <th>Producto</th>
                        <th class="text-center">Cantidad</th>
                        <th class="text-end">Precio Unitario</th>
                        <th class="text-end">Subtotal</th>
                        <th class="text-center">Quitar</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repCarrito" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("NombreProducto") %></td>
                                <td class="text-center"><%# Eval("Cantidad") %></td>
                                <td class="text-end">$ <%# Eval("PrecioUnitario", "{0:N2}") %></td>
                                <td class="text-end">$ <%# Eval("Subtotal", "{0:N2}") %></td>
                                <td class="text-center">
                                    <asp:Button runat="server" Text="Quitar"
                                        CssClass="btn btn-sm btn-outline-danger"
                                        CommandArgument='<%# Eval("IDProducto") %>'
                                        OnClick="btnQuitar_Click"
                                        OnClientClick="return confirm('¿Quitar este producto del carrito?');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="3" class="text-end fw-bold">Total:</td>
                        <td class="text-end fw-bold">
                            <asp:Label ID="lblTotal" runat="server" Text="$ 0,00" />
                        </td>
                        <td></td>
                    </tr>
                </tfoot>
            </table>
        </div>

        <div class="text-center text-muted mt-3" id="lblCarritoVacio" runat="server">
            El carrito está vacío. Agregá productos arriba.
        </div>

        <div class="mt-4 d-flex gap-2">
            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar venta"
                        CssClass="btn btn-primary" OnClick="btnConfirmar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"
                        CssClass="btn btn-outline-secondary" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>
    </div>

</asp:Content>