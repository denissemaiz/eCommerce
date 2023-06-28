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

namespace eCommerce.User
{
    public partial class Registro : System.Web.UI.Page
    {
        Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = new Usuario();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            UsuarioNegocio datos = new UsuarioNegocio();

            usuario.Username = txtUser.Text;
            usuario.Contraseña = txtPass.Text;
            usuario.Mail = txtEmail.Text;
            usuario.EsAdmin = false;

            

            if (usuario.ConfirmarContraseña(txtConfPass.Text))
            {

                if(datos.Registro(usuario,ref mensaje))
                {
                    Session.Add("mensaje", mensaje);
                    Response.Redirect("../Default.aspx");
                }
                else
                {
                    Session.Add("error", mensaje);
                    Response.Redirect("../Error.aspx");
                }
            }
        }
    }
}