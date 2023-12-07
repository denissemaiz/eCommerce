using Clases;
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
    public partial class AgregarGenero : System.Web.UI.Page
    {
        Genero genero;
        GeneroNegocio generonegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            genero = new Genero();
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            genero.Nombre = txt_genero.Text;
            genero.Descripcion = txt_descripcion.Text;
            generonegocio = new GeneroNegocio();

            try
            {
                generonegocio.Agregar(genero);
                lblagregado.Visible = true;
                txt_genero.Text = "";
                txt_descripcion.Text = "";
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
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