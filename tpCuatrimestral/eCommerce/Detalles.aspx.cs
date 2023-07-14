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

        public List<Libro> ListarLibros { get; set; }
        public List<Autor> ListarAutor { get; set; }
        public List<Genero> ListarGenero { get; set; }

        public Libro Librito = new Libro();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.AllKeys.Contains("cod")) 
            { 
                string codigo = Request.QueryString["cod"].ToString();
                LibroNegocio libro = new LibroNegocio();
                GeneroNegocio genero = new GeneroNegocio();
                AutorNegocio autor = new AutorNegocio();
                ListarLibros = libro.BuscarporCodigo(codigo);
                ListarGenero = genero.BuscarGenero(codigo);
                ListarAutor = autor.BuscarAutor(codigo);

                if(ListarLibros.Count() != 0) 
                {
                    Librito = ListarLibros.First();
                    Librito.Generos = ListarGenero;
                    Librito.Autores = ListarAutor;
                }

            }

         }
    }
}