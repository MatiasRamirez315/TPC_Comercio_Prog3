using System;
using System.Collections.Generic;
using Dominio;

namespace AccesoDatos
{
    public class MarcaDatos
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarMarcas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IDMarca = (int)datos.Lector["id_marca"];
                    aux.Descripcion = datos.Lector["descripcion"].ToString();
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

        public Marca listarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ObtenerMarca");
                datos.setearParametro("@id_marca", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IDMarca = (int)datos.Lector["id_marca"];
                    aux.Descripcion = datos.Lector["descripcion"].ToString();
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

        public void agregar(Marca nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AltaMarca");
                datos.setearParametro("@descripcion", nueva.Descripcion);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ModificarMarca");
                datos.setearParametro("@id_marca", marca.IDMarca);
                datos.setearParametro("@descripcion", marca.Descripcion);
                datos.setearParametro("@activo", marca.Activo);
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
                datos.setearProcedimiento("SP_EliminarMarca");
                datos.setearParametro("@id_marca", id);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}