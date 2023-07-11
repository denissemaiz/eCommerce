using Conexiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio User = new UsuarioNegocio();
            DVGUsuarios.DataSource = User.ListarL();
            DVGUsuarios.DataBind();

        }
    }
}