<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverlapRepeater.aspx.cs" Inherits="IntelligentCBD.Test.OverlapRepeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:Repeater ID="Repeater1" runat="server" OnItemCreated="Repeater1_ItemCreated" >
        <HeaderTemplate><h2> </h2><br /></HeaderTemplate>
        <ItemTemplate>
            <%# Eval("类型名称") %><br />
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                   <%# DataBinder.Eval(Container.DataItem,"图片地址")  %><br />
                </ItemTemplate>
            </asp:Repeater>
            
                       
        </ItemTemplate>
        <FooterTemplate>yy<asp:Label ID="label2" runat="server" Text='<%# Eval("图片类型") %>' /></FooterTemplate>
    </asp:Repeater>
        
        
        
        
    </div>
    </form>
</body>
</html>
