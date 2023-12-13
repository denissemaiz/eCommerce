<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eCommerce.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <html>
<head>
<title>W3.CSS Template</title>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
body,h1 {font-family: "Montserrat", sans-serif}
img {margin-bottom: -7px}
.w3-row-padding img {margin-bottom: 12px}
</style>
</head>
<body>

<!-- !PAGE CONTENT! -->
<div class="w3-content" style="max-width:1500px">

<!-- Header -->
<div class="w3-opacity">
<span class="w3-button w3-xxlarge w3-white w3-right" onclick="w3_open()"><i class="fa fa-bars"></i></span> 
<div class="w3-clear"></div>
<header class="w3-center w3-margin-bottom">
  <h1><b>PHOTOLIO</b></h1>
  <p><b>A template made by w3.css for photographers.</b></p>
  <p class="w3-padding-16"><button class="w3-button w3-black" onclick="myFunction()">Toggle Grid Padding</button></p>
</header>
</div>

<!-- Photo Grid -->
<div class="w3-row" id="myGrid" style="margin-bottom:128px">
  <div class="w3-third">
    <img src="/w3images/rocks.jpg" style="width:100%">
    <img src="/w3images/sound.jpg" style="width:100%">
    <img src="/w3images/woods.jpg" style="width:100%">
    <img src="/w3images/rock.jpg" style="width:100%">
    <img src="/w3images/nature.jpg" style="width:100%">
    <img src="/w3images/mist.jpg" style="width:100%">
  </div>

  <div class="w3-third">
    <img src="/w3images/coffee.jpg" style="width:100%">
    <img src="/w3images/bridge.jpg" style="width:100%">
    <img src="/w3images/notebook.jpg" style="width:100%">
    <img src="/w3images/london.jpg" style="width:100%">
    <img src="/w3images/rocks.jpg" style="width:100%">
    <img src="/w3images/avatar_g.jpg" style="width:100%">
  </div>

  <div class="w3-third">
    <img src="/w3images/mist.jpg" style="width:100%">
    <img src="/w3images/workbench.jpg" style="width:100%">
    <img src="/w3images/gondol.jpg" style="width:100%">
    <img src="/w3images/skies.jpg" style="width:100%">
    <img src="/w3images/lights.jpg" style="width:100%">
    <img src="/w3images/workshop.jpg" style="width:100%">
  </div>
</div>

</div>

 


</body>
</html>






















    <%if (Session["Usuario"] != null)
            {   %>
        <h3>Usted está Logueado</h3>
      <% } if (Session["mensaje"] != null)
          { %>
            <h3><%:Session["Mensaje"].ToString() %> </h3>
        <%} %>

</asp:Content>
