<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TiendaZapatillas.Gerente.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
         <br />
         <h2>Usuarios registrados</h2>
         <br />
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView class="table thead-dark" ID="tablausers"
                                                                runat="server" CssClass="grid"
                                                                AutoGenerateColumns="false" BorderStyle="None"
                                                                BorderWidth="1px" CellPadding="3"
                                                                ShowHeaderWhenEmpty="true" BackColor="White"
                                                                BorderColor="#CCCCCC">
                                                                <HeaderStyle Font-Bold="True"
                                                                ForeColor="ForestGreen"  />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Usuario">
                                                                        <ItemTemplate>
                                                                            <asp:Label Text='<%# Eval("UserName") %>'
                                                                                runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email">
                                                                        <ItemTemplate>
                                                                            <asp:Label Text='<%# Eval("Email") %>'
                                                                                runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Rol">
                                                                        <ItemTemplate>
                                                                            <asp:Label Text='<%# Eval("Rol") %>'
                                                                                runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Compras">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ValidationGroup="valord1"
                                                                                ImageUrl="~/Images/lupa.png" ID="imgord"
                                                                                runat="server"
                                                                                CommandArgument='<%#Eval("UserName") %>'
                                                                                OnClick="imgord_Click" Width="20px"
                                                                                Height="20px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>

                                                            </asp:GridView>

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                </div>
</asp:Content>
