<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="eCommerce.User.UserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% if (Session["Usuario"] != null){ %>
            
    <% }else{ %>
        <div class="div row align-self-center">
				<h1>Debe loguearse para ingresar a esta página</h1>
				<div class="col">
					<a href="Login.aspx" class="btn btn-primary">Login</a>
					<a href="../Default.aspx" class="btn btn-secondary">Inicio</a>
				</div>
			</div>
    <% } %>
</asp:Content>
