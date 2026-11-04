using System;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class CategoriaForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;

                if (HayIdEnQueryString())
                {
                    lblTitulo.Text = "Editar categoría";
                    lblSubtitulo.Text = "Modificá los datos de la categoría";
                    cargarCategoria();
                }
                else
                {
                    lblTitulo.Text = "Nueva categoría";
                    lblSubtitulo.Text = "Completá los datos para dar de alta una categoría";
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                mostrarError("La descripción es obligatoria.");
                return;
            }

            try
            {
                CategoriaNegocio negocio = new CategoriaNegocio();

                if (HayIdEnQueryString())
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    Categoria categoria = negocio.listarPorId(id);

                    if (categoria == null)
                    {
                        Response.Redirect("Categorias.aspx");
                        return;
                    }

                    categoria.Descripcion = txtDescripcion.Text.Trim();

                    negocio.modificar(categoria);
                    Session["MensajeExito"] = "Categoría modificada correctamente.";
                }
                else
                {
                    Categoria nueva = new Categoria();
                    nueva.Descripcion = txtDescripcion.Text.Trim();
                    nueva.Activo = true;

                    negocio.agregar(nueva);
                    Session["MensajeExito"] = "Categoría agregada correctamente.";
                }

                Response.Redirect("Categorias.aspx");
            }
            catch (Exception ex)
            {
                mostrarError("Error al guardar: " + ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias.aspx");
        }

        private bool HayIdEnQueryString()
        {
            return !string.IsNullOrWhiteSpace(Request.QueryString["id"]);
        }

        private void cargarCategoria()
        {
            int id = int.Parse(Request.QueryString["id"]);
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria categoria = negocio.listarPorId(id);

            if (categoria == null)
            {
                Response.Redirect("Categorias.aspx");
                return;
            }

            txtDescripcion.Text = categoria.Descripcion;
        }

        private void mostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}