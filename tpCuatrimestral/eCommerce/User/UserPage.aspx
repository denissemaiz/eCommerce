<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="eCommerce.User.UserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<% if (Session["Usuario"] != null){ %>--%>
            <div class="container gy-5">

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
                        MaxLength="11"
                        placeholder="011******"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txbTelefono"
                            ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"
                            ForeColor="Red"
                            ErrorMessage="Solo acepta números"></asp:RegularExpressionValidator>
                    </div>
                </div>
                
                <div class="container row g-3">
                    <h1>Direccion</h1>
                    <div class="col-md-6">
                        <label class="form-label">Calle </label>
                        <asp:TextBox ID="txbCalle" runat="server" 
                            CssClass="form-control"
                            placeholder="Ej. Av. Constituyentes"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <label class="form-label">Altura </label>
                        <asp:TextBox ID="txbAltura" runat="server" 
                            CssClass="form-control"
                            placeholder="Ej. 150"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rgvAltura" runat="server" 
                            ControlToValidate="txbAltura"
                            ErrorMessage="Solo acepta números"
                            Display="Dynamic"
                            ForeColor="Red"
                            CssClass="Invalid-Feedback"
                            ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
                    </div>
                    <div class="row">

                        <div class="col-md-4">
                            <label class="form-label">Localidad </label>
                            <asp:TextBox ID="txbLocalidad" runat="server" 
                                CssClass="form-control"
                                placeholder="Palermo"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">cp </label>
                            <asp:TextBox ID="txbCp" runat="server" 
                                CssClass="form-control"
                                placeholder="Ej. 150"></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="txbAltura"
                                ErrorMessage="Solo acepta números"
                                Display="Dynamic"
                                ForeColor="Red"
                                CssClass="Invalid-Feedback"
                                ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>--%>
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">Provincia</label>
                            <asp:DropDownList ID="drdlProvincias" runat="server" CssClass="form-select"></asp:DropDownList>

                        </div>
                    </div>
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
