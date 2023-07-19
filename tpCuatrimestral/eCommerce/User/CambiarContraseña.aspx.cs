using Clases;
using Conexiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce.User
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        public Usuario user { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Usuario"] != null || user == null && Session["Usuario"] != null)
                user = (Usuario)Session["Usuario"];  
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string contraseñaActual = user.EncriptarPass(txbContraseñaActual.Text);
            string nuevaContraseña = user.EncriptarPass(txbContraseñaNueva.Text);

            if(user.Contraseña == contraseñaActual)
            {
                user.Contraseña = nuevaContraseña;
                try
                {
                    UsuarioNegocio userDat = new UsuarioNegocio();
                    userDat.Modificar(user);
                    Session["Usuario"] = user;
                    Response.Redirect("../PanelUsuario.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("../Error.aspx");
                }
            }
            else
            {
                return;
            }
        }

    }
}