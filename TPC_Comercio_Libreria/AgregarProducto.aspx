<%@ Page Title="Agregar Producto - Libreria Escolar" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPC_Comercio_Libreria.AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Agregar producto</h1>
    <br />
    <div class="row">
        <asp:HiddenField ID="hdnID" runat="server" />  <%-- hidden field lo uso para poder cambiar el boton de guardar a modificar  --%>

        <div class="col-md-6">
            <div class="mb-3">
                <label class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Código:</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Marca:</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"
                    DataTextField="Descripcion" DataValueField="IDMarca">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label class="form-label">Categoria:</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"
                    DataTextField="Descripcion" DataValueField="IDCategoria">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label class="form-label">Tipo:</label>
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select"
                    DataTextField="Descripcion" DataValueField="IDTipo">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label class="form-label">Porcentaje Ganancia:</label>
                <asp:TextBox ID="txtPorcentajeGanancia" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Precio Compra Último:</label>
                <asp:TextBox ID="txtPrecioCompraUltimo" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
        </div>


        <div class="col-md-6">


            <div class="mb-3">
                <label class="form-label">Stock Actual:</label>
                <asp:TextBox ID="txtStockActual" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Stock Mínimo:</label>
                <asp:TextBox ID="txtStockMin" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Url de imagen:</label>
                <asp:TextBox ID="txtURLImagen" runat="server" CssClass="form-control" AutoPostBack="true"
                    OnTextChanged="txtURLImagen_TextChanged"></asp:TextBox>
            </div>

            <div class="mb-3 text-center">
                <asp:Image ID="imgVistaPrevia" runat="server" />

            </div>

            <div class="mb-3 mt-4">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" />
                <a href="Inicio.aspx" class="btn btn-secondary">Cancelar</a>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger ms-3"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
