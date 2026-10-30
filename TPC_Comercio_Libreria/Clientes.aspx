<%@ Page Title="Clientes - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_Comercio_Libreria.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Clientes</h1>
            <p>Listado de escuelas, librerías y particulares</p>
        </div>
        <a href="ClienteForm.aspx" class="btn btn-primary">+ Nuevo cliente</a>
    </div>

    <div class="page-card">

        <div class="page-toolbar">
            <input type="text" class="form-control search-input"
                placeholder="Buscar por nombre, CUIT o email..." />
        </div>

        <div class="table-responsive">
            <table class="table table-hover align-middle mb-0">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>CUIT</th>
                        <th>Teléfono</th>
                        <th>Email</th>
                        <th>Dirección</th>
                        <th class="text-center">Estado</th>
                        <th class="text-center">Acciones</th>
                    </tr>
                </thead>

                <tbody>
                    <asp:Repeater ID="RepClientes" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval ("Nombre")%></td>
                                <td><%# Eval ("Cuit")%></td>
                                <td><%# Eval ("Telefono")%></td>
                                <td><%# Eval ("Email")%></td>
                                <td><%# Eval ("Direccion")%></td>
                                <td class="text-center"><span class="badge bg-success">Activo</span></td>
                                <td class="text-center">
                                    <a href="EditarCliente.aspx" class="btn btn-sm btn-outline-secondary">Editar</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>


                </tbody>
            </table>
        </div>

    </div>

</asp:Content>
