<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuGerente.aspx.cs" Inherits="TiendaZapatillas.Gerente.MenuGerente" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .game-board {
            display: grid;
            grid-template-rows: 20em 20em; /* Aumenta la altura */
            grid-template-columns: 20em 20em; /* Aumenta el ancho */
            grid-gap: 2em;
            justify-content: center; /* Centra los botones horizontalmente */
            align-content: center; /* Centra los botones verticalmente */
        }

        .game-board a {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            text-align: center;
            background-color: #343a40; /* Color de fondo de los botones */
            color: #fff; /* Color de texto */
            border-radius: 1em;
            text-decoration: none;
        }

        .game-board a:hover {
            background-color: #212529; /* Cambia el color de fondo al pasar el mouse */
        }

        .game-board span {
            margin-top: 2em;
            font-size:1.4em
        }
    </style>

    <div class="game-board">
        <a class="btn btn-dark rounded-3" href="Clientes.aspx" runat="server">
            <asp:Image ImageUrl="~/Images/marcas0.png" runat="server" Height="170px" />
            <span>Clientes</span>
        </a>
        <a class="btn btn-dark rounded-3" runat="server" href="Reportes.aspx">
            <asp:Image ImageUrl="~/Images/tipos20.png" runat="server" Height="170px" />
            <span>Reportes</span>
        </a>
        <a class="btn btn-dark rounded-3" href="Transacciones.aspx" runat="server">
            <asp:Image ImageUrl="~/Images/productos20.png" runat="server" Height="170px" />
            <span>Transacciones</span>
        </a>
        <a class="btn btn-dark rounded-3" href="EstadisticasAdmin.aspx" runat="server">
            <asp:Image ImageUrl="~/Images/productos20.png" runat="server" Height="170px" />
            <span>Estadisticas</span>
        </a>
      <%--  <a class="btn btn-dark rounded-3" href="ProductosGerente.aspx" runat="server">
            <asp:Image ImageUrl="~/Images/productos20.png" runat="server" Height="170px" />
            <span>Productos</span>
        </a>
        <a class="btn btn-dark rounded-3" runat="server">
            <asp:Image runat="server" Height="170px" />
            <span></span>
        </a>--%>
    </div>
</asp:Content>
