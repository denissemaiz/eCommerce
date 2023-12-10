using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mensaje"] != null)
            {
                lblMensaje.Text = Session["mensaje"].ToString();
                Session.Remove("mensaje");
            }
            else
                Response.Redirect("Default.aspx");
        }
    }
}