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
            if (Session["librosAgregados"] != null)
            {
                LibroNegocio manejoLista = new LibroNegocio();
                repProductos.DataSource = manejoLista.RemoveDuplicadosLibro(carritoNegocio.Libros);
                repProductos.DataBind();
                lblContador_Load(sender, e);
            }
            
        }

        protected void lbtnSumar_Click(object sender, EventArgs e)
        {
            string codigo = ((LinkButton)sender).CommandArgument;
            LibroNegocio datos = new LibroNegocio();
            Libro busqueda = datos.Buscar(codigo, "Codigo").First();
            if (busqueda != null && carritoNegocio != null)
            {
                if(busqueda.Stock >= carritoNegocio.contabilizarLibro(busqueda.Id) + 1) 
                {
                    carritoNegocio.Libros.Add(busqueda);
                    repProductos_Load(sender, e);
                }
            }
        }

        protected void lbtnRestarLibro_Click(object sender, EventArgs e)
        {
            string codigo = ((LinkButton)sender).CommandArgument;
            LibroNegocio datos = new LibroNegocio();
            List<Libro> busqueda = datos.Buscar(codigo, "Codigo");
            if (busqueda != null && carritoNegocio != null)
            {
                if(carritoNegocio.QuitarLibro(busqueda.First().Id))
                repProductos_Load(sender, e);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
                LibroNegocio librosDB = new LibroNegocio();
                Response.Redirect("Productos.aspx?tituloLib=" + txtbxBuscar.Text);
        }

        public bool ValidarAdmin()
        {
            Usuario user;
            if (Session["Usuario"] != null)
            {
                user = ((Usuario)Session["Usuario"]);
                return user.EsAdmin;
            }
            return false;
        }
    }
}