<%@ Page Title="Categorías - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPC_Comercio_Libreria.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Categorías</h1>
            <p>Rubros del catálogo: Cuadernos, Escritura, Mochilas…</p>
        </div>
        <a href="CategoriaForm.aspx" class="btn btn-primary">+ Nueva categoría</a>
    </div>

    <asp:Label ID="lblMensaje" runat="server"
               CssClass="alert alert-success d-block mb-3"
               Visible="false" />

    <div class="page-card">

        <div class="page-toolbar">
            <input type="text" class="form-control search-input"
                   placeholder="Buscar categoría..." />
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
                    <asp:Repeater ID="repCategorias" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Descripcion") %></td>
                                <td class="text-center">
                                    <%# Convert.ToBoolean(Eval("Activo"))
                                        ? "<span class='badge bg-success'>Activa</span>"
                                        : "<span class='badge bg-secondary'>Inactiva</span>" %>
                                </td>
                                <td class="text-center">
                                    <a href='<%# "CategoriaForm.aspx?id=" + Eval("IDCategoria") %>'
                                       class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                                    <a href='<%# "Categorias.aspx?eliminar=" + Eval("IDCategoria") %>'
                                       class="btn btn-sm btn-outline-danger"
                                       onclick="return confirm('¿Dar de baja esta categoría?');">Eliminar</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <div class="text-center text-muted mt-3" id="msgVacio" runat="server" visible="false">
            No hay categorías cargadas todavía.
        </div>

    </div>

</asp:Content>