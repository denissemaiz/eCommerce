using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using Conexiones;
using dominio;

namespace eCommerce.User
{
    public partial class RecuperarPasswordMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {

            UsuarioNegocio conexion = new UsuarioNegocio();

            string Correo = txtRecuperarMail.Text;

            ServicioMail Mail = new ServicioMail();

            if (conexion.VerificarCorreo(Correo)) 
            {

                string valor = Guid.NewGuid().ToString();

                string RecuperarMail = $"https://localhost:44313/User/RecuperarContrase%C3%B1a.aspx?ref={valor}";

                Mail.EnviarEnlaceRecuperacion(Correo, RecuperarMail);
                   
                lblMensaje.Visible = true;
                lblMensaje.Text = "Correo enviado!";
            }

            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Correo ingresado no registrado";
            }



        }


    }
}