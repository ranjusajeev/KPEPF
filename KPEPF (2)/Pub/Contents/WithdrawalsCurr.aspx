<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_WithdrawalsCurr, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" runat="server" class="MnHead" Text="Withdrawals_Treasury" ></asp:Label> </TD></TR><TR><TD style="align: left"><asp:Label id="YearVal" runat="server" Text="Year" CssClass="p4"></asp:Label></TD><TD style="align: left"><asp:Label id="Label2Val" runat="server" Text="Month" CssClass="p4"></asp:Label></TD><TD style="align: left"><asp:Label id="Label4Val" runat="server" Text="District Tresury" CssClass="p4"></asp:Label></TD><TD style="align: left"><asp:Label id="lblAmtBk" runat="server" CssClass="p4" text="Amt"></asp:Label></TD></TR><TR align=left><TD style="HEIGHT: 22px; align: left"><asp:Label id="lblInti" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Verdana" text="Intimation Date"></asp:Label></TD><TD style="HEIGHT: 22px; align: left"><asp:Label id="txtInt" runat="server" CssClass="p3"></asp:Label></TD><TD style="HEIGHT: 22px; align: left"><asp:Label id="lblAmt" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Verdana" text="Amount"></asp:Label></TD>&nbsp; <TD style="HEIGHT: 22px; align: left"><asp:Label id="txtAmt" runat="server" CssClass="p3" text="Amount"></asp:Label>&nbsp;&nbsp;</TD></TR><TR align=left><TD align=left colSpan=1><asp:Label id="lblRem" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Verdana" text="Remarks"></asp:Label></TD><TD style="align: left"><asp:Label id="txtRem" runat="server" CssClass="p3" text="Remarks"></asp:Label></TD></TR><TR><TD align=center colSpan=4>&nbsp;<asp:Label id="lblSTDet" runat="server" CssClass="p3"></asp:Label> </TD></TR><TR><TD style="WIDTH: 500px" vAlign=top colSpan=2><asp:GridView id="gdvChalanS" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5">
<FooterStyle BackColor="Maroon" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No.">
<ItemStyle Width="50px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AccDt" HeaderText="Acc. Date">
<ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="Trn Date" DataTextField="TrnDt" DataNavigateUrlFormatString="~/Contents/WithdrawalsCurr.aspx?intTreasuryId={0}&amp;intDay={1}&amp;intDayAccDt={2}" DataNavigateUrlFields="intTreasuryId,intDay,intDayAccDt">
<ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltBillAmount" HeaderText="Amount">
<ItemStyle Width="100px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#E0E0E0" ForeColor="#333333"></RowStyle>

<EditRowStyle Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#FFCC66" ForeColor="Navy" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="Gray" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD><TD style="WIDTH: 500px" vAlign=top colSpan=2><asp:GridView id="gdvChalanLB" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No.">
<ItemStyle Width="50px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField HeaderText="Bill Details" DataTextField="dtBillDate" DataNavigateUrlFormatString="~/Contents/ChalanEdit.aspx?numBillID={0}" DataNavigateUrlFields="numBillID">
<ItemStyle Width="200px" HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltBillAmount" HeaderText="Amount">
<ItemStyle Width="100px" HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Unposted"><ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" Width="80px" Enabled="False" OnCheckedChanged="chkApp_CheckedChanged" AutoPostBack="True" __designer:wfdid="w3"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Rsn" HeaderText="Reason">
<ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=left><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Withdrawals" Height="23px"></asp:LinkButton></TD><TD></TD><TD style="WIDTH: 855px" align=left colSpan=2><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="48px" Text="Print"></asp:Button> </TD></TR></TBODY></TABLE>
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
                yearRange: "-56:+0",
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
   
	</script>
</asp:Content>

