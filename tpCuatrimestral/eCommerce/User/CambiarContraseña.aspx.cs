using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce.User
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        public Usuario user { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Usuario"] != null)
                user = (Usuario)Session["Usuario"];
                
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string contraseñaActual = user.EncriptarPass(txbContraseñaActual.Text);

            if(user.Contraseña == contraseñaActual)
            {

            }
            else
            {
                lblErrorCoincidencia.Visible = true;
                lblErrorCoincidencia.Text = "Contraseña ingresada no coincide con la contraseña actual";
                return;
            }
        }

    }
}