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
using System.Security.Cryptography;
using System.Text;

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
                TokensNegocio token = new TokensNegocio();
                
                string valor = Guid.NewGuid().ToString();
                valor = EncriptarToken(valor);


                string RecuperarMail = $"https://localhost:44313/User/RecuperarContrase%C3%B1a.aspx?ref={valor}";

                Mail.EnviarEnlaceRecuperacion(Correo, RecuperarMail);
                   
                lblMensaje.Visible = true;
                lblMensaje.Text = "Correo enviado!";

                try
                {
                    token.Cargar(valor, Correo);
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("../error.aspx");
                }
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Correo ingresado no registrado";
            }



        }

        internal string EncriptarToken(string pass)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(pass));

                foreach (byte b in result)
                    sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

    }
}