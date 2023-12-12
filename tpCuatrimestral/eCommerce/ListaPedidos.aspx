<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPedidos.aspx.cs" Inherits="eCommerce.ListaPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (ValidarAdmin())
        { %>

    <asp:GridView ID="DGVPedidos" runat="server"
        DataKeyNames="Id"
        CssClass="table"
        AutoGenerateColumns="false"
        OnLoad="DGVPedidos_Load"
        OnSelectedIndexChanged="DGVPedidos_SelectedIndexChanged"
        OnSelectedIndexChanging="DGVPedidos_SelectedIndexChanging"
        OnRowDataBound="DGVPedidos_RowDataBound">
        <columns>
            <asp:TemplateField HeaderText="Detalle">
                <itemtemplate>
                    <asp:HyperLink ID="hlVer" Text="Ver" runat="server"
                        NavigateUrl='<%#Eval("Id", "Compras/DetallesCompra2.aspx?idCompra={0}") %>'>
                    </asp:HyperLink>
                </itemtemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="ID" DataField="Id" />
            <asp:BoundField HeaderText="Fecha" DataField="FechaCompra" />
            <asp:BoundField HeaderText="Estado" DataField="Estado" />
            <asp:CommandField HeaderText="Cancelar" ShowSelectButton="true" SelectText="Cancelar" />
        </columns>
</asp:GridView>




    <% } %>

</asp:Content>
