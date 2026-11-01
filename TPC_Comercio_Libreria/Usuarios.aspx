<%@ Page Title="Usuarios - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPC_Comercio_Libreria.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Usuarios</h1>
            <p>Personal del sistema: administradores y vendedores</p>
        </div>
        <a href="UsuarioForm.aspx" class="btn btn-primary">+ Nuevo usuario</a>
    </div>

    <div class="page-card">

        <div class="page-toolbar">
            <input type="text" class="form-control search-input"
                   placeholder="Buscar por usuario o rol..." />
        </div>

        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead>
                    <tr>
                        <th>Usuario</th>
                        <th>Rol</th>
                        <th class="text-center">Estado</th>
                        <th class="text-center">Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repUsuarios" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("NombreUsuario") %></td>
                                <td>
                                    <%# Eval("Rol").ToString() == "ADMIN"
                                        ? "<span class='badge bg-primary'>Administrador</span>"
                                        : "<span class='badge bg-info text-dark'>Vendedor</span>" %>
                                </td>
                                <td class="text-center">
                                    <%# Convert.ToBoolean(Eval("Activo"))
                                        ? "<span class='badge bg-success'>Activo</span>"
                                        : "<span class='badge bg-secondary'>Inactivo</span>" %>
                                </td>
                                <td class="text-center">
                                    <a href="EditarUsuario.aspx" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                                    <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <div class="text-center text-muted mt-3" id="msgVacio" runat="server" visible="false">
            No hay usuarios cargados todavía.
        </div>

    </div>

</asp:Content>