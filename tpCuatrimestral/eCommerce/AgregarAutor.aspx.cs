using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using Conexiones;
using negocio;
using System.Globalization;
using System.Text;

namespace eCommerce
{
    public partial class AgregarAutor : System.Web.UI.Page
    {
        Autor autor;
        AutorNegocio autornegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            autor = new Autor();

        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            autor.Nombre = txt_autornombre.Text;
            autor.Apellido = txt_autorapellido.Text;

            autornegocio = new AutorNegocio();
            try
            {
                List<Autor> autores = autornegocio.Listar();
                bool cond = false;
                foreach (Autor autorList in autores)
                {
                    if(RemoverAcentos( autorList.NombreApellido ).ToLower() 
                        == RemoverAcentos ( autor.NombreApellido ).ToLower() )
                        cond = true;
                }
                if (!cond)
                {
                    autornegocio.Agregar(autor);
                    lblagregado.Visible = true;
                    txt_autornombre.Text = "";
                    txt_autorapellido.Text = "";
                }
                else
                {
                    txt_autornombre.Text = "";
                    txt_autorapellido.Text = "";
                    Lblfallo.Visible = true;

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