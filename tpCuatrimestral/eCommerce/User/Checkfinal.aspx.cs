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
                else
                {
                    Session.Add("error", "Carrito vacío, se deben agregar productos antes de ingresar al CheckFinal");
                    Response.Redirect("../Error.aspx", false); 
                    return;
                }
               
                //Consigo al usuario para recuperar sus datos de la BD
                if (Session["Usuario"] != null)
                {
                    usuario = (Usuario)Session["Usuario"];
                    usuario.DireccionUsuario = null;
                }


            }
            else
            {
                if(carrito == null && Session["librosAgregados"] != null)
                {
                    carrito = new Carrito();
                    carrito.Libros = (List<Libro>)Session["librosAgregados"];
                }

                if (usuario == null && Session["Usuario"] != null)
                {
                    usuario = (Usuario)Session["Usuario"];
                    usuario.DireccionUsuario = null;
                }

            }
            
        }
        protected void lbtnUsarMiDireccion_Click(object sender, EventArgs e)
        {
            DireccionNegocio direccionNegocio = new DireccionNegocio();
            usuario.DireccionUsuario = new Direccion();
            usuario.DireccionUsuario = direccionNegocio.Buscar_X_Usuario(usuario.Id);
            if(usuario.DireccionUsuario != null)
            {
                txtDireccion.Text = usuario.DireccionUsuario.Calle;
                txtDireccion.DataBind();
                txtDireccion.Enabled = false;

                txtAltura.Text = usuario.DireccionUsuario.Altura.ToString();
                txtAltura.DataBind();
                txtAltura.Enabled = false;

                txtCiudad.Text = usuario.DireccionUsuario.Localidad;
                txtCiudad.DataBind();
                txtCiudad.Enabled = false;

                txtProvincia.Text = usuario.DireccionUsuario.Provincia;
                txtProvincia.DataBind();
                txtProvincia.Enabled = false; 

                txtCp.Text = usuario.DireccionUsuario.Cp.ToString();
                txtCp.DataBind();
                txtCp.Enabled = false;
            }
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            Compra compra = new Compra();
            try
            {
                CompraNegocio compraNeg = new CompraNegocio();

                compra.Carrito = carrito;
                compra.IdCliente = usuario.Id;
                compra.FechaCompra = DateTime.Today;
                

                int idInsert = compraNeg.Agregar(compra);
                if(idInsert > 0)
                {
                    DireccionNegocio direNegocio = new DireccionNegocio();
                    if(usuario.DireccionUsuario != null)
                        direNegocio.Agregar_a_Compra(usuario.DireccionUsuario.Id, idInsert);
                    else
                    {
                        Direccion direccion = new Direccion();

                        direccion.Altura = Int32.Parse(txtAltura.Text);
                        direccion.Calle = txtDireccion.Text;
                        direccion.Localidad = txtCiudad.Text;
                        direccion.Provincia = txtProvincia.Text;
                        direccion.Cp = Int32.Parse(txtCp.Text);

                        direNegocio.NuevaDireccion_Compra(direccion, idInsert);

                        Session.Remove("librosAgregados");
                    }
                }
                else
                {
                    Session.Add("error", "Error al cargar la compra");
                    Response.Redirect("../Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../Error.aspx", false);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginNecesario = HttpContext.Current.Request.Url.AbsolutePath;
            Session.Add("loginNecesario", loginNecesario);
            if (Session["Usuario"] != null)
                Session.Remove("Usuario");

            Response.Redirect("../User/Login.aspx");
        }
    }
}