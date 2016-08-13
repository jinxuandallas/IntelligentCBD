<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainSite.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="IntelligentCBD.Problems.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../scripts/jquery-1.8.2.min.js"></script>
    <table>
        <tr>
            <td style="width: 200px"></td>
            <td>
                <table style="width: 600px; font-size: 14px; height: 30px" class="MainTable">
                    <tr>
                        <td style="width: 100px; height: 30px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="background-color: #F3F3F3; height: 35px"><span style="color: red; font-size: 18px">&nbsp;反馈问题：*</span>
                        </td>
                    </tr>
                     <tr>
                        <td colspan="3" style="padding: 0px">
                            <table class="TableBox">
                    <tr>
                        <td style="width: 100px; height: 30px">&nbsp;</td>
                        <td style="width: 500px;">&nbsp;
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 30px">&nbsp;</td>
                        <td style="height: 30px">
                            <asp:TextBox ID="TextBoxProblem" runat="server" Height="200px" MaxLength="2000" TextMode="MultiLine" Width="450px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxProblem" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationExpression="[\s\S]{10,2000}"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxProblem" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td style="height: 30px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 30px">&nbsp;</td>
                        <td style="font-size: 12px">10-2000字</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 120px; height: 30px;font-size:14px">上传图片：</td>
                        <td>
                            <div id="f" style="background-color: #ff6600; width: 350px;">
                                <div id="zhi">
                                    <div id="content">
                                        <input id="File1" runat="server" type="file" /><input id="jia" type="button" value="添加" /><input id="jian" type="button" value="删除" />
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <input id="tianjia" type="button" value="添加新项" /></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 30px">&nbsp;</td>
                        <td style="font-size: 12px; color: darkgray">单张图片不要超过2MB，总共不要超过5MB，只支持jpg,png,gif图片格式</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 30px">&nbsp;</td>
                        <td>
                            <asp:Label ID="LabelPrompt" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 30px">&nbsp;</td>
                        <td>
                            <asp:Button ID="Submit" runat="server" Text="提  交" OnClick="Submit_Click" Style="height: 21px" />
                            &nbsp;&nbsp;&nbsp;
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 30px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                                </table>
                            </td>
                         </tr>
                </table>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(function () {
            var uploadNum = 5;
            //让层隐藏
            $("#f").hide();
            //跟添加按钮绑定点击事件
            $("#tianjia").bind("click", function () {
                //点击添加按钮的时候，层显示
                if (uploadNum < 1)
                    alert("最多只能上传5张图片，请先删除几张图片")
                else {
                    $("#f").show();
                    $("#tianjia").hide();
                }

            });
            //添加file控件
            $("#jia").click(function () {
                //克隆id=content下面的元素。添加到id=zhi的div里面
                var shu = $("#f").find("#content").size();
                if (parseInt(shu) < uploadNum) {
                    $("#content").clone(true).appendTo("#zhi");
                    //a--;
                } else {
                    alert("最多不能超过5张图片");
                }

            });
            //删除file控件操作
            $("#jian").click(function () {
                //查找上传控件的个数
                var shu = $("#f").find("#content").size();
                //如果有多，就删除掉
                if (parseInt(shu) > 1) {
                    $(this).parent().remove();
                }
                else {
                    alert("至少保留一个！");
                }
            });
        })
    </script>

</asp:Content>
