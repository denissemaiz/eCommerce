using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using dominio;
using negocio;


namespace eCommerce
{
    public partial class Productos : System.Web.UI.Page
    {
        public List<Libro> listaLibros { get; set; }
        public List<Libro> librosCarrito = new List<Libro>();
        public Carrito carrito { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            LibroNegocio librosDB = new LibroNegocio();

            if (!IsPostBack)
            {
                if (Request.QueryString.AllKeys.Contains("generosLib"))
                {
                    string genero = Request.QueryString["generosLib"].ToString();
                    List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.Buscar(genero, "ID_Genero"));
                    repLibros.DataSource = listaSinRepetidos;
                    repLibros.DataBind();
                }

                if (Request.QueryString.AllKeys.Contains("autoresLib"))
                {
                    string autor = Request.QueryString["autoresLib"].ToString();
                    List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.Buscar(autor, "ID_Autor"));
                    repLibros.DataSource = listaSinRepetidos;
                    repLibros.DataBind();
                }

                if (Request.QueryString.AllKeys.Contains("tituloLib"))
                {
                    string titulo = Request.QueryString["tituloLib"].ToString();
                    List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.Buscar(titulo, "Titulo"));
                    repLibros.DataSource = listaSinRepetidos;
                    repLibros.DataBind();
                }

                if (!Request.QueryString.AllKeys.Contains("autoresLib") && !Request.QueryString.AllKeys.Contains("generosLib") && !Request.QueryString.AllKeys.Contains("tituloLib"))
                {
                    List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.Listar());
                    repLibros.DataSource = listaSinRepetidos;
                    repLibros.DataBind();
                }
            }
            
        }

        protected void btnEliminarLibro_Click(object sender, EventArgs e)
        {
            string idLibro = ((Button)sender).CommandArgument;

            LibroNegocio articulos = new LibroNegocio();
            listaLibros = articulos.PruebaBuscar(idLibro);

            if (listaLibros != null)
            {
                LibroNegocio negocio = new LibroNegocio();
                int id = Convert.ToInt32(idLibro);
                negocio.Eliminar(id);
                Response.Redirect("Productos.aspx");
            }
        }

        protected void btnModificarLibro_Click(object sender, EventArgs e)
        {
            Response.Redirect("StoreProc.aspx");
        }

        protected void btnAgregarACarrito_Click(object sender, EventArgs e)
        {
            string codigo = ((Button)sender).CommandArgument;

            LibroNegocio datosLibros = new LibroNegocio();
            listaLibros = datosLibros.Buscar(codigo, "Codigo");

            if (listaLibros != null)
            {
                if (Session["librosAgregados"] == null)
                {
                    librosCarrito.Add(listaLibros.First());
                    Session.Add("librosAgregados", librosCarrito);
                    Response.Redirect("Productos.aspx");
                }
                else
                {
                    librosCarrito = (List<Libro>)Session["librosAgregados"];
                    librosCarrito.Add(listaLibros.First());
                    Session.Add("librosAgregados", librosCarrito);
                    Response.Redirect("Productos.aspx");
                }
            }
        }

        public bool EsStockDisponible(string codigoLibro)
        {
            LibroNegocio librosDB = new LibroNegocio();

            listaLibros = librosDB.Buscar(codigoLibro, "Codigo");

            if (listaLibros != null)
            {
                if (listaLibros.First().Stock > 0) { return true; }
            }

            return false;
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