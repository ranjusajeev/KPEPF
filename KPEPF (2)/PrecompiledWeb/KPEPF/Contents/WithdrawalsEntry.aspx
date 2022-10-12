<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_WithdrawalsEntry, App_Web_4p3ju0t2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel1" runat= "Server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead">&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Withdrawals_Treasury"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 128px" align=center><asp:Panel id="pnlEntry" runat="server" Width="90%" BorderStyle="Solid" BorderWidth="1px" BorderColor="#ccd0e6"><TABLE width="100%"><TBODY><TR><TD align=left><asp:Label id="Year" runat="server" Text="Year" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True" width="150px"></asp:DropDownList></TD><TD align=left><asp:Label id="Label3" runat="server" Text="District" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlDis" runat="server" OnSelectedIndexChanged="ddlDis_SelectedIndexChanged" AutoPostBack="True" width="150px"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlMonth" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="True" width="150px"></asp:DropDownList></TD><TD align=left><asp:Label id="Label4" runat="server" Text="District Treasury" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlTresury" runat="server" OnSelectedIndexChanged="ddlTresury_SelectedIndexChanged" AutoPostBack="True" width="150px"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="lblInti" runat="server" CssClass="p1" text="Intimation Date"></asp:Label></TD><TD align=left>
    <asp:TextBox id="txtInt" runat="server" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtInt_TextChanged" MaxLength="10" Width="147px"></asp:TextBox></TD><TD align=left><asp:Label id="lblAmt" runat="server" CssClass="p1" text="Amount"></asp:Label></TD><TD align=left>
    <asp:TextBox id="txtAmt" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="146px" CssClass="txtNumeric" MaxLength="8" Text="0" ></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="lblRem" runat="server" CssClass="p1" text="Remarks"></asp:Label></TD><TD align=left><asp:TextBox id="txtRem" runat="server" Width="147px"></asp:TextBox></TD><TD colSpan=2>
    <asp:CheckBox id="chkVerified" runat="server" Text="Verified" CssClass="p1" Checked="False" OnCheckedChanged="chkVerified_CheckedChanged"></asp:CheckBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button id="btnEntry" onclick="btnEntry_Click" runat="server" Width="50px" Text="Ok" Height="19px"></asp:Button> &nbsp; &nbsp;&nbsp; <asp:Label id="lblTotA" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp; &nbsp;&nbsp; <asp:Label id="lblmm" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD align=center><asp:Label id="lblChalancap" runat="server" Width="900px" ForeColor="Navy" Font-Bold="True" Text="Withdrawals_Localbody" BackColor="#CCD0E6" Font-Names="Verdana" Font-Size="10pt" Visible="False"></asp:Label> </TD></TR><TR><TD align=center><DIV style="OVERFLOW-X: auto; WIDTH: 800px">
    <asp:GridView id="gdvWith" runat="server" Width="700px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellSpacing="2" AutoGenerateColumns="False" GridLines="None" CellPadding="2" Visible="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<%--<asp:HyperLinkField DataNavigateUrlFields="numBillID,fltBillAmount,flgBillType" DataNavigateUrlFormatString="~/Contents/WithdrawalsEmpCurr.aspx?numBillID={0}&amp;fltBillAmount={1}&amp;flgBillType={2}" DataTextField="dtBillDate" HeaderText="Bill Date">
<ItemStyle HorizontalAlign="Left" Width="160px"></ItemStyle>
</asp:HyperLinkField>--%>


    <asp:HyperLinkField DataNavigateUrlFields="numBillID,fltBillAmount,flgBillType,intTreasuryId" DataNavigateUrlFormatString="~/Contents/WithdrawalsEmpCurr.aspx?numBillID={0}&amp;fltBillAmount={1}&amp;flgBillType={2}&amp;intTreasuryId={3}" DataTextField="dtBillDate" HeaderText="Bill Date">
<ItemStyle HorizontalAlign="Left" Width="160px"></ItemStyle>
</asp:HyperLinkField>

<asp:BoundField DataField="fltBillAmount" HeaderText="Bill Amount">
<ItemStyle HorizontalAlign="Right" Width="140px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Unposted"><ItemTemplate>
<asp:CheckBox id="chkApp1" runat="server" AutoPostBack="True" OnCheckedChanged="chkApp1_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted Reason"><ItemTemplate>
<asp:DropDownList id="ddlReason" runat="Server" Width="140px" OnSelectedIndexChanged="ddlReason_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Verify"><HeaderTemplate>
<asp:CheckBox id="Allchk" runat="server" Text="Verify" AutoPostBack="True" Enable="false"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkV" runat="server" Width="15px" Height="19px" AutoPostBack="True" OnCheckedChanged="chkV_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Id" Visible="False"><ItemTemplate>
<asp:Label id="lblBillId" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPRO" Visible="False"><ItemTemplate>
<asp:Label id="lblUnPRO" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="VerfyO" Visible="False"><ItemTemplate>
<asp:Label id="lblVrfO" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPR" Visible="False"><ItemTemplate>
<asp:Label id="lblUnPR" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Verfy" Visible="False"><ItemTemplate>
<asp:Label id="lblVrf" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="editMd" Visible="False"><ItemTemplate>
<asp:Label id="lblMd" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD align=center>&nbsp;</TD></TR><TR><TD align=center>&nbsp;</TD></TR><TR><TD style="HEIGHT: 16px" align=center><asp:Label id="lblChalancap2" runat="server" Width="900px" ForeColor="Navy" Font-Bold="True" Text="Withdrawals_Others" BackColor="#CCD0E6" Font-Names="Verdana" Font-Size="10pt"></asp:Label></TD></TR><TR><TD align=center><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvExtra" runat="server" Width="900px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellSpacing="2" AutoGenerateColumns="False" GridLines="None" CellPadding="2" OnSelectedIndexChanged="gdvExtra_SelectedIndexChanged">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl. No."><ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill No"><ItemTemplate>
<asp:TextBox id="txtExBillNo" onkeypress="return  isNumberKey(event)" runat="server" Width="56px" AutoPostBack="True" OnTextChanged="txtExBillNo_TextChanged" CssClass="txtNumeric" text='<%#Eval("chvBillNo") %>' MaxLength="8"></asp:TextBox> 
    </ItemTemplate>

<HeaderStyle Width="150px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Date"><ItemTemplate>
<asp:TextBox id="txtExBillDt" runat="server" Width="80px" CssClass="datePicker" MaxLength="10" AutoPostBack="True" text='<%#Eval("dtBillDate") %>' OnTextChanged="txtExBillDt_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Amount"><ItemTemplate>
<asp:TextBox id="txtExAmount" onkeypress="return  isNumberKey(event)" runat="server" Width="84px" CssClass="txtNumeric" AutoPostBack="True" text='<%#Eval("fltBillAmount") %>' OnTextChanged="txtExAmount_TextChanged" MaxLength="8"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Bill Type"><ItemTemplate>
<asp:DropDownList id="ddlBill" runat="server" Width="122px" OnSelectedIndexChanged="ddlBill_SelectedIndexChanged" AutoPostBack="True" MaxLength="10"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Un posted"><ItemTemplate>
<asp:CheckBox id="chkNonUnpost" runat="server" Width="50px" AutoPostBack="True" OnCheckedChanged="chkNonUnpost_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnpostedReason"><ItemTemplate>
<asp:DropDownList id="ddlReson" runat="server" Width="106px" OnSelectedIndexChanged="ddlReson_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRemarks" runat="server" Width="133px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField DataNavigateUrlFields="numBillID,fltBillAmount,flgBillType,intTreasuryId" DataNavigateUrlFormatString="~/Contents/WithdrawalsEmpCurr.aspx?numBillID={0}&amp;fltBillAmount={1}&amp;flgBillType={2}&amp;intTreasuryId={3}" Text="Bill" HeaderText="Details"></asp:HyperLinkField>
<asp:TemplateField HeaderText="Bill Id" Visible="False"><ItemTemplate>
<asp:Label id="lblBillIdO" text='<%# Eval("numBillID") %>' runat="server"></asp:Label>
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
<asp:TemplateField HeaderText="BillNo" Visible="False"><ItemTemplate>
<asp:Label id="lblSlNo" text='<%#Eval("intBillNo") %>' runat="server" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPRO" Visible="False"><ItemTemplate>
<asp:Label id="lblUnPRO1" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPR" Visible="False"><ItemTemplate>
<asp:Label id="lblUnPR1" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="noO" Visible="False"><ItemTemplate>
<asp:Label id="lblnoO" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="amtO" Visible="False"><ItemTemplate>
<asp:Label id="lblamtO" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="dtO" Visible="False"><ItemTemplate>
<asp:Label id="lbldtO" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Tp" Visible="False"><ItemTemplate>
<asp:Label id="lbltp" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="editMd" Visible="False"><ItemTemplate>
<asp:Label id="lblMd1" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></DIV></TD></TR><TR><TD align=center><asp:Button id="btnNonLBSave" onclick="btnNonLBSave_Click" runat="server" Width="100px" Text="Save" Height="20px"></asp:Button> <asp:Button id="btnTreasRpt" onclick="btnTreasRpt_Click" runat="server" Width="132px" Text="Treasury Statement" Height="20px"></asp:Button> </TD></TR></TBODY></TABLE>
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
   function changeColour(elementId) 
   {
        var interval = 1000;
        var colour1 = "#ff0000"
        var colour2 = "#000000";
        if (document.getElementById) 
        {
            var element = document.getElementById(elementId);
            element.style.color = (element.style.color == colour1) ? colour2 : colour1;
            setTimeout("changeColour('" + elementId + "')", interval);
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

