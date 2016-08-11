<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="ManageCompanyComments.aspx.cs" Inherits="IntelligentCBD.Comment.ManageCompanyComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../scripts/jquery-1.8.2.min.js"></script>
    <script src="../scripts/jquery.raty.min.js"></script>
    <script src="../scripts/readmore.min.js"></script>
    <style>
        .raty {
        }
    </style>
    <asp:ScriptManager ID="ScriptManager3" runat="server"></asp:ScriptManager>
    <table style="border: 1px solid #d8d8d8;width:800px"><tr><td>
    <asp:ListView ID="ListViewComment" runat="server" OnItemDataBound="ListViewComment_ItemDataBound">
        <LayoutTemplate>
            <div id="itemPlaceholder" style="width: 800px" runat="server"></div>
            <div style="width: 800px; text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                <asp:DataPager ID="DataPager1" PageSize="10" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <EmptyDataTemplate>
            <span>目前还没有评论</span>
        </EmptyDataTemplate>
        <ItemTemplate>
            <!-- 企业选项还可以设计的更漂亮些（企业名称横着一排显示）-->
            <!-- 每一个要显示的label都要用Server.HtmlEncode重新编码，防止JavaScript注入攻击-->
            <div style="clear: both; padding: 5px; margin: 10px; width: 800px; font-size: 13px">
                <div style="width: 600px; margin: 10px"><%# Eval("企业名称") %></div>
                <div>
                    <div style="float: left; width: 600px; margin: 10px">
                        <asp:Label ID="CommentID" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label>

                        <input type="hidden" value='<%#Eval("星级") %>' />
                        <div style="float: left; font: 11px verdana;" id="Star" class="raty" runat="server"></div>
                    </div>

                </div>
                <div style="clear: both; width: 600px; margin: 10px">
                    <article>
                        <%-- 内容在录入时已经进行过HtmlEncode编码 --%>
                        <asp:Label Style="word-break: break-all" ID="LabelComment" runat="server" Text='<%# Eval("内容") %>'></asp:Label>
                    </article>
                </div>
                <div style="width: 600px; margin: 10px; color: #CFCCD2">
                    <asp:Literal ID="Date" runat="server" Text='<%#commentc.ConvertDate(Eval("录入时间").ToString()) %>'></asp:Literal>
                </div>


                <asp:Repeater ID="RepeaterCommentPic" runat="server">
                    <ItemTemplate>
                        <div style="float: left; width: 70px; height: 50px">
                            <a href='<%# DataBinder.Eval(Container.DataItem,"图片地址").ToString().Replace("~","..") %>' target="_blank">
                                <asp:Image ID="img" runat="server" Width="65px" Height="45px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"图片地址")  %>' />

                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div style="clear: both; width: 600px; margin: 10px">
                            <asp:Button ID="Explanation" runat="server" Text="追加解释" OnClick="Explanation_Click" />
                            <article>
                                <%-- 内容在录入时已经进行过HtmlEncode编码 --%>
                                <asp:Label Style="word-break: break-all;" ForeColor="#BD7F00" ID="LabelExplanation" runat="server"></asp:Label>
                            </article>
                        </div>
                        <hr style="clear: both" />

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </ItemTemplate>
    </asp:ListView>
    </td></tr></table>
    <script>
        $(function () {
            $(".raty").each(function () {
                var ratyValue = $(this).parent().find("input[type=hidden]").val();
                $(this).raty({
                    path: "../Images/Ratyimg",
                    readOnly: true,
                    start: ratyValue
                });
            })

        })

        $("article").readmore({
            collapsedHeight: 62,
            moreLink: '<a style="text-decoration: none;text-align: right; font-size: 13px;color: blue"  href="#">展开</a>',
            lessLink: '<a style="text-decoration: none;text-align: right; font-size: 13px;color: blue" href="#">收起</a>'
        });
    </script>
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="padding: 15px; border: 1px solid #CCCCCC; width: 500px; height: 300px; top: 150px; left: 300px; position: fixed; background-color: white" id="AddExplanation" runat="server" visible="false">
                <div style="margin: 10px">
                    追加解释：<asp:HiddenField ID="HiddenCommentID" runat="server" />
                </div>
                <div style="margin: 10px">
                    <asp:TextBox ID="TextBoxExplanation" runat="server" Width="400px" Height="150px" CssClass="text" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                </div>
                <div style="margin: 10px">
                    <asp:Label ID="LabelPrompt" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <div style="margin: 10px">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="提交" OnClick="ButtonSubmit_Click" />&nbsp;&nbsp;
            <asp:Button ID="ButtonCancel" runat="server" Text="关闭" OnClick="ButtonCancel_Click" Style="height: 21px" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
