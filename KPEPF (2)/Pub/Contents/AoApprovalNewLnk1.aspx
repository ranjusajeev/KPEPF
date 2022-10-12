<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AoApprovalNewLnk1, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="AO Approval"></asp:Label> </TD></TR><TR><TD style="WIDTH: 1029px; HEIGHT: 25px" align=center colSpan=2><asp:Label id="lblType" runat="server" ForeColor="Navy" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD></TR><TR><TD style="WIDTH: 970px; HEIGHT: 64px" align=center><TABLE><TBODY><TR><TD style="WIDTH: 46px; HEIGHT: 16px" align=left><asp:Label id="Label2" runat="server" Width="88px" ForeColor="Blue" Font-Bold="True" Text="Year" Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label></TD><TD style="WIDTH: 103px; HEIGHT: 16px"></TD><TD style="WIDTH: 115px; HEIGHT: 16px" align=left><asp:Label id="Label3" runat="server" Width="104px" ForeColor="Blue" Font-Bold="True" Text="Month" Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 16px"></TD></TR><TR><TD colSpan=4><asp:GridView id="gdvAOApprov" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="Chalan details" DataTextField="ChalDet" DataNavigateUrlFormatString="~/Contents/AoApprovalNewLnk2.aspx?intChalanId={0}&amp;intDistID={1}" DataNavigateUrlFields="intChalanId,intDistID">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Chalan Amt.">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltTotalSum" HeaderText="Schedule Amt.">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD colSpan=4><asp:GridView id="gdvAOApprovWith" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AccNo" HeaderText="Acc. No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>

<asp:BoundField DataField="fltAdvAmt" HeaderText="Withdrawal Amt.">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dtSantion" HeaderText="Sanction Date">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=left colSpan=2><asp:LinkButton id="btnBack" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Approve" Height="23px" PostBackUrl="~/Contents/AoApprovalNew.aspx"></asp:LinkButton></TD><TD align=left colSpan=2><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="70px" ForeColor="Navy" Text="Approve" Height="28px" Font-Size="Small" Visible="False"></asp:Button> </TD></TR></TBODY></TABLE><%--  </asp:Panel>--%></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

