<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TiendaZapatillas.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Estilo para centrar vertical y horizontalmente */
        .centered-image {
            height: 100%;
            width: 100%;
        }
    </style>
    
    <div class="centered-image">
        <a href="https://localhost:44351/ProductDetails?productID=10">
            <img class="d-block img-fluid" src="Images/fulladidascrazyfast.jpg" alt="First slide">
        </a>
    </div>
    <br /><br />
    <div class="container">
        <div class="row">
            <div class="col-sm">
                <a href="ProductList.aspx?Adidas=Adidas">
                    <div class="image-container" style="height:70%; width:70%;">
                        <img class="card-img-top" src="Images/Thumbs/adidaslogo.png" alt="Card image cap">
                        <div class="card-body">
                            <h5 class="card-title text-center"></h5>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col-sm">
                <a href="ProductList.aspx?Nike=Nike">
                    <div class="image-container" style="height:70%; width:70%;">
                        <img class="card-img-top" src="Images/Thumbs/nikelogo.png" alt="Card image cap">
                        <div class="card-body">
                            <h5 class="card-title text-center"></h5>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col-sm">
                <a href="ProductList.aspx?NewBalance=NewBalance">
                    <div class="image-container" style="height:70%; width:70%;">
                        <img class="card-img-top" src="Images/Thumbs/newbalancelogo.png" alt="Card image cap">
                        <div class="card-body">
                            <h5 class="card-title text-center"></h5>
                        </div>
                    </div>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
