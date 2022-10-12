<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_WithdrawalsPDEEmp, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
  <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR style="WIDTH: 90%"><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Withdrawals_Treasury"></asp:Label> </TD></TR>
<TR><TD  >&nbsp;</TD></TR> 
<TR align="center"><TD colSpan="2"><asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp;&nbsp; &nbsp;<asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:Label id="lblDT" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR>
<TR><TD  >&nbsp;</TD></TR> 

<TR align="center"><TD colspan="3"><asp:Label id="lblBillNo" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblBillDt" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblBAmt" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR> 

<TR align="center"><TD   vAlign=top colSpan=3><asp:GridView id="gdvChalanS" runat="server" ForeColor="#333333" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" Font-Names="Verdana" Font-Size="10pt">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:TemplateField HeaderText="Acc No."><ItemTemplate>
<asp:TextBox id="txtAccNo" runat="server" Width="122px" CssClass="txtNumeric" Height="22px" MaxLength="10" AutoPostBack="True" OnTextChanged="txtAccNo_TextChanged1" __designer:wfdid="w10"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:Label id="lblName" runat="server" Width="187px" Text="Label" Height="24px" __designer:wfdid="w6"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnIdentified"><ItemTemplate>
<asp:CheckBox id="chkUnIdent" runat="server" Width="22px"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" oncopy="reaturn false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="96px" CssClass="txtNumeric" Height="22px" MaxLength="5" AutoPostBack="True" OnTextChanged="txtAmt_TextChanged" __designer:wfdid="w12"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Type"><ItemTemplate>
<asp:DropDownList id="ddlType" runat="server" Width="100px" __designer:wfdid="w13"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sanction Date" Visible="False"><ItemTemplate>
<asp:TextBox id="txtSDate" runat="server" Width="105px" CssClass="datePicker" Height="21px" AutoPostBack="True" OnTextChanged="txtSDate_TextChanged" __designer:wfdid="w14"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Withdraw Date"><ItemTemplate>
<asp:TextBox id="txtWDate" runat="server" Width="116px" CssClass="datePicker" Height="21px" MaxLength="10" __designer:wfdid="w15"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Acc No" Visible="False"><ItemTemplate>
<asp:Label id="lblNewAcc" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Old Acc" Visible="False"><ItemTemplate>
<asp:Label id="lblOldAcc" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Old Amt" Visible="False"><ItemTemplate>
<asp:Label id="lblOldAmt" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="WithdrawId" Visible="False"><ItemTemplate>
<asp:Label id="lblWithId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="PfoWithdrawId" Visible="False"><ItemTemplate>
<asp:Label id="lblWithIdPfo" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPosted" Visible="False"><ItemTemplate>
<asp:CheckBox id="chkUnP" runat="server" Width="51px"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPosted Reason" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlUnP" runat="server"></asp:DropDownList>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EditMode" Visible="False"><ItemTemplate>
<asp:Label id="lblEditMode" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR align="center"><TD> <asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Withdrawals" Height="23px"></asp:LinkButton></TD><TD  ><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="48px" Text="Save"></asp:Button> </TD></TR></TBODY></TABLE>
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

