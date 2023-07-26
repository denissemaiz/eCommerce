using System;
using Clases;
using Conexiones;
using dominio;
using negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace eCommerce.User
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        public string token { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ref"] != null)
            {
                token = Request.QueryString["ref"].ToString();
                
                TokensNegocio tokenData = new TokensNegocio();
                if (tokenData.ValidarToken(token) == false) 
                {
                    Session.Add("error", "ERROR, Token a expirado");
                    Response.Redirect("../Error.aspx");
                }

            }
            else
            {
                Session.Add("error", "Error, usted no posee un token valido");
                Response.Redirect("../Error.aspx");
            }

        }


        public Usuario nuevo { get; set; }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            nuevo = new Usuario();

            string nuevaPass = txtContraseñaNueva.Text;
            string nuevaPassEncryptada = nuevo.EncriptarPass(nuevaPass);

            try
            {
                TokensNegocio tokenConexion = new TokensNegocio();

                tokenConexion.UpdatePass_x_Token(token, nuevaPassEncryptada);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../error.aspx");
            }
            

        }
    }
}