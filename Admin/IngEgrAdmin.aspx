<%@ Page Title="Movimientos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IngEgrAdmin.aspx.cs" Inherits="TiendaZapatillas.Admin.IngEgrAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3>Movimientos de productos</h3>
        <p>Realiza ingresos o egresos de stock de productos sobre los depositos</p>
            <asp:Button ID="btnmov" CssClass="btn btn-success rounded-3" runat="server"
                            Text="Realizar Movimiento" OnClick="btnmov_Click"/>
                       

        <p></p>
        <asp:GridView runat="server" CssClass="grid" BorderStyle="None" ID="gvhistorial" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("ID_Movimiento") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tipo de movimiento">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Nombre") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Deposito">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("DepName") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Observacion">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("descripcion") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("dateTime") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                       <asp:ImageButton runat="server" ImageUrl="~/Images/plus.png" Height="20px" ID="btn_det_mov" OnClick="btn_det_mov_Click" CommandArgument='<%#Eval("ID_Movimiento") %>'  />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        
        
        </asp:GridView>
    </div>
</asp:Content>
