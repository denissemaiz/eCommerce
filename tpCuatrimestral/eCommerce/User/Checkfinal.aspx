<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Checkfinal.aspx.cs" Inherits="eCommerce.User.Checkfinal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <link rel="stylesheet" type="text/css" href="/Styles/Checkout.css">

<script src="https://kit.fontawesome.com/227b5d7dc2.js" crossorigin="anonymous"></script>
    <%if (Session["Usuario"] != null)
      { %>
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
                                                <label for="txtDireccion"><i class="fa fa-address-card-o"></i> Calle</label>
                                                <asp:TextBox ID="txtDireccion" runat="server" placeholder="Monteagudo"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvCalle" runat="server"
                                                    ControlToValidate="txtDireccion"
                                                    Display="Dynamic"
                                                    CssClass="invalid-feedback"
                                                    ForeColor="Red"
                                                    Text="Debe ingresar un nombre de calle"></asp:RequiredFieldValidator>
                                            </div>
        
                                            <div class="col">
                                                <label for="txtAltura">Altura</label>
                                                <asp:TextBox ID="txtAltura" runat="server" placeholder="1241"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvAltura" runat="server"
                                                    ControlToValidate="txtAltura"
                                                    Display="Dynamic"
                                                    CssClass="invalid-feedback"
                                                    ForeColor="Red"
                                                    Text="Debe ingresar el numero de su dirección"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revAltura" runat="server"
                                                    Display="Dynamic"
                                                    ControlToValidate="txtAltura"
                                                    ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"
                                                    ForeColor="Red"
                                                    CssClass="invalid-feedback"
                                                    ErrorMessage="Solo se aceptan numeros"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
        
                                        <label for="txtCiudad"><i class="fa-solid fa-city"></i> Ciudad</label> 
                                        <asp:TextBox ID="txtCiudad" runat="server" placeholder="Pacheco"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server"
                                            ControlToValidate="txtCiudad"
                                            Display="Dynamic"
                                            CssClass="invalid-feedback"
                                            ForeColor="Red"
                                            Text="Debe ingresar el nombre de su ciudad"></asp:RequiredFieldValidator>
        
                                        <div class="row">
                                            <div class="col-50">
                                                <label for="txtProvincia"><i class="bi bi-map"></i>Provincia</label>
                                                <asp:TextBox ID="txtProvincia" runat="server" placeholder="Buenos Aires"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvProvincia" runat="server"
                                                    ControlToValidate="txtProvincia"
                                                    Display="Dynamic"
                                                    CssClass="invalid-feedback"
                                                    ForeColor="Red"
                                                    Text="Debe ingresar el nombre de su provincia"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-50">
                                                <label for="txtCp"><i class="bi bi-mailbox-flag"></i> CP</label>
                                                <asp:TextBox ID="txtCp" runat="server" placeholder="1674"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvCp" runat="server"
                                                    ControlToValidate="txtCp"
                                                    Display="Dynamic"
                                                    CssClass="invalid-feedback"
                                                    ForeColor="Red"
                                                    Text="Debe ingresar su código postal"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revCp" runat="server"
                                                    ControlToValidate="txtCp"
                                                    Display="Dynamic"
                                                    ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"
                                                    CssClass="invalid-feedback"
                                                    ForeColor="Red"
                                                    ErrorMessage="Solo se aceptan numeros"></asp:RegularExpressionValidator>
                                            </div>                                     
                                        </div>
                                        <asp:LinkButton ID="lbtnUsarMiDireccion" runat="server" 
                                            Text="Usar mi Dirección"
                                            OnClick="lbtnUsarMiDireccion_Click"
                                            CausesValidation="false"></asp:LinkButton>
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
    <%} else { %>
        <div class="div row align-self-center">
	        <h1>Necesita estar logueado para acceder a esta página</h1>
	        <div class="col">
	            <a href="../Default.aspx" class="btn btn-secondary">Inicio</a>
	            <asp:Button ID="btnLogin" runat="server" 
                         Text="Login"
                         CssClass="btn btn-primary"
                         OnClick="btnLogin_Click"/>
	        </div>
	    </div>
    <%} %>

</asp:Content>
