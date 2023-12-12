using Clases;
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
            DVGUsuarios.DataSource = User.Listar();
            DVGUsuarios.DataBind();
            
        }

        public bool ValidarAdmin()
        {
            Usuario user;
            if (Session["Usuario"] != null)
            {
                user = ((Usuario)Session["Usuario"]);
                return user.EsAdmin;
            }
            return false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginNecesario = HttpContext.Current.Request.Url.AbsolutePath;
            Session.Add("loginNecesario", loginNecesario);
            if (Session["Usuario"] != null)
                Session.Remove("Usuario");

            Response.Redirect("User/Login.aspx");
        }

        protected void DVGUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DVGUsuarios.PageIndex = e.NewPageIndex;
            DVGUsuarios.DataBind();
        }
    }
}