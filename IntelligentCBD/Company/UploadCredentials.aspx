<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="UploadCredentials.aspx.cs" Inherits="IntelligentCBD.Company.UploadCredentials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <style type="text/css">
        .delButton{}
        .pic{}
        .divpic{}
        .defaultButton{}
        
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
        
        .auto-style8 {
            height: 50px;
        }
        
    </style>
    <input type="hidden" id="HiddenDelFiles" runat="server"/>
     <input type="hidden" id="HiddenDefault" runat="server"/>
    <table style="width:550px">
            <tr>
                <td class="auto-style6">上传证照</td>
                <td style="height: 20px;"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    &nbsp;</td>
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
            </tr>
        
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
            <td colspan="2">
                        <div class="divpic" id="divpic" runat="server" style="vertical-align:middle;writing-mode:vertical-lr;">
                            <asp:Image ImageUrl='<%# Eval("图片地址") %>' ID="img"  CssClass="pic" Height="150px" runat="server"/>
                            <input type="button" id="del" class="delButton" value="删除"/>
                            <input type="button" id="defaultButton" class="defaultButton" value="设为默认" runat="server"/>
                            <br />
                            </div>
                </td>
            </tr>
                    </ItemTemplate>
                </asp:Repeater>
                
        <tr>
                <td class="auto-style7"></td>
                <td style="height: 20px; ">
                   
                   
                </td>
            </tr>
        <tr>
                <td colspan="2" class="auto-style8">
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
                <td colspan="2">
                    <asp:Label ID="LabelPrompt" runat="server" ForeColor="Red"></asp:Label>
                </td>
                    
             </tr>
         <tr>
                <td>
                    <asp:Button ID="Submit" runat="server" Text="提交" Width="70px" OnClick="Submit_Click" />
                </td>
                    
                <td>
                    <asp:Button ID="Reset" runat="server" Text="重置" Width="70px" OnClick="Reset_Click" />
                     
                &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Preview" runat="server" Text="预览" Width="70px" OnClick="Preview_Click" />
                     
                </td>
                    
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
         //删除按钮的处理
        $(".delButton").click(function (){

            //<!--在母版页中的子页会改变原控件的ID，
            //客户端ID会被改为“ContentPlaceHolder1_Hidden2”，添加了ContentPlaceHolder1_前缀，此处需注意。
            var h=$("#ContentPlaceHolder1_HiddenDelFiles").attr("value");
            var src=$(this).parent().find(".pic").attr("src");
            //var i=$("#ContentPlaceHolder1_Hidden2").val();

            //将要删除的文件名存于ContentPlaceHolder1_HiddenDelFiles中
            $("#ContentPlaceHolder1_HiddenDelFiles").attr("value",h+";"+src);
            //$("#ContentPlaceHolder1_Hidden2").val(i+"12");
            uploadNum++;
            //alert($("#ContentPlaceHolder1_HiddenDelFiles").val());
            
            //处理如果删除的是默认图片的处理
            if($("#ContentPlaceHolder1_HiddenDefault").val()==src)
                $("#ContentPlaceHolder1_HiddenDefault").val("");
            $(this).parent().remove();
            //alert($(this).parent().find(".pic").attr("src"));
            //alert($("#ContentPlaceHolder1_HiddenDefault").val());
        });
        //*/
        
        $(".pic").click(function(){
            window.open($(this).attr("src"),"_blank")
            //alert($(this).attr("src"));
        });

        /*
        //下拉框改变的处理
        $("#ContentPlaceHolder1_DropDownList_PicType").change(function(){
            if ($(this).val()=="1")
                $(".defaultButton").show();
            else
            {
                $(".defaultButton").hide();
                //将HiddenDefault值清空（？有没有必要？）
                //$("#HiddenDefault").val("");
            };
            alert($(this).val());
        });
        */
        //设为默认的处理
        $(".defaultButton").click(function(){
            $(".divpic").css('background-color','white');
            $(this).parent().css('background-color','yellow');
            $("#ContentPlaceHolder1_HiddenDefault").val($(this).parent().find(".pic").attr("src"));
            //$("#HiddenDefault").attr("value",$(this).parent().find(".pic").attr("src"));
            //alert($("#ContentPlaceHolder1_HiddenDefault").val());
            //alert($(this).parent().find(".pic").attr("src"));
        });
        
    })
</script>
</asp:Content>
