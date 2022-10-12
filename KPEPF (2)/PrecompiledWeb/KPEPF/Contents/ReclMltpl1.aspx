<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ReclMltpl1, App_Web_m1ijyhfm" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2>&nbsp;<asp:Label id="lblHead" runat="server" class="MnHead" Text="Reconciliation" ></asp:Label> </TD></TR><TR><TD align=center colSpan=2><asp:Label id="lblYearD" runat="server" Width="344px" ForeColor="Navy" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> <asp:Label id="lblYearD2" runat="server" Width="344px" ForeColor="Navy" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD></TR><TR><TD colSpan=2><asp:GridView id="gdvRecM" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" OnRowCreated="gdvRecM_RowCreated" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury"></asp:BoundField>
<asp:BoundField DataField="CrPostedT" HeaderText="Treasury"></asp:BoundField>
<asp:BoundField DataField="CrPostedAG" HeaderText="AG">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TotP" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CrUnpostedT" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CrUnpostedAG" HeaderText="AG">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TotUP" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Tot" HeaderText="Grand Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=left><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to REconciliation" Height="23px"></asp:LinkButton></TD><TD align=left><asp:LinkButton id="btnDet" onclick="btnDet_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Unposted Details" Height="23px"></asp:LinkButton></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>

