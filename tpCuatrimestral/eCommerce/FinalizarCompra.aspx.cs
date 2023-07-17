using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        public Carrito carrito { get; set; }
        public List<Libro> LibrosSinRepetidos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            LibroNegocio libroNegocio = new LibroNegocio();
            if(!IsPostBack || Session["librosAgregados"] != null && carrito == null)
            {
                carrito = new Carrito();
                if (Session["librosAgregados"] != null)
                {
                    carrito.Libros = (List<Libro>)Session["librosAgregados"];
                    LibrosSinRepetidos = libroNegocio.RemoveDuplicadosLibro(carrito.Libros);
                }else 
                    LibrosSinRepetidos = new List<Libro>();

                repLibros.DataSource = LibrosSinRepetidos;
                repLibros.DataBind();
            }
            else
            {
                if (Session["librosAgregados"] != null)
                {
                    carrito.Libros = (List<Libro>)Session["librosAgregados"];
                    LibrosSinRepetidos = libroNegocio.RemoveDuplicadosLibro(carrito.Libros);
                    repLibros.DataSource=LibrosSinRepetidos;
                    repLibros.DataBind();
                }
            }
        }

        protected void PrecioFinal_Load(object sender, EventArgs e)
        {
            if (carrito.Libros != null)
                PrecioFinal.Text = carrito.CalcularMonto().ToString();
        }
    }
}