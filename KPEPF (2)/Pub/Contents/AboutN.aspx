<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AboutN, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead">
<asp:Label id="lblHead" runat="server" CssClass="MnHead"  Text="About" ></asp:Label></TD></TR><%--button--%><TR><TD align=center><asp:Button id="btnOk" runat="server" Text="Ok" CssClass="button"></asp:Button></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

