<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="eCommerce.AgregarProducto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

    <% if (ValidarAdmin()){ %>
        <div class="row">

            <div class="col-md-3">
                <asp:Label for="txtID" runat="server" CssClass="form-label"><b>ID:</b></asp:Label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control"></asp:TextBox>
            </div>


            <div class="col-md-3">
                <asp:Label for="txtCodigo" runat="server" CssClass="form-label"><b>Codigo:</b></asp:Label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" 
                    ControlToValidate="txtCodigo"
                    Display="Dynamic"
                    ErrorMessage="Debe ingresar un código para el libro"
                    CssClass="invalid-feedback"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-3">
                <asp:Label for="txtTitulo" runat="server" CssClass="form-label"><b>Titulo:</b></asp:Label>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" 
                    ControlToValidate="txtTitulo"
                    Display="Dynamic"
                    ErrorMessage="Debe ingresar un titulo para el libro"
                    CssClass="invalid-feedback"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-3">
                <asp:Label for="txtGenero" runat="server" CssClass="form-label"><b>Genero:</b></asp:Label>
                <asp:DropDownList ID="txtGenero" CssClass="form-select" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvGenero" runat="server"
                    ControlToValidate="txtGenero"
                    InitialValue="NA"
                    Display="Dynamic"
                    ErrorMessage="Debe seleccionar un genero para el libro"
                    CssClass="invalid-feedback"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-3">
                <asp:Label for="txtAutorNombre" runat="server" CssClass="form-label"><b>Nombre del autor:</b></asp:Label>
                <asp:DropDownList ID="txtAutorNombre" CssClass="form-select" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvAutor" runat="server"
                    ControlToValidate="txtAutorNombre"
                    InitialValue="NA"
                    Display="Dynamic"
                    ErrorMessage="Debe seleccionar un autor para el libro"
                    CssClass="invalid-feedback"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-6">
                <asp:Label for="txtDescripcion" runat="server" CssClass="form-label"><b>Descripcion:</b></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" 
                    ControlToValidate="txtDescripcion"
                    Display="Dynamic"
                    ErrorMessage="Debe ingresar una descripción para el libro"
                    CssClass="invalid-feedback"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-3">
                <asp:Label for="txtStock" runat="server" CssClass="form-label"><b>Stock:</b></asp:Label>
                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStock" runat="server" 
                    ControlToValidate="txtStock"
                    Display="Dynamic"
                    ErrorMessage="Debe ingresar un valor de stock para el libro"
                    CssClass="invalid-feedback"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-3">
                <asp:Label for="txtPrecio" runat="server" CssClass="form-label"><b>Precio:</b></asp:Label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" 
                    ControlToValidate="txtPrecio"
                    Display="Dynamic"
                    ErrorMessage="Debe ingresar el precio del libro"
                    CssClass="invalid-feedback"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="col-md-6">
                        <asp:Label for="txxportadaURL" runat="server" CssClass="form-label"><b>Imagen url:</b></asp:Label>
                        <asp:TextBox ID="txtportadaURL" runat="server" 
                            CssClass="form-control" 
                            AutoPostBack="true" 
                            OnTextChanged="txtportadaURL_TextChanged" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPortada" runat="server" 
                            ControlToValidate="txtportadaURL"
                            Display="Dynamic"
                            ErrorMessage="Debe cargar el URL de la portada del libro"
                            CssClass="invalid-feedback"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Image  ImageUrl="https://plantillasdememes.com/img/plantillas/imagen-no-disponible01601774755.jpg"   ID="ImgPortada" runat="server" width="30%"/>
                </ContentTemplate>
            </asp:UpdatePanel>





        <div class="row m-3">
            <div class="col-md-6">
                <asp:Button ID="BtnAgregar" runat="server" OnClick="BtnAgregar_Click" Text="Aceptar" CssClass="btn btn-primary" />
                <a href="Default.aspx" class="btn btn-primary">Volver</a>
            </div>
        </div>
    <% }else { %>
        <div class="div row align-self-center">
				<h1>Necesita ser un administrador para acceder a esta pagina</h1>
			<div class="col">
				<a href="../Default.aspx" class="btn btn-secondary">Inicio</a>
				<asp:Button ID="btnLogin" runat="server" 
                    Text="Login"
                    CssClass="btn btn-primary"
                    OnClick="btnLogin_Click"/>
			</div>
		</div>
        
    <% } %>

</asp:Content>

