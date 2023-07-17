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
    public partial class Detalles : System.Web.UI.Page
    {
        public List<Libro> listarLibros { get; set; }
        public List<Autor> listarAutor { get; set; }
        public List<Genero> listarGenero { get; set; }

        public Libro librito = new Libro();
        public List<Libro> librosCarrito = new List<Libro>();

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
                    Response.Redirect("Productos.aspx");
                }
                else
                {
                    librosCarrito = (List<Libro>)Session["librosAgregados"];
                    librosCarrito.Add(listarLibros.First());
                    Session.Add("librosAgregados", librosCarrito);
                    Response.Redirect("Productos.aspx");
                }
            }
        }
    }
}