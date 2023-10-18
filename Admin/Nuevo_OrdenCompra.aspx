﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nuevo_OrdenCompra.aspx.cs" Inherits="ShopGaspar.Admin.Nuevo_OrdenCompra" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
         <h3>Registrar Orden de Compra</h3>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" Font-Bold="true" Text="N° Orden: "></asp:Label>
                                                  </td><td>
                                                      <asp:TextBox runat="server" Enabled="false" ID="txtordid" Width="60%"></asp:TextBox>
                                                      
                                                      </td>
                                                       
                                                        </tr>
                                                        
                                                    <tr>
                                                        <td>
                                                   
                                                            <asp:Label Font-Bold="true" runat="server">Proveedor:</asp:Label>
                                                   </td><td>
                                                            <asp:DropDownList ID="ddlistprov" runat="server" Width="60%"
                                                                ItemType="ShopGaspar.Models.proveedores"
                                                                SelectMethod="GetProveedores" DataTextField="ProvName"
                                                                DataValueField="ProvID">
                                                            </asp:DropDownList>
                                                       </td>
                                                       
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" Text="Fecha Comprobante:">
                                                                </asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" TextMode="Date"
                                                                    style="width:60%" ID="txtcalendar"> </asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        </table>
                                        

<asp:Button runat="server" ID="btnagregarprodfact" Text="+ Producto" CssClass="btn btn-success" />
                                             


                        <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel21"
                            TargetControlID="btnagregarprodfact" CancelControlID="btncerrarprodfact" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="Panel21" runat="server" CssClass="modalPopup" align="center"
                            Style="background-color:white; border:solid; border-color:black; height:80%; width:80%; overflow:auto">
                            <div style="padding:20px;">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
         <h3>Seleccione los productos</h3>
        
        <asp:GridView runat="server" CssClass="grid" BorderStyle="None" 
            ID="gvproductoslista" ShowHeaderWhenEmpty="true" AutoGenerateColumns="true" DataKeyNames="ID" OnRowUpdating="gvproductoslista_RowUpdating">
            <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    
                      <asp:Button ID="Button5" CssClass="btn btn-success rounded-3"  runat="server" Text="+" CommandName="Update"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cant.">
                    <ItemTemplate>
                    <asp:TextBox ID="txtcantfact" runat="server" TextMode="Number" Width="50px"></asp:TextBox>
                    
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio">
                    <ItemTemplate>
                    <asp:TextBox ID="txtpricefact" runat="server" TextMode="Number" Width="100px"  ></asp:TextBox>
                       
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                </div>
                            
                                                        <asp:Button ID="btncerrarprodfact"
                                                            CssClass="btn btn-danger rounded-3" runat="server"
                                                            Text="Cerrar" ValidationGroup="VG107" />
                        </asp:Panel>

        <asp:GridView runat="server" CssClass="grid" BorderStyle="None" 
            ID="gvprodfact" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnRowDeleting="gvprodfact_RowDeleting" DataKeyNames="idcomprdet">
    
            <Columns>
                <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("idcomprdet") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
             
                <asp:TemplateField HeaderText="Producto">
                    <ItemTemplate>
                        <asp:Label ID="lblprodmov"  Text='<%# Eval("ProductName") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:Label  Text='<%# Eval("cantidad") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio">
                    <ItemTemplate>
                        <asp:Label  Text=<%#:String.Format("{0:c}", Eval("precio"))%> runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <asp:Label Text=<%#:String.Format("{0:c}", Eval("Total"))%> runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ImageUrl="~/Images/delete.png" Height="30px" CommandName="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


            <asp:Button ID="btnguardarfact" OnClick="btnguardarfact_Click"  CssClass="btn btn-info rounded-3" runat="server"  Text="Guardar" CausesValidation="true" ValidationGroup="VG2481"/>
        </div>

    <asp:Label runat="server" ID="lblSuccessMessage"></asp:Label>
    <asp:Label runat="server" ID="lblErrorMessage"></asp:Label>
</asp:Content>
