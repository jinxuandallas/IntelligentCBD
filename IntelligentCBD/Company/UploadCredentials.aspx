<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="UploadCredentials.aspx.cs" Inherits="IntelligentCBD.Company.UploadCredentials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <style type="text/css">
        .delButton{}
        .pic{}
        .auto-style6 {
            background-color: #0066ff;
            color: white;
            font-size: 1.4em;
            font-weight: bolder;
            text-align: center;
            height: 20px;
            width: 110px;
        }
        .auto-style7 {
            width: 110px;
            height: 20px;
        }
        
    </style>
    <table style="width:550px">
            <tr>
                <td class="auto-style6">上传证照</td>
                <td style="height: 20px;"></td>
                <td style="height: 20px"></td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    &nbsp;</td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    上传图片类型:</td>
                <td style="height: 20px; ">
                    <asp:DropDownList ID="DropDownList_PicType" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource_PicType" DataTextField="类型名称" DataValueField="ID" OnSelectedIndexChanged="DropDownList_PicType_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource_PicType" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [图片类型]"></asp:SqlDataSource>
                </td>
                <td style="height: 20px; ">&nbsp;</td>
                <td style="height: 20px; ">&nbsp;</td>
                <td style="height: 20px; ">&nbsp;</td>
            </tr>
        <tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <td>
                        <div>
                            <asp:Image ImageUrl='<%# Eval("图片地址") %>' ID="img"  CssClass="pic" Height="150px" Width="150px" runat="server"/>
                            <input type="button" id="del" class="delButton" value="删除"/>
                            </div></td>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
        <tr>
                <td class="auto-style7"></td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
            <td style="height: 20px; "></td>
            <td style="height: 20px; "></td>
            </tr>
        <tr>
                <td colspan="5">
<div id="f" style="background-color:#ff6600; width: 350px;">
        <div id="zhi">
            <div id="content">
                <input id="File1" type="file" runat="server"/><input type="button" id="jia" value="添加" /><input
                    type="button" value="删除" id="jian" />
                <br />

            </div>
        </div>
    </div>
    <input type="button" id="tianjia" value="添加新项" />
        <br />
                </td>
            </tr>
         <tr>
                <td colspan="5"><input id="HiddenDelfiles" type="hidden" runat="server"/>
                    <asp:Label ID="LabelPrompt" runat="server" ForeColor="Red"></asp:Label>
                </td>
                    
             </tr>
         <tr>
                <td>
                    <asp:Button ID="Submit" runat="server" Text="提交" Width="70px" OnClick="Submit_Click" />
                </td>
                    
                <td>
                    <asp:Button ID="Reset" runat="server" Text="重置" Width="70px" />
                </td>
                    
                <td>&nbsp;</td>
                    
                <td>&nbsp;</td>
                    
                <td>&nbsp;</td>
                    
             </tr>
        </table>
    <script>
    $(function () {
        var uploadNum=<%=uploadNum%>;
        //让层隐藏
        $("#f").hide();
        //跟添加按钮绑定点击事件
        $("#tianjia").bind("click", function () {
            //点击添加按钮的时候，层显示
            if (uploadNum<1)
                alert("最多只能上传5张图片，请先删除几张图片")
            else
            {
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
            } else
            {
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
        
        $(".delButton").click(function (){
            var h=$("#HiddenDelfiles").attr("value");
            $("#HiddenDelfiles").attr("value",h+";"+$(this).parent().find(".pic").attr("src"));
            uploadNum++;
            $(this).parent().remove();
            //alert($(this).parent().find(".pic").attr("src"));
            //alert($("#Hidden1").attr("value"));
        });
        //*/
        
        $(".pic").click(function(){
            window.open($(this).attr("src"),"_blank")
            //alert($(this).attr("src"));
        })
    })
</script>
</asp:Content>
