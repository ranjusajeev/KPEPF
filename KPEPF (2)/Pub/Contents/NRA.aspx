<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_NRA, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
</script>

 <asp:UpdatePanel ID="updatepanel" runat= "server">
 <ContentTemplate>
<TABLE id="TABLE1" onclick="return TABLE1_onclick()" width="100%" border=0><TBODY><TR><TD class="TdMnHead" colSpan=5 height=26 ;><asp:Label id="lblHead" class="MnHead" runat="server" Text="Non Refundable Advance"></asp:Label></TD></TR><TR><TD style="COLOR: black; BACKGROUND-COLOR: #ccd0e6" align=center colSpan=5 height=26 ;><asp:Label id="Label5" class="p1" runat="server" Text="Basic Details"></asp:Label></TD></TR><TR><TD style="WIDTH: 166px"><asp:Label id="Inward" class="p1" runat="server" Text="Label">Inward No.</asp:Label> </TD><TD style="WIDTH: 166px"><asp:TextBox id="txtInwNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" OnTextChanged="txtInwNo_TextChanged"></asp:TextBox> </TD><TD colSpan=1></TD><TD colSpan=1><asp:Label id="Label2" class="p1" runat="server" Text="Account No. "></asp:Label></TD><TD colSpan=2>&nbsp; <asp:TextBox id="txtEmpID" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="136px" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" OnTextChanged="txtEmpID_TextChanged"></asp:TextBox>&nbsp; <asp:Button id="Button1" onclick="Button1_Click" runat="server" text="..."></asp:Button></TD></TR><TR><TD style="WIDTH: 166px"><asp:Label id="FileNo" class="p1" runat="server" Text="Label">File No.</asp:Label> </TD><TD style="WIDTH: 166px"><asp:Label id="txtFileNo" runat="server" Enabled="False"></asp:Label> </TD><TD></TD><TD><asp:Label id="lblNameAppl" class="p1" runat="server" Text="Name of Applicant"></asp:Label> </TD><TD style="WIDTH: 166px"><asp:Label id="lblNameApplDisp" class="p1" runat="server" Text="<<>>"></asp:Label> </TD></TR><TR><TD style="WIDTH: 166px"><asp:Label id="AppDate" class="p1" runat="server" Text="Label">Application Date</asp:Label> </TD><TD style="WIDTH: 166px"><asp:TextBox id="txtAppDate" runat="server" CssClass="datePicker" OnTextChanged="txtAppDate_TextChanged"></asp:TextBox> </TD><TD align=left></TD><TD align=left><asp:Label id="lblAccNo" class="p1" runat="server" Text="Designation"></asp:Label> </TD><TD style="WIDTH: 166px" align=left><asp:Label id="lblDesig" class="p1" runat="server" Text="<<>>"></asp:Label> </TD></TR><TR><TD style="COLOR: black; BACKGROUND-COLOR: #ccd0e6" align=center colSpan=5 height=26 ;><asp:Label id="Label4" class="p1" runat="server" Text="Advance Details"></asp:Label></TD></TR><TR><%--<td></td>--%><TD align=left colSpan=2><asp:Label id="lblPur" class="p1" runat="server" Text="Purpose of NRA"></asp:Label></TD><TD align=left colSpan=1></TD><TD align=left colSpan=2><asp:DropDownList id="ddlPurpose" oncontextmenu="fnJumpSize(this);" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPurpose_SelectedIndexChanged" Tooltip="Right click to view in full" onchange="fnc(this);" width="155"></asp:DropDownList></TD><%--<td  align="left"><asp:Label id="Label1" class="p1" runat="server" Text="Consolidated TA Amount"></asp:Label></td>
        <td  align=left><asp:TextBox id="lblConsAmt" class="p2" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtNumeric" MaxLength="6"></asp:TextBox></td>--%></TR><TR><%--<td></td>--%><TD align=left colSpan=2><asp:Label id="lblAmt" class="p1" runat="server" Text="Proposed Amount for NRA"></asp:Label></TD><TD align=left colSpan=1></TD><TD align=left colSpan=2><asp:TextBox id="txtPropAmt" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)" runat="server" MaxLength="7" AutoPostBack="True" OnTextChanged="txtPropAmt_TextChanged" Cssclass="txtNumericFloat"></asp:TextBox> </TD><%--<td  align="left"><asp:Label id="Label3" class="p1" runat="server" Text="Monthly Repayment"></asp:Label></td>
        <td  align=left><asp:TextBox id="lblRepay" class="p2" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtNumeric" MaxLength="5"></asp:TextBox></td>--%></TR><TR><%-- <td></td>--%><TD align=left colSpan=2><asp:Label id="lblInst" class="p1" runat="server" Text="Amount Of NRA Admissible"></asp:Label></TD><TD align=left colSpan=1></TD><TD align=left colSpan=2><asp:TextBox id="txtPropInst"  oncut="return false" oncopy="return false" onpaste="return false"  onkeypress="return  isNumberKey(event)" runat="server" CssClass="txtNumeric" MaxLength="2" AutoPostBack="True" ReadOnly="True" Enabled="False"></asp:TextBox></TD><%-- <td  align=left><asp:Label id="lblAdmAmt" class="p1" runat="server" Text="Amount of TA Admissible"></asp:Label></td>
        <td  align=left><asp:TextBox id="txtAdmAmt" runat="server" cssclass="txtNumericFloat" OnTextChanged="txtAdmAmt_TextChanged" AutoPostBack="True" readonly></asp:TextBox></td>--%></TR><TR><TD align=center colSpan=7><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="56px" Text="Save"></asp:Button> </TD></TR><TR><TD style="WIDTH: 494px" colSpan=5><asp:LinkButton id="btnSec" onclick="btnSec_Click" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to inbox" Height="23px" PostBackUrl="~/Contents/InboxService.aspx" Visible="False"></asp:LinkButton></TD></TR></TBODY></TABLE><asp:Panel style="Z-INDEX: 100; LEFT: 700px; POSITION: absolute; TOP: 220px" id="pnlEmpDet" runat="server" BackColor="Thistle" Visible="false">
    <div >
    <TABLE width=50% border="1" cellpadding="0" cellspacing="0" bordercolor="white" >
    <tr><td colspan=2 align=center class=p2>Employee details</td></tr>
    <tr><td colspan=2 align=center class=p2>
        <asp:LinkButton ID="LinkButton1" runat="server" BackColor="Transparent" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" >Annual Statement</asp:LinkButton>  </td></tr>
      <TR><TD align=left width=70% style="height: 21px"><asp:Label id="Label6" class="p1" runat="server"  Text="PF No"></asp:Label> </TD><TD style="width: 104px; height: 21px"><asp:Label id="lblPFNo" class="p4" runat="server" ></asp:Label> </TD></TR>
         
    <TR><TD align=left width=70% style="height: 21px"><asp:Label id="lblbp" class="p1" runat="server"  Text="Basic Pay"></asp:Label> </TD><TD style="width: 104px; height: 21px"><asp:Label id="lblBPay" class="p4" runat="server" ></asp:Label> </TD></TR>
    <TR><TD  align=left><asp:Label id="lblCr" class="p1" runat="server"  Text="Eligible Credit"></asp:Label> </TD><TD style="width: 104px"><asp:Label id="lblPFCr" class="p4" runat="server" ></asp:Label> </TD></TR>
    <TR><TD  align=left style="height: 40px"><asp:Label id="Label7" class="p1" runat="server" Text="Maximum eligible Loan Amount"></asp:Label> </TD><TD style="width: 104px" ><asp:Label id="lblAdmloan" class="p4" runat="server" ></asp:Label> </TD></TR>
    <TR><TD  align=left><asp:Label id="lblLoan" class="p1" runat="server"  Text="Loan Outstanding"></asp:Label> </TD><TD style="width: 104px"><asp:Label id="lblLoanOutstnd" class="p4" runat="server" ></asp:Label> </TD></TR>
    <TR><TD align=left><asp:Label id="lblDB" class="p1" runat="server"  Text="DOB"></asp:Label></TD><TD style="width: 104px"><asp:Label id="lblDBirth" class="p4" runat="server" ></asp:Label></TD></TR>
    <TR><TD align=left style="height: 21px"><asp:Label id="lblJD" class="p1" runat="server" Width="116px" Text="Date of Joining"></asp:Label></TD><TD style="width: 104px" ><asp:Label id="lblJoinDate" class="p4" runat="server" ></asp:Label></TD></TR>
    <TR><TD  align=left><asp:Label id="lblDEn" class="p1" runat="server"  Text="Date of Enrollment"></asp:Label></TD><TD style="width: 104px" ><asp:Label id="lblDEnroll" class="p4" runat="server" ></asp:Label></TD></TR>
    <TR><TD align=left><asp:Label id="lblRet" class="p1" runat="server"  Text="Date of Retirement"></asp:Label></TD><TD style="width: 104px" ><asp:Label id="lblDRetire" class="p4" runat="server" ></asp:Label></TD></TR>
    <TR><TD  align=center colSpan=2><asp:Button id="OkBtn" class="button" runat="server" Width="43px" Text="Ok" OnClick="OkBtn_Click" ></asp:Button>  </TD></TR>
    <TR><TD align=center colSpan=2><asp:Label id="lblpnlerr" runat="server"  Font-Names="Verdana" ForeColor="Red" Font-Size="Smaller"></asp:Label></TD></TR></TABLE></DIV>
    </asp:Panel> <asp:Label id="lblConfirm" runat="server" ForeColor="red" Visible="false"></asp:Label> 
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
   
	</script>

</asp:Content>

