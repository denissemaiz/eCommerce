<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="eCommerce.User.UserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<% if (Session["Usuario"] != null){ %>--%>
            
                <div class="container row g-3">
                    <h1>Mis datos</h1>
                    <div class="col-md-4">
                        <label class="form-label">Nombre </label>
                        <asp:TextBox ID="txbNombre" runat="server" 
                            CssClass="form-control"
                            placeholder="Nombre. . ."></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">Apellido </label>
                        <asp:TextBox ID="txbApellido" runat="server" 
                            CssClass="form-control"
                            placeholder="Apellido. . ."></asp:TextBox>
                    </div>
                    
                    <div class="col-8">
                        <asp:TextBox ID="txbTelefono" runat="server" 
                        CssClass="form-control"
                        textMode="Number"
                        placeholder="011******"></asp:TextBox>
                    </div>
                </div>
                
                <div class="container row g-3">
                    <h1>Direccion</h1>
                    <div class="col-md-4">
                        <label class="form-label">Calle </label>
                        <asp:TextBox ID="txbCalle" runat="server" 
                            CssClass="form-control"
                            placeholder="Calle"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">Numero </label>
                        <asp:TextBox ID="txbNumero" runat="server" 
                            CssClass="form-control"
                            placeholder="Numero"></asp:TextBox>
                    </div>
                    
                    <div class="col-8">
                        <asp:TextBox ID="txbCiudad" runat="server" 
                        CssClass="form-control"
                        textMode="Number"
                        placeholder="011******"></asp:TextBox>
                    </div>
                </div>
            
    <%--<% }else{ %>
        <div class="div row align-self-center">
				<h1>Debe loguearse para ingresar a esta página</h1>
				<div class="col">
					<a href="Login.aspx" class="btn btn-primary">Login</a>
					<a href="../Default.aspx" class="btn btn-secondary">Inicio</a>
				</div>
			</div>
    <% } %>--%>
</asp:Content>
