<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_WithdrawalPDEAG, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
  <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=5>&nbsp; <asp:Label id="lblHead" runat="server" class="MnHead" Text="Withdrawals_AG" ></asp:Label> </TD></TR><TR><TD align=center>&nbsp; <asp:Label id="lblAmt" runat="server" ForeColor="#0000C0" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD><TD align=center>&nbsp; <asp:TextBox id="txtDate" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 188px" vAlign=top colSpan=5><asp:GridView id="gdvWithAG" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:TemplateField HeaderText="Acc No."><ItemTemplate>
<asp:TextBox id="txtAccNo" runat="server" Width="76px" __designer:wfdid="w55" MaxLength="10" CssClass="txtNumeric" AutoPostBack="True" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txtName" runat="server" Width="76px" __designer:wfdid="w56" MaxLength="10" CssClass="txtNumeric" AutoPostBack="True" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Designation"><ItemTemplate>
<asp:DropDownList id="ddldesig" runat="server" Width="71px" __designer:wfdid="w57"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="WithdrawalType"><ItemTemplate>
<asp:DropDownList id="ddlType" runat="server" Width="71px" __designer:wfdid="w58"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OrderNo"><ItemTemplate>
<asp:TextBox id="txtOrderNo" runat="server" Width="76px" __designer:wfdid="w59" MaxLength="10" CssClass="txtNumeric" AutoPostBack="True" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OrderDate" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox id="txtOrderDate" runat="server" Width="67px" __designer:wfdid="w60"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" runat="server" Width="71px" __designer:wfdid="w61" MaxLength="6" CssClass="txtNumeric"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Object of advance"><ItemTemplate>
<asp:DropDownList id="ddlpurpose" runat="server" Width="71px" __designer:wfdid="w62"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OrderNo&amp;Date of Prev TA"><ItemTemplate>
&nbsp;<asp:TextBox id="txtOrderNoDate" runat="server" Width="71px" __designer:wfdid="w63"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amt of Prev TA"><ItemTemplate>
<asp:TextBox id="txtAmtPreTa" runat="server" Width="81px" __designer:wfdid="w64"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Balance of prev TA" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox id="txtBalTA" runat="server" Width="71px" __designer:wfdid="w65"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Consolidated Amt" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox id="txtConsolidated" runat="server" Width="71px" __designer:wfdid="w66"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="No. of instalment" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox id="txtInstNo" runat="server" Width="71px" __designer:wfdid="w67"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amt of instalment" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox id="instAmt" runat="server" Width="71px" __designer:wfdid="w68"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPosted"><ItemTemplate>
<asp:CheckBox id="chkUnP" runat="server" Width="51px" __designer:wfdid="w69"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPosted Reason"><ItemTemplate>
<asp:DropDownList id="ddlUnP" runat="server" __designer:wfdid="w70"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox id="txtRemarks" runat="server" Width="71px" __designer:wfdid="w71"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlStatus" runat="server" Width="71px" __designer:wfdid="w72"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo" Visible="False"><ItemTemplate>
<asp:TextBox id="AccNo" runat="server" Width="71px" __designer:wfdid="w73" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnpostedReasonId" Visible="False"><ItemTemplate>
<asp:TextBox id="UnpostedReasonId" runat="server" Width="71px" __designer:wfdid="w74" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="WithTypeId" Visible="False"><ItemTemplate>
<asp:TextBox id="TypeId" runat="server" Width="71px" __designer:wfdid="w75" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="VoucherId" Visible="False"><ItemTemplate>
<asp:TextBox id="VoucherId" runat="server" Width="71px" __designer:wfdid="w76" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="WithId PDE" Visible="False"><ItemTemplate>
<asp:TextBox id="WithIDPDE" runat="server" Width="71px" __designer:wfdid="w77" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DEsigId" Visible="False"><ItemTemplate>
<asp:TextBox id="desigId" runat="server" Width="71px" __designer:wfdid="w78" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OldAmt" Visible="False"><ItemTemplate>
<asp:TextBox id="OldAmt" runat="server" Width="71px" __designer:wfdid="w79" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OldAccNo" Visible="False"><ItemTemplate>
<asp:TextBox id="OldAccNo" runat="server" Width="71px" __designer:wfdid="w80" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD align=left colSpan=2><asp:LinkButton id="btnBack" onclick="btnBack_Click" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Withdrawals" Height="23px"></asp:LinkButton></TD><TD style="WIDTH: 855px" colSpan=2><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="48px" Text="Save"></asp:Button> </TD></TR></TBODY></TABLE>
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



