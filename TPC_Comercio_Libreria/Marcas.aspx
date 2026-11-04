<%@ Page Title="Marcas - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPC_Comercio_Libreria.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Marcas</h1>
            <p>Fabricantes de los productos: Rivadavia, Faber-Castell, Bic…</p>
        </div>
        <a href="MarcaForm.aspx" class="btn btn-primary">+ Nueva marca</a>
    </div>

    <asp:Label ID="lblMensaje" runat="server"
               CssClass="alert alert-success d-block mb-3"
               Visible="false" />

    <div class="page-card">

        <div class="page-toolbar">
            <input type="text" class="form-control search-input"
                   placeholder="Buscar marca..." />
        </div>

        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead>
                    <tr>
                        <th>Descripción</th>
                        <th class="text-center">Estado</th>
                        <th class="text-center">Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repMarcas" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Descripcion") %></td>
                                <td class="text-center">
                                    <%# Convert.ToBoolean(Eval("Activo"))
                                        ? "<span class='badge bg-success'>Activa</span>"
                                        : "<span class='badge bg-secondary'>Inactiva</span>" %>
                                </td>
                                <td class="text-center">
                                    <a href='<%# "MarcaForm.aspx?id=" + Eval("IDMarca") %>'
                                       class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                                    <a href='<%# "Marcas.aspx?eliminar=" + Eval("IDMarca") %>'
                                       class="btn btn-sm btn-outline-danger"
                                       onclick="return confirm('¿Dar de baja esta marca?');">Eliminar</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <div class="text-center text-muted mt-3" id="msgVacio" runat="server" visible="false">
            No hay marcas cargadas todavía.
        </div>

    </div>

</asp:Content>