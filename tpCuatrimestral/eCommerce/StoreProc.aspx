<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="StoreProc.aspx.cs" Inherits="eCommerce.StoreProc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="DVGLibros"  runat="server" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="DVGLibros_SelectedIndexChanged" OnSelectedIndexChanging="DVGLibros_SelectedIndexChanging">

        <Columns>

            <asp:BoundField Headertext="Codigo" Datafield="Codigo"  />
            <asp:BoundField Headertext="Titulo" Datafield="Titulo"  />
            <asp:BoundField Headertext="Precio" Datafield="Precio"  />
            <asp:BoundField Headertext="Stock" Datafield="Stock"  />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Modificar" />

        </Columns>
    </asp:GridView>


</asp:Content>
