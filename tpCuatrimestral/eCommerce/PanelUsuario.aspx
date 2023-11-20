﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PanelUsuario.aspx.cs" Inherits="eCommerce.PanelUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link rel="stylesheet" type="text/css" href="Styles\EstiloPanelUser.css">
  <script src="https://kit.fontawesome.com/acc2095c9d.js" crossorigin="anonymous"></script>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
       
        <%if (Session["Usuario"] != null)
            { %>
            

            <div class="contenedorxd">
                <div class="container-barras">

                    <div class="BarraLateral">
                        <h2><b>Datos personales</b></h2>                      
                        <div class="row mb-2">
                            <label for="txbNombres" class="col-sm-1 col-form-label"><i class="fa-regular fa-user"></i></label>
                            <div class="col">
                                <asp:TextBox ID="txbNombres" runat="server"
                                    Enabled="false"
                                    CssClass="form-control"
                                    placeholder="Nombres"></asp:TextBox>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txbApellidos" runat="server"
                                    Enabled="false"
                                    CssClass="form-control"
                                    placeholder="Apellidos"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <label for="txbTelefono" class="col-sm-1 col-form-label"><i class="fa-solid fa-phone"></i></label>
                            <div class="col-sm-11">
                                <asp:TextBox ID="txbTelefono" runat="server"
                                    Enabled="false"
                                    CssClass="form-control"
                                    placeholder="Telefono"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revTelefono" runat="server"
                                    ControlToValidate="txbTelefono"
                                    ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"
                                    ForeColor="Red"
                                    CssClass="invalid-feedback"
                                    ErrorMessage="Solo se aceptan numeros"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <label for="txbMail" class="col-sm-1 col-form-label"><i class="fa-regular fa-envelope"></i></label>
                            <div class="col-sm-11">
                                <asp:TextBox ID="txbMail" runat="server"
                                    Enabled="false"
                                    CssClass="form-control"
                                    TextMode="Email"
                                    placeholder="E-Mail"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMail" runat="server"
                                        ControlToValidate="txbMail"
                                        Display="Dynamic"
                                        CssClass="invalid-feedback"
                                        ForeColor="Red"
                                        Text="Debe ingresar su dirección de correo electronico"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <asp:Button ID="BtnEditarDatosPersonales" runat="server" 
                            Text="Editar" 
                            CssClass="EditarDatos" 
                            OnClick="BtnEditarDatosPersonales_Click"/>

                           <asp:Button ID="btnCambiarPass" runat="server" 
                               Text="Cambiar contraseña" 
                               CssClass="EditarDatos" 
                               OnClick="BtonCambiarContraseña_Click"/>

                        <asp:Button ID="btnCancelarEditarDatosPersonales" runat="server"
                            Enabled="false"
                            Visible="false" 
                            CausesValidation="false"
                            Text="Cancelar"
                            CssClass="btn btn-secondary"
                            OnClick="btnCancelarEditarDatosPersonales_Click"/>
                        <asp:Button ID="btnGuardarDatosPersonales" runat="server"
                            Text="Guardar"
                            CssClass="btn btn-primary"
                            Enabled="false"
                            Visible="false" 
                            OnClick="btnGuardarDatosPersonales_Click"/>
                        
                    </div>

                    <div class="BarraLateralDos">
                        <h2><b>Direccion</b></h2>
                        <%if (user.DireccionUsuario != null)
                            { %>
                            <div class="row mb-2">
                                <label for="txbCalle" class="col-sm-1 col-form-label"><i class="bi bi-signpost"></i></label>
                                <div class="col">
                                    <asp:TextBox ID="txbCalle" runat="server"
                                        Enabled="false"
                                        CssClass="form-control"
                                        placeholder="Calle"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCalle" runat="server"
                                        ControlToValidate="txbCalle"
                                        Display="Dynamic"
                                        CssClass="invalid-feedback"
                                        ForeColor="Red"
                                        Text="Debe ingresar un nombre de calle"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col">
                                    <asp:TextBox ID="txbAltura" runat="server"
                                        Enabled="false"
                                        CssClass="form-control"
                                        placeholder="Altura"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAltura" runat="server"
                                        ControlToValidate="txbAltura"
                                        Display="Dynamic"
                                        CssClass="invalid-feedback"
                                        ForeColor="Red"
                                        Text="Debe ingresar el numero de su dirección"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revAltura" runat="server"
                                        ControlToValidate="txbAltura"
                                        ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"
                                        ForeColor="Red"
                                        CssClass="invalid-feedback"
                                        ErrorMessage="Solo se aceptan numeros"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="row mb-2">                              
                                <label for="txbLocalidad" class="col-sm-1 col-form-label"><i class="fa-solid fa-city"></i></label>
                                <div class="col">
                                    <asp:TextBox ID="txbLocalidad" runat="server"
                                        Enabled="false"
                                        CssClass="form-control"
                                        placeholder="Localidad"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server"
                                        ControlToValidate="txbLocalidad"
                                        Display="Dynamic"
                                        CssClass="invalid-feedback"
                                        ForeColor="Red"
                                        Text="Debe ingresar el nombre de su localidad"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col">
                                    <asp:TextBox ID="txbCp" runat="server"
                                        Enabled="false"
                                        CssClass="form-control"
                                        placeholder="Cp"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCp" runat="server"
                                        ControlToValidate="txbCp"
                                        Display="Dynamic"
                                        CssClass="invalid-feedback"
                                        ForeColor="Red"
                                        Text="Debe ingresar su código postal"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revCp" runat="server"
                                        ControlToValidate="txbCp"
                                        ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"
                                        CssClass="invalid-feedback"
                                        ForeColor="Red"
                                        ErrorMessage="Solo se aceptan numeros"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <label for="txbProvincia" class="col-sm-1 col-form-label"><i class="bi bi-map"></i></label>
                                <div class="col">
                                    <asp:TextBox ID="txbProvincia" runat="server" 
                                        Enabled="false"
                                        CssClass="form-control"
                                        placeholder="Provincia"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvProvincia" runat="server"
                                        ControlToValidate="txbProvincia"
                                        Display="Dynamic"
                                        CssClass="invalid-feedback"
                                        ForeColor="Red"
                                        Text="Debe ingresar el nombre de su provincia"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <asp:Button ID="BtnEditarDireccion" runat="server" 
                                Text="Editar"
                                CssClass="EditarDireccion" 
                                OnClick="BtnEditarDireccion_Click"/>

                            <asp:Button ID="btnCancelarEdicionDire" runat="server"
                                Enabled="false"
                                Visible="false"
                                CausesValidation="false"
                                Text="Cancelar"
                                CssClass="btn btn-secondary" 
                                OnClick="btnCancelarEdicionDire_Click"/>

                            <asp:Button ID="btnGuardarDireccion" runat="server"
                                Enabled="false"
                                Visible="false"
                                Text="Guardar"
                                CssClass="btn btn-primary" 
                                OnClick="btnGuardarDireccion_Click"/>
                                
                            
                        <%} else { %>
                            <h5>Usted no ha cargado su dirección todavía</h5>
                            <asp:Button ID="btnCargar" runat="server" 
                                Text="Cargar" 
                                CssClass="EditarDireccion" 
                                OnClick="btnCargar_Click"/>


                        <%} %>
                    </div>

                    

                </div>

                <div class="Centralxd">
                    <h2><b>Pedidos</b></h2>
                    <asp:GridView ID="DGVPedidos" runat="server"
                        DataKeyNames="Id"
                        CssClass="table"
                        AutoGenerateColumns="false"
                        OnLoad="DGVPedidos_Load"
                        OnSelectedIndexChanged="DGVPedidos_SelectedIndexChanged"
                        OnSelectedIndexChanging="DGVPedidos_SelectedIndexChanging"
                        OnRowDataBound="DGVPedidos_RowDataBound">
                        <Columns>                            
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Button ID="btnVer" runat="server" Text="Ver" OnClick="btnVer_Click" CommandArgument='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="ID" DataField="Id" />  
                            <asp:BoundField HeaderText="Fecha" DataField="FechaCompra" />                         
                            <asp:BoundField HeaderText="Estado" DataField="Estado" />
                            <asp:CommandField HeaderText="Cancelar" ShowSelectButton="true" SelectText="Cancelar" />
                        </Columns>
                    </asp:GridView>
                </div>
            
            </div>
        <%} else { %>
                <div class="div row align-self-center">
				        <h1>Necesita estar logueado para acceder a esta página</h1>
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
