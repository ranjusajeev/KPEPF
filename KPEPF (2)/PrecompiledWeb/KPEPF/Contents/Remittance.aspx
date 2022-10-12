<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_Remittance, App_Web_m1ijyhfm" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="WIDTH: 90%" class="TdMnHead">&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Remittance_Treasury"></asp:Label> </TD></TR><TR><TD align=center><asp:Panel id="pnlEntry" runat="server" Width="90%" BorderColor="#ccd0e6" BorderStyle="Solid" BorderWidth="1px"><TABLE width="90%"><TBODY><TR><TD style="HEIGHT: 22px" align=left><asp:Label id="Year" runat="server" Text="Year" CssClass="p1"></asp:Label></TD><TD style="HEIGHT: 22px" align=left><asp:DropDownList id="ddlYear" runat="server" Width="184px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True" style="height: 20px"></asp:DropDownList></TD><TD style="HEIGHT: 22px" align=left><asp:Label id="Label3" runat="server" Text="District" CssClass="p1"></asp:Label></TD><TD style="HEIGHT: 22px" align=left><asp:DropDownList id="ddldist" runat="server" Width="184px" OnSelectedIndexChanged="ddldist_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlMnth" runat="server" Width="184px" OnSelectedIndexChanged="ddlMnth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD align=left><asp:Label id="Label4" runat="server" Text="District Treasury" CssClass="p1"></asp:Label></TD><TD align=left><asp:DropDownList id="ddlDT" runat="server" Width="184px" OnSelectedIndexChanged="ddlDT_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="lblInti" runat="server" CssClass="p1" text="Intimation Date"></asp:Label></TD><TD align=left><asp:TextBox id="txtInt" runat="server" Width="184px" CssClass="datePicker" AutoPostBack="True" MaxLength="10" OnTextChanged="txtInt_TextChanged"></asp:TextBox></TD><TD align=left><asp:Label id="lblAmt" runat="server" CssClass="p1" text="Amount"></asp:Label></TD><TD align=left><asp:TextBox id="txtAmt" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="184px" CssClass="txtNumeric" MaxLength="8"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 22px" align=left><asp:Label id="lblRem" runat="server" CssClass="p1" text="Remarks"></asp:Label></TD><TD style="HEIGHT: 22px" align=left><asp:TextBox id="txtRem" runat="server" Width="184px"></asp:TextBox></TD><TD style="HEIGHT: 22px" colSpan=2><asp:CheckBox id="chkVerified" runat="server" Text="Verified" CssClass="p1" AutoPostBack="True" Checked="False" OnCheckedChanged="chkVerified_CheckedChanged"></asp:CheckBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button id="btnEntry" onclick="btnEntry_Click" runat="server" Width="50px" Text="Ok" Height="19px"></asp:Button> &nbsp; &nbsp;&nbsp;<asp:Label id="lblTotA" runat="server" Width="71px" Text="..." CssClass="p4"></asp:Label>&nbsp; &nbsp;&nbsp;<asp:Label id="lblStat" runat="server" Width="107px" Text="..." CssClass="p4"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR><TD>&nbsp;</TD></TR>

<tr>
<td align="right">
    <asp:CheckBox ID="chkShow" runat="server" CssClass="p1" AutoPostBack="True" Text="Show Grid" OnCheckedChanged="chkShow_CheckedChanged"  />
</td>

</tr>

<TR><TD style="HEIGHT: 16px" class="TdMnHead" align=center><asp:Label id="lblChalancap" runat="server" Width="90%" Text="Remittance_Localbody" CssClass="MnHead"></asp:Label></TD></TR><TR align=center><TD style="HEIGHT: 188px">
    
  <DIV style="OVERFLOW-X: auto; WIDTH: 900px">  
    <asp:GridView id="gdvchRem" runat="server" Width="120%" ForeColor="#333333" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="2" Font-Size="10pt" Font-Names="Verdana">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<%--<asp:TemplateField HeaderText="Sl. No." ><ItemTemplate>
<asp:Label id="lblSlNoLB" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>--%>

<asp:HyperLinkField DataNavigateUrlFields="numChalanId" DataNavigateUrlFormatString="~/Contents/Remittance.aspx?numChalanId14={0}" DataTextField="SlNo" HeaderText="Sl.No.">
    <ItemStyle Width="50px" />
    </asp:HyperLinkField>

<asp:BoundField DataField="chvTreasuryName" HeaderText="Sub Treasury">
<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,fltChalanAmt,flgApproval" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;fltChalanAmt={1}&amp;flgApproval={2}" DataTextField="ChNodtChalanDate" HeaderText="Chalan  details">
<ItemStyle Width="210px"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Chalan Amount">
<HeaderStyle Width="70px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" Width="70px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="LocalBody">
<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
</asp:BoundField>
    <asp:TemplateField HeaderText="From">
        <ItemTemplate>
            <asp:DropDownList ID="ddlFrmWhm" runat="server" width="70px">
            </asp:DropDownList>
        </ItemTemplate> <ItemStyle Width="75px" />
    </asp:TemplateField>
<asp:TemplateField HeaderText="UnP"><ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="chkApp_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted Reason"><ItemTemplate>
<asp:DropDownList id="ddlReason" runat="server" width="70px"></asp:DropDownList> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="70px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChalanId" Visible="False"><ItemTemplate>
<asp:Label id="lblChalId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Verify"><HeaderTemplate>
<asp:CheckBox id="Allchk" runat="server" Text="Verify" AutoPostBack="True" OnCheckedChanged="Allchk_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkV" runat="server" Width="15px" AutoPostBack="True" Height="19px" OnCheckedChanged="chkV_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Dt" Visible="False"><ItemTemplate>
<asp:Label id="txtchlDt" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndeleteCh" onclick="btnDeleteCh_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>
<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng"></HeaderStyle>
<ItemStyle HorizontalAlign="Center" Width="70px"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
      </DIV>
      </TD></TR><TR><TD align=center style="height: 24px"><asp:Button id="btnLBSave" onclick="btnLBSave_Click" runat="server" Width="50px" Text="Save" Height="20px"></asp:Button> </TD></TR><TR><TD style="HEIGHT: 14px" align=center>&nbsp;</TD></TR><TR><TD style="HEIGHT: 20px" class="TdMnHead" align=center><asp:Label id="lblChalancap2" runat="server" Width="90%" Text="Remittance_MisClassified" CssClass="MnHead"></asp:Label></TD></TR><TR><TD><asp:LinkButton id="lnkChal" onclick="lnkChal_Click" runat="server" Font-Bold="True" Font-Size="10pt">New Chalan</asp:LinkButton> </TD></TR><TR><TD align=center>
    
    <DIV style="OVERFLOW-X: auto; WIDTH: 900px">
    <asp:GridView id="gdvchNonLB" runat="server" Width="100%" ForeColor="#333333" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="2" Font-Size="10pt" Font-Names="Verdana"  >
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl.No." ><ItemTemplate>
<asp:Label id="lblSlNo" runat="server" ></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
    <asp:BoundField DataField="chvTreasuryName" HeaderText="Sub Treasury" />

<asp:HyperLinkField DataNavigateUrlFields="numChalanId" DataNavigateUrlFormatString="~/Contents/Remittance.aspx?numChalanId={0}" DataTextField="intChalanNo" HeaderText="Chalan No."></asp:HyperLinkField>
    <asp:BoundField DataField="dtChalanDate" HeaderText="Chalan Date" />
    <asp:BoundField DataField="fltChalanAmt" HeaderText="Chalan Amount" >
        <ItemStyle HorizontalAlign="Right" />
    </asp:BoundField>
    <asp:BoundField DataField="chvChalanType" HeaderText="Chalan Type" />
      <asp:BoundField DataField="charType" HeaderText="FrmWhm" />
<asp:TemplateField HeaderText="UnP"><ItemTemplate>
<asp:CheckBox id="chkNonUnpost"   runat="server" Width="50px" Enabled="false"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
</asp:TemplateField>
    <asp:BoundField DataField="chvUnPostedRsn" HeaderText="UP Rn" />
    <asp:BoundField DataField="chvEngLBName" HeaderText="Institution" >
        <ItemStyle Width="200px" />
    </asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgChalanType,fltChalanAmt" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;flgChalanType={1}&amp;fltChalanAmt={2}" Text="schedule" HeaderText="Schedule details"></asp:HyperLinkField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Chalan Tp" Visible="False"><ItemTemplate>
<asp:Label id="lblChalTp" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Chalan Amt" Visible="False"><ItemTemplate>
<asp:Label id="lblAmountN" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Chalan ID" Visible="False"><ItemTemplate>
<asp:Label id="txtchlId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
        
        </DIV></DIV> </TD></TR><TR><TD align=center><asp:Button id="btnNonLBSave" onclick="btnNonLBSave_Click" runat="server" Width="50px" Text="Save" Enabled="False" Visible="False"></asp:Button> <asp:Button id="btnTreasRpt" onclick="btnTreasRpt_Click" runat="server" Width="132px" Height="20px" Text="Treasury Statement"></asp:Button> </TD></TR><TR><TD><asp:Panel style="Z-INDEX: 100; LEFT: 300px; POSITION: absolute; TOP: 550px" id="pnlChalNew" runat="server" Width="300px" BackColor="LightGray" Visible="false"><DIV><TABLE><TBODY><TR align="center"><TD style="HEIGHT: 18px" class="p1" align="center" colSpan=2>New Chalan</TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="lblchlId" runat="server" Text="id." Visible="False"></asp:Label><asp:Label id="lblEditMode" runat="server" Text="0" Visible="False"></asp:Label><asp:Label id="lblDy" runat="server" Text="0" Visible="False"></asp:Label><asp:Label id="lblDtOld" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px">
    <asp:TextBox id="txtchlnId"  runat="server" BorderStyle="None" Enabled="False" MaxLength="7" Visible="False">0</asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label6" class="p1" runat="server" Text="No."></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:TextBox id="txtChalNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="9">0</asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label1" class="p1" runat="server" Text="Date"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:TextBox id="txtChalDt" runat="server" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtChalDt_TextChanged">
</asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label5" class="p1" runat="server" Text="Amount"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:TextBox id="txtChalAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="7"></asp:TextBox> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="lblStreas" runat="server" Text="SubTreasury" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:DropDownList id="ddlsubTreas" runat="server" Width="150px"></asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Labe3" runat="server" Text="Localbody" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:DropDownList id="ddlLBNew" runat="server" Width="150px" ></asp:DropDownList> </TD></TR>



<TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="lbltype" runat="server" Text="ChalanType" CssClass="p1"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:DropDownList id="ddlchlType" runat="server" Width="150px" OnSelectedIndexChanged="ddlchlType_SelectedIndexChanged"></asp:DropDownList> </TD></TR>


<TR>
    
    <TD style="HEIGHT: 21px" align=left width="90%">
        
        <asp:Label id="LblFrm" class="p1" runat="server" Text="From Whom"></asp:Label>

    </TD>
    <TD style="WIDTH: 104px; HEIGHT: 21px">
        <asp:DropDownList id="ddlFrm" runat="server">
</asp:DropDownList> 

    </TD>

</TR>

<TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="Label7" class="p1" runat="server" Text="Unposted"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:CheckBox id="chkUpN" runat="server" AutoPostBack="True" OnCheckedChanged="chkUpN_CheckedChanged">
</asp:CheckBox> </TD></TR>

<TR>
    
    <TD style="HEIGHT: 21px" align=left width="90%">
        
        <asp:Label id="Label8" class="p1" runat="server" Text="Reason"></asp:Label>

    </TD>
    <TD style="WIDTH: 104px; HEIGHT: 21px">
        <asp:DropDownList id="ddlRsnN" runat="server" Enabled="False" >
</asp:DropDownList> 

    </TD>

</TR>

<TR><TD style="HEIGHT: 21px" align=center width="90%" colSpan=2><asp:Button id="btnNewChal" onclick="btnNewChal_Click" runat="server" Width="55px" Text="Save" Height="20px"></asp:Button> 

<asp:Button id="btnCan" onclick="btnCan_Click" runat="server" Width="55px" Text="Cancel" Height="20px"></asp:Button>
</TD></TR><TR><TD style="HEIGHT: 21px" align=left width="90%"><asp:Label id="lblNw" runat="server" Text="0" Visible="False"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:Label id="lblOl" runat="server" Text="0" Visible="False"></asp:Label> </TD></TR></TBODY></TABLE></DIV></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    <%--<script language="javascript" type="text/javascript">
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
function TABLE1_onclick() {

}

 </script>--%>
</asp:Content>

