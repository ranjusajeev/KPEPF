<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="RemitanceConsolidation.aspx.cs" Inherits="RemitanceConsolidation" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE><TBODY><TR><TD class="TdMnHead"><asp:Label id="lblch" runat="server" class="MnHead" Text="Consolidation" ></asp:Label> </TD></TR><TR><TD style="HEIGHT: 14px" align=right>&nbsp;</TD></TR><TR><TD style="WIDTH: 861px; HEIGHT: 178px" align=center><asp:GridView id="gdvchRem" runat="server" Width="642px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
    <asp:BoundField HeaderText="Accounting Date" />
<asp:HyperLinkField DataTextField="dtChalanDate" HeaderText="Transaction Date.">
<HeaderStyle Width="150px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Sub Treasury"></asp:BoundField>
<asp:BoundField DataField="fltChalanAmt" HeaderText=" Amount  ">
<ItemStyle Width="45px"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

