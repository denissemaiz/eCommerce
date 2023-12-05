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
                        <asp:Label ID="lblNombre" runat="server" Visible="true" ></asp:Label>
                        <%--<label for="na"></label>--%>
                        <label for="email"><i class="fa fa-envelope"></i> <b>Mail</b></label>
                        <asp:Label ID="lblEmail" runat="server" Visible="true"></asp:Label>
                        <%--<label for="mail">ejemplo@ejemplo.com</label>--%>
                        <label for="adr"><i class="fa-solid fa-house"></i> <b>Direccion</b></label>
                        <asp:Label ID="lblDireccion" runat="server" Visible="true"></asp:Label>
                        <%--<label for="direccion">Cordero 2312</label>--%>
                        <label for="phone"><i class="fa-solid fa-mobile-screen-button"></i> <b>Telefono</b></label>
                        <asp:Label ID="lblTelefono" runat="server" Visible="true"></asp:Label>
                        <%--<label for="Telefono">1138296242</label>--%>
                        <label for="city"><i class="fa-solid fa-city"></i> <b>Ciudad</b></label>
                        <asp:Label ID="lblCiudad" runat="server" Visible="true"></asp:Label>
                        <%--<label for="ciudad">Tigre</label>--%>

                        <div class="row">
                            <div class="col-50">
                                <label for="state"><b>Provincia</b></label>
                                <asp:Label ID="lblProvincia" runat="server" Visible="true"></asp:Label>
                                <%--<label for="pv">Buenos Aires</label>--%>
                            </div>
                            <div class="col-50">
                                <label for="zip"><b>Codigo postal</b></label>
                                <asp:Label ID="lblCp" runat="server" Visible="true"></asp:Label>
                                <%--<label for="cp">1647</label>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-50">
                        <h3>Datos del producto</h3>
                        <label for="cname"><i class="fa-solid fa-shop"></i> <b>Codigo de compra</b></label>
                        <asp:Label ID="lblCodigoCompra" runat="server" Visible="true"></asp:Label>
                        <%--<label for="codigo">B3F123</label>--%>
                        <label for="datefecha"><i class="fa-solid fa-calendar-days"></i> <b>Fecha de la compra</b></label>
                        <asp:Label ID="lblFechaCompra" runat="server" Visible="true"></asp:Label>
                        <%--<label for="datefechacompra">10/10/10</label>--%>
                        <label for="prodnum"><i class="fa-solid fa-cart-shopping"></i> <b>Producto</b></label>
                        <asp:ListBox ID="lbxProductos" runat="server" CssClass="form-control"></asp:ListBox>
                        <%--<label for="producto">Libro, cantidad: 10</label>--%>
                        <label for="Pago"><i class="fa-solid fa-dollar-sign"></i> <b>Monto total</b></label>
                        <asp:Label ID="lblMonto" runat="server" Visible="true"></asp:Label>
                        <%--<label for="PagoTotal">1000</label>--%>
                        <label for="estado"><i class="fa-solid fa-truck-fast"></i> <b>Estado</b></label>
                        <asp:Label ID="lblEstado" runat="server" Visible="true"></asp:Label>
                        <%--<label for="estadoactual">En espera</label>--%>


                    </div>

                </div>
                <asp:Button ID="btnVolver" runat="server" 
                    Text="Volver"
                    CssClass="btn" 
                    OnClick="btnVolver_Click" />
                 <%if (ValidarAdmin()) { %>
     <div class="btn-toolbar my-lg-0" role="toolbar" aria-label="A&B button group">
         <asp:Button ID="Button1" runat="server" 
    Text="Guardar"
    CssClass="btn" 
    OnClick="btnVolver_Click" />

     </div>
 <% } %>
                <%--<input type="button" value="Volver" class="btn">--%>
                <%--<input type="button" value="Cancelar compra" class="btn2">--%>
            </form>
        </div>
    </div>
</div>

</asp:Content>
