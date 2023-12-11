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

namespace eCommerce
{
    public partial class DetallesCompra2 : System.Web.UI.Page
    {
        public Compra pedido { get; set; }
        public Direccion direccion {  get; set; }
        public Usuario cliente { get; set; }
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idPedido = Convert.ToInt32(Request.QueryString["idCompra"]);//Consigo el id de pedido de la URL

                CompraNegocio negocioCompra = new CompraNegocio();
                LibroNegocio negocioLibro = new LibroNegocio();
                List<Libro> libros = new List<Libro>();
                List<string> estados = new List<string>();
                estados.Add("En proceso");
                estados.Add("Enviado");
                estados.Add("Completado");
                estados.Add("Cancelado");

                try
                {
                    pedido = negocioCompra.BuscarCompra(idPedido); //Busco la compra x ID
                    if(pedido != null) //Validación de que se encuentre la compra
                    {
                        //Asignación de datos de la compra
                        lblCodigoCompra.Text = pedido.Id.ToString();
                        lblFechaCompra.Text = pedido.FechaCompra.ToString();
                        lblEstado.Text = pedido.Estado.ToString();
                        txtEstadoCompra.DataSource = estados;
                        txtEstadoCompra.DataBind();
                        
                        //Consigo la direccion del pedido
                        DireccionNegocio direccionNegocio = new DireccionNegocio();
                        direccion = direccionNegocio.Buscar_X_Compra(pedido.Id);
                        if(direccion != null)
                        {
                            //Y si se encuentra la asigno a los respectivos labels
                            lblDireccion.Text = direccion.Calle;
                            lblCiudad.Text = direccion.Localidad;
                            lblProvincia.Text = direccion.Provincia;
                            lblCp.Text = direccion.Cp.ToString();
                        }

                        //Lista de cadenas para mostrar los libros vendidos y la cantidad vendida
                        List<String> productos = new List<String>();
                        libros = negocioLibro.RemoveDuplicadosLibro(pedido.Carrito.Libros);
                            
                        foreach (Libro libro in libros)
                        {
                            //Por cada libro en el listado de libros genero una cadena con el código de libro, el título y
                            //la cantidad que se vendió de ese libro
                            productos.Add(libro.ToString() + 
                                "  ........  X" + pedido.Carrito.contabilizarLibro(libro.Id).ToString() );
                        }
                        lbxProductos.DataSource = productos;
                        lbxProductos.DataBind();

                        lblMonto.Text = pedido.Carrito.CalcularMonto().ToString();
                       

                        //Valido que haya un usuario logueado y que su ID de usuario no sea igual al ID del cliente del pedido
                        if (Session["cliente"] != null && ((Usuario)Session["cliente"]).Id == pedido.IdCliente)
                        {
                            //En caso de coincidir el ID del usuario con el del cliente, obtengo directamente el usuario de la sesión
                            //en vez de buscarlo.
                            cliente = (Usuario)Session["cliente"];

                            //Consigo sus datos personales
                            DatosUsuarioNegocio datoscliente = new DatosUsuarioNegocio();
                            cliente.DatosUsuario = datoscliente.Buscar_x_Usuario(cliente.Id);
                            if (cliente.DatosUsuario == null)
                                cliente.DatosUsuario = new DatosUsuario();

                            //Los asigno a los labels
                            lblNombre.Text = cliente.DatosUsuario.Nombres + " " + cliente.DatosUsuario.apellidos;
                            lblEmail.Text = cliente.Mail;
                            lblTelefono.Text = cliente.DatosUsuario.Telefono;

                            //Consigo su dirección
                            //cliente.DireccionUsuario = new Direccion();
                            //DireccionNegocio datosDireccion = new DireccionNegocio();
                            ////cliente.DireccionUsuario = datosDireccion.Buscar(cliente.);
                            //if (cliente.DireccionUsuario == null)
                            //    cliente.DireccionUsuario = new Direccion();

                            
                        }
                        else
                        {
                            //En caso de no coincidir el ID del usuario con el del cliente busco el cliente del pedido a través del
                            //ID de Usuario
                            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                            cliente = usuarioNegocio.buscarUsuario_x_Id(pedido.IdCliente);
                            if (cliente != null)
                            {

                                //Y si se encuentra ya busco su dirección y datos personales y los asigno a los labels
                                DatosUsuarioNegocio datoscliente = new DatosUsuarioNegocio();
                                cliente.DatosUsuario = datoscliente.Buscar_x_Usuario(cliente.Id);
                                if (cliente.DatosUsuario == null)
                                    cliente.DatosUsuario = new DatosUsuario();

                                lblNombre.Text = cliente.DatosUsuario.Nombres + " " + cliente.DatosUsuario.apellidos;
                                lblEmail.Text = cliente.Mail;
                                lblTelefono.Text = cliente.DatosUsuario.Telefono;

                                //cliente.DireccionUsuario = new Direccion();
                                //DireccionNegocio datosDireccion = new DireccionNegocio();
                                //cliente.DireccionUsuario = datosDireccion.Buscar(cliente.Id);
                                //if (cliente.DireccionUsuario == null)
                                //    cliente.DireccionUsuario = new Direccion();

                                //lblDireccion.Text = cliente.DireccionUsuario.Calle;
                                //lblCiudad.Text = cliente.DireccionUsuario.Localidad;
                                //lblProvincia.Text = cliente.DireccionUsuario.Provincia;
                                //lblCp.Text = cliente.DireccionUsuario.Cp.ToString();
                                
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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Panelusuario.aspx", false);
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

        protected void BtonGuardar_Click(object sender, EventArgs e)
        {
            CompraNegocio negocio = new CompraNegocio();
            int idPedido = Convert.ToInt32(Request.QueryString["idCompra"]);

            int idEstado = txtEstadoCompra.SelectedIndex + 1;
            try
            {
                negocio.ModificarEstado(idEstado, idPedido);
                lblEstado.Text = txtEstadoCompra.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../Error.aspx", false);
            }

        }
    }
}