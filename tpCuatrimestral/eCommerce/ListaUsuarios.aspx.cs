﻿using Clases;
using Conexiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio User = new UsuarioNegocio();
            DVGUsuarios.DataSource = User.ListarL();
            DVGUsuarios.DataBind();
            
        }

        public bool ValidarAdmin()
        {
            Usuario user;
            if (Session["Usuario"] != null)
            {
                user = ((Usuario)Session["Usuario"]);
                return user.EsAdmin;
            }
            return false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool loginNecesario = true;
            Session.Add("loginNecesario", loginNecesario);
            Response.Redirect("User/Login.aspx");
        }
    }
}