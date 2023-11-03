<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TiendaZapatillas.Gerente.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
         <br />
         <h2>Usuarios</h2>
         <p>Todos los usuarios registrados en la pagina</p>
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

              <br />

                <h3>Top Usuarios</h3>
                 <p>Se muestran los usuarios que mas compraron dentro de la pagina</p>

                      <asp:GridView ID="Grid_top_clientes" BorderStyle="None" runat="server"
                          CssClass="grid" ShowHeaderWhenEmpty="true"
                          AutoGenerateColumns="false">
                          <HeaderStyle  Font-Bold="True"
                                      ForeColor="black"  />
                         
                          <Columns>
                                <asp:TemplateField HeaderText="Cliente">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Cliente") %>'
                                            runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gastó">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Compras") %>'
                                            runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               

                            </Columns>
                      </asp:GridView>


         </div>
</asp:Content>
