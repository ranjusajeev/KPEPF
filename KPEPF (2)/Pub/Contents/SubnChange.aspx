<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_SubnChange, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<table border=0 width=100%>
<tr><td colspan="4" class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="Subscription change"></asp:Label></TD></TR>
<tr><td colspan="4" class="TdSbHead"><asp:Label id="Label5" class="p1" runat="server" Text="Basic Details"></asp:Label></TD></TR>

<tr>
        <td> <asp:Label id="Inward" class="p1" runat="server" Text="Label">Inward No.</asp:Label> </td>
        <td><asp:TextBox id="txtInwNo" oncut="return false" oncopy="return false" onpaste="return false"  runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" OnTextChanged="txtInwNo_TextChanged"></asp:TextBox> </td>
        <td><asp:Label id="Label2" class="p1" runat="server" Text="Account No. "></asp:Label> </td>
        <td><asp:TextBox id="txtEmpID" oncut="return false" oncopy="return false" onpaste="return false"  runat="server" AutoPostBack="True" OnTextChanged="txtEmpID_TextChanged" onkeypress="return  isNumberKey(event)" CssClass="txtNumeric" MaxLength="5" Width="116px"  ></asp:TextBox> 
        <asp:Button id="Button1" onclick="btnDet_Click" runat="server" text="..."></asp:Button> 
        </td>
    </tr>
    <tr>
        <td ><asp:Label id="FileNo" class="p1" runat="server" Text="Label">File No.</asp:Label> </td>
        <td ><asp:Label id="txtFileNo" runat="server"  Enabled="False"></asp:Label> </td>
        <td ><asp:Label id="lblNameAppl" class="p1" runat="server" Text="Name of Applicant"></asp:Label> </td>
        <td ><asp:Label id="lblNameApplDisp" class="p1" runat="server" Text="<<>>"></asp:Label>  </td>
    </tr>
    <tr>
        <td ><asp:Label id="AppDate" class="p1" runat="server" Text="Label">Application Date</asp:Label> </td>
        <td ><asp:TextBox id="txtAppDate" CssClass="datePicker" runat="server" OnTextChanged="txtAppDate_TextChanged"  ></asp:TextBox> </td>
         <td  align="left"><asp:Label id="lblAccNo" class="p1" runat="server" Text="Designation"></asp:Label> </td>
    <td  align="left"><asp:Label id="lblDesig" class="p1" runat="server" Text="<<>>"></asp:Label> </td>
    </tr>
<tr><td colspan="4" class="TdSbHead"><asp:Label id="Label4" class="p1" runat="server" Text="Subscription Details"></asp:Label></td></TR>



<%--<tr>
        <td  align="left"><asp:Label id="lblPur" class="p1" runat="server" Text="Current subn. amount"></asp:Label></td>
        <td  align="left"><asp:DropDownList id="ddlPurpose" Tooltip="Right click to view in full" runat="server"  oncontextmenu="fnJumpSize(this);" onchange="fnc(this);" width="155" AutoPostBack="True" ></asp:DropDownList></td>
                <td  align="left"><asp:Label id="Label1" class="p1" runat="server" Text="Consolidated TA Amount"></asp:Label></td>
        <td  align=left><asp:TextBox id="lblConsAmt" class="p2" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtNumeric" MaxLength="6"></asp:TextBox></td>                     

    </tr>--%>
    <tr>
        <td  align="left"><asp:Label id="lblAmt" class="p1" runat="server" Text="Current Subscription Amount"></asp:Label></td>
        <td  align="left"><asp:TextBox id="txtCSubnAmt" runat="server" onkeypress="return  isNumberKey(event)" MaxLength="7" Cssclass="txtNumericFloat"  oncut="return false" oncopy="return false" onpaste="return false"   AutoPostBack="True" ReadOnly="True"></asp:TextBox>
            </td>
                    <td  align="left"><asp:Label id="Label3" class="p1" runat="server" Text="Proposed Subscription Amount"></asp:Label></td>
        <td  align=left><asp:TextBox id="txtPSubnAmt" oncut="return false" oncopy="return false" onpaste="return false"  class="p2" runat="server" onkeypress="return  isNumberKey(event)" CssClass="txtNumeric" MaxLength="5"></asp:TextBox></td>                     

    </tr>

<TR><TD  colSpan=4 align="center"><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Text="Save" Width="64px"></asp:Button> </TD></TR>
<TR><TD style="WIDTH: 494px" colSpan=4><asp:LinkButton id="btnSec" runat="server" ForeColor="Blue" Font-Bold="True" Text="Back to inbox" Width="138px" Height="23px" Visible="False" PostBackUrl="~/Contents/InboxMembership.aspx"></asp:LinkButton></TD></TR></table>
<asp:Panel  id="pnlEmpDet" runat="server" BackColor="#CCD0E6" Style="z-index: 100;
        left: 700px; position: absolute; top: 220px" Visible="false">>
    <div >
    <TABLE width=50% border="1" cellpadding="0" cellspacing="0" bordercolor="white" >
    <tr><td colspan=2 align=center class=p2>Employee details</td></tr>
    <tr><td colspan=2 align=center class=p2>
        <asp:LinkButton ID="LinkButton1" runat="server" BackColor="Transparent" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small" >Annual Statement</asp:LinkButton>  </td></tr>
      <TR><TD align=left width=70% style="height: 21px"><asp:Label id="Label6" class="p1" runat="server"  Text="PF No."></asp:Label> </TD><TD style="width: 104px; height: 21px"><asp:Label id="lblPFNo" class="p4" runat="server" ></asp:Label> </TD></TR>
         
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
    </asp:Panel>


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

