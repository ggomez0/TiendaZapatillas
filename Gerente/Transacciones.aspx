<%@ Page Title="Transacciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transacciones.aspx.cs" Inherits="TiendaZapatillas.Gerente.TransaccionesAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <h2>Transacciones</h2>
        <p>Todas las compras realizadas en la pagina</p>
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:gridview class="table thead-dark" CssClass="grid"
                                                            ID="tablatrans" runat="server" AutoGenerateColumns="false"
                                                            ShowHeaderWhenEmpty="true" BackColor="White"
                                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                            CellPadding="3">
                                                            <HeaderStyle BackColor="black" Font-Bold="True"
                                                                ForeColor="White"  />
                                                     
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label Text='<%# Eval("ID") %>'
                                                                            runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fecha">
                                                                    <ItemTemplate>
                                                                        <asp:Label Text='<%# Eval("Date") %>'
                                                                            runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Usuario">
                                                                    <ItemTemplate>
                                                                        <asp:Label Text='<%# Eval("usuarion") %>'
                                                                            runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total $">
                                                                    <ItemTemplate>
                                                                        <asp:Label Text='<%# Eval("Total") %>'
                                                                            runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Detalles">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ValidationGroup="ordenesval"
                                                                            ImageUrl="~/Images/lupa.png" ID="imgordenes"
                                                                            runat="server"
                                                                            CommandArgument='<%#Eval("ID") %>'
                                                                            OnClick="imgordenes_Click" Width="20px"
                                                                            Height="20px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
</asp:Content>
