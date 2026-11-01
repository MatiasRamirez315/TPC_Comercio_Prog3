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
    }
}