<%@ control language="C#" autoeventwireup="true" inherits="Contents_MsgUCtrl, App_Web_ypdhnn_y" %>
<link rel="stylesheet" type="text/css" href="../themes/styleL.css" />
<div class="container">
<asp:Panel ID="MessageBox" runat="server">
<asp:HyperLink runat="server" id="CloseButton" >
<asp:Image ID="Image1" runat="server" ImageUrl="~/images/ikm.png" 
AlternateText="Click here to close this message" />
</asp:HyperLink>
<p>
<asp:Literal ID="litMessage" runat="server"></asp:Literal></p>
</asp:Panel>
</div>