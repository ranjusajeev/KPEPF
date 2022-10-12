<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="TaNraConversion.aspx.cs" Inherits="Contents_TaNraConversion" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

<asp:UpdatePanel ID="updatepanel" runat= "server">
 <ContentTemplate>
<TABLE id="TABLE1" onclick="return TABLE1_onclick()"><TBODY><TR><TD class="TdMnHead" colSpan=4 ><asp:Label id="lblHead" class="MnHead" runat="server" Text="TA to NRA Conversion"></asp:Label> </TD></TR><TR><TD class="TdSbHead" colSpan=4 height=26 ;><asp:Label id="Label5" class="p1" runat="server" Text="Basic Details">
</asp:Label></TD></TR><TR><TD style="WIDTH: 227px"><asp:Label id="Inward" class="p1" runat="server" Text="Label">Inward No</asp:Label> </TD><TD style="WIDTH: 166px"><asp:TextBox id="txtInwNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" OnTextChanged="txtInwNo_TextChanged" AutoPostBack="True" MaxLength="5" CssClass="txtNumeric"></asp:TextBox> </TD><TD style="WIDTH: 166px"><asp:Label id="Label2" class="p1" runat="server" Text="Account No. ">
</asp:Label> </TD><TD style="WIDTH: 166px"><asp:TextBox id="txtEmpID" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="104px" OnTextChanged="txtEmpID_TextChanged" AutoPostBack="True" MaxLength="5" CssClass="txtNumeric">
</asp:TextBox> <asp:Button id="Button1" onclick="btnDet_Click" runat="server" text="..."></asp:Button> </TD></TR><TR><TD style="WIDTH: 227px"><asp:Label id="FileNo" class="p1" runat="server" Text="Label">File No</asp:Label> </TD><TD style="WIDTH: 166px"><asp:Label id="txtFileNo" runat="server" Enabled="False" ></asp:Label> </TD><TD style="WIDTH: 166px"><asp:Label id="lblNameAppl" class="p1" runat="server" Text="Name of Applicant"></asp:Label> </TD><TD style="WIDTH: 166px"><asp:Label id="lblNameApplDisp" class="p1" runat="server" Text="<<>>"></asp:Label> </TD></TR><TR><TD style="WIDTH: 227px"><asp:Label id="AppDate" class="p1" runat="server" Text="Label">Application Date</asp:Label> </TD><TD style="WIDTH: 166px"><asp:TextBox id="txtAppDate" runat="server" OnTextChanged="txtAppDate_TextChanged" CssClass="datePicker"></asp:TextBox> </TD><TD style="WIDTH: 166px" align=left><asp:Label id="lblAccNo" class="p1" runat="server" Text="Designation"></asp:Label> </TD><TD style="WIDTH: 166px" align=left><asp:Label id="lblDesig" class="p1" runat="server" Text="<<>>"></asp:Label> </TD></TR><TR><TD class="TdSbHead" colSpan=4 ><asp:Label id="Label4" class="p1" runat="server" Text="Advance Details"></asp:Label></TD></TR><TR><TD><asp:Label id="lblPur" class="p1" runat="server" Text="Original Amount Of Temporary Advance "></asp:Label></TD><TD colSpan=2><asp:TextBox id="txtOriginalAmnt" runat="server" Enabled="False" ReadOnly="True" >
</asp:TextBox> </TD></TR><TR><TD style="WIDTH: 227px"><asp:Label id="lblPendInstal" class="p1" runat="server" Text="No Of Instalments Pending"></asp:Label> </TD><TD style="WIDTH: 166px"><asp:TextBox id="txtPendInstal" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 227px"><asp:Label id="lblAmntPending" class="p1" runat="server" text="Amount Of Temporary Advance Pending"></asp:Label> </TD><TD style="WIDTH: 166px"><asp:TextBox id="txtAmntPending" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 227px"><asp:Label id="lblAmntConvert" class="p1" runat="server" text="Amount Of Temporary Advance To Convert"></asp:Label> </TD><TD style="WIDTH: 166px"><asp:TextBox id="txtAmntConvert" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox> </TD></TR><TR><TD></TD><TD style="WIDTH: 200px" align=right><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="48px" Text="Save"></asp:Button> </TD></TR><TR><TD style="WIDTH: 494px" colSpan=4><asp:LinkButton id="btnSec" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to inbox" Height="23px" Visible="False" PostBackUrl="~/Contents/InboxService.aspx"></asp:LinkButton></TD></TR></TBODY></TABLE>

<asp:Panel style="Z-INDEX: 100; LEFT: 700px; POSITION: absolute; TOP: 220px" id="pnlEmpDet" runat="server" BackColor="#CCD0E6" Visible="false">
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
    <TR><TD  align=center colSpan=2><asp:Button id="OkBtn" class="button" runat="server" Width="43px" Text="Ok" OnClick="OkBtn_Click"  ></asp:Button>  </TD></TR>
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
   
	</script>



</asp:Content>

