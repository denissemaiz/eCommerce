<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ReporteVentas.aspx.cs" Inherits="eCommerce.ReporteVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgVentas" runat="server">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="Id"  Css/>
            
        </Columns>
    </asp:GridView>
</asp:Content>
