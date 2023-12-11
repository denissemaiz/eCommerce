using Clases;
using Conexiones;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace eCommerce
{
    public partial class Detalles : System.Web.UI.Page
    {
        public List<Libro> listarLibros { get; set; }
        public List<Autor> listarAutor { get; set; }
        public List<Genero> listarGenero { get; set; }

        public Libro librito = new Libro();
        public List<Libro> librosCarrito = new List<Libro>();
        public Carrito carritoNegocio { get; set; }
        public List<Libro> LibrosSinRepetidos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.AllKeys.Contains("cod")) 
            { 
                string codigo = Request.QueryString["cod"].ToString();
                LibroNegocio libro = new LibroNegocio();
                GeneroNegocio genero = new GeneroNegocio();
                AutorNegocio autor = new AutorNegocio();
                listarLibros = libro.BuscarporCodigo(codigo);
                listarGenero = genero.BuscarGenero(codigo);
                listarAutor = autor.BuscarAutor(codigo);

                if(listarLibros.Count() != 0) 
                {
                    librito = listarLibros.First();
                    librito.Generos = listarGenero;
                    librito.Autores = listarAutor;
                }

                carritoNegocio = new Carrito();
                carritoNegocio.Libros = new List<Libro>();

                if (Session["librosAgregados"] != null)
                {
                    carritoNegocio.Libros = (List<Libro>)Session["librosAgregados"];

                    LibroNegocio manejoLibros = new LibroNegocio();
                    LibrosSinRepetidos = manejoLibros.RemoveDuplicadosLibro(carritoNegocio.Libros);
                }

                bool habilitarBoton = EsStockDisponible(codigo);

                btnAgregarACarritoDetalles.Enabled = habilitarBoton;      

                if (!habilitarBoton)
                {
                    mensajeStock.InnerText = "No hay más stock de este producto";
                    mensajeStock.Style["display"] = "block";  // Muestra el mensaje
                }
                else
                {
                    mensajeStock.Style["display"] = "none";  // Oculta el mensaje si se muestra
                }                
            }
            else
            {
                Response.Redirect("Productos.aspx");
            }
         }

        protected void btnAgregarACarritoDetalles_Click(object sender, EventArgs e)
        {
            string codigo = Request.QueryString["cod"].ToString();

            LibroNegocio datosLibros = new LibroNegocio();
            listarLibros = datosLibros.Buscar(codigo, "Codigo");

            if (listarLibros != null)
            {
                if (Session["librosAgregados"] == null)
                {
                    librosCarrito.Add(listarLibros.First());
                    Session.Add("librosAgregados", librosCarrito);
                    Response.Redirect("Detalles.aspx?cod=" + codigo);
                }
                else
                {
                    librosCarrito = (List<Libro>)Session["librosAgregados"];
                    librosCarrito.Add(listarLibros.First());
                    Session.Add("librosAgregados", librosCarrito);
                    Response.Redirect("Detalles.aspx?cod=" + codigo);
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
    }
}