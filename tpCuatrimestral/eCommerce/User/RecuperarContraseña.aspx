<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="eCommerce.User.RecuperarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <form class="">
        <div class="row m-3 justify-content-center">
            <div class="col-md-6">
                <asp:Label ID="LblContraseña" runat="server" CssClass="form-label"><b>Nueva contraseña</b></asp:Label> 
                <asp:TextBox ID="txtContraseñaNueva" runat="server" CssClass="form-control" TextMode="Password" placeholder="*********" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContraNueva" runat="server"
                    ControlToValidate="txtContraseñaNueva"
                    Display="Dynamic"
                    CssClass="invalid-feedback"
                    ErrorMessage="Debe ingresar su nueva contraseña"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row m-3 justify-content-center">
            <div class="col-md-6">
                <asp:Label ID="lblContraseñaConfirmar" runat="server" CssClass="form-label"><b>Confirmar contraseña</b> </asp:Label>
                <asp:TextBox ID="txtContraseñaNuevaConfirmar" runat="server" CssClass="form-control" TextMode="Password" placeholder="*********" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConfPass" runat="server"
                    ControlToValidate="txtContraseñaNuevaConfirmar"
                    Display="Dynamic"
                    CssClass="invalid-feedback"
                    ErrorMessage="Debe confirmar su nueva contraseña"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpvConfPass" runat="server"
                    ControlToValidate="txtContraseñaNuevaConfirmar"
                    ControlToCompare="txtContraseñaNueva"
                    Display="Dynamic"
                    CssClass="invalid-feedback"
                    ErrorMessage="Contraseñas ingresadas no coinciden"
                    ForeColor="Red"></asp:CompareValidator>
                <br />
                <a href="..\Default.aspx" class="btn btn-secondary">Cancelar</a>
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <asp:Label ID="lblMensaje" Visible="false" runat="server" CssClass="form-label" ForeColor="Red"><b></b></asp:Label>
            </div>
        </div>
    </form>

</asp:Content>
