using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using dominio;
using negocio;

namespace eCommerce
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            txtID.Enabled = false;  


        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Libro libro = new Libro();
                LibroNegocio negocio = new LibroNegocio();

                libro.Codigo = txtCodigo.Text;
                libro.Titulo = txtTitulo.Text;
                libro.Descripcion = txtDescripcion.Text;
                libro.Precio = decimal.Parse(txtPrecio.Text);
                libro.Stock = int.Parse(txtStock.Text);

                negocio.Agregar(libro);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Fallo al agregar", ex);
                throw;
            }
        }
    }
}