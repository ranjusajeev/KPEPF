<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ChalanSchedule, App_Web_zy0s82tr" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE><TBODY><TR><TD><TABLE width="100%"><TBODY><TR><TD class="TdMnHead" colSpan=4><asp:Label id="lblHead" class="MnHead" runat="server" Text="Chalan And Schedule Details "></asp:Label> </TD></TR><TR><TD align=left colSpan=2><asp:Panel id="pnlSelection" runat="server" Width="100%"><TABLE width="50%"><TBODY><TR><TD align=left></TD><TD align=left><asp:Label id="lblYearChln" runat="server"  Text="Year" CssClass="p1"></asp:Label> </TD><TD align=left><asp:DropDownList id="ddlyearChln" runat="server" Width="184px" AutoPostBack="True"></asp:DropDownList></TD><TD align=left><asp:Label id="lblChlan" runat="server"  Text="Chalan Amount" CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtAmountCh" runat="server" Width="184px"></asp:TextBox></TD></TR><TR><TD align=left></TD><TD align=left><asp:Label id="lblDistChln" runat="server"  Text="District" CssClass="p1"></asp:Label> </TD><TD align=left><asp:DropDownList id="ddlDistChln" runat="server" Width="184px" AutoPostBack="True"></asp:DropDownList></TD><TD align=left><asp:Label id="Label3" runat="server" Text="Schedule Amount"  CssClass="p1"></asp:Label></TD><TD align=left><asp:TextBox id="txtAmtSch" runat="server" Width="184px"></asp:TextBox></TD></TR><TR><TD align=left></TD><TD align=left><asp:Label id="lblLBChln" runat="server" Text="Institusion" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlLBChln" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlLBChln_SelectedIndexChanged"></asp:DropDownList></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD align=center><asp:Panel id="pnlChlnShed" runat="server" Width="100%"><asp:Label id="lblChalanHead" runat="server" Width="100%" ForeColor="Navy" Font-Bold="True" Text="Chalan Particulars" Font-Size="10pt" Font-Names="Verdana" BackColor="#CCD0E6"></asp:Label><TABLE width="100%"><TBODY><TR><TD ><asp:GridView id="gdvChlnSchedl" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="Treasury Name"><ItemTemplate>
<asp:TextBox id="txtTrname" runat="server" Width="184px" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtChalanNo" runat="server" Width="184px" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Date"><ItemTemplate>
<asp:TextBox id="txtChalDate" runat="server" Width="184px"  readonly="true" CssClass="datePicker"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtChln" onkeypress="return  isNumberKey(event)" onpaste="return False" runat="server" Width="184px" CssClass="txtNumeric" MaxLength="8"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="From Month"><ItemTemplate>
<asp:TextBox id="txtFrmMnth" runat="server" Width="184px"  MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="To Month"><ItemTemplate>
<asp:TextBox id="txtToMnth" runat="server" Width="184px"  MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status"><ItemTemplate>
<asp:TextBox id="txtStatsChln" runat="server" Width="184px"  MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remark"><ItemTemplate>
<asp:TextBox id="txtRemarkChln" runat="server" Width="184px"  MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="WIDTH: 3087px" align=center><asp:Panel id="pnlSched" runat="server" Width="100%"><asp:Label id="Label1" runat="server" Width="100%" ForeColor="Navy" Font-Bold="True" Text="Shedule Particulars" Font-Size="10pt" Font-Names="Verdana" BackColor="#CCD0E6"></asp:Label><TABLE width="100%"><TBODY><TR></TR><TR><TD align=left><asp:Label id="Label6" runat="server" Width="184px" ForeColor="#0000C0" Text="No of Records" Font-Size="10pt" Font-Names="Verdana"></asp:Label> <asp:TextBox id="txtRcrds" runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtRcrds_TextChanged"></asp:TextBox></TD><TD></TD></TR><TR><TD><asp:GridView id="gdvshdule1" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="A/C No"><ItemTemplate>
<asp:TextBox id="txtAccNo" runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtAccNo_TextChanged" __designer:wfdid="w1"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name Of Subscriber"><ItemTemplate>
<asp:TextBox id="txtSubs" runat="server" Width="184px" __designer:wfdid="w2" ReadOnly="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Subscription"><ItemTemplate>
<asp:TextBox id="txtsub" onkeypress="return  isNumberKey(event)" onpaste="return False" runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtsub_TextChanged" CssClass="txtNumeric" MaxLength="8"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Repayment">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="150px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox id="txtrepay" onkeypress="return  isNumberKey(event)" onpaste="return False" runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtrepay_TextChanged" CssClass="txtNumeric" MaxLength="8"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Arrear PF">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="150px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox id="txtArrPF" onkeypress="return  isNumberKey(event)" onpaste="return False" runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtArrPF_TextChanged" CssClass="txtNumeric" MaxLength="8"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Arrear DA"><ItemTemplate>
<asp:TextBox id="txtArrDA" onkeypress="return  isNumberKey(event)" onpaste="return False" runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtArrDA_TextChanged" CssClass="txtNumeric" MaxLength="8"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Arrear Pay">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="150px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox id="txtArrPay" onkeypress="return  isNumberKey(event)" onpaste="return False" runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtArrPay_TextChanged" CssClass="txtNumeric" MaxLength="8"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="150px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox id="txtTotal" onkeypress="return  isNumberKey(event)" runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtTotal_TextChanged" __designer:wfdid="w2" MaxLength="8" CssClass="txtNumeric"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText=" Govt Order"><ItemTemplate>
<asp:DropDownList id="ddlGovtOrder" runat="server" Width="184px" ></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="No. Instalment">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="150px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox id="txtInst" onkeypress="return  isNumberKey(event)" runat="server" Width="184px" AutoPostBack="True" OnTextChanged="txtInst_TextChanged" CssClass="txtNumeric" MaxLength="2"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted"><ItemTemplate>
<asp:CheckBox id="chkUnpost" runat="server" ></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason"><ItemTemplate>
<asp:DropDownList id="ddlReasn4" runat="server" Width="184px" ></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remark"><ItemTemplate>
<asp:TextBox id="txtRemark4" runat="server" Width="184px"  MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Add Row"><ItemTemplate>
<asp:Button id="btnAddrow" runat="server" Width="50px" Text="Add" __designer:wfdid="w4" HeaderText="Add Row"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD align=center colSpan=4><asp:Button id="btnbck1" onclick="btnbck1_Click" runat="server" Width="113px" Text="Back"></asp:Button> <asp:Button id="btnsave1" onclick="btnsave1_Click" runat="server" Width="113px" Text="Save"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
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

