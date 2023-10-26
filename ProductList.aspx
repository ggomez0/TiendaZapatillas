<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="TiendaZapatillas.ProductList"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container" style="text-align:center; ">
     
         <table><tr><td>
      <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true" DataSourceID="SqlDataSource2" DataTextField="MarcaName" DataValueField="MarcaName">
        <asp:ListItem Text="Todas las Categorias" Value="" />
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TiendaZapatillas %>"
        SelectCommand="select distinct MarcaName from Products p inner join Marcas c on c.MarcaID=p.MarcaID"></asp:SqlDataSource>

             <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="true" DataSourceID="SqlDataSource3" DataTextField="TypeCategoryName" DataValueField="TypeCategoryName">
        <asp:ListItem Text="Todos los tipos de calzado" Value="" />
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:TiendaZapatillas %>"
        SelectCommand="select distinct TypeCategoryName from Products p inner join TypeCategories c on c.TypeCategoryID=p.TypeCategoryID"></asp:SqlDataSource>

            <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="true" DataSourceID="SqlDataSource4" DataTextField="GeneroName" DataValueField="GeneroName">
        <asp:ListItem Text="Todas los generos" Value="" />
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:TiendaZapatillas %>"
        SelectCommand="select distinct GeneroName from Products p inner join GeneroCategories c on c.GenCategoryID=p.GenCategoryID"></asp:SqlDataSource>


      <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" type="submit" Text="Buscar" OnClick="btnSearch_Click" CssClass="rounded-3 btn-success" />      
   </td></tr></table> <p></p>
       <div style="margin-left:5%">
    <asp:ListView ID="productlist" runat="server" DataSourceID="SqlDataSource1" GroupItemCount="4">
        <AlternatingItemTemplate>
          <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?productID=<%#:Eval("ProductID")%>">
                                        <div class="" style="width: 18rem;">       
                                                <img class="card-img-top" src="/Images/Thumbs/<%#:Eval("ImagePath") %>"  style="height:10rem; object-fit:contain;" />
                                         </a>

                                            <div class="card-body">
                                                <h5 href="ProductDetails.aspx?productID=<%#:Eval("ProductID")%>" class="card-title">
                                                    <span>
                                                        <%#:Eval("ProductName")%>                                               
                                                    </span>
                                                </h5>

                                                <p class="card-text"></b><%#:String.Format("{0:c}", Eval("UnitPrice"))%></p>
                                                <a href="/AddToCart.aspx?productID=<%#:Eval("ProductID") %>" class="btn btn-success rounded-3" style="font-family:Calibri">
                                                    <b>Agregar al Carrito<b>
                                                </a>
                                            </div>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
        </AlternatingItemTemplate>

        <EditItemTemplate>
          <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?productID=<%#:Eval("ProductID")%>">
                                        <div class="" style="width: 18rem;">       
                                                <img class="card-img-top" src="/Images/Thumbs/<%#:Eval("ImagePath") %>"  style="height:10rem; object-fit:contain;" />
                                         </a>

                                            <div class="card-body">
                                                <h5 href="ProductDetails.aspx?productID=<%#:Eval("ProductID")%>" class="card-title">
                                                    <span>
                                                        <%#:Eval("ProductName")%>                                               
                                                    </span>
                                                </h5>

                                                <p class="card-text"></b><%#:String.Format("{0:c}", Eval("UnitPrice"))%></p>
                                                <a href="/AddToCart.aspx?productID=<%#:Eval("ProductID") %>" class="btn btn-success rounded-3" style="font-family:Calibri">
                                                    <b>Agregar al Carrito<b>
                                                </a>
                                            </div>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
        </EditItemTemplate>

        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No se encontraron productos.</td>
                </tr>
            </table>
        </EmptyDataTemplate>

        <EmptyItemTemplate>
            <td runat="server" />
        </EmptyItemTemplate>

        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>

        <InsertItemTemplate>
          <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?productID=<%#:Eval("ProductID")%>">
                                        <div class="" style="width: 18rem;">       
                                                <img class="card-img-top" src="/Images/Thumbs/<%#:Eval("ImagePath") %>"  style="height:10rem; object-fit:contain;" />
                                         </a>

                                            <div class="card-body">
                                                <h5 href="ProductDetails.aspx?productID=<%#:Eval("ProductID")%>" class="card-title">
                                                    <span>
                                                        <%#:Eval("ProductName")%>                                               
                                                    </span>
                                                </h5>

                                                <p class="card-text"></b><%#:String.Format("{0:c}", Eval("UnitPrice"))%></p>
                                                <a href="/AddToCart.aspx?productID=<%#:Eval("ProductID") %>" class="btn btn-success rounded-3" style="font-family:Calibri">
                                                    <b>Agregar al Carrito<b>
                                                </a>
                                            </div>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
        </InsertItemTemplate>

        <ItemTemplate>
            <td runat="server">
                       <table>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?productID=<%#:Eval("ProductID")%>">
                                        <div class="" style="width: 18rem;">       
                                                <img class="card-img-top" src="/Images/Thumbs/<%#:Eval("ImagePath") %>"  style="height:10rem; object-fit:contain;" />
                                         </a>

                                            <div class="card-body">
                                                <h5 href="ProductDetails.aspx?productID=<%#:Eval("ProductID")%>" class="card-title">
                                                    <span>
                                                        <%#:Eval("ProductName")%>                                               
                                                    </span>
                                                </h5>

                                                <p class="card-text"></b><%#:String.Format("{0:c}", Eval("UnitPrice"))%></p>
                                                <a href="/AddToCart.aspx?productID=<%#:Eval("ProductID") %>" class="btn btn-success rounded-3" style="font-family:Calibri">
                                                    <b>Agregar al Carrito<b>
                                                </a>
                                            </div>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
        </ItemTemplate>

        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server" style="position:center;">
                    <td runat="server">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="24">
                            <Fields >
                                    <asp:NumericPagerField ButtonCount="5" NumericButtonCssClass="page-item" CurrentPageLabelCssClass="page-item disabled" NextPreviousButtonCssClass="page-item" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
   
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TiendaZapatillas %>"
        SelectCommand="SELECT [ProductID], [ImagePath], [ProductName], [UnitPrice] from Products p inner join Marcas c on c.MarcaID=p.MarcaID inner join TypeCategories ty on ty.TypeCategoryID=p.TypeCategoryID inner join GeneroCategories gc on gc.GenCategoryID=p.GenCategoryID WHERE ([ProductName] LIKE '%' + @ProductName + '%') AND (MarcaName = @MarcaName OR ISNULL(@MarcaName,'') = '') AND (GeneroName = @GeneroName OR ISNULL(@GeneroName,'') = '') AND (TypeCategoryName = @TypeCategoryName OR ISNULL(@TypeCategoryName,'') = '') ">
        <SelectParameters>

            <asp:ControlParameter ControlID="txtsearch" Name="ProductName" PropertyName="Text" Type="String" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter ControlID="DropDownList1" Name="MarcaName" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter ControlID="DropDownList2" Name="TypeCategoryName" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter ControlID="DropDownList3" Name="GeneroName" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="false" />

        </SelectParameters>
    </asp:SqlDataSource> 
</div>
  </div>
</asp:Content>