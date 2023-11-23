using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using Conexiones;

namespace eCommerce
{
    public partial class DetallesCompra2 : System.Web.UI.Page
    {
        Compra pedido = new Compra();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPedido"] != null)
                {
                    int id =Convert.ToInt32(Session["idPedido"]);
                    CompraNegocio negocio = new CompraNegocio();

                    pedido = negocio.BuscarCompra(id);
                }
            }
        }
    }
}