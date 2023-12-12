<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="StoreProc.aspx.cs" Inherits="eCommerce.StoreProc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="Styles/Paginador.css" />

    <% if( ValidarAdmin()) { %>
            <asp:GridView ID="DVGLibros"  runat="server" 
                DataKeyNames="Id" 
                AllowPaging="true"
                CssClass="table" 
                AutoGenerateColumns="false" 
                OnSelectedIndexChanged="DVGLibros_SelectedIndexChanged" 
                OnSelectedIndexChanging="DVGLibros_SelectedIndexChanging"
                OnPageIndexChanging="DVGLibros_PageIndexChanging">


                <Columns>

                    <asp:BoundField Headertext="Codigo" Datafield="Codigo"  />
                    <asp:BoundField Headertext="Titulo" Datafield="Titulo"  />
                    <asp:BoundField Headertext="Precio" Datafield="Precio"  />
                    <asp:BoundField Headertext="Stock" Datafield="Stock"  />
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Modificar" />

                </Columns>
                <PagerSettings 
                    Mode="Numeric"/>
            </asp:GridView>
    <% }else{ %>
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
