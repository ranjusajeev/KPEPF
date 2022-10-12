<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AoApprovalNewCurr, App_Web_4p3ju0t2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="AO Approval"></asp:Label> </TD></TR><TR><TD style="WIDTH: 1029px; HEIGHT: 25px" align=center colSpan=2><asp:RadioButtonList id="rdTrn" runat="server" ForeColor="RoyalBlue" Font-Bold="True" OnSelectedIndexChanged="rdTrn_SelectedIndexChanged" Enabled="true" AutoPostBack="True" RepeatDirection="Horizontal" Font-Names="Verdana" Font-Size="10pt">
<asp:ListItem Selected="True">Remittance</asp:ListItem>
<asp:ListItem>Withdrawal</asp:ListItem>
</asp:RadioButtonList> </TD></TR><TR><TD style="WIDTH: 970px; HEIGHT: 64px" align=center><TABLE><TBODY><TR><TD style="WIDTH: 46px" align=left><asp:Label id="Label2" runat="server" Width="88px" ForeColor="Blue" Font-Bold="True" Text="Year" Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label></TD><TD style="WIDTH: 103px"><asp:DropDownList id="ddlYear" tabIndex=4 runat="server" Width="160px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 115px" align=left><asp:Label id="Label3" runat="server" Width="104px" ForeColor="Blue" Font-Bold="True" Text="Month" Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="ddlMonth" runat="server" Width="136px" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD colSpan=4><asp:GridView id="gdvAOApprov" runat="server" Width="692px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="District Treasury" DataTextField="chvTreasuryName" DataNavigateUrlFormatString="~/Contents/AoApprovalNewLnk1Curr.aspx?intDTreasuryId={0}" DataNavigateUrlFields="intDTreasuryId">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="Status" HeaderText="Status">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Select">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" AutoPostBack="True"  />
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="DistT"><ItemTemplate>
            <asp:Label ID="lblDist" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR align=center><TD colSpan=4><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="70px" ForeColor="Navy" Text="Approve" Font-Size="Small" Height="28px"></asp:Button> </TD></TR></TBODY></TABLE><%--  </asp:Panel>--%></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

