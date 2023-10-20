<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductosGerente.aspx.cs" Inherits="TiendaZapatillas.Gerente.ProductosGerente" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Productos</h1>
        <asp:UpdatePanel ID="wer1yy23" runat="server">
            <ContentTemplate>

                <asp:GridView ID="gridproductos" runat="server" CssClass="grid"
                    ShowHeaderWhenEmpty="true" class="table thead-dark"
                    AutoGenerateColumns="false" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <HeaderStyle BackColor="black" Font-Bold="True"
                                ForeColor="White" />


                    <Columns>
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
                        <%--<asp:TemplateField HeaderText="ImagePath">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("ImagePath") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("UnitPrice") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                  
                        <asp:TemplateField HeaderText="Categoria">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("CategoryName") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Genero">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("GeneroName") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Tipo">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("TypeCategoryName") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                                </Columns>

                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>


    </div>
</asp:Content>
