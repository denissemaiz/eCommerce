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
            token = Request.QueryString["ref"];

        }


        public Usuario nuevo { get; set; }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            nuevo = new Usuario();

            string nuevaPass = txtContraseñaNueva.Text;
            string nuevaPassEncryptada = nuevo.EncriptarPass(nuevaPass);
            

            

        }
    }
}