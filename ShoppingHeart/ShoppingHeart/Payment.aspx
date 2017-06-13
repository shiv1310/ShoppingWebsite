<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="ShoppingHeart.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <table align="center" 
        style="border-spacing: 0; border-collapse: collapse; width: 652px; background-color: transparent;">
        <tr>
            <td class="style30">
            </td>
            <td class="style31">
                <asp:Image ID="Image4" runat="server" Height="27px" ImageUrl="~/visa.png" 
                    style="margin-bottom: 0px" Width="64px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image3" runat="server" Height="27px" ImageUrl="~/mastercard.gif" 
                    Width="64px" />
&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image5" runat="server" Height="27px" ImageUrl="~/maestro.png" 
                    Width="64px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image6" runat="server" Height="38px" ImageUrl="~/rupay.png" 
                    Width="54px" />
            </td>
            <td class="style32">
                </td>
        </tr>
        <tr>
            <td class="style26" rowspan="2">
                <strong>Card Number</strong></td>
            <td class="style25" rowspan="2">
                <asp:TextBox ID="TextBox1" runat="server" Height="29px" Width="293px" 
                    AutoPostBack="True" ontextchanged="TextBox1_TextChanged" ValidationGroup="a"></asp:TextBox>
            </td>
            <td class="style29">
                <asp:Label ID="Label2" runat="server" Font-Italic="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style37">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style34">
                &nbsp;<span class="style19"><strong>Expiration Date</strong></span></td>
            <td class="style35">
                <asp:TextBox ID="TextBox2" runat="server" Height="29px" style="margin-top: 0px" 
                    Width="293px" AutoPostBack="True" ontextchanged="TextBox2_TextChanged" 
                    ValidationGroup="a"></asp:TextBox>
            </td>
            <td class="style36">
                <asp:Label ID="Label4" runat="server" Font-Italic="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style22">
                <strong>CVV Number</strong></td>
            <td class="style38">
                <asp:TextBox ID="TextBox3" runat="server" Height="29px" Width="293px" 
                    AutoPostBack="True" ontextchanged="TextBox3_TextChanged" ValidationGroup="c"></asp:TextBox>
            </td>
            <td class="style39">
                <asp:Label ID="Label5" runat="server" Font-Italic="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style23">
                <strong>Card Holder Name</strong></td>
            <td class="style16">
                <asp:TextBox ID="TextBox4" runat="server" Height="29px" Width="293px" 
                    AutoPostBack="True" ontextchanged="TextBox4_TextChanged" ValidationGroup="d"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Font-Italic="True" ForeColor="Red"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style27">
                </td>
            <td class="style28">
                &nbsp;</td>
            <td class="style29">
                </td>
        </tr>
        <tr>
            <td class="style33">
                &nbsp;</td>
            <td class="style16">
                <strong>
                <asp:Button ID="Button1" runat="server" Height="45px"
                    Text="Make Payment" Width="180px" Font-Bold="True" Font-Size="Medium"/>
                </strong>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .style16
    {
            width: 314px;
        }
    .style19
    {
        font-size: medium;
    }
        .style22
        {
            font-size: medium;
            height: 34px;
            width: 143px;
        }
        .style23
        {
            font-size: medium;
            width: 143px;
        }
        .style25
        {
            height: 28px;
            width: 314px;
        }
        .style26
        {
            height: 28px;
            width: 143px;
        }
        .style27
        {
            width: 143px;
            height: 21px;
        }
        .style28
        {
            width: 314px;
            height: 21px;
        }
        .style29
        {
        }
        .style30
        {
            width: 143px;
            height: 44px;
        }
        .style31
        {
            width: 314px;
            height: 44px;
        }
        .style32
        {
            height: 44px;
        }
        .style33
        {
            width: 143px;
        }
        .style34
        {
            width: 143px;
            height: 31px;
        }
        .style35
        {
            width: 314px;
            height: 31px;
        }
        .style36
        {
            height: 31px;
        }
        .style37
        {
            height: 21px;
        }
        .style38
        {
            width: 314px;
            height: 34px;
        }
        .style39
        {
            height: 34px;
        }
    </style>
</asp:Content>
