<%@ page language="C#" autoeventwireup="true" inherits="Contents_MenuTest, App_Web_ypdhnn_y" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Menu binding to declarative datasources | RadMenu Demo</title>
  <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Menu ID="Menu1" runat="server" BackColor=aquamarine
             DynamicHorizontalOffset="4" Font-Names="Verdana" Font-Size="0.8em" 
            ForeColor="White" Orientation="Horizontal" StaticSubMenuIndent="10px">
            <StaticSelectedStyle BackColor="Black" BorderColor="Aqua"
                BorderStyle="Solid" BorderWidth="2px" ItemSpacing="10px" />
            <StaticMenuItemStyle VerticalPadding="2px" 
                BackColor="Black" Font-Names="Courier New,Courier,Arial,Helvetica" 
                Font-Size="200%" ForeColor="#CCCCCC" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="1px" ItemSpacing="10px" />
            <StaticHoverStyle BackColor="Black" ForeColor="#CCCCCC" BorderColor="#666666" 
                BorderStyle="Solid" BorderWidth="1px" 
                Font-Names="Courier New,Courier,Arial,Helvetica" Font-Strikeout="False" />
            <Items>
                <asp:MenuItem Text="Home" Value="Home" >
                <asp:MenuItem Text="HomeSub1" Value="HomeSub1" NavigateUrl="~/Login.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Login" Value="Login" NavigateUrl="~/Login.aspx"></asp:MenuItem>
                <asp:MenuItem Text="About" Value="About"></asp:MenuItem>
            </Items>
            <StaticItemTemplate>
                <%# Eval("Text") %>
            </StaticItemTemplate>
        </asp:Menu>
 
    </form>
</body>
</html>
