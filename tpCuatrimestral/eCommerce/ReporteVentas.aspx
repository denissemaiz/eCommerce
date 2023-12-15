<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ReporteVentas.aspx.cs" Inherits="eCommerce.ReporteVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (ValidarAdmin())
        {  %>
        <div class="container">
            <div class="row gy-2">            
                <div class="col-sm-3">

                    <div class="input-group form-inline">
                        <label for="txtAnio" class="col-sm-2 col-form-label">Año: </label>
                        <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control" placeholder="2023"></asp:TextBox>
                        <asp:Button ID="btnBuscarAnio" runat="server" 
                            OnClick="btnBuscarAnio_Click"
                            CssClass="btn btn-outline-primary" 
                            Text="Buscar" />
                        <asp:RequiredFieldValidator ID="rfvAnio" runat="server"
                            ControlToValidate="txtAnio"
                            Display="Dynamic"
                            ErrorMessage="Debe ingresar año para buscar"
                            CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTelefono" runat="server"
                                        ControlToValidate="txtAnio"
                                        ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"
                                        ForeColor="Red"
                                        CssClass="invalid-feedback"
                                        ErrorMessage="Solo se aceptan numeros"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="col">

                    <asp:GridView ID="dgVentas" runat="server" 
                        AutoGenerateColumns="false"
                        AllowSorting="true"
                        OnSorting="dgVentas_Sorting"                    
                        CssClass="table">                    
                        <Columns>
                            <%--<asp:BoundField DataField="Mes" HeaderText="Mes" 
                                SortExpression="Mes"
                                />--%>
                            <asp:TemplateField HeaderText="Mes" SortExpression="Mes">
                                <ItemTemplate>
                                    <%#NombreMes((Int32)Eval("Mes")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
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
    <%}else{ %>
        <div class="div row align-self-center">
				<h1>Necesita ser un administrador para acceder a esta pagina</h1>
			<div class="col">
				<a href="../Default.aspx" class="btn btn-secondary">Inicio</a>
				<asp:Button ID="btnLogin" runat="server" 
                    Text="Login"
                    CssClass="btn btn-primary"
                    OnClick="btnLogin_Click"/>
			</div>
		</div>            
    <%} %>
</asp:Content>
