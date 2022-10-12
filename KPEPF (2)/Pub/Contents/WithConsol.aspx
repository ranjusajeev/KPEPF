<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ConsolWith, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE><TBODY><TR class="TdMnHead" colSpan=2><asp:Label id="Label6" runat="server" class="MnHead" Text="Consolidation" ></asp:Label></TD></TR><TR><TD style="WIDTH: 983px; HEIGHT: 159px" align=center><asp:GridView id="gdvWith" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2"><Columns>
<asp:BoundField HeaderText="SlNo"></asp:BoundField>
<asp:BoundField HeaderText="Transaction Date" DataField="dtmBill"></asp:BoundField>
<asp:BoundField HeaderText="Bill Amount" DataField="fltBillAmount"></asp:BoundField>
<%--<asp:TemplateField HeaderText="Transaction Date"><ItemTemplate>
<asp:TextBox id="txtDate" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Amount"><ItemTemplate>
<asp:TextBox id="fltBillAmount" runat="server"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>--%>
<%--<asp:TemplateField HeaderText="ChkAll"><HeaderTemplate>
<asp:CheckBox id="Allchk1" runat="server" Text="Check All" __designer:wfdid="w6" AutoPostBack="True" OnCheckedChanged="Allchk1_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkApp1" runat="server" __designer:wfdid="w4" AutoPostBack="True"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>--%>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR>
<tr>
<td>
<asp:HyperLink runat="server" ID="hlBack" Text="Back" NavigateUrl="~/Contents/Withdrawals.aspx" Font-Bold="True" Font-Size="Larger" Width="40px"></asp:HyperLink>
</td>
</tr></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

