<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_Treasurrecosile, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
<ContentTemplate>
<table style="width: 100%">

<tr>
<%--<td colspan="4" style="WIDTH: 116px; COLOR: black; BACKGROUND-COLOR: #ccd0e6" align="center" height="26" ;><asp:Label id="lblHead" class="Head1" runat="server" Text="Sanction Order"></asp:Label></td>--%>
<td  colspan="4" class="TdMnHead" >
                <asp:Label ID="lblHead" runat="server" class="MnHead" Text="Treasury Reconsilation"></asp:Label>
            </td>
</tr>
<tr><td align="center" colspan="2">
<asp:RadioButtonList id="rdPrcess" runat="server" ForeColor="RoyalBlue" Font-Size="10pt" Font-Names="Verdana" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdApp_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True"  Enabled="true">
<asp:ListItem Selected="True">TA <=75000 &nbsp &nbsp </asp:ListItem>
<asp:ListItem>TA >75000 & <=200000 &nbsp &nbsp</asp:ListItem>
<asp:ListItem>TA >200000 &nbsp &nbsp </asp:ListItem>
    <asp:ListItem>NRA <=200000&nbsp &nbsp </asp:ListItem>
    <asp:ListItem>NRA >200000 &nbsp &nbsp </asp:ListItem>
</asp:RadioButtonList>
</td></tr>
<tr>
<td colspan="4" align="center" style="width: 1027px">
<%--<asp:panel ID="pnlAcquttance" runat="server" Visible="true">--%>
<asp:GridView ID="gvTreasury" runat="server" ForeColor="#333333" Width="792px" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True" UseAccessibleHeader="False">
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
<Columns>
    <asp:BoundField DataField="SlNo" HeaderText="Sl. No." />
<asp:BoundField  HeaderText="Bill Date " DataField="dtmBill"></asp:BoundField>
<asp:BoundField DataField="fltBillAmount" HeaderText="Amount"></asp:BoundField>
    <asp:TemplateField HeaderText="numTrnId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblTrnId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField>
<HeaderTemplate>
<asp:CheckBox ID="chkAll" runat="server" Text="Check All" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox ID="chkApp" runat="server" Checked="True" />
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Bill No.">
        <ItemTemplate>
            <asp:TextBox ID="txtRem" runat="server" MaxLength="20"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="BillId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblBillId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="EmpId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblEmpId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="TrnType" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblTrnType" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <RowStyle BackColor="#EFF3FB" />
    <EditRowStyle BackColor="#2461BF" />
</asp:GridView></td>
<%--</asp:Panel>--%>
</tr>
<tr><td align="center">
<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td></tr></table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

