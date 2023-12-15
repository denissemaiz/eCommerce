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
<div class="w3-content" style="max-width:100%">

<!-- Header -->
<div">
<div class="w3-clear"></div>
<header class="w3-center w3-margin-bottom">
  <h1><b>Bienvenidos</b></h1>
  <p><b>Conozca nuestros libros en stock.</b></p>
    <p class="w3-padding-16">
    <a href="Productos.aspx" class="w3-button w3-black"> Catalogo</a>
    </p>
</header>
</div>

<!-- Photo Grid -->
<div class="w3-row-padding" id="myGrid" style="margin-bottom:128px">
  <div class="w3-third">
    <img src="http://www.lesvraisvoyageurs.com/wp-content/uploads/2020/04/Julio-Cort%C3%A1zar.-Madrid-1980-706x1024.jpg" alt="Julio Cortázar" style="width:100%">
    <img src="https://wmagazin.com/wp-content/uploads/2021/04/Cronicadeunamuerteanunciada-Colombia-1-633x1024.jpg" alt="Cronica de una muerte anunciada" style="width:100%">
    <img src="https://pablobedrossian.files.wordpress.com/2021/09/jorge-luis-borges-01.jpg" alt="Jorge Luis Borges" style="width:100%">
    <img src="https://cdn.culturagenial.com/es/imagenes/neruda-cke.jpg" alt="Pablo Neruda" style="width:100%">
    <img src="https://assets-global.website-files.com/6034d7d1f3e0f52c50b2adee/625453f86f695c42fd66a883_6228e16ec46732b86f7d1aa0_9788418395796.jpeg" style="width:100%">
    <img src="https://www.penguinrandomhousegrupoeditorial.com/wp-content/uploads/2023/05/gabriel-garcia-marquez-penguinrandomhousegrupoeditorial-1024x1024.jpg" alt="Gabriel García Márquez" style="width:100%">
  </div>

  <div class="w3-third">
    <img src="https://http2.mlstatic.com/D_NQ_NP_884290-MLC46642291217_072021-O.webp" style="width:100%">
    <img src="https://colecciones.lanacion.com.ar/wp-content/uploads/2023/02/TIENDA_Coleccion_Isabel-Allende_2023_VENTA_640x550.jpg" style="width:100%">
    <img src="https://libroschorcha.files.wordpress.com/2018/01/la-ciudad-y-los-perros-mario-vargas-llosa.jpg" style="width:100%">
    <img src="https://www.anagrama-ed.es/uploads/media/portadas/0001/19/61a262954208d59d9d103c74c64be29d87c32582.jpeg" style="width:100%">
    <img src="https://i.ibb.co/CpLBLCy/z.jpg" style="width:100%">
  </div>

  <div class="w3-third">
    <img src="https://media.admagazine.com/photos/618a6aabac089e092dcc0283/master/w_1600%2Cc_limit/62420.jpg" style="width:100%">
    <img src="https://upload.wikimedia.org/wikipedia/commons/9/94/Silvina-tomado-por-Bioy-Casares-en-Posadas-1959.jpg" style="width:100%">
    <img src="https://assets1.bmstatic.com/assets/books-covers/e2/38/cMjpdbPA-ipad.jpeg" style="width:100%">
    <img src="https://cdn.sanity.io/images/p34gzxcg/production/5d7515af3b9d7928ebbfac51e492d32fe00c1c53-600x805.jpg?auto=format&w=1000&fit=scale" style="width:100%">
    <img src="https://i.ibb.co/qBjgCfP/zz.jpg" style="width:100%" >
  </div>
</div>

</div>
    


</body>
</html>


</asp:Content>
