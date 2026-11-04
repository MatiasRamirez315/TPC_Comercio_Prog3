using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    ddlMarca.DataSource = marcaNegocio.listar();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "IDMarca";
                    ddlMarca.DataBind();

                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    ddlCategoria.DataSource = categoriaNegocio.listar();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "IDCategoria";
                    ddlCategoria.DataBind();

                    TipoNegocio tipoNegocio = new TipoNegocio();
                    ddlTipo.DataSource = tipoNegocio.listar();
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataValueField = "IDTipo";
                    ddlTipo.DataBind();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }

        protected void txtURLImagen_TextChanged(object sender,EventArgs e)
        {
            imgVistaPrevia.ImageUrl = txtURLImagen.Text;

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto nuevoProducto = new Producto();
                if(!string.IsNullOrEmpty(txtNombre.Text))
                {
                    nuevoProducto.Nombre = txtNombre.Text;
                }
                else
                {
                    lblError.Text = "El nombre del producto es obligatorio.";
                    return;
                }

                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    nuevoProducto.Codigo = txtCodigo.Text;
                }
                else
                {
                    lblError.Text = "El codigo del producto es obligatorio.";
                    return;
                }

                nuevoProducto.Marca = new Marca();
                nuevoProducto.Marca.IDMarca = int.Parse(ddlMarca.SelectedValue);
                
                nuevoProducto.Categoria = new Categoria();
                nuevoProducto.Categoria.IDCategoria = int.Parse(ddlCategoria.SelectedValue);
                

                nuevoProducto.Tipo = new Tipo();
                nuevoProducto.Tipo.IDTipo = int.Parse(ddlTipo.SelectedValue);

                if (!string.IsNullOrEmpty(txtPorcentajeGanancia.Text) && decimal.Parse(txtPorcentajeGanancia.Text) > 0)
                {
                    nuevoProducto.PorcentajeGanancia = decimal.Parse(txtPorcentajeGanancia.Text);
                }
                else
                {
                    lblError.Text = "El porcentaje de ganancia debe ser mayor a 0.";
                    return;
                }
                if (!string.IsNullOrEmpty(txtPrecioCompraUltimo.Text) && decimal.Parse(txtPrecioCompraUltimo.Text) > 0)
                {
                    nuevoProducto.PrecioCompraUltimo = decimal.Parse(txtPrecioCompraUltimo.Text);
                }
                else
                {
                    lblError.Text = "El precio de compra del producto debe ser mayor a 0.";
                    return;
                }
                if (!string.IsNullOrEmpty(txtStockActual.Text) && int.Parse(txtStockActual.Text) >= 0)
                {
                    nuevoProducto.StockActual = int.Parse(txtStockActual.Text);
                }
                else
                {
                    lblError.Text = "El stock actual debe ser mayor o igual a 0.";
                    return;
                }
                if (!string.IsNullOrEmpty(txtStockMin.Text) && decimal.Parse(txtStockMin.Text) >= 0)
                {
                    nuevoProducto.StockMinimo = int.Parse(txtStockMin.Text);
                }
                else
                {
                    lblError.Text = "El stock mínimo debe ser mayor o igual a 0";
                    return;
                }

                ProductoNegocio negocio = new ProductoNegocio();

                int idNuevoProducto = negocio.Agregar(nuevoProducto);

                if (idNuevoProducto > 0 && !string.IsNullOrEmpty(txtURLImagen.Text))
                {
                    Imagen nuevaImg = new Imagen();

                    nuevaImg.IDProducto = idNuevoProducto;
                    nuevaImg.URLImagen = txtURLImagen.Text;

                    ImagenNegocio negocioImagen = new ImagenNegocio();
                    negocioImagen.Agregar(nuevaImg);
                }

                Response.Redirect("Productos.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
    }
}