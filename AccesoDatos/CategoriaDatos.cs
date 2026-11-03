using System;
using System.Collections.Generic;
using Dominio;

namespace AccesoDatos
{
    public class CategoriaDatos
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarCategorias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IDCategoria = (int)datos.Lector["id_categoria"];
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

        public Categoria listarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ObtenerCategoria");
                datos.setearParametro("@id_categoria", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IDCategoria = (int)datos.Lector["id_categoria"];
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

        public void agregar(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AltaCategoria");
                datos.setearParametro("@descripcion", nueva.Descripcion);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ModificarCategoria");
                datos.setearParametro("@id_categoria", categoria.IDCategoria);
                datos.setearParametro("@descripcion", categoria.Descripcion);
                datos.setearParametro("@activo", categoria.Activo);
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
                datos.setearProcedimiento("SP_EliminarCategoria");
                datos.setearParametro("@id_categoria", id);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}