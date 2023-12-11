<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarAutor.aspx.cs" Inherits="eCommerce.AgregarAutor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%if (ValidarAdmin())
        { %>


    <div class="row">

        <div class="col-md-3">
            <h3>Ingrese el nuevo autor</h3>
            <asp:TextBox ID="txt_autornombre" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Autornombre" runat="server"
                ControlToValidate="txt_autornombre"
                Display="Dynamic"
                ErrorMessage="Por favor ingrese el nombre"
                CssClass="invalid-feedback"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txt_autorapellido" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Autorapellido" runat="server"
                ControlToValidate="txt_autorapellido"
                Display="Dynamic"
                ErrorMessage="Por favor ingrese el apellido"
                CssClass="invalid-feedback"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Button ID="Agregar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="Agregar_Click" />
            <div>
                <asp:Label ID="lblagregado" Visible="false" runat="server" Text="Autor agregado con exito!"></asp:Label>
                <asp:Label ID="Lblfallo" Visible="false" runat="server" Text="El autor ya existe"></asp:Label>
            </div>
        </div>
    </div>
    <% } %>
</asp:Content>
