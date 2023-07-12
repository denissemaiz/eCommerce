<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PanelUsuario.aspx.cs" Inherits="eCommerce.PanelUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link rel="stylesheet" type="text/css" href="EstiloPanelUser.css">
  <script src="https://kit.fontawesome.com/acc2095c9d.js" crossorigin="anonymous"></script>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />


<body>
  <div class="contenedorxd">
    
    <div class="container-barras">

        <div class="BarraLateral">
          <h2><b>Datos personales</b></h2>
          <asp:Button ID="BtnEditarDatosPersonales" runat="server" Text="Editar" CssClass="EditarDatos" />
          <ul>
            <li><i class="fa-regular fa-user"></i> Nombre Apellido</li>
            <li><i class="fa-regular fa-envelope"></i> Mail</li>
            <li><i class="fa-solid fa-phone"></i>Telefono</li>
          </ul>
        </div>
    
        <div class="BarraLateralDos">
            <h2><b>Direccion</b></h2>
            <asp:Button ID="BtnEditarDireccion" runat="server" Text="Editar" CssClass="EditarDireccion" />
            <ul>
              <li><i class="fa-solid fa-location-dot"></i> Calle, Direccion</li>
              <li>Localidad, Codigo postal</li>
              <li>Provincia</li>
            </ul>
          </div>
    </div>

    <div class="Centralxd">
      <h2><b>Pedidos</b></h2>
      <p>Aca van los pedidos</p>
    </div>

  </div>
</body>

</asp:Content>
