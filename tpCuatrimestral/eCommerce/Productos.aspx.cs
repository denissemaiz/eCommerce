using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases;
using dominio;
using negocio;


namespace eCommerce
{
    public partial class Productos : System.Web.UI.Page
    {

        public List<Libro> ListarLibros { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            LibroNegocio librosDB = new LibroNegocio();

            if (!IsPostBack)
            {
                if (Request.QueryString.AllKeys.Contains("generosLib"))
                {
                    string genero = Request.QueryString["generosLib"].ToString();
                    List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.Buscar(genero, "ID_Genero"));
                    repLibros.DataSource = listaSinRepetidos;
                    repLibros.DataBind();
                }

                if (Request.QueryString.AllKeys.Contains("autoresLib"))
                {
                    string autor = Request.QueryString["autoresLib"].ToString();
                    List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.Buscar(autor, "ID_Autor"));
                    repLibros.DataSource = listaSinRepetidos;
                    repLibros.DataBind();
                }

                if (!Request.QueryString.AllKeys.Contains("autoresLib") && !Request.QueryString.AllKeys.Contains("generosLib"))
                {
                    List<Libro> listaSinRepetidos = librosDB.RemoveDuplicadosLibro(librosDB.Listar());
                    repLibros.DataSource = listaSinRepetidos;
                    repLibros.DataBind();
                }
            }
            
        }

        protected void btnEliminarLibro_Click(object sender, EventArgs e)
        {
            string idLibro = ((Button)sender).CommandArgument;

            LibroNegocio articulos = new LibroNegocio();
            ListarLibros = articulos.PruebaBuscar(idLibro);

            if (ListarLibros != null)
            {
                LibroNegocio negocio = new LibroNegocio();
                int id = Convert.ToInt32(idLibro);
                negocio.Eliminar(id);
                Response.Redirect("Productos.aspx");
            }
        }

        protected void btnModificarLibro_Click(object sender, EventArgs e)
        {
            Response.Redirect("StoreProc.aspx");
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