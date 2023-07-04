<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="eCommerce.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>

        * {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

body {
    font-family: 'Poppins', sans-serif;
    max-width: 1200px;
    margin: 0 auto;
}

img {
    max-width: 100%;
}

main {
    display: flex;
    gap: 30px;
    margin-bottom: 80px;
}

.contenedor-imagen {
    flex: 1;
}

.contenedor-infoproducto {
    flex: 1;
    display: flex;
    justify-content: center;
    flex-direction: column;
    
}

.contenedor-infoproducto li {
    padding-bottom: 10px;
}

.contenedor-precio {
    padding-bottom: 10px;
}

.contenedor-precio span {
    font-size: 24px;
    font-weight: 300px;
}

.contenedor-detalles {
    padding: 15px 0;

}

.contenedor-agregarproducto {
    display: flex;
    gap: 20px;
    padding-bottom: 30px;

}

.btn-add-al-carrito {
    border: none;
    padding: 10px;
    background-color: cornflowerblue;
    color: aliceblue;
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 5px;
    font-weight: 700;
    cursor: pointer;
 
}

.btn-add-al-carrito:hover {
    color: black;

}

.contenedor-descripcion{


display: flex;
flex-direction: column;
padding: 10px 0;

}

.titulo-descripcion{

display: flex;
align-items: center;
justify-content: space-between;

}

.text-descripcion{

padding-bottom: 20px;
font-size: 15px;
color: rgb(121, 38, 38);
line-height: 22px;
margin-top: 22px;
}

.contenedor-detalles ul
{
    padding: 0;
}


    </style>



    <body>
    <main>

        <div class="contenedor-imagen">
            <img src="https://http2.mlstatic.com/D_NQ_NP_684301-MLA52624250137_112022-O.webp"
                alt="https://plantillasdememes.com/img/plantillas/imagen-no-disponible01601774755.jpg">
        </div>

        <div class="contenedor-infoproducto">
            <div class="contenedor-precio">
                <span><b>Precio:</b></span>
            </div>

            <div class="contenedor-detalles">

                <ul style="list-style: none;">
                    <li>
                        <b>Nombre:</b>
                    </li>
                    <li>
                        <b>Genero:</b>
                    </li>
                    <li>
                        <b>Codigo:</b>
                    </li>
                    <li>
                        <b>Autor/es:</b>
                    </li>
                </ul>

            </div>

            <div class="contenedor-descripcion">

                <div class="titulo-descripcion">

                    <h4><b>Descripcion</b></h4>

                </div>

                <div class="text-descripcion">
                    <p>

                        Lorem ipsum dolor sit amet. Ut nostrum dolorum ex placeat reiciendis quo natus deserunt ab alias
                        maiores. Ea itaque enim ut illum fuga vel quidem excepturi et quas impedit eos architecto
                        praesentium. Et tenetur facere ut dolorem perferendis non consequuntur autem. In cumque
                        dignissimos sit dolorem illum eos placeat placeat hic aspernatur minus est modi doloremque vel
                        nostrum facilis.

                        Cum enim quae ut harum beatae ad facere repellat. Ut rerum suscipit ut consequuntur esse aut
                        voluptatibus neque ut repellendus eaque.

                        Et corporis enim et rerum amet est quia deserunt id facere itaque. Aut nostrum quod eos animi
                        incidunt non nobis blanditiis sit quibusdam laudantium. Eos reprehenderit exercitationem quo
                        necessitatibus unde 33 nostrum dolores est fugiat asperiores quo aliquam cumque. Et sint maiores
                        et eaque voluptas hic doloremque quasi?
                    
                    </p>

                </div>

            </div>

            <div class="contenedor-agregarproducto">
                <button class="btn-add-al-carrito">
                    Agregar al carrito
                </button>
            </div>

        </div>

    </main>

</body>





</asp:Content>
