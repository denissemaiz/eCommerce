<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ReporteVentas.aspx.cs" Inherits="eCommerce.ReporteVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgVentas" runat="server" 
        AutoGenerateColumns="false"
        CssClass="table">
        <Columns>
            <asp:BoundField DataField="Mes" HeaderText="Mes" />
            <asp:BoundField DataField="MontoTotalMes" HeaderText="Monto Total" DataFormatString="${0:N2}" />
            <asp:BoundField DataField="NumeroDeVentas" HeaderText="Ventas" />
        </Columns>
    </asp:GridView>
</asp:Content>
