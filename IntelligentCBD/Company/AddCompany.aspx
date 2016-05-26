<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="AddCompany.aspx.cs" Inherits="IntelligentCBD.Company.AddCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="width:100%;">
            <tr>
                <td class="TableTitle">添加企业</td>
                <td style="height: 20px; width: 150px;"></td>
                <td style="height: 20px; width: 80px;"></td>
                <td style="height: 20px; width: 100px;">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 20px; "></td>
                <td style="height: 20px; width: 150px;"></td>
                <td style="height: 20px; width: 80px;"></td>
                <td style="height: 20px; width: 100px;">&nbsp;</td>
                <td style="height: 20px; ">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px; height: 23px;">企业名称：</td>
                <td style="height: 23px;" colspan="3">
                    <asp:TextBox ID="TextBox_CompanyName" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_CompanyName" Display="Dynamic" ErrorMessage="企业名称不能为空" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td style="height: 23px"></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 23px;">注册资本：</td>
                <td class="auto-style1" style="width: 150px; height: 23px;">
                    <asp:TextBox ID="TextBox_Capital" runat="server" MaxLength="7" TextMode="Number" Width="100px"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>亿</asp:ListItem>
                        <asp:ListItem>万</asp:ListItem>
                        <asp:ListItem>千</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 23px; width: 80px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox_Capital" Display="Dynamic" ErrorMessage="请输入正确的注册资本" ForeColor="Red" ValidationExpression="^\+?[1-9][0-9]{0,6}$">*</asp:RegularExpressionValidator>
                </td>
                <td style="height: 23px; width: 100px">所属行业：</td>
                <td style="height: 23px">
                    <asp:TextBox ID="TextBox_Nickname1" runat="server" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 30px;">性别：</td>
                <td class="auto-style1" style="width: 150px; height: 30px;">
                    <asp:RadioButtonList ID="RadioButtonList_Sex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="男" Value="男" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="女" Value="女"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="height: 30px; width: 80px"></td>
                <td style="height: 30px; width: 100px"></td>
                <td style="height: 30px"></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 38px;">手机号码：</td>
                <td class="auto-style1" style="width: 150px; height: 38px;">
                    <asp:TextBox ID="TextBox_Phone" runat="server" MaxLength="30" TextMode="Phone"></asp:TextBox>
                    <br />
                </td>
                <td style="height: 38px; width: 80px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox_Phone" Display="Dynamic" ErrorMessage="请输入正确的手机号" ForeColor="Red" ValidationExpression="^[1]+\d{10}">*</asp:RegularExpressionValidator>
                </td>
                <td style="width: 100px; height: 38px">
                    &nbsp;</td>
                <td style="height: 38px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 23px;">电子邮箱：</td>
                <td class="auto-style1" style="width: 150px; height: 23px">
                    <asp:TextBox ID="TextBox_Email" runat="server" MaxLength="50" TextMode="Email"></asp:TextBox>
                    <br />
                </td>
                <td style="height: 23px; width: 80px;">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox_Email" Display="Dynamic" ErrorMessage="请输入正确的邮箱地址" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
                <td style="height: 23px; width: 100px;">
                    &nbsp;</td>
                <td style="height: 23px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">密保问题：</td>
                <td class="auto-style1" style="width: 150px">
                    <asp:TextBox ID="TextBox_Question" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                <td style="width: 80px">&nbsp;</td>
                <td style="width: 100px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">密保答案：</td>
                <td class="auto-style1" style="width: 150px">
                    <asp:TextBox ID="TextBox_Answer" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                <td style="width: 80px">&nbsp;</td>
                <td style="width: 100px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px; height: 20px;"></td>
                <td style="height: 20px; width: 150px;">
                    <asp:Label ID="LabelSucceed" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 20px; width: 80px;"></td>
                <td style="height: 20px; width: 100px;"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 20px;"></td>
                <td style="height: 20px; " colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                </td>
                <td style="height: 20px; width: 100px;"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 100px">&nbsp;</td>
                <td class="auto-style1" style="width: 150px">
                    <asp:Button ID="Submit" runat="server" Text="提交" />
                &nbsp;</td>
                <td style="width: 80px">
                    &nbsp;</td>
                <td style="width: 100px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>
