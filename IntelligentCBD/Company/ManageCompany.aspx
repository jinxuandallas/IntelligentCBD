<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="ManageCompany.aspx.cs" Inherits="IntelligentCBD.Company.ManageCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 900px;">
        <tr>
            <td  class="TableTitle" style="width:150px">管理企业信息</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>要管理的企业：</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:ListView ID="ListViewCompany" runat="server" DataSourceID="SqlDataSource1">
                    <LayoutTemplate>
                        <div id="itemPlaceholder" runat="server"></div>
                        <div style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    <asp:DataPager ID="DataPager1"  PageSize="3" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                            
                </div
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div style="width:800px">
                        <div style="padding: 10px; margin: 10px; border: solid; border-width: 1px; border-color: black;width:500px;height:100px">
                            <div style="float:left;width:150px;height:80px; margin: 10px"><asp:Image ID="Image企业宣传图片" ImageUrl='<%# Eval("图片地址") %>'  Width="120px" Height="70px" runat="server" /></div>
                            <div style="float:left;  width:150px;height:80px; margin: 10px">bb</div>
                        </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [企业名称], [注册资本], [载体名称], [联系人], [图片地址], [ID] FROM [企业视图]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
