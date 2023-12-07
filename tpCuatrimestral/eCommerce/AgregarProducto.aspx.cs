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
        public Libro libro;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;


            try
            {
                if (!IsPostBack)
                {
                    libro = new Libro();
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

                    Session.Add("libro", libro);

                }
                else if (libro == null)
                    if (Session["Libro"] != null)
                        libro = (Libro)Session["Libro"];
                    else
                        libro = new Libro();
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
                libro = neg.Buscar_X_Id(Id); //Busco el libro X ID

                txtID.Text = Id;
                txtCodigo.Text = libro.Codigo;
                txtTitulo.Text = libro.Titulo;
                txtDescripcion.Text = libro.Descripcion;
                txtStock.Text = libro.Stock.ToString();
                txtPrecio.Text = libro.Precio.ToString();
                txtportadaURL.Text = libro.PortadaURL.ToString();

                //Remuevo del listbox Genero los generos que se traen de la BD
                foreach (Genero genero in libro.Generos)
                {
                    ListItem itemToRemove = txtGenero.Items.FindByValue(genero.Id.ToString());
                    if (itemToRemove != null)
                        txtGenero.Items.Remove(itemToRemove);
                    
                }

                //Remuevo del listbox Autor los Autores que se traen de la BD
                foreach (Autor autor in libro.Autores)
                {
                    ListItem itemToRemove = txtAutorNombre.Items.FindByValue(autor.Id.ToString());
                    if (itemToRemove != null)
                        txtAutorNombre.Items.Remove(itemToRemove);

                }

                //txtGenero.Text = seleccionado.Generos.ToString();

                lbxAutores.DataSource = libro.Autores;
                lbxAutores.DataBind();
                lbxGeneros.DataSource = libro.Generos;
                lbxGeneros.DataBind(); 

                

                txtportadaURL_TextChanged(sender, e);

                Session["Libro"] = libro;

            }

        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Libro libro = new Libro();
                LibroNegocio negocio = new LibroNegocio();
                Genero genero = new Genero();
                Autor autor = new Autor();

                libro.Codigo = txtCodigo.Text;
                libro.Titulo = txtTitulo.Text;
                libro.Descripcion = txtDescripcion.Text;
                libro.Precio = decimal.Parse(txtPrecio.Text);
                libro.Stock = short.Parse(txtStock.Text);
                libro.PortadaURL = txtportadaURL.Text;
                //autor.Id = int.Parse(txtAutorNombre.SelectedValue);
                //genero.Id = int.Parse(txtGenero.SelectedValue);
                //libro.Generos.Add(genero);
                //libro.Autores.Add(autor);  

                

                if (Request.QueryString["Id"] != null) 
                {
                    libro.Id = int.Parse(txtID.Text);
                    negocio.Modificar(libro);
                    /*Response.Redirect("StoreProc.aspx", false);*/
                    Response.Redirect("Productos.aspx", false);
                }
                else
                {
                    negocio.Agregar(libro);
                    Response.Redirect("Productos.aspx", false);
                }

                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        


        }

        protected void txtportadaURL_TextChanged(object sender, EventArgs e)
        {
            ImgPortada.ImageUrl = txtportadaURL.Text;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginNecesario = HttpContext.Current.Request.Url.AbsolutePath;
            Session.Add("loginNecesario", loginNecesario);
            if (Session["Usuario"] != null)
                Session.Remove("Usuario");

            Response.Redirect("User/Login.aspx");
        }

        protected void btnAgregarGenero_Click(object sender, EventArgs e)
        {
            Genero genero = new Genero();
            //Obtengo los datos del genero seleccionado
            genero.Id = Int32.Parse(txtGenero.SelectedValue);
            genero.Nombre = txtGenero.SelectedItem.ToString();

            //Agrego el genero al listado de mi libro
            libro.Generos.Add(genero);

            //Remuevo el genero agregado del dropbox
            txtGenero.Items.Remove(txtGenero.SelectedItem);
            txtGenero.ClearSelection(); //Limpio las selecciones de la lista para que vuelva al valor "Vacio"
            txtGenero.DataBind(); //Vuelvo a hacer el bind de los datos para asegurarme que tenga el listado actualizado

            Session["Libro"] = libro; //Vuelvo a agregar el libro a session para no perder los datos

            lbxGeneros.DataSource = libro.Generos;
            lbxGeneros.DataBind(); //por ultimo actualizo los elementos del ListBox
        }

        protected void btnAgregarAutor_Click(object sender, EventArgs e)
        {
            Autor autor = new Autor();
            //Obtengo el id del Autor
            autor.Id = Int32.Parse(txtAutorNombre.SelectedValue);
            
            AutorNegocio autorNegocio = new AutorNegocio();
            //Obtengo el autor de la base de datos
            autor = autorNegocio.BuscarAutor_ID(autor.Id);

            //Le agrego el libro al autor
            libro.Autores.Add(autor);

            //Remuevo el autor del dropbox
            txtAutorNombre.Items.Remove(txtAutorNombre.SelectedItem);
            txtAutorNombre.ClearSelection(); //Limpio los selected values
            txtAutorNombre.DataBind();

            Session["Libro"] = libro;

            lbxAutores.DataSource = libro.Autores;
            lbxAutores.DataBind(); //Actualizo elementos del listbox
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