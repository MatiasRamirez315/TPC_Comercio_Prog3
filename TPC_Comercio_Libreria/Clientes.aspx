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
                    <tr>
                        <td>Escuela Primaria N°12</td>
                        <td>30-71234567-1</td>
                        <td>011-4555-1001</td>
                        <td>contacto@ep12.edu.ar</td>
                        <td>Av. Rivadavia 1200, CABA</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary">Editar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Colegio San José</td>
                        <td>30-70987654-2</td>
                        <td>011-4555-1002</td>
                        <td>admin@colegiosanjose.edu.ar</td>
                        <td>Belgrano 456, CABA</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary">Editar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Librería El Sol</td>
                        <td>30-71456789-3</td>
                        <td>011-4555-1003</td>
                        <td>ventas@libreriaelsol.com</td>
                        <td>Corrientes 890, CABA</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary">Editar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Distribuidora Norte SRL</td>
                        <td>30-71654321-4</td>
                        <td>011-4555-1004</td>
                        <td>compras@distnorte.com.ar</td>
                        <td>Mitre 330, Vicente López</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary">Editar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Escuela Técnica N°5</td>
                        <td>30-71098765-5</td>
                        <td>011-4555-1005</td>
                        <td>secretaria@et5.edu.ar</td>
                        <td>San Martín 780, Lanús</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary">Editar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Jardín de Infantes Arcoíris</td>
                        <td>30-71345678-6</td>
                        <td>011-4555-1006</td>
                        <td>info@jardinarcoiris.com</td>
                        <td>Rivadavia 3400, CABA</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary">Editar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Papelería Central</td>
                        <td>30-71765432-7</td>
                        <td>011-4555-1007</td>
                        <td>papeleriacentral@gmail.com</td>
                        <td>Callao 1500, CABA</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary">Editar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Instituto Belgrano</td>
                        <td>30-71234500-8</td>
                        <td>011-4555-1008</td>
                        <td>compras@instbelgrano.edu.ar</td>
                        <td>Av. Cabildo 2100, CABA</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary">Editar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Librería La Plaza</td>
                        <td>30-71543210-9</td>
                        <td>011-4555-1009</td>
                        <td>libreriaplaza@hotmail.com</td>
                        <td>Plaza Italia 45, La Plata</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary">Editar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Colegio Nacional Buenos Aires</td>
                        <td>30-71876543-0</td>
                        <td>011-4555-1010</td>
                        <td>admin@cnba.edu.ar</td>
                        <td>Bolívar 263, CABA</td>
                        <td class="text-center"><span class="badge bg-success">Activo</span></td>
                        <td class="text-center">
                            <a href="#" class="btn btn-sm btn-outline-secondary">Editar</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>

</asp:Content>