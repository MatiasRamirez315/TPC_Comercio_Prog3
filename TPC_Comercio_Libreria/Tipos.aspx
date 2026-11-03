<%@ Page Title="Tipos - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="Tipos.aspx.cs" Inherits="TPC_Comercio_Libreria.Tipos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Tipos</h1>
            <p>Formatos y presentaciones: A4, Pack x6, Tapa dura…</p>
        </div>
        <a href="TipoForm.aspx" class="btn btn-primary">+ Nuevo tipo</a>
    </div>

    <asp:Label ID="lblMensaje" runat="server"
               CssClass="alert alert-success d-block mb-3"
               Visible="false" />

    <div class="page-card">

        <div class="page-toolbar">
            <input type="text" class="form-control search-input"
                   placeholder="Buscar tipo..." />
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
                    <asp:Repeater ID="repTipos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Descripcion") %></td>
                                <td class="text-center">
                                    <%# Convert.ToBoolean(Eval("Activo"))
                                        ? "<span class='badge bg-success'>Activo</span>"
                                        : "<span class='badge bg-secondary'>Inactivo</span>" %>
                                </td>
                                <td class="text-center">
                                    <a href='<%# "TipoForm.aspx?id=" + Eval("IDTipo") %>'
                                       class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                                    <a href='<%# "Tipos.aspx?eliminar=" + Eval("IDTipo") %>'
                                       class="btn btn-sm btn-outline-danger"
                                       onclick="return confirm('¿Dar de baja este tipo?');">Eliminar</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <div class="text-center text-muted mt-3" id="msgVacio" runat="server" visible="false">
            No hay tipos cargados todavía.
        </div>

    </div>

</asp:Content>