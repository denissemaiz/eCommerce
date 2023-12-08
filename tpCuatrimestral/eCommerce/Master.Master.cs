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
        public List<Libro> LibrosSinRepetidos { get; set; }
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

                carritoNegocio = new Carrito();
                carritoNegocio.Libros = new List<Libro>();
                
                if (Session["librosAgregados"] != null)
                {
                    carritoNegocio.Libros = (List<Libro>)Session["librosAgregados"];
                    
                    LibroNegocio manejoLibros = new LibroNegocio();
                    LibrosSinRepetidos = manejoLibros.RemoveDuplicadosLibro(carritoNegocio.Libros);
                }
            }
            else
            {
                if (carritoNegocio == null || carritoNegocio.Libros == null)
                {
                    carritoNegocio = new Carrito();
                    carritoNegocio.Libros = new List<Libro>();
                }
                if (Session["librosAgregados"] != null)
                {
                    carritoNegocio.Libros = (List<Libro>)Session["librosAgregados"];

                    LibroNegocio manejoLibros = new LibroNegocio();
                    LibrosSinRepetidos = manejoLibros.RemoveDuplicadosLibro(carritoNegocio.Libros);
                }   
            }
        }

        protected void lblContador_Load(object sender, EventArgs e)
        {
            if (carritoNegocio.Libros.Count() > 0)
                lblContador.Text = carritoNegocio.Libros.Count().ToString();
        }        

        protected void repProductos_Load(object sender, EventArgs e)
        {
            if(LibrosSinRepetidos != null)
            {
                repProductos.DataSource = LibrosSinRepetidos;
                repProductos.DataBind();
            }
            
        }

        protected void lbtnSumar_Click(object sender, EventArgs e)
        {
            string codigo = ((LinkButton)sender).CommandArgument;
            LibroNegocio datos = new LibroNegocio();
            Libro busqueda = datos.Buscar_x_Codigo(codigo);
            if (busqueda != null && carritoNegocio != null)
            {
                if(busqueda.Stock >= carritoNegocio.contabilizarLibro(busqueda.Id) + 1) 
                {
                    carritoNegocio.Libros.Add(busqueda);
                    Session["librosAgregados"] = carritoNegocio.Libros;

                    lblContador_Load(sender, e);
                    repProductos_Load(sender, e);

                }
            }
        }

        protected void lbtnRestarLibro_Click(object sender, EventArgs e)
        {
            string codigo = ((LinkButton)sender).CommandArgument;
            LibroNegocio datos = new LibroNegocio();
            Libro busqueda = datos.Buscar_x_Codigo(codigo);
            if (busqueda != null && carritoNegocio != null)
            {
                if(carritoNegocio.QuitarLibro(busqueda.Id))
                    Session["librosAgregados"] = carritoNegocio.Libros;
                LibrosSinRepetidos = datos.RemoveDuplicadosLibro(carritoNegocio.Libros);

                lblContador_Load(sender, e);
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