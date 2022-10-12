<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="ChalBillSearch.aspx.cs" Inherits="Contents_ChalBillSearch" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%" border=0><TBODY><TR><TD style="HEIGHT: 20px" class="TdMnHead" colSpan=4 ;><asp:Label id="lblHead" class="MnHead" runat="server" Text="View Chalan"></asp:Label></TD></TR><TR><TD style="WIDTH: 1118px; BACKGROUND-COLOR: #ccd0e6" align=center><asp:RadioButtonList id="rdCategory" runat="server" OnSelectedIndexChanged="rdCategory_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="p1"><asp:ListItem Selected="True">Number &nbsp;&nbsp;</asp:ListItem>
<asp:ListItem>Localbody &nbsp;&nbsp;</asp:ListItem>
<asp:ListItem>Treasury</asp:ListItem>
</asp:RadioButtonList> <asp:Panel id="pnlNo" runat="server" Width="100%" Visible="true"><asp:Label id="Label5" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Date" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:TextBox id="txtDt" tabIndex=4 runat="server" AutoPostBack="True" CssClass="datePicker" MaxLength="10" OnTextChanged="txtDt_TextChanged"></asp:TextBox> &nbsp; <asp:Label id="Label6" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="No." CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:TextBox id="txtNo" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return isNumberKey(event)" onpaste="return false" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="9"></asp:TextBox> &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </asp:Panel> <asp:Panel id="pnlLb" runat="server" Width="100%" Visible="true"><asp:Label id="Label1" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Year" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlYear" tabIndex=4 runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp; <asp:Label id="Label2" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Month" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlMonth" tabIndex=5 runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp; <asp:Label id="Label4" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="District" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlDistrict" tabIndex=6 runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp; <asp:Label id="Label3" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Localbody" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlLb" tabIndex=6 runat="server" OnSelectedIndexChanged="ddlLb_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp; &nbsp; </asp:Panel> <asp:Panel id="pnlTreas" runat="server" Width="100%" Visible="true"><asp:Label id="Label7" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Year" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlYearT" tabIndex=4 runat="server" OnSelectedIndexChanged="ddlYearT_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp; <asp:Label id="Label8" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Month" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlMonthT" tabIndex=5 runat="server" OnSelectedIndexChanged="ddlMonthT_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp; <asp:Label id="Label9" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="District" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlDistrictT" tabIndex=6 runat="server" OnSelectedIndexChanged="ddlDistrictT_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp; <asp:Label id="Label10" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Treasury" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlTreas" tabIndex=6 runat="server" OnSelectedIndexChanged="ddlTreas_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp; &nbsp; </asp:Panel> </TD></TR><TR><TD style="HEIGHT: 24px" align=center colSpan=4><asp:Button id="btnFind" onclick="btnFind_Click" runat="server" Width="75px" ForeColor="#0000C0" Text="Find" Font-Names="Verdana"></asp:Button>&nbsp; </TD></TR><TR align=center><TD><asp:GridView id="gdvInboxMembership" runat="server" Width="692px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId,PerYearId,PerMonthId,intDistID,PDEYear" DataNavigateUrlFormatString="~/Contents/ChalanEdit.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}&amp;PerYearId={4}&amp;PerMonthId={5}&amp;intDistID={6}&amp;PDEYear={7}" DataTextField="dtChalanDate" HeaderText="Chalan details"></asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right" Width="45px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvNAme" HeaderText="Localbody"></asp:BoundField>
<asp:BoundField DataField="chvEngDistName" HeaderText="District"></asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury" Visible="False"></asp:BoundField>
<asp:TemplateField HeaderText="TrnId" Visible="False"><ItemTemplate>
<asp:Label id="txtNumTrnId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Apprv" Visible="False"><ItemTemplate>
<asp:Label id="lblAppFlg" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="YearId" Visible="False"><ItemTemplate>
            <asp:Label ID="lblYear" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="MonthId" Visible="False"><ItemTemplate>
            <asp:Label ID="lblMonth" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DistId" Visible="False"><ItemTemplate>
            <asp:Label ID="lblDist" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="chvApproval" HeaderText="Status"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>&nbsp; <asp:GridView id="gdvBill" runat="server" Width="692px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intBillWiseId,flgApproval" DataNavigateUrlFormatString="~/Contents/BillEditPDE01.aspx?intBillWiseId={0}&amp;flgApproval={1}" DataTextField="BillDet" HeaderText="Bill details"></asp:HyperLinkField>
<asp:BoundField DataField="fltNetAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right" Width="45px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>&nbsp; </TD></TR><TR align=center><TD><asp:GridView id="gdvInboxMembershipCurr" runat="server" Width="692px" ForeColor="#333333" Visible="False" Font-Names="Verdana" Font-Size="10pt" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId,PerYearId,PerMonthId,intDistID,PDEYear" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}&amp;PerYearId={4}&amp;PerMonthId={5}&amp;intDistID={6}&amp;PDEYear={7}" DataTextField="dtChalanDate" HeaderText="Chalan details"></asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right" Width="45px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvNAme" HeaderText="Localbody"></asp:BoundField>
<asp:BoundField DataField="chvEngDistName" HeaderText="District"></asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury" Visible="False"></asp:BoundField>
<asp:TemplateField HeaderText="TrnId" Visible="False"><ItemTemplate>
<asp:Label id="txtNumTrnId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Apprv" Visible="False"><ItemTemplate>
<asp:Label id="lblAppFlg" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="YearId" Visible="False"><ItemTemplate>
            <asp:Label ID="lblYear" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="MonthId" Visible="False"><ItemTemplate>
            <asp:Label ID="lblMonth" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DistId" Visible="False"><ItemTemplate>
            <asp:Label ID="lblDist" runat="server" Text="Label"></asp:Label>
        
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="chvApproval" HeaderText="Status"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>&nbsp; <asp:GridView id="gdvBillCurr" runat="server" Width="692px" ForeColor="#333333" Visible="False" Font-Names="Verdana" Font-Size="10pt" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="intBillWiseId,flgApproval" DataNavigateUrlFormatString="~/Contents/BillEditPDE01.aspx?intBillWiseId={0}&amp;flgApproval={1}" DataTextField="BillDet" HeaderText="Bill details"></asp:HyperLinkField>
<asp:BoundField DataField="fltNetAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right" Width="45px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury"></asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>&nbsp; </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
<%--<script language="javascript" type="text/javascript">
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
--%></asp:Content>

