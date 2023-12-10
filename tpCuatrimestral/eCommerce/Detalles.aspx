<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="eCommerce.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link rel="stylesheet" type="text/css" href="Styles/Detalles.css">
        <main>
            <div class="contenedor-imagen">
                <img src="<%: librito.PortadaURL %>"
                    alt="No disponible">
            </div>
            <div class="contenedor-infoproducto">
                <div class="contenedor-precio">
                    <span><b>Precio: $<%: librito.Precio %> </b></span>
                </div>
                <div class="contenedor-detalles">
                    <ul style="list-style: none;">
                        <li>
                            <p><b>Titulo: </b><%:librito.Titulo%></p>
                        </li>
                        <li>
                            <p><b>Genero: </b><%:librito.ListarGenero() %></p>
                        </li>
                        <li>
                            <p><b>Codigo: </b><%:librito.Codigo %></p>
                        </li>
                        <li>
                            <p><b>Autor/es: </b><%: librito.ListarAutores()%>  </p>
                        </li>
                    </ul>
                </div>
                <div class="contenedor-descripcion">
                    <div class="titulo-descripcion">

                        <h4><b>Descripcion</b></h4>

                    </div>
                    <div class="text-descripcion">
                        <p><%: librito.Descripcion %></p>
                    </div>
                </div>
                <div class="contenedor-agregarproducto">
                    <asp:Button ID="btnAgregarACarritoDetalles" CssClass="btn btn-add-al-carrito" Text="Agregar al carrito" CommandArgument='<%#Eval(librito.Codigo)%>' CommandName="IdLibro" OnClick="btnAgregarACarritoDetalles_Click" runat="server" />
                </div>
                <p id="mensajeStock" runat="server" style="color: red; display: none;">No hay stock de este producto</p>
            </div>
        </main>
</asp:Content>
