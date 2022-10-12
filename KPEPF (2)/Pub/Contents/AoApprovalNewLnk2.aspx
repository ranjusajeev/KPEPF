<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AoApprovalNewLnk2, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="AO Approval"></asp:Label> </TD></TR><TR><TD style="WIDTH: 1029px; HEIGHT: 25px" align=center colSpan=2><asp:Label id="lblType" runat="server" ForeColor="Navy" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD></TR><TR><TD style="WIDTH: 970px; HEIGHT: 64px" align=center><TABLE><TBODY><TR><TD style="WIDTH: 46px" align=left><asp:Label id="Label2" runat="server" Width="88px" ForeColor="Blue" Font-Bold="True" Text="Year" Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label></TD><TD style="WIDTH: 115px" align=left><asp:Label id="Label3" runat="server" Width="104px" ForeColor="Blue" Font-Bold="True" Text="Month" Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label></TD></TR><TR><TD colSpan=4><asp:GridView id="gdvAOApprov" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ChalDet" HeaderText="Chalan det">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Chalan Amt.">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><%--<TR><TD style="WIDTH: 46px" align=left><asp:Label id="Label12" runat="server" Width="88px" ForeColor="Blue" Font-Bold="True" Text="Schedule" Font-Size="10pt" Font-Names="Verdana"></asp:Label></TD><TD style="WIDTH: 103px"><asp:DropDownList id="ddlSched" tabIndex=4 runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="ddlSched_SelectedIndexChanged"></asp:DropDownList></TD></TR>--%><TR><TD colSpan=4><asp:GridView id="gdvAOApprovSched" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvPF_No" HeaderText="Acc. No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvUnPosted" HeaderText="UnIdentified">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltMsAmt" HeaderText="Subn.">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltRfAmt" HeaderText="Repay.">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltPfAmt" HeaderText="PF">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltDaAmt" HeaderText="DA">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltPayAmt" HeaderText="Pay">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltTotAmt1" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=left colSpan=2><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Approve" Height="23px"></asp:LinkButton></TD><TD align=left colSpan=2><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="70px" ForeColor="Navy" Text="Approve" Height="28px" Font-Size="Small" Visible="False"></asp:Button> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

