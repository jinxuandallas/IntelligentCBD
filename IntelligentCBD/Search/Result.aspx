<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainSite.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="IntelligentCBD.Search.Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       .imgbtn{
           vertical-align:bottom;
       }
      
   </style>
    <table style="width: 100%;">
        <tr>
            <td class="auto-style1" style="width: 5px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 5px">&nbsp;
                </td>
            <td style="vertical-align:bottom;height:40px">
                <img src="../Images/title4.png" style="vertical-align:bottom;" /><asp:TextBox ID="TextBoxSearch" runat="server" BorderColor="#186AE4" BorderStyle="Solid" BorderWidth="1px" Height="25px" Width="400px" Wrap="False" MaxLength="100" /><asp:ImageButton ID="ImgBtnSearch" runat="server" ImageUrl="~/Images/Search.jpg"   CssClass="imgbtn" OnClick="ImgBtnSearch_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 5px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <ul>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <li>
                <%# Eval("企业名称") %><br />
            </li>
        </ItemTemplate>
    </asp:Repeater>
        </ul>
</asp:Content>
