<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPedidos.aspx.cs" Inherits="eCommerce.ListaPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" type="text/css" href="Styles/Paginador.css" />

    <%if (ValidarAdmin())
        { %>

        <asp:GridView ID="DGVPedidos" runat="server"
            DataKeyNames="Id"
            CssClass="table table-striped table-bordered table-hover"
            AllowPaging="true"
            AutoGenerateColumns="false"
            OnLoad="DGVPedidos_Load"
            OnSelectedIndexChanged="DGVPedidos_SelectedIndexChanged"
            OnSelectedIndexChanging="DGVPedidos_SelectedIndexChanging"
            OnPageIndexChanging="DGVPedidos_PageIndexChanging"
            OnRowDataBound="DGVPedidos_RowDataBound">
            <columns>
                <asp:TemplateField HeaderText="Detalle">
                    <itemtemplate>
                        <asp:HyperLink ID="hlVer" Text="Ver" runat="server"
                            NavigateUrl='<%#Eval("Id", "Compras/DetallesCompra2.aspx?idCompra={0}&redirect=1") %>'>
                        </asp:HyperLink>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Fecha" DataField="FechaCompra" />
                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                <asp:CommandField HeaderText="Cancelar" ShowSelectButton="true" SelectText="Cancelar" />
            </columns>

            <PagerSettings 
                Mode="Numeric"/>

            <%--<PagerStyle CssClass="pagination-ys" />--%>

        </asp:GridView>




    <% } %>

</asp:Content>
