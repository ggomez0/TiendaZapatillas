<%@ Page Title="Estadisticas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadisticasAdmin.aspx.cs" Inherits="TiendaZapatillas.Gerente.EstadisticasAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
        <div class="container">
            <br />
            <h3>Top Productos</h3>
            <p>Los productos más vendidos en la pagina</p>
            <asp:GridView ID="Grid_top_productos" BorderStyle="None" runat="server"
                CssClass="grid" ShowHeaderWhenEmpty="true"
                AutoGenerateColumns="false">
                <HeaderStyle BackColor="black" Font-Bold="True"
                            ForeColor="White"  />
                <Columns>
                    <asp:TemplateField HeaderText="#">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ProductID") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>

                            <img class="card-img-top" src="/Images/Thumbs/<%#:Eval("Imagepath") %>" style="
                            object-fit:contain; width:5em;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ProductName") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>                   
                    <asp:TemplateField HeaderText="Descripcion">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Description") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vendidos">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("vendido") %>'
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

          
        </div>
    
</asp:Content>
