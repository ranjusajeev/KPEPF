<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="PrintPage.aspx.cs" Inherits="Contents_PrintPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%" style="border-top-style: solid; border-top-color: #3399ff; border-bottom-style: solid; border-left-color: #3399ff; border-bottom-color: #3399ff; border-right-style: solid; border-left-style: solid; border-right-color: #3399ff;"><TBODY><TR><TD class="TdMnHead" colSpan=4><asp:Label id="lblHead" class="MnHead" runat="server" Text="View a file"></asp:Label></TD></TR><TR><TD style="WIDTH: 505px; align=center #ccd0e6? BACKGROUND-COLOR:>&nbsp; <asp:TextBox id="txtEmpId" oncopy="return false" oncut="return false" onkeypress="return isNumberKey(event)" onpaste="return false" runat="server" OnTextChanged="txtEmpId_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 505px" align=center><asp:Panel id="pnlChal" runat="server" Width="100%" Visible="false" BorderColor="Red" BorderStyle="Solid"><TABLE><TBODY><TR><TD><asp:Label id="Label1" runat="server" Text="Year" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlYear" tabIndex=4 runat="server" Width="80px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList> </TD><TD>&nbsp;</TD><TD><asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlMonth" tabIndex=5 runat="server" Width="80px" AutoPostBack="True"></asp:DropDownList></TD><TD>&nbsp;</TD><TD><asp:Label id="Label4" runat="server" Text="District" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlDistrict" tabIndex=6 runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList> </TD><TD>&nbsp;</TD><TD><asp:Label id="Label3" runat="server" Width="70px" Text="Treasury" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlTreas" tabIndex=6 runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlTreas_SelectedIndexChanged"></asp:DropDownList></TD><TD>&nbsp;</TD><TD><asp:Label id="Label5" runat="server" Text="Chalan" CssClass="p1"></asp:Label> <asp:DropDownList id="ddlChalan" tabIndex=6 runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlChalan_SelectedIndexChanged"></asp:DropDownList> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR align=center>
    <TD style="WIDTH: 505px"><asp:Panel id="pnlEmpE" runat="server" Width="100%" Visible="false" BorderColor="Red" BorderStyle="Solid">
        <table>
        <tr><td>
        <asp:RadioButtonList id="rdTrn" runat="server" ForeColor="RoyalBlue" Font-Bold="True" CssClass="p1" Font-Names="Verdana" AutoPostBack="True" OnSelectedIndexChanged="rdTrn_SelectedIndexChanged" Font-Size="10pt" RepeatDirection="Horizontal" Enabled="true"><asp:ListItem Selected="True"> Consolidation &nbsp;&nbsp;</asp:ListItem>
<asp:ListItem> Live &nbsp;&nbsp;</asp:ListItem>
<asp:ListItem> Closed &nbsp;&nbsp;</asp:ListItem>
<asp:ListItem> With OB &nbsp;&nbsp;</asp:ListItem>
<asp:ListItem> Without OB &nbsp;&nbsp;</asp:ListItem>
</asp:RadioButtonList></td></tr> <tr><td><asp:Label id="Label10" runat="server" ForeColor="#0000C0" Font-Bold="True" Text="District" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlDist" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged"></asp:DropDownList></td></tr> </asp:Panel> </TD></TR><TR align=center><TD style="WIDTH: 505px"><asp:Panel id="pnlAppStat" runat="server" Width="100%" Visible="false" BorderColor="Red" BorderStyle="Solid">
    
    <table>
        <tr><td colspan="2">
            <asp:RadioButtonList id="rdAppListCons" runat="server" ForeColor="RoyalBlue" Font-Bold="True" CssClass="p1" Font-Names="Verdana" AutoPostBack="True" OnSelectedIndexChanged="rdAppListCons_SelectedIndexChanged" Font-Size="10pt" RepeatDirection="Horizontal" Enabled="true"><asp:ListItem Selected="True">Consolidated</asp:ListItem>
<asp:ListItem>Yearwise</asp:ListItem>
</asp:RadioButtonList>
            </td></tr>
        <tr><td>
    <asp:Label id="Label11" runat="server" ForeColor="#0000C0" Font-Bold="True" Text="Year" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> &nbsp; &nbsp;&nbsp;<asp:DropDownList id="ddlYearA" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYearA_SelectedIndexChanged" Enabled="False"></asp:DropDownList> &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:Label id="Label21" runat="server" ForeColor="#0000C0" Font-Bold="True" Text="Month" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label>&nbsp; &nbsp;&nbsp; <asp:DropDownList id="ddlMonthA" tabIndex=5 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonthA_SelectedIndexChanged" Enabled="False"></asp:DropDownList></td></tr> <tr><td><asp:RadioButtonList id="rdTrnA" runat="server" ForeColor="RoyalBlue" Font-Bold="True" CssClass="p1" Font-Names="Verdana" AutoPostBack="True" OnSelectedIndexChanged="rdTrnA_SelectedIndexChanged" Font-Size="10pt" RepeatDirection="Horizontal" Enabled="true"><asp:ListItem Selected="True">Remittance</asp:ListItem>
<asp:ListItem>Withdrawal</asp:ListItem>
</asp:RadioButtonList></td></tr></table> </asp:Panel> </TD></TR><TR align=center><TD style="WIDTH: 505px"><asp:Panel id="pnlSuspOtherPF" runat="server" Width="100%" Visible="false" BorderColor="Red" BorderStyle="Solid"><asp:Label id="Label11S" runat="server" ForeColor="#0000C0" Font-Bold="True" Text="District" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlDistS" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistS_SelectedIndexChanged"></asp:DropDownList> &nbsp; <asp:Label id="Label21S" runat="server" ForeColor="#0000C0" Font-Bold="True" Text="Year" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> <asp:DropDownList id="ddlYearS" tabIndex=5 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYearS_SelectedIndexChanged"></asp:DropDownList> </asp:Panel> </TD></TR><TR><TD style="WIDTH: 505px" align=center><asp:Button id="btnPrint" onclick="btnPrint_Click" runat="server" Width="75px" ForeColor="#0000C0" Text="View" Font-Names="Verdana"></asp:Button> </TD></TR>

    <tr><td align="center">

        <asp:GridView id="gdvSerHis" runat="server"  ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="chvYear" HeaderText="Year"></asp:BoundField>
<asp:BoundField DataField="chvMonth" HeaderText="Month"></asp:BoundField>
<asp:BoundField HeaderText="District" DataField="chvEngDistName">
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
      
        
          <asp:GridView id="gdvRejList" runat="server"  ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="chvYear" HeaderText="Year"></asp:BoundField>
<asp:BoundField DataField="chvMonth" HeaderText="Month"></asp:BoundField>
<asp:BoundField HeaderText="District" DataField="chvEngDistName">
</asp:BoundField>
    <asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury" />
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
        </td></tr>
                                                                                                                                                                                                                                                        </TBODY></TABLE>
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
                yearRange: "-30:+0",
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
   function ReportDet()
    {
        var strlink;
        strlink="../Contents/Reports.aspx?rptName=TASanctionOrder.rpt&noParams=0";
        window.open(strlink,"TASanctionOrder","status=no,toolbar=no,menubar=no,scrollbars=yes,fullscreen=no,left=0,top=0,height=555,width=796,resizable=yes");
    }


	</script>
--%></asp:Content>

