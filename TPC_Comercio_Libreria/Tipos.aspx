<%@ Page Title="Tipos - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="Tipos.aspx.cs" Inherits="TPC_Comercio_Libreria.Tipos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Tipos</h1>
            <p>Formatos y presentaciones: A4, Pack x6, Tapa dura…</p>
        </div>
        <a href="TipoForm.aspx" class="btn btn-primary">+ Nuevo tipo</a>
    </div>

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
                    <tr>
                        <td>A4</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>A5</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Oficio</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Unitario</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Pack x6</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Pack x12</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Tapa dura</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Tapa blanda</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Espiral</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Anillado</td>
                        <td class="text-center"><span class="badge bg-secondary">Inactivo</span></td>
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