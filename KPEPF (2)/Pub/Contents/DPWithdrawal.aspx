<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_DPWithdrawal, App_Web_zy0s82tr" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE><TBODY></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    <table style="width: 100%">
        <tr>
            <td class="TdMnHead" >
                <asp:Label ID="lblHead" runat="server" class="MnHead" Text="Debit Plus Withdrawal"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="background-color: #ccd0e6; width: 983px; height: 14px;" >
                &nbsp;</td>
        </tr>
        <tr><td align="left" style="height: 39px">
        <asp:Panel ID="pnlAGDPWith" runat="server" Height="25px" Width="950px">
            &nbsp;
        <asp:Label ID="lblvoucher" runat="server" Text="Voucher" Width="50px" Height="16px"></asp:Label>
        <asp:DropDownList ID="ddlVoucher" runat="server" Width="105px">
        </asp:DropDownList>&nbsp;
        </asp:Panel>
        </td></tr>
        <tr><td><asp:Panel runat="server" ID="pnlDebitPlus" Height="25px" Width="950px">
        <asp:GridView id="gdvDebitWith" runat="server" ForeColor="#333333" Width="692px" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<Columns>
    <asp:BoundField DataField="SlNo" HeaderText="SlNo" />
    <asp:TemplateField HeaderText="Account No" >
        <ItemTemplate>
             <asp:TextBox ID="txtACnoDW" runat="server"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Name">
        <ItemTemplate>
            <asp:TextBox ID="txtNameDW" runat="server"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Designation" >
        <ItemTemplate>
            <asp:DropDownList ID="ddlDesiDW" runat="server">
            </asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Withdrawal Type" >
        <ItemTemplate>
            <asp:DropDownList ID="ddlwithTypeDw" runat="server">
            </asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Order No" >
        <ItemTemplate>
            <asp:TextBox ID="txtOrdrnoDW" runat="server" MaxLength="50" Width="115px" Enabled="False" ReadOnly="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Order Date" >
        <ItemTemplate>
            <asp:TextBox ID="txtOrdrDtDW" runat="server" MaxLength="50" Width="115px" Enabled="False" ReadOnly="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Advance Amount">
    <ItemTemplate>
        <asp:TextBox ID="txtAdvncAmt" runat="server"></asp:TextBox>
    </ItemTemplate>
        <ItemStyle Width="12px" />
    </asp:TemplateField>
     <asp:TemplateField HeaderText="Object of Advance" >
        <ItemTemplate>
            <asp:DropDownList ID="ddlObjct" runat="server">
            </asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Order No&date of Prev.TA" >
        <ItemTemplate>
            <asp:TextBox ID="txtOrdrDAte" runat="server" MaxLength="50" Width="115px" Enabled="False" ReadOnly="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Amount of Prev.TA" >
        <ItemTemplate>
            <asp:TextBox ID="txtAmtPrev" runat="server" MaxLength="50" Width="115px" Enabled="False" ReadOnly="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Balance of Prev.TA" >
        <ItemTemplate>
            <asp:TextBox ID="txtBlncePrev" runat="server" MaxLength="50" Width="115px" Enabled="False" ReadOnly="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Consolidated Amount" >
        <ItemTemplate>
            <asp:TextBox ID="txtConAmt" runat="server" MaxLength="50" Width="115px" Enabled="False" ReadOnly="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="No.of Installment" >
        <ItemTemplate>
            <asp:TextBox ID="txtNoInst" runat="server" MaxLength="50" Width="115px" Enabled="False" ReadOnly="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Unposted">
    <ItemTemplate>
        <asp:DropDownList id="ddlUnpstd" runat="server">
        </asp:DropDownList>   
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Reason" >
        <ItemTemplate>
            <asp:TextBox ID="txtRsnDW" runat="server" MaxLength="50" Width="115px" Enabled="False" ReadOnly="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Remarks" >
        <ItemTemplate>
            <asp:TextBox ID="txtRemDW" runat="server" MaxLength="50" Width="115px" Enabled="False" ReadOnly="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Status" >
        <ItemTemplate>
            <asp:DropDownList ID="ddlStaDW" runat="server">
            </asp:DropDownList>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Old ACC No" >
        <ItemTemplate>
            <asp:TextBox ID="txtOldACNo" runat="server" MaxLength="50" Width="115px" Enabled="False" ReadOnly="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>           
<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <EditRowStyle Wrap="True" BackColor="#2461BF" />
    <RowStyle BackColor="#EFF3FB" />
</asp:GridView>
            </asp:Panel>
           </td></tr>
<TR><TD style="WIDTH: 983px; HEIGHT: 70px" align=center>
<asp:Panel id="flgpnl" runat="server" Width="100%">
<table style="width=100%"><tr style="width=100%"> <td align="center" colspan="2">
    <table>
        <tr>
             <td style="width: 100px">
                <asp:Button ID="btnBackDW" runat="server" Text="Back"  Font-Size="Small" ForeColor="Navy" Height="28px" Width="94px" /></td>
             <td style="width: 100px">
                <asp:Button ID="btnDeleteDW" runat="server" Text="Delete"  Font-Size="Small" ForeColor="Navy" Height="28px" Width="94px" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnSaveDW" runat="server" Text="Save"  Font-Size="Small" ForeColor="Navy" Height="28px" Width="96px" OnClick="btnSaveDW_Click" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnClstDW" runat="server" Text="Close"  Font-Size="Small" ForeColor="Navy" Height="28px" Width="94px" /></td>
        </tr>
    </table>
</td></tr></table></asp:Panel> </TD></TR>
</asp:Content>

