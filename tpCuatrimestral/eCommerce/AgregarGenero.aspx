<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarGenero.aspx.cs" Inherits="eCommerce.AgregarGenero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="row">

        <div class="col-md-3">
            <h3>Ingrese el nuevo genero</h3>
            <asp:TextBox ID="txt_genero" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="Agregar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="Agregar_Click" />
        </div>

    </div>

</asp:Content>
