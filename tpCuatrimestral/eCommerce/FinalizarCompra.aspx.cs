using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using Conexiones;
using Clases;

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
                
            }
            else
            {
                if (Session["librosAgregados"] != null)
                {
                    carrito.Libros = (List<Libro>)Session["librosAgregados"];
                    LibrosSinRepetidos = libroNegocio.RemoveDuplicadosLibro(carrito.Libros);
                }
            }
        }

        protected void PrecioFinal_Load(object sender, EventArgs e)
        {
            if (carrito.Libros != null)
                PrecioFinal.Text = carrito.CalcularMonto().ToString();
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            Session["Carrito"] = carrito;
            Response.Redirect("User/CheckFinal.aspx", false);
        }

        protected void repLibros_Load(object sender, EventArgs e)
        {
            if (LibrosSinRepetidos != null)
            {
                repLibros.DataSource = LibrosSinRepetidos;
                repLibros.DataBind();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            String codigo =  button.CommandArgument;

            carrito.RemoverLibro(codigo);

            Session["librosAgregados"] = carrito.Libros;
            
            LibroNegocio libroNegocio = new LibroNegocio();
            LibrosSinRepetidos = libroNegocio.RemoveDuplicadosLibro(carrito.Libros);

            repLibros_Load(sender, e);
            PrecioFinal_Load(sender, e);
        }
    }
}