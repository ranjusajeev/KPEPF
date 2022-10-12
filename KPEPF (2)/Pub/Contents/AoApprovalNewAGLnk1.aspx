<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AoApprovalNewAGLnk1, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD  class="TdMnHead" colspan="2"><asp:Label id="lblHead" runat="server" class="MnHead" Text="AO Approval (AG Data)" ></asp:Label> </TD></TR>
<tr><td>&nbsp;</td></tr>
<TR align="center" ><TD colspan="2"><asp:Label id="lblYear" runat="server"  ForeColor="Blue" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> &nbsp; &nbsp; &nbsp;<asp:Label id="lblMonth" runat="server"  ForeColor="Blue" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label></TD></TR>

<TR align="center"><TD  colSpan="2"><asp:GridView id="gdvAOApprov" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" DataKeyNames="intDTreasuryID" OnRowCreated="gdvAOApprov_RowCreated" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Credit_T">
<ItemTemplate>
<asp:Label id="lblCrT" runat="server" __designer:wfdid="w1"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Credit_AG">
<ItemTemplate>
<asp:Label id="lblCrAG" runat="server" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Debit_T">
<ItemTemplate>
<asp:Label id="lblDtT" runat="server" __designer:wfdid="w3"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Debit_AG">
<ItemTemplate>
<asp:Label id="lblDtAG" runat="server" __designer:wfdid="w4"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TId" Visible="False"><ItemTemplate>
<asp:Label id="lblTId" runat="server" Text="Label" __designer:wfdid="w5"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="intDTreasuryId" HeaderText="dt" Visible="False"></asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR>

<TR align="center" ><TD style="width:80%" colspan="2"><TABLE style="WIDTH: 75%" border=1><TBODY>
<tr><td align="left">
<asp:Label id="lblCrPlus" class="p1" runat="server" Text="CreditPlus"></asp:Label></td>
<TD style="WIDTH: 154px" align="right"><asp:Label id="txtcrplus" class="p1" runat="server"></asp:Label> </TD>
<TD align="left"><asp:Label id="lblDebitPlus" class="p1" runat="server" Text="DebitPlus"></asp:Label></TD>
<TD align="right"><asp:Label id="txtDbplus" class="p1" runat="server"></asp:Label></TD>

</tr>
<tr>
        <td align="left"><asp:Label ID="lblCrMinus" Text="CreditMinus" runat="server"  class="p1"></asp:Label></td>
        <td style="width: 154px" align="right"><asp:Label ID="txtcrMinus" runat="server" class="p1" ></asp:Label></td>
        
        <td align="left"><asp:Label ID="lblDebitMinus" Text="DebitMinus" runat="server"  class="p1"></asp:Label></td>
        <td align="right"><asp:Label ID="txtDbMinus" runat="server" class="p1"></asp:Label></td>
        
    </tr>
    <tr>
<td align="left">
<asp:Label ID="lbl1" Text="Net Credit" runat="server"  class="p1"></asp:Label>
</td>
<td align="right">
<asp:Label ID="lblNetCr" Text="..." runat="server"  class="p4"></asp:Label>
</td>
<td>
<asp:Label ID="lbl2" Text="Net Debit" runat="server"  class="p1"></asp:Label>
</td>
<td align="right">
<asp:Label ID="lblNetDt" Text="..." runat="server"  class="p4"></asp:Label>
</td>
</tr>
</TBODY></TABLE></TD></TR>
<tr><td>&nbsp;</td></tr>
<TR><TD align="center" colSpan="2"><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Approval" Height="23px"></asp:LinkButton></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

