using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using Conexiones;
using eCommerce.User;

namespace eCommerce
{
    public partial class DetallesCompra2 : System.Web.UI.Page
    {
        public Compra pedido = new Compra();
        public Usuario cliente = new Usuario();

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
                        //if (Session["user"] != null && ((Usuario)Session["user"]).Id == pedido.IdCliente )
                        //{
                        //    cliente = (Usuario)Session["user"];
                        //}
                        //else{
                        //    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                        //    cliente = usuarioNegocio.buscarUsuario_x_Id(pedido.IdCliente);
                        //    if( cliente != null)
                        //    {
                        //        DatosUsuarioNegocio datosUser = new DatosUsuarioNegocio();
                        //        cliente.DatosUsuario = datosUser.Buscar_x_Usuario(cliente.Id);
                        //        if (cliente.DatosUsuario == null)
                        //            cliente.DatosUsuario = new DatosUsuario();

                        //        cliente.DireccionUsuario = new Direccion();
                        //        DireccionNegocio datosDireccion = new DireccionNegocio();
                        //        cliente.DireccionUsuario = datosDireccion.Buscar(cliente.Id);
                        //    }
                        //    else
                        //    {
                        //        Session.Add("error", "No se encontró un cliente relacionado a este pedido");
                        //        Response.Redirect("../Error.aspx", false);
                        //    }
                        //}

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