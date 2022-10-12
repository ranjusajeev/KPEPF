<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_InboxMonthlyTrn, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="80%"><TBODY><TR align="center"><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="Inbox_Monthly transaction"></asp:Label></TD></TR><TR align=center><TD style="BACKGROUND-COLOR: #ccd0e6" align=center><asp:RadioButtonList id="rdApp" runat="server" ForeColor="Navy" AutoPostBack="True" OnSelectedIndexChanged="rdApp_SelectedIndexChanged" RepeatDirection="Horizontal" Font-Names="Verdana" Font-Size="10pt"><asp:ListItem Selected="True">Forward for Approval</asp:ListItem>
<asp:ListItem>Returned for Modification</asp:ListItem>
</asp:RadioButtonList> </TD></TR><TR align="center"><TD ><asp:Panel id="pnlAo" runat="server" Width="100%"><asp:Label id="Label1" runat="server" ForeColor="#0000C0" Text="District" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlDistrict" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList> &nbsp; &nbsp; &nbsp; <asp:Label id="Label2" runat="server" ForeColor="#0000C0" Text="Localbody" Font-Names="Verdana" Font-Size="10pt" Visible="False"></asp:Label> <asp:DropDownList id="ddlLb" tabIndex=4 runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlLb_SelectedIndexChanged" Visible="False"></asp:DropDownList> </asp:Panel> </TD></TR><TR align="center"><TD  align="center"><asp:GridView id="gdvInboxMembership" runat="server" Width="850px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:BoundField DataField="chvYear" HeaderText="Year"></asp:BoundField>
<asp:BoundField DataField="chvMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="Chalan details" DataTextField="ChalNoDt" DataNavigateUrlFormatString="~/Contents/MonthlySubn.aspx?numChalanId={0}&amp;flgApproval={1}" DataNavigateUrlFields="numChalanId,flgApproval"></asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Chalan amount">
<ItemStyle Width="80px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SchAmt" HeaderText="Schedule amount">
<ItemStyle Width="80px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvInst" Visible="False" HeaderText="Localbody"></asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury"></asp:BoundField>
<asp:TemplateField Visible="False" HeaderText="TrnId"><ItemTemplate>
<asp:Label id="txtNumTrnId" runat="server" Text="Label"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Check all"><HeaderTemplate>
            <asp:CheckBox ID="Allchk" runat="server" Checked="True" AutoPostBack="True" Text="Select" OnCheckedChanged="Allchk_CheckedChanged" />
</HeaderTemplate>
<ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Returned"><ItemTemplate>
            <asp:CheckBox ID="chkReturned" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkReturned_CheckedChanged"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason for Return"><ItemTemplate>
<asp:TextBox id="txtRsn" runat="server" Width="115px" ReadOnly="True" MaxLength="50" ForeColor="Black"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>&nbsp; </TD></TR><TR><TD style="WIDTH: 693px" align=center><asp:Panel id="flgpnl" runat="server" Width="100%"><TABLE style="WIDTH: 100%"><TBODY><TR style="WIDTH: 100%"><TD style="WIDTH: 599px" align=right><asp:RadioButtonList id="rlist" runat="server" Width="338px" ForeColor="Navy" Font-Size="Small" RepeatDirection="Horizontal" OnSelectedIndexChanged="rlist_SelectedIndexChanged" AutoPostBack="True" Visible="False"><asp:ListItem Selected="True">Forwarded for Approval</asp:ListItem>
<asp:ListItem>Returned for Modification</asp:ListItem>
</asp:RadioButtonList></TD><TD align=left><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="46px" ForeColor="Navy" Text="OK" Font-Size="Small"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    	</asp:Content>

