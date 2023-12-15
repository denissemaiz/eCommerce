using Conexiones;
using System;
using System.Collections.Generic;
using System.Data;
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
                try
                {
                    CompraNegocio compraNegocio = new CompraNegocio();                
                    DataTable dt = new DataTable();

                    dt = compraNegocio.ReporteVentas_x_MesAnio();

                    decimal montoTotal = 0;

                    foreach (DataRow row  in dt.Rows)
                    {
                        montoTotal += Decimal.Round(Convert.ToDecimal(row["MontoTotalMes"]), 2 );
                    }

                    lblMontoTotal.Text = montoTotal.ToString();

                    dgVentas.DataSource = dt;
                    dgVentas.DataBind();

                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                    
                }
            }
        }
    }
}