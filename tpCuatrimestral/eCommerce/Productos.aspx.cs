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
    public partial class Productos : System.Web.UI.Page
    {
        public List<Libro> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            LibroNegocio articulo = new LibroNegocio();
            List<Libro> listaSinRepetidos = articulo.RemoveDuplicadosLibro(articulo.Listar());
            repArticulos.DataSource = listaSinRepetidos;
            repArticulos.DataBind();
        }
    }
}