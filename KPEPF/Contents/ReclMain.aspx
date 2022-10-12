<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="ReclMain.aspx.cs" Inherits="Contents_ReclMain" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2>&nbsp;<asp:Label id="lblHead" runat="server" class="MnHead" Text="Reconciliation" ></asp:Label> </TD></TR><TR><TD align=center><asp:Label id="Year" runat="server"  Text="Year" CssClass="p1"></asp:Label></TD><TD style="WIDTH: 40px; HEIGHT: 30px" align=left><asp:DropDownList id="ddlYear" runat="server" Width="147px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList></TD></TR><TR><TD align=center 204px? HEIGHT:><asp:GridView id="gdvRecT1" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" OnRowCreated="gdvRecT1_RowCreated" OnRowDataBound="gdvRecT1_RowDataBound">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvShortMonth" HeaderText="Month">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="RemAmtBfr4T" HeaderText="Bfr 4">
    <ItemStyle HorizontalAlign="Right" />
</asp:BoundField>
<asp:BoundField DataField="RemAmtAftr4T" HeaderText="Afr 4">
    <ItemStyle HorizontalAlign="Right" />
</asp:BoundField>
<asp:BoundField DataField="total" HeaderText="Total">
    <ItemStyle HorizontalAlign="Right" />
</asp:BoundField>
<asp:BoundField DataField="WithAmtT" HeaderText="Debit">
    <ItemStyle HorizontalAlign="Right" />
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD style="HEIGHT: 204px" align=center><asp:GridView id="gdvRecAG1" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" OnRowCreated="gdvRecAG1_RowCreated">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvShortMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="RemAmt" HeaderText="Bfr 4">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PostedAGCrPlusBfr18" HeaderText="Bfr 2008">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="totalAmt" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltWithdrawAmt" HeaderText="Debit">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=center 204px? HEIGHT:><asp:GridView id="gdvRecT2" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" OnRowCreated="gdvRecT2_RowCreated">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvShortMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="fltMisClassBfr" HeaderText="Bfr 4">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltMisClassAftr" HeaderText="Afr 4">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="total" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltMisClassTA" HeaderText="Debit">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD style="HEIGHT: 204px" align=center><asp:GridView id="gdvRecAG2" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" OnRowCreated="gdvRecAG2_RowCreated">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvShortMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="fltMisClassBfr" HeaderText="Bfr 4">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PostedAGCrPlusBfr18" HeaderText="Afr 4">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="total" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltMisClassTA" HeaderText="Debit">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=center 204px? HEIGHT:><asp:GridView id="gdvRecT3" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" OnRowCreated="gdvRecT3_RowCreated">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvShortMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="fltMissingSchedBfr" HeaderText="Bfr 4">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltMissingSchedAftr" HeaderText="Afr 4">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="total" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltMissingSchedTA" HeaderText="Debit">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD><TD style="HEIGHT: 204px" align=center><asp:GridView id="gdvRecAG3" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" OnRowCreated="gdvRecAG3_RowCreated">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="chvShortMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField ReadOnly="True" DataField="fltMissingSchedBfr" HeaderText="Bfr 4">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltMissingSchedAftr" HeaderText="Afr 4">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="total" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltMissingSchedTA" HeaderText="Debit">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR>
    <tr><td align="center">

        <asp:Button id="btnPrint1" OnClientClick="doPrint()" runat="server" Width="50px" Text="Print" Height="19px"></asp:Button>

        </td></tr>
    <TR><TD align=center colSpan=2><asp:Panel id="pnlLedger" runat="server" BorderColor="#8080FF" BorderStyle="Solid"><TABLE width="100%"><TBODY><TR><TD align=left><asp:Label id="Label2" runat="server" ForeColor="Blue" Font-Bold="True" Text="Opening Balance" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD align=right><asp:Label id="lblOb" runat="server" ForeColor="Red" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD>&nbsp;&nbsp;&nbsp; </TD><TD align=left><asp:Label id="Label3" runat="server" ForeColor="Blue" Font-Bold="True" Text="Interest" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD align=right><asp:Label id="lblInt" runat="server" ForeColor="Red" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD>&nbsp;&nbsp;&nbsp; </TD><TD align=left><asp:Label id="Label4" runat="server" ForeColor="Blue" Font-Bold="True" Text="Withdrawal" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD align=right><asp:Label id="lblWith" runat="server" ForeColor="Red" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="Label5" runat="server" ForeColor="Blue" Font-Bold="True" Text="Remittance" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD align=right><asp:Label id="lblRem" runat="server" ForeColor="Red" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD>&nbsp;&nbsp;&nbsp; </TD><TD align=left><asp:Label id="Label6" runat="server" ForeColor="Blue" Font-Bold="True" Text="Total" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD align=right><asp:Label id="lblTot" runat="server" ForeColor="Red" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD>&nbsp;&nbsp;&nbsp; </TD><TD align=left><asp:Label id="Label7" runat="server" ForeColor="Blue" Font-Bold="True" Text="Closing Balance" Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD align=right><asp:Label id="lblCb" runat="server" ForeColor="Red" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel> 
    
      
    <script type="text/javascript">


        function doPrint() {
            var prtContent = document.getElementById('<%=gdvRecAG1.ClientID %>');
        prtContent.border = 4;
        var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
        WinPrint.document.write(prtContent.outerHTML);
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
    }

    </script>
        
</asp:Content>

