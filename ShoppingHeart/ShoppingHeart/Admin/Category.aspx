<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="ShoppingHeart.Admin.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
       
       <asp:Label ID="lblTitle" runat="server" 
           style="font-weight:700; font-size: x-large; color: #0033CC;" Text="Label">All Categories</asp:Label>
       <hr />
   </div>
   <table align="center" style="width: 100%; background-color: #FFFFFF">
           <tr>
               <td align="center">
                   <asp:GridView ID="gvAvailableCategories" runat="server" CellPadding="4" 
                       ForeColor="#333333" GridLines="None">
                       <AlternatingRowStyle BackColor="White" />
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
