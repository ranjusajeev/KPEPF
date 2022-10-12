<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_InboxMonthlyTrn, App_Web_q2bqv01f" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="80%"><TBODY><TR align=center><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="Inbox_Monthly transaction"></asp:Label></TD></TR><TR align=center><TD style="BACKGROUND-COLOR: #ccd0e6" align=center><asp:RadioButtonList id="rdApp" runat="server" ForeColor="Navy" Font-Size="10pt" Font-Names="Verdana" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdApp_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True">Forward for Approval</asp:ListItem>
<asp:ListItem>Returned for Modification</asp:ListItem>
</asp:RadioButtonList> </TD></TR><TR align=center><TD>


<asp:Panel id="pnlAo" runat="server" Width="900px"><asp:Label id="Label2" runat="server" CssClass="p1" Text="Year" ></asp:Label> <asp:DropDownList id="ddlYear" tabIndex=4 runat="server" Width="86px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>  &nbsp; &nbsp; &nbsp; 
<asp:Label id="Label3" runat="server" CssClass="p1" Text="Month" ></asp:Label> <asp:DropDownList id="ddlMth" tabIndex=4 runat="server" Width="88px" OnSelectedIndexChanged="ddlMth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>   &nbsp; &nbsp; &nbsp; 
<asp:Label id="Label1" runat="server"  Text="District" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlDistrict" tabIndex=4 runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="True" Width="112px"></asp:DropDownList>  &nbsp; &nbsp; &nbsp; 
<asp:Label id="Label4" runat="server" CssClass="p1" Text="Dist. Treasury" ></asp:Label> <asp:DropDownList id="ddlDt" tabIndex=4 runat="server" Width="150px" OnSelectedIndexChanged="ddlDt_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> 
</asp:Panel> 


</TD></TR><TR align=center><TD align=center><asp:GridView id="gdvInboxMembership" runat="server" Width="850px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:BoundField DataField="chvYear" HeaderText="Year"></asp:BoundField>
<asp:BoundField DataField="chvMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval" DataNavigateUrlFormatString="~/Contents/MonthlySubnEntry.aspx?numChalanId={0}&amp;flgApproval={1}" DataTextField="ChalNoDt" HeaderText="Chalan details">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Chalan amount">
<ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SchAmt" HeaderText="Schedule amount" Visible="False">
<ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvInst" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury" Visible="False"></asp:BoundField>
<asp:TemplateField HeaderText="TrnId" Visible="False"><ItemTemplate>
<asp:Label id="txtNumTrnId" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Check all"><HeaderTemplate>
            <asp:CheckBox ID="Allchk" runat="server" Checked="False" AutoPostBack="True" Text="Select" OnCheckedChanged="Allchk_CheckedChanged" />
</HeaderTemplate>
<ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="False" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged"/>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Suggest for Return"><ItemTemplate>
            <asp:CheckBox ID="chkReturned" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkReturned_CheckedChanged"/>
</ItemTemplate>

<ItemStyle Width="60px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason for Return"><ItemTemplate>
<asp:TextBox id="txtRsn" runat="server" Width="115px" ReadOnly="True" MaxLength="50" ForeColor="Black"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>&nbsp; </TD></TR><TR><TD style="WIDTH: 693px" align=center><asp:Panel id="flgpnl" runat="server" Width="100%"><TABLE style="WIDTH: 100%"><TBODY><TR style="WIDTH: 100%"><TD style="WIDTH: 599px" align=right><asp:RadioButtonList id="rlist" runat="server" Width="338px" ForeColor="Navy" Font-Size="Small" RepeatDirection="Horizontal" OnSelectedIndexChanged="rlist_SelectedIndexChanged" AutoPostBack="True" Visible="False"><asp:ListItem Selected="True">Forwarded for Approval</asp:ListItem>
<asp:ListItem>Returned for Modification</asp:ListItem>
</asp:RadioButtonList></TD><TD align=left><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="78px" ForeColor="Navy" Text="Forward" Font-Size="Small" Height="22px"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    	</asp:Content>

