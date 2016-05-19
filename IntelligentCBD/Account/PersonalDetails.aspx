<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="PersonalDetails.aspx.cs" Inherits="IntelligentCBD.Account.PersonalDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width:100%;">
            <tr>
                <td style="width: 100px">用户名：</td>
                <td>
                    <asp:Label ID="Label_Username" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">昵称：</td>
                <td>
                    <asp:TextBox ID="TextBox_Nickname" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">性别：</td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList_Sex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="男" Value="男" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="女" Value="女"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">手机号码：</td>
                <td>
                    <asp:TextBox ID="TextBox_Phone" runat="server" MaxLength="30" TextMode="Phone"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">电子邮箱：</td>
                <td>
                    <asp:TextBox ID="TextBox_Email" runat="server" MaxLength="50" TextMode="Email"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">密保问题：</td>
                <td>
                    <asp:TextBox ID="TextBox_Question" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">密保答案：</td>
                <td>
                    <asp:TextBox ID="TextBox_Answer" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px;"></td>
                <td style="height: 19px"></td>
                <td style="height: 19px"></td>
            </tr>
            <tr>
                <td style="width: 100px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <!--下一步加入上传头像功能  -->
        </table>
    
</asp:Content>
