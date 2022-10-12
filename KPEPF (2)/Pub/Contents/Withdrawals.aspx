<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_Withdrawals, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel1" runat= "Server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 90%" class="TdMnHead">&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Width="90%" Text="Withdrawals_Treasury"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 128px" align=center><asp:Panel id="pnlEntry" runat="server" Width="90%" BorderColor="#ccd0e6" BorderWidth="1px" BorderStyle="Solid"><TABLE width="90%"><TBODY><TR><TD align=left><asp:Label id="Year" runat="server" Text="Year" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlYear" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList></TD><TD align=left><asp:Label id="Label3" runat="server" Text="District" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlDis" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlDis_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlMonth" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"></asp:DropDownList></TD><TD align=left><asp:Label id="Label4" runat="server" Text="District Tresury" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlTresury" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlTresury_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="lblInti" runat="server" CssClass="p1" text="Intimation Date"></asp:Label></TD><TD align=left><asp:TextBox id="txtInt" runat="server" Width="184px" CssClass="datePicker" AutoPostBack="True" MaxLength="10" OnTextChanged="txtInt_TextChanged"></asp:TextBox></TD><TD align=left><asp:Label id="lblAmt" runat="server" CssClass="p1" text="Amount"></asp:Label></TD><TD style="HEIGHT: 6px" align=left><asp:TextBox id="txtAmt" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="184px" CssClass="txtNumeric" MaxLength="8"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="lblRem" runat="server" CssClass="p1" text="Remarks"></asp:Label></TD><TD align=left colSpan=3><asp:TextBox id="txtRem" runat="server" Width="184px"></asp:TextBox><asp:Button id="btnEntry" onclick="btnEntry_Click" runat="server" Width="50px" Text="Ok" Height="19px"></asp:Button> &nbsp; &nbsp;&nbsp;<asp:Label id="lblTotA" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR><TD>&nbsp;</TD></TR><TR align=center><TD class="TdMnHead"><asp:Label id="lblChalancap" runat="server" Width="100%" Text="Withdrawals_Localbody" CssClass="MnHead"></asp:Label></TD></TR><TR align=center><TD><asp:GridView id="gdvWith" runat="server" Width="100%" ForeColor="#333333" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="2" ShowFooter="True" Font-Names="Verdana" Font-Size="10pt">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:BoundField DataField="chvBillNo" HeaderText="Bill No."></asp:BoundField>
<asp:BoundField DataField="dtBillDate" HeaderText="Bill Date"></asp:BoundField>
<asp:BoundField DataField="fltBillAmount" HeaderText="Bill Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Unposted"><ItemTemplate>
<asp:CheckBox id="chkApp1" runat="server" AutoPostBack="True" OnCheckedChanged="chkApp1_CheckedChanged" __designer:wfdid="w1"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted Reason"><ItemTemplate>
<asp:DropDownList id="ddlReason" runat="Server" Width="108px" AutoPostBack="True" __designer:wfdid="w2"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Bill Id"><ItemTemplate>
<asp:Label id="lblBillId" runat="server" Text="0" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Verify"><ItemTemplate>
<asp:CheckBox id="chkV" runat="server" Width="15px" Height="19px" AutoPostBack="True" __designer:wfdid="w2" OnCheckedChanged="chkV_CheckedChanged" Checked="True"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR align=center><TD><asp:Button id="btnLBSave" onclick="btnLBSave_Click" runat="server" Width="50px" Text="Save"></asp:Button> </TD></TR><TR align=center><TD style="WIDTH: 90%">&nbsp;</TD></TR><TR class="TdMnHead" align=center><TD style="WIDTH: 90%"><asp:Label id="lblChalancap2" runat="server" Text="Withdrawals_Others" CssClass="MnHead"></asp:Label></TD></TR><TR align=center><TD style="WIDTH: 90%"><asp:GridView id="gdvExtra" runat="server" Width="100%" ForeColor="#333333" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="2" ShowFooter="True" Font-Names="Verdana" Font-Size="10pt">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField HeaderText="Sl.No."></asp:BoundField>
<asp:TemplateField HeaderText="Bill No">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="150px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox id="txtExBillNo" onkeypress="return  isNumberKey(event)" runat="server" Width="48px" text='<%#Eval("chvBillNo") %>' CssClass="txtNumeric" MaxLength="8" __designer:wfdid="w1"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Date"><ItemTemplate>
<asp:TextBox id="txtExBillDt" runat="server" Width="84px" AutoPostBack="True" text='<%#Eval("dtBillDate") %>' CssClass="datePicker" OnTextChanged="txtExBillDt_TextChanged" __designer:wfdid="w2"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Amount"><ItemTemplate>
<asp:TextBox id="txtExAmount" onkeypress="return  isNumberKey(event)" runat="server" Width="70px" AutoPostBack="True" text='<%#Eval("fltBillAmount") %>' CssClass="txtNumeric" OnTextChanged="txtExAmount_TextChanged" MaxLength="8" __designer:wfdid="w3"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Institusion"><ItemTemplate>
<asp:DropDownList id="ddlInst" runat="server" Width="118px" AutoPostBack="True" __designer:wfdid="w4"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Type"><ItemTemplate>
<asp:DropDownList id="ddlBill" runat="server" Width="98px" OnSelectedIndexChanged="ddlBill_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w6"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted"><ItemTemplate>
<asp:CheckBox id="chkNonUnpost" runat="server" Width="1px" AutoPostBack="True" __designer:wfdid="w7" OnCheckedChanged="chkNonUnpost_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnpostedReason"><ItemTemplate>
<asp:DropDownList id="ddlReson" runat="server" Width="98px" AutoPostBack="True" __designer:wfdid="w8"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Bill Id"><ItemTemplate>
<asp:Label id="lblBillIdO" text='<%#Eval("numBillID") %>' runat="server" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField HeaderText="Details" Text="Details" DataNavigateUrlFormatString="~/Contents/WithdrawalsEmpCurr.aspx?numBillID={0}&amp;fltBillAmount={1}" DataNavigateUrlFields="numBillID,fltBillAmount"></asp:HyperLinkField>
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
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align=center><asp:Button id="btnNonLBSave" onclick="btnNonLBSave_Click" runat="server" Width="50px" Text="Save"></asp:Button> <asp:Button id="btnTreasRpt" onclick="btnTreasRpt_Click" runat="server" Width="132px" Text="Treasury Statement"></asp:Button> </TD></TR></TBODY></TABLE>
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
                yearRange: "-56:+0",
      });
              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
});
</script>--%>
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
	 <script type="text/javascript">
function DeleteItem() {
            if (confirm("Are you sure you want to delete ...?")) {
                return true;
            }
            return false;
        }
 </script>
</asp:Content>

