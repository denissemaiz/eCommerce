<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="DetallesCompra2.aspx.cs" Inherits="eCommerce.DetallesCompra2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <link rel="stylesheet" type="text/css" href="/Styles/Checkout.css">

<script src="https://kit.fontawesome.com/227b5d7dc2.js" crossorigin="anonymous"></script>

<div class="row">
    <div class="col-75">
        <div class="container">
            <form class="Pago">

                <div class="row">
                    <div class="col-50">
                        <h3>Datos de envio</h3>
                        <label for="fname"><i class="fa fa-user"></i> <b>Nombre completo</b></label>
                        <label for="na"><%#Eval(pedido.IdCliente.ToString()) %></label>
                        <label for="email"><i class="fa fa-envelope"></i> <b>Mail</b></label>
                        <label for="mail">ejemplo@ejemplo.com</label>
                        <label for="adr"><i class="fa-solid fa-house"></i> <b>Direccion</b></label>
                        <label for="direccion">Cordero 2312</label>
                        <label for="phone"><i class="fa-solid fa-mobile-screen-button"></i> <b>Telefono</b></label>
                        <label for="Telefono">1138296242</label>
                        <label for="city"><i class="fa-solid fa-city"></i> <b>Ciudad</b></label>
                        <label for="ciudad">Tigre</label>

                        <div class="row">
                            <div class="col-50">
                                <label for="state"><b>Provincia</b></label>
                                <label for="pv">Buenos Aires</label>
                            </div>
                            <div class="col-50">
                                <label for="zip"><b>Codigo postal</b></label>
                                <label for="cp">1647</label>
                            </div>
                        </div>
                    </div>

                    <div class="col-50">
                        <h3>Datos del producto</h3>
                        <label for="cname"><i class="fa-solid fa-shop"></i> <b>Codigo de compra</b></label>
                        <label for="codigo">B3F123</label>
                        <label for="datefecha"><i class="fa-solid fa-calendar-days"></i> <b>Fecha de la compra</b></label>
                        <label for="datefechacompra">10/10/10</label>
                        <label for="prodnum"><i class="fa-solid fa-cart-shopping"></i> <b>Producto</b></label>
                        <label for="producto">Libro, cantidad: 10</label>
                        <label for="Pago"><i class="fa-solid fa-dollar-sign"></i> <b>Monto total</b></label>
                        <label for="PagoTotal">1000</label>
                        <label for="estado"><i class="fa-solid fa-truck-fast"></i> <b>Estado</b></label>
                        <label for="estadoactual">En espera</label>


                    </div>

                </div>
                <input type="button" value="Volver" class="btn">
                <input type="button" value="Cancelar compra" class="btn2">
            </form>
        </div>
    </div>
</div>

</asp:Content>
