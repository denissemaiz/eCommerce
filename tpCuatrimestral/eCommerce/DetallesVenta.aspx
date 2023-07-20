<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallesVenta.aspx.cs" Inherits="eCommerce.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row">
    <div class="col-75">
        <div class="container">
            <form class="Venta">
                <div class="row">
                    <div class="col-50">
                        <h3>Datos de compra</h3>
                        <label for="lblcodigo"> <b>Codigo compra:</b></label>
                        <label for="lblcodigocompra"> 1212 </label>
                        <br />
                        <label for="lblfecha"> <b>Fecha:</b></label>
                        <label for="lblfechacompra"> 09/12/2018 </label>
                        <br />
                        <label for="lblproductos"> <b>Productos:</b></label>
                        <label for="lblproductoscompra"> Boca murio en madrid. Cantidad: 91218 </label>
                        <br />
                        <label for="lblmonto"> <b>Monto total:</b></label>
                        <label for="lblmontototal"> $100000 </label>
                        <br />
                        <label for="lblestado"> <b>Estado:</b></label>
                        <label for="lblestadocompra"> En espera </label>
                        <br />
                        <br />
                        <p><b>La compra se cancelara unicamente si el producto todavia no fue despachado, osea, si el producto no fue enviado</b></p>
                        <asp:Button Text="Volver" CssClass="btn btn-secondary" runat="server" /> 
                        <asp:Button Text="Cancelar compra" CssClass="btn btn-primary" runat="server" />
                        <br />
                        
                    </div>
                </div>
            </form>
        </div>
    </div>
</div>


</asp:Content>
