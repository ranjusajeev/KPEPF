<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_DebitPlusPDE, App_Web_sldhjcan" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colspan="2"><asp:Label id="lblHead" runat="server" class="MnHead" Text="Transfer Entry_Debit Plus" ></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblYear" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD>

<TD align=right>
<asp:Panel runat="server" id="pnlMain">
<table><tr>
<td align="left"><asp:Label id="lbl11" runat="server" Text="Debit Plus " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</td>
<td  align="right"> <asp:Label id="lblTot" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></td>
</tr>

<tr>
<td align="left"><asp:Label id="lblTotET" runat="server" Text="Credit Plus Entered " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</td>
<td  align="right"> <asp:Label id="lblTotE" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></td>
</tr>

<tr>
<td align="left"><asp:Label id="lbl12" runat="server" Text="  Balance " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</td>
<td  align="right"> <asp:Label id="lblBal" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></td>
</tr>

</table>
</asp:Panel>
</TD></TR>

<%--<TR><TD align=right><asp:Label id="lbl11" runat="server" Text="Credit Plus " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblTot" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR>
<TR><TD align=right><asp:Label id="lblTotET" runat="server" Text="Debit Plus Entered " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblTotE" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR>
<TR><TD align=right><asp:Label id="lbl12" runat="server" Text="  Balance " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblBal" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR>--%>

<TR><TD  colspan="2"><asp:Label id="lbl1" runat="server" Text="Without Supporting Documents" CssClass="p1"></asp:Label> <asp:Label id="lblAmtWOCP" runat="server" CssClass="p4"></asp:Label> </TD></TR><TR><TD  colspan="2"><asp:GridView id="gdvDPWithOut" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE No"><ItemTemplate>
<asp:TextBox id="txtteDPWO" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill No"><ItemTemplate>
<asp:TextBox id="txtChlnDPWO" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Dt."><ItemTemplate>
<asp:TextBox id="txtChlnDateDPWO" runat="server" Width="71px" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtDPWO" runat="server" Width="71px" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTreasuryDPWO" runat="server" Width="175px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="LocalBody"><ItemTemplate>
<asp:DropDownList id="ddlLB" runat="server" Width="175px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemDPWO" runat="server" Width="71px" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Collect"><ItemTemplate>
<asp:CheckBox id="chkCollect" runat="server"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="IntId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtintId" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
<asp:Button id="Btnwithout" onclick="Btnwithout_Click" runat="server" Width="54px" Text="Add Row"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intMnthId" Visible="False"><ItemTemplate>
<asp:TextBox id="RelMnth" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intYrId" Visible="False"><ItemTemplate>
<asp:TextBox id="RelYearId" runat="server" Width="71px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelMnthWiseID" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRelMnthWiseId" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD align=center  colspan="2"><asp:Button id="btnOkWithouDocsDb" onclick="btnOkWithouDocsDb_Click" runat="server" Text="OK"></asp:Button></TD></TR><TR><TD  colspan="2"><asp:Label id="lbl2" runat="server" Text="Bill Entry" CssClass="p1"></asp:Label> <asp:Label id="lblAmtWCP" runat="server" CssClass="p4"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lbl23" runat="server" Text="Employee wise Entry" CssClass="p1"></asp:Label> <asp:Label id="lblAmtBill" runat="server" CssClass="p4"></asp:Label>
</TD></TR><TR><TD  colspan="2"><asp:GridView id="gdvDPWith" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeDP" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField DataNavigateUrlFields="intVoucherID" DataNavigateUrlFormatString="~/Contents/WithdrawalPDEAG.aspx?intVoucherID={0}" DataTextField="intVoucherNo" HeaderText="Bill No."></asp:HyperLinkField>
<asp:TemplateField HeaderText="Bill Date"><ItemTemplate>
&nbsp;<asp:TextBox id="txtBilldateDBplus" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DrawnBy"><ItemTemplate>
<asp:DropDownList id="ddldrawn" runat="server" Width="150px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtDbPlus" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dist.Treasury"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlTreasDBplus" runat="server" Width="150px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted"><ItemTemplate>
<asp:CheckBox id="chkUnpostDPW" runat="server" Width="71px"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason"><ItemTemplate>
<asp:TextBox id="txtReasonDBPlus" runat="server" Width="100px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>--%>
<asp:TemplateField HeaderText="intId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtintId" runat="server" Width="71px" Enabled="False" MaxLength="50" ReadOnly="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
<asp:Button id="BtnwithDt" onclick="BtnwithDt_Click" runat="server" Width="71px" Text="Add Row"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelmtnhWiseId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRelMnthWiseIdW" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelMnth" Visible="False"><ItemTemplate>
<asp:TextBox id="RelMnth" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelYear" Visible="False"><ItemTemplate>
<asp:TextBox id="RelYearId" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD align=center  colspan="2"><asp:Button id="btnSaveDBPlus" onclick="btnSaveDBPlus_Click" runat="server" Text="OK"></asp:Button> </TD></TR><TR><TD  colspan="2"><asp:Label id="lbl3" runat="server" Text="Balance Transfer" CssClass="p1"></asp:Label><asp:Label id="lblAmtBTCP" runat="server" CssClass="p4"></asp:Label></TD></TR><TR><TD align="center"  colspan="2"><asp:GridView id="gdvBlnsDP" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNo" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="From Acc No"><ItemTemplate>
<asp:TextBox id="txtFromACc" runat="server" Width="71px" OnTextChanged="txtFromACc_TextChanged" AutoPostBack="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txtfrmName" runat="server" Width="150px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ToAcc No"><ItemTemplate>
<asp:TextBox id="txtName" runat="server" Width="100px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txtToName" runat="server" Width="100px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmount" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemarks" runat="server" Width="115px" Enabled="False" MaxLength="50" ReadOnly="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<%--<asp:TemplateField HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStatus" runat="server" Width="71px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>--%>
<asp:TemplateField HeaderText="intId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtintId" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
<asp:Button id="BtnBTDt" onclick="BtnBTDt_Click" runat="server" Width="54px" Text="Add Row"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelmnthId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRelMnthIDbalDb" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intAccno" Visible="False"><ItemTemplate>
<asp:TextBox id="accNo" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=center  colspan="2"><asp:Button id="btnbalance" onclick="btnbalance_Click" runat="server" Text="OK"></asp:Button></TD></TR><TR><TD  colspan="2"><asp:LinkButton id="btnBack" onclick="btnBack_Click" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to AG Statements" Height="23px"></asp:LinkButton> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    
    <script language="javascript" type="text/javascript">
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
</asp:Content>

