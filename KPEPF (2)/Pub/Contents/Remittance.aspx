<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_Remittance, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
  <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 90%" class="TdMnHead">&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Remittance_Treasury"></asp:Label> </TD></TR><TR><TD align=center><asp:Panel id="pnlEntry" runat="server" Width="90%" BorderWidth="1px" BorderStyle="Solid" BorderColor="#ccd0e6"><TABLE width="90%"><TBODY><TR><TD align=left><asp:Label id="Year" runat="server" Text="Year" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlYear" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList></TD><TD align=left><asp:Label id="Label3" runat="server" Text="District" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddldist" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddldist_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlMnth" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlMnth_SelectedIndexChanged"></asp:DropDownList></TD><TD align=left><asp:Label id="Label4" runat="server" Text="District Tresury" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlDT" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlDT_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="lblInti" runat="server" text="Intimation Date" CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtInt" runat="server" Width="184px" AutoPostBack="True" MaxLength="10" CssClass="datePicker" OnTextChanged="txtInt_TextChanged"></asp:TextBox></TD><TD align=left><asp:Label id="lblAmt" runat="server" text="Amount" CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtAmt" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="184px" MaxLength="8" CssClass="txtNumeric"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="lblRem" runat="server" text="Remarks" CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtRem" runat="server" Width="184px"></asp:TextBox><asp:Button id="btnEntry" onclick="btnEntry_Click" runat="server" Width="50px" Text="Ok" Height="19px"></asp:Button></TD></TR></TBODY></TABLE></asp:Panel></TD></TR>
<tr><td>&nbsp;</td></tr>
<TR><TD style="HEIGHT: 16px" align=center class="TdMnHead"><asp:Label id="lblChalancap" runat="server" Width="90%" Text="Remittance_Localbody" CssClass="MnHead"></asp:Label></TD></TR><TR align="center"><TD><asp:GridView id="gdvchRem" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No.">
<ItemStyle Width="50px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Sub Treasury"></asp:BoundField>
<asp:HyperLinkField HeaderText="Chalan  details" DataTextField="ChNodtChalanDate" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;fltChalanAmt={1}" DataNavigateUrlFields="numChalanId,fltChalanAmt"></asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Chalan Amount"></asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="LocalBody"></asp:BoundField>
<asp:TemplateField HeaderText="Unposted">
<ItemStyle Width="70px"></ItemStyle>
<ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged" __designer:wfdid="w4" Checked="True"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted reason">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="50px" Font-Size="Small" Font-Names="Verdana"></HeaderStyle>
<ItemTemplate>
<asp:DropDownList id="ddlReason" runat="server" __designer:wfdid="w4" width="98px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="ChalanId"><ItemTemplate>
<asp:Label id="lblChalId" runat="server" Text="Label" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Verify"><ItemTemplate>
<asp:CheckBox id="chkV" runat="server" Width="15px" Height="19px" AutoPostBack="True" OnCheckedChanged="chkV_CheckedChanged" __designer:wfdid="w5"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD align=center><asp:Button id="btnLBSave" onclick="btnLBSave_Click" runat="server" Width="50px" Text="Save"></asp:Button> </TD></TR><TR><TD align=center>&nbsp;</TD></TR><TR><TD style="HEIGHT: 16px" class="TdMnHead" align=center><asp:Label id="lblChalancap2" runat="server" Width="90%" Text="Remittance_Others" CssClass="MnHead"></asp:Label></TD></TR><TR><TD  align="center"><asp:GridView id="gdvchNonLB" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField HeaderText="Sl.No."></asp:BoundField>
<asp:TemplateField HeaderText="Sub Treasury"><ItemTemplate>
<asp:DropDownList id="ddlSubTre" runat="server" AutoPostBack="True" __designer:wfdid="w4"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan  No">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
<ItemTemplate>
<asp:TextBox id="txtNonLBChNo" text='<%#Eval("intChalanNo") %>' onkeypress="return  isNumberKey(event)" runat="server" Width="40px" CssClass="txtNumeric" MaxLength="4"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Date"><ItemTemplate>
<asp:TextBox id="txtNonChDate" text='<%#Eval("dtChalanDate") %>' runat="server" Width="75px" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtNonChDate_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Amount"><ItemTemplate>
<asp:TextBox id="txtNonLBAmount" text='<%#Eval("fltChalanAmt") %>'  onkeypress="return  isNumberKey(event)" runat="server" Width="66px" AutoPostBack="True" CssClass="txtNumeric" OnTextChanged="txtNonLBAmount_TextChanged" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Institusion"><ItemTemplate>
<asp:DropDownList id="ddlInst" runat="server" OnSelectedIndexChanged="ddlInst_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> <asp:TextBox id="txtNonLBInstit" runat="server" Visible="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Type"><ItemTemplate>
<asp:DropDownList id="ddlChalan" runat="server" OnSelectedIndexChanged="ddlChalan_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Unposted"><ItemTemplate>
<asp:CheckBox id="chkNonUnpost"   runat="server" Width="50px" AutoPostBack="True" OnCheckedChanged="chkNonUnpost_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="UnpostedReson"><ItemTemplate>
<asp:DropDownList id="ddlReson" runat="server" AutoPostBack="True"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField HeaderText="Schedule details" Text="schedule" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;flgChalanType={1}&amp;fltChalanAmt={2}" DataNavigateUrlFields="numChalanId,flgChalanType,fltChalanAmt"></asp:HyperLinkField>
<asp:TemplateField HeaderText="Add">
<ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="15%" CssClass="cssHeadGridEng" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btnAddFloorNew" onclick="btnAddFloorNew_Click" runat="server" ImageUrl="~/images/addrow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
<ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="15%" CssClass="cssHeadGridEng" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="chlId"><ItemTemplate>
<%--<asp:TextBox id="txtchlId" runat="server" Width="40px" text='<%#Eval("numChalanId") %>' ></asp:TextBox> --%>
<asp:Label id="txtchlId" runat="server" Text="0"></asp:Label>

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
    <script language="javascript" type="text/javascript">
//Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()

//{
$(".datePicker").datepicker 
          ({
                numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "-56:+0",
      });
              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
};
</script>
<script language="javascript" type="text/javascript">
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

