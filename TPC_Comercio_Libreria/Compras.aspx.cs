using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_Comercio_Libreria
{
    public partial class Compras : System.Web.UI.Page
    {
        private bool EsAdmin
        {
            get
            {
                return Session["Rol"] != null && Session["Rol"].ToString() == "ADMIN";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["cancelar"]))
            {
                if (EsAdmin)
                {
                    try
                    {
                        int id = int.Parse(Request.QueryString["cancelar"]);
                        CompraNegocio negocio = new CompraNegocio();
                        negocio.CancelarCompra(id);
                        Session["MensajeExito"] = "Exito al cancelar la compra";
                    }
                    catch (Exception ex)
                    {

                        Session["MensajeExito"] = "Error al cancelar la compra";
                    }
                    Response.Redirect("Compras.aspx");
                    return;
                }
            }
            CargarCompras();

            if (Session["MensajeExito"] != null)
            {
                lblMensaje.Text = Session["MensajeExito"].ToString();
                lblMensaje.Visible = true;
                Session["MensajeExito"] = null;
            }
        }

        public void CargarCompras()
        {
            CompraNegocio negocio = new CompraNegocio();
            List<Compra> lista = negocio.Listar();

            repCompras.DataSource = lista;
            repCompras.DataBind();

            msgVacio.Visible = lista.Count == 0;

        }
    }
}