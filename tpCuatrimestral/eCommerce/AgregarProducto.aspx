<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="eCommerce.AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row m-3">
         <div class="col-md-6">
             <asp:Label for="txtCodigo" runat="server" CssClass="form-label"><b>Codigo:</b></asp:Label>
             <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
         </div>
     </div>
            <div class="row m-3">
                <div class="col-md-6">
                    <asp:Label for="txtTitulo" runat="server" CssClass="form-label"><b>Titulo:</b></asp:Label>
                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row m-3">
                <div class="col-md-6">
                    <asp:Label for="txtAutor" runat="server" CssClass="form-label"><b>Autor</b></asp:Label>
                    <asp:TextBox ID="txtAutor" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row m-3">
                <div class="col-md-6">
                    <asp:Label for="txtDescripcion" runat="server" CssClass="form-label"><b>Descripcion:</b></asp:Label>
                    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row m-3">
                <div class="col-md-6">
                    <asp:Label for="txtPrecio" runat="server" CssClass="form-label"><b>Precio:</b></asp:Label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row m-3">
                <div class="col-md-6">
                    <asp:Label for="txtStock" runat="server" CssClass="form-label"><b>Stock:</b></asp:Label>
                    <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row m-3">
                <div class="col-md-6">
                    <asp:Label for="txtGenero" runat="server" CssClass="form-label"><b>Genero:</b></asp:Label>
                    <asp:TextBox ID="txtGenero" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
    <div class="row m-3">
        <div class="col-md-6">


        </div>
    </div>
        


</asp:Content>

