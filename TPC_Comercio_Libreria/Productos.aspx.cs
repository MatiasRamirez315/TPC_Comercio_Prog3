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
    public partial class Productos : System.Web.UI.Page
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
            phNuevoProducto.Visible = EsAdmin;
            thAcciones.Visible = EsAdmin;

            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                List<Producto> lista = negocio.Listar();

                if (!EsAdmin)
                {
                    lista = lista.Where(p => p.Activo).ToList();
                }

                RepProductos.DataSource = lista;
                RepProductos.DataBind();

                if (Session["MensajeExito"] != null)
                {
                    lblMensaje.Text = Session["MensajeExito"].ToString();
                    lblMensaje.Visible = true;

                    Session["MensajeExito"] = null;
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!EsAdmin)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            Button btn = (Button)sender;
            ProductoNegocio negocio = new ProductoNegocio();

            int idProducto = int.Parse(btn.CommandArgument);
            Producto prod = new Producto();
            prod.IDProducto = idProducto;
            negocio.EliminarProducto(prod);

            Session["MensajeExito"] = "El producto se elimino correctamente";
            Response.Redirect("Productos.aspx");
        }
    }
}