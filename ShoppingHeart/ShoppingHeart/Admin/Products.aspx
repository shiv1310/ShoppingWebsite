<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ShoppingHeart.Admin.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div align="center">
       
        <asp:Label ID="lblTitle" runat="server" 
            style="font-weight:700; font-size: x-large; color: #0033CC;" Text="Label">All Products</asp:Label>
       <hr />
   </div>
    <table align="center" style="width: 100%; background-color: #FFFFFF">
           <tr>
               <td align="center">
                   <asp:GridView ID="gvAvailableProducts" runat="server" CellPadding="3" 
                       ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                       BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px">
                       <AlternatingRowStyle BackColor="White" />
                       <Columns>
                           <asp:BoundField DataField="ProductID" HeaderText="ProductID" />
                           <asp:BoundField DataField="Name" HeaderText="ProductName">
                           <ItemStyle Width="150px" />
                           </asp:BoundField>
                           <asp:BoundField DataField="CategoryName" HeaderText="ProductCategory">
                           <HeaderStyle Width="50px" />
                           </asp:BoundField>
                           <asp:BoundField DataField="AvailableStock" HeaderText="AvailableStock">
                           <HeaderStyle Font-Bold="True" Font-Size="Larger" Width="150px" />
                           </asp:BoundField>
                           <asp:BoundField DataField="Price" HeaderText="Price">
                           <HeaderStyle Width="150px" />
                           </asp:BoundField>
                           <asp:ImageField DataImageUrlField="Image" HeaderText="Image">
                               <ControlStyle Width="150px" />
                           </asp:ImageField>
                       </Columns>
                       <EditRowStyle BackColor="#2461BF" />
                       <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                       <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                       <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                       <RowStyle BackColor="#EFF3FB" />
                       <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                       <SortedAscendingCellStyle BackColor="#F5F7FB" />
                       <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                       <SortedDescendingCellStyle BackColor="#E9EBEF" />
                       <SortedDescendingHeaderStyle BackColor="#4870BE" />
                   </asp:GridView>
               </td>
           </tr>
       </table>
   
   
</asp:Content>
