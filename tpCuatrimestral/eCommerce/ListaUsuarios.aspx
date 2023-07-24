<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="eCommerce.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
    
</asp:Content>
