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

        public List<Usuario> ListarUsuarios = new List<Usuario>();
        public List<DatosUsuario> ListarDatos = new List<DatosUsuario>();
        public List<Direccion> ListarDirecciones = new List<Direccion>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString.AllKeys.Contains("cod")) 
            {
                string codigo = Request.QueryString["cod"].ToString();
                int code;
                if (int.TryParse(codigo, out code)) 
                {

                    //UsuarioNegocio usuarioss = new UsuarioNegocio();
                    //ListarUsuarios = usuarioss.ListarLPrueba(code);
                    //RepeaterDatos.DataSource = ListarUsuarios;
                    //RepeaterDatos.DataBind();

                }
        
            }
        }
    }
}