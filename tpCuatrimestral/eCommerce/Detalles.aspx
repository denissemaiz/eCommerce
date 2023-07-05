﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="eCommerce.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link rel="stylesheet" type="text/css" href="Detalles.css">

    <body>
        <main>

            <%  foreach (dominio.Libro Articulo in ListarLibros)
                {%>

            <%foreach (dominio.Genero Genero in ListarGenero)
                {%>

            <%foreach (dominio.Autor Autor in ListarAutor)
                { %>

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
                            <p><b>Titulo: </b><%:Articulo.Titulo %></p>
                        </li>
                        <li>
                           <p> <b>Genero: </b><%:Genero.Nombre %></p>
                        </li>
                        <li>
                            <p><b>Codigo: </b><%:Articulo.Codigo %></p>
                        </li>
                        <li>
                            <p> <b> Autor/es: </b> <%:Autor.Nombre%> <%:Autor.Apellido %> </p>
                        </li>
                        <li>
                            <p><b>Stock: </b><%:Articulo.Stock %> </p>
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




            <%} %>


            <%} %>


            <% } %>
        </main>

    </body>





</asp:Content>
