using Clases;
using Conexiones;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce
{
    public partial class PanelUsuario : System.Web.UI.Page
    {

        public Usuario user;
        //public List<DatosUsuario> ListarDatos;
        //public Direccion direccion;

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Request.QueryString.AllKeys.Contains("cod")) 
            //{
            //    string codigo = Request.QueryString["cod"].ToString();
            //    int code;
            //    if (int.TryParse(codigo, out code)) 
            //    {

            //        UsuarioNegocio usuarioss = new UsuarioNegocio();
            //        ListarUsuarios = usuarioss.ListarLPrueba(code);
            //        RepeaterDatos.DataSource = ListarUsuarios;
            //        RepeaterDatos.DataBind();

            //    }
        
            //}
            if(!IsPostBack && Session["Usuario"] != null)
            {
               user = (Usuario)Session["Usuario"];
                
                DatosUsuarioNegocio datosUser = new DatosUsuarioNegocio();
                user.DatosUsuario = datosUser.Buscar_x_Usuario(user.Id);
                if(user.DatosUsuario == null)
                    user.DatosUsuario= new DatosUsuario();

                user.DireccionUsuario = new Direccion();
                DireccionNegocio datosDireccion = new DireccionNegocio();
                user.DireccionUsuario = datosDireccion.Buscar(user.DireccionUsuario.Id);
                //if(user.DireccionUsuario == null)
                //    user.DireccionUsuario = new Direccion();

            }
        }
    }
}