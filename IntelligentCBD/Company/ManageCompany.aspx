<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="ManageCompany.aspx.cs" Inherits="IntelligentCBD.Company.ManageCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery-1.4.4.min.js"></script>
    <style>
        .delBtn{}
        .pic{}
    </style>
    
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
                    <asp:DataPager ID="DataPager1"  PageSize="5" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                            
                </div
                    </LayoutTemplate>
                    <EmptyDataTemplate>
                        <span>没有要管理的企业</span>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <!-- 企业选项还可以设计的更漂亮些（企业名称横着一排显示）-->
                        <!-- 每一个要显示的label都要用Server.HtmlEncode重新编码，防止JavaScript注入攻击-->
                        <div style="padding: 10px; margin: 10px; border: solid; border-width: 1px; border-color: black;width:700px;height:120px">
                            <div style="float:left;width:150px;height:100px; margin: 10px">
                                <asp:Image ID="Image企业宣传图片" ImageUrl='<%#t.TransformPicAddress( Eval("图片地址").ToString()) %>'  CssClass="pic" Width="150px" Height="100px" runat="server" />
                                <asp:Label ID="Label企业ID" runat="server" Text='<%#Eval("ID")%>' Visible="false"/>
                            </div>
                            <div style="float:left;  width:150px;height:100px; margin: 10px">
                                <div style="clear:both;width:130px;height:50px">
                                    企业名称：<br /><asp:Label ID="Label企业名称" runat="server" Text='<%# Server.HtmlEncode(t.cutStr(Eval("企业名称").ToString(),40)) %>'></asp:Label>
                                </div>
                                
                            </div>
                            <div style="float:left;  width:150px;height:100px; margin: 10px">
                                <div style="clear:both;width:130px;height:50px">注册资本：<asp:Label ID="Label注册资本" runat="server" Text='<%#t.LongStr2CapitalStr(Eval("注册资本").ToString()) %>'></asp:Label> </div>
                                <div style="width:130px;height:50px">所属载体：<asp:Label ID="Label所属载体" runat="server" Text='<%# Eval("载体名称") %>' ></asp:Label></div>
                            </div>
                            <div style="float:left;  width:150px;height:100px; margin: 10px">
                                <div style="clear:both;width:130px;height:50px">
                                    <asp:Button ID="ButtonEdit" runat="server" Text="编辑"  OnClick="ButtonEdit_Click"/></div>
                                <div style="width:130px;height:50px"><asp:Button ID="ButtonDel" runat="server" Text="删除" CssClass="delBtn" OnClick="ButtonDel_Click" /></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [企业名称], [注册资本], [载体名称], [图片地址], [ID] FROM [企业视图] WHERE ([录入人] = @录入人)">
                    <SelectParameters>
                        <asp:SessionParameter Name="录入人" SessionField="Username" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <script>
        $(".delBtn").click(function () {
            return confirm("将永久删除企业信息，不可恢复");
        })
        $(".pic").click(function () {
            window.open($(this).attr("src"), "_blank");
        })
    </script>
    
</asp:Content>
