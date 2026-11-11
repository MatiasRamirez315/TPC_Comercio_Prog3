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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                ProductoNegocio negocio = new ProductoNegocio();
                RepProductos.DataSource = negocio.Listar();
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