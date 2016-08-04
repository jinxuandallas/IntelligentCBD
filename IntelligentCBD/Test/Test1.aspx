<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="IntelligentCBD.Test.Test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="~/Images/noImg.jpg" runat="server" />
        </div>

        <br />
        <div style="width: 120px; height: 35px; color: #FFFFFF; background-color: #FF7200; font-weight: bold; text-align: center;">
            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" Font-Underline="false" Font-Size="18">添加评论</asp:LinkButton>
        </div>

        <br />
        <a href="../Comment/AddComment.aspx" target="_blank" style="text-decoration-style:none">
            <div style="width: 100px; height: 30px; color: #FFFFFF; background-color: #FF7200; font-weight: bold; text-align: center; font-size: 16px;text-decoration:none;vertical-align:central">
                添加评论
            </div>
        </a>
        <br />
        <a href="~\default.aspx" style=" text-decoration: none;text-align: center;line-height:30px" target="_blank" ><div  style="width: 100px; height: 30px; color: #FFFFFF; background-color: #FF7200; font-weight: bold;  font-size: 16px;">首页</div></a>
        <br />
        <div style="width: 100px; height: 30px; color: #FFFFFF; background-color: #FF7200; font-weight: bold;  font-size: 16px;line-height:30px">首页</div>
    </form>

</body>
</html>
