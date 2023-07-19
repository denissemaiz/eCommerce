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
        

        protected void Page_Load(object sender, EventArgs e)
        {


        }


        public Usuario nuevo { get; set; }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            nuevo = new Usuario();

            string aux = txtContraseñaNueva.Text;
            string aux2 = txtContraseñaNuevaConfirmar.Text;

            string Nuevapass = nuevo.EncriptarPass(aux);
            string Confirmarpass = nuevo.EncriptarPass(aux2);

            if (Nuevapass == Confirmarpass) 
            {

  



            }
            else 
            { 
                LblFallo.Visible = true;
            
            
            }

        }
    }
}