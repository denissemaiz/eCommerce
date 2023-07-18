<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="eCommerce.User.CambiarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form class="">
        <div class="row m-3 justify-content-center">
            <div class="col-md-6">
                <asp:Label ID="LblContraseñaActual" runat="server" CssClass="form-label"><b>Contraseña actual</b></asp:Label>
                <asp:TextBox ID="txbContraseñaActual" runat="server" 
                    CssClass="form-control" 
                    TextMode="Password" 
                    placeholder="*********">
                </asp:TextBox>
                <asp:Label ID="lblErrorCoincidencia" runat="server"
                    Visible="false"
                    CssClass="invalid-feedback"></asp:Label>
                <asp:RequiredFieldValidator ID="rfvContraseñaActual" runat="server"
                    ControlToValidate="txbContraseñaActual"
                    Display="Dynamic"
                    ErrorMessage="Debe ingresar su contraseña actual"
                    CssClass="invalid-feedback"
                    ForeColor="Red"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row m-3 justify-content-center">
            <div class="col-md-6">
                <asp:Label ID="LblContraseñaNueva" runat="server" CssClass="form-label"><b>Nueva contraseña</b></asp:Label>
                <asp:TextBox ID="txbContraseñaNueva" runat="server" 
                    CssClass="form-control" 
                    TextMode="Password" 
                    placeholder="*********"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContraNueva" runat="server"
                    ControlToValidate="txbContraseñaNueva"
                    Display="Dynamic"
                    ErrorMessage="Debe ingresar una nueva contraseña"
                    CssClass="invalid-feedback"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row m-3 justify-content-center">
            <div class="col-md-6">
                <asp:Label ID="lblContraseñaConfirmar" runat="server" CssClass="form-label"><b>Confirmar contraseña</b> </asp:Label>
                <asp:TextBox ID="txbContraseñaNuevaConfirmar" runat="server" 
                    CssClass="form-control" 
                    TextMode="Password" 
                    placeholder="*********"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConfContra" runat="server"
                    ControlToValidate="txbContraseñaNuevaConfirmar"
                    Display="Dynamic"
                    ErrorMessage="Debe confirmar su nueva contraseña"
                    CssClass="invalid-feedback"
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <a href="..\Default.aspx" class="btn btn-secondary">Cancelar</a>
                <asp:Button ID="btnAceptar" runat="server" 
                    Text="Aceptar" 
                    CssClass="btn btn-primary"
                    OnClick="btnAceptar_Click"/>
            </div>
        </div>
    </form>

</asp:Content>
