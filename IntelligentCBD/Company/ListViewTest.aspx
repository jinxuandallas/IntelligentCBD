<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="ListViewTest.aspx.cs" Inherits="IntelligentCBD.Company.ListViewTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="width: 900px;">
        <tr>
            <td  class="TableTitle" style="width:150px">管理企业信息</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 19px"></td>
            <td style="height: 19px"></td>
            <td style="height: 19px"></td>
            <td style="height: 19px"></td>
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
                      <div style="padding: 10px; margin: 10px; border: solid; border-width: 1px; border-color: black;width:700px;height:100px">
                            <div style="float:left;width:150px;height:90px; margin: 10px"><asp:Image ID="Image企业宣传图片" ImageUrl='<%# t.TransformPicAddress(Eval("默认图片").ToString()) %>'  Width="120px" Height="70px" runat="server" />
                                <asp:Label ID="Label企业ID" runat="server" Text='<%#Eval("ID")%>' Visible="false"/></div>
                            <div style="float:left;  width:150px;height:90px; margin: 10px">
                                    企业名称：<asp:Label ID="Label企业名称" runat="server" Text='<%#t.cutStr(Eval("企业名称").ToString(),40)%>'></asp:Label>
                                
                            </div>
                            <div style="float:left;  width:150px;height:100px; margin: 10px">
                                <div style="clear:both;width:130px;height:50px">注册资本：<asp:Label ID="Label注册资本" runat="server" Text='<%#t.LongStr2CapitalStr(Eval("注册资本").ToString())%>'/></div>
                                <div style="width:130px;height:50px">所属载体：<asp:Label ID="Label载体" runat="server" Text='<%#Eval("载体")%>'/></div>
                            </div>
                            <div style="float:left;  width:150px;height:100px; margin: 10px">
                                <div style="clear:both;width:130px;height:50px"><asp:Button ID="edit" Text="编辑" runat="server"  OnClick="edit_Click"/></div>
                                <div style="width:130px;height:50px"><asp:Button ID="del" Text="删除" runat="server" /></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT 企业.企业名称, 企业.注册资本, 企业.联系人, 企业.ID, 企业.载体,默认图片 FROM 企业 "></asp:SqlDataSource>
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
