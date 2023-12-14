using Conexiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class ReporteVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CompraNegocio compraNegocio = new CompraNegocio();
                dgVentas.DataSource = compraNegocio.ReporteVentas_x_MesAnio();
                dgVentas.DataBind();

            }
        }
    }
}