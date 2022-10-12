<%@ Page Title="" Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="ReclMltpl3New.aspx.cs" Inherits="Contents_ReclMltpl3New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2>&nbsp;<asp:Label id="lblHead" runat="server" class="MnHead" Text="Reconciliation" ></asp:Label> </TD></TR><TR><TD align=center colSpan=2>
    <asp:Label id="lblTp" runat="server" Width="150px" ForeColor="#FF3300" Font-Bold="True" Text="..." Font-Size="12pt" Font-Names="Verdana"></asp:Label>
    <asp:Label id="lblYearD" runat="server" Width="150px" ForeColor="#FF3300" Font-Bold="True" Text="..." Font-Size="12pt" Font-Names="Verdana"></asp:Label> <asp:Label id="lblYearD2" runat="server" Width="150px" ForeColor="#FF3300" Font-Bold="True" Text="..." Font-Size="12pt" Font-Names="Verdana"></asp:Label> <asp:Label id="lblYearD3" runat="server" Width="250px" ForeColor="#FF3300" Font-Bold="True" Text="..." Font-Size="12pt" Font-Names="Verdana"></asp:Label> </TD></TR><TR><TD colSpan=2 align="center" ><asp:GridView id="gdvRecM" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5" ShowFooter="True" Width="703px">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<%--<asp:HyperLinkField HeaderText="Chalan Details" DataTextField="ChalDet" DataNavigateUrlFormatString="~/Contents/AoApprovalNewLnk2.aspx?intChalanId={0}&amp;intYearId={1};&amp;flgPrevYear={2}" DataNavigateUrlFields="intChalanId,intYearId,flgPrevYear"></asp:HyperLinkField>--%>
<asp:BoundField DataField="ChalDet" HeaderText="Chalan Details">
<ItemStyle Width="20%"></ItemStyle>
</asp:BoundField>
    <asp:BoundField DataField="chvTEId" HeaderText="TE No." />
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury">
<ItemStyle Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltCash" HeaderText="Chalan Amount">
<ItemStyle Width="20%" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <asp:GridView id="gdvRecM1" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="ChalDet" HeaderText="Chalan Details"></asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury">
<ItemStyle Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle Width="20%"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltCash" HeaderText="Chalan Amount">
<ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align="center"><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Reconcilation" Height="23px"></asp:LinkButton></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>

