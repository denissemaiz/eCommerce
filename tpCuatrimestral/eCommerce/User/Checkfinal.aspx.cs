using Clases;
using Conexiones;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce.User
{
    public partial class Checkfinal : System.Web.UI.Page
    {
        //Propiedades pagina
        public Carrito carrito { get; set; }
        public Usuario usuario { get; set; }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            LibroNegocio libroNegocio = new LibroNegocio();
            if (!IsPostBack || Session["librosAgregados"] != null && carrito == null)
            {
                carrito = new Carrito();
                //Consigo los datos de la compra
                if (Session["librosAgregados"] != null)                
                    carrito.Libros = (List<Libro>)Session["librosAgregados"];
                //Consigo al usuario para recuperar sus datos de la BD
                if (Session["User"] != null)
                {
                    usuario = (Usuario)Session["User"];

                    DireccionNegocio direccionNegocio = new DireccionNegocio();
                    usuario.DireccionUsuario = direccionNegocio.Buscar(usuario.DireccionUsuario.Id);
                    
                }

            }
            else
            {
                if (Session["librosAgregados"] != null)
                    carrito.Libros = (List<Libro>)Session["librosAgregados"];                
            }
        }


    }
}