<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IntelligentCBD.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div >
    
        <table style="width:100%;">
            <tr>
                <td style="width:70%;">&nbsp;</td>
                <td>
    
        <asp:Login ID="UserLogin" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" CreateUserText="注册新用户" CreateUserUrl="SignUp.aspx" Font-Names="Verdana" Font-Size="0.9em" ForeColor="#333333" OnAuthenticate="UserLogin_Authenticate" PasswordRecoveryText="忘记密码" RememberMeText="下次记住我" PasswordRecoveryUrl="ForgetPassword.aspx">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.9em" ForeColor="#284E98" />
            <TextBoxStyle Font-Size="0.9em" />
            <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
