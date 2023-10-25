<%@ Page Title="Marcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionMarcas.aspx.cs" Inherits="TiendaZapatillas.Admin.GestionMarcas" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="true" ForeColor="DarkRed"></asp:Label>
        <asp:Label ID="lblSuccessMessage" runat="server"></asp:Label>
        <p></p>

         <asp:Button ID="Button1" CssClass="btn btn-success rounded-3"  runat="server" Text="Agregar Marca" />
                                    <!-- ModalPopupExtender --->
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                                        PopupControlID="Panel2" TargetControlID="Button1" CancelControlID="Button2"
                                        BackgroundCssClass="modalBackground">
                                    </cc1:ModalPopupExtender>
                                    <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" align="center"
                                        Style="background-color:white; border:solid; border-color:black;" >
                                        <div style="padding:20px">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <h3>Agregar Marca</h3>
                                                  <table>
    <tr>
        <td>
            <asp:Label runat="server">Nombre:</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="AddCategoria" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Font-Bold="true" Text="*Nombre de Marca requerida" ControlToValidate="AddCategoria" SetFocusOnError="true" Display="Dynamic" ValidationGroup="VG1"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server">Descripcion:</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtdescmarca" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Bold="true" Text="Descripcion requerida" ControlToValidate="txtdescmarca" SetFocusOnError="true" Display="Dynamic" ValidationGroup="VG1"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server">Pais de origen:</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtpaismarca" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Font-Bold="true" Text="*Pais Requerida" ControlToValidate="txtpaismarca" SetFocusOnError="true" Display="Dynamic" ValidationGroup="VG1"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server">Logotipo:</asp:Label>
        </td>
        <td>
            <asp:FileUpload ID="imgaddmarca" runat="server" />
        </td>
        <td>
            <asp:RequiredFieldValidator ValidationGroup="VG1" ID="RequiredFieldValidator440" runat="server" Text="* Imagen requerida." ControlToValidate="imgaddmarca" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server">URL:</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Font-Bold="true" Text="*Nombre de Marca requerida" ControlToValidate="AddCategoria" SetFocusOnError="true" Display="Dynamic" ValidationGroup="VG1"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Label ID="lbladdcatstatus" Font-Bold="true" ForeColor="DarkRed" runat="server"></asp:Label>
        </td>
    </tr>
</table>


                                                
                                    
                                                     </ContentTemplate>
                                            </asp:UpdatePanel>
                                            </div>
                                        <asp:Button ID="AddCat" runat="server" Text="Agregar"
                                                                    OnClick="AddCat_Click" CssClass="btn btn-success rounded-3" CausesValidation="true"
                                                                    ValidationGroup="VG1" />
                                        <asp:Button ID="Button2" CssClass="btn btn-danger rounded-3" runat="server" Text="Cerrar" />
                                        <br />
                                        <p>  </p>
                                        <p></p>
                                   
       
                                             </asp:Panel>

                              
                                    <asp:GridView ID="gvcattab" runat="server" CssClass="grid"
                                        ShowHeaderWhenEmpty="true" class="table thead-dark" AutoGenerateColumns="false"
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                        CellPadding="3" DataKeyNames="MarcaID" OnRowCommand="gvcattab_RowCommand"
                                                    OnRowEditing="gvcattab_RowEditing"
                                                    OnRowCancelingEdit="gvcattab_RowCancelingEdit"
                                                    OnRowUpdating="gvcattab_RowUpdating"
                                                    OnRowDeleting="gvcattab_RowDeleting">
                                                            <HeaderStyle BackColor="black" Font-Bold="True"
                                                                ForeColor="White"  />
                                                            
                                                          
                                                           
                                        <Columns>

                                              <asp:TemplateField HeaderText="ID">
                                                            <ItemTemplate>
                                                                <asp:Label Text='<%# Eval("MarcaID") %>'
                                                                    runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Nombre">
                                                            <ItemTemplate>
                                                                <asp:Label Text='<%# Eval("MarcaName") %>'
                                                                    runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Descripcion">
                                                            <ItemTemplate>
                                                                <asp:Label Text='<%# Eval("MarcaName") %>'
                                                                    runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pais Origen">
                                                            <ItemTemplate>
                                                                <asp:Label Text='<%# Eval("MarcaName") %>'
                                                                    runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Logo">
                                                            <ItemTemplate>
                                                                <asp:Label Text='<%# Eval("MarcaName") %>'
                                                                    runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Web">
                                                            <ItemTemplate>
                                                                <asp:Label Text='<%# Eval("MarcaName") %>'
                                                                    runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                              <asp:TemplateField HeaderStyle-Width="10px" >
                                                            <ItemTemplate>
                                                                    <asp:ImageButton ImageUrl="~/Images/lupa.png"
                                                                        runat="server" ValidationGroup="VGlupa" ID="btndetcat" Width="20px"
                                                                        Height="20px" OnClick="btndetcat_Click" CommandArgument='<%#Eval("MarcaID") %>' />
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderStyle-Width="10px">
                                                            <ItemTemplate>
                                                                    <asp:ImageButton ImageUrl="~/Images/edit.png"
                                                                        runat="server" ValidationGroup="VG3" ID="btneditcat" Width="20px"
                                                                        Height="20px"  />
                                                                  <cc1:ModalPopupExtender ID="mp1" runat="server"
                                                                        PopupControlID="Panel21"
                                                                        TargetControlID="btneditcat"
                                                                        CancelControlID="btncerrareditcat"
                                                                        BackgroundCssClass="modalBackground">
                                                                    </cc1:ModalPopupExtender>
                                                                    <asp:Panel ID="Panel21" runat="server"
                                                                        CssClass="modalPopup" align="center"
                                                                        Style="background-color:white; border:solid; border-color:black;">
                                                                        <div style="padding:20px">
                                                                            <asp:UpdatePanel ID="UpdatePanel2"
                                                                                runat="server">
                                                                                <ContentTemplate>
                                                                                    <h3>Editar Marca</h3>
                                                                                    <table>                                                                                     
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label
                                                                                                    ID="lbleditnamecat"
                                                                                                    runat="server">
                                                                                                    Nombre:</asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox
                                                                                                    ID="txtCategoryNameedit"
                                                                                                    Text='<%# Eval("MarcaName") %>'
                                                                                                    runat="server" />
                                                                                                     </td></tr><tr></tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator515"
                                                                    runat="server" Font-Bold="true"
                                                                    Text="* Nombre de marca requerida"
                                                                    ControlToValidate="txtCategoryNameedit"
                                                                    SetFocusOnError="true" Display="Dynamic"
                                                                    ValidationGroup="VG2"></asp:RequiredFieldValidator>
                                                                                               
                                                                                       </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <p></p>
                                                                                    <p></p>
                                                                                    <%-- causesvalidation false --%>
                                                                                    <asp:Button CssClass="btn btn-success rounded-3" ID="Editcat"
                                                                                        runat="server"
                                                                                        Text="Editar"
                                                                                        CommandName="Update"
                                                                                        ValidationGroup="VG2" CausesValidation="false" />
                                                                                      <asp:Button ID="btncerrareditcat" CssClass="btn btn-danger rounded-3" runat="server"
                                                                            Text="Cerrar" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <asp:Label ID="lblcatedit"
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
