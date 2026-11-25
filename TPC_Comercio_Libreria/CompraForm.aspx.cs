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

            if (!IsPostBack)
            {
                try
                {
                    

                    CargarCategorias();

                    CargarProductoXCategoria();

                    CargarProveedoresXProducto();

                    CargarDatosProducto();


                    

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        private void CargarDatosProducto()
        {
            int idProd = int.Parse(ddlProducto.SelectedValue);

            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> lista = negocio.Listar();

            foreach (Producto prod in lista)
            {
                if (prod.IDProducto == idProd)
                {
                    txtPrecioCompraUltimo.Text = prod.PrecioCompraUltimo.ToString();
                    txtPorcentajeGanancia.Text = prod.PorcentajeGanancia.ToString();
                    break;
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

        
        private void InfoNuestra()
        {
            lblInfoProducto.Text = "Seleccioná un producto para ver el precio y el stock.";

            if (string.IsNullOrWhiteSpace(ddlProducto.SelectedValue))
            {
                return;
            }

            int idProd = int.Parse(ddlProducto.SelectedValue);

            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> lista = negocio.Listar();

            foreach (Producto prod in lista)
            {
                if (prod.IDProducto == idProd)
                {
                    decimal NuestroPrecio = prod.PrecioCompraUltimo + (prod.PrecioCompraUltimo *  prod.PorcentajeGanancia / 100);
                    decimal prueba = prod.StockActual;
                    lblInfoProducto.Text = "Precio de venta: $" + NuestroPrecio.ToString("0.00") + " · Stock actual: " + prod.StockActual;
                    break;
                }
            }
        }

        

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProductoXCategoria();
            CargarProveedoresXProducto();
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
                CargarDatosProducto();
                CargarProveedoresXProducto(); 
                InfoNuestra();
            }
        
        }

        public void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            PrecioxCantidad();
        }

        public void PrecioxCantidad()
        {
            lblTotal.Text = "";

            if (string.IsNullOrWhiteSpace(ddlProducto.SelectedValue))
            {
                return;
            }
            if (txtCantidad.Text == "" || int.Parse(txtCantidad.Text) < 0)
            {
                return;
            }


            int idProd = int.Parse(ddlProducto.SelectedValue);

            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> lista = negocio.Listar();

            foreach (Producto prod in lista)
            {
                if (prod.IDProducto == idProd)
                {
                    decimal Total = prod.PrecioCompraUltimo * decimal.Parse(txtCantidad.Text);
                    int CantTot = prod.StockActual + int.Parse(txtCantidad.Text);
                    lblTotal.Text = "Total de compra: $" + Total.ToString("0.00") + " · Cantidad final: " + CantTot ;
                    break;
                }
            }
        }

        public void CargarProveedoresXProducto()
        {
            ddlProveedor.DataSource = null;
            ddlProveedor.DataBind();

            if (string.IsNullOrWhiteSpace(ddlProducto.SelectedValue))
            {
                return;
            }

            int idProducto = int.Parse(ddlProducto.SelectedValue);

            ProveedorNegocio negocio = new ProveedorNegocio();
            List<Proveedor> lista = negocio.ListarProveedorXProducto(idProducto);

            if(lista == null || lista.Count == 0)
            {
                lista = negocio.listar();
            }

            ddlProveedor.DataSource = lista;
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataValueField = "IDProveedor";
            ddlProveedor.DataBind();
        }

        public void btnRegistrar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string numeroFactura = txtNumeroFactura.Text.Trim();
            if (string.IsNullOrWhiteSpace(numeroFactura))
            {
                lblError.Text = "ingrese un numero de facutra";
                return;
            }

            if(string.IsNullOrWhiteSpace(ddlProducto.SelectedValue) || string.IsNullOrWhiteSpace(ddlProveedor.SelectedValue))
            {
                lblError.Text = "por favor seleccione un producto y un proveedor";
                return;
            }

            if(!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                lblError.Text = "Ingrese una cantidad mayor a 0";
                return;
            }

            if (!decimal.TryParse(txtPrecioCompraUltimo.Text, out decimal precio) || precio <= 0)
            {
                lblError.Text = "Ingrese un precio mayor a 0";
                return;
            }

            int idProducto = int.Parse(ddlProducto.SelectedValue);
            int idProveedor = int.Parse(ddlProveedor.SelectedValue);

            Compra compra = new Compra();

            compra.IDProveedor = new Proveedor { IDProveedor = idProveedor };

            int idUsuario = Convert.ToInt32(Session["IDUsuario"]);

            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            Usuario usuarioCompra = negocioUsuario.listarPorId(idUsuario);

            compra.IDUsuario = usuarioCompra;
            compra.NumeroFactura = numeroFactura;
            compra.Total = cantidad * precio;

            CompraNegocio negocioCompra = new CompraNegocio();
            int idCompra =negocioCompra.AgregarCompra(compra);

            if (idCompra > 0)
            {
                Dominio.CompraDetalle detalle = new Dominio.CompraDetalle();
                detalle.IDCompra= idCompra;
                detalle.IDCompraDetalle = idCompra;
                detalle.IDProducto = idProducto;
                detalle.Cantidad = cantidad;
                detalle.PrecioCompra = precio;
                detalle.Subtotal = compra.Total;

                negocioCompra.AgregarDetalleCompra(detalle);

                ProveedorNegocio negocioProveedor = new ProveedorNegocio();
                negocioProveedor.AsociarProductoProveedor(idProducto, idProveedor);
            }

            txtNumeroFactura.Text = "";
            txtCantidad.Text = "";
            txtPrecioCompraUltimo.Text = "";
            txtPorcentajeGanancia.Text = "";
        }
    }
}