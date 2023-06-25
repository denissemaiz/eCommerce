<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="eCommerce.User.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% if (Session["Usuario"] != null )
		{ %>
			<div class="div row align-self-center">
				<h1>Usted ya se encuetra registrado</h1>
				<div class="col">
					<a href="Logout.aspx" class="btn btn-primary">Logout</a>
					<a href="../Default.aspx" class="btn btn-secondary">Volver</a>
				</div>
			</div>
	<%	}else{ %>
			<form class="">
                <div class="row m-3 justify-content-center">
                    <div class="col-md-6">
                        <asp:Label ID="lblEmail" runat="server" CssClass="form-label">Email:</asp:Label> 
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    </div>
                </div>
                <div class="row m-3 justify-content-center">
                    <div class="col-md-6">
                        <asp:Label ID="lblUsuario" runat="server" CssClass="form-label">Usuario:</asp:Label> 
                        <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row m-3 justify-content-center">
                    <div class="col-md-6">
                        <asp:Label ID="lblPass" runat="server" CssClass="form-label">Contraseña:</asp:Label> 
                        <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="row m-3 justify-content-center">
                    <div class="col-md-6">
                        <asp:Label ID="lblConf" runat="server" CssClass="form-label">Confirmar Contraseña: </asp:Label>
                        <asp:TextBox ID="txtConfPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" UseSubmitBehavior="false"/>
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" />
                    </div>
                </div>
       
            </form>
			
	
	<%   } %>
</asp:Content>
