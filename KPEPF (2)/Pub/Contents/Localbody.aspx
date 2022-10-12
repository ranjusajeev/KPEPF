<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_Localbody, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead">&nbsp; <asp:Label id="lblHead" class="MnHead" runat="server" Text="Localbody"></asp:Label> </TD></TR><TR><TD align=center><asp:Panel id="pnlLb" runat="server"><TABLE style="WIDTH: 100%"><TBODY><TR><TD>&nbsp;</TD></TR><TR align=center><TD><asp:Label id="Year" runat="server" ForeColor="#0000C0" Text="District" Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlDist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
 </asp:DropDownList></TD><TD><asp:Label id="Year1" runat="server" ForeColor="#0000C0" Text="LB Type" Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlLBType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLBType_SelectedIndexChanged">
 </asp:DropDownList></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD align=center colSpan=4><asp:GridView id="gdvLb" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" ReadOnly="True">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvLBCode" HeaderText="LB Code">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryNameD" HeaderText="Dist. Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryNameDisp" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD align=center></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD align=center><asp:Panel id="pnlT" runat="server"><TABLE style="WIDTH: 100%"><TBODY><TR align=center><TD><asp:Label id="Year2" runat="server" ForeColor="#0000C0" Text="District" Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlDistT" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistT_SelectedIndexChanged">
 </asp:DropDownList></TD><TD><asp:Label id="Year11" runat="server" ForeColor="#0000C0" Text="Treasury Type" Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlTType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTType_SelectedIndexChanged">
 </asp:DropDownList></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD align=center colSpan=4><asp:GridView id="gdvT" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryCode" HeaderText="Treasury Code">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryNameDisp" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Dist. Treasury">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD align=center></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD align=center><asp:Panel id="pnlLBAdd" runat="server"><TABLE style="WIDTH: 100%" border=2><TBODY><TR style="WIDTH: 40px"><TD>&nbsp;</TD><TD align=left><asp:Label id="lbl31" runat="server" Text="District" CssClass="p3"></asp:Label>&nbsp;&nbsp;<asp:DropDownList id="ddlDistLBAdd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistLBAdd_SelectedIndexChanged">
 </asp:DropDownList></TD><TD style="TEXT-ALIGN: left"><asp:Label id="lbl32" runat="server" Text="Localbody Type" CssClass="p3"></asp:Label>&nbsp;&nbsp;<asp:DropDownList id="ddlLBTypeLBAdd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLBTypeLBAdd_SelectedIndexChanged">
 </asp:DropDownList></TD><TD>&nbsp;</TD></TR><TR style="WIDTH: 40px"><TD>&nbsp;</TD><TD align=left><asp:Label id="lbl44" runat="server" Text="Localbody Name" CssClass="p3"></asp:Label> <asp:TextBox id="txtLBName" runat="server" MaxLength="50"></asp:TextBox> </TD><TD style="TEXT-ALIGN: left"><asp:Label id="Label15" runat="server" Text="Treasury" CssClass="p3"></asp:Label>&nbsp;&nbsp;<asp:DropDownList id="ddlTLBAdd" runat="server" Width="147px" AutoPostBack="True" OnSelectedIndexChanged="ddlTLBAdd_SelectedIndexChanged">
 </asp:DropDownList></TD><TD>&nbsp;</TD></TR><TR style="WIDTH: 40px"><TD>&nbsp;</TD><TD align=center colSpan=2><asp:Button id="btnLBAdd" onclick="btnLBAdd_Click" runat="server" Width="50px" Text="Add"></asp:Button></TD><TD>&nbsp;</TD></TR><TR><TD align=center colSpan=4><asp:GridView id="gdvLBAdd" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" ReadOnly="True">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvLBCode" HeaderText="LB Code" Visible="False">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryNameD" HeaderText="Dist. Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryNameDisp" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD align=center></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>

