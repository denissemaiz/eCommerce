<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eCommerce.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h2>Informacion de inicio</h2>
    <%if (Session["Usuario"] != null)
            {   %>
        <h3>Usted está Logueado</h3>
      <% } if (Session["mensaje"] != null)
          { %>
            <h3><%:Session["Mensaje"].ToString() %> </h3>
        <%} %>

</asp:Content>
