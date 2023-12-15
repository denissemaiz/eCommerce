using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Conexiones;
using negocio;
using eCommerce.User;

namespace eCommerce
{
    public partial class ListaPedidos : System.Web.UI.Page
    {

        public Usuario user;

        protected void Page_Load(object sender, EventArgs e)
        {

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
                Response.Redirect("ListaPedidos.aspx");
            }
            else
            {
                //Agregar mensaje de error
                Response.Redirect("ListaPedidos.aspx");
            }
        }
        protected void DGVPedidos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            DGVPedidos.PageIndex = e.NewSelectedIndex;
            DGVPedidos.DataBind();
        }
        protected void DGVPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVPedidos.PageIndex = e.NewPageIndex;
            DGVPedidos.DataBind();
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
            }
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