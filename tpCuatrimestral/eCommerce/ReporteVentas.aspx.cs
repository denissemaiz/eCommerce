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
            // Obtener el DataTable ordenado
            int anio = 2023; // Asigna el valor adecuado para el año
            string columnaOrderBy = e.SortExpression;
            string orderBy = GetSortDirection(e.SortExpression);

            CompraNegocio compraNegocio = new CompraNegocio();
            DataTable dtVentas = compraNegocio.ReporteVentas_x_MesAnio(anio, columnaOrderBy, orderBy);

            // Volver a vincular el GridView con el DataTable ordenado
            dgVentas.DataSource = dtVentas;
            dgVentas.DataBind();
        }

        private string GetSortDirection(string column)
        {
            // Obtener la dirección actual de la ordenación
            string sortDirection = "ASC";
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Si la columna actual es la misma que la columna anterior, invertir la dirección
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Guardar la columna y dirección actual en ViewState
            ViewState["SortExpression"] = column;
            ViewState["SortDirection"] = sortDirection;

            return sortDirection;
        }
    }
}