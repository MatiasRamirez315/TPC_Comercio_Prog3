<%@ Page Title="Compras - Libreria escolar" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TPC_Comercio_Libreria.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Compras</h1>
            <p>Historial de compras registradas</p>
        </div>
        <a href="CompraForm.aspx" class="btn btn-primary">+ Nueva compra</a>
    </div>

    <asp:Label ID="lblMensaje" runat="server"
        CssClass="alert alert-success d-block mb-3"
        Visible="false" />

    <div class="page-card">

        <div class="page-toolbar">
            <input type="text" class="form-control search-input" id="txtBuscar"
                placeholder="Buscar por proveedor o fecha..." />
        </div>

        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead>
                    <tr>
                        <th>N° Compra</th>
                        <th>N° de factura</th>
                        <th>Fecha</th>
                        <th>Proveedor</th>
                        <th class="text-end">Total</th>
                        <th class="text-center">Estado</th>
                        <th class="text-center">Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repCompras" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("IDCompra") %></td>
                                <td><%# Eval("NumeroFactura") %></td>
                                <td><%# Eval("Fecha", "{0:dd/MM/yyyy HH:mm}") %></td>
                                <td><%# Eval("NombreProveedor") %></td>
                                <td class="text-end">$ <%# Eval("Total", "{0:N2}") %></td>
                                <td class="text-center">
                                    <%# Eval("Estado").ToString() == "Recibido"
                                    ? "<span class='badge bg-success'>Recibido</span>"
                                    :Eval("Estado").ToString() == "Cancelado"
                                    ? "<span class='badge bg-danger'>Cancelado</span>"
                                    : "<span class='badge bg-secondary'>Pendiente</span>"%>
                                
                                </td>
                                <td class="text-center">
                                    <a href='<%# "CompraDetalle.aspx?id=" + Eval("IDCompra") %>'
                                        class="btn btn-sm btn-outline-secondary me-1">Ver detalle</a>

                                    <asp:PlaceHolder runat="server"
                                        Visible='<%# Session["Rol"] != null 
                                            && Session["Rol"].ToString() == "ADMIN"
                                            && Eval("Estado").ToString() == "Pendiente" %>'>
                                        <a href='<%# "Compras.aspx?cancelar=" + Eval("IDCompra") %>'
                                            class="btn btn-sm btn-outline-danger"
                                            onclick="return confirm('¿Cancelar esta compra?');">Cancelar</a>
                                        </asp:PlaceHolder >

                                        <asp:PlaceHolder runat="server"
                                            Visible='<%# Session["Rol"] != null 
                                                && Session["Rol"].ToString() == "ADMIN"
                                                && Eval("Estado").ToString() == "CONFIRMADA" %>'>
                                            <a href='<%# "Compras.aspx?cancelar=" + Eval("IDCompra") %>'
                                                class="btn btn-sm btn-outline-danger"
                                                onclick="return confirm('¿Cancelar esta compra? Se restaurará el stock de los productos.');">Cancelar</a>
                                        </asp:PlaceHolder>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <div class="text-center text-muted mt-3" id="msgVacio" runat="server" visible="false">
            No hay compras registradas todavía.
        </div>

    </div>
</asp:Content>
