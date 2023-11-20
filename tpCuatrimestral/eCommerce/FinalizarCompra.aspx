<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="eCommerce.FinalizarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (LibrosSinRepetidos.Count() != 0)
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
                <asp:Label ID="PrecioFinal" runat="server" Text="Precion Final" OnLoad="PrecioFinal_Load"> Total a pagar </asp:Label>
            </h5>   
         </div>
        <div>
            <asp:Button ID="btnFinalizarCompra" runat="server" 
                CssClass="btn btn-primary"
                Text="Finalizar Compra"
                OnClick="btnFinalizarCompra_Click"/>
        </div>
    <%}
      else
      { %>
        <h2>No hay productos</h2>
    <%} %>
</asp:Content>
