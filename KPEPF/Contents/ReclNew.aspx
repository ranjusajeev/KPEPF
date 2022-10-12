<%@ Page Title="" Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="ReclNew.aspx.cs" Inherits="Contents_ReclNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Reconciliation"></asp:Label> </TD></TR><TR><TD align=center colSpan=2><asp:RadioButtonList id="rdTrnType" runat="server" ForeColor="#0000C0" Font-Bold="True" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdTrnType_SelectedIndexChanged" Font-Names="Verdana" Font-Size="10pt">
                    <asp:ListItem Selected="True">Credit</asp:ListItem>
                    <asp:ListItem>Debit</asp:ListItem>
                    
                </asp:RadioButtonList> </TD></TR><TR><TD colSpan=2>&nbsp;</TD></TR><TR align=center><TD colSpan=2><asp:Label id="Label2" runat="server" Text="AG Account" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblTrnTp" runat="server" Text="Credit" CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblYrAGCr" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR vAlign=top align=left><TD style="WIDTH: 45%"><asp:GridView id="gdvRecAg" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvYear" HeaderText="Year">
<ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="Credit" DataTextField="amountAGRem" DataNavigateUrlFormatString="~/Contents/ReclNew.aspx?intYearIdAG={0}" DataNavigateUrlFields="intYearId">
<ItemStyle Width="150px" HorizontalAlign="Right"></ItemStyle>
</asp:HyperLinkField>
<asp:HyperLinkField HeaderText="Debit" DataTextField="amountAGWith" DataNavigateUrlFormatString="~/Contents/ReclNew.aspx?intYearIdAGW={0}" DataNavigateUrlFields="intYearId">
<ItemStyle Width="150px" HorizontalAlign="Right"></ItemStyle>
</asp:HyperLinkField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD style="WIDTH: 60%"><asp:GridView id="gdvRecAgCr" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvMonth" HeaderText="Month">
<ItemStyle Width="45px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="amountAGRem" HeaderText="Treasury">
<ItemStyle Width="100px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="TEEntryCr" HeaderText="Transfer Entry">
<ItemStyle Width="100px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
    <asp:BoundField DataField="totalCr" HeaderText="Total">
        <ItemStyle HorizontalAlign="Right" Width="150px" />
    </asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> 

    <asp:GridView id="gdvRecAgDt" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvMonth" HeaderText="Monthh">
<ItemStyle Width="45px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="amountAGWith" HeaderText="Treasury">
</asp:BoundField>
    <asp:BoundField DataField="TEEntryDt" HeaderText="Transfer Entry" />
    <asp:BoundField DataField="totalDt" HeaderText="Total" />
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>

                     </TD></TR><TR><TD colSpan=2>&nbsp;</TD></TR><TR><TD align=center colSpan=2><asp:Label id="lblYearDAG" runat="server" Text="..." CssClass="p4" visible="false"></asp:Label> </TD></TR><TR align="center">
    <td colspan="2">
        <asp:Label ID="Label1" runat="server" CssClass="p1" Text="KPEPF Account"></asp:Label>
    </td>
    <tr align="center">
        <td colspan="2" style="WIDTH: 100%">
            <asp:GridView ID="gdvRecPF" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="5" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None" OnRowCreated="gdvRecPF_RowCreated" Width="900px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="intYearId" DataNavigateUrlFormatString="~/Contents/ReclNew.aspx?intYearId={0}" DataTextField="chvYear" HeaderText="Year">
                        <ItemStyle HorizontalAlign="Left" />
                        
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="amtTP" HeaderText="Treasury">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amtAP" HeaderText="AG">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amtPTot" HeaderText="Total">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amtTUP" HeaderText="Treasury">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amtAUP" HeaderText="AG">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amtUPTot" HeaderText="Total">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="gTot" HeaderText="Grand Total">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#0066FF" Wrap="True" />
                <SelectedRowStyle BackColor="#3366FF" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lblYearD" runat="server" CssClass="p4" Text="..."></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:GridView ID="gdvRecM" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="5" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None" OnRowCreated="gdvRecM_RowCreated" ShowFooter="True" Width="900px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="intMonthId" DataNavigateUrlFormatString="~/Contents/ReclMltpl1New.aspx?intMonthId={0}" DataTextField="chvMonth" HeaderText="Month">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="amtTP" HeaderText="Treasury">
                        <ItemStyle HorizontalAlign="Right" Width="45px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amtAP" HeaderText="AG">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amtPTot" HeaderText="Total">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amtTUP" HeaderText="Treasury">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amtAUP" HeaderText="AG">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="amtUPTot" HeaderText="Total">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="gTot" HeaderText="Grand Total">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" Wrap="True" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
    </tr>
    </TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>

