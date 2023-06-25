using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce.User
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                try
                {
                    Session["Usuario"] = null;
                    Session.Clear();
                    Response.Cookies.Clear();
                    Response.Redirect("../Default.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("../Error.aspx", false);
                }
            }
            else
            {
                Session.Add("error", "Usted no se encuentra logueado");
                Response.Redirect("../Error.aspx", false);
            }
        }
    }
}