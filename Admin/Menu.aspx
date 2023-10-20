<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TiendaZapatillas._Default" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server" >
                    <style>
                        .game-board {
                    display: grid;
                    grid-template-rows: 15em 15em;
                    grid-template-columns: 15em 15em 15em 15em;
                    grid-gap:1em;
                }


                    </style>
                <div class="game-board" style="margin-left:18%;">
                    <a class="btn btn-dark rounded-3" href="CategoriaAdmin.aspx" runat="server" >
                        <p></p>
                        <asp:Image ImageUrl="~/Images/categorias7.png" runat="server" Height="130px" />
                        <p></p>
                     <span>Categoria</span>
                    </a>
                     <a class="btn btn-dark rounded-3" runat="server" href="CategoriaTipo.aspx">
                        <p></p>
                        <asp:Image ImageUrl="~/Images/categories.png" runat="server" Height="130px" />
                        <p> </p>
                    <span>Tipo de zapatillas</span>
                    </a>
                    <a class="btn btn-dark rounded-3" href="ProductosAdmin.aspx" runat="server">
                        <p></p>
                        <asp:Image ImageUrl="~/Images/productos7.png" runat="server" Height="130px" />
                        <p></p>
                    <span>Productos</span>
                    </a>          
                </div>
</asp:Content>
