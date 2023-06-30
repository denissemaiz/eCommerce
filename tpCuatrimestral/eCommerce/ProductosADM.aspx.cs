using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;


namespace eCommerce
{
    public partial class ProductosADM : System.Web.UI.Page
    {

        public List<Libro> ListarLibros { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            

           LibroNegocio negocio = new LibroNegocio();
           ListarLibros = negocio.ListarL();
            Repetidor.DataSource = ListarLibros;
            Repetidor.DataBind();
            

        }

    }
}