<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainSite.Master" AutoEventWireup="true" CodeBehind="AddComment.aspx.cs" Inherits="IntelligentCBD.Comment.AddComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../scripts/jquery.min.js"></script>
    <script src="../scripts/jquery.raty.min.js"></script>
    <table style="width: 1000px;font-size:14px;height:30px">
        <tr>
            <td style=" width: 100px;height:30px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="background-color:#F3F3F3; height:35px">
               &nbsp; <asp:Label ID="LabelCompanyName" runat="server" ForeColor="#FF3300" Font-Size="20px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style=" width: 100px;height:30px">总体评价:</td>
            <td style=" width: 500px;""><div style="float:left;font: 11px verdana;" id="CommentGrade"></div><div id="hint" style="float:left; font:11px verdana; color: red;"></div> <input type="hidden" id="score" runat="server" /></td>
            <td ></td>
        </tr>
        <tr>
            <td style=" width: 100px;height:30px">评价：</td>
            <td>
                <asp:TextBox ID="TextBoxComment" runat="server" Height="200px" MaxLength="2000" TextMode="MultiLine" Width="450px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style=" width: 100px;height:30px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style=" width: 100px;height:30px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        <script type="text/javascript">
            $('#CommentGrade').raty({
                path:"../Images/Ratyimg",
            hintList: ['很差', '较差', '一般', '较好', '很好'],
                //half: true,
                target: '#hint',
            targetKeep: true,
            click: function (score, evt) {
                $("#score").val(score);
            }
        });
    </script>
</asp:Content>
