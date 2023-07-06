<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="eCommerce.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1></h1>
<p>Catálogo de Libros</p>
    <%if (ValidarAdmin()) { %>
        <div class="btn-toolbar my-lg-0" role="toolbar" aria-label="A&B button group">
            <a href="AgregarProducto.aspx" class="btn btn-primary btn-lg active" role="button" aria-pressed="true">Agregar Libro</a>
            <a href="StoreProc.aspx" class="btn btn-secondary btn-lg active" role="button" aria-pressed="true">Modificar</a>
        </div>
    <% } %>
  <div class="row row-cols-1 row-cols-md-3 g-4">              
      <asp:Repeater ID="repLibros" runat="server">
        <ItemTemplate>
            <div class="col">
                <div class="card h-80" style="width: 18rem;">
                    <img src="<%#Eval("PortadaURL") %>" class="card-img-top img-fluid" alt="...">
                    <div class="card-body">
                        <h5 class="card-title ms-1"><%#Eval("Titulo") %></h5>
                        <p class="card-text mb-1 ms-1">$<%#Eval("Precio") %></p>
                        <div class="btn-toolbar justify-content-between" role="toolbar" aria-label="button group">
                            <div class="btn btn-sm p-0" role="group" aria-label="First">
                                <a href="Detalles.aspx?cod=<%#Eval("Codigo") %>" class="btn btn-light mt-1">Ver detalles</a>                                        
                            </div>                         
                         </div>
                            <div class="btn-group btn-group-sm" role="group" aria-label="Basic example">
                                <%if (ValidarAdmin()) { %>
                                    <div class="btn-group" role="group" aria-label="First group">
                                        <asp:Button ID="btnModificarLibro" runat="server"
                                            CssClass="btn btn-dark btn-sm my-2" 
                                            Text="Modificar" 
                                            CommandArgument='<%#Eval("Id") %>' 
                                            CommandName="ModificarLibro" 
                                            OnClick="btnModificarLibro_Click"/>
                                    </div>
                                    <div class="btn-group" role="group" aria-label="Second group">
                                        <asp:Button ID="btnEliminarLibro" runat="server" 
                                            CssClass="btn btn-danger btn-sm my-2" 
                                            Text="Eliminar" CommandArgument='<%#Eval("Id") %>' 
                                            CommandName="EliminarLibro" 
                                            OnClick="btnEliminarLibro_Click"/>
                                    </div>
                                <%} else {%>
                                    <div class="d-grid gap-2">
                                        <asp:Button ID="btnAgregarACarrito" CssClass="btn btn-dark" Text="Agregar al carrito" CommandArgument='<%#Eval("Codigo") %>' CommandName="IdLibro" OnClick="btnAgregarACarrito_Click" runat="server" />
                                    </div>
                                <%}%>
                        </div>
                    </div>
                    <div class="card-footer">
                        <small class="text-body-secondary">Código: <%#Eval("Codigo") %></small>
                    </div>
                </div>
            </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
</asp:Content>
