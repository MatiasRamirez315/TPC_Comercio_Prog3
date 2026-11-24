<%@ Page Title="Control manual de stock - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="ControlStock.aspx.cs" Inherits="TPC_Comercio_Libreria.ControlStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Control manual de stock</h1>
            <p>Ajustá el stock de los productos después de un control físico</p>
        </div>
        <a href="Inicio.aspx" class="btn btn-outline-secondary">← Volver al inicio</a>
    </div>

    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-success d-block mb-3" Visible="false" />
    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block mb-3" Visible="false" />

    <div class="alert alert-warning">
        <b>Atención:</b> esta pantalla modifica directamente el stock. Usala solo después de un conteo físico.
    </div>

    <!-- ============================================================
         PANEL 1: Edición
         ============================================================ -->
    <asp:Panel ID="pnlEdicion" runat="server">

        <div class="page-card">
            <div class="table-responsive">
                <table class="table table-hover align-middle mb-0">
                    <thead>
                        <tr>
                            <th>Código</th>
                            <th>Producto</th>
                            <th style="width:130px;">Stock Actual</th>
                            <th style="width:130px;">Stock Mínimo</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repProductos" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Codigo") %></td>
                                    <td><%# Eval("Nombre") %></td>
                                    <td>
                                        <asp:HiddenField ID="hdnIDProducto" runat="server" Value='<%# Eval("IDProducto") %>' />
                                        <asp:HiddenField ID="hdnNombre" runat="server" Value='<%# Eval("Nombre") %>' />
                                        <asp:HiddenField ID="hdnStockActualOriginal" runat="server" Value='<%# Eval("StockActual") %>' />
                                        <asp:TextBox ID="txtStockActual" runat="server" TextMode="Number"
                                                     CssClass="form-control form-control-sm"
                                                     Text='<%# Eval("StockActual") %>' />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hdnStockMinOriginal" runat="server" Value='<%# Eval("StockMinimo") %>' />
                                        <asp:TextBox ID="txtStockMinimo" runat="server" TextMode="Number"
                                                     CssClass="form-control form-control-sm"
                                                     Text='<%# Eval("StockMinimo") %>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

            <div class="mt-4">
                <asp:Button ID="btnAplicar" runat="server" Text="Aplicar cambios"
                            CssClass="btn btn-primary" OnClick="btnAplicar_Click" />
            </div>
        </div>

    </asp:Panel>

    <!-- ============================================================
         PANEL 2: Confirmación
         ============================================================ -->
    <asp:Panel ID="pnlConfirmacion" runat="server" Visible="false">

        <div class="page-card">
            <div class="alert alert-warning">
                <b>Confirmación requerida</b><br/>
                Estás por modificar el stock de los siguientes productos. Esta acción no se puede deshacer automáticamente.
                Revisá los valores antes de confirmar.
            </div>

            <div class="table-responsive">
                <table class="table table-hover align-middle mb-0">
                    <thead>
                        <tr>
                            <th>Producto</th>
                            <th class="text-center">Stock Actual</th>
                            <th class="text-center">Stock Mínimo</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repConfirmacion" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("NombreProducto") %></td>
                                    <td class="text-center">
                                        <%# (int)Eval("StockActualAnterior") != (int)Eval("StockActualNuevo")
                                            ? "<span class='text-muted'>" + Eval("StockActualAnterior") + "</span> → <b>" + Eval("StockActualNuevo") + "</b>"
                                            : Eval("StockActualNuevo").ToString() %>
                                    </td>
                                    <td class="text-center">
                                        <%# (int)Eval("StockMinimoAnterior") != (int)Eval("StockMinimoNuevo")
                                            ? "<span class='text-muted'>" + Eval("StockMinimoAnterior") + "</span> → <b>" + Eval("StockMinimoNuevo") + "</b>"
                                            : Eval("StockMinimoNuevo").ToString() %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

            <div class="mt-4 d-flex gap-2">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar cambios"
                            CssClass="btn btn-warning" OnClick="btnConfirmar_Click" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver sin guardar"
                            CssClass="btn btn-outline-secondary" OnClick="btnVolver_Click" CausesValidation="false" />
            </div>
        </div>

    </asp:Panel>

</asp:Content>