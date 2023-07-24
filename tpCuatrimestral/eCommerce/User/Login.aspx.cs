using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using Conexiones;
using dominio;
using negocio;

namespace eCommerce
{
    public partial class Login : System.Web.UI.Page
    {
        Usuario user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Session.Add("error", "Usted ya se encuentra logueado, para iniciar sesion por favor desconecte su sesión actual");
                Response.Redirect("../Error.aspx", false);
            }
            user = new Usuario();

        }

        protected void btnIngresar_Click1(object sender, EventArgs e)
        {
            UsuarioNegocio conexion = new UsuarioNegocio();
            try
            {
                user.Username = txtUser.Text;
                user.Contraseña =txtPass.Text;

                user.Contraseña = user.EncriptarPass(user.Contraseña);

                if (conexion.Login(user))
                {
                    Session.Add("Usuario", user);
                    if (Session["loginNecesario"] != null)
                    {
                        string url = Session["loginNecesario"] as string;
                        Session.Remove("loginNecesario");
                        Response.Redirect(url, false);
                    }else
                        Response.Redirect("../PanelUsuario.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o contraseña incorrecto");
                    Response.Redirect("../Error.aspx", false);
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("../Error.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }
    }
}