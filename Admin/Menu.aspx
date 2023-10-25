<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TiendaZapatillas._Default" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .game-board {
            display: grid;
            grid-template-rows: 20em; /* Aumenta la altura */
            grid-template-columns: 20em 20em 20em; /* Aumenta el ancho */
            grid-gap: 3em;
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
            padding: 1em;
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
        <a class="btn btn-dark rounded-3" href="GestionMarcas.aspx" runat="server">
            <asp:Image ImageUrl="~/Images/marcas20.png" runat="server" Height="170px" />
            <span>Marcas</span>
        </a>
        <a class="btn btn-dark rounded-3" runat="server" href="CategoriaTipo.aspx">
            <asp:Image ImageUrl="~/Images/tipos20.png" runat="server" Height="170px" />
            <span>Tipo de zapatillas</span>
        </a>
        <a class="btn btn-dark rounded-3" href="ProductosAdmin.aspx" runat="server">
            <asp:Image ImageUrl="~/Images/productos20.png" runat="server" Height="170px" />
            <span>Productos</span>
        </a>
        <a class="btn btn-dark rounded-3" href="IngEgrAdmin.aspx" runat="server">
            <asp:Image ImageUrl="~/Images/productlos20.png" runat="server" Height="170px" />
            <span>Stock</span>
        </a>
        <a class="btn btn-dark rounded-3" href="DepositosAdmin.aspx" runat="server">
            <asp:Image ImageUrl="~/Images/producftos20.png" runat="server" Height="170px" />
            <span>Depositos</span>
        </a>
    </div>
</asp:Content>
