using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class ModificarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                txtID.Enabled = false;


        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void txtportadaURL_TextChanged(object sender, EventArgs e)
        {
            ImgPortada.ImageUrl = txtportadaURL.Text;
        }
    }
}