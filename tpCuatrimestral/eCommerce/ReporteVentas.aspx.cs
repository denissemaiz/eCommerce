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

        protected void dgVentas_Sorting(object sender, GridViewSortEventArgs e)
        {
            
            int anio = 2023; 
            string columnaOrderBy = e.SortExpression; //Obtengo la expresión para el ordenamiento
            string orderBy = DireccionDeOrdenamiento(e.SortExpression);

            CompraNegocio compraNegocio = new CompraNegocio();
            DataTable dtVentas = compraNegocio.ReporteVentas_x_MesAnio(anio, columnaOrderBy, orderBy);

            // Actualizo el DataSource del GridView
            dgVentas.DataSource = dtVentas;
            dgVentas.DataBind();
        }
        protected void btnBuscarAnio_Click(object sender, EventArgs e)
        {
            int anio = Int32.Parse(txtAnio.Text);
            string columnaOrderBy = dgVentas.SortExpression;
            string orderBy = DireccionDeOrdenamiento(dgVentas.SortExpression);

            CompraNegocio compraNegocio = new CompraNegocio();
            DataTable dtVentas = compraNegocio.ReporteVentas_x_MesAnio(anio, columnaOrderBy, orderBy);

            dgVentas.DataSource = dtVentas;
            dgVentas.DataBind();
        }

        private string DireccionDeOrdenamiento(string column)
        {
            // Obtengo la direccion de ordenamiento
            string direccionOrdenamiento = "ASC";
            string expresionOrdenamiento = ViewState["SortExpression"] as string;

            if (expresionOrdenamiento != null)
            {
                // Si la columna actual quedaría igual que la anterior invierto la dirección
                if (expresionOrdenamiento == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        direccionOrdenamiento = "DESC";
                    }
                }
            }

            // Guardo la columna y dirección actual en el ViewState
            ViewState["SortExpression"] = column;
            ViewState["SortDirection"] = direccionOrdenamiento;

            return direccionOrdenamiento;
        }

    }
}