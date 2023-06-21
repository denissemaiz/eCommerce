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
            user = new Usuario();

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio conexion = new UsuarioNegocio();
            user.Nombre = txtUser.Text;
            user.Contraseña = txtPass.Text;

            if (conexion.Login(user)) Session.Add("Usuario", user);
            
            
            Response.Redirect("Default.aspx");
        }
    }
}