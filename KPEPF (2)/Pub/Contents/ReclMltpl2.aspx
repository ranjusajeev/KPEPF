<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ReclMltpl2, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2>&nbsp;<asp:Label id="lblHead" runat="server" class="MnHead" Text="Reconciliation_Unposted Details" ></asp:Label> </TD></TR><TR><TD align=center colSpan=2><asp:Label id="lblYearD" runat="server" Width="344px" ForeColor="Navy" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> <asp:Label id="lblYearD2" runat="server" Width="344px" ForeColor="Navy" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> <asp:Label id="lblYearD3" runat="server" Width="344px" ForeColor="Navy" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD></TR><TR><TD colSpan=2><asp:GridView id="gdvRecM" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" OnRowCreated="gdvRecM_RowCreated" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury"></asp:BoundField>
<asp:BoundField DataField="EntryMissing_STreas" HeaderText="1">
<ItemStyle Width="7.14%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EntryMissing_ChalanT1" HeaderText="2">
<ItemStyle HorizontalAlign="Right" Width="7.14%"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intYearId,intMonthId,intDTreasuryId,flgTp3" DataNavigateUrlFormatString="~/Contents/ReclMltpl3.aspx?intYearId={0}&amp;intMonthId={1}&amp;intDTreasuryId={2}&amp;flgTp={3}" DataTextField="EntryMissing_EmpT" HeaderText="3">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="intYearId,intMonthId,intDTreasuryId,flgTp2" DataNavigateUrlFormatString="~/Contents/ReclMltpl3.aspx?intYearId={0}&amp;intMonthId={1}&amp;intDTreasuryId={2}&amp;flgTp={3}" DataTextField="Unposted_ChalanT" HeaderText="4">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="intYearId,intMonthId,intDTreasuryId,flgTp1" DataNavigateUrlFormatString="~/Contents/ReclMltpl3.aspx?intYearId={0}&amp;intMonthId={1}&amp;intDTreasuryId={2}&amp;flgTp={3}" DataTextField="Unposted_empT" HeaderText="5">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="TotT" HeaderText="Total">
<ItemStyle HorizontalAlign="Right" Width="7.14%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Missing_Docs" HeaderText="1*">
<ItemStyle Width="7.14%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Unposted_ChalanAG" HeaderText="2*">
<ItemStyle Width="7.14%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EntryMissing_EmpAG" HeaderText="3*">
<ItemStyle Width="7.14%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EntryMissing_TEMinus" HeaderText="4*">
<ItemStyle Width="7.14%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="EntryMissing_ChalanAG" HeaderText="5*">
<ItemStyle Width="7.14%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Unposted_empAG" HeaderText="6*">
<ItemStyle Width="7.14%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TotAG" HeaderText="Total">
<ItemStyle Width="7.14%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GTot" HeaderText="Grand Total">
<ItemStyle HorizontalAlign="Right" Width="7.14%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=left><asp:Label id="lblTDet" runat="server" ForeColor="Blue" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lblAGDet" runat="server" ForeColor="Blue" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label></TD></TR><TR><TD align=left><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Reconciliation" Height="23px"></asp:LinkButton></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>

