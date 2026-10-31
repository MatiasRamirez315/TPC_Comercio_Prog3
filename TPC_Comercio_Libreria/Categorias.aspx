<%@ Page Title="Categorías - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPC_Comercio_Libreria.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Categorías</h1>
            <p>Rubros del catálogo: Cuadernos, Escritura, Mochilas…</p>
        </div>
        <a href="CategoriaForm.aspx" class="btn btn-primary">+ Nueva categoría</a>
    </div>

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
                    <tr>
                        <td>Cuadernos</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Escritura</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Mochilas y bolsos</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Papelería</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Artística</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Geometría</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Libros</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Agendas</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Adhesivos y cintas</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Carpetas y archivadores</td>
                        <td class="text-center"><span class="badge bg-secondary">Inactiva</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>

</asp:Content>