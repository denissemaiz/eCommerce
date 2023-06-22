<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="eCommerce.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Tienda</h1>
    <p>Catálogo de Productos</p>
    <div class="row row-cols-1 row-cols-md-3 g-4">      
        <asp:Repeater ID="repArticulos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <asp:Repeater ID="repImagenes" runat="server">
                            <ItemTemplate>
                                <img src="<%#Eval("ImagenUrl") %>" class="card-img-top img-fluid" alt="...">
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="card-body">
                            <h5 class="card-title ms-1"><%#Eval("Nombre") %></h5>
                            <p class="card-text mb-1 ms-1">$<%#Eval("Precio") %></p>
                            <div class="btn-toolbar justify-content-between" role="toolbar" aria-label="Toolbar with button groups">
                                <div class="btn-group me-2" role="group" aria-label="First group">
                                    <a href="Detalle.aspx?cod=<%#Eval("Codigo") %>" class="btn btn-light btn-sm mb-3">Ver detalles</a>
                                </div>
                                <div class="btn-group" role="group" aria-label="Second group">
                                    <button type="button" class="btn btn-danger btn-sm mb-3">♥</button>
                                </div>
                            </div>
                            <div class="d-grid gap-2">
                                <asp:Button ID="btnAgregarACarrito" CssClass="btn btn-dark" Text="Agregar al carrito" CommandArgument='<%#Eval("Codigo") %>' runat="server" />
                            </div>
                        </div>
                        <div class="card-footer">
                            <small class="text-body-secondary">Código de artículo: <%#Eval("Codigo") %></small>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
