<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AnnStatementLat, App_Web_4p3ju0t2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=3><asp:Label id="lblHead" class="MnHead" runat="server" Text="Annual Statement"></asp:Label> </TD></TR><TR><TD align=center><asp:Label id="Label5" class="p1" runat="server" Text="Account No."></asp:Label> <asp:TextBox id="txtAccNo" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" OnTextChanged="txtAccNo_TextChanged" CssClass="txtNumeric" AutoPostBack="True" MaxLength="5"></asp:TextBox> <asp:Label id="lblAccNo" runat="server" CssClass="p4" Text="..." ></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblName" runat="server" CssClass="p4" Text="..."  ></asp:Label> </TD><TD align=center>&nbsp;</TD></TR>
<tr><td> &nbsp;</td></tr>

    <TR><TD style="WIDTH: 700px" align=center colSpan=3><asp:GridView id="gdvCons" runat="server" Width="300px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:HyperLinkField DataNavigateUrlFields="intYearId" DataNavigateUrlFormatString="~/Contents/AnnStatementLat.aspx?intYearId={0}" DataTextField="chvYear" HeaderText="Year">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltTotal" HeaderText="Credit">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltWith" HeaderText="Debit">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="intYearId" HeaderText="YearId" Visible="False">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR>


<TR><TD style="WIDTH: 1027px" align=center colSpan=3><asp:GridView id="gdvAnnStmnt" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5" Visible="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField ApplyFormatInEditMode="True" DataField="chvMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId,PerYearId,PerMonthId,intDistID,PDEYear" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}&amp;PerYearId={4}&amp;PerMonthId={5}&amp;intDistID={6}&amp;PDEYear={7}" DataTextField="ChalanDet" HeaderText="Chalan">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltSubnAmt" HeaderText="Subn.  Amount  ">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltRePaymentAmt" HeaderText="Ref. Amount ">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltArearPFAmt" HeaderText="Arr. PF">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltArearDA" HeaderText="Arr. DA">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltArearPay" HeaderText="Arr. Pay">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltTotal" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAllottedAmt" HeaderText="Withdrawal">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 1027px" align=center colSpan=3><asp:GridView id="gdvCcVer" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5" Visible="False" OnRowDataBound="gdvCcVer_RowDataBound">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField ApplyFormatInEditMode="True" DataField="chvMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApprovalChal,flgPrevYear,intGroupId,intID,intDistID" DataNavigateUrlFormatString="~/Contents/ChalanEdit.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}&amp;intMonthID={4}&amp;intDistID={5}" DataTextField="CDate" HeaderText="Chalan">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="MsAmt" HeaderText="Subn. Amount  ">
<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RfAmt" HeaderText="Ref. Amount  ">
<HeaderStyle HorizontalAlign="Center" Width="70px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PfAmt" HeaderText="Arr. PF">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DaAmt" HeaderText="Arr. DA">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="PayAmt" HeaderText="Arr. Pay">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RemAmt" HeaderText="Total">
<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Withdrawal" HeaderText="Withdrawal">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
<%--<SCRIPT language="javascript" type="text/javascript">
Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()

{
$(".datePicker").datepicker 
          ({
                numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "-10:+0",
      });
//              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
});

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
   
	</SCRIPT>
--%></ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

