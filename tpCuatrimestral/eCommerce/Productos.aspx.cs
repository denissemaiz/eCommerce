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

        public Libro libro {  get; set; }


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

                    if (listaSinRepetidos.Count != 0)
                    {
                        repLibros.DataSource = listaSinRepetidos;
                        repLibros.DataBind();
                    }
                    else
                    {
                        Session.Add("error", "No se encontró ninguna coincidencia.");
                        Response.Redirect("Error.aspx", false);
                    }
                }

                if (Request.QueryString.AllKeys.Contains("autoresLib"))
                {
                    string autor = Request.QueryString["autoresLib"].ToString();
                    List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.Buscar(autor, "ID_Autor"));

                    if (listaSinRepetidos.Count != 0)
                    {
                        repLibros.DataSource = listaSinRepetidos;
                        repLibros.DataBind();
                    }
                    else
                    {
                        Session.Add("error", "No se encontró ninguna coincidencia.");
                        Response.Redirect("Error.aspx", false);
                    }
                }

                if (Request.QueryString.AllKeys.Contains("tituloLib"))
                {
                    string titulo = Request.QueryString["tituloLib"].ToString();
                    List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.Buscar(titulo, "Titulo"));
                    
                    if (listaSinRepetidos.Count != 0)
                    {
                        repLibros.DataSource = listaSinRepetidos;
                        repLibros.DataBind();
                    }
                    else
                    {
                        Session.Add("error", "No se encontró ninguna coincidencia.");
                        Response.Redirect("Error.aspx", false);
                    }
                }

                if (Request.QueryString.AllKeys.Contains("busquedaGeneral"))
                {
                    string palabra = Request.QueryString["busquedaGeneral"].ToString();
                    List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.BusquedaGeneral(palabra));

                    if (listaSinRepetidos.Count != 0)
                    {
                        repLibros.DataSource = listaSinRepetidos;
                        repLibros.DataBind();
                    }
                    else
                    {
                        Session.Add("error", "No se encontró ninguna coincidencia.");
                        Response.Redirect("Error.aspx", false);
                    }
                }

                if (!Request.QueryString.AllKeys.Contains("autoresLib") && !Request.QueryString.AllKeys.Contains("generosLib") && !Request.QueryString.AllKeys.Contains("tituloLib") && !Request.QueryString.AllKeys.Contains("busquedaGeneral"))
                {
                    if (ValidarAdmin()) 
                    {
                        List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.ListarL());
                        repLibros.DataSource = listaSinRepetidos;
                        repLibros.DataBind();
                    }
                    else
                    {
                        List<Libro> listaFinal = librosDB.RemoveDuplicadosLibro(librosDB.ListarL());
                        listaFinal = RemoveNoDisponbles(listaFinal);
                        repLibros.DataSource = listaFinal;
                        repLibros.DataBind();
                    }
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
            //listaLibros = articulos.PruebaBuscar(idLibro);
            libro = articulos.Buscar_X_Id(idLibro);
            //libro = listaLibros.First();
            string codigo = libro.Codigo;

            if (libro != null)
            {
                LibroNegocio negocio = new LibroNegocio();
                //libro = listaLibros.First();
                libro.Activo = false;

                negocio.Modificar(libro);
                Response.Redirect("Productos.aspx");
            }

            /*
            if (EsStockDisponible(codigo))
            {
                LibroNegocio negocio = new LibroNegocio();
                libro = listaLibros.First();
                libro.Stock = short.Parse("0");

                negocio.Modificar(libro);
                Response.Redirect("Productos.aspx");
            }*/

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
                HtmlGenericControl mensajeSinStock = (HtmlGenericControl)e.Item.FindControl("mensajeSinStock");
                HtmlGenericControl mensajeUltStock = (HtmlGenericControl)e.Item.FindControl("mensajeUltStock");
                HtmlGenericControl mensajeEliminado = (HtmlGenericControl)e.Item.FindControl("mensajeEliminado");                

                if (mensajeSinStock != null || mensajeUltStock != null)
                {
                    string codigoLibro = DataBinder.Eval(e.Item.DataItem, "Codigo").ToString();

                    if (EsLibroActivo(codigoLibro))
                    {
                        if (!EsStockDisponible(codigoLibro))
                        {
                            mensajeSinStock.InnerText = "No hay más stock";
                            mensajeSinStock.Style["display"] = "block";
                        }
                        else
                        {
                            if (stockDisponible(codigoLibro) == 1)
                            {
                                mensajeUltStock.InnerText = "¡Último disponible!";
                                mensajeUltStock.Style["display"] = "block";
                            }
                            mensajeSinStock.Style["display"] = "none";
                        }
                    }
                    else
                    {
                        mensajeEliminado.InnerText = "Producto eliminado.";
                        mensajeEliminado.Style["display"] = "block";
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

        public bool EsLibroActivo(string codigo)
        {
            LibroNegocio librosDB = new LibroNegocio();
            Libro busqueda = librosDB.Buscar_x_Codigo(codigo);

            return busqueda.Activo;
        }

        public int stockDisponible(string codigoLibro)
        {
            LibroNegocio librosDB = new LibroNegocio();
            Libro busqueda = librosDB.Buscar_x_Codigo(codigoLibro);

            if (busqueda != null)
            {
                return busqueda.Stock;
            }

            return 0;
        }

        public List<Libro> RemoveNoDisponbles(List<Libro> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Libro> finalList = new List<Libro>();
            foreach (Libro lib in inputList)
            {
                if (!uniqueStore.ContainsKey(lib.Codigo.ToString()) && lib.Activo)
                {
                    uniqueStore.Add(lib.Codigo.ToString(), "0");
                    finalList.Add(lib);
                }
            }
            return finalList;
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