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
        public Carrito Carro { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Carro = new Carrito();

            Carro.Libros = (List<Libro>)Session["librosAgregados"];
            repLibros.DataSource = Carro.Libros;
            repLibros.DataBind();

            if (Session["librosAgregados"] != null)
            {
                decimal Monto = Carro.CalcularMonto();
                PrecioFinal.Text = Monto.ToString();
            }
        }
    }
}