<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainSite.Master" AutoEventWireup="true" CodeBehind="ShowCompany.aspx.cs" Inherits="IntelligentCBD.Company.ShowCompany" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script src="../js/jquery-1.4.4.min.js"></script>--%>
    <script src="../scripts/jquery-1.8.2.min.js"></script>
    <script src="../scripts/jquery.SuperSlide.2.1.1.js"></script>
    <script src="../scripts/jquery.raty.min.js"></script>
    <script src="../scripts/readmore.min.js"></script>
    <style type="text/css">
        /* css 重置 */
        * {
            margin: 0;
            padding: 0;
            list-style: none;
        }
        /*body{ background:#fff; font:normal 12px/22px 宋体;  }*/
        img {
            border: 0;
        }

        a {
            text-decoration: none;
            color: #333;
        }

        /* 本例子css */
        .slideBox {
            width: 300px;
            height: 180px;
            overflow: hidden;
            position: relative;
            border: 1px solid #ddd;
        }

            .slideBox .hd {
                height: 15px;
                overflow: hidden;
                position: absolute;
                right: 5px;
                bottom: 5px;
                z-index: 1;
            }

                .slideBox .hd ul {
                    overflow: hidden;
                    zoom: 1;
                    float: left;
                }

                    .slideBox .hd ul li {
                        float: left;
                        margin-right: 2px;
                        width: 15px;
                        height: 15px;
                        line-height: 14px;
                        text-align: center;
                        background: #fff;
                        cursor: pointer;
                    }

                        .slideBox .hd ul li.on {
                            background: #f00;
                            color: #fff;
                        }

            .slideBox .bd {
                position: relative;
                height: 100%;
                z-index: 0;
            }

                .slideBox .bd li {
                    zoom: 1;
                    vertical-align: middle;
                }

                .slideBox .bd img {
                    width: 300px;
                    height: 180px;
                    display: block;
                }

            /* 下面是前/后按钮代码，如果不需要删除即可 */
            .slideBox .prev,
            .slideBox .next {
                position: absolute;
                left: 3%;
                top: 50%;
                margin-top: -25px;
                display: block;
                width: 32px;
                height: 40px;
                background: url(../images/slider-arrow.png) -110px 5px no-repeat;
                filter: alpha(opacity=50);
                opacity: 0.5;
            }

            .slideBox .next {
                left: auto;
                right: 3%;
                background-position: 8px 5px;
            }

                .slideBox .prev:hover,
                .slideBox .next:hover {
                    filter: alpha(opacity=100);
                    opacity: 1;
                }

            .slideBox .prevStop {
                display: none;
            }

            .slideBox .nextStop {
                display: none;
            }

        .auto-style6 {
            width: 350px;
        }

        .auto-style7 {
            font-size: 15px;
            width: 150px;
            vertical-align: top;
        }

        .auto-style10 {
            font-size: 15px;
            width: 200px;
            vertical-align: top;
        }

        .auto-style13 {
            font-size: 15px;
            width: 200px;
            vertical-align: top;
        }

        .auto-style16 {
            font-size: 15px;
            font-size: 15px;
            width: 100px;
            vertical-align: top;
        }

        .auto-style17 {
            font-size: 15px;
            width: 100px;
            vertical-align: top;
        }

        .auto-style19 {
            font-size: 15px;
            width: 200px;
            vertical-align: top;
            height: 26px;
        }

        .auto-style20 {
            font-size: 15px;
            width: 100px;
            vertical-align: top;
            height: 26px;
        }

        .auto-style21 {
            width: 90px;
        }

        .auto-style22 {
            width: 90px;
            height: 100px;
        }

        .auto-style23 {
            height: 100px;
        }

        .raty {
        }

        .auto-style24 {
            font-size: 15px;
            vertical-align: top;
        }
    </style>
    <table style="width: 900px">
        <tr>
            <td class="auto-style6" rowspan="5">
                <div id="slideBox" class="slideBox">
                    <div class="hd">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <HeaderTemplate>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><%# Eval("Num")%></li>
                            </ItemTemplate>
                            <FooterTemplate></ul></FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="bd">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <HeaderTemplate>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><a href='<%#Eval("图片地址").ToString().Replace("~","..") %>' target="_blank">
                                    <img src='<%#Eval("图片地址").ToString().Replace("~","..") %>' /></a></li>
                            </ItemTemplate>
                            <FooterTemplate></ul></FooterTemplate>
                        </asp:Repeater>
                    </div>

                    <!-- 下面是前/后按钮代码，如果不需要删除即可 -->
                    <a class="prev" href="javascript:void(0)"></a>
                    <a class="next" href="javascript:void(0)"></a>

                </div>
            </td>
            <td style="font-size: 20px; font-weight: bold" class="auto-style7">企业名称:</td>
            <td colspan="3" style="vertical-align: top">
                <asp:Label ID="LabelCompanyName" runat="server" Font-Size="18px" Width="400px" CssClass="WordWrap" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 200px; height: 24px" colspan="4">
                <div style="font: 11px verdana;" id="BigStar"></div>
            </td>
        </tr>

        <tr>
            <td class="auto-style7">联系电话：</td>
            <td class="auto-style13">
                <asp:Label ID="LabelPhone" runat="server" CssClass="WordWrap"></asp:Label>
            </td>
            <td class="auto-style16">联系人：</td>
            <td class="auto-style10">
                <asp:Label ID="LabelContact" runat="server" CssClass="WordWrap"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">所属载体：</td>
            <td class="auto-style13">
                <asp:Label ID="LabelVector" runat="server"></asp:Label>
            </td>
            <td class="auto-style16">注册资本：</td>
            <td class="auto-style10">
                <asp:Label ID="LabelCapital" runat="server"></asp:Label>&nbsp;RMB
            </td>
        </tr>
        <tr>
            <td class="auto-style7">地址：</td>
            <td class="auto-style19">
                <asp:Label ID="LabelAddress" runat="server" CssClass="WordWrap"></asp:Label>
            </td>
            <td class="auto-style20">房间号：</td>
            <td class="auto-style19">
                <asp:Label ID="LabelRoomNum" runat="server" CssClass="WordWrap"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7"></td>
            <td class="auto-style13"></td>
            <td class="auto-style17"></td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp" ActiveTabIndex="0" Width="850px" OnActiveTabChanged="TabContainer1_ActiveTabChanged"
                    OnDemand="true">

                    <ajaxToolkit:TabPanel runat="server" HeaderText="基本信息" ID="TabPanelInfo" OnDemandMode="Once">
                        <ContentTemplate>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="auto-style21">所属行业：</td>
                                    <td>
                                        <asp:Label ID="LabelIndustry" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style21">物业面积：</td>
                                    <td>
                                        <asp:Label ID="LabelArea" runat="server"></asp:Label>㎡
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style22">企业简介：</td>
                                    <td class="auto-style23">
                                        <asp:Label ID="LabelIntroduction" Width="300px" runat="server" Style="word-wrap: break-word; word-break: break-all; height: 100px; overflow-y: scroll;" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
                                    </td>
                                    <td class="auto-style23"></td>
                                    <td class="auto-style22">经营范围：</td>
                                    <td class="auto-style23">
                                        <asp:Label ID="LabelBusinessScope" runat="server" Style="word-wrap: break-word; word-break: break-all; height: 100px; overflow-y: scroll;" Width="300px" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style21">注册日期：</td>
                                    <td>
                                        <asp:Label ID="LabelRegistrationDate" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style21">注册地：</td>
                                    <td>
                                        <asp:Label ID="LabelRegisteredAddress" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style21">QQ:</td>
                                    <td>
                                        <asp:Label ID="LabelQQ" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td class="auto-style21">电子邮箱：</td>
                                    <td>
                                        <asp:Label ID="LabelEmail" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2" class="auto-style21">企业宣传内容：</td>

                                    <td>&nbsp;</td>
                                    <td class="auto-style21">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <hr />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="LabelContent" runat="server" Style="word-wrap: break-word; word-break: break-all; height: 100px" Width="800px"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanelPic" runat="server" HeaderText="相关证照" OnDemandMode="Once">
                        <ContentTemplate>
                            <asp:Repeater ID="Repeater3" runat="server" OnItemCreated="Repeater3_ItemCreated">
                                <HeaderTemplate>
                                    <h2></h2>
                                    <br />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="clear: both">
                                        <div style="height: 30px"><%# DataBinder.Eval(Container.DataItem,"类型名称") %>：</div>
                                        <asp:Repeater ID="Repeater4" runat="server">
                                            <ItemTemplate>
                                                <div style="float: left; width: 170px; height: 120px">
                                                    <a href='<%# DataBinder.Eval(Container.DataItem,"图片地址").ToString().Replace("~","..") %>' target="_blank">
                                                        <asp:Image ID="img" runat="server" Width="150px" Height="110px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"图片地址")  %>' /></a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <hr style="clear: both;" />
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanelComments" runat="server" HeaderText="评论" OnDemandMode="Always">
                        <ContentTemplate>
                            <div style="margin: 20px 20px 5px 25px">
                                <a href="../Comment/AddComment.aspx?comID=<%=companyID %>" style="text-decoration: none; text-align: center; line-height: 30px" target="_blank">
                                    <div style="width: 100px; height: 30px; color: #FFFFFF; background-color: #FF7200; font-weight: bold; font-size: 16px;">写评论</div>
                                </a>
                            </div>
                            <asp:ListView ID="ListViewComment" runat="server" OnItemDataBound="ListViewComment_ItemDataBound">
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


                                        <asp:Repeater ID="Repeater5" runat="server">
                                            <ItemTemplate>
                                                <div style="float: left; width: 70px; height: 50px">
                                                    <a href='<%# DataBinder.Eval(Container.DataItem,"图片地址").ToString().Replace("~","..") %>' target="_blank">
                                                        <asp:Image ID="img" runat="server" Width="65px" Height="45px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"图片地址")  %>' />
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <div style="clear: both; width: 600px; margin: 10px">
                                            <article>
                                                <%-- 内容在录入时已经进行过HtmlEncode编码 --%>
                                                <asp:Label Style="word-break: break-all;" ForeColor="#BD7F00" ID="LabelExplanation" runat="server"></asp:Label>
                                            </article>
                                        </div>
                                        <hr style="clear: both" />
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ID], [内容], [录入人], [星级], [录入时间], [是否匿名] FROM [评论] WHERE ([所属企业] = @所属企业)">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="所属企业" QueryStringField="comID" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>--%>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4" OnDemandMode="Once">
                        <ContentTemplate>
                            I'm tab 4. Hey, I&#39;m loaded only once!<br />
                            I was rendered at
                    <%= DateTime.Now.ToString("T") %>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
        </tr>
    </table>
    <script type="text/javascript">
        jQuery(".slideBox").slide({ mainCell: ".bd ul", autoPlay: true, trigger: "click" });

        $(function () {
            $("#BigStar").raty({
                path: "../Images/Ratyimg",
                readOnly: true,
                size: 24,
                half: true,
                start: <%=bigStar%>,
                starHalf:   'star-half-big.png',
                starOff:    'star-off-big.png',
                starOn:     'star-on-big.png'
            })
        })
        function pageLoad() {
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
        }
    </script>

</asp:Content>
