<%@ Page Title="Inicio - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPC_Comercio_Libreria.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="menu-header">
        <h1>Panel de administración</h1>
        <p>Seleccioná una opción para comenzar</p>
    </div>

    <h2 class="menu-seccion">Operaciones del día</h2>
    <div class="menu-grid">
        <a href="Ventas.aspx" class="menu-card">
            <span class="menu-icon">💰</span>
            <span class="menu-title">Ventas</span>
            <span class="menu-desc">Registrar una venta a cliente</span>
        </a>
        <a href="Compras.aspx" class="menu-card">
            <span class="menu-icon">🛒</span>
            <span class="menu-title">Compras</span>
            <span class="menu-desc">Registrar una compra a proveedor</span>
        </a>
    </div>

    <h2 class="menu-seccion">Catálogo</h2>
    <div class="menu-grid">
        <a href="Productos.aspx" class="menu-card">
            <span class="menu-icon">📦</span>
            <span class="menu-title">Productos</span>
            <span class="menu-desc">Stock, precios e imágenes</span>
        </a>
        <a href="Marcas.aspx" class="menu-card">
            <span class="menu-icon">🏷️</span>
            <span class="menu-title">Marcas</span>
            <span class="menu-desc">Rivadavia, Faber-Castell, Bic…</span>
        </a>
        <a href="Categorias.aspx" class="menu-card">
            <span class="menu-icon">📂</span>
            <span class="menu-title">Categorías</span>
            <span class="menu-desc">Cuadernos, Escritura, Mochilas…</span>
        </a>
        <a href="Tipos.aspx" class="menu-card">
            <span class="menu-icon">📏</span>
            <span class="menu-title">Tipos</span>
            <span class="menu-desc">A4, Pack x6, Tapa dura…</span>
        </a>
    </div>

    <h2 class="menu-seccion">Contactos</h2>
    <div class="menu-grid">
        <a href="Clientes.aspx" class="menu-card">
            <span class="menu-icon">👥</span>
            <span class="menu-title">Clientes</span>
            <span class="menu-desc">Escuelas, librerías, particulares</span>
        </a>
        <a href="Proveedores.aspx" class="menu-card">
            <span class="menu-icon">🚚</span>
            <span class="menu-title">Proveedores</span>
            <span class="menu-desc">Distribuidoras y mayoristas</span>
        </a>
    </div>

    <h2 class="menu-seccion">Administración</h2>
    <div class="menu-grid">
        <a href="Usuarios.aspx" class="menu-card" id="cardUsuarios">
            <span class="menu-icon">👤</span>
            <span class="menu-title">Usuarios</span>
            <span class="menu-desc">Alta y baja de usuarios del sistema</span>
        </a>
        <a href="Reportes.aspx" class="menu-card" id="cardReportes">
            <span class="menu-icon">📊</span>
            <span class="menu-title">Reportes</span>
            <span class="menu-desc">Ventas, ganancias y stock bajo</span>
        </a>
    </div>

</asp:Content>