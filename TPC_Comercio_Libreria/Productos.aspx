<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Comercio_Libreria.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Productos</h1>
            <p>Listado de los productos de la librería</p>
        </div>
        <a href="ProductosForm.aspx" class="btn btn-primary">+ Nuevo Producto</a>
    </div>

    <div class="page-card">

        <div class="page-toolbar" >
            <input type="text" class="form-control search-input-input"
                placeholder="Buscar por Nombre, Codigo, Marca..." />
        </div>
    </div>

    <div class="table-responsive" >
        <table class="table table-hover align-middle mb-0">
            <thead>
                <tr>
                    <th>Codigo</th>
                    <th>Nombre</th>
                    <th>Marca</th>
                    <th>Categoria</th>
                    <th>Tipo</th>
                    <th>Precio</th>
                    <th>Stock</th>
                    <th class="text-center">Estado</th>
                    <th class="text-center">Acciones</th>
                </tr>
            </thead>

            <tbody>
                <asp:Repeater ID="RepProductos" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval ("Codigo")%></td>
                            <td><%# Eval ("Nombre")%></td>
                            <td><%# Eval ("Marca")%></td>
                            <td><%# Eval ("Categoria")%></td>
                            <td><%# Eval ("Tipo")%></td>
                            <td><%# Eval ("PrecioCompraUltimo")%></td>
                            <td><%# Eval ("StockActual")%></td>
                            <td class="text-center"><span class="badge bg-success">Activo</span></td>
                            <td class="text-center">
                                <a href="EditarProducto.aspx" class="btn btn-sm btn-outline-secondary">Editar</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>


            </tbody>
        </table>
    </div>

</asp:Content>
