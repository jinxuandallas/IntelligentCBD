<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="IntelligentCBD.Account.RegisterUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 70px;
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
                <!--<asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" onblur="alert('xx')" OnTextChanged="UserName_TextChanged"></asp:TextBox>-->
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style1">用户名：</td>
                        <td>
                            <asp:TextBox ID="UserName" runat="server" AutoPostBack="True" OnTextChanged="UserName_TextChanged" MaxLength="30"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">密码：</td>
                        <td>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="CreateUser" runat="server" Text="注册" />
    </div>
    </form>
</body>
</html>
