<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="eCommerce.AgregarProducto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

    <% if (ValidarAdmin())
        { %>
        <div>
            <%--Fila para el ID (Habría que buscar formas de mostrar el ID autoasignado--%>
            <div class="row">
                <div class="col-md-3">
                    <asp:Label for="txtID" runat="server" CssClass="form-label"><b>ID:</b></asp:Label>
                    <asp:TextBox ID="txtID" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

            </div>

            <div class="row">
                <div class="col-md-2">
                    <asp:Label for="txtCodigo" runat="server" CssClass="form-label"><b>Codigo:</b></asp:Label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" 
                        ControlToValidate="txtCodigo"
                        Display="Dynamic"
                        ErrorMessage="Debe ingresar un código para el libro"
                        CssClass="invalid-feedback"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label for="txtTitulo" runat="server" CssClass="form-label"><b>Titulo:</b></asp:Label>
                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" 
                        ControlToValidate="txtTitulo"
                        Display="Dynamic"
                        ErrorMessage="Debe ingresar un titulo para el libro"
                        CssClass="invalid-feedback"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

            <asp:UpdatePanel ID="updListas" runat="server">
                <ContentTemplate>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label for="txtGenero" runat="server" CssClass="form-label"><b>Genero:</b></asp:Label>
                            <%-- Agrupo los controles con un div="Input-Group" para que se dibujen sobre la misma fila --%>
                            <div class="input-group">
                                <asp:DropDownList ID="txtGenero" CssClass="form-select" runat="server"></asp:DropDownList>
                                <asp:LinkButton ID="btnAgregarGenero" runat="server"
                                    CssClass="btn btn-success"
                                    OnClick="btnAgregarGenero_Click"
                                    ValidationGroup="GrupoGenero">
                                    <i class="bi bi-plus-lg"></i></asp:LinkButton>
                            </div>
                            <%--Validador para el genero--%>
                            <asp:RequiredFieldValidator ID="rfvGenero" runat="server"
                                ControlToValidate="txtGenero"
                                ValidationGroup="GrupoGenero"
                                InitialValue="NA"
                                Display="Dynamic"
                                ErrorMessage="Debe seleccionar un genero para el libro"
                                CssClass="invalid-feedback"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="row g-2">
                            <div class="col-md-3">
                                <asp:ListBox ID="lbxGeneros" runat="server" CssClass="form-control">
                                </asp:ListBox>
                                <%--Validador para el listado de generos --%>
                                <%--<asp:RequiredFieldValidator ID="rfvGeneros" runat="server"
                                    ControlToValidate="lbxGeneros"
                                    InitialValue=""
                                    Display="Dynamic"
                                    ErrorMessage="Debe agregar un género para el libro"
                                    CssClass="invalid-feedback"
                                    ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                <asp:CustomValidator ID="cvGeneros" runat="server"
                                    ClientValidationFunction="checkListBoxGenero"
                                    Display="Dynamic"
                                    ValidateEmptyText="true"
                                    ErrorMessage="Debe agregarle al menos un genero al libro"
                                    CssClass="invalid-feedback"
                                    ForeColor="Red"></asp:CustomValidator>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label for="txtAutorNombre" runat="server" CssClass="form-label"><b>Nombre del autor:</b></asp:Label>
                            <div class="input-group">
                                <asp:DropDownList ID="txtAutorNombre" CssClass="form-select" runat="server"></asp:DropDownList>
                                <asp:LinkButton ID="btnAgregarAutor" runat="server"
                                    ValidationGroup="GrupoAutores"
                                    OnClick="btnAgregarAutor_Click"
                                    CssClass="btn btn-success"><i class="bi bi-plus-lg"></i></asp:LinkButton>

                            </div>

                            <%-- Validador del autor --%>
                            <asp:RequiredFieldValidator ID="rfvAutor" runat="server"
                                ControlToValidate="txtAutorNombre"
                                ValidationGroup="GrupoAutores"
                                InitialValue="NA"
                                Display="Dynamic"
                                ErrorMessage="Debe seleccionar un autor para el libro"
                                CssClass="invalid-feedback"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="row g-2">
                            <div class="col-md-3">
                                <asp:ListBox ID="lbxAutores" runat="server" CssClass="form-control">
                                </asp:ListBox>
                                <%--<asp:RequiredFieldValidator ID="rfvAutores" runat="server"
                                    ControlToValidate="lbxAutores"
                                    InitialValue=""
                                    Display="Dynamic"
                                    ErrorMessage="Debe agregar un género para el libro"
                                    CssClass="invalid-feedback"
                                    ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                <%--Validador para el listado de Autores --%>
                                <asp:CustomValidator ID="cvAutores" runat="server"
                                    ClientValidationFunction="checkListBoxAutor"
                                    Display="Dynamic"
                                    ValidateEmptyText="true"
                                    ErrorMessage="Debe agregarle al menos un autor al libro"
                                    CssClass="invalid-feedback"
                                    ForeColor="Red"></asp:CustomValidator>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

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
    <% }
        else
        { %>
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

    <script>
        //Valida que haya al menos un Genero en el listbox de Generos
        function checkListBoxGenero(source, args) {
            var listBox = document.getElementById('<%= lbxGeneros.ClientID %>');
            args.IsValid = listBox.options.length > 0;
        }
        //Valida que haya al menos un Autor en el listbox de Autores
        function checkListBoxAutor(source, args) {
            var listBox = document.getElementById('<%= lbxAutores.ClientID %>');
            args.IsValid = listBox.options.length > 0;
        }
    </script>
</asp:Content>

