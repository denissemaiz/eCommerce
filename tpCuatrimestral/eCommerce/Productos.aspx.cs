using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
        public Carrito carritoNegocio { get; set; }
        public List<Libro> LibrosSinRepetidos { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            LibroNegocio librosDB = new LibroNegocio();

            if (!IsPostBack)
            {
                carritoNegocio = new Carrito();
                carritoNegocio.Libros = new List<Libro>();

                if (Session["librosAgregados"] != null)
                {
                    carritoNegocio.Libros = (List<Libro>)Session["librosAgregados"];

                    LibroNegocio manejoLibros = new LibroNegocio();
                    List<Libro> LibrosSinRepetidos = manejoLibros.RemoveDuplicadosLibro(carritoNegocio.Libros);
                }

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
                    List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.ListarL());
                    repLibros.DataSource = listaSinRepetidos;
                    repLibros.DataBind();
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
            string id = ((Button)sender).CommandArgument;

            Response.Redirect("AgregarProducto.aspx?id=" + id);


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

        protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Encuentra el control mensajeStock
                HtmlGenericControl mensajeStock = (HtmlGenericControl)e.Item.FindControl("mensajeStock");

                if (mensajeStock != null)
                {
                    string codigoLibro = DataBinder.Eval(e.Item.DataItem, "Codigo").ToString();

                    if (!EsStockDisponible(codigoLibro))
                    {
                        mensajeStock.InnerText = "No hay más stock";
                        mensajeStock.Style["display"] = "block";  // Muestra el mensaje
                    }
                    else
                    {
                        mensajeStock.Style["display"] = "none";  // Oculta el mensaje si se muestra
                    }
                }
            }
        }

        public bool EsStockDisponible(string codigoLibro)
        {
            LibroNegocio librosDB = new LibroNegocio();
            Libro busqueda = librosDB.Buscar_x_Codigo(codigoLibro);

            if (busqueda != null)
            {
                if (busqueda.Stock <= 0) { return false; } 
                if (Session["librosAgregados"] != null && !(busqueda.Stock >= carritoNegocio.contabilizarLibro(busqueda.Id) + 1)) { return false; }
            }

            return true;
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