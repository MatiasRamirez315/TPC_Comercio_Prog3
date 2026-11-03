using System;
using System.Collections.Generic;
using Dominio;

namespace AccesoDatos
{
    public class TipoDatos
    {
        public List<Tipo> listar()
        {
            List<Tipo> lista = new List<Tipo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarTipos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Tipo aux = new Tipo();
                    aux.IDTipo = (int)datos.Lector["id_tipo"];
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

        public Tipo listarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ObtenerTipo");
                datos.setearParametro("@id_tipo", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Tipo aux = new Tipo();
                    aux.IDTipo = (int)datos.Lector["id_tipo"];
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

        public void agregar(Tipo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AltaTipo");
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Tipo tipo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ModificarTipo");
                datos.setearParametro("@id_tipo", tipo.IDTipo);
                datos.setearParametro("@descripcion", tipo.Descripcion);
                datos.setearParametro("@activo", tipo.Activo);
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
                datos.setearProcedimiento("SP_EliminarTipo");
                datos.setearParametro("@id_tipo", id);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}