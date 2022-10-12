<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="DebitPlusPDE.aspx.cs" Inherits="Contents_DebitPlusPDE" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="Transfer Entry_Debit Plus"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblYear" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Panel id="pnlMain" runat="server"><TABLE><TBODY><TR><TD align=left><asp:Label id="lbl11" runat="server" Text="Debit Plus " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTot" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lblTotET" runat="server" Text="Debit Plus Entered " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTotE" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblBal" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><%--<TR><TD align=right><asp:Label id="lbl11" runat="server" Text="Credit Plus " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblTot" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR>
<TR><TD align=right><asp:Label id="lblTotET" runat="server" Text="Debit Plus Entered " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblTotE" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR>
<TR><TD align=right><asp:Label id="lbl12" runat="server" Text="  Balance " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblBal" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR>--%><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lbl1" runat="server" Text="Without Supporting Documents" CssClass="p1"></asp:Label>&nbsp; &nbsp;&nbsp;&nbsp;<asp:Label id="lblAmtWOCP" runat="server" CssClass="p4"></asp:Label> </TD></TR>
    
    
<TR><TD colSpan=2><asp:Label id="Label51" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:TextBox id="txtCntWO" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="2" OnTextChanged="txtCntWO_TextChanged" AutoPostBack="True"></asp:TextBox> </TD></TR>

    <TR align=center><TD colSpan=2><asp:GridView id="gdvDPWithOut" runat="server" Width="900px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True" ><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE No"><ItemTemplate>
<asp:TextBox id="txtteDPWO" runat="server" Width="88px" __designer:wfdid="w3"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill No"><ItemTemplate>
<asp:TextBox id="txtChlnDPWO" Text="0" runat="server" Width="88px" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  CssClass="txtNumeric"  MaxLength="7"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDateDPWO" runat="server" CssClass="datePicker" Width="88px" OnTextChanged="txtChlnDateDPWO_TextChanged" AutoPostBack="True" __designer:wfdid="w4" MaxLength="10"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtDPWO" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="88px" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtAmtDPWO_TextChanged" __designer:wfdid="w4" MaxLength="6"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreasuryDPWO" runat="server" Width="173px" __designer:wfdid="w6" OnSelectedIndexChanged="ddlTreasuryDPWO_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> 
</ItemTemplate><ItemStyle Width="175px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="LocalBody" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlLB" runat="server" Width="173px" __designer:wfdid="w5"></asp:DropDownList> 
</ItemTemplate><ItemStyle Width="175px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemDPWO" runat="server" Width="148px" MaxLength="50"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="150px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Collect"><ItemTemplate>
<asp:CheckBox id="chkCollect" runat="server"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="IntId"><ItemTemplate>
<asp:Label id="lblintId" runat="server" Text = "0" Width="71px"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="intMnthId"><ItemTemplate>
<asp:TextBox id="RelMnth" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="intYrId"><ItemTemplate>
<asp:TextBox id="RelYearId" runat="server" Width="71px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="RelMnthWiseID"><ItemTemplate>
<asp:TextBox id="txtRelMnthWiseId" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
<ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="30px" CssClass="cssHeadGridEng" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btndeletedTplusMissing" onclick="btndeletedTplusMissing_Click" runat="server" onclientclick="return DeleteItem()" ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD align=center colSpan=2><asp:Button id="btnOkWithouDocsDb" onclick="btnOkWithouDocsDb_Click" runat="server" Height="19px" Width="53px" Text="Save"></asp:Button></TD></TR><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lbl2" runat="server" Text="Bill Entry" CssClass="p1"></asp:Label>&nbsp; &nbsp;&nbsp;&nbsp; <asp:Label id="lblAmtWCP" runat="server" CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lbl23" runat="server" Text="Employee wise Entry" CssClass="p1"></asp:Label> &nbsp; &nbsp;&nbsp;&nbsp;<asp:Label id="lblAmtBill" runat="server" CssClass="p4"></asp:Label> </TD></TR><TR><TD colSpan=2><asp:Label id="lblCntCap" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="2" OnTextChanged="txtCntRow_TextChanged" AutoPostBack="True"></asp:TextBox> </TD></TR><TR align=center><TD colSpan=2>
    <asp:GridView id="gdvDPWith" runat="server" Width="900px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeDP" runat="server" Width="71px" __designer:wfdid="w24"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill No."><ItemTemplate>
<asp:TextBox id="txtBillNoWD" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  CssClass="txtNumeric" MaxLength="6" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Date"><ItemTemplate>
&nbsp;<asp:TextBox id="txtBilldateDBplus" CssClass="datePicker" runat="server" Width="71px" OnTextChanged="txtBilldateDBplus_TextChanged" AutoPostBack="True" __designer:wfdid="w8" MaxLength="10"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DrawnBy"><ItemTemplate>
<asp:DropDownList id="ddldrawn" runat="server" Width="80px" __designer:wfdid="w7"></asp:DropDownList> 
</ItemTemplate>
    <ItemStyle Width="20px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtDbPlus" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="71px" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtAmtDbPlus_TextChanged" __designer:wfdid="w8" MaxLength="6"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dist.Treasury"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlTreasDBplus" runat="server" Width="150px" __designer:wfdid="w9"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted"><ItemTemplate>
<asp:CheckBox id="chlUnpostDPW" runat="server" Width="71px" __designer:wfdid="w10" AutoPostBack="True" OnCheckedChanged="chlUnpostDPW_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Reason"><ItemTemplate>
<asp:TextBox id="txtReasonDBPlus" runat="server" Width="100px" __designer:wfdid="w11"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>--%>
    <asp:TemplateField HeaderText="Reason"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlreason" runat="server" Width="71px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField DataTextField="intVoucherNo" DataNavigateUrlFields="intVoucherID" DataNavigateUrlFormatString="~/Contents/WithdrawalPDEAG.aspx?intVoucherID={0}" Text="Bill" HeaderText="Bill No."></asp:HyperLinkField>
<asp:TemplateField HeaderText="intId" Visible="False"><ItemTemplate>
&nbsp;<asp:Label id="lblintId" Text ="0" runat="server" __designer:wfdid="w27"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelmtnhWiseId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRelMnthWiseIdW" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelMnth" Visible="False"><ItemTemplate>
<asp:Label id="lblMnth" runat="server" Width="71px" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelYear" Visible="False"><ItemTemplate>
<asp:Label id="lblYearId" runat="server" Width="71px"  Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndeleteWth" onclick="btnDeleteWth_Click" runat="server" __designer:wfdid="w7" ImageUrl="~/images/removerow.gif" onclientclick="return DeleteItem()"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="30px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
</asp:TemplateField>

    <asp:TemplateField HeaderText="EditId" Visible="False"><ItemTemplate>
<asp:Label id="lblEditId" runat="server" __designer:wfdid="w21">0</asp:Label> 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="RelDay" Visible="False"><ItemTemplate>
<asp:Label id="lblDay" runat="server" Width="71px"  Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD align=center colSpan=2><asp:Button id="btnSaveDBPlus" onclick="btnSaveDBPlus_Click" runat="server" Height="19px" Width="53px" Text="Save"></asp:Button> </TD></TR><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lbl3" runat="server" Text="Balance Transfer" CssClass="p1"></asp:Label> &nbsp; &nbsp;&nbsp;&nbsp; <asp:Label id="lblAmtBTCP" runat="server" CssClass="p4"></asp:Label></TD></TR>
    <TR><TD colSpan=2><asp:Label id="Label71" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:TextBox id="txtCntb" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="2" OnTextChanged="txtCntb_TextChanged" AutoPostBack="True"></asp:TextBox> </TD></TR>
    
    <TR><TD align=center colSpan=2><asp:GridView id="gdvBlnsDP" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNo" runat="server" Width="88px" __designer:wfdid="w1"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="From Acc No"><ItemTemplate>
<asp:TextBox id="txtFromACc" runat="server" Width="88px" OnTextChanged="txtFromACc_TextChanged" AutoPostBack="True"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txtfrmName" runat="server" Width="178px" __designer:wfdid="w2" ReadOnly="True"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="180px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="ToAcc No"><ItemTemplate>
<asp:TextBox id="txtName" runat="server" Width="88px" MaxLength="15"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Name" Visible="False"><ItemTemplate>
<asp:TextBox id="txtToName" runat="server" Width="100px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmount" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="88px" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtAmount_TextChanged" __designer:wfdid="w14" MaxLength="6"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemarks" runat="server" Width="178px"  MaxLength="50" ></asp:TextBox> 
</ItemTemplate><ItemStyle Width="180px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="intId" Visible="False"><ItemTemplate>
<asp:Label id="lblintId" runat="server" Width="71px" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelmnthId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRelMnthIDbalDb" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intAccno" Visible="False"><ItemTemplate>
<asp:Label id="lblAccNo" runat="server"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="OldAccno" Visible="False"><ItemTemplate>
<asp:Label id="lbloldAcc" runat="server"  Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
        <asp:TemplateField HeaderText="OldAmt" Visible="False"><ItemTemplate>
<asp:Label id="lbloldAmt" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align="center" colSpan="2">
    <asp:Button id="btnBack"  runat="server" Width="53px" Text="Back " Height="19px" OnClick="btnBack_Click" ></asp:Button>
    <asp:Button id="btnbalance" onclick="btnbalance_Click" runat="server" Width="53px" Height="19px" Text="Save"></asp:Button></TD></TR><TR><TD colSpan=2>

<%--<asp:LinkButton id="btnBack" onclick="btnBack_Click" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to AG Statements" Height="23px"></asp:LinkButton>--%> 



</TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
 </asp:Content>

