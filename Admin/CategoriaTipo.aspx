<%@ Page Title="Categoria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriaTipo.aspx.cs" Inherits="TiendaZapatillas.Admin.CategoriaTipo" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
        <asp:Label ID="lblSuccessMessage" runat="server"></asp:Label>

         <asp:Button ID="btnopentipo" CssClass="btn btn-success rounded-3"  runat="server" Text="Agregar Tipo" />
                                    <!-- ModalPopupExtender --->
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                                        PopupControlID="Panel2" TargetControlID="btnopentipo" CancelControlID="btnclosetipo"
                                        BackgroundCssClass="modalBackground">
                                    </cc1:ModalPopupExtender>
                                    <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" align="center"
                                        Style="background-color:white; border:solid; border-color:black;" >
                                        <div style="padding:20px">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <h3>Agregar Tipo de zapatillas</h3>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="lblAddTipo" runat="server">
                                                                </asp:TextBox>
                                                                

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                                                    runat="server" Font-Bold="true"
                                                                    Text="*Nombre requerido"
                                                                    ControlToValidate="lblAddTipo"
                                                                    SetFocusOnError="true" Display="Dynamic"
                                                                    ValidationGroup="VG1"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbladdtipostatus" runat="server" Text="">
                                                                </asp:Label>

                                                            </td>
                                                        </tr>

                                                    </table>



                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <asp:Button ID="btnaddtipo" runat="server" Text="Agregar" OnClick="Addtipo_Click" CssClass="btn btn-success rounded-3" CausesValidation="true" ValidationGroup="VG1" />
                                        <asp:Button ID="btnclosetipo" CssClass="btn btn-danger rounded-3" runat="server" Text="Cerrar" />
                                        <br />
                                        <p>  </p>
                                        <p></p>
                                    </asp:Panel>

                              
                                    <asp:GridView ID="gvtipotab" runat="server" CssClass="grid"
                                        ShowHeaderWhenEmpty="true" class="table thead-dark" AutoGenerateColumns="false"
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                        CellPadding="3" DataKeyNames="TypeCategoryID" OnRowCommand="gvtipotab_RowCommand"
                                                    OnRowEditing="gvtipotab_RowEditing"
                                                    OnRowCancelingEdit="gvtipotab_RowCancelingEdit"
                                                    OnRowUpdating="gvtipotab_RowUpdating"
                                                    OnRowDeleting="gvtipotab_RowDeleting">
                                                            <HeaderStyle BackColor="black" Font-Bold="True"
                                                                ForeColor="White"  />
                                                            
                                                          
                                                           
                                        <Columns>

                                              <asp:TemplateField HeaderText="ID">
                                                            <ItemTemplate>
                                                                <asp:Label Text='<%# Eval("TypeCategoryID") %>'
                                                                    runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Nombre">
                                                            <ItemTemplate>
                                                                <asp:Label Text='<%# Eval("TypeCategoryName") %>'
                                                                    runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                              <asp:TemplateField HeaderStyle-Width="10px" >
                                                            <ItemTemplate>
                                                                    <asp:ImageButton ImageUrl="~/Images/lupa.png"
                                                                        runat="server" ValidationGroup="VG2" ID="btndettipo" Width="20px"
                                                                        Height="20px" OnClick="btndettipo_Click" CommandArgument='<%#Eval("TypeCategoryID") %>' />
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderStyle-Width="10px">
                                                            <ItemTemplate>
                                                                    <asp:ImageButton ImageUrl="~/Images/edit.png"
                                                                        runat="server" ValidationGroup="VG3" ID="btnedittipo" Width="20px"
                                                                        Height="20px"  />
                                                                  <cc1:ModalPopupExtender ID="mp1" runat="server"
                                                                        PopupControlID="Panel21"
                                                                        TargetControlID="btnedittipo"
                                                                        CancelControlID="btncerraredittipo"
                                                                        BackgroundCssClass="modalBackground">
                                                                    </cc1:ModalPopupExtender>
                                                                    <asp:Panel ID="Panel21" runat="server"
                                                                        CssClass="modalPopup" align="center"
                                                                        Style="background-color:white; border:solid; border-color:black;">
                                                                        <div style="padding:20px">
                                                                            <asp:UpdatePanel ID="UpdatePanel2"
                                                                                runat="server">
                                                                                <ContentTemplate>
                                                                                    <h3>Editar Tipo de zapatillas</h3>
                                                                                    <table>                                                                                     
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label
                                                                                                    ID="lbleditnametipo"
                                                                                                    runat="server">
                                                                                                    Nombre:</asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox
                                                                                                    ID="txttipoNameedit"
                                                                                                    Text='<%# Eval("TypeCategoryName") %>'
                                                                                                    runat="server" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <p></p>
                                                                                    <p></p>

                                                                                    <asp:Button CssClass="btn btn-success rounded-3" ID="Editcat"
                                                                                        runat="server"
                                                                                        Text="Editar tipo de zapatillas"
                                                                                        CommandName="Update"
                                                                                        ValidationGroup="VG188885" />
                                                                                      <asp:Button ID="btncerraredittipo" CssClass="btn btn-danger rounded-3" runat="server"
                                                                            Text="Cerrar"
                                                                            ValidationGroup="VG16" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <asp:Label ID="lbltipoedit"
                                                                                        runat="server" Text="">
                                                                                    </asp:Label>
                                                                    </asp:Panel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="10px">
                                                            <ItemTemplate>

                                                                <asp:ImageButton ImageUrl="~/Images/delete.png"
                                                                    runat="server" CommandName="Delete"
                                                                    ValidationGroup="VG3" ToolTip="Eliminar"
                                                                    Width="20px" Height="20px" />
                                                            </ItemTemplate>                                                       
                                                        </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
    </div>
</asp:Content>
