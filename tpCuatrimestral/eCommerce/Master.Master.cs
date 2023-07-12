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
            //if (Session["CarritoCargado"] == null)
            //{
                carritoNegocio = new Carrito();
                if (Session["librosAgregados"] != null)
                {
                    carritoNegocio.Libros = (List<Libro>)Session["librosAgregados"];                
                    lblContador.Text = carritoNegocio.Libros.Count().ToString();
                    //Session["CarritoCargado"] = carritoNegocio;
                }
            //}
            //else
            //{
            //    if (Session["librosAgregados"] != null)
            //    {
            //        carritoNegocio = (Carrito)Session["CarritoCargado"];
            //        lblContador.Text = carritoNegocio.Libros.Count().ToString();
            //    }
            //}
        }        

        protected void repProductos_Load(object sender, EventArgs e)
        {
            if (Session["librosAgregados"] != null)
            {
                LibroNegocio manejoLista = new LibroNegocio();
                repProductos.DataSource = manejoLista.RemoveDuplicadosLibro(carritoNegocio.Libros);
                repProductos.DataBind();
            }
            //if (Session["librosAgregados"] != null)
            //{
            //    if (Session["CarritoCargado"] != null)
            //    {
            //        Carrito carritoCargado = (Carrito)Session["CarritoCargado"];
            //        if (carritoCargado.Productos == null)
            //        {
            //            carritoCargado.OrganizarProductos(carritoCargado.Libros);
            //            Session["CarritoCargado"] = carritoCargado;
            //        }
            //        repProductos.DataSource = carritoCargado.Productos; 
            //        repProductos.DataBind();

            //    }
            //}
        }

        protected void lbtnSumar_Click(object sender, EventArgs e)
        {
            string codigo = ((LinkButton)sender).CommandArgument;
            LibroNegocio datos = new LibroNegocio();
            List<Libro> busqueda = datos.Buscar(codigo, "Codigo");
            if (busqueda != null && carritoNegocio != null)
            {
                carritoNegocio.Libros.Add(busqueda.First());
                repProductos_Load(sender, e);
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

    }
}