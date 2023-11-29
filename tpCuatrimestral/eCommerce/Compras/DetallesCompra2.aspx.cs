using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using Conexiones;

namespace eCommerce
{
    public partial class DetallesCompra2 : System.Web.UI.Page
    {
        public Compra pedido;
        public Usuario cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idPedido = Convert.ToInt32(Request.QueryString["idCompra"]);

                CompraNegocio negocio = new CompraNegocio();
                try
                {
                    pedido = negocio.BuscarCompra(idPedido);
                    if(pedido != null) 
                    {
                        if (Session["cliente"] != null && ((Usuario)Session["cliente"]).Id == pedido.IdCliente)
                        {
                            cliente = (Usuario)Session["cliente"];
                        }
                        else
                        {
                            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                            cliente = usuarioNegocio.buscarUsuario_x_Id(pedido.IdCliente);
                            if (cliente != null)
                            {


                                DatosUsuarioNegocio datoscliente = new DatosUsuarioNegocio();
                                cliente.DatosUsuario = datoscliente.Buscar_x_Usuario(cliente.Id);
                                if (cliente.DatosUsuario == null)
                                    cliente.DatosUsuario = new DatosUsuario();

                                lblNombre.Text = cliente.DatosUsuario.Nombres + " " + cliente.DatosUsuario.apellidos;
                                lblEmail.Text = cliente.Mail;
                                lblTelefono.Text = cliente.DatosUsuario.Telefono;

                                cliente.DireccionUsuario = new Direccion();
                                DireccionNegocio datosDireccion = new DireccionNegocio();
                                cliente.DireccionUsuario = datosDireccion.Buscar(cliente.Id);
                                if (cliente.DireccionUsuario == null)
                                    cliente.DireccionUsuario = new Direccion();

                                lblDireccion.Text = cliente.DireccionUsuario.Calle;
                                lblCiudad.Text = cliente.DireccionUsuario.Localidad;
                                lblProvincia.Text = cliente.DireccionUsuario.Provincia;
                                lblCp.Text = cliente.DireccionUsuario.Cp.ToString();
                                
                            }
                            else
                            {
                                Session.Add("error", "No se encontró un cliente relacionado a este pedido");
                                Response.Redirect("../Error.aspx", false);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}