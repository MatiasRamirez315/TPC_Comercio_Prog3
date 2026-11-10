using System;
using System.Collections.Generic;
using Dominio;

namespace AccesoDatos
{
    public class ProveedorDatos
    {
        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarProveedores");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.IDProveedor = (int)datos.Lector["id_proveedor"];
                    aux.Nombre = datos.Lector["nombre"].ToString();
                    aux.Descripcion = datos.Lector["descripcion"] == DBNull.Value ? "" : datos.Lector["descripcion"].ToString();
                    aux.Cuit = datos.Lector["cuit"] == DBNull.Value ? "" : datos.Lector["cuit"].ToString();
                    aux.Telefono = datos.Lector["telefono"] == DBNull.Value ? "" : datos.Lector["telefono"].ToString();
                    aux.Email = datos.Lector["email"] == DBNull.Value ? "" : datos.Lector["email"].ToString();
                    aux.Activo = (bool)datos.Lector["activo"];
                    lista.Add(aux);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public Proveedor listarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ObtenerProveedor");
                datos.setearParametro("@id_proveedor", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.IDProveedor = (int)datos.Lector["id_proveedor"];
                    aux.Nombre = datos.Lector["nombre"].ToString();
                    aux.Descripcion = datos.Lector["descripcion"] == DBNull.Value ? "" : datos.Lector["descripcion"].ToString();
                    aux.Cuit = datos.Lector["cuit"] == DBNull.Value ? "" : datos.Lector["cuit"].ToString();
                    aux.Telefono = datos.Lector["telefono"] == DBNull.Value ? "" : datos.Lector["telefono"].ToString();
                    aux.Email = datos.Lector["email"] == DBNull.Value ? "" : datos.Lector["email"].ToString();
                    aux.Activo = (bool)datos.Lector["activo"];
                    return aux;
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Proveedor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AltaProveedor");
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", ValorONull(nuevo.Descripcion));
                datos.setearParametro("@cuit", ValorONull(nuevo.Cuit));
                datos.setearParametro("@telefono", ValorONull(nuevo.Telefono));
                datos.setearParametro("@email", ValorONull(nuevo.Email));
                datos.setearParametro("@activo", true);   // el SP lo ignora, pero lo exige como parámetro
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ModificarProveedor");
                datos.setearParametro("@id_proveedor", proveedor.IDProveedor);
                datos.setearParametro("@nombre", proveedor.Nombre);
                datos.setearParametro("@descripcion", ValorONull(proveedor.Descripcion));
                datos.setearParametro("@cuit", ValorONull(proveedor.Cuit));
                datos.setearParametro("@telefono", ValorONull(proveedor.Telefono));
                datos.setearParametro("@email", ValorONull(proveedor.Email));
                datos.setearParametro("@activo", proveedor.Activo);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_EliminarProveedor");
                datos.setearParametro("@id_proveedor", id);
                datos.EjecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private object ValorONull(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return DBNull.Value;
            return valor.Trim();
        }
    }
}