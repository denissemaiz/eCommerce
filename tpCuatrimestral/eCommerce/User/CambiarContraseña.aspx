<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="eCommerce.User.CambiarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form class="">
        <div class="row m-3 justify-content-center">
            <div class="col-md-6">
                <asp:Label ID="LblContraseñaActual" runat="server" CssClass="form-label"><b>Contraseña actual</b></asp:Label>
                <asp:TextBox ID="TxtContraseñaActual" runat="server" CssClass="form-control" TextMode="Password" placeholder="*********"></asp:TextBox>
            </div>
        </div>
        <div class="row m-3 justify-content-center">
            <div class="col-md-6">
                <asp:Label ID="LblContraseñaNueva" runat="server" CssClass="form-label"><b>Nueva contraseña</b></asp:Label>
                <asp:TextBox ID="txtContraseñaNueva" runat="server" CssClass="form-control" TextMode="Password" placeholder="*********"></asp:TextBox>
            </div>
        </div>
        <div class="row m-3 justify-content-center">
            <div class="col-md-6">
                <asp:Label ID="lblContraseñaConfirmar" runat="server" CssClass="form-label"><b>Confirmar contraseña</b> </asp:Label>
                <asp:TextBox ID="txtContraseñaNuevaConfirmar" runat="server" CssClass="form-control" TextMode="Password" placeholder="*********"></asp:TextBox>
                <br />
                <a href="..\Default.aspx" class="btn btn-secondary">Cancelar</a>
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary"/>
            </div>
        </div>
    </form>

</asp:Content>
