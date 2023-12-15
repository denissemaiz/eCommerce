<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ReporteVentas.aspx.cs" Inherits="eCommerce.ReporteVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <div class="row gy-2">            
            <div class="col-sm-3">

                <div class="input-group form-inline">
                    <label for="txtAnio" class="col-sm-2 col-form-label">Año: </label>
                    <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control" placeholder="2023"></asp:TextBox>
                    <asp:Button ID="btnBuscarAnio" runat="server" CssClass="btn btn-outline-primary" Text="Buscar" />
                </div>
            </div>

            <div class="col">

                <asp:GridView ID="dgVentas" runat="server" 
                    AutoGenerateColumns="false"
                    AllowSorting="true"
                    OnSorting="dgVentas_Sorting"
                    CssClass="table">                    
                    <Columns>
                        <asp:BoundField DataField="Mes" HeaderText="Mes" 
                            SortExpression="Mes"/>
                        <asp:BoundField DataField="MontoTotalMes" HeaderText="Monto Total" 
                            DataFormatString="${0:N2}"
                            SortExpression="MontoTotalMes"/>
                        <asp:BoundField DataField="NumeroDeVentas" HeaderText="Ventas" 
                            SortExpression="NumeroDeVentas"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
        <h4>Monto Total: $<asp:Label ID="lblMontoTotal" runat="server" ></asp:Label></h4>
    </div>
</asp:Content>
