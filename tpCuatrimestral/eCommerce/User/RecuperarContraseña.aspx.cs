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

            TokensNegocio tokenConexion = new TokensNegocio();
            nuevo = new Usuario();

            string nuevaPass = txtContraseñaNueva.Text;
            string nuevaPassEncryptada = nuevo.EncriptarPass(nuevaPass);

            nuevo.Mail = tokenConexion.BuscarMail_x_Token(token);
            nuevo.Contraseña = nuevaPassEncryptada;

            UsuarioNegocio userConexion = new UsuarioNegocio();
            
            if(userConexion.VerificarPassUsada(nuevo.Mail, nuevo.Contraseña) != true)
            {
                try
                {
                    tokenConexion.UpdatePass_x_Token(token, nuevaPassEncryptada);
                    Response.Redirect("Login.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("../error.aspx");
                }
                finally
                {
                    tokenConexion.BajaToken(token);
                }
            }
            else
            {
                Session.Add("error", "Su contraseña no puede ser igual a su contraseña anterior");
                Response.Redirect("../Error.aspx");
            }

        }
    }
}