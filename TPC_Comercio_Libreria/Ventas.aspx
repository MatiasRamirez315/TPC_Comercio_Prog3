<%@ Page Title="Ventas - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TPC_Comercio_Libreria.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Ventas</h1>
            <p>Historial de ventas registradas</p>
        </div>
        <a href="VentaForm.aspx" class="btn btn-primary">+ Nueva venta</a>
    </div>

    <asp:Label ID="lblMensaje" runat="server"
               CssClass="alert alert-success d-block mb-3"
               Visible="false" />

    <div class="page-card">

        <div class="page-toolbar">
            <input type="text" class="form-control search-input"
                   placeholder="Buscar por cliente o vendedor..." />
        </div>

        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead>
                    <tr>
                        <th>N° Venta</th>
                        <th>Fecha</th>
                        <th>Cliente</th>
                        <th>Vendedor</th>
                        <th>Método Pago</th>
                        <th class="text-end">Total</th>
                        <th class="text-center">Estado</th>
                        <th class="text-center">Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repVentas" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>#<%# Eval("IDVenta") %></td>
                                <td><%# Eval("Fecha", "{0:dd/MM/yyyy HH:mm}") %></td>
                                <td><%# Eval("ClienteNombre") %></td>
                                <td><%# Eval("VendedorNombre") %></td>
                                <td><%# Eval("MetodoPago") %></td>
                                <td class="text-end">$ <%# Eval("Total", "{0:N2}") %></td>
                                <td class="text-center">
                                    <%# Eval("Estado").ToString() == "CONFIRMADA"
                                        ? "<span class='badge bg-success'>Confirmada</span>"
                                        : "<span class='badge bg-secondary'>Cancelada</span>" %>
                                </td>
                                <td class="text-center">
                                    <a href='<%# "VentaDetalle.aspx?id=" + Eval("IDVenta") %>'
                                       class="btn btn-sm btn-outline-secondary me-1">Ver detalle</a>

                                    <asp:PlaceHolder runat="server"
                                        Visible='<%# Session["Rol"] != null 
                                                    && Session["Rol"].ToString() == "ADMIN"
                                                    && Eval("Estado").ToString() == "CONFIRMADA" %>'>
                                        <a href='<%# "Ventas.aspx?cancelar=" + Eval("IDVenta") %>'
                                           class="btn btn-sm btn-outline-danger"
                                           onclick="return confirm('¿Cancelar esta venta? Se restaurará el stock de los productos.');">Cancelar</a>
                                    </asp:PlaceHolder>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <div class="text-center text-muted mt-3" id="msgVacio" runat="server" visible="false">
            No hay ventas registradas todavía.
        </div>

    </div>

</asp:Content>