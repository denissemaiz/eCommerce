using Clases;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
                List<Genero> generos = generonegocio.Listar();
                bool cond = false;
                foreach (Genero generoNegocio in generos)
                    if(RemoverAcentos(genero.Nombre).ToLower() == RemoverAcentos(generoNegocio.Nombre).ToLower())
                        cond = true;
                if (!cond)
                {
                    generonegocio.Agregar(genero);
                    lblagregado.Visible = true;
                    txt_genero.Text = "";
                    txt_descripcion.Text = "";
                }
                else
                {
                    //txt_genero.Text = "";
                    //txt_descripcion.Text = "";
                }
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

        static string RemoverAcentos(string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

    }
}