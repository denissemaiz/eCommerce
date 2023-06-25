<%@ Page Title="Login" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="eCommerce.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form class="">
        <div class="row m-3 justify-content-center">
            <div class="col-md-6">
                <asp:Label ID="lblUsuario" runat="server" CssClass="form-label">Usuario:</asp:Label> 
                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row m-3 justify-content-center">
            <div class="col-md-6">
                <asp:Label ID="lblContra" runat="server" CssClass="form-label">Contraseña: </asp:Label>
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" UseSubmitBehavior="false"/>
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click1"/>
            </div>
        </div>
       
    </form>
    
                
            
                
            
</asp:Content>
