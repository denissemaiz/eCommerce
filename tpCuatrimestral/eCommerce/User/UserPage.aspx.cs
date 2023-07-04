using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce.User
{
    public partial class UserPage : System.Web.UI.Page
    {
        public List<string> provincias;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                provincias = new List<string>();
                provincias.Add("Buenos Aires");
                provincias.Add("Ciudad Autónoma de Buenos Aires");
                provincias.Add("Catamarca");
                provincias.Add("Chaco");
                provincias.Add("Chubut");
                provincias.Add("Córdoba");
                provincias.Add("Corrientes");
                provincias.Add("Entre Ríos");
                provincias.Add("Formosa");
                provincias.Add("Jujuy");
                provincias.Add("La Pampa");
                provincias.Add("La Rioja");
                provincias.Add("Mendoza");
                provincias.Add("Misiones");
                provincias.Add("Neuquén");
                provincias.Add("Río Negro");
                provincias.Add("Salta");
                provincias.Add("San Juan");
                provincias.Add("San Luis");
                provincias.Add("Santa Cruz");
                provincias.Add("Santa Fe");
                provincias.Add("Santiago del Estero");
                provincias.Add("Tierra del Fuego");
                provincias.Add("Túcuman");

                drdlProvincias.DataSource = provincias;

                drdlProvincias.DataBind();
            }
        }
    }
}