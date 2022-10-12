<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AoApprovalNew, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="AO Approval"></asp:Label> </TD></TR><TR><TD style="WIDTH: 1029px; HEIGHT: 25px" align=center colSpan=2><asp:RadioButtonList id="rdTrn" runat="server" ForeColor="RoyalBlue" Font-Bold="True" Font-Size="10pt" Font-Names="Verdana" OnSelectedIndexChanged="rdTrn_SelectedIndexChanged" Enabled="true" AutoPostBack="True" RepeatDirection="Horizontal">
<asp:ListItem Selected="True">Remittance</asp:ListItem>
<asp:ListItem>Withdrawal</asp:ListItem>
</asp:RadioButtonList> </TD></TR>
<tr><td>&nbsp;</td></tr>

<TR><TD style="WIDTH: 970px; HEIGHT: 64px" align=center><TABLE><TBODY>
<TR><TD  align=left><asp:Label id="Label2" runat="server" Width="88px"  Text="Year"  CssClass="p1"></asp:Label> <asp:DropDownList id="ddlYear" tabIndex=4 runat="server" Width="160px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD   align=left><asp:Label id="Label3" runat="server" Width="104px"  Text="Month"   CssClass="p1"></asp:Label> <asp:DropDownList id="ddlMonth" runat="server" Width="136px" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD colSpan=4><asp:GridView id="gdvAOApprov" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intDistrictId" DataNavigateUrlFormatString="~/Contents/AoApprovalNewLnk1.aspx?intDistrictId={0}" DataTextField="chvEngDistName" HeaderText="District">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="Status" HeaderText="Status">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Select"><ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" AutoPostBack="True"  />
        
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dist" Visible="False"><ItemTemplate>
            <asp:Label ID="lblDist" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR align="center"><TD colSpan=4><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="70px" ForeColor="Navy" Text="Approve" Height="28px" Font-Size="Small"></asp:Button> </TD></TR></TBODY></TABLE><%--  </asp:Panel>--%></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

