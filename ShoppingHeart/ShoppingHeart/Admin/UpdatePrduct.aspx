<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UpdatePrduct.aspx.cs" Inherits="ShoppingHeart.Admin.UpdatePrduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

  <table border: medium groove #000000; width: 100%" style="width: 979px">
    <tr>
        <td class="style7" colspan="2" 
            style="color: #000000; font-size: x-large; background-color: #3366FF">
            <strong>Update Product</strong><hr /></td>
    </tr>
    <tr>
        <td style="height: 26px">
            Product Name</td>
        <td style="height: 26px">
            <asp:TextBox ID="TextBox1" runat="server" Width="201px"></asp:TextBox>
        </td>
    </tr>
    <td style="height: 26px">
            Product Id</td>
        <td style="height: 26px">
            <asp:TextBox ID="TextBox4" runat="server" Width="201px"></asp:TextBox>
        </td>
    <tr>
        <td>
            Product Category</td>
        <td>
            <asp:DropDownList ID="ddlCategory" runat="server" Width="207px" 
                DataSourceID="SqlDataSource1" DataTextField="CategoryName" 
                DataValueField="CategoryID">
            </asp:DropDownList>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ShoppingConnectionString6 %>" 
                SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
            
        </td>
    </tr>
    <tr>
        <td>
            Product Description</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Height="82px" TextMode="MultiLine" 
                Width="208px"></asp:TextBox>
        &nbsp;</td>
    </tr>
    <tr>
        <td class="style6" style="height: 44px">
            Product Image</td>
        <td class="style6" style="height: 44px">
            <asp:FileUpload ID="FileUpload1" runat="server" Width="202px" />
        </td>
    </tr>
    <tr>
        <td class="style6" style="height: 45px">
            Product Price</td>
        <td class="style6" style="height: 45px">
            <asp:TextBox ID="TextBox3" runat="server" Width="201px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6" style="height: 52px">
            Product Quantity</td>
        <td class="style6" style="height: 52px">
            <asp:TextBox ID="txtProductQuantity" runat="server" Height="30px" Width="203px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Submit" Width="110px" 
                onclick="Button1_Click" Height="37px" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    
</table>
</asp:Content>
