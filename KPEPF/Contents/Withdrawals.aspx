<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="Withdrawals.aspx.cs" Inherits="Contents_Withdrawals" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel1" runat= "Server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead">&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Withdrawals_Treasury"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 128px" align=center><asp:Panel id="pnlEntry" runat="server" Width="90%" BorderColor="#ccd0e6" BorderWidth="1px" BorderStyle="Solid"><TABLE width="100%"><TBODY><TR><TD align=left><asp:Label id="Year" runat="server" Text="Year" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" width="150px" AutoPostBack="True"></asp:DropDownList></TD><TD align=left><asp:Label id="Label3" runat="server" Text="District" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlDis" runat="server" OnSelectedIndexChanged="ddlDis_SelectedIndexChanged" width="150px" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlMonth" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" width="150px" AutoPostBack="True"></asp:DropDownList></TD><TD align=left><asp:Label id="Label4" runat="server" Text="District Treasury" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlTresury" runat="server" OnSelectedIndexChanged="ddlTresury_SelectedIndexChanged" width="150px" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="lblInti" runat="server" CssClass="p1" text="Intimation Date"></asp:Label></TD><TD align=left><asp:TextBox id="txtInt" runat="server" CssClass="datePicker" AutoPostBack="True" MaxLength="10" OnTextChanged="txtInt_TextChanged"></asp:TextBox></TD><TD align=left><asp:Label id="lblAmt" runat="server" CssClass="p1" text="Amount"></asp:Label></TD><TD align=left><asp:TextBox id="txtAmt" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="146px" CssClass="txtNumeric" MaxLength="8"></asp:TextBox></TD></TR><%--<TR><TD align=left><asp:Label id="lblRem" runat="server" CssClass="p1" text="Remarks"></asp:Label></TD>
<TD align=left colSpan=3><asp:TextBox id="txtRem" runat="server"></asp:TextBox>

<asp:Button id="btnEntry" onclick="btnEntry_Click" runat="server" Width="50px" Text="Ok" Height="19px"></asp:Button> &nbsp; &nbsp;&nbsp;
<asp:Label id="lblTotA" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR>--%><TR><TD align=left><asp:Label id="lblRem" runat="server" CssClass="p1" text="Remarks"></asp:Label></TD><TD align=left><asp:TextBox id="txtRem" runat="server" Width="184px"></asp:TextBox></TD><TD colSpan=2><asp:CheckBox id="chkVerified" runat="server" Text="Verified" CssClass="p1" Checked="False"></asp:CheckBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button id="btnEntry" onclick="btnEntry_Click" runat="server" Width="50px" Text="Ok" Height="19px"></asp:Button> &nbsp; &nbsp;&nbsp; <asp:Label id="lblTotA" runat="server" Width="71px" Text="..." CssClass="p4"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD align=center><asp:Label id="lblChalancap" runat="server" Width="900px" ForeColor="Navy" Font-Bold="True" Text="Withdrawals_Localbody" Font-Size="10pt" Font-Names="Verdana" BackColor="#CCD0E6"></asp:Label> </TD></TR><TR><TD align=center><DIV style="OVERFLOW-X: auto; WIDTH: 800px"><asp:GridView id="gdvWith" runat="server" Width="700px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="2" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<%--<asp:BoundField DataField="dtBillDate" HeaderText="Bill Date">
<ItemStyle Width="140px"></ItemStyle>
</asp:BoundField>--%>
<asp:HyperLinkField HeaderText="Bill Date" DataTextField="dtBillDate" DataNavigateUrlFormatString="~/Contents/WithdrawalsEmpCurr.aspx?numBillID={0}&amp;fltBillAmount={1}" DataNavigateUrlFields="numBillID,fltBillAmount">
<ItemStyle Width="160px" HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>

<asp:BoundField DataField="fltBillAmount" HeaderText="Bill Amount">
<ItemStyle HorizontalAlign="Right" Width="140px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Unposted"><ItemTemplate>
<asp:CheckBox id="chkApp1" runat="server" AutoPostBack="True" OnCheckedChanged="chkApp1_CheckedChanged" __designer:wfdid="w1"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted Reason"><ItemTemplate>
<asp:DropDownList id="ddlReason" runat="Server" AutoPostBack="True" Width="140px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Verify">
<HeaderTemplate>
<asp:CheckBox id="Allchk" runat="server" Text="Verify" AutoPostBack="True" OnCheckedChanged="Allchk_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkV" runat="server" Width="15px" Height="19px" AutoPostBack="True" OnCheckedChanged="chkV_CheckedChanged"></asp:CheckBox> 

</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Id" Visible="False"><ItemTemplate>
<asp:Label id="lblBillId" runat="server" Text="0" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD align=center>&nbsp;</TD></TR><TR><TD align=center>&nbsp;</TD></TR><TR><TD style="HEIGHT: 16px" align=center><asp:Label id="lblChalancap2" runat="server" Width="900px" ForeColor="Navy" Font-Bold="True" Text="Withdrawals_Others" Font-Size="10pt" Font-Names="Verdana" BackColor="#CCD0E6"></asp:Label></TD></TR><TR><TD align=center><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvExtra" runat="server" Width="900px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="2" ShowFooter="True" OnSelectedIndexChanged="gdvExtra_SelectedIndexChanged">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField HeaderText="Sl.No."></asp:BoundField>
<asp:TemplateField HeaderText="Bill No"><ItemTemplate>
<asp:TextBox id="txtExBillNo" onkeypress="return  isNumberKey(event)" runat="server" Width="150px" CssClass="txtNumeric" text='<%#Eval("chvBillNo") %>' MaxLength="8" __designer:wfdid="w1"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle Width="150px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Date"><ItemTemplate>
<asp:TextBox id="txtExBillDt" 
text='<%#Eval("dtBillDate") %>' runat="server" Width="150px" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtExBillDt_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Amount"><ItemTemplate>
<asp:TextBox id="txtExAmount" text='<%#Eval("fltBillAmount") %>'  onkeypress="return  isNumberKey(event)" runat="server" Width="150px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="8" OnTextChanged="txtExAmount_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Institusion" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlInst" runat="server" Width="150px" AutoPostBack="True"></asp:DropDownList> <asp:TextBox id="txtNonLBInstit" runat="server" Visible="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Type" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlBill" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlBill_SelectedIndexChanged"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted" Visible="False"><ItemTemplate>
<asp:CheckBox id="chkNonUnpost" runat="server" Width="50px" AutoPostBack="True" OnCheckedChanged="chkNonUnpost_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnpostedReason" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlReson" runat="server" Width="150px" AutoPostBack="True"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemarks" runat="server" Width="133px" __designer:wfdid="w2"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Id" Visible="False"><ItemTemplate>
<asp:Label id="lblBillIdO" text='<%#Eval("numBillID") %>' runat="server" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
<asp:ImageButton id="btnAddFloorNew" onclick="btnAddFloorNew_Click" runat="server"  ImageUrl="~/images/addrow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></DIV></TD></TR><TR><TD align=center><asp:Button id="btnNonLBSave" onclick="btnNonLBSave_Click" runat="server" Width="50px" Text="Save"></asp:Button> <asp:Button id="btnTreasRpt" onclick="btnTreasRpt_Click" runat="server" Width="132px" Text="Treasury Statement"></asp:Button> </TD></TR></TBODY></TABLE>
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
<%--<script language=javascript type="text/javascript">
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
--%></asp:Content>

