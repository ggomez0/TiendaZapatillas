<%@ Page Title="Detalle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetMovimiento.aspx.cs" Inherits="TiendaZapatillas.Admin.DetMovimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
         <asp:FormView ID="movID" runat="server" ItemType="TiendaZapatillas.Models.movimientos" SelectMethod ="GetMovimiento" RenderOuterTable="false" >
                            <ItemTemplate>
                                <div>
                                    <h1>Detalle del movimiento N° <%#:Item.ID_Movimiento %></h1>
                                </div>
                                <br />
                                <table>
                                   <tr>
                                       <td>
                                           <asp:Label runat="server" Font-Bold="true" Text="Tipo de movimiento:"></asp:Label>
                                        </td>
                                        <td>                  
                                           <span style="font-size:1em"><%#Item.Nombre %></span>
                                        </td>
                                         <tr>
                                             <td>
                                                 <asp:Label runat="server" Font-Bold="true" Text="Observacion:"></asp:Label>
                                             </td>
                                        <td>
                                                <span style="font-size:1em"><%#Item.descripcion %></span>
                                        </td>
                                             </tr>
                                       <tr>
                                           <td>
                                               <asp:Label runat="server" Font-Bold="true" Text="Fecha:"></asp:Label>
                                           </td>
                                           <td>
                                              <span style="font-size:1em"><%#Item.dateTime %></span>
                                           </td>
                                           </tr>
                                       <tr>
                                           <td>
                                           <asp:Label runat="server" Font-Bold="true" Text="Deposito:"></asp:Label>

                                           </td>
                                           <td>
                                             <span style="font-size:1em"><%#:Item.stringn %></span><br />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:FormView>
                       
        <asp:GridView runat="server" CssClass="grid" BorderStyle="None" ID="gv_detmov" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">
            <Columns>
                         <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("ID_Det_Movimientos") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
             
                <asp:TemplateField HeaderText="Producto">
                    <ItemTemplate>
                        <asp:Label ID="lblprodmov"  Text='<%# Eval("ProductName") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:Label ID="lblcantmov" Text='<%# Eval("cantidad") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
