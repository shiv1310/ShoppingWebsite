<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ShoppingHeart._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 900px;
        }
        .style2
        {
            width: 900px;
        }
        .style3
        {
            width: 99px;
        }
        .style4
        {
            width: 387px;
        }
        .style5
        {
            width: 64px;
        }
        .style6
        {
            width: 350px;
            text-align: center;
            color: #FF6699;
        }
        .style7
        {
            width: 900px;
            background-color: #FF6699;
        }
        .style8
        {
            text-align: center;
            width: 633px;
        }
        .style10
        {
            text-align: center;
            color: #0000CC;
        }
        .style11
        {
            width: 900px;
            border: 4px solid #0000FF;
            text-align:center;
        }
        .style13
        {
            width: 172px;
            border: 2px solid #000000;
        }
        .style14
        {
            width: 257px;
            text-align:center;
        }
        .style16
        {
            width: 633px;
            text-align:left;
        }
        .style17
        {
            width: 100%;
        }
        .style18
        {
            width: 172px;
            border: 1px solid #000000;
        }
        .style19
        {
            color: #000000;
        }
        .style20
        {
            text-align: left;
        }
        .style21
        {
            height: 23px;
        }
        .style22
        {
            text-align: left;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
          <div>
        <table align="center" class="style1">
            <tr>
                <td>
                    <table class="style2">
                        <tr>
                            <td class="style3">
                                <asp:Image ID="Image1" runat="server" Height="108px" 
                                    ImageUrl="~/Images/Shop2.png" Width="267px" />
                            </td>
                            <td class="style6">
                                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                                    style="text-align: center; color: #FF3399; font-weight: 700; font-size: x-large">Those who Love To Shop</asp:LinkButton>
                            </td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style5">
                                <asp:Image ID="Image2" runat="server" Height="69px" 
                                    ImageUrl="~/Images/shopCart.png" Width="77px" />
                            </td>
                            <td>
                                <asp:LinkButton ID="btnShoppingHeart" runat="server" Font-Bold="True" 
                                    Font-Size="Larger" ForeColor="Red" onclick="btnShoppingHeart_Click">0</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" class="style7">
                        <tr>
                            <td class="style8">
                                <asp:Label ID="lblCategoryName" runat="server" Font-Bold="True" 
                                    Font-Size="Larger" ForeColor="#0033CC" Text="Label"></asp:Label>
                            </td>
                            <td class="style10">
                                <asp:Label ID="lblProductsName" runat="server" Font-Bold="True" 
                                    Font-Size="Larger" ForeColor="#0033CC" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                <div>
                    <table align="center" class="style11" width="185px">
                        <tr>
                            <td class="style16" valign="top">
                                <asp:Panel ID="pnlProducts" ScrollBars="Auto" valign Height="500px" BorderColor="Black" BorderStyle="Inset" BorderWidth="1px" runat="server">
                                    
                                    <asp:DataList ID="dlProducts" RepeatColumns="3" Width="600px" Font-Bold="False" 
                                        Font-Italic="False" Font-Overline="False" Font-Underline="False" 
                                        Font-Strikeout="False" runat="server">
                                        <ItemTemplate>
                                        <div align="left">
                                            <table class="style13">
                                                <tr>
                                                    <td style="text-align: center">
                                                        <asp:Label ID="lblProductName" runat="server" Font-Bold="True" 
                                                           Text='<%#Eval("Name") %>' Font-Size="Medium" ForeColor="#000099"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <asp:Image ID="Image3" runat="server" src='<%#Eval("Image") %>'  Height="127px" ImageAlign="AbsMiddle" 
                                                            Width="174px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        Price:
                                                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                                                        <br />
                                                        Stock:<asp:Label ID="lblAvailableStock" runat="server" Text='<%#Eval("AvailableStock") %>' Font-Bold="True" 
                                                            ForeColor="Red" ToolTip="Available Stock"></asp:Label>
                                                        <br />
                                                        <asp:HiddenField ID="hfProductID" runat="server" Value='<%#Eval("ProductID") %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="middle">
                                                        <asp:Button ID="btnAddtoCart" runat="server" Height="35px" Text="Add to Cart" 
                                                            CommandArgument='<%#Eval("ProductID") %>' onclick="btnAddtoCart_Click" CausesValidation="false"
                                                             BorderWidth="1px" BorderColor="Black" BorderStyle="Inset" Width="100%" Font-Bold="True" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        </ItemTemplate>
                                        <ItemStyle Width="33%"/>
                                    </asp:DataList>
                                    
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ShoppingConnectionString3 %>" 
                                        SelectCommand="SELECT * FROM [Products_new]"></asp:SqlDataSource>
                                    
                                </asp:Panel>
                                <asp:Panel ID="pnlMyCart" runat="server" BorderColor="Black" 
                                    BorderStyle="Inset" Height="554px" ScrollBars="Auto" Visible="False">
                               
                                <table align="center" class="style17">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblAvailableStockAlert" runat="server" Text="Label" 
                                                Font-Bold="True" ForeColor="Red"></asp:Label>
                                            &nbsp;<br />
                                            <asp:DataList ID="dlCartProducts" runat="server" ForeColor="Red" 
                                                RepeatColumns="3" RepeatDirection="Horizontal" Width="551px" 
                                                >
                                                <ItemTemplate>
                                                    <table align="center" class="style18">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Image ID="Image6" src='<%#Eval("Image") %>' runat="server" Height="138px" Width="140px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style19">
                                                                Available Stock:<asp:Label ID="lblAvailableStock"  runat="server" 
                                                                    Text='<%# Eval("AvailableStock") %>'></asp:Label>
                                                                <br />
                                                                Price:<asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price") %>'>
                                                                </asp:Label> 
                                                                &nbsp;*
                                                                <asp:TextBox ID="txtProductQuantity" runat="server" AutoPostBack="True" 
                                                                    Height="15px" MaxLength="1" Text='<%# Eval("TotalProducts") %>' ontextchanged="txtProductQuantity_TextChanged" 
                                                                    Width="15px"></asp:TextBox>
                                                                <asp:HiddenField ID="hfProductID"  Value='<%#Eval("ProductID") %>' runat="server" />
                                                            </td>
                                                        </tr>
                                                        <caption>
                                                            <hr />
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnRemoveFromCart" runat="server" CausesValidation="false" 
                                                                        CommandArgument='<%#Eval("ProductID") %>' Font-Bold="True" Height="27px" 
                                                                        Text="Remove From Cart" Width="134px" onclick="btnRemoveFromCart_Click" />
                                                                </td>
                                                            </tr>
                                                        </caption>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle Width="33%"/>
                                            </asp:DataList>
                                        </td>
                                     </asp:Panel>
                             </td>
                             <td align="center" class="style14" valign="top">
                                <asp:Panel ID="pnlCategory" runat="server">
                                                <asp:DataList ID="dlCategories" runat="server" CellPadding="4" 
                                                    ForeColor="#333333" 
                                                     Width="139px">
                                                    <AlternatingItemStyle BackColor="White" />
                                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                    <ItemStyle BackColor="#E3EAEB" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnCategory"  runat="server" Text='<%#Eval("CategoryName")%>' OnClick="lbtnCategory_Click"
                                                            CommandArgument='<%#Eval("CategoryID")%>'></asp:LinkButton>
                                                        
                                                    </ItemTemplate>
                                                    <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                </asp:DataList>
                                                
                                            </asp:Panel>
                                 <asp:Panel ID="pnlCheckOut" runat="server" BorderColor="Black" 
                                     BorderStyle="Inset" BorderWidth="1px" Height="700px" ScrollBars="Auto" 
                                     Visible="False">
                                 
                                 <table align="left" class="style17">
                                     <tr>
                                         <td style="text-align: left">
                                             Name:</td>
                                     </tr>
                                     <tr>
                                         <td class="style20">
                                             <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                 ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td class="style20">
                                             Phoneno.</td>
                                     </tr>
                                     <tr>
                                         <td class="style20">
                                             <asp:TextBox ID="txtPhone" runat="server" MaxLength="10"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                 ControlToValidate="txtPhone" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="text-align: left" class="style21">
                                             EmailId.</td>
                                     </tr>
                                     <tr>
                                         <td class="style22">
                                             <asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                 ControlToValidate="txtEmailID" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="text-align: left">
                                             Address</td>
                                     </tr>
                                     <tr>
                                         <td class="style20">
                                             <asp:TextBox ID="txtAddress" runat="server" Height="111px" TextMode="MultiLine" 
                                                 Width="144px"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                 ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="text-align: left">
                                             Total Products</td>
                                     </tr>
                                     <tr>
                                         <td class="style20">
                                             <asp:TextBox ID="txtTotalProducts" runat="server" ReadOnly="True"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                 ControlToValidate="txtTotalProducts" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="text-align: left">
                                             Total Price</td>
                                     </tr>
                                     <tr>
                                         <td class="style20">
                                             <asp:TextBox ID="txtPrice" runat="server" ReadOnly="True" Width="208px"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                 ControlToValidate="txtPrice" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td class="style20">
                                             Payment Mode</td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:RadioButtonList ID="rblPaymentMethod" runat="server">
                                                 <asp:ListItem Selected="True">Cash On Delivery</asp:ListItem>
                                             </asp:RadioButtonList>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:Button ID="btnPlaceOrder" runat="server" Height="27px" Text="Place Order" 
                                                 Width="114px" onclick="btnPlaceOrder_Click" />
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                 ControlToValidate="txtEmailID" ErrorMessage=" Please enter valid Email id" 
                                                 ForeColor="Red" 
                                                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                         </td>
                                     </tr>
                                 </table>
                                 <br />
                                 <br />
                                 </asp:Panel>
                              </td>
                            </tr>
                            <tr>
                                <td colspan="2" valign="top">
                                    <asp:Panel ID="pnlEmptyCart" runat="server" Visible="false">
                                        <div style="text-align:center;">
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/empty-cart.gif" 
                                                Width="500px" />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlOrderPlacedSuccessfully" runat="server" Visible="false">
                                        <div style="text-align:center;">
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/happyshopping2.jpg" />
                                            <br />
                                            <br />
                                            <label>
                                            Order placed Successfully</label><br /><br /> Transaction details are sent at 
                                            Email provided by you.<br />
                                            <br />
                                            <br />
                                            <asp:Label ID="lblTransactionNo" runat="server" Style="font-weight:700"></asp:Label>
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="style16" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Login.aspx" 
                                        style="text-align: center">Admin Panel</asp:HyperLink>
                                </td>
                                <td class="style14">
                                    &nbsp;</td>
                            </tr>
                                    </tr>
                                </table>
                            </td>

            </tr>
            </table>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    </form>
</body>
</html>
