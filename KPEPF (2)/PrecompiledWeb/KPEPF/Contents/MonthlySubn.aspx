<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_MonthlySubn, App_Web_m1ijyhfm" title="KPEPF-Monthly Subscription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel id="UpdatePanel1" runat="server">
 <ContentTemplate>
<TABLE style="BACKGROUND: white" width="100%" border=0><TBODY><TR><TD class="TdMnHead" colSpan=4><asp:Label id="lblHead" class="MnHead" runat="server" Text="Monthly Subscription"></asp:Label> </TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD align=left><asp:Label id="lblYear" class="p1" runat="server" Text="Year"></asp:Label> <asp:DropDownList id="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD><TD align=left><asp:Label id="lblMonth" class="p1" runat="server" Text="Month"></asp:Label> <asp:DropDownList id="ddlMonth" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> <asp:Label id="lblStatus" class="p1" runat="server"></asp:Label> </TD><TD align=center><asp:Label id="lblType" class="p1" runat="server" Text="BillType"></asp:Label> <asp:DropDownList id="ddlBillType" runat="server" OnSelectedIndexChanged="ddlBillType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 5px" colSpan=4><asp:Panel style="Z-INDEX: 100; LEFT: 361px; POSITION: absolute; TOP: 164px" id="pnlAmountmismatch" runat="server" Width="312px" Visible="False" BackColor="Silver" Height="105px"><asp:Label id="Label1" runat="server" Width="100%" Font-Bold="True" Text="KPEPF" Font-Size="Medium" Font-Names="Verdana" CssClass="p3"></asp:Label> <asp:Button style="Z-INDEX: 100; LEFT: 98px; POSITION: absolute; TOP: 54px" id="btnYes" onclick="btnYes_Click" runat="server" Width="59px" Text="Yes"></asp:Button> <asp:Button style="Z-INDEX: 100; LEFT: 174px; POSITION: absolute; TOP: 53px" id="btnNo" onclick="btnNo_Click" runat="server" Width="59px" Text="No"></asp:Button> <asp:Label id="Label2" runat="server" Width="100%" Text="Amount mismatch in Chalan and Schedule! Do you want to Continue?" Font-Size="10pt" Font-Names="Verdana" CssClass="p2"></asp:Label></asp:Panel></TD></TR><TR><TD colSpan=4>&nbsp;</TD></TR><TR><TD style="WIDTH: 100%" colSpan=4><asp:GridView id="gdvMonthlySubn" runat="server" Width="900px" ForeColor="#333333" ShowFooter="True" GridLines="None" CellPadding="4" AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="10pt">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl no.">
<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvPF_No" HeaderText="Acc No">
<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="chvName" HeaderText="Name">
<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="fltSubnAmt" HeaderText="Subscription">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltRePaymentAmt" HeaderText="Repayment">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltArearPFAmt" HeaderText="Arrear PF">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltArearDA" HeaderText="Arrear DA">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltArearPay" HeaderText="Arrear Pay">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Govt.Order"><ItemTemplate>
<asp:DropDownList id="ddlGo" runat="server" width="70px" Enabled="False"></asp:DropDownList> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="TotRem" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Unposted" Visible="False"><ItemTemplate>
<asp:CheckBox id="chkUp" runat="server" Width="44px" OnCheckedChanged="chkUp_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted reason" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlUpRsn" runat="server" Width="70px"></asp:DropDownList>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtRem" runat="server" Width="70px"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EmpId" Visible="False"><ItemTemplate>
<asp:Label id="lblEmpId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="InactiveCaptionText" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" BorderColor="Gray" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 122px" align=center colSpan=4><asp:Panel id="pnlChal" runat="server" Visible="true" width="100%" BorderWidth="0"><TABLE width="100%"><TBODY><TR><TD colSpan=4 height=5></TD></TR><TR><TD class="TdSbHead" colSpan=4><asp:Label id="lblDet" class="Head1" runat="server" Text="Chalan Details"></asp:Label> </TD></TR>

 <TR><TD style="WIDTH: 10%; HEIGHT: 22px" align=left><asp:Label id="lblBank" runat="server" CssClass="p1" text="Treasury"></asp:Label> </TD><TD style="WIDTH: 20%; HEIGHT: 22px" align=left><asp:Label id="lblTreas" runat="server" Font-Size="10pt" Font-Names="Verdana" CssClass="p3" text="..."></asp:Label> </TD><TD style="WIDTH: 10%; HEIGHT: 22px" align=left><asp:Label id="lblChlNo" runat="server" CssClass="p1" text="Chalan No."></asp:Label> </TD><TD style="WIDTH: 25%; HEIGHT: 22px" align=left><asp:TextBox id="txtChlNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" width="130px" CssClass="txtNumeric" MaxLength="4"></asp:TextBox> </TD></TR><TR><TD align=left><asp:Label id="lblChlAmt" runat="server" CssClass="p1" text="Chalan Amount"></asp:Label> </TD><TD align=left><asp:TextBox id="txtChlAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" width="90px" CssClass="txtNumericFloat" text="0" MaxLength="6" ReadOnly="True"></asp:TextBox> </TD><TD align=left><asp:Label id="lblChldt" runat="server" CssClass="p1" text="Chalan Date"></asp:Label> </TD><TD align=left><asp:TextBox id="txtChlDt" runat="server" width="130px" CssClass="datePicker" MaxLength="10"></asp:TextBox> </TD></TR>

  </TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="HEIGHT: 24px" align=center colSpan=3><asp:Button id="btnFinal" onclick="btnFinal_Click" runat="server" Width="74px" Text="Save"></asp:Button> &nbsp; <asp:Button id="btnPrint" onclick="btnPrint_Click" runat="server" Width="70px" Text="Print" Enabled="True "></asp:Button> </TD></TR><TR><TD style="HEIGHT: 33px" colSpan=4><asp:LinkButton id="btnSec" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to inbox" Visible="False" Height="23px" PostBackUrl="~/Contents/InboxMonthlyTrn.aspx" OnClick="btnSec_Click"></asp:LinkButton> </TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel>
    &nbsp;

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
	<script type = "text/javascript">
        function Confirm() 
        {
//        alert(ctl00_contentPholder_txtChlAmt.value);
//        if(ctl00_contentPholder_txtChlAmt.text != "0" || ctl00_contentPholder_txtChlAmt.text != "" )
//        {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Amount mismatch in Chalan and Schedule! Do you want to Continue?")) 
            {
                confirm_value.value = "Yes";
            } 
            else 
            {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
          }
            
//        }
    </script>
</asp:Content>

