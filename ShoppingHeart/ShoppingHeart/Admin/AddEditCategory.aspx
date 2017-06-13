<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddEditCategory.aspx.cs" Inherits="ShoppingHeart.Admin.AddNewProct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="border-style: groove; border-width: medium; width: 100%" border:1>
        <tr>
            <td class="style7" colspan="2" 
                style="font-size: x-large; height: 30px; background-color: #6699FF">
                <strong>Add New Category</strong><hr /></td>
                
        </tr>
        <tr>
            <td class="style7" style="width: 485px">
                Category Name</td>
              
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="189px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 485px; height: 23px">
            </td>
            <td style="height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 485px">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
