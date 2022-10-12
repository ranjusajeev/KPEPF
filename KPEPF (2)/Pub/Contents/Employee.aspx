<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="Contents_Employee" %>--%>

<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_Employee, App_Web_vxnq-4wi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%"><TBODY align=center><TR><TD class="TdMnHead" colSpan=3><asp:Label id="lblHead" class="MnHead" runat="server" Text="Employee Master"></asp:Label></TD></TR><TR><TD align=center><asp:Panel id="Panel1" runat="server"><asp:RadioButtonList id="rbtDist" runat="server" Width="240px" ForeColor="Navy" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbtDist_SelectedIndexChanged" Font-Names="Verdana" Font-Size="10pt" Height="14px" CssClass="p1"><asp:ListItem Selected="True">Consolidation</asp:ListItem>
<asp:ListItem>District wise</asp:ListItem>
</asp:RadioButtonList> </asp:Panel></TD></TR><TR><TD align=center><asp:Panel id="pnlEmp" runat="server" Visible="false"><TABLE width="40%"><TBODY align=center><TR><TD><asp:Label id="Label1" runat="server" Text="District" Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label></TD><TD><asp:DropDownList id="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Font-Names="Verdana" Font-Size="10pt"></asp:DropDownList> <asp:Label id="lblCnt" runat="server" visible="False" text="..." CssClass="p4"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD><asp:Panel id="pnlEmpGrid" runat="server" Visible="true"><asp:GridView id="gdvEmp" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" CellPadding="2" GridLines="None" ShowFooter="True">
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
</asp:GridView> </asp:Panel> </TD></TR><TR><TD><asp:Panel id="pnlEmpDist" runat="server" Visible="false"><asp:Label id="lblPgNo" runat="server" Visible="False" CssClass="p4"></asp:Label> <asp:GridView id="gdvEmpDist" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" GridLines="None" CellPadding="2" AutoGenerateColumns="False" CellSpacing="5" PageSize="50" OnPageIndexChanging="gdvEmpDist_PageIndexChanging" AllowPaging="True">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl. No."></asp:BoundField>
<asp:BoundField DataField="chvPF_No" HeaderText="Acc No.">
<ItemStyle Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ItemStyle Width="200px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngDistName" HeaderText="Current District">
<ItemStyle Width="200px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvInst" HeaderText="Current Localbody">
<ItemStyle Width="200px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    	</asp:Content>