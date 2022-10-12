<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_CorrInApp, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<table style="width: 100%">

<tr>
<%--<td colspan="4" style="WIDTH: 116px; COLOR: black; BACKGROUND-COLOR: #ccd0e6" align="center" height="26" ;><asp:Label id="lblHead" class="Head1" runat="server" Text="Sanction Order"></asp:Label></td>--%>
<td  colspan="4" class="TdMnHead" >
                <asp:Label ID="lblHead" runat="server" class="MnHead" Text="Rejection on Approved files"></asp:Label>
            </td>
</tr>
<tr>
    <td align="center" >
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Service" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="Blue"></asp:Label>
    </td>
    <td align="left">
        <asp:DropDownList runat="server" Width="159px" TabIndex="11" ID="ddlSer" OnSelectedIndexChanged="ddlSer_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>&nbsp;
    </td>
        
    </tr>
    <tr><td colspan="2">
    <asp:GridView id="gdvInboxTA" runat="server" ForeColor="#333333" Width="692px" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" >
<Columns>
    <asp:BoundField DataField="SlNo" HeaderText="SlNo" />
<asp:BoundField DataField="dtmDateOfRequest" HeaderText="Date of Request"></asp:BoundField>
<asp:HyperLinkField HeaderText="Account No" DataTextField="chvPF_No" DataNavigateUrlFormatString="~/Contents/TA.aspx?TAReqID={0}" DataNavigateUrlFields="numTrnID"></asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Employee Name"></asp:BoundField>
    <asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" />
    <asp:TemplateField HeaderText="numTrnId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Select">
<%--        <HeaderTemplate>
            <asp:CheckBox ID="Allchk" runat="server" OnCheckedChanged="Allchk_CheckedChanged" Checked="True" Text="Check All" AutoPostBack="True" />
        </HeaderTemplate>--%>
        <ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="EmpId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblEmpId" runat="server"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="TrnType" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblTrnType" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
            <EmptyDataTemplate>
                <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
            </EmptyDataTemplate>
            
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <EditRowStyle Wrap="True" BackColor="#2461BF" />
    <RowStyle BackColor="#EFF3FB" />
</asp:GridView>

<asp:GridView id="gdvInboxNRA" runat="server" ForeColor="#333333" Width="692px" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" >
<Columns>
    <asp:BoundField DataField="SlNo" HeaderText="SlNo" />
<asp:BoundField DataField="dtmDateOfRequest" HeaderText="Date of Request"></asp:BoundField>
<asp:HyperLinkField HeaderText="Account No" DataTextField="chvPF_No" DataNavigateUrlFormatString="~/Contents/NRA.aspx?TAReqID={0}" DataNavigateUrlFields="numTrnID"></asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Employee Name"></asp:BoundField>
    <asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" />
    <asp:TemplateField HeaderText="numTrnId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Select">
<%--        <HeaderTemplate>
            <asp:CheckBox ID="Allchk" runat="server" OnCheckedChanged="Allchk_CheckedChanged" Checked="True" Text="Check All" AutoPostBack="True" />
        </HeaderTemplate>--%>
        <ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="EmpId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblEmpId" runat="server"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="TrnType" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblTrnType" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
            <EmptyDataTemplate>
                <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
            </EmptyDataTemplate>
            
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <EditRowStyle Wrap="True" BackColor="#2461BF" />
    <RowStyle BackColor="#EFF3FB" />
</asp:GridView>
<asp:GridView id="gdvInboxMS" runat="server" ForeColor="#333333" Width="692px" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" >
<Columns>
    <asp:BoundField DataField="SlNo" HeaderText="SlNo" />
<asp:BoundField DataField="dtmDateOfRequest" HeaderText="Date of Request"></asp:BoundField>
<asp:HyperLinkField HeaderText="Account No" DataTextField="chvPF_No" DataNavigateUrlFormatString="~/Contents/MonthlySubn.aspx?TAReqID={0}" DataNavigateUrlFields="numTrnID"></asp:HyperLinkField>
<asp:BoundField DataField="chvName" HeaderText="Employee Name"></asp:BoundField>
    <asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" />
    <asp:TemplateField HeaderText="numTrnId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Select">
<%--        <HeaderTemplate>
            <asp:CheckBox ID="Allchk" runat="server" OnCheckedChanged="Allchk_CheckedChanged" Checked="True" Text="Check All" AutoPostBack="True" />
        </HeaderTemplate>--%>
        <ItemTemplate>
            <asp:CheckBox ID="chkApp" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="EmpId" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblEmpId" runat="server"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="TrnType" Visible="False">
        <ItemTemplate>
            <asp:Label ID="lblTrnType" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
            <EmptyDataTemplate>
                <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
            </EmptyDataTemplate>
            
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <EditRowStyle Wrap="True" BackColor="#2461BF" />
    <RowStyle BackColor="#EFF3FB" />
</asp:GridView>
    </td></tr>
    <tr><td align="center" colspan="2" style="height: 10px">
<asp:Button ID="btnGenerate" Width="100px" runat="server" Text="Reject" Font-Bold="True" Font-Names="Verdana" ForeColor="Blue" OnClick="btnGenerate_Click" />

</td></tr>
</table>
</asp:Content>

