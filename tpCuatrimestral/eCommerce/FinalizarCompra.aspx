<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="eCommerce.FinalizarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <head>
        <meta charset="UTF-8">
        <title>Carrito de Compra</title>
        <link rel="stylesheet" href="styles.css">
    </head>

    <%if (LibrosSinRepetidos.Count() != 0)
      { %>
        <asp:Repeater ID="repLibros" runat="server">
            <ItemTemplate>

                <body>
                    <div class="cart">
                        <h2>Carrito de Compra</h2>
                        <ul class="cart-items">
                            <!-- Elementos para no perderme -->
                            <li class="item">
                                <img src=" <%#Eval("PortadaURL")%> " alt="Producto">
                                <span class="item-name"> <%#Eval("Titulo")%> </span>
                                <span class="item-price"> <%#Eval("Precio")%> </span>
                                <button class="remove-item">Eliminar</button>
                            </li>
                            <!-- Agregar mas cosas por si se da -->
                        </ul>
                </body>

            </ItemTemplate>
        </asp:Repeater>
        <div>       
            <h5>Total a pagar: $
                <asp:Label ID="PrecioFinal" runat="server" Text="Precion Final" OnLoad="PrecioFinal_Load"> Total a pagar </asp:Label>
            </h5>   
         </div>
        <div>
            <asp:Button ID="btnFinalizarCompra" runat="server" 
                CssClass="checkout-btn"
                Text="Finalizar Compra"
                OnClick="btnFinalizarCompra_Click"/>
        </div>
    <%}
      else
      { %>
        <h2>No hay productos</h2>
    <%} %>

</asp:Content>
