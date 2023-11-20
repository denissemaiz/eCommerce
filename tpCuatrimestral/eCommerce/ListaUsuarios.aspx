<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="eCommerce.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (ValidarAdmin() == true)
       { %>
        <asp:GridView ID="DVGUsuarios" 
            CssClass="table" 
            AutoGenerateColumns="false"  
            runat="server">
    
          <Columns>
            <asp:BoundField Headertext="ID del Usuario" Datafield="Id"  />
            <asp:BoundField Headertext="Usuario" Datafield="Username"  />
            <asp:BoundField Headertext="Direccion Email" Datafield="Mail"  />

         </Columns>
    
    
    
        </asp:GridView>
    <%}else
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
     <%} %>
</asp:Content>
