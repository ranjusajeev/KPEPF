<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ReclMltpl, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Reconciliation"></asp:Label> </TD></TR><TR><TD align=center colSpan=2><asp:RadioButtonList id="rdTrnType" runat="server" ForeColor="#0000C0" Font-Bold="True" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdTrnType_SelectedIndexChanged" Font-Names="Verdana" Font-Size="10pt">
                    <asp:ListItem Selected="True">Credit</asp:ListItem>
                    <asp:ListItem>Debit</asp:ListItem>
                    
                </asp:RadioButtonList> </TD></TR><TR><TD colSpan=2>&nbsp;</TD></TR><TR align=center><TD colSpan=2><asp:Label id="Label2" runat="server" Text="AG Account" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblTrnTp" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblYrAGCr" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR vAlign=top align=left><TD style="WIDTH: 45%"><asp:GridView id="gdvRecAg" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvYear" HeaderText="Year">
<ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="Credit" DataTextField="TotAmtCr" DataNavigateUrlFormatString="~/Contents/ReclMltpl.aspx?intYearIdAG={0}&intTp={1}" DataNavigateUrlFields="intYearId,int1">
<ItemStyle Width="150px" HorizontalAlign="Right"></ItemStyle>
</asp:HyperLinkField>
<asp:HyperLinkField HeaderText="Debit" DataTextField="TotAmtDt" DataNavigateUrlFormatString="~/Contents/ReclMltpl.aspx?intYearIdAG={0}&intTp={1}" DataNavigateUrlFields="intYearId,int2">
<ItemStyle Width="150px" HorizontalAlign="Right"></ItemStyle>
</asp:HyperLinkField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD style="WIDTH: 60%"><asp:GridView id="gdvRecAgCr" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvMonth" HeaderText="Month">
<ItemStyle Width="45px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CrAmt" HeaderText="Treasury">
<ItemStyle Width="100px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TEAmt" HeaderText="Transfer Entry">
<ItemStyle Width="100px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="totalCr" HeaderText="Total">
<ItemStyle Width="150px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD colSpan=2>&nbsp;</TD></TR><TR><TD align=center colSpan=2><asp:Label id="lblYearDAG" runat="server" Text="..." CssClass="p4" visible="false"></asp:Label> </TD></TR><TR><TD align=center colSpan=2><asp:GridView id="gdvRecAGMth" runat="server" Width="900px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False" OnRowCreated="gdvRecAGMth_RowCreated" ShowFooter="True" Visible="False">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvMonth" HeaderText="Month">
<ItemStyle Width="45px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CrAmt" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TEAmt" HeaderText="Transfer Entry">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="totalCr" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DtAmt" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TEAmtDt" HeaderText="Transfer Entry"></asp:BoundField>
<asp:BoundField DataField="totalDt" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GTot" HeaderText="Grand Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR align=center><TD colSpan=2><asp:Label id="Label1" runat="server" Text="KPEPF Account" CssClass="p1"></asp:Label> </TD></TR><TR align=center><TD style="WIDTH: 100%" colSpan=2><asp:GridView id="gdvRecPF" runat="server" Width="900px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False" OnRowCreated="gdvRecPF_RowCreated">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:HyperLinkField HeaderText="Year" DataTextField="chvYear" DataNavigateUrlFormatString="~/Contents/ReclMltpl.aspx?intYearId={0}" DataNavigateUrlFields="intYearId">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="PostedT" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PostedAG" HeaderText="AG">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TotP" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UnpostedT" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UnpostedAG" HeaderText="AG">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TotAg" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GTot" HeaderText="Grand Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD align=center colSpan=2><asp:Label id="lblYearD" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR><TD align=center colSpan=2><asp:GridView id="gdvRecM" runat="server" Width="900px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False" OnRowCreated="gdvRecM_RowCreated" ShowFooter="True">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:HyperLinkField HeaderText="Month" DataTextField="chvMonth" DataNavigateUrlFormatString="~/Contents/ReclMltpl1.aspx?intMonthId={0}" DataNavigateUrlFields="intMonthId">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="CrPostedT" HeaderText="Treasury">
<ItemStyle Width="45px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
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
<asp:BoundField DataField="TotUp" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="GTot" HeaderText="Grand Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>

