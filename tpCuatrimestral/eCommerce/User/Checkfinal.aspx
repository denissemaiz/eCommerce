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
                        <label for="txtNombreCompleto"><i class="fa fa-user"></i> Nombre completo</label>                       
                        <asp:TextBox ID="txtNombreCompleto" runat="server" placeholder="Nombre Apellido"></asp:TextBox>

                        <label for="txtMail"><i class="fa fa-envelope"></i> Email</label>
                        <asp:TextBox ID="txtMail" runat="server" placeholder="Usuario@gmail.com"></asp:TextBox>                        

                        <!-- Panel para datos de la direccion del usuario -->
                        <asp:ScriptManager ID="scrManagerDireccion" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="upDireccion" runat="server">

                            <ContentTemplate>
                                <div class="row">
                                    <div class="col">
                                        <label for="txtDireccion"><i class="fa fa-address-card-o"></i> Direccion</label>
                                        <asp:TextBox ID="txtDireccion" runat="server" placeholder="Monteagudo"></asp:TextBox>
                                    </div>

                                    <div class="col">
                                        <label for="txtAltura">Altura</label>
                                        <asp:TextBox ID="txtAltura" runat="server" placeholder="1241"></asp:TextBox>
                                    </div>
                                </div>

                                <label for="txtCiudad"><i class="fa-solid fa-city"></i> Ciudad</label> 
                                <asp:TextBox ID="txtCiudad" runat="server" placeholder="Pacheco"></asp:TextBox>

                                <div class="row">
                                    <div class="col-50">
                                        <label for="txtProvincia"><i class="bi bi-map"></i>Provincia</label>
                                        <asp:TextBox ID="txtProvincia" runat="server" placeholder="Buenos Aires"></asp:TextBox>
                                    </div>
                                    <div class="col-50">
                                        <label for="txtCp"><i class="bi bi-mailbox-flag"></i> CP</label>
                                        <asp:TextBox ID="txtCp" runat="server" placeholder="1674"></asp:TextBox>
                                    </div>                                     
                                </div>
                                <asp:LinkButton ID="lbtnUsarMiDireccion" runat="server" 
                                    Text="Usar mi Dirección"
                                    OnClick="lbtnUsarMiDireccion_Click"></asp:LinkButton>
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
                <%--<label>
                    <input type="checkbox" checked="checked" name="sameadr"> Mi direccion de envio es igual que el de facturacion
                </label>--%>                
                <asp:Button ID="btnFinalizarCompra" runat="server" 
                    OnClick="btnFinalizarCompra_Click"
                    Text="FinalizarCompra"
                    CssClass="btn" />                
                <asp:Button ID="btnCancelar" runat="server"
                    Text="Cancelar Compra"
                    CssClass="btn2" />
            </form>
        </div>
    </div>
</div>

</asp:Content>
