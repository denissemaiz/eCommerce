<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarGenero.aspx.cs" Inherits="eCommerce.AgregarGenero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <%if (ValidarAdmin()) { %>

    <div class="row">

        <div class="col-md-3">
            <h3>Ingrese el nuevo genero</h3>
            <label for="txt_genero" class="form-label">Nombre: </label>
            <asp:TextBox ID="txt_genero" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="GeneroNombre" runat="server"
                ControlToValidate="txt_genero"
                Display="Dynamic"
                ErrorMessage="Por favor ingrese el genero"
                CssClass="invalid-feedback"
                ForeColor="Red"></asp:RequiredFieldValidator>

            <label for="txt_descripcion" class="form-label">Descripcion: </label>
            <asp:TextBox ID="txt_descripcion" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="GeneroDescripcion" runat="server"
                ControlToValidate="txt_descripcion"
                Display="Dynamic"
                ErrorMessage="Por favor ingrese el genero"
                CssClass="invalid-feedback"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Button ID="Agregar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="Agregar_Click" />
            <div>
                <asp:Label ID="lblagregado" Visible="false" runat="server" Text="Genero agregado con exito!"></asp:Label>
            </div>
        </div>

    </div>
    <% } %>

</asp:Content>
