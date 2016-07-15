<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainSite.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="IntelligentCBD.Search.Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery-1.4.4.min.js"></script>
    <style>
       .imgbtn{
           vertical-align:bottom;
       }
      .ComName{

      }
   </style>
    <table style="width: 900px;">
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

    <asp:ListView ID="ListViewResult" runat="server" >
                    <LayoutTemplate>
                        <div id="itemPlaceholder" style="width:1000px" runat="server"></div>
                        <div style="width:1000px; text-align : center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                    <asp:DataPager ID="DataPager1" PageSize="10"  runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </div>
                    </LayoutTemplate>
                    <EmptyDataTemplate>
                        <span>没有要管理的企业</span>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <!-- 企业选项还可以设计的更漂亮些（企业名称横着一排显示）-->
                        <!-- 每一个要显示的label都要用Server.HtmlEncode重新编码，防止JavaScript注入攻击-->
                        <div style="clear:both; padding: 5px; margin: 10px;width:800px;height:100px;font-size:13px">
                            <div style="float:left;width:150px;height:100px; margin: 5px">
                                <div style="border:solid;border-width:1px;border-color:black;padding:2px"><asp:ImageButton ID="Image企业宣传图片" ImageUrl='<%#t.TransformPicAddress( Eval("图片地址").ToString()) %>' OnClick="Image企业宣传图片_Click" Width="145px" Height="100px" runat="server" /></div>
                                <asp:Label ID="LabelComID" runat="server" Text='<%#Eval("ID")%>' Visible="false"/>
                            </div>
                            <div style="float:left;width:600px;height:100px; margin: 10px">
                                <div style="clear:both;width:300px;height:30px">
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
                                </div>
                            </div>
                            <hr style="clear:both" />
                        </div>
                                
                    </ItemTemplate>
                </asp:ListView>

 
    <script>
        $(".ComName").mouseover(function () {
            $(this).attr("style", "color:#ff6600;font-size:15px;text-decoration:none");
        })
        $(".ComName").mouseout(function () {
            $(this).attr("style", "color:black;font-size:15px;text-decoration:none");
        })
    </script>
</asp:Content>
