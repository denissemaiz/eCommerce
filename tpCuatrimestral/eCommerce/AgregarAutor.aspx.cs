﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using Conexiones;
using negocio;

namespace eCommerce
{
    public partial class AgregarAutor : System.Web.UI.Page
    {
        Autor autor;
        AutorNegocio autornegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            autor = new Autor();

        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            autor.Nombre = txt_autornombre.Text;
            autor.Apellido = txt_autorapellido.Text;

            autornegocio = new AutorNegocio();

            autornegocio.Agregar(autor);

        }
    }
}