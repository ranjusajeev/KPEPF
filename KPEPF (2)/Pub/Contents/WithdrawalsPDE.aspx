<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_WithdrawalsPDE, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
  <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Withdrawals_Treasury"></asp:Label> </TD></TR><TR align=left><TD><asp:Label id="Year" runat="server" Text="Year" CssClass="p1"></asp:Label></TD><TD style="align: left"><asp:DropDownList id="ddlYear" runat="server" Width="150px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="align: left"><asp:Label id="Label3" runat="server" Text="District" CssClass="p1"></asp:Label></TD><TD style="align: left"><asp:DropDownList id="ddldist" runat="server" Width="150px" OnSelectedIndexChanged="ddldist_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR align=left><TD style="align: left"><asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label></TD><TD style="align: left"><asp:DropDownList id="ddlMnth" runat="server" Width="150px" OnSelectedIndexChanged="ddlMnth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD style="align: left"><asp:Label id="Label4" runat="server" Text="District Tresury" CssClass="p1"></asp:Label></TD><TD style="align: left"><asp:DropDownList id="ddlDT" runat="server" Width="150px" OnSelectedIndexChanged="ddlDT_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD>&nbsp;</TD></TR><%--<TR><TD align=left>&nbsp;<asp:Label id="lblSTDet" runat="server" Text="..." CssClass="p4"></asp:Label></TD>&nbsp;&nbsp; <TD align=right><asp:Label id="lblSTDet2" runat="server" Text="..." CssClass="p4"></asp:Label> </TD>&nbsp;&nbsp; <TD align=right><asp:Label id="lblSTDet3" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR>
--%><TR><TD align=left colSpan=2><asp:Label id="lbl1" runat="server" Text="Acc. Date wise Details" CssClass="p1"></asp:Label></TD><TD align=left colSpan=2>&nbsp;<asp:Label id="lbl2" runat="server" Text="Bill Details" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblSTDet3" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR></TR><TR><TD style="HEIGHT: 188px" vAlign=top colSpan=2><asp:GridView id="gdvChalanS" runat="server" ForeColor="#333333" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="2" Font-Names="Verdana" Font-Size="10pt">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intWithdrawConId" DataNavigateUrlFormatString="~/Contents/WithdrawalsPDE.aspx?intWithdrawConId={0}" DataTextField="AccDate" HeaderText="Acc Date">
<ItemStyle HorizontalAlign="Left" Width="160px"></ItemStyle>
</asp:HyperLinkField>
<asp:TemplateField HeaderText="Trn Date"><ItemTemplate>
<asp:TextBox id="txtTrnDate" runat="server" Width="81px" CssClass="datePicker" AutoPostBack="True" __designer:wfdid="w17" OnTextChanged="txtTrnDate_TextChanged" Height="21px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="84px" CssClass="txtNumeric" __designer:wfdid="w18" MaxLength="6" Height="21px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TreasuryId" Visible="False"><ItemTemplate>
<asp:Label id="lblTreasId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="WithConId" Visible="False"><ItemTemplate>
<asp:Label id="lblWithConId" runat="server" Text="Label" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD><TD style="WIDTH: 864px" vAlign=top colSpan=2><asp:GridView id="gdvChalanLB" runat="server" ForeColor="#333333" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="2" Font-Names="Verdana" Font-Size="10pt">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intBillWiseId" DataNavigateUrlFormatString="~/Contents/WithdrawalsPDEEmp.aspx?intBillWiseId={0}" DataTextField="intBillNo" HeaderText="Bill No.">
<ItemStyle Width="100px"></ItemStyle>
</asp:HyperLinkField>
<asp:TemplateField HeaderText="Bill Date"><ItemTemplate>
<asp:TextBox id="txtBDate" runat="server" Width="105px" CssClass="datePicker" __designer:wfdid="w19" Height="21px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="95px" CssClass="txtNumeric" __designer:wfdid="w20" MaxLength="6" Height="21px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted"><HeaderTemplate>
<asp:CheckBox id="Allchk" runat="server" Text="Unposted" AutoPostBack="True" OnCheckedChanged="Allchk_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" Width="1px" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted reason"><ItemTemplate>
<asp:DropDownList id="ddlReason" runat="server" width="86px"></asp:DropDownList> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD colSpan=2></TD><TD style="WIDTH: 855px" colSpan=2><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="48px" Text="Save"></asp:Button> </TD></TR></TBODY></TABLE>
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

