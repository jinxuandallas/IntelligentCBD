<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="IntelligentCBD.Account.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--将文本框设为不可改变大小 -->
     <style type="text/css">
    .text {
        resize:none
    }
        
         .auto-style6 {
             width: 25px;
         }
                 
         .auto-style8 {
             width: 108px;
         }
        
        
         .auto-style10 {
             height: 19px;
         }
         .auto-style11 {
             background-color: #0066ff;
             color: white;
             font-size: 1.4em;
             font-weight: bolder;
             text-align: center;
             width: 100px;
         }
         .auto-style12 {
             width: 100px;
         }
        
        
    </style>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="Secret" runat="server">
            <table style="width:100%;">
                <tr>
                <td class="auto-style11">忘记密码</td>
                <td style="height: 20px"></td>
            </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10" colspan="2">请输入正确的密保答案</td>
                    <td class="auto-style10"></td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp; 密保问题：</td>
                    <td colspan="2">
                        <asp:Label ID="LabelQuestion" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp; 密保答案：</td>
                    <td>
                        <asp:TextBox ID="TextBoxAnswer" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td>
                        <asp:Label ID="LabelNotice" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style12">&nbsp;</td>
                    <td>
                        <asp:Button ID="Next" runat="server" OnClick="Next_Click" Text="下一步" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="Appeal" runat="server">
            <table style="width:100%;">
                <tr>
                <td class="TableTitle">忘记密码</td>
                    <td >&nbsp;</td>
                <td style="height: 20px"></td>
            </tr>
                <tr>
                    <td>&nbsp;</td><td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td><td>你没有设置密保问题，请向管理员申诉</td>
                </tr>
                <tr>
                    <td>&nbsp;</td><td>
                        <asp:TextBox ID="TextBoxAppeal" runat="server" Height="100px" MaxLength="300" TextMode="MultiLine" Width="400px" CssClass="text"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td><td>
                    <asp:Button ID="SubmitAppeal" runat="server" Text="提交" OnClick="SubmitAppeal_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="ChangePassword" runat="server">
            <table style="width:100%;">
                <tr>
                <td class="TableTitle" colspan="2">忘记密码</td>
                <td style="height: 20px"></td>
            </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td colspan="2">请输入新秘密</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">新密码：</td>
                    <td>
                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NewPassword" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="NewPassword" Display="Dynamic" ErrorMessage="6-16个字符（字母、数字、下划线）" ForeColor="Red" ValidationExpression="[a-zA-Z]\w{5,15}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">确认新秘密：</td>
                    <td>
                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="ConfirmPassword" ControlToValidate="NewPassword" Display="Dynamic" ErrorMessage="两次输入的密码需一致" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td>
                        <asp:Label ID="LabelPasswordNotice" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td>
                        <asp:Button ID="SubmitChangepassword" runat="server" OnClick="SubmitChangepassword_Click" Text="提交" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
