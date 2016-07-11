<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainSite.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="IntelligentCBD._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       .imgbtn{
           vertical-align:bottom;
       }
      
   </style>
     <table style="width:1200px;">
        <tr>
            <td style="width: 250px">&nbsp;</td>
            <td style="width: 700px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td style="width: 250px">&nbsp;</td>
            <td style="width: 700px">&nbsp;
                <img alt="" src="Images/title3.png" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 250px; height: 40px"></td>
            <td style="width: 700px; height: 40px;vertical-align:bottom">
                &nbsp;<asp:TextBox ID="TextBoxSearch" runat="server" BorderColor="#186AE4" BorderStyle="Solid" BorderWidth="1px" Height="25px" Width="400px" Wrap="False" MaxLength="100" /><asp:ImageButton ID="ImgBtnSearch" runat="server" ImageUrl="~/Images/Search.jpg"   CssClass="imgbtn" OnClick="ImgBtnSearch_Click" />
            </td>
            <td class="auto-style3" style="height: 40px"></td>
        </tr>
        <tr>
            <td style="width: 250px">&nbsp;</td>
            <td style="width: 700px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
