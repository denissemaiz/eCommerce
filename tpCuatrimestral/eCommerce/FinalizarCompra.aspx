<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="eCommerce.FinalizarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["librosAgregados"] != null)
      { %>
        <asp:Repeater ID="repLibros" runat="server">
            <ItemTemplate>
                <hr style="color: white; background-color: white; width: 75%;" />
                <div id="container">
                    <center>
                        <div>
                            <h5><%#Eval("Titulo")%></h5>
                        </div>
                    </center>
                    <div>
                        <div>
                            <ul>
                                <li><%#Eval("Descripcion")%></li>
                                <li><%#Eval("Codigo")%></li>
                            </ul>
                        </div>
                    </div>
                    <h6><%#Eval("Precio")%></h6>
                </div>
                <hr style="color: white; background-color: white; width: 75%;" />
            </ItemTemplate>
        </asp:Repeater>
        <div>       
            <h5>Total a pagar: $
                <asp:Label ID="PrecioFinal" runat="server" Text="Precion Final"> Total a pagar </asp:Label>
            </h5>   
         </div>         
    <%}
      else
      { %>
        <h2>No hay productos</h2>
    <%} %>
</asp:Content>
