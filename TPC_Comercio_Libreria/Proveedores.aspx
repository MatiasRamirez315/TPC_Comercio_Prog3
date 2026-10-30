<%@ Page Title="Proveedores - Libreria Escolar" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_Comercio_Libreria.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Proveedores</h1>
            <p>Listado de los proveedores de la librería</p>
        </div>
        <a href="ProveedoresForm.aspx" class="btn btn-primary">+ Nuevo Proveedor</a>
    </div>

    <div class="page-card">

        <div class="page-toolbar">
            <input type="text" class="form-control search-input-input"
                placeholder="Buscar por Nombre, CUIT, Email..." />
        </div>
    </div>

    <div class="table-responsive">
        <table class="table table-hover align-middle mb-0">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Descripcion</th>
                    <th>CUIT</th>
                    <th>Teléfono</th>
                    <th>Email</th>
                    <th class="text-center">Estado</th>
                    <th class="text-center">Acciones</th>
                </tr>
            </thead>

            <tbody>
                <asp:Repeater ID="RepProveedores" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval ("Nombre")%></td>
                            <td><%# Eval ("Descripcion")%></td>
                            <td><%# Eval ("Cuit")%></td>
                            <td><%# Eval ("Telefono")%></td>
                            <td><%# Eval ("Email")%></td>
                            <td class="text-center"><span class="badge bg-success">Activo</span></td>
                            <td class="text-center">
                                <a href="EditarProveedor.aspx" class="btn btn-sm btn-outline-secondary">Editar</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>


            </tbody>
        </table>
    </div>


</asp:Content>
