﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="RecuperarPasswordMail.aspx.cs" Inherits="eCommerce.User.RecuperarPasswordMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form class="">
        <div class="row m-3 justify-content-center">
            <div class="col-md-6">
                <asp:Label ID="lblIngreseMail" runat="server" CssClass="form-label"><b>Ingrese su direccion email</b> </asp:Label>
                <asp:TextBox ID="txtRecuperarMail" runat="server" CssClass="form-control" placeholder="ejemplo@ejemplo.com"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtRecuperarMail" runat="server"
                    ControlToValidate="txtRecuperarMail"
                    Display="Dynamic"
                    CssClass="invalid-feedback"
                    ForeColor="Red"
                    Font-Bold="true"
                    ErrorMessage="Debe ingresar su mail"></asp:RequiredFieldValidator>
                <br />
                <a href="..\Default.aspx" class="btn btn-secondary">Cancelar</a>
                <asp:Button ID="BtnEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="BtnEnviar_Click"/>
                <asp:Label ID="lblMensaje" Visible="false" runat="server" CssClass="form-label"><b>Se envio el mail a su casilla de correo.</b> </asp:Label>
            </div>
        </div>
       
    </form> 
         
    




</asp:Content>
