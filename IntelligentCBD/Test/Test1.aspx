﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="IntelligentCBD.Test.Test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="~/Images/noImg.jpg" runat="server" />
    </div>
    </form>
    
</body>
</html>