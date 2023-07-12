using Clases;
using Conexiones;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class PanelUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                string commandArgument = Request.QueryString["Id"];
                if (!string.IsNullOrEmpty(commandArgument))
                {
                    UsuarioNegocio usuario =  new UsuarioNegocio();
                    DatosUsuarioNegocio Datos = new DatosUsuarioNegocio();


                }



            }


        }
    }
}