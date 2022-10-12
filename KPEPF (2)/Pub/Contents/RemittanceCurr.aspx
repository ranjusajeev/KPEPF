<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_RemittanceCurr, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" runat="server" class="MnHead" Text="Remittance_Treasury" ></asp:Label> </TD></TR><TR><TD style="align: left"><asp:Label id="YearVal" runat="server" Text="Year" CssClass="p4"></asp:Label></TD><TD style="align: left"><asp:Label id="Label2Val" runat="server" Text="Month" CssClass="p4"></asp:Label></TD><TD style="align: left"><asp:Label id="Label4Val" runat="server" Text="District Tresury" CssClass="p4"></asp:Label></TD><TD style="align: left"><asp:Label id="lblAmtBk" runat="server" CssClass="p4" text="Amt"></asp:Label></TD></TR>
<tr><td>&nbsp;</td></tr>
<TR align=left><TD style="HEIGHT: 22px; align: left"><asp:Label id="lblInti" runat="server"  CssClass="p1" text="Intimation Date"></asp:Label></TD><TD style="HEIGHT: 22px; align: left"><asp:Label id="txtInt" runat="server" CssClass="p4"></asp:Label></TD><TD style="HEIGHT: 22px; align: left"><asp:Label id="lblAmt" runat="server" CssClass="p1" text="Amount"></asp:Label> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="txtAmt" runat="server" CssClass="p4" text="Amount"></asp:Label>&nbsp;&nbsp;</TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<TD style="WIDTH: 140px" align=left><asp:Label id="lblRem" runat="server" CssClass="p1" text="Remarks"></asp:Label>&nbsp;<asp:Label id="txtRem" runat="server" CssClass="p4" text="Remarks"></asp:Label></TD></TR>
<tr><td>&nbsp;</td></tr>
<TR><TD align=center colSpan=4>&nbsp;<asp:Label id="lblSTDet" runat="server" CssClass="p4"></asp:Label> </TD></TR><TR><TD vAlign=top colSpan=2><asp:GridView id="gdvChalanS" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<FooterStyle BackColor="#1C5E55" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:BoundField DataField="AccDt" HeaderText="Acc. Date"></asp:BoundField>
<asp:BoundField DataField="TrnDt" HeaderText="Trn Date"></asp:BoundField>
<asp:HyperLinkField HeaderText="Sub Treasury" DataTextField="chvTreasuryNameDisp" DataNavigateUrlFormatString="~/Contents/RemittanceCurr.aspx?intTreasuryId={0}&amp;intDay={1}&amp;intDayAccDt={2}" DataNavigateUrlFields="intTreasuryId,intDay,intDayAccDt">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="Gainsboro"></RowStyle>

<EditRowStyle BackColor="#7C6F57" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="Gray" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD><TD style="WIDTH: 864px" vAlign=top colSpan=2><asp:GridView id="gdvChalanLB" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:BoundField DataField="chvTreasuryNameDisp" HeaderText="Sub Treasury"></asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody"></asp:BoundField>
<asp:HyperLinkField HeaderText="Chalan details" DataTextField="dtChalanDate" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;fltChalanAmt={1}" DataNavigateUrlFields="numChalanId,fltChalanAmt">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Unposted"><HeaderTemplate>
<asp:CheckBox id="Allchk" runat="server" Text="Unposted" AutoPostBack="True" OnCheckedChanged="Allchk_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged" Width="1px" Enabled="False"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Rsn" HeaderText="Reason"></asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=left><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Remittance" Height="23px"></asp:LinkButton></TD><TD></TD><TD style="WIDTH: 855px" align=left colSpan=2><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="48px" Text="Print"></asp:Button> </TD></TR></TBODY></TABLE>
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

