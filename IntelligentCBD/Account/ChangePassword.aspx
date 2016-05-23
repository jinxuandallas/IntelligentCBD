<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="IntelligentCBD.Account.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
                <td class="TableTitle">修改密码</td>
                <td style="height: 20px;"></td>
                <td style="height: 20px"></td>
            </tr
        <tr>
            <td class="auto-style1" style="width: 100px">&nbsp;&nbsp; </td>
            <td style="width: 170px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 100px">&nbsp;&nbsp;原密码：</td>
            <td style="width: 170px">
                <asp:TextBox ID="OriginalPassword" runat="server" TextMode="Password"> </asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="OriginalPassword" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="OriginalPassword" Display="Dynamic" ErrorMessage="6-16个字符（字母、数字、下划线）" ForeColor="Red" ValidationExpression="[a-zA-Z]\w{5,15}"></asp:RegularExpressionValidator>
                        </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 100px">&nbsp;&nbsp;新密码：</td>
            <td style="width: 170px">
                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NewPassword" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="NewPassword" Display="Dynamic" ErrorMessage="6-16个字符（字母、数字、下划线）" ForeColor="Red" ValidationExpression="[a-zA-Z]\w{5,15}"></asp:RegularExpressionValidator>
                        </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 100px">确认新密码：</td>
            <td style="width: 170px">
                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="ConfirmPassword" ControlToValidate="NewPassword" Display="Dynamic" ErrorMessage="两次输入的密码需一致" ForeColor="Red"></asp:CompareValidator>
                        </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 100px">&nbsp;</td>
            <td style="width: 170px">
                <asp:Label ID="Label_Status" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="NewPassword" ControlToValidate="OriginalPassword" Display="Dynamic" ErrorMessage="原密码与新秘密需不一致" ForeColor="Red" Operator="NotEqual"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 100px">&nbsp;</td>
            <td style="width: 170px">
                <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="提交" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
