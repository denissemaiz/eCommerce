using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using dominio;
using negocio;


namespace eCommerce
{
    public partial class StoreProc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LibroNegocio negocio = new LibroNegocio();
            DVGLibros.DataSource = negocio.ListarL();
            DVGLibros.DataBind();
        }

        protected void DVGLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = DVGLibros.SelectedDataKey.Value.ToString();
            Response.Redirect("AgregarProducto.aspx?id=" + Id);
        }

        protected void DVGLibros_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            DVGLibros.PageIndex = e.NewSelectedIndex;
            DVGLibros.DataBind();
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