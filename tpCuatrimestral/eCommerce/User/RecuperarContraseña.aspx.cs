﻿using System;
using Clases;
using Conexiones;
using dominio;
using negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace eCommerce.User
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string Nuevapass = txtContraseñaNueva.Text;
            string Confirmarpass = txtContraseñaNuevaConfirmar.Text;
            UsuarioNegocio usuario = new UsuarioNegocio();

            

            if(Nuevapass == Confirmarpass) 
            {
                usuario.NuevaContraseña(Nuevapass);
                
            }
            else 
            { 
            
            
            
            }

        }
    }
}