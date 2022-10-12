<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ApprovedFiles, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 100%" class="TdMnHead" colSpan=3><asp:Label id="lblHead" class="MnHead" runat="server" Text="Freash Memberships"></asp:Label> </TD></TR><TR><TD align=center><asp:Label id="Label1" class="p1" runat="server" Text="Service" Visible="false"></asp:Label></TD><TD><asp:DropDownList id="ddlSer" tabIndex=4 runat="server" Visible="false" OnSelectedIndexChanged="ddlSer_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD></TR><TR align="center"><TD colSpan=2><asp:Panel id="pnlAppFiles" runat="server" Width="100%"><asp:GridView id="gdvSearch" runat="server" ForeColor="#333333" width="900px" Font-Size="10pt" Font-Names="Verdana" OnSelectedIndexChanged="gdvSearch_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="2" GridLines="None" CellSpacing="5">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<%--<asp:TemplateField HeaderText="Sl.No."><ItemTemplate>
<asp:Label id="lblSlNo" runat="server" Text="Label" __designer:wfdid="w1"></asp:Label>
</ItemTemplate>
</asp:TemplateField>--%>
<asp:BoundField DataField="SlNo" Visible="True" HeaderText="Sl.No."></asp:BoundField>
<asp:BoundField DataField="numEmpId" HeaderText="Account Number">
<ItemStyle   HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ControlStyle ></ControlStyle>

<ItemStyle   HorizontalAlign="Left"></ItemStyle>

<HeaderStyle   HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngDistName" Visible="False" HeaderText="Joining District ">
<ItemStyle HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Joining Localbody"></asp:BoundField>
<asp:BoundField Visible="False" HeaderText="Current District"></asp:BoundField>
<asp:BoundField Visible="False" HeaderText="Current Localbody"></asp:BoundField>
<asp:BoundField DataField="dtmDOJ" HeaderText="Date Of Joining"></asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> <asp:Panel id="pnlPndng" runat="server" Width="100%"><asp:GridView id="gdvPndng" runat="server" ForeColor="#333333" CellSpacing="5" GridLines="None" CellPadding="2" AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="10pt" >
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" Visible="False" HeaderText="Sl.No."></asp:BoundField>
<asp:TemplateField HeaderText="Sl.No."><ItemTemplate>
<asp:Label id="lblSlNo" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="TrnType" HeaderText="Service">
<ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvPF_No" HeaderText="Account No.">
<ItemStyle Width="85px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ControlStyle Width="111px"></ControlStyle>

<ItemStyle Width="200px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="222px" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="dtmEntry" Visible="False" HeaderText="Date of Request"></asp:BoundField>
<asp:BoundField DataField="dtmApproval" HeaderText="Date of Recieve"></asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Originator">
<ItemStyle Width="200px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Seat" HeaderText="Seat">
<ItemStyle Width="90px"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </asp:Panel> <asp:Panel id="pnlUpds" runat="server" Width="100%"><asp:GridView id="gdvUpds" runat="server" ForeColor="#333333" CellSpacing="5" GridLines="None" CellPadding="2" AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="10pt" >
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" Visible="False" HeaderText="Sl.No."></asp:BoundField>
<asp:TemplateField HeaderText="Sl.No."><ItemTemplate>
<asp:Label id="lblSlNo" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="TrnType" HeaderText="Service">
<ItemStyle Width="120px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvPF_No" HeaderText="Account No.">
<ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<ItemStyle Width="150px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="dtmEntry" HeaderText="Date of Request">
<ControlStyle Width="111px"></ControlStyle>

<ItemStyle Width="80px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Originator"></asp:BoundField>
<asp:BoundField DataField="RtndBy" HeaderText="Returned by">
<ItemStyle Width="200px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvRem" HeaderText="Reason">
<ItemStyle Width="125px"></ItemStyle>
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

