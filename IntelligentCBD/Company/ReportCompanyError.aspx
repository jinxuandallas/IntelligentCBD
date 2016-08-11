<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainSite.Master" AutoEventWireup="true" CodeBehind="ReportCompanyError.aspx.cs" Inherits="IntelligentCBD.Company.ReportCompanyError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="width: 200px"></td>
            <td>
                <table style="width: 600px; font-size: 14px; height: 30px">
                    <tr>
                        <td style="width: 100px; height: 30px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="background-color: #F3F3F3; height: 35px">
                            <asp:Label ID="LabelCompanyName" runat="server" ForeColor="#FF3300" Font-Size="20px"></asp:Label>
                            <span style="color: darkgray">（</span><span style="color: red">*</span><span style="color: darkgray">为必填选项）</span>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="3" style="padding: 0px">
                            <table class="TableBox">
                                <tr>
                                    <td style="height: 30px" colspan="2">报告企业信息错误问题:<span style="color: red">*</span></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 30px">&nbsp;</td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="TextBoxReport" runat="server" Height="200px" MaxLength="2000" TextMode="MultiLine" Width="450px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxReport" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationExpression="[\s\S]{10,500}"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxReport" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                    <td style="height: 30px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 30px">&nbsp;</td>
                                    <td style="font-size: 12px">10-500字</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 30px">&nbsp;</td>
                                    <td>
                                        <asp:Label ID="LabelPrompt" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 30px">&nbsp;</td>
                                    <td>
                                        <asp:Button ID="Submit" runat="server" Text="提  交" OnClick="Submit_Click" />
                                        &nbsp;
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 30px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
