<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoppingHeart.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            border-style: solid;
            border-width: 2px;
        }
        .style2
        {
            font-size: x-large;
            text-align: center;
            color: #CC0000;
        }
        .style3
        {
            text-align: center;
            font-size: large;
            color: #000000;
            background-color: #3366FF;
            height: 24px;
        }
        .style4
        {
            text-align: center;
            width: 345px;
        }
        .style5
        {
            text-align: center;
            width: 346px;
        }
        .style6
        {
        }
        .style7
        {
            width: 345px;
            height: 23px;
        }
        .style8
        {
            height: 23px;
        }
        .style9
        {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style2">
    
        <strong><span class="style9">Shopping Heart-Admin Portal</span><br />
        <br />
        <br />
        <br />
        <br />
        <br />
        </strong></div>
    <table class="style1" width="300px" align="center">
        <tr>
            <td class="style3" colspan="2">
                Admin Portal<hr /></td>
        </tr>
        <tr>
            <td class="style5">
                LoginID</td>
            <td class="style4">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Password</td>
            <td class="style4">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style7" align=center>
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" 
                    onclick="Button1_Click" Width="71px" />
            </td>
        </tr>
        <tr>
            <td class="style6" colspan="2" align=center>
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
