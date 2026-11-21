<%@ Page Title="Ingreso de Stock" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="CompraForm.aspx.cs" Inherits="TPC_Comercio_Libreria.CompraForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Nuevo Ingreso</h1>
            <p>Registra la compra a un proveedor</p>
        </div>
        <a href="Compras.aspx" class="btn btn-outline-secondary">← Volver al listado</a>
    </div>

    <div class="page-card">
        <asp:Label ID="lblError" runat="server"
            CssClass="alert alert-danger d-block mb-3"
            Visible="false"></asp:Label>

        <div class="row align-items-start g-4">
            <div class="col-md-6">
                <div class="mb-3">
                    <label class="form-label">Categoria  <span class="text-danger">*</span></label>
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>


                <div class="mb-3">
                    <label class="form-label">Producto <span class="text-danger">*</span></label>
                    <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-select"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>


                <div class="mb-3">
                    <label class="form-label">Cantidad</label>
                    <asp:TextBox ID="txtCantidad" TextMode="number" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label class="form-label">Precio Compra Último:</label>
                    <asp:TextBox ID="txtPrecioCompraUltimo" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label class="form-label">Porcentaje Ganancia:</label>
                    <asp:TextBox ID="txtPorcentajeGanancia" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>

            </div>


            <div class="col-md-5 text-center">
                <div class="border rounded p-3 bg-light">
                    <asp:Image ID="imgProducto" runat="server"
                        CssClass="img-fluid rounded" AlternateText="Imagen del producto" />
                </div>
            </div>
        </div>

        <br />

        <div class="col-12">
            <div class="alert alert-info mb-0">
                <asp:Label ID="lblInfoProducto" runat="server" Text="Seleccioná un producto para ver el precio y el stock." />
            </div>
        </div>

        <br />

        <div class="col-12">
            <div class="alert alert-success mb-0">
                <asp:Label ID="lblTotal" runat="server" Text="" Font-Bold="true" Font-Size="Large" />
            </div>
        </div>

    </div>


</asp:Content>
