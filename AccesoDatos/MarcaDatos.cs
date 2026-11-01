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
    }
}