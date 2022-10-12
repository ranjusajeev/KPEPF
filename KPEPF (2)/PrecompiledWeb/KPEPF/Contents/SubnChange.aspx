<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_SubnChange, App_Web_m1ijyhfm" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%" border=0><TBODY><TR><TD class="TdMnHead" colSpan=4><asp:Label id="lblHead" class="MnHead" runat="server" Text="Subscription change"></asp:Label></TD></TR><TR><TD class="TdSbHead" colSpan=4><asp:Label id="Label5" class="p1" runat="server" Text="Basic Details"></asp:Label></TD></TR><%--<tr>
        <td> <asp:Label id="Inward" class="p1" runat="server" Text="Label">Inward No.</asp:Label> </td>
        <td><asp:TextBox id="txtInwNo" oncut="return false" oncopy="return false" onpaste="return false"  runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" OnTextChanged="txtInwNo_TextChanged"></asp:TextBox> </td>
       <%-- <td><asp:Label id="Label2" class="p1" runat="server" Text="Account No. "></asp:Label> </td>
        <td><asp:TextBox id="txtEmpID" oncut="return false" oncopy="return false" onpaste="return false"  runat="server" AutoPostBack="True" OnTextChanged="txtEmpID_TextChanged" onkeypress="return  isNumberKey(event)" CssClass="txtNumeric" MaxLength="5" Width="116px"  ></asp:TextBox> 
        <asp:Button id="Button1" onclick="btnDet_Click" runat="server" text="..."></asp:Button> 
        </td>
    </tr>--%><TR><%-- <td ><asp:Label id="FileNo" class="p1" runat="server" Text="Label">File No.</asp:Label> </td>
        <td ><asp:Label id="txtFileNo" runat="server"  Enabled="False"></asp:Label> </td>--%><TD><asp:Label id="Label2" class="p1" runat="server" Text="Account No. "></asp:Label> </TD><TD><asp:TextBox id="txtEmpID" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="116px" MaxLength="5" CssClass="txtNumeric" OnTextChanged="txtEmpID_TextChanged" AutoPostBack="True"></asp:TextBox> <asp:Button id="Button1" onclick="btnDet_Click" runat="server" text="..." Width="27px"></asp:Button> </TD><TD><asp:Label id="lblNameAppl" class="p1" runat="server" Text="Name of Applicant"></asp:Label> </TD><TD><asp:Label id="lblNameApplDisp" class="p1" runat="server" Text="<<>>"></asp:Label> </TD></TR><TR><TD><asp:Label id="AppDate" class="p1" runat="server" Text="Label">Application Date</asp:Label> </TD><TD><asp:TextBox id="txtAppDate" runat="server" MaxLength="10" CssClass="datePicker" OnTextChanged="txtAppDate_TextChanged" AutoPostBack="True"></asp:TextBox> </TD><TD align=left><asp:Label id="lblAccNo" class="p1" runat="server" Text="Designation"></asp:Label> </TD><TD align=left><asp:Label id="lblDesig" class="p1" runat="server" Text="<<>>"></asp:Label> </TD></TR><TR><TD class="TdSbHead" colSpan=4><asp:Label id="Label4" class="p1" runat="server" Text="Subscription Details"></asp:Label></TD></TR><%--<tr>
        <td  align="left"><asp:Label id="lblPur" class="p1" runat="server" Text="Current subn. amount"></asp:Label></td>
        <td  align="left"><asp:DropDownList id="ddlPurpose" Tooltip="Right click to view in full" runat="server"  oncontextmenu="fnJumpSize(this);" onchange="fnc(this);" width="155" AutoPostBack="True" ></asp:DropDownList></td>
                <td  align="left"><asp:Label id="Label1" class="p1" runat="server" Text="Consolidated TA Amount"></asp:Label></td>
        <td  align=left><asp:TextBox id="lblConsAmt" class="p2" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtNumeric" MaxLength="6"></asp:TextBox></td>                     

    </tr>--%><TR><TD align=left><asp:Label id="lblAmt" class="p1" runat="server" Text="Current Subscription Amount"></asp:Label></TD><TD align=left><asp:TextBox id="txtCSubnAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" MaxLength="7" AutoPostBack="True" ReadOnly="True" Cssclass="txtNumericFloat"></asp:TextBox> </TD><TD align=left><asp:Label id="Label3" class="p1" runat="server" Text="Proposed Subscription Amount"></asp:Label></TD><TD align=left><asp:TextBox id="txtPSubnAmt" oncopy="return false" class="p2" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" MaxLength="5" CssClass="txtNumeric"></asp:TextBox></TD></TR><TR><TD align=center colSpan=4><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="64px" Text="Save"></asp:Button> </TD></TR><TR><TD style="WIDTH: 494px" colSpan=4><asp:LinkButton id="btnSec" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to inbox" PostBackUrl="~/Contents/InboxMembership.aspx" Visible="False" Height="23px" OnClick="btnSec_Click"></asp:LinkButton></TD></TR></TBODY></TABLE><asp:Panel style="Z-INDEX: 100; LEFT: 700px; POSITION: absolute; TOP: 220px" id="pnlEmpDet" runat="server" Visible="false" BackColor="#CCD0E6">&gt; <DIV><TABLE borderColor=white cellSpacing=0 cellPadding=0 width="50%" border=1><TBODY><TR><TD class="p2" align=center colSpan=2>Employee details</TD></TR><TR><TD class="p2" align=center colSpan=2><asp:LinkButton id="LinkButton1" runat="server" Font-Bold="True" BackColor="Transparent" Font-Size="X-Small" Font-Names="Verdana">Annual Statement</asp:LinkButton> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="70%"><asp:Label id="Label6" class="p1" runat="server" Text="PF No."></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:Label id="lblPFNo" class="p4" runat="server"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 21px" align=left width="70%"><asp:Label id="lblbp" class="p1" runat="server" Text="Basic Pay"></asp:Label> </TD><TD style="WIDTH: 104px; HEIGHT: 21px"><asp:Label id="lblBPay" class="p4" runat="server"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblCr" class="p1" runat="server" Text="Eligible Credit"></asp:Label> </TD><TD style="WIDTH: 104px"><asp:Label id="lblPFCr" class="p4" runat="server"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 40px" align=left><asp:Label id="Label7" class="p1" runat="server" Text="Maximum eligible Loan Amount"></asp:Label> </TD><TD style="WIDTH: 104px"><asp:Label id="lblAdmloan" class="p4" runat="server"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblLoan" class="p1" runat="server" Text="Loan Outstanding"></asp:Label> </TD><TD style="WIDTH: 104px"><asp:Label id="lblLoanOutstnd" class="p4" runat="server"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblDB" class="p1" runat="server" Text="DOB"></asp:Label></TD><TD style="WIDTH: 104px"><asp:Label id="lblDBirth" class="p4" runat="server"></asp:Label></TD></TR><TR><TD style="HEIGHT: 21px" align=left><asp:Label id="lblJD" class="p1" runat="server" Width="116px" Text="Date of Joining"></asp:Label></TD><TD style="WIDTH: 104px"><asp:Label id="lblJoinDate" class="p4" runat="server"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lblDEn" class="p1" runat="server" Text="Date of Enrollment"></asp:Label></TD><TD style="WIDTH: 104px"><asp:Label id="lblDEnroll" class="p4" runat="server"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lblRet" class="p1" runat="server" Text="Date of Retirement"></asp:Label></TD><TD style="WIDTH: 104px"><asp:Label id="lblDRetire" class="p4" runat="server"></asp:Label></TD></TR><TR><TD align=center colSpan=2><asp:Button id="OkBtn" class="button" onclick="OkBtn_Click" runat="server" Width="43px" Text="Ok"></asp:Button> </TD></TR><TR><TD align=center colSpan=2><asp:Label id="lblpnlerr" runat="server" ForeColor="Red" Font-Size="Smaller" Font-Names="Verdana"></asp:Label></TD></TR></TBODY></TABLE></DIV></asp:Panel> 
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
   
	</script>
--%></asp:Content>

