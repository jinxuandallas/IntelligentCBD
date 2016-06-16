<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="UploadCredentials.aspx.cs" Inherits="IntelligentCBD.Company.Credentials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .delButton{}
        .pic{}
        .auto-style6 {
            background-color: #0066ff;
            color: white;
            font-size: 1.4em;
            font-weight: bolder;
            text-align: center;
            height: 20px;
            width: 110px;
        }
        .auto-style7 {
            width: 110px;
            height: 20px;
        }
    </style>
    <table style="width:750px">
            <tr>
                <td class="auto-style6">上传证照</td>
                <td style="height: 20px;"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    &nbsp;</td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
            </tr>
        <tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <td style="height: 20px; ">
                        <div id="pic">
                            <asp:Image ImageUrl='<%# Eval("图片地址") %>' ID="img"  CssClass="pic" Height="150px" Width="150px" runat="server"/>
                            <input type="button" id="del" class="delButton" value="删除"/>
                            </div></td>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
        <tr>
                <td class="auto-style7"></td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
            <td style="height: 20px; "></td>
            <td style="height: 20px; "></td>
            </tr>
        </table>
</asp:Content>
