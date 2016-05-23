<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="PersonalDetails.aspx.cs" Inherits="IntelligentCBD.Account.PersonalDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width:100%;">
            <tr>
                <td style="width: 100px; height: 20px;">用户信息</td>
                <td style="height: 20px; width: 170px;"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 100px">用户名：</td>
                <td class="auto-style1" style="width: 170px">
                    <asp:Label ID="Label_Username" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">昵称：</td>
                <td class="auto-style1" style="width: 170px">
                    <asp:TextBox ID="TextBox_Nickname" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">性别：</td>
                <td class="auto-style1" style="width: 170px">
                    <asp:RadioButtonList ID="RadioButtonList_Sex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="男" Value="男" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="女" Value="女"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">手机号码：</td>
                <td class="auto-style1" style="width: 170px">
                    <asp:TextBox ID="TextBox_Phone" runat="server" MaxLength="30" TextMode="Phone"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox_Phone" Display="Dynamic" ErrorMessage="请输入正确的手机号" ForeColor="Red" ValidationExpression="^[1]+\d{10}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 23px;">电子邮箱：</td>
                <td class="auto-style1" style="width: 170px; height: 23px">
                    <asp:TextBox ID="TextBox_Email" runat="server" MaxLength="50" TextMode="Email"></asp:TextBox>
                </td>
                <td style="height: 23px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox_Email" Display="Dynamic" ErrorMessage="请输入正确的邮箱地址" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px">密保问题：</td>
                <td class="auto-style1" style="width: 170px">
                    <asp:TextBox ID="TextBox_Question" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">密保答案：</td>
                <td class="auto-style1" style="width: 170px">
                    <asp:TextBox ID="TextBox_Answer" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px; height: 20px;"></td>
                <td style="height: 20px; width: 170px;">
                    <asp:Label ID="LabelSucceed" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 100px">&nbsp;</td>
                <td class="auto-style1" style="width: 170px">
                    <asp:Button ID="Submit" runat="server" Text="完成修改" OnClick="Submit_Click" />
                &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <!--下一步加入上传头像功能  -->
        </table>
    
</asp:Content>
