<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_TANew, App_Web_q2bqv01f" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

    <ContentTemplate></ContentTemplate>
   
<table  width=100%>
<tr>
<td align="center">

    <table>
        <tr>
            <td class="TdMnHead" colspan="4">
                <asp:Label ID="lblHead" runat="server" class="MnHead" Text="Temporary Advance"></asp:Label></td>
        </tr>
        <tr>
            <td  colspan="4" class="TdSbHead">
                <asp:Label ID="Label5" runat="server" class="p1" Text="Basic Details"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 166px; text-align: left;">
                <asp:Label ID="Inward" runat="server" class="p1" Text="Label">Inward No.</asp:Label>
            </td>
            <td style="width: 166px">
                <asp:TextBox ID="txtInwNo" runat="server" AutoPostBack="True" CssClass="txtNumeric"
                    MaxLength="5" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)"
                    onpaste="return false" OnTextChanged="txtInwNo_TextChanged" TabIndex="1"></asp:TextBox>
            </td>
            <td style="width: 166px; text-align: left;">
                <asp:Label ID="Label2" runat="server" class="p1" Text="Account No. "></asp:Label>
            </td>
            <td style="width: 350px">
                <asp:TextBox ID="txtEmpID" runat="server" AutoPostBack="True" CssClass="txtNumeric"
                    MaxLength="5" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)"
                    onpaste="return false" OnTextChanged="txtEmpID_TextChanged" TabIndex="3" Width="104px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="btnDet_Click" Text="..." />
            </td>
        </tr>
        <tr>
            <td style="width: 166px; height: 22px; text-align: left;">
                <asp:Label ID="FileNo" runat="server" class="p1" Text="Label">File No.</asp:Label>
            </td>
            <td style="width: 166px; height: 22px;">
                <asp:Label ID="txtFileNo" runat="server" Enabled="False" ></asp:Label>
            </td>
            <td style="width: 166px; height: 22px; text-align: left;">
                <asp:Label ID="lblNameAppl" runat="server" class="p1" Text="Name of Applicant"></asp:Label>
            </td>
            <td style="width: 350px; height: 22px;">
                <asp:Label ID="lblNameApplDisp" runat="server" class="p1" Text="<<>>"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 166px; text-align: left;">
                <asp:Label ID="AppDate" runat="server" class="p1" Text="Label">Application Date</asp:Label>
            </td>
            <td style="width: 166px">
                <asp:TextBox ID="txtAppDate" runat="server" CssClass="datePicker" OnTextChanged="txtAppDate_TextChanged"
                    TabIndex="2"></asp:TextBox>
            </td>
            <td align="left" style="width: 166px">
                <asp:Label ID="lblAccNo" runat="server" class="p1" Text="Designation"></asp:Label>
            </td>
            <td align="left" style="width: 350px; text-align: center;">
                <asp:Label ID="lblDesig" runat="server" class="p1" Text="<<>>"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  colspan="4" class="TdSbHead">
                <asp:Label ID="Label4" runat="server" class="p1" Text="Advance Details"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="height: 22px">
                <asp:Label ID="lblPur" runat="server" class="p1" Text="Purpose of TA"></asp:Label></td>
            <td align="left" style="height: 22px">
                <asp:DropDownList ID="ddlPurpose" runat="server" AutoPostBack="True" onchange="fnc(this);"
                    oncontextmenu="fnJumpSize(this);" TabIndex="4" ToolTip="Right click to view in full"
                    Width="155">
                </asp:DropDownList></td>
            <td align="left" style="height: 22px">
                <asp:Label ID="Label1" runat="server" class="p1" Text="Outstanding Balance"></asp:Label></td>
            <td align="left" style="width: 350px; height: 22px;">
                <asp:TextBox ID="lblConsAmt" runat="server" AutoPostBack="True" class="p2" CssClass="txtNumeric"
                    MaxLength="6" onkeypress="return  isNumberKey(event)" OnTextChanged="lblConsAmt_TextChanged"
                    ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblAmt" runat="server" class="p1" Text="Proposed Amount for TA"></asp:Label></td>
            <td align="left">
                <asp:TextBox ID="txtPropAmt" runat="server" AutoPostBack="True" CssClass="txtNumericFloat"
                    MaxLength="7" onkeypress="return  isNumberKey(event)" OnTextChanged="txtPropAmt_TextChanged"
                    TabIndex="5"></asp:TextBox>
            </td>
            <td align="left" style="height: 22px">
                <asp:Label ID="lblConsolidatedAmt" runat="server" class="p1" Text="Consolidated Amount"></asp:Label></td>
            <td align="left" style="width: 350px; height: 22px">
                <asp:TextBox ID="txtConsAmt" runat="server" AutoPostBack="True" CssClass="txtNumericFloat"
                    OnTextChanged="txtConsAmt_TextChanged" ReadOnly=""></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" style="height: 22px">
                <asp:Label ID="lblInst" runat="server" class="p1" Text="Proposed No of Installment"></asp:Label></td>
            <td align="left" style="height: 22px">
                <asp:TextBox ID="txtPropInst" runat="server" AutoPostBack="True" CssClass="txtNumeric"
                    MaxLength="2" onkeypress="return  isNumberKey(event)" OnTextChanged="txtPropInst_TextChanged"
                    TabIndex="6"></asp:TextBox></td>
            <td align="left">
                <asp:Label ID="Label3" runat="server" class="p1" Text="Monthly Repayment"></asp:Label></td>
            <td align="left" style="width: 350px">
                <asp:TextBox ID="lblRepay" runat="server" class="p2" CssClass="txtNumeric" MaxLength="5"
                    onkeypress="return  isNumberKey(event)" OnTextChanged="lblRepay_TextChanged"
                    ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left" style="height: 22px">
            </td>
            <td align="left" style="height: 22px">
            </td>
            <td align="left" style="height: 22px">
                <asp:Label ID="lblAdmAmt" runat="server" class="p1" Text="Amount of TA Admissible"></asp:Label></td>
            <td align="left" style="width: 350px; height: 22px">
                <asp:TextBox ID="txtAdmAmt" runat="server" AutoPostBack="True" CssClass="txtNumericFloat"
                    OnTextChanged="txtAdmAmt_TextChanged" ReadOnly=""></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" colspan="3">
             <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="48px" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Card" Width="54px" />
               
               <asp:Button ID="btnService" runat="server" OnClick="btnService_Click" Text="Service History"
                    Width="95px" />
                 <asp:Button ID="btnABCD" runat="server" OnClick="btnABCD_Click" Text="ABCD" Width="48px" />
                <asp:Button ID="btnUtili" runat="server" OnClick="btnUtili_Click" Text="Utilisation Certificate"
                    Width="133px" />
            </td>
                      
        </tr>
        <tr>
        <td colspan="3" style="width: 494px; height: 25px;">
        <asp:Label ID="lblut" Text="Upload Declaration form"  runat="server" Font-Italic="False" Font-Size="Small"></asp:Label>
          <asp:FileUpload ID="fpUpload" runat="server" Enabled="False" Width="199px" />
                <triggers></triggers>
                <asp:ASYNCPOSTBACKTRIGGER ControlID="btnSubmit"  EventName="Click"><asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
                    Text="Submit" Width="77px" />
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
        </td>
         <td> <div>
                <asp:PlaceHolder ID="phLinkButtons" runat="server"></asp:PlaceHolder>
            </div></td>
        </tr>
        <tr align="left">
            <td colspan="4" style="width: 494px">
                <asp:LinkButton ID="btnSec" runat="server" Font-Bold="True" ForeColor="Blue" Height="23px"
                    OnClick="btnSec_Click" PostBackUrl="~/Contents/InboxService.aspx" Text="Back to inbox"
                    Visible="False" Width="138px"></asp:LinkButton></td>
                   
        </tr>
        
    </table>
    </td>
</tr>
</table>
    <asp:Panel ID="pnlEmpDet" runat="server" BackColor="#CCD0E6" Style="z-index: 100;
        left: 700px; position: absolute; top: 220px" Visible="false">
        <div>
            <table border="1" bordercolor="white" cellpadding="0" cellspacing="0" width="50%">
                <tr>
                    <td align="center" class="p2" colspan="2">
                        Employee details</td>
                </tr>
                <tr>
                    <td align="center" class="p2" colspan="2">
                        <asp:LinkButton ID="LinkButton1" runat="server" BackColor="Transparent" Font-Bold="True"
                            Font-Names="Verdana" Font-Size="X-Small" OnClick="LinkButton1_Click">Annual Statement</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 21px" width="70%">
                        <asp:Label ID="Label6" runat="server" class="p1" Text="PF No"></asp:Label>
                    </td>
                    <td style="width: 104px; height: 21px">
                        <asp:Label ID="lblPFNo" runat="server" class="p4"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 21px" width="70%">
                        <asp:Label ID="lblbp" runat="server" class="p1" Text="Basic Pay"></asp:Label>
                    </td>
                    <td style="width: 104px; height: 21px">
                        <asp:Label ID="lblBPay" runat="server" class="p4"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblCr" runat="server" class="p1" Text="Eligible Credit"></asp:Label>
                    </td>
                    <td style="width: 104px">
                        <asp:Label ID="lblPFCr" runat="server" class="p4"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="height: 40px">
                        <asp:Label ID="Label7" runat="server" class="p1" Text="Maximum eligible Loan Amount"></asp:Label>
                    </td>
                    <td style="width: 104px">
                        <asp:Label ID="lblAdmloan" runat="server" class="p4"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblLoan" runat="server" class="p1" Text="Loan Outstanding"></asp:Label>
                    </td>
                    <td style="width: 104px">
                        <asp:Label ID="lblLoanOutstnd" runat="server" class="p4"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblDB" runat="server" class="p1" Text="DOB"></asp:Label></td>
                    <td style="width: 104px">
                        <asp:Label ID="lblDBirth" runat="server" class="p4"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left" style="height: 21px">
                        <asp:Label ID="lblJD" runat="server" class="p1" Text="Date of Joining" Width="116px"></asp:Label></td>
                    <td style="width: 104px">
                        <asp:Label ID="lblJoinDate" runat="server" class="p4"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblDEn" runat="server" class="p1" Text="Date of Enrollment"></asp:Label></td>
                    <td style="width: 104px">
                        <asp:Label ID="lblDEnroll" runat="server" class="p4"></asp:Label></td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblRet" runat="server" class="p1" Text="Date of Retirement"></asp:Label></td>
                    <td style="width: 104px">
                        <asp:Label ID="lblDRetire" runat="server" class="p4"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="OkBtn" runat="server" class="button" OnClick="OkBtn_Click" Text="Ok"
                            Width="43px" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="lblpnlerr" runat="server" Font-Names="Verdana" Font-Size="Smaller"
                            ForeColor="Red"></asp:Label></td>
                </tr>
            </table>
        </div>
    </asp:Panel>
<%--    </asp:UpdatePanel>--%>
<%-- <script type="text/javascript">
Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()
{
      jQuery(function() 
        {
        var dlg1 = jQuery("#Attachments").dialog(
                        { 
                           draggable: true, 
                           resizable: true, 
                           width: 320,
                            modal: true,
                           autoOpen: false,
                           minHeight: 10, 
                            minwidth: 10,
                            buttons: {
                                            Upload: function () 
                                            {
     
                                                $("[id*=btnUpload]").click();
   

                                            },

                                            Close: function () 

                                            {

                                                $("[id*=attachmentClose]").click();

                                            }

                                        }
                         });
          dlg1.parent().appendTo(jQuery("form"));
        });   

 });   

   </script>
    
    
    
<script type="text/javascript">    
    
    
 
function checkFileExtension(elem)  
{    
    var filePath = elem.value;     
    if (filePath.indexOf('.') == -1)      
    return false;     
    var validExtensions = new Array();    
    var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();     
     validExtensions[0]='ADE';
     validExtensions[1]='ADP';
     validExtensions[2]='BAS';
     validExtensions[3]='BAT';
     validExtensions[4]='CHM';
     validExtensions[5]='CMD';
     validExtensions[6]='COM';
     validExtensions[7]='CPL';
     validExtensions[8]='CRT';
     validExtensions[9]='EXE';
     validExtensions[10]='HLP';
     validExtensions[11]='HTA';
     validExtensions[12]='INF';
     validExtensions[13]='INS';
     validExtensions[14]='ISP';
     validExtensions[15]='JS';
     validExtensions[16]='JSE';
     validExtensions[17]='LNK';
     validExtensions[18]='MDB';
     validExtensions[19]='MDE';
     validExtensions[20]='MSC';
     validExtensions[21]='MSI';
     validExtensions[22]='MSP';
     validExtensions[23]='MST';
     validExtensions[24]='PCD';
     validExtensions[25]='PIF';
     validExtensions[26]='REG';
     validExtensions[27]='SCR';
     validExtensions[28]='SCT';
     validExtensions[29]='SHS';
     validExtensions[30]='URL';
     validExtensions[31]='VB';
     validExtensions[32]='VBE';
     validExtensions[33]='VBS';
     validExtensions[34]='WSC';
     validExtensions[35]='WSF';
     validExtensions[36]='WSH';

    for (var i = 0; i < validExtensions.length; i++)    
    { 
    //alert (ext);  
   // alert (validExtensions[i]);  
        if (ext.toUpperCase() == validExtensions[i])    
        alert('The file extension ' + ext.toUpperCase() + ' is not allowed!');    
     //   return false;    
       // return true;    
    }     
       // alert('The file extension ' + ext.toUpperCase() + ' is not allowed!');    
        //return false;
         return true; 
    }
    
    </script>
--%>
<script type="text/javascript" language="javascript" > 
function InitializeRequest(path) {
	// call server side method 
	PageMethods.SetDownloadPath(path);

	// Create an IFRAME.
	var iframe = document.createElement("iframe"); 
	iframe.src = "Downloads.aspx";

	// This makes the IFRAME invisible to the user.
	iframe.style.display = "none";

	// Add the IFRAME to the page. This will trigger
	// a request to GenerateFile now.
	document.body.appendChild(iframe); 
} 
</script>
<script type="text/javascript">
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
              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
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

