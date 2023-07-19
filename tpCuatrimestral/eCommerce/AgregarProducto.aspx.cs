using System;
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
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            txtID.Enabled = false;


            try
            {
                if (!IsPostBack)
                {
                    GeneroNegocio Gene = new GeneroNegocio();
                    List<Genero> lista = Gene.Listar();
                    AutorNegocio Autor = new AutorNegocio();
                    List<Autor> lista2 = Autor.Listar();

                    txtGenero.DataSource = lista;
                    txtGenero.DataValueField = "Id";
                    txtGenero.DataTextField = "Nombre";
                    txtGenero.DataBind();
                    txtGenero.Items.Insert(0, new ListItem("--Vacío--", "NA"));

                    txtAutorNombre.DataSource = lista2;
                    txtAutorNombre.DataValueField = "Id";
                    txtAutorNombre.DataTextField = "NombreApellido";
                    txtAutorNombre.DataBind();
                    txtAutorNombre.Items.Insert(0, new ListItem("--Vacío--", "NA"));


                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }





            string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

            if (Id != "" && !IsPostBack)
            {
                LibroNegocio neg = new LibroNegocio();
                Libro seleccionado = (neg.BuscarTest(Id))[0];

                txtID.Text = Id;
                txtCodigo.Text = seleccionado.Codigo;
                txtTitulo.Text = seleccionado.Titulo;
                txtDescripcion.Text = seleccionado.Descripcion;
                txtStock.Text = seleccionado.Stock.ToString();
                txtPrecio.Text = seleccionado.Precio.ToString();
                txtportadaURL.Text = seleccionado.PortadaURL.ToString();
                txtAutorNombre.Text = seleccionado.Autores.ToString();
                txtGenero.Text = seleccionado.Generos.ToString();

                txtportadaURL_TextChanged(sender, e);


            }

        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Libro libro = new Libro();
                LibroNegocio negocio = new LibroNegocio();
                Genero genero = new Genero();
                Autor autor = new Autor();

                libro.Codigo = txtCodigo.Text;
                libro.Titulo = txtTitulo.Text;
                libro.Descripcion = txtDescripcion.Text;
                libro.Precio = decimal.Parse(txtPrecio.Text);
                libro.Stock = short.Parse(txtStock.Text);
                libro.PortadaURL = txtportadaURL.Text;
                autor.Id = int.Parse(txtAutorNombre.SelectedValue);
                genero.Id = int.Parse(txtGenero.SelectedValue);
                libro.Generos = new List<Genero>();
                libro.Generos.Add(genero);
                libro.Autores = new List<Autor>();
                libro.Autores.Add(autor);  

                

                if (Request.QueryString["Id"] != null) 
                {
                    libro.Id = int.Parse(txtID.Text);
                    negocio.Modificar(libro);
                    /*Response.Redirect("StoreProc.aspx", false);*/
                    Response.Redirect("Productos.aspx");
                }
                else
                {
                    negocio.Agregar(libro);
                    Response.Redirect("Productos.aspx");
                }

                
            }
            catch (Exception ex)
            {
                Session.Add("Fallo al agregar", ex);
                throw;
            }


        


        }

        protected void txtportadaURL_TextChanged(object sender, EventArgs e)
        {
            ImgPortada.ImageUrl = txtportadaURL.Text;
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
    }
}