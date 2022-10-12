<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AoApprovalNewLnk2, App_Web_1la5evxf" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="AO Approval"></asp:Label> </TD></TR><TR><TD style="WIDTH: 1029px; HEIGHT: 25px" align=center colSpan=2><asp:Label id="lblType" runat="server" CssClass="p4" Text="..." ></asp:Label> </TD></TR><TR><TD style="WIDTH: 970px; HEIGHT: 64px" align=center><TABLE><TBODY><TR><TD style="WIDTH: 46px" align=left><asp:Label id="Label2" runat="server" Width="88px" Text="Year" CssClass="p4"></asp:Label></TD><TD style="WIDTH: 115px" align=left><asp:Label id="Label3" runat="server" Width="104px" Text="Month" CssClass="p4"></asp:Label></TD></TR><TR><TD colSpan=4><asp:GridView id="gdvAOApprov" runat="server" Width="900px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ChalDet" HeaderText="Chalan details">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Chalan Amt.">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><%--<TR><TD style="WIDTH: 46px" align=left><asp:Label id="Label12" runat="server" Width="88px" ForeColor="Blue" Font-Bold="True" Text="Schedule" Font-Size="10pt" Font-Names="Verdana"></asp:Label></TD><TD style="WIDTH: 103px"><asp:DropDownList id="ddlSched" tabIndex=4 runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="ddlSched_SelectedIndexChanged"></asp:DropDownList></TD></TR>--%><TR><TD colSpan=4>&nbsp;</TD></TR><TR><TD class="TdMnHead" colSpan=4><asp:Label id="lblSHead" class="MnHead" runat="server" Text="Schedule"></asp:Label> </TD></TR><TR><TD colSpan=4><asp:GridView id="gdvAOApprovSched" runat="server" Width="900px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvPF_No" HeaderText="Acc. No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvUnPosted" HeaderText="Un Ident">
<ItemStyle HorizontalAlign="Right" Width="50px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltMsAmt" HeaderText="Subn.">
<ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltRfAmt" HeaderText="Repay.">
<ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltPfAmt" HeaderText="PF">
<ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltDaAmt" HeaderText="DA">
<ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltPayAmt" HeaderText="Pay">
<ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltTotAmt1" HeaderText="Total">
<ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
</asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=left colSpan=2>

<%--<asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Approve" Height="23px"></asp:LinkButton>
--%>
<asp:Button id="btnBack"  runat="server" Width="53px" Text="Back " Height="19px" OnClick="btnBack_Click" ></asp:Button>


</TD><TD align=left colSpan=2><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="70px" ForeColor="Navy" Text="Approve" Font-Size="Small" Height="28px" Visible="False"></asp:Button> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

