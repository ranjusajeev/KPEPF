<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_WithdrawalsEmpCurr, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=5>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Withdrawals_Treasury"></asp:Label> </TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD align=center>&nbsp;<asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label> </TD><TD align=center>&nbsp;<asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label> </TD><TD align=center>&nbsp;<asp:Label id="lblDT" runat="server" Text="..." CssClass="p4"></asp:Label> </TD>

<%--<TD align=center>&nbsp;<asp:Label id="lblBillNo" runat="server" Text="..." CssClass="p4"></asp:Label> </TD><TD align=center>&nbsp;<asp:Label id="lblBillDt" runat="server" Width="38px" ForeColor="#0000C0" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4">
</asp:Label> 
</TD>--%>
<TD align=center><asp:Panel id="pnlMain" runat="server"><TABLE><TBODY><TR><TD align=left><asp:Label id="lbl11" runat="server" Text="Total bill amount" Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD>
<TD align=right><asp:Label id="lblTot" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label>
 </TD></TR><TR><TD align=left><asp:Label id="lblTotET" runat="server" Text="Bill amount Entered " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;</TD>
 <TD align=right><asp:Label id="lblTotE" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label>
  </TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>
   &nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblBal" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label> 
   </TD>
   </TR>
   </TBODY>
   </TABLE></asp:Panel>
    </TD>
</TR>

<TR><TD style="HEIGHT: 188px" vAlign=top colSpan=5><asp:GridView id="gdvChalanS" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl.No">
<ItemStyle Width="9%"></ItemStyle>

<HeaderStyle Width="9%" CssClass="cssHeadGridEng"></HeaderStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Acc No."><ItemTemplate>
<asp:TextBox id="txtAccNo" text='<%#Eval("chvPF_No") %>' runat="server" Width="76px" OnTextChanged="txtAccNo_TextChanged1" AutoPostBack="True" CssClass="txtNumeric" MaxLength="10"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:Label id="lblName" text='<%#Eval("chvName") %>' runat="server" Width="140px" ></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnIdentified" Visible="False"><ItemTemplate>
<asp:CheckBox id="chkUnIdent" runat="server" Width="22px"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" text='<%#Eval("fltAllottedAmt") %>' runat="server" Width="71px" OnTextChanged="txtAmt_TextChanged" AutoPostBack="True" CssClass="txtNumeric" MaxLength="6"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Type"><ItemTemplate>
<asp:DropDownList id="ddlType" runat="server"></asp:DropDownList>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sanction Date" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox text='<%#Eval("dtmDateOfSanction") %>' id="txtSDate" runat="server" Width="67px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Withdraw Date"><ItemTemplate>
<asp:TextBox id="txtWDate" text='<%#Eval("dtmDateOfSanction") %>' runat="server" Width="81px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Acc No" Visible="False"><ItemTemplate>
<asp:Label id="lblNewAcc" text='<%#Eval("numEmpId") %>' runat="server" ></asp:Label>
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
<asp:TemplateField HeaderText="WithdrawId"><ItemTemplate>
<asp:Label id="lblWithId" text='<%#Eval("numWithdrawalID") %>' runat="server" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="PfoWithdrawId" Visible="False"><ItemTemplate>
<asp:Label id="lblWithIdPfo" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPosted"><ItemTemplate>
<asp:CheckBox id="chkUnP" runat="server" Width="51px"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPosted Reason"><ItemTemplate>
<asp:DropDownList id="ddlUnP" runat="server"></asp:DropDownList>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EditMode" Visible="False"><ItemTemplate>
<asp:Label id="lblEditMode" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add">
<ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="15%" CssClass="cssHeadGridEng" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btnAddFloorNew" onclick="btnAddFloorNew_Click" runat="server"  ImageUrl="~/images/addrow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
<ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="15%" CssClass="cssHeadGridEng" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btndeleteCr" onclick="btnDeleteCr_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD align=left colSpan=2><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Withdrawals" Height="23px"></asp:LinkButton></TD><TD style="WIDTH: 855px" colSpan=2><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="48px" Text="Save"></asp:Button> </TD></TR></TBODY></TABLE>
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


