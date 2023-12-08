<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Checkfinal.aspx.cs" Inherits="eCommerce.User.Checkfinal" %>
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
                        <label for="fname"><i class="fa fa-user"></i> Nombre completo</label>
                        <input type="text" id="fname" name="firstname" placeholder="Nombre Apellido">
                        <label for="email"><i class="fa fa-envelope"></i> Email</label>
                        <input type="text" id="email" name="email" placeholder="Usuario@gmail.com">
                        <label for="adr"><i class="fa fa-address-card-o"></i> Direccion</label>
                        <input type="text" id="adr" name="address" placeholder="Monteagudo 1234">
                        <!-- Panel para datos de la direccion del usuario -->
                        <asp:ScriptManager ID="scrManagerDireccion" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="upDireccion" runat="server">

                            <ContentTemplate>
                                <label for="city"><i class="fa fa-institution"></i> Ciudad</label> <asp:LinkButton ID="lbtnUsarMiDireccion" runat="server" Text="Usar mi Dirección"></asp:LinkButton>
                                <input type="text" id="city" name="city" placeholder="Pacheco">

                                <div class="row">
                                    <div class="col-50">
                                        <label for="state">Provincia</label>
                                        <input type="text" id="state" name="state" placeholder="Buenos Aires">
                                    </div>
                                    <div class="col-50">
                                        <label for="zip">CP</label>
                                        <input type="text" id="zip" name="zip" placeholder="1646">
                                    </div>
                                     <div class="col-50">
                                        <label for="state">Provincia</label>
                                        <input type="text" id="state" name="state" placeholder="Buenos Aires">
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-50">
                        <h3>Pago</h3>
                        <label for="fname">Aceptamos:</label>
                        <div class="icon-container">
                            <i class="fa fa-cc-visa" style="color:navy;"></i>
                            <i class="fa fa-cc-amex" style="color:blue;"></i>
                            <i class="fa fa-cc-mastercard" style="color:red;"></i>
                            <i class="fa fa-cc-discover" style="color:orange;"></i>
                        </div>
                        <label for="cname">Propietario de la tarjeta</label>
                        <input type="text" id="cname" name="cardname" placeholder="Alan Ibañez">
                        <label for="ccnum">Numero de tarjeta</label>
                        <input type="text" id="ccnum" name="cardnumber" placeholder="1111-2222-3333-4444">
                        <label for="expmonth">Mes de expiracion</label>
                        <input type="text" id="expmonth" name="expmonth" placeholder="Septiembre">
                        <div class="row">
                            <div class="col-50">
                                <label for="expyear">Año de expiracion</label>
                                <input type="text" id="expyear" name="expyear" placeholder="2033">
                            </div>
                            <div class="col-50">
                                <label for="cvv">CVV</label>
                                <input type="text" id="cvv" name="cvv" placeholder="111">
                            </div>
                        </div>
                    </div>

                </div>
                <label>
                    <input type="checkbox" checked="checked" name="sameadr"> Mi direccion de envio es igual que el de facturacion
                </label>
                <input type="button" value="Finalizar compra" class="btn">
                <input type="button" value="Cancelar compra" class="btn2">
            </form>
        </div>
    </div>
</div>

</asp:Content>
