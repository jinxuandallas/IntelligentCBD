<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="IntelligentCBD.Account.RegisterUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head title="注册用户" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Css/MainStyleSheet.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100px;
        }
        .auto-style2 {
            width: 100px;
            height: 25px;
        }
        .auto-style3 {
            height: 25px;
        }
        .auto-style4 {
            width: 100px;
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style6 {
            font-weight: bold;
            font-size: 1.4em;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server"> 
        <br />
        <br />
    <div>
  
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!--<asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" onblur="alert('xx')" OnTextChanged="UserName_TextChanged"></asp:TextBox>-->
                <table><tr><td style="width:200px"></td><td>
                <table style="width:800px;" class="MainTable">
                   <tr> 
                    <td style="width:100px" class="TableTitle">注册用户</td>
                <td style="height: 20px;"></td>
                <td style="height: 20px"></td>
            </tr>
                    <tr>
                                <td colspan="3" style="padding: 0px">
                                    <table class="TableBox">
            <tr>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
            </tr>
                    <tr>
                        <td class="auto-style2">用户名：</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="UserName" runat="server" AutoPostBack="True" OnTextChanged="UserName_TextChanged" MaxLength="30"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserName" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="UserName" Display="Dynamic" ErrorMessage="4-20位字符" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9][a-zA-Z0-9_@.]{3,19}$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style4">密 码：</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Password" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Password" Display="Dynamic" ErrorMessage="6-16个字符（字母、数字、下划线）" ForeColor="Red" ValidationExpression="[a-zA-Z]\w{5,15}"></asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style5"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">确认密码：</td>
                        <td>
                            <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="两次输入的密码需一致" ForeColor="Red"></asp:CompareValidator>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                                        </table>
                                    </td>
                        </tr>
                </table>
                <br />
                    </td></tr></table>
            </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="CreateUser" runat="server" Text="注册" OnClick="CreateUser_Click" />
    </div>
    </form>
</body>
</html>
