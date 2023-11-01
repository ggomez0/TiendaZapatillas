<%@ Page Title="Estadisticas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadisticasAdmin.aspx.cs" Inherits="TiendaZapatillas.Gerente.EstadisticasAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
        <div class="container">
            <br />
            <h3>Top Productos</h3>
            <asp:GridView ID="Grid_top_productos" BorderStyle="None" runat="server"
                CssClass="grid" ShowHeaderWhenEmpty="true"
                AutoGenerateColumns="true">
                <HeaderStyle BackColor="black" Font-Bold="True"
                            ForeColor="White"  />

            </asp:GridView>

            <br />

            <h3>Top Clientes</h3>

            <asp:GridView ID="Grid_top_clientes" BorderStyle="None" runat="server"
                CssClass="grid" ShowHeaderWhenEmpty="true"
                AutoGenerateColumns="true">
                <HeaderStyle BackColor="black" Font-Bold="True"
                            ForeColor="White"  />

            </asp:GridView>
        </div>
    
</asp:Content>
