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
    }
}