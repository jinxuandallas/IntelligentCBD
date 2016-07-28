<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentTest.aspx.cs" Inherits="IntelligentCBD.Test.CommentTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<script src="../scripts/jquery.min.js"></script>--%>
    <script src="../scripts/jquery-1.8.2.min.js"></script>
    <script src="../scripts/jquery.raty.min.js"></script>
    <script src="../scripts/readmore.min.js"></script>
    <style>
        .raty {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListViewResult" runat="server" DataSourceID="SqlDataSource1" OnItemCreated="ListViewResult_ItemCreated">
                <LayoutTemplate>
                    <div id="itemPlaceholder" style="width: 1000px" runat="server"></div>
                    <div style="width: 1000px; text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
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

                        <div>
                            <div style="float: left; width: 600px; margin: 10px">
                                &nbsp;&nbsp;<asp:Label ID="LabelUsername" runat="server" Text='<%#commentc.ShowAnonymity(Eval("录入人").ToString(),Convert.ToInt16((Eval("是否匿名")))) %>'></asp:Label>&nbsp;&nbsp;
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


                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div style="float: left; width: 100px; height: 80px">
                                    <a href='<%# DataBinder.Eval(Container.DataItem,"图片地址").ToString().Replace("~","..") %>'>
                                        <asp:Image ID="img" runat="server" Width="90px" Height="75px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"图片地址")  %>' />

                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%--<div style="clear:both;width:300px;height:30px">
                                    <asp:LinkButton ID="LinkButton企业名称" CssClass="ComName"  ForeColor="Black" Font-Size="15px" Text='<%# t.cutStr(Server.HtmlEncode(Eval("企业名称").ToString()),60) %>'  OnClick="LinkButton企业名称_Click" Font-Underline="false" runat="server" />
                                </div>
                                <div style="width:500px;height:20px">
                                    <div style="float:left;width:150px;height:20px">注册资本：<asp:Label ID="Label注册资本" runat="server" Text='<%#t.LongStr2CapitalStr(Eval("注册资本").ToString()) %>'></asp:Label></div>
                                    <div style="float:left;width:150px;height:20px">所属载体：<asp:Label ID="Label所属载体" runat="server" Text='<%# Eval("载体名称") %>' ></asp:Label></div> 
                                    <div style="float:left;width:150px;height:20px">房间号：<asp:Label ID="Label房间号" runat="server" Text='<%# t.cutStr(Eval("房间号").ToString(),20) %>' ></asp:Label></div>
                                </div>
                                <div style="width:500px;height:20px">
                                    <div style="float:left;width:150px;height:20px">行&nbsp;&nbsp;业：<asp:Label ID="Label行业" runat="server" Text='<%#t.cutStr(Eval("行业").ToString(),20) %>'></asp:Label></div>
                                    <div style="float:left;width:150px;height:20px">物业面积：<asp:Label ID="Label物业面积" runat="server" Text='<%# Eval("物业面积") %>' ></asp:Label>㎡</div> 
                                    <div style="float:left;width:150px;height:20px">联系人：<asp:Label ID="Label联系人" runat="server" Text='<%# t.cutStr(Eval("联系人").ToString(),20) %>' ></asp:Label></div>
                                </div>--%>
                        <hr style="clear: both" />
                    </div>

                </ItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [内容], [星级], [是否匿名], [录入人], [ID],[录入时间] FROM [评论] WHERE ([所属企业] = @所属企业)">
                <SelectParameters>
                    <asp:SessionParameter Name="所属企业" SessionField="CompanyID" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>

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
                moreLink: '<a style="text-decoration: none;text-align: right; font-size: 13px" href="#">展开</a>',
                lessLink: '<a style="text-decoration: none;text-align: right; font-size: 13px" href="#">收起</a>'
            });
        </script>
    </form>
</body>
</html>
