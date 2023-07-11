using Clases;
using Conexiones;
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
    public partial class Master : System.Web.UI.MasterPage
    {
        public Carrito carritoNegocio { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            GeneroNegocio generosDB = new GeneroNegocio();
            AutorNegocio autoresDB = new AutorNegocio();
            if (!IsPostBack)
            {
                repGeneros.DataSource = generosDB.RemoveDuplicadosGenero(generosDB.Listar());
                repGeneros.DataBind();
                repAutores.DataSource = autoresDB.RemoveDuplicadosAutor(autoresDB.Listar());
                repAutores.DataBind();
            }
        }

        protected void lblContador_Load(object sender, EventArgs e)
        {
            carritoNegocio = new Carrito();
            if (Session["librosAgregados"] != null)
            {
                carritoNegocio.Libros = (List<Libro>)Session["librosAgregados"];                
                lblContador.Text = carritoNegocio.Libros.Count().ToString();
                
            }
        }        

        protected void repProductos_Load(object sender, EventArgs e)
        {
            if (Session["librosAgregados"] != null && carritoNegocio != null)
            {
                carritoNegocio.OrganizarProductos(carritoNegocio.Libros);
                repProductos.DataSource = carritoNegocio.Productos; 
                repProductos.DataBind();
            }
        }

        protected void lbtnSumar_Click(object sender, EventArgs e)
        {
            string codigo = ((LinkButton)sender).CommandArgument;
            LibroNegocio datos = new LibroNegocio();
            List<Libro> busqueda = datos.Buscar(codigo, "Codigo");
            if (busqueda != null && carritoNegocio != null)
            {
                carritoNegocio.agregarProd(busqueda.First());
                carritoNegocio.Libros.Add(busqueda.First());
                Session["librosAgregados"] = carritoNegocio.Libros;
                
            }
        }

        protected void lbtnRestarLibro_Click(object sender, EventArgs e)
        {
            string codigo = ((LinkButton)sender).CommandArgument;
            LibroNegocio datos = new LibroNegocio();
            List<Libro> busqueda = datos.Buscar(codigo, "Codigo");
            if (busqueda != null && carritoNegocio != null)
            {
                carritoNegocio.QuitarProd(busqueda.First());
                Session["librosAgregados"] = carritoNegocio.Libros;
                repProductos_Load(sender, e);
            }
        }
    }
}