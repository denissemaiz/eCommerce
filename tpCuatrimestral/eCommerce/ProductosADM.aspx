<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ProductosADM.aspx.cs" Inherits="eCommerce.ProductosADM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <div class="row row-cols-1 row-cols-md-3 g-4">      
        
      <asp:Repeater ID="Repetidor" runat="server">

    <ItemTemplate>
             <div class="col">
                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title ms-1"><%#Eval("Titulo") %></h5>
                            <p class="card-text mb-1 ms-1">$<%#Eval("Precio") %></p>
                            <div class="btn-toolbar justify-content-between" role="toolbar" aria-label="Toolbar with button groups">
                                <div class="btn-group me-2" role="group" aria-label="First group">
                                    <asp:Button ID="Btnmod" runat="server" Text="Modificar" CssClass="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <small class="text-body-secondary">Código de artículo: <%#Eval("Codigo") %></small>
                        </div>
                    </div>
                </div>
    </ItemTemplate>

      </asp:Repeater>


    </div>

</asp:Content>
