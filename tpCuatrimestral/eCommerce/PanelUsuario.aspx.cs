using Clases;
using Conexiones;
using dominio;
using negocio;
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
                user.DireccionUsuario = datosDireccion.Buscar_X_Usuario(user.Id);

                txbNombres.Text = user.DatosUsuario.Nombres;
                txbApellidos.Text = user.DatosUsuario.Apellidos;
                txbTelefono.Text = user.DatosUsuario.Telefono;
                txbMail.Text = user.Mail;

                if(user.DireccionUsuario != null)
                {
                    txbCalle.Text = user.DireccionUsuario.Calle;
                    txbAltura.Text = user.DireccionUsuario.Altura.ToString();
                    txbLocalidad.Text = user.DireccionUsuario.Localidad;
                    txbCp.Text = user.DireccionUsuario.Cp.ToString();
                    txbProvincia.Text = user.DireccionUsuario.Provincia.ToString();
                }
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
                    user.DireccionUsuario = datosDireccion.Buscar_X_Usuario(user.Id);
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

            btnCambiarPass.Enabled = false;
            btnCambiarPass.Visible = false;

            btnCancelarEditarDatosPersonales.Enabled = true;
            btnCancelarEditarDatosPersonales.Visible = true;

            btnGuardarDatosPersonales.Enabled = true;
            btnGuardarDatosPersonales.Visible = true;
        }

        protected void btnCancelarEditarDatosPersonales_Click(object sender, EventArgs e)
        {
            if (txbMail.Text == "")
                txbMail.Text = user.Mail;
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

            btnCambiarPass.Enabled = true;
            btnCambiarPass.Visible = true;
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

                btnCambiarPass.Enabled = true;
                btnCambiarPass.Visible = true;
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
            txbCalle.Enabled = true;
            txbAltura.Enabled = true;
            txbLocalidad.Enabled = true;
            txbCp.Enabled = true;
            txbProvincia.Enabled = true;

            btnCancelarEdicionDire.Enabled = true;
            btnCancelarEdicionDire.Visible = true;

            btnGuardarDireccion.Enabled = true;
            btnGuardarDireccion.Visible = true;

            BtnEditarDireccion.Enabled = false;
            BtnEditarDireccion.Visible = false;
            
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            txbCalle.Enabled = true; 
            txbAltura.Enabled = true;
            txbLocalidad.Enabled = true;
            txbCp.Enabled = true;
            txbProvincia.Enabled = true;

            btnCancelarEdicionDire.Enabled = true;
            btnCancelarEdicionDire.Visible = true;

            btnGuardarDireccion.Enabled = true;
            btnGuardarDireccion.Visible = true;

            btnCargar.Enabled = false;
            btnCargar.Visible = false;

            BtnEditarDireccion.Enabled = false;
            BtnEditarDireccion.Visible = false;

            user.DireccionUsuario = new Direccion();
            Session["Usuario"] = user;
        }

        protected void btnCancelarEdicionDire_Click(object sender, EventArgs e)
        {
            if(user.DireccionUsuario == null || user.DireccionUsuario.Id == 0)
            {
                btnGuardarDireccion.Enabled = false;
                btnGuardarDireccion.Visible = false;

                btnCancelarEdicionDire.Enabled = false;
                btnCancelarEdicionDire.Visible = false;

                btnCargar.Enabled = true;
                btnCargar.Visible = true;

                user.DireccionUsuario = null;
                Session["Usuario"] = user;
            }
            else
            {
                txbCalle.Text = user.DireccionUsuario.Calle;
                txbAltura.Text = user.DireccionUsuario.Altura.ToString();
                txbLocalidad.Text = user.DireccionUsuario.Localidad;
                txbCp.Text = user.DireccionUsuario.Cp.ToString();
                txbProvincia.Text = user.DireccionUsuario.Provincia.ToString();

                btnGuardarDireccion.Enabled = false;
                btnGuardarDireccion.Visible = false;

                btnCancelarEdicionDire.Enabled = false;
                btnCancelarEdicionDire.Visible = false;

                BtnEditarDireccion.Enabled = true;
                BtnEditarDireccion.Visible = true;
            }
        }

        protected void btnGuardarDireccion_Click(object sender, EventArgs e)
        {
            DireccionNegocio dire = new DireccionNegocio();
            if(user.DireccionUsuario == null)
            {
                user.DireccionUsuario = new Direccion();
                user.DireccionUsuario.Id = user.Id;
                user.DireccionUsuario.Calle = txbCalle.Text.ToString();
                user.DireccionUsuario.Altura = int.Parse(txbAltura.Text);
                user.DireccionUsuario.Localidad = txbLocalidad.Text.ToString();
                user.DireccionUsuario.Provincia = txbProvincia.Text.ToString();
                user.DireccionUsuario.Cp = int.Parse(txbCp.Text.ToString());

                try
                {
                    dire.NuevaDireccion_Usuario(user.DireccionUsuario, user.Id);
                    Session["Usuario"] = user;
                }
                catch (Exception ex)
                {
                    Session["error"] = ex.ToString();
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                user.DireccionUsuario.Calle = txbCalle.Text.ToString();
                user.DireccionUsuario.Altura = int.Parse(txbAltura.Text);
                user.DireccionUsuario.Localidad = txbLocalidad.Text.ToString();
                user.DireccionUsuario.Provincia = txbProvincia.Text.ToString();
                user.DireccionUsuario.Cp = int.Parse(txbCp.Text.ToString());
                try
                {
                    dire.Modificar(user.DireccionUsuario);
                    Session["Usuario"] = user;
                }
                catch (Exception ex)
                {
                    Session["error"] = ex.ToString();
                    Response.Redirect("Error.aspx");
                }
            }
            txbCalle.Enabled = false;
            txbAltura.Enabled = false;
            txbLocalidad.Enabled = false;
            txbCp.Enabled = false;
            txbProvincia.Enabled = false;

            btnGuardarDireccion.Enabled = false;
            btnGuardarDireccion.Visible = false;

            btnCancelarEdicionDire.Enabled = false;
            btnCancelarEdicionDire.Visible = false;

            BtnEditarDireccion.Enabled = true;
            BtnEditarDireccion.Visible = true;
        }

        protected void BtonCambiarContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User/CambiarContraseña.aspx", false);
        }

        protected void DGVPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)DGVPedidos.SelectedValue;
            CompraNegocio negocioComp = new CompraNegocio();
            LibroNegocio negocioLib = new LibroNegocio();

            if (negocioComp.BuscarCompra(id).Estado.Equals("En proceso"))
            {
                negocioComp.ModificarEstado(4, id);
                Compra compra = negocioComp.BuscarCompra(id);
                negocioLib.SumarStock(compra);
                Response.Redirect("PanelUsuario.aspx");
            }
            else
            {
                //Agregar mensaje de error
                Response.Redirect("PanelUsuario.aspx");
            }
        }

        protected void DGVPedidos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            DGVPedidos.PageIndex = e.NewSelectedIndex;
            DGVPedidos.DataBind();
        }

        protected void DGVPedidos_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                user = (Usuario)Session["Usuario"];
                CompraNegocio negocio = new CompraNegocio();
                if (user.EsAdmin)
                {
                    List<Compra> listaCompra = negocio.Listar();
                    /*foreach (Compra comp in listaCompra)
                    {                        
                        string fechaFormateada = comp.FechaCompra.ToString("dd/MM/yyyy");
                        comp.FechaCompra = fechaFormateada;
                    }*/

                    DGVPedidos.DataSource = negocio.Listar();
                    DGVPedidos.DataBind();
                }
                else
                {
                    DGVPedidos.DataSource = negocio.Listar(user.Id);
                    DGVPedidos.DataBind();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginNecesario = HttpContext.Current.Request.Url.AbsolutePath;
            Session.Add("loginNecesario", loginNecesario);
            if (Session["Usuario"] != null)
                Session.Remove("Usuario");

            Response.Redirect("User/Login.aspx");
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

        protected void DGVPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = DataBinder.Eval(e.Row.DataItem, "Estado").ToString();

                LinkButton selectButton = (LinkButton)e.Row.Cells[4].Controls[0];

                if (estado == "En proceso")
                {
                    selectButton.Text = "Cancelar";
                }
                else
                {
                    selectButton.Text = "";
                }

                if (selectButton != null)
                {
                    string confirmScript = "return confirm('¿Estás seguro? Esta acción cancelará la compra.');";
                    selectButton.Attributes.Add("onclick", confirmScript);
                }
            }
        }

        protected void DGVPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVPedidos.PageIndex = e.NewPageIndex;
            DGVPedidos.DataBind();
        }
    }
}