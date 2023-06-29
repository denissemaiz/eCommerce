<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="eCommerce.AgregarProducto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

    <div class="row">

        <div class="col-md-3">
            <asp:Label for="txtID" runat="server" CssClass="form-label"><b>ID:</b></asp:Label>
            <asp:TextBox ID="txtID" runat="server" CssClass="form-control"></asp:TextBox>
        </div>


        <div class="col-md-3">
            <asp:Label for="txtCodigo" runat="server" CssClass="form-label"><b>Codigo:</b></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="col-md-3">
            <asp:Label for="txtTitulo" runat="server" CssClass="form-label"><b>Titulo:</b></asp:Label>
            <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>


        <div class="col-md-6">
            <asp:Label for="txtDescripcion" runat="server" CssClass="form-label"><b>Descripcion:</b></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="col-md-3">
            <asp:Label for="txtStock" runat="server" CssClass="form-label"><b>Stock:</b></asp:Label>
            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="col-md-3">
            <asp:Label for="txtPrecio" runat="server" CssClass="form-label"><b>Precio:</b></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="col-md-6">
                    <asp:Label for="txxportadaURL" runat="server" CssClass="form-label"><b>Imagen url:</b></asp:Label>
                    <asp:TextBox ID="txtportadaURL" runat="server" cssclass="form-control" AutoPostBack="true" OnTextChanged="txtportadaURL_TextChanged" >
                    </asp:TextBox>
                </div>
                <asp:Image  ImageUrl="https://plantillasdememes.com/img/plantillas/imagen-no-disponible01601774755.jpg"   ID="ImgPortada" runat="server" width="30%"/>
            </ContentTemplate>
        </asp:UpdatePanel>





    <div class="row m-3">
        <div class="col-md-6">
            <asp:Button ID="BtnAgregar" runat="server" OnClick="BtnAgregar_Click" Text="Agregar" CssClass="btn btn-primary" />
            <a href="Default.aspx" class="btn btn-primary">Volver</a>
        </div>
    </div>

</asp:Content>

