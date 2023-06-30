<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ProductosADM.aspx.cs" Inherits="eCommerce.ProductosADM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <div class="row row-cols-1 row-cols-md-3 g-4">              
      <asp:Repeater ID="Repetidor" runat="server">
        <ItemTemplate>
            <div class="col">
                <div class="card h-100">
                    <img src="<%#Eval("PortadaURL") %>" class="card-img-top img-fluid" alt="...">
                    <div class="card-body">
                        <h5 class="card-title ms-1"><%#Eval("Titulo") %></h5>
                        <p class="card-text mb-1 ms-1">$<%#Eval("Precio") %></p>
                        <div class="btn-toolbar justify-content-between" role="toolbar" aria-label="Toolbar with button groups">
                            <div class="btn-group me-2" role="group" aria-label="First group">
                                <a href="Detalle.aspx?cod=<%#Eval("Codigo") %>" class="btn btn-light btn-sm mb-3">Ver detalles</a>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <small class="text-body-secondary">Código: <%#Eval("Codigo") %></small>
                    </div>
                </div>
            </div>
        </ItemTemplate>
      </asp:Repeater>
    </div>
</asp:Content>
