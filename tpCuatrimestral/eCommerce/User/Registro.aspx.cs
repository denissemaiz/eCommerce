﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using Conexiones;
using dominio;
using negocio;

namespace eCommerce.User
{
    public partial class Registro : System.Web.UI.Page
    {
        Usuario usuario;
        DatosUsuario datosUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = new Usuario();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            UsuarioNegocio datos = new UsuarioNegocio();

            usuario.Username = txtUser.Text;
            usuario.Contraseña = txtPass.Text;
            usuario.Mail = txtEmail.Text;
            usuario.EsAdmin = false;

            

            if (usuario.ConfirmarContraseña(txtConfPass.Text))
            {
                int id = 0;
                usuario.Contraseña = usuario.EncriptarPass(usuario.Contraseña);
                if(datos.Registro(usuario,ref mensaje, ref id))
                {

                    datosUser = new DatosUsuario(id, txtNombre.Text, txtApellido.Text, txtTelefono.Text);


                    Session.Add("mensaje", mensaje);
                    Response.Redirect("../Default.aspx");
                }
                else
                {
                    Session.Add("error", mensaje);
                    Response.Redirect("../Error.aspx");
                }
            }
        }
    }
}