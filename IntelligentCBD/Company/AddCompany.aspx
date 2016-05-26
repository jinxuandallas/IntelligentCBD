<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="AddCompany.aspx.cs" Inherits="IntelligentCBD.Company.AddCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
            <tr>
                <td class="TableTitle" style="width: 90px">添加企业</td>
                <td style="height: 20px; width: 150px;"></td>
                <td style="height: 20px; width: 80px;"></td>
                <td style="height: 20px; width: 90px;">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 20px; width: 90px;"></td>
                <td style="height: 20px; width: 150px;"></td>
                <td style="height: 20px; width: 80px;"></td>
                <td style="height: 20px; width: 90px;">&nbsp;</td>
                <td style="height: 20px; ">&nbsp;</td>
                <td style="height: 20px; ">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px; height: 23px;">企业名称：</td>
                <td style="height: 23px; color: #FF6600;" colspan="3">
                    <span class="SearchNotice">此处信息可被检索出</span><br />
                    <asp:TextBox ID="TextBox_CompanyName" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_CompanyName" Display="Dynamic" ErrorMessage="企业名称不能为空" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td style="height: 23px"></td>
                <td style="height: 23px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px; height: 23px;">注册资本：</td>
                <td class="auto-style1" style="width: 150px; height: 23px;">
                    <asp:TextBox ID="TextBox_Capital" runat="server" MaxLength="7" TextMode="Number" Width="100px"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList_Units" runat="server">
                        <asp:ListItem>亿</asp:ListItem>
                        <asp:ListItem>万</asp:ListItem>
                        <asp:ListItem>千</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 23px; width: 80px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox_Capital" Display="Dynamic" ErrorMessage="请输入正确的注册资本" ForeColor="Red" ValidationExpression="^\+?[1-9][0-9]{0,6}$">*</asp:RegularExpressionValidator>
                </td>
                <td style="height: 23px; width: 90px">所属行业：</td>
                <td style="height: 23px">
                    <asp:TextBox ID="TextBox_Industry" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td style="height: 23px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px; height: 20px;">物业面积：</td>
                <td class="auto-style1" style="width: 150px; height: 20px;">
                    <asp:TextBox ID="TextBox_Area" runat="server" MaxLength="10" TextMode="Number" Width="120px"></asp:TextBox>
                    <span style="color: rgb(51, 51, 51); font-family: arial, sans-serif; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 24px; orphans: auto; text-align: start; text-indent: 28px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">㎡</span></td>
                <td style="height: 20px; width: 80px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox_Area" Display="Dynamic" ErrorMessage="请输入正确的物业面积" ForeColor="Red" ValidationExpression="^\+?[1-9][0-9]{0,6}$">*</asp:RegularExpressionValidator>
                </td>
                <td style="height: 20px; width: 90px">房 间 号：</td>
                <td style="height: 20px">
                    <asp:TextBox ID="TextBox_Nickname2" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px; height: 20px;">企业地址：</td>
                <td class="auto-style1" style="height: 20px;" colspan="2">
                    <asp:TextBox ID="TextBox_Address" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                    </td>
                <td style="height: 20px">
                    所属载体：</td>
                <td style="height: 20px">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 90px; height: 160px;">企业简介：</td>
                <td class="auto-style2" style="height: 160px;" colspan="2"><span class="SearchNotice">此处信息可被检索出</span>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="text" Height="130px" TextMode="MultiLine" Width="225px" MaxLength="500"></asp:TextBox>
                </td>
                <td style="width: 90px; height: 160px">
                    经营范围：</td>
                <td style="height: 160px" class="auto-style3"><span class="SearchNotice">此处信息可被检索出</span>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server"  CssClass="text" Height="130px" TextMode="MultiLine" Width="225px" MaxLength="500"></asp:TextBox>
                </td>
                <td style="height: 160px" class="auto-style3">
                    </td>
            </tr>
            <tr>
                <td style="width: 90px; height: 20px;">注册地：</td>
                <td class="auto-style1" style="width: 150px; height: 20px;">
                    <asp:TextBox ID="TextBox_RegisteredAddress" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td style="height: 20px; width: 80px">
                </td>
                <td style="width: 90px; height: 20px">
                    注册日期：</td>
                <td style="height: 20px">
                    <asp:TextBox ID="TextBox_RegistrationDate" runat="server" MaxLength="30" TextMode="Date"></asp:TextBox>
                </td>
                <td style="height: 20px">
                    </td>
            </tr>
            <tr>
                <td style="width: 90px; height: 21px;">手机号码：</td>
                <td class="auto-style1" style="width: 150px; height: 21px;">
                    <asp:TextBox ID="TextBox_Phone" runat="server" MaxLength="30" TextMode="Phone"></asp:TextBox>
                    <br />
                </td>
                <td style="height: 21px; width: 80px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox_Phone" Display="Dynamic" ErrorMessage="请输入正确的手机号" ForeColor="Red" ValidationExpression="^[1]+\d{10}">*</asp:RegularExpressionValidator>
                </td>
                <td style="width: 90px; height: 21px">
                    </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                    </td>
            </tr>
            <tr>
                <td style="width: 90px; height: 21px;">电子邮箱：</td>
                <td class="auto-style1" style="width: 150px; height: 21px">
                    <asp:TextBox ID="TextBox_Email" runat="server" MaxLength="50" TextMode="Email"></asp:TextBox>
                    <br />
                </td>
                <td style="height: 21px; width: 80px;">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox_Email" Display="Dynamic" ErrorMessage="请输入正确的邮箱地址" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
                <td style="height: 21px; width: 90px;">
                    </td>
                <td style="height: 21px">
                    </td>
                <td style="height: 21px">
                    </td>
            </tr>
            <tr>
                <td style="width: 90px">密保问题：</td>
                <td class="auto-style1" style="width: 150px">
                    <asp:TextBox ID="TextBox_Question" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                <td style="width: 80px">&nbsp;</td>
                <td style="width: 90px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px">密保答案：</td>
                <td class="auto-style1" style="width: 150px">
                    <asp:TextBox ID="TextBox_Answer" runat="server" MaxLength="50"></asp:TextBox>
                </td>
                <td style="width: 80px">&nbsp;</td>
                <td style="width: 90px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px; height: 20px;"></td>
                <td style="height: 20px; width: 150px;">
                    <asp:Label ID="LabelSucceed" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 20px; width: 80px;"></td>
                <td style="height: 20px; width: 90px;"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px; height: 20px;"></td>
                <td style="height: 20px; " colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                </td>
                <td style="height: 20px; width: 90px;"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px">&nbsp;</td>
                <td class="auto-style1" style="width: 150px">
                    <asp:Button ID="Submit" runat="server" Text="提交" />
                &nbsp;</td>
                <td style="width: 80px">
                    &nbsp;</td>
                <td style="width: 90px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>
