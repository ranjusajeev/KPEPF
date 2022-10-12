<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_DebitPlusCurr, App_Web_4p3ju0t2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="Transfer Entry_Debit Plus"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblYear" runat="server" Text="..." CssClass="p4" Font-Names="Verdana" Font-Size="10pt"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4" Font-Names="Verdana" Font-Size="10pt"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Panel id="pnlMain" runat="server"><TABLE><TBODY><TR><TD align=left><asp:Label id="lbl11" runat="server" Text="Debit Plus " CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTot" runat="server" Text="..." CssClass="p4" Font-Names="Verdana" Font-Size="10pt"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lblTotET" runat="server" Text="Debit Plus Entered " CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTotE" runat="server" Text="..." CssClass="p4" Font-Names="Verdana" Font-Size="10pt"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblBal" runat="server" Text="..." CssClass="p4" Font-Names="Verdana" Font-Size="10pt"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><%--<TR><TD align=right><asp:Label id="lbl11" runat="server" Text="Credit Plus " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblTot" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR>
<TR><TD align=right><asp:Label id="lblTotET" runat="server" Text="Debit Plus Entered " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblTotE" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR>
<TR><TD align=right><asp:Label id="lbl12" runat="server" Text="  Balance " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblBal" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR>--%><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lbl1" runat="server" Text="Without Supporting Documents" CssClass="p1"></asp:Label>&nbsp; &nbsp;&nbsp;&nbsp;<asp:Label id="lblAmtWOCP" runat="server" CssClass="p4"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 22px" colSpan=2><asp:Label id="lblCntWthout" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp; <asp:TextBox id="txtCntwtht" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtCntwtht_TextChanged" MaxLength="2"></asp:TextBox> </TD></TR><TR align=center><TD colSpan=2><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvDPWithOut" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE No"><ItemTemplate>
<asp:TextBox id="txtteDPWO" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="88px" CssClass="txtNumeric" MaxLength="10"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill No"><ItemTemplate>
<asp:TextBox id="txtChlnDPWO" Text="0" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="88px" CssClass="txtNumeric" MaxLength="7"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDateDPWO" runat="server" CssClass="datePicker" Width="88px" OnTextChanged="txtChlnDateDPWO_TextChanged" AutoPostBack="True" MaxLength="10"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtDPWO" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="88px" CssClass="txtNumeric" OnTextChanged="txtAmtDPWO_TextChanged" AutoPostBack="True" MaxLength="6"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Dist. Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreasuryDPWO" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="ddlTreasuryDPWO_SelectedIndexChanged"></asp:DropDownList> 
</ItemTemplate><ItemStyle Width="177px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="LocalBody" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlLB" runat="server" Width="175px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemDPWO" runat="server" Width="148px" MaxLength="50"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="150px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Collect"><ItemTemplate>
<asp:CheckBox id="chkCollect" runat="server" OnCheckedChanged="chkCollect_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="IntId"><ItemTemplate>
<asp:Label id="lblintId" runat="server" Text="0"></asp:Label>&nbsp; 
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
</asp:GridView> </DIV></TD></TR><TR><TD align=center colSpan=2><asp:Button id="btnOkWithouDocsDb" onclick="btnOkWithouDocsDb_Click"  Height="19px" runat="server" Width="53px" Text="Save"></asp:Button></TD></TR><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lbl2" runat="server" Text="Bill Entry" CssClass="p1"></asp:Label>&nbsp; &nbsp;&nbsp;&nbsp; <asp:Label id="lblAmtWCP" runat="server" CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lbl23" runat="server" Text="Employee wise Entry" CssClass="p1"></asp:Label> &nbsp; &nbsp;&nbsp;&nbsp;<asp:Label id="lblAmtBill" runat="server" CssClass="p4"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 22px" colSpan=2><asp:Label id="lblCntCap" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp; <asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtCntRow_TextChanged" MaxLength="2"></asp:TextBox> </TD></TR><TR align=center><TD colSpan=2><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvDPWith" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2"><Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeDP" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="71px" CssClass="txtNumeric" MaxLength="10"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill No."><ItemTemplate>
<asp:TextBox id="txtBillNoWD" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  CssClass="txtNumeric" MaxLength="6" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Date"><ItemTemplate>
&nbsp;<asp:TextBox id="txtBilldateDBplus" runat="server" CssClass="datePicker" Width="71px" AutoPostBack="True" OnTextChanged="txtBilldateDBplus_TextChanged" MaxLength="10"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DrawnBy"><ItemTemplate>
<asp:DropDownList id="ddldrawn" runat="server" Width="120px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtDbPlus" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="71px" CssClass="txtNumeric" OnTextChanged="txtAmtDbPlus_TextChanged" AutoPostBack="True" MaxLength="8"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dist.Treasury"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlTreasDBplus" runat="server" Width="150px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Un P"><ItemTemplate>
<asp:CheckBox id="chlUnpostDPW" runat="server" Width="50px" AutoPostBack="True" OnCheckedChanged="chlUnpostDPW_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Reason"><ItemTemplate>
<asp:TextBox id="txtReasonDBPlus" runat="server" Width="100px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Reason"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlreason" runat="server" Width="71px" Enabled="False"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField HeaderText="Bill" Text="Bill" DataNavigateUrlFormatString="~/Contents/WithdrawalsEmpCurr.aspx?numBillID={0}&amp;fltBillAmount={1}&amp;intTreasuryId={2}" DataNavigateUrlFields="numBillID,fltBillAmount,intTreasuryId"></asp:HyperLinkField>
<asp:TemplateField HeaderText="intId" Visible="False"><ItemTemplate>
&nbsp;<asp:Label id="lblintId" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="RelmtnhWiseId"><ItemTemplate>
<asp:TextBox id="txtRelMnthWiseIdW" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<%--<asp:TemplateField Visible="False" HeaderText="RelMnth"><ItemTemplate>
<asp:TextBox id="RelMnth" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="RelYear"><ItemTemplate>
<asp:TextBox id="RelYearId" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>--%>

<asp:TemplateField HeaderText="lblEditId" Visible="False" ><ItemTemplate>
<asp:Label id="lblEditId" runat="server" Text="0" __designer:wfdid="w4"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
   
    <asp:TemplateField HeaderText="YearId" Visible="False" ><ItemTemplate>
<asp:Label id="lblYearId" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="MonthId" Visible="False" ><ItemTemplate>
<asp:Label id="lblMnth" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<%--<asp:TemplateField HeaderText="Day" ><ItemTemplate>
<asp:Label id="lblDay" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>--%>

<asp:TemplateField HeaderText="Delete">
<ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="30px" CssClass="cssHeadGridEng" HorizontalAlign="Right"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btndeletedDtlus" onclick="btndeletedDtlus_Click" runat="server" onclientclick="return DeleteItem()" ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>

</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD align=center colSpan=2><asp:Button id="btnSaveDBPlus" onclick="btnSaveDBPlus_Click"  Height="19px" runat="server" Width="53px" Text="Save"></asp:Button> </TD></TR><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lbl3" runat="server" Text="Balance Transfer" CssClass="p1"></asp:Label> &nbsp; &nbsp;&nbsp;&nbsp; <asp:Label id="lblAmtBTCP" runat="server" CssClass="p4"></asp:Label></TD></TR><TR><TD style="HEIGHT: 22px" colSpan=2><asp:Label id="lblCntCapBT" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp; <asp:TextBox id="txtCntBT" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtCntBTRow_TextChanged" MaxLength="2"></asp:TextBox> </TD></TR><TR><TD align=center colSpan=2><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvBlnsDP" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNo" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="88px" CssClass="txtNumeric" MaxLength="10"></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="90px" />

</asp:TemplateField>
<asp:TemplateField HeaderText="From Acc No"><ItemTemplate>
<asp:TextBox id="txtFromACc" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="88px" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtFromACc_TextChanged"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txtfrmName" runat="server" Width="198px" ReadOnly="true"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="200px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="ToAcc No"><ItemTemplate>
<asp:TextBox id="txtName" runat="server" Width="88px" OnTextChanged="txtName_TextChanged"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Name" Visible="False"><ItemTemplate>
<asp:TextBox id="txtToName" runat="server" Width="100px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmount" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="88px" CssClass="txtNumeric" OnTextChanged="txtAmount_TextChanged" AutoPostBack="True" MaxLength="8"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="90px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemarks" runat="server" Width="178px" MaxLength="50"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="180px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="intId" Visible="False"><ItemTemplate>
<asp:Label id="lblintId" runat="server" Text="0"></asp:Label>&nbsp;
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelmnthId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRelMnthIDbalDb" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intAccno" Visible="False"><ItemTemplate>
<asp:Label id="lblaccNo" runat="server"></asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="AccNoOld" Visible="False"><ItemTemplate>
<asp:Label id="lblAccNoNew" runat="server">0</asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="AmtOld" Visible="False"><ItemTemplate>
<asp:Label id="lblAmtOld" runat="server">0</asp:Label>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndeletedDtbal" onclick="btndeletedDtbal_Click" runat="server" onclientclick="return DeleteItem()" ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Right" CssClass="cssHeadGridEng" Width="30px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
</asp:TemplateField>


</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD align="center" colSpan="2">

<asp:Button id="btnBack"  runat="server" Width="53px" Text="Back " Height="19px" OnClick="btnBack_Click" ></asp:Button>
    <asp:Button id="btnbalance" onclick="btnbalance_Click"  Height="19px" runat="server" Width="53px" Text="Save"></asp:Button></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    
<%--    <script language="javascript" type="text/javascript">
Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()

{
$(".datePicker").datepicker 
          ({
                numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
//                yearRange: "-10:+0",
      });
              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
});
</script>
<script language=javascript type="text/javascript">
 function isNumberKey(evt)
    {
        if(document.activeElement.className == "txtNumeric"||document.activeElement.className == "txtBoxNumericPhone")
        {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if ((charCode < 48 || charCode > 57) && charCode != 8)
             return false;
             else
             return true;
        }
        if(document.activeElement.className == "txtNumericFloat")
        {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode != 46 && (charCode < 48 || charCode > 57))
             return false;
             else
             return true;
        }
    }
    function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
        
        function checkNumOnly(input)
{
   $(input).bind('keyup blur', function () { $(this).val($(this).val().replace(/[^0-9.]/g, '')) }); 
   return true;
}

    </script>
--%></asp:Content>

