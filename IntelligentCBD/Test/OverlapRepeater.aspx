<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverlapRepeater.aspx.cs" Inherits="IntelligentCBD.Test.OverlapRepeater" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

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
            <div style="clear:both"> 
                
            <div style="height:30px"><%# Eval("类型名称") %>：</div>
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <div style="float:left;width:170px;height:120px">
                   <asp:Image ID="img" runat="server"  Width="150px" Height="110px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"图片地址")  %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
           </div><hr style="clear:both; " /><br />
                       
        </ItemTemplate>
       
    </asp:Repeater>
        
        
        
        
    </div>
        
    </form>
</body>
</html>
