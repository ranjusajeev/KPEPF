<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="Contents_MainPage" Title="Kerala Panchayat Employees Provident Fund" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%"><TBODY><TR>
<TD align=center ><asp:Label id="lblHead23" class="Head1" runat="server" Text=""></asp:Label> </TD>
<TD align=center><asp:Label id="lblHead"  runat="server" Text="KPEPF Online" Font-Bold="True" Font-Names="Verdana" Font-Overline="True" Font-Size="25pt" ForeColor="#FFC0C0"></asp:Label> </TD></TR>

<TR valign="top"><TD><asp:GridView id="gdvCnt" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" CellPadding="2" GridLines="None" ShowFooter="True">
<FooterStyle BackColor="#507CD1" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" FooterText="Total" HeaderText="Sl. No."></asp:BoundField>
<asp:BoundField DataField="chvGroup" HeaderText="Transaction">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="cnt1" HeaderText="Count">
<ItemStyle Width="75px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD ><asp:GridView id="gdvEmp" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" CellPadding="2" GridLines="None" ShowFooter="True">
<FooterStyle BackColor="#507CD1" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" FooterText="Total" HeaderText="Sl. No."></asp:BoundField>
<asp:BoundField DataField="chvEngDistName" HeaderText="District">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="cntLive" HeaderText="Live">
<ItemStyle Width="75px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="cntClosed" HeaderText="Closed">
<ItemStyle Width="75px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TotalCnt" HeaderText="Total">
<ItemStyle Width="75px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>
	</asp:Content>