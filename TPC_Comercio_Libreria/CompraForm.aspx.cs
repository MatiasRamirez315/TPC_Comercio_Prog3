using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;


namespace TPC_Comercio_Libreria
{
    public partial class CompraForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    CargarCategorias();

                    CargarProductoXCategoria();

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        private void CargarCategorias()
        {
            CategoriaNegocio negocioCate = new CategoriaNegocio();
            ddlCategoria.DataSource = negocioCate.listar();
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "IDCategoria";
            ddlCategoria.DataBind();

        }

        private void CargarProductoXCategoria()
        {
            int idCategoria = int.Parse(ddlCategoria.SelectedValue);


            ProductoNegocio negocioProd = new ProductoNegocio();
            List<Producto> listaCompleta = negocioProd.Listar();
            List<Producto> listaFiltro = new List<Producto>();

            foreach (Producto prod in listaCompleta)
            {
                if (prod.Categoria.IDCategoria == idCategoria) 
                {
                    listaFiltro.Add(prod);
                }

            }

            ddlProducto.DataSource = listaFiltro;
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataValueField = "IDProducto";
            ddlProducto.DataBind();


        }
        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProductoXCategoria();
        }

        public void MostrarImagenProducto(int idProd)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> lista = negocio.Listar();
            Producto prod = null;

            foreach (var item in lista)
            {
                if(item.IDProducto == idProd)
                {
                    prod = item;
                    break;
                }
            }

            if (prod != null)
            {
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                prod.Imagenes = imagenNegocio.ListarPorProducto(prod.IDProducto);

                if(prod.Imagenes != null && prod.Imagenes.Count > 0 && !string.IsNullOrWhiteSpace(prod.Imagenes[0].URLImagen)){
                    imgProducto.ImageUrl = prod.Imagenes[0].URLImagen;
                    return;
                }
            }

            imgProducto.ImageUrl = "https://imgs.search.brave.com/LWzCp47VF1oqbGPjTQqr24T6dW99TfZnfzhc-e6Hknk/rs:fit:500:0:1:0/g:ce/aHR0cHM6Ly9zdDMu/ZGVwb3NpdHBob3Rv/cy5jb20vMjM1OTQ5/MjIvMzE4MjIvdi80/NTAvZGVwb3NpdHBo/b3Rvc18zMTgyMjEz/Njgtc3RvY2staWxs/dXN0cmF0aW9uLW1p/c3NpbmctcGljdHVy/ZS1wYWdlLWZvci13/ZWJzaXRlLmpwZw";

        }
        public void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ddlProducto.SelectedValue)){

                int idProd = int.Parse(ddlProducto.SelectedValue);
                MostrarImagenProducto(idProd);
            }
        
        }


    }
}