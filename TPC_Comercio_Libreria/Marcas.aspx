<%@ Page Title="Marcas - Librería Escolar" Language="C#" MasterPageFile="~/MiMaster.master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPC_Comercio_Libreria.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <div>
            <h1>Marcas</h1>
            <p>Fabricantes de los productos: Rivadavia, Faber-Castell, Bic…</p>
        </div>
        <a href="MarcaForm.aspx" class="btn btn-primary">+ Nueva marca</a>
    </div>

    <div class="page-card">

        <div class="page-toolbar">
            <input type="text" class="form-control search-input"
                   placeholder="Buscar marca..." />
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
                        <td>Rivadavia</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Faber-Castell</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Bic</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Maped</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Pelikan</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Alba</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Simball</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Filgo</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Mooving</td>
                        <td class="text-center"><span class="badge bg-success">Activa</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary me-1">Editar</a>
                            <a href="#" class="btn btn-sm btn-outline-danger">Eliminar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Stabilo</td>
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