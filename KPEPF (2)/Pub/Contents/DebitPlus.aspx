<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_DebitPlus, App_Web_sldhjcan" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY>
<tr><td  colspan="2" class="TdMnHead" ><asp:Label id="lblHead"  runat="server" Text="Debit Plus" class="MnHead"></asp:Label></td></tr>

<TR><TD></TD></TR><TR><TD style="WIDTH: 1029px; HEIGHT: 14px" align=center colSpan=2><asp:Panel id="pnlDrPlus" runat="server" Width="100%" Height="50px" Font-Size="12px" GroupingText="Debit Plus"><TR /><TD style="WIDTH: 983px" align="center" /><asp:Panel id="pnlWithoutDP" runat="server" Width="100%" Font-Bold="False" Height="50px" Font-Size="12px" GroupingText="Without Document"><asp:Label id="lblAmtWODP" runat="server" Text=""></asp:Label> <asp:GridView id="gdvDPWithOut" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE No"><ItemTemplate>
<asp:TextBox id="txtteDPWO" runat="server" __designer:wfdid="w13"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtChlnDPWO" runat="server" __designer:wfdid="w4"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDateDPWO" runat="server" __designer:wfdid="w5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtDPWO" runat="server" Width="115px" __designer:wfdid="w14" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreasuryDPWO" runat="server" __designer:wfdid="w15">
            </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="LB"><ItemTemplate>
<asp:DropDownList id="ddlLB" runat="server" __designer:wfdid="w8">
            </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemDPWO" runat="server" Width="115px" __designer:wfdid="w16" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intId"><ItemTemplate>
<asp:TextBox id="txtintId" runat="server" Width="115px" __designer:wfdid="w10" Enabled="False" MaxLength="50" ReadOnly="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
<asp:Button id="BtnwithoutDt" onclick="BtnwithoutDt_Click" runat="server" Width="54px" Text="Add Row" __designer:wfdid="w11"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView><asp:Button id="btnOkWithouDocsDb" onclick="btnOkWithouDocsDb_Click" runat="server" Text="OK"></asp:Button> </asp:Panel> <asp:Panel id="Panel3" runat="server" Width="100%"><asp:Panel id="pnlWithDP" runat="server" Width="125px" Font-Bold="False" Height="50px" Font-Size="12px" GroupingText="With Document"><asp:Label id="lblamtWDP" runat="server" Text=""></asp:Label> <asp:GridView id="gdvDPWith" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeDP" runat="server" __designer:wfdid="w27"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill No"><ItemTemplate>
<asp:TextBox id="txtBillNoDBPlus" runat="server" __designer:wfdid="w20"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Date"><ItemTemplate>
&nbsp;<asp:TextBox id="txtBilldateDBplus" runat="server" __designer:wfdid="w21"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtDbPlus" runat="server" __designer:wfdid="w22"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dist.Treasury"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlTreasDBplus" runat="server" __designer:wfdid="w23"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted"><ItemTemplate>
<asp:CheckBox id="chkUnpostDPW" runat="server" __designer:wfdid="w24"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason"><ItemTemplate>
<asp:TextBox id="txtReasonDBPlus" runat="server" __designer:wfdid="w25"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStatusDBPlus" runat="server"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intId"><ItemTemplate>
<asp:TextBox id="txtintId" runat="server" Width="115px" Enabled="False" MaxLength="50" ReadOnly="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
<asp:Button id="BtnwithDt" onclick="BtnwithDt_Click" runat="server" Width="54px" Text="Add Row" __designer:wfdid="w26"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <asp:Button id="btnSaveDBPlus" onclick="btnSaveDBPlus_Click" runat="server" Width="96px" ForeColor="Navy" Text="Save" Height="28px" Font-Size="Small"></asp:Button> </asp:Panel> &nbsp; <asp:Panel id="pnlBTDP" runat="server" Width="100%" Font-Bold="False" Height="50px" Font-Size="12px" GroupingText="Balance Transfer"><asp:Label id="lblAmtBDP" runat="server" Text=""></asp:Label> <asp:GridView id="gdvBlnsDP" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNo" runat="server" __designer:wfdid="w34"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="From Acc No"><ItemTemplate>
<asp:TextBox id="txtFromACc" runat="server" __designer:wfdid="w35"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ToAcc No"><ItemTemplate>
<asp:TextBox id="txtName" runat="server" __designer:wfdid="w36"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmount" runat="server" __designer:wfdid="w37"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemarks" runat="server" Width="115px" __designer:wfdid="w38" Enabled="False" MaxLength="50" ReadOnly="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intId"><ItemTemplate>
<asp:TextBox id="txtintId" runat="server" __designer:wfdid="w39"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
<asp:Button id="BtnBTDt" onclick="BtnBTDt_Click" runat="server" Width="54px" Text="Add Row" __designer:wfdid="w40"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <asp:Button id="btnbalance" onclick="btnbalance_Click" runat="server" Text="OK"></asp:Button></asp:Panel> &nbsp;&nbsp;</asp:Panel> <TR /><TD style="WIDTH: 983px; HEIGHT: 70px" align="center" /><asp:Panel id="Panel6" runat="server" Width="100%">
<table style="width=100%;"><tr style="width=100%;"> <td align="center" colspan="2">
    <table>
        <tr>
            <td style="width: 100px">
                <asp:Button ID="btnBckDP" runat="server" Text="Back"  Font-Size="Small" ForeColor="Navy" Height="28px" Width="100px" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnSaveDP" runat="server" Text="Save"  Font-Size="Small" ForeColor="Navy"  Height="28px" Width="96px" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnWithDP" runat="server" Text="Withdrawal"  Font-Size="Small" ForeColor="Navy"  Height="28px" Width="96px" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnClsDP" runat="server" Text="Close"  Font-Size="Small" ForeColor="Navy"  Height="28px" Width="94px" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnPrtDP" runat="server" Text="Print"  Font-Size="Small" ForeColor="Navy"  Height="28px" Width="94px" /></td>
        </tr>
    </table>
</td></tr></table></asp:Panel> </asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
