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
         .auto-style7 {
             width: 80px;
         }
        
    </style>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="Secret" runat="server">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">密保问题：</td>
                    <td colspan="2">
                        <asp:Label ID="LabelQuestion" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">密保答案</td>
                    <td>
                        <asp:TextBox ID="TextBoxAnswer" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>
                        <asp:Label ID="LabelNotice" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>
                        <asp:Button ID="SubmitSecret" runat="server" OnClick="SubmitSecret_Click" Text="提交" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="Appeal" runat="server">
            <table style="width:100%;">
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
    </asp:MultiView>
</asp:Content>
