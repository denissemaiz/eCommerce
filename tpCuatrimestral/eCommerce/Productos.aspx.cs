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
        public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            List<Articulo> listaSinRepetidos = articulo.RemoveDuplicadosArticulo(articulo.Listar());
            repArticulos.DataSource = listaSinRepetidos;
            repArticulos.DataBind();
        }
    }
}