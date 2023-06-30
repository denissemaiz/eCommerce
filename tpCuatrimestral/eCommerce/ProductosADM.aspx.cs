﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;


namespace eCommerce
{
    public partial class ProductosADM : System.Web.UI.Page
    {

        public List<Libro> ListarLibros { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LibroNegocio negocio = new LibroNegocio();
                ListarLibros = negocio.ListarL();
                Repetidor.DataSource = ListarLibros;
                Repetidor.DataBind();
            }

        }

        protected void btnEliminarLibro_Click(object sender, EventArgs e)
        {
            string idLibro = ((Button)sender).CommandArgument;

            LibroNegocio articulos = new LibroNegocio();
            ListarLibros = articulos.PruebaBuscar(idLibro);

            if (ListarLibros != null)
            {
                LibroNegocio negocio = new LibroNegocio();
                int id = Convert.ToInt32(idLibro);
                negocio.Eliminar(id);
                Response.Redirect("ProductosADM.aspx");
            }
        }
    }
}