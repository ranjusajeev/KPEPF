<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="Treasurrecosile.aspx.cs" Inherits="Contents_Treasurrecosile" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
<ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4><asp:Label id="lblHead" class="MnHead" runat="server" Text="Treasury Reconsilation"></asp:Label> </TD></TR><tr><td></td></tr><TR><TD align=center colSpan=2><asp:RadioButtonList id="rdPrcess" runat="server" ForeColor="RoyalBlue" Font-Bold="True" Enabled="true" AutoPostBack="True" OnSelectedIndexChanged="rdApp_SelectedIndexChanged" RepeatDirection="Horizontal" Font-Names="Verdana" Font-Size="10pt">
<asp:ListItem Selected="True">TA <=75000 &nbsp &nbsp </asp:ListItem>
<asp:ListItem>TA >75000 & <=200000 &nbsp &nbsp</asp:ListItem>
<asp:ListItem>TA >200000 &nbsp &nbsp </asp:ListItem>
    <asp:ListItem>NRA <=200000&nbsp &nbsp </asp:ListItem>
    <asp:ListItem>NRA >200000 &nbsp &nbsp </asp:ListItem>
</asp:RadioButtonList> </TD></TR>
<tr><td></td></tr>
<TR><TD style="WIDTH: 1027px" align=center colSpan=4> <asp:GridView id="gvTreasury" runat="server" Width="792px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" UseAccessibleHeader="False" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
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
</asp:GridView></TD><%--</asp:Panel>--%></TR><TR><TD align=center><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="77px" Text="Save"></asp:Button></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

