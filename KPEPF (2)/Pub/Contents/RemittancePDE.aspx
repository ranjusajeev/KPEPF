<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_RemittancePDE, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
  <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Remittance_Treasury"></asp:Label> </TD></TR><TR><TD style="align: left"><asp:Label id="Year" runat="server" Text="Year" CssClass="p1"></asp:Label></TD><TD style="align: left"><asp:DropDownList id="ddlYear" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList></TD><TD style="align: left"><asp:Label id="Label3" runat="server" Text="District" CssClass="p1"></asp:Label></TD><TD style="align: left"><asp:DropDownList id="ddldist" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddldist_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR align=left><TD style="align: left"><asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label></TD><TD style="align: left"><asp:DropDownList id="ddlMnth" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlMnth_SelectedIndexChanged"></asp:DropDownList></TD><TD style="align: left"><asp:Label id="Label4" runat="server" Text="District Tresury" CssClass="p1"></asp:Label></TD><TD style="align: left"><asp:DropDownList id="ddlDT" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlDT_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR align=left><TD style="HEIGHT: 22px; align: left"><asp:Label id="lblInti" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Verdana" text="Intimation Date" Font-Strikeout="False" Font-Italic="False"></asp:Label></TD><TD style="HEIGHT: 22px; align: left"><asp:TextBox id="txtInt" runat="server" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtInt_TextChanged" width="150px"></asp:TextBox></TD><TD style="HEIGHT: 22px; align: left"><asp:Label id="lblAmt" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Verdana" text="Amount"></asp:Label></TD><TD style="HEIGHT: 22px; align: left"><asp:TextBox id="txtAmt" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="150px" CssClass="txtNumeric" MaxLength="8"></asp:TextBox></TD></TR><TR align=left><TD style="WIDTH: 140px" align=left><asp:Label id="lblRem" runat="server" ForeColor="#0000C0" Font-Size="10pt" Font-Names="Verdana" text="Remarks"></asp:Label></TD><TD style="align: left"><asp:TextBox id="txtRem" runat="server" Width="150px"></asp:TextBox></TD></TR><%--<TR> <TD align=center colSpan=4>&nbsp;<asp:Label id="lblSTDet" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR>
--%><TR><TD>&nbsp;</TD></TR><TR><TD align=left colSpan=2><asp:Label id="lbl1" runat="server" Text="Sub Treasury wise Details" CssClass="p1"></asp:Label></TD><TD align=left colSpan=2>&nbsp;<asp:Label id="lbl2" runat="server" Text="Chalan Details" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblSTDet" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR><TD vAlign=top colSpan=2><asp:GridView id="gdvChalanS" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No.">
<ItemStyle Width="4px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Acc. Date"><ItemTemplate>
<%--<asp:TextBox id="txtAccDate" runat="server" Width="75px" __designer:wfdid="w1"></asp:TextBox>--%><asp:TextBox id="txtAccDate" runat="server" Width="77px" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtAccDate_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Trn Date"><ItemTemplate>
<%--<asp:TextBox id="txtTrnDate" runat="server" Width="75px" __designer:wfdid="w2"></asp:TextBox>--%><asp:TextBox id="txtTrnDate" runat="server" Width="77px" AutoPostBack="True" OnTextChanged="txtTrnDate_TextChanged" CssClass="datePicker"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField HeaderText="Sub Treasury" DataTextField="chvTreasuryNameDisp" DataNavigateUrlFormatString="~/Contents/RemittancePDE.aspx?intSTreasuryDetId={0}" DataNavigateUrlFields="intSTreasuryDetId">
<ItemStyle Width="160px" HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" runat="server" Width="75px" CssClass="txtNumeric" OnTextChanged="txtAmt_TextChanged"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="STreasDetId"><ItemTemplate>
<asp:Label id="lblSTDetId" visible="false" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="TreasuryId"><ItemTemplate>
<asp:Label id="lblTreasId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="EditMode"><ItemTemplate>
<asp:Label id="lblEditMode" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="OldAmt"><ItemTemplate>
            <asp:Label ID="lblOldAmt" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD><TD vAlign=top colSpan=2><asp:GridView id="gdvChalanLB" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
<asp:TemplateField HeaderText="Sub Treasury" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlST" runat="server" __designer:wfdid="w1"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle Width="200px"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId" DataNavigateUrlFormatString="~/Contents/ChalanEdit.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}" DataTextField="intChalanDet" HeaderText="Chalan details">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="NetAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Un posted"><ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" Width="1px" AutoPostBack="True" __designer:wfdid="w2" Enabled="False" OnCheckedChanged="chkApp_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted reason" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlReason" runat="server" width="86px" Enabled="False"></asp:DropDownList> 
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

