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
            if (!IsPostBack && Session["Usuario"] != null)
            {
                user = (Usuario)Session["Usuario"];

                DatosUsuarioNegocio datosUser = new DatosUsuarioNegocio();
                user.DatosUsuario = datosUser.Buscar_x_Usuario(user.Id);
                if (user.DatosUsuario == null)
                    user.DatosUsuario = new DatosUsuario();

                user.DireccionUsuario = new Direccion();
                DireccionNegocio datosDireccion = new DireccionNegocio();
                user.DireccionUsuario = datosDireccion.Buscar(user.DireccionUsuario.Id);

                txbNombres.Text = user.DatosUsuario.Nombres;
                txbApellidos.Text = user.DatosUsuario.Apellidos;
                txbTelefono.Text = user.DatosUsuario.Telefono;
                txbMail.Text = user.Mail;
            }
            else
            {
                if (Session["Usuario"] != null)
                {
                    user = (Usuario)Session["Usuario"];
                    DatosUsuarioNegocio datosUser = new DatosUsuarioNegocio();
                    user.DatosUsuario = datosUser.Buscar_x_Usuario(user.Id);
                    if (user.DatosUsuario == null)
                        user.DatosUsuario = new DatosUsuario();

                    user.DireccionUsuario = new Direccion();
                    DireccionNegocio datosDireccion = new DireccionNegocio();
                    user.DireccionUsuario = datosDireccion.Buscar(user.DireccionUsuario.Id);
                }           
            }
        }

        protected void BtnEditarDatosPersonales_Click(object sender, EventArgs e)
        {
            txbNombres.Enabled = true;
            txbApellidos.Enabled = true;
            txbTelefono.Enabled = true;
            txbMail.Enabled = true;

            BtnEditarDatosPersonales.Enabled = false;
            BtnEditarDatosPersonales.Visible = false;

            btnCancelarEditarDatosPersonales.Enabled = true;
            btnCancelarEditarDatosPersonales.Visible = true;

            btnGuardarDatosPersonales.Enabled = true;
            btnGuardarDatosPersonales.Visible = true;
        }

        protected void btnCancelarEditarDatosPersonales_Click(object sender, EventArgs e)
        {
            txbNombres.Enabled = false;
            txbApellidos.Enabled = false;
            txbTelefono.Enabled = false;
            txbMail.Enabled = false;

            btnCancelarEditarDatosPersonales.Enabled = false;
            btnCancelarEditarDatosPersonales.Visible = false;

            btnGuardarDatosPersonales.Enabled = false;
            btnGuardarDatosPersonales.Visible = false;

            BtnEditarDatosPersonales.Enabled = true;
            BtnEditarDatosPersonales.Visible = true;
        }

        protected void btnGuardarDatosPersonales_Click(object sender, EventArgs e)
        {
            user.DatosUsuario.Nombres = txbNombres.Text.ToString();
            user.DatosUsuario.Apellidos = txbApellidos.Text.ToString(); 
            user.DatosUsuario.Telefono = txbTelefono.Text.ToString();
            user.Mail = txbMail.Text.ToString();
            try
            {
                UsuarioNegocio datos = new UsuarioNegocio();
                datos.Modificar(user);

                DatosUsuarioNegocio datUsuariosDat = new DatosUsuarioNegocio();
                datUsuariosDat.Modificar(user.DatosUsuario);

                txbNombres.Enabled = false;
                txbApellidos.Enabled = false;
                txbTelefono.Enabled = false;
                txbMail.Enabled = false;

                btnCancelarEditarDatosPersonales.Enabled = false;
                btnCancelarEditarDatosPersonales.Visible = false;

                btnGuardarDatosPersonales.Enabled = false;
                btnGuardarDatosPersonales.Visible = false;

                BtnEditarDatosPersonales.Enabled = true;
                BtnEditarDatosPersonales.Visible = true;
            }
            catch (Exception ex)
            {
                string mensaje = ex.ToString();
                Session.Add("error", mensaje);
                Response.Redirect("Error.aspx");
            }
            finally
            {
                Session["Usuario"] = user;
            }
        }

        protected void BtnEditarDireccion_Click(object sender, EventArgs e)
        {

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            txbCalle.Enabled = true; 
            txbAltura.Enabled = true;
            txbLocalidad.Enabled = true;
            txbProvincia.Enabled = true;

            btnCargar.Enabled = false;
            btnCargar.Visible = false;

            BtnEditarDireccion.Enabled = false;
            BtnEditarDireccion.Visible = false;

            user.DireccionUsuario = new Direccion();
            Session["Usuario"] = user;
        }
    }
}