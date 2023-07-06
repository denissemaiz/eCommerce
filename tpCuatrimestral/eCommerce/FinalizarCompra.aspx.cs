using dominio;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = new Carrito();

            carrito.Libros = (List<Libro>)Session["librosAgregados"];
            repLibros.DataSource = carrito.Libros;
            repLibros.DataBind();

            if (Session["librosAgregados"] != null)
            {
                decimal Monto = carrito.CalcularMonto();
                PrecioFinal.Text = Monto.ToString();
            }
        }
    }
}