<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="eCommerce.FinalizarCompra" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <script type="text/javascript">
            function confirmarEliminacion() {
                return confirm('¿Estás seguro de que deseas eliminar este libro?');
            }
            </script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles/CompraFinal.css">
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Carrito de Compra</title>
        <link rel="stylesheet" href="styles.css">
    </head>

       <asp:ScriptManager ID="scManager1" runat="server"></asp:ScriptManager>
       <asp:UpdatePanel ID="upProductos" runat="server">
           <ContentTemplate>
               <%if (LibrosSinRepetidos.Count() != 0)
                 { %>
          
                   <h2>Carrito de Compra</h2>
       
                           <asp:Repeater ID="repLibros" runat="server" OnLoad="repLibros_Load">
                               <ItemTemplate>

                                   <body>
                                       <div class="cart">
                                           <ul class="cart-items">
                                               <!-- Elementos para no perderme -->
                                               <li class="item">
                                                   <img src=" <%#Eval("PortadaURL")%> " alt="Producto">
                                                   <span class="item-name"> <%#Eval("Titulo")%>(x<%#:carrito.contabilizarLibro((int)Eval("Id")) %>) </span>
                                                   <span class="item-price"> <%#Eval("Precio")%> $ </span>
                                                   <asp:button ID="btnEliminar" runat="server" 
                                                       CommandArgument='<%#:Eval("Codigo") %>'
                                                       OnClick="btnEliminar_Click"
                                                       OnClientClick="return confirmarEliminacion();"
                                                       CssClass="remove-item" 
                                                       Text="Eliminar"></asp:button>
                                               </li>
                                               <!-- Agregar mas cosas por si se da -->
                                           </ul>
                                        </div>
                                   </body>

                               </ItemTemplate>
                           </asp:Repeater>

           
                   <div>       
                       <h5><b>Total a pagar: $</b>
                           <b>
                           <asp:Label ID="PrecioFinal" runat="server" Text="Precion Final" OnLoad="PrecioFinal_Load"> <b>Total a pagar</b> </asp:Label></b>
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
           </ContentTemplate>
       </asp:UpdatePanel>
    </html>
</asp:Content>
