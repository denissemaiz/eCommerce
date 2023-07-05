<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="eCommerce.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link rel="stylesheet" type="text/css" href="Detalles.css">

    <body>
        <main>

            <% 

                foreach (dominio.Libro Articulo in ListarLibros)
                {%>

            <div class="contenedor-imagen">
                <img src="<%: Articulo.PortadaURL %>"
                    alt="No disponible">
            </div>

            <div class="contenedor-infoproducto">
                <div class="contenedor-precio">
                    <span><b>Precio: $<%: Articulo.Precio %> </b></span>
                </div>

                <div class="contenedor-detalles">

                    <ul style="list-style: none;">
                        <li>
                            <b>Titulo: <%:Articulo.Titulo %></b>
                        </li>
                        <li>
                            <b>Genero: </b>
                        </li>
                        <li>
                            <b>Codigo: <%:Articulo.Codigo %></b>
                        </li>
                        <li>
                            <b>Autor/es:</b>
                        </li>
                        <li>
                            <b>Stock: <%:Articulo.Stock %></b>
                        </li>
                    </ul>

                </div>

                <div class="contenedor-descripcion">

                    <div class="titulo-descripcion">

                        <h4><b>Descripcion</b></h4>

                    </div>

                    <div class="text-descripcion">
                        <p><%:Articulo.Descripcion %></p>

                    </div>

                </div>

                <div class="contenedor-agregarproducto">
                    <button class="btn-add-al-carrito">
                        Agregar al carrito
                    </button>
                </div>

            </div>

            <% } %>
        </main>

    </body>





</asp:Content>
