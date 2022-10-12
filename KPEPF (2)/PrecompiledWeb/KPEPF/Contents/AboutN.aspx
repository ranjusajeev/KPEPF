<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AboutN, App_Web_rihpu3hj" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" runat="server" Text=" K P E P F " CssClass="MnHead"></asp:Label></TD></TR><TR><TD></TD></TR>

<tr><td>
<asp:Label ID="lblTxt1" runat="server" CssClass="p1" Text="Content Owned, Maintained and Updated By: Grama Panchayats,DDPs and Directorate of Panchayats"></asp:Label>
</td></tr>

<TR><TD align=center><asp:Button id="btnOk" runat="server" Width="43px" Text="Ok" CssClass="button"></asp:Button></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

