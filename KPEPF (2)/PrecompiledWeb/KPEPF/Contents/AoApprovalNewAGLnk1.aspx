<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AoApprovalNewAGLnk1, App_Web_m1ijyhfm" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="AO Approval (AG Data)"></asp:Label> </TD></TR><TR><TD>&nbsp;</TD></TR><TR align=center><TD colSpan=2><asp:Label id="lblYear" runat="server"  Text="..." CssClass="p4"></asp:Label> &nbsp; &nbsp; &nbsp;<asp:Label id="lblMonth" runat="server"   Text="..." CssClass="p4"></asp:Label></TD></TR><TR align=center><TD colSpan=2><asp:GridView id="gdvAOApprov" runat="server" Width="692px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" OnRowCreated="gdvAOApprov_RowCreated" DataKeyNames="intDTreasuryID" ShowFooter="True">
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
<asp:Label id="lblCrT" runat="server"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Credit_AG">
<ItemTemplate>
<asp:Label id="lblCrAG" runat="server"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Debit_T">
<ItemTemplate>
<asp:Label id="lblDtT" runat="server"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Debit_AG">
<ItemTemplate>
<asp:Label id="lblDtAG" runat="server"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TId" Visible="False"><ItemTemplate>
<asp:Label id="lblTId" runat="server" Text="Label"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="intDTreasuryId" HeaderText="dt" Visible="False"></asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR align="center"><TD colSpan=2><asp:GridView id="gdvAOApprov1415" runat="server" Width="692px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" OnRowCreated="gdvAOApprov_RowCreated" DataKeyNames="intDTreasuryID" ShowFooter="True" visible="False"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAmountTreasuryCr" HeaderText="Credit_T"></asp:BoundField>
<asp:BoundField DataField="fltAmountAGCr" HeaderText="Credit_AG"></asp:BoundField>
<asp:BoundField DataField="fltAmountTreasuryDt" HeaderText="Debit_T"></asp:BoundField>
<asp:BoundField DataField="fltAmountAGDt" HeaderText="Debit_AG"></asp:BoundField>
<asp:TemplateField Visible="False" HeaderText="TId"><ItemTemplate>
<asp:Label id="lblTId" runat="server" Text="Label"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="intDTreasuryId" Visible="False" HeaderText="dt"></asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR align=center><TD style="WIDTH: 80%" colSpan=2><TABLE style="WIDTH: 75%" border=1><TBODY><TR><TD align=left><asp:Label id="lblCrPlus" class="p1" runat="server" Text="CreditPlus"></asp:Label></TD><TD style="WIDTH: 154px" align=right><asp:Label id="txtcrplus" CssClass="p4" runat="server"></asp:Label> </TD><TD align=left><asp:Label id="lblDebitPlus" class="p1" runat="server" Text="DebitPlus"></asp:Label></TD><TD align=right><asp:Label id="txtDbplus" CssClass="p4" runat="server"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lblCrMinus" class="p1" runat="server" Text="CreditMinus"></asp:Label></TD><TD style="WIDTH: 154px" align=right><asp:Label id="txtcrMinus" CssClass="p4" runat="server"></asp:Label></TD><TD align=left><asp:Label id="lblDebitMinus" class="p1" runat="server" Text="DebitMinus"></asp:Label></TD><TD align=right><asp:Label id="txtDbMinus" CssClass="p4" runat="server"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lbl1" class="p1" runat="server" Text="Net Credit"></asp:Label> </TD><TD align=right><asp:Label id="lblNetCr" CssClass="p4" runat="server" Text="..."></asp:Label> </TD><TD><asp:Label id="lbl2" class="p1" runat="server" Text="Net Debit"></asp:Label> </TD><TD align=right><asp:Label id="lblNetDt" CssClass="p4" runat="server" Text="..."></asp:Label> </TD></TR></TBODY></TABLE></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD align="left" colSpan=2>

<%--<asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Approval" Height="23px"></asp:LinkButton>--%>
<asp:Button id="btnBack"  runat="server" Width="53px" Text="Back " Height="19px" OnClick="btnBack_Click" ></asp:Button>


</TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

