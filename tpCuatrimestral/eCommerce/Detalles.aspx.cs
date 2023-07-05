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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.AllKeys.Contains("cod")) 
            { 
                string codigo = Request.QueryString["cod"].ToString();
                LibroNegocio libro = new LibroNegocio();
                ListarLibros = libro.BuscarporCodigo(codigo);

            }

         }
    }
}