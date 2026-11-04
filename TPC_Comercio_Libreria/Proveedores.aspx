<%@ Page Title="Proveedores - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_Comercio_Libreria.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Proveedores</h1>
            <p>Distribuidoras y mayoristas que abastecen la librería</p>
        </div>
        <a href="ProveedorForm.aspx" class="btn btn-primary">+ Nuevo proveedor</a>
    </div>

    <asp:Label ID="lblMensaje" runat="server"
               CssClass="alert alert-success d-block mb-3"
               Visible="false" />

    <div class="page-card">

        <div class="page-toolbar">
            <input type="text" class="form-control search-input"
                   placeholder="Buscar proveedor..." />
        </div>

        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Descripción</th>
                        <th>CUIT</th>
                        <th>Teléfono</th>
                        <th>Email</th>
                        <th class="text-center">Estado</th>
                        <th class="text-center">Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repProveedores" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Nombre") %></td>
                                <td><%# Eval("Descripcion") %></td>
                                <td><%# Eval("Cuit") %></td>
                                <td><%# Eval("Telefono") %></td>
                                <td><%# Eval("Email") %></td>
                                <td class="text-center">
                                    <%# Convert.ToBoolean(Eval("Activo"))
                                        ? "<span class='badge bg-success'>Activo</span>"
                                        : "<span class='badge bg-secondary'>Inactivo</span>" %>
                                </td>
                                <td class="text-center">
                                    <a href='<%# "ProveedorForm.aspx?id=" + Eval("IDProveedor") %>'
                                       class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                                    <a href='<%# "Proveedores.aspx?eliminar=" + Eval("IDProveedor") %>'
                                       class="btn btn-sm btn-outline-danger"
                                       onclick="return confirm('¿Dar de baja este proveedor?');">Eliminar</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <div class="text-center text-muted mt-3" id="msgVacio" runat="server" visible="false">
            No hay proveedores cargados todavía.
        </div>

    </div>

</asp:Content>