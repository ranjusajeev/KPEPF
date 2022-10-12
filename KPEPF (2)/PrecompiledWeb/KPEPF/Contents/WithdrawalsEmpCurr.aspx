<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_WithdrawalsEmpCurr, App_Web_m1ijyhfm" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=5>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Withdrawals_Employee"></asp:Label> </TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD style="HEIGHT: 18px" align=center colSpan=4>&nbsp;<asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Label id="lblDT" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Label id="lblBillNo" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Label id="lblBillDt" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp; &nbsp;&nbsp; <asp:Label id="lblmm" runat="server" Text=" " CssClass="p6"></asp:Label> </TD></TR>
      <TR align="left"><TD colspan="8" ><asp:LinkButton id="lnkChal" onclick="lnkChal_Click" runat="server" Font-Bold="True" Font-Size="10pt">New Withdrawal</asp:LinkButton>
        </TD>
   </TR>    
    <TR><TD style="HEIGHT: 188px" vAlign=top colSpan=5><DIV style="OVERFLOW-X: auto; WIDTH: 900px">  
    <asp:GridView ID="gdvChalanS" runat="server" ForeColor="#333333" Width="2500px" OnRowDataBound="gdvChalanS_RowDataBound" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" Font-Size="10pt" Font-Names="Verdana">
        <RowStyle BackColor="#EFF3FB"></RowStyle>
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="numWithdrawalID,numBillID,fltBillAmount,flgBillType,intTreasuryId" DataNavigateUrlFormatString="~/Contents/WithdrawalsEmpCurr.aspx?numWithdrawalID={0}&amp;numBillID={1}&amp;fltBillAmount={2}&amp;flgBillType={3} &amp;intTreasuryId={4} " DataTextField="SlNo" HeaderText="Sl No">
                <ItemStyle Width="60px" />
            </asp:HyperLinkField>
            <asp:BoundField HeaderText="AccNo" DataField="chvPF_No" ><ItemStyle Width="100px" /></asp:BoundField>
            <asp:BoundField DataField="chvName" HeaderText="Name" ><ItemStyle Width="240px" /></asp:BoundField>
            <asp:BoundField DataField="chvDesignation" HeaderText="Designation"><ItemStyle Width="250px" /> </asp:BoundField>
            <asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" ><ItemStyle Width="350px" /></asp:BoundField>
            <asp:BoundField DataField="fltAllottedAmt" HeaderText="Amount"><ItemStyle Width="70px" /></asp:BoundField>
            <asp:TemplateField HeaderText="Advance Amount" Visible="False">              
                <ItemTemplate>
                    <asp:TextBox ID="txtAmt" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="7" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" OnTextChanged="txtAmt_TextChanged" TabIndex="4" Text='<%#Eval("fltAllottedAmt") %>' Width="71px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="charType" HeaderText="By"><ItemStyle Width="50px" /> </asp:BoundField>
            <asp:BoundField DataField="chvLoanType" HeaderText="Type" ><ItemStyle Width="80px"/> </asp:BoundField>
            <asp:BoundField DataField="chvOrderNo" HeaderText="Odr No" ><ItemStyle Width="100px" /> </asp:BoundField>
            <asp:BoundField DataField="sanctiondate" HeaderText="Odr Date" ><ItemStyle Width="80px" /> </asp:BoundField>
            <asp:BoundField DataField="chvLoanPurpose" HeaderText="Object" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="chvOdrNoDtOfPrevTA" HeaderText="Odr PrevTA" />
            <asp:BoundField DataField="fltamtPrevTA" HeaderText="Amt Pr TA" />
            <asp:BoundField DataField="fltbalancePrevTA" HeaderText="Balance Pr TA" />
            <asp:BoundField DataField="fltconsolidatedAmt" HeaderText="Cons. Amt" />
            <asp:BoundField DataField="intnoOfInstalment" HeaderText="Inst" ><ItemStyle Width="40px" /></asp:BoundField>
            <asp:BoundField DataField="fltamtinstalment" HeaderText="Inst MT"><ItemStyle Width="80px" /> </asp:BoundField>
            <asp:BoundField DataField="dtmDateOfWith" HeaderText="With Date" />
            <asp:TemplateField HeaderText="UnP">
                <ItemTemplate>                  
                     <asp:CheckBox ID="chkUnPo" runat="server" Width="25px" Enabled="false" ></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="chvReason" HeaderText="Reason" />
        </Columns>

        <FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    </asp:GridView> </DIV>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server" Width="100px" Text="Back " Height="20px"></asp:Button>
         <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="100px" Text="Save" Height="20px"></asp:Button>

        </TD></TR>

 <%--   <tr>
        <td align="left" colspan="2"><asp:Button ID="btnBack" OnClick="btnBack_Click" runat="server" Width="102px" Text="Back " Height="19px"></asp:Button>
        </td>
        <td style="WIDTH: 855px" align="center" colspan="2">
            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="67px" Text="Save"></asp:Button>
        </td>
    </tr>--%>


        <tr>
        <td style="WIDTH: 908px" colspan="8">
            <AjaxExt:ModalPopupExtender ID="Mdlchl" runat="server"  CancelControlID="" OkControlID="btnCan" TargetControlID="btnCan" PopupControlID="pnlChalNew" BackgroundCssClass="ModalPopUpBG"></AjaxExt:ModalPopupExtender>


            <asp:Panel Style="DISPLAY: none" ID="pnlChalNew" runat="server" Width="800px" BackColor="LightGray">
            <%--<asp:Panel  ID="pnlChalNew" runat="server" Width="800px" BackColor="LightGray" Visible="false">--%>
                <div>
                    <table>
                        <tbody>
                            <tr align="center"><td>&nbsp;&nbsp;</td>
                                <td style="HEIGHT: 18px" class="p1" align="center" colspan="8">Withdrawal details</td>
                            </tr>
                            <tr>
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="lblchlId" runat="server" Text="id." Visible="False"></asp:Label>
                                    <asp:Label ID="lblEditMode" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblDtOld" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                 <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label15" class="p1" runat="server" Text="AccountNumber"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:TextBox ID="txtAccNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" BorderStyle="None" CssClass="txtNumeric" OnTextChanged="txtAccNo_TextChanged1" AutoPostBack="True" MaxLength="5"  Text='<%# Eval("chvPF_No") %>' Width="150px" ></asp:TextBox>
                                </td>
                         
                                 <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label14" class="p1" runat="server" Text="Name"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:Label ID="lblName" class="p1" runat="server" Text='<%# Eval("chvName") %>' ></asp:Label>
                                </td>
                               <%-- <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:TextBox ID="txtChalNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="7">0</asp:TextBox>
                                </td>--%>
                            </tr>
                            <tr>
                                 <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label1" class="p1" runat="server" Text="Designation"></asp:Label>
                                </td>
                                  <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:DropDownList ID="ddldesig" runat="server" Width="150px"></asp:DropDownList>
                                </td>
                       
                                   <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label2" class="p1" runat="server" Text="Localbody"></asp:Label>
                                </td>
                                  <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:DropDownList ID="ddlLB" runat="server" Width="190px"></asp:DropDownList>
                                </td>
                          </tr>
                               <%-- <td style="HEIGHT: 21px" align="left" width="90%">
                                    <asp:Label ID="Label1" class="p1" runat="server" Text="Date"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:TextBox ID="txtChalDt" runat="server" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtChalDt_TextChanged">
                                    </asp:TextBox>
                                </td>--%>
                      
                            <tr>
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label5" class="p1" runat="server" Text="Advance Amount"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:TextBox ID="txtAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" OnTextChanged="txtAmt_TextChanged" AutoPostBack="True" MaxLength="7" Text='<%#Eval("fltAllottedAmt") %>' Width="150px"></asp:TextBox>
                                </td>
                          
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="lbldrwn" runat="server" Text="Drawn by" CssClass="p1"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:DropDownList ID="drwnby" runat="server" Width="190px"></asp:DropDownList>
                                </td>
                            </tr>


                            <tr>
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Labe3" runat="server" Text="WithdrawalType" CssClass="p1"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:DropDownList ID="ddlType" runat="server" Width="150px" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </td>
                          
                  
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="lbltype" runat="server"  CssClass="p1" > OrderNo</asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:TextBox ID="txtorderNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="190px" ></asp:TextBox>
                                </td>
                            </tr>


                            <tr>
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="LblFrm" class="p1" runat="server" Text="Order Date"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                   <asp:TextBox ID="txtSDate"  oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="datePicker" MaxLength="10" AutoPostBack="True" OnTextChanged="txtSDate_TextChanged"  Text='<%# Eval("sanctiondate") %>' Width="150px"></asp:TextBox>
                                </td>
                          
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label3" class="p1" runat="server" Text="Object of Advance" Width="190px"></asp:Label>
                                </td>
                              <%--  <td style="WIDTH:224px; HEIGHT: 21px">
                                    <asp:DropDownList ID="ddlobj" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="ddlobj_SelectedIndexChanged">
                                    </asp:DropDownList>

                                </td>--%>
                                     <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:DropDownList ID="ddlobj" runat="server" Width="190px"  AutoPostBack="True"  OnSelectedIndexChanged="ddlobj_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                       

                            </tr>

                              <tr>
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label4" runat="server" Text="OrderNo &amp;Date of PrevTA" CssClass="p1" ></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:TextBox ID="txtprevtaDt" Text='<%# Eval("chvOdrNoDtOfPrevTA") %>'  runat="server"  MaxLength="20" Width="150px"></asp:TextBox>
                                </td>
                          
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label6" runat="server" Text="Amt of Prev TA" CssClass="p1"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:TextBox ID="txtprevTaAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True"  MaxLength="7"  OnTextChanged="txtprevTaAmt_TextChanged" Text='<%# Eval("fltamtPrevTA") %>'></asp:TextBox>
                                </td>
                            </tr>


                             <tr>
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label9" runat="server" Text="Balance of Prev TA" CssClass="p1"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:TextBox ID="txtprevTABal" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True"  MaxLength="7"  OnTextChanged="txtprevTABal_TextChanged"  Text='<%# Eval("fltbalancePrevTA") %>' Width="150px"></asp:TextBox>
                                </td>
                           
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label10" runat="server" Text="Consolidated Amt" CssClass="p1"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:TextBox ID="txtconsAmt" ReadOnly="True" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True"  MaxLength="7"  OnTextChanged="txtprevTABal_TextChanged"  Text='<%# Eval("fltconsolidatedAmt") %>'></asp:TextBox>
                                </td>
                            </tr>


                               <tr>
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label11" runat="server" Text="No of instalment" CssClass="p1"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:TextBox ID="txtinstNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True"  MaxLength="2"  OnTextChanged="txtinstNo_TextChanged"   Text='<%# Eval("intnoOfInstalment") %>' Width="150px"></asp:TextBox>
                                </td>
                          
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label12" runat="server" Text="Amt of inst" CssClass="p1"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:TextBox ID="txtinstAmt" ReadOnly="True" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True"  MaxLength="7"  OnTextChanged="txtinstNo_TextChanged"   Text='<%# Eval("fltamtinstalment") %>'></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label7" class="p1" runat="server" Text="Unposted"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:CheckBox ID="chkUnP" runat="server" AutoPostBack="True" OnCheckedChanged="chkUnP_CheckedChanged"></asp:CheckBox>
                                </td>
                            
                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label8" class="p1" runat="server" Text="Reason"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                    <asp:DropDownList ID="ddlUnP" runat="server" Enabled="False" >
                                    </asp:DropDownList>
                                </td>
                           </tr>
                            <tr>

                                <td style="HEIGHT: 21px" align="left" width="50%">
                                    <asp:Label ID="Label17" class="p1" runat="server" Text="Date of Withdrawal"></asp:Label>
                                </td>
                                <td style="WIDTH: 104px; HEIGHT: 21px">
                                     <asp:TextBox id="txtWithDt" runat="server" Width="150px" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtWithDt_TextChanged" MaxLength="10"></asp:TextBox>
                                </td>
                                <td style="HEIGHT: 21px" align="left" width="50%"></td><td style="WIDTH: 104px; HEIGHT: 21px"></td>
                           </tr>

                            <tr><td></td></tr><tr><td align="center" colspan="6" style="HEIGHT: 21px">
                            <asp:Button ID="btnNewEmp" runat="server" Height="20px" OnClick="btnNewEmp_Click" Text="Save" Width="55px" />
                            <asp:Button ID="btnCan" runat="server" Height="20px" OnClick="btnCan_Click" Text="Cancel" Width="55px" />
                            <asp:Button ID="btnDelN" runat="server" Height="20px" OnClick="btnDelN_Click" onclientclick="return DeleteItem()" Text="Delete" Width="55px" />
                            </td></tr>
                            <tr>
                                <td style="HEIGHT: 21px" align="left" colspan="8" width="50%">
                                    <asp:Label ID="Label13" runat="server" class="p1" Text="Withdraw Date" Visible="false"></asp:Label>
                                    <asp:TextBox ID="txtWDate" runat="server" AutoPostBack="True" CssClass="datePicker" MaxLength="10" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" ReadOnly="true" text='<%# Eval("dtmDateOfWith") %>' Visible="false" Width="150px"></asp:TextBox>
                                    <asp:Label ID="lblNewAcc" runat="server" class="p1" Text='<%# Eval("numEmpId") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblOldAcc" runat="server" class="p1" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="lblOldAmt" runat="server" class="p1" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="lblWithId" runat="server" class="p1" Text='<%#Eval("numWithdrawalID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblWithIdPfo" runat="server" class="p1" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="lblEditMod" runat="server" class="p1" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="lblBillId" runat="server" class="p1" Text='<%# Eval("numWithdrawalID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblOMnth" runat="server" class="p1" Visible="false"></asp:Label>
                                    <asp:Label ID="lblWMnth" runat="server" class="p1" Visible="false"></asp:Label>
                                    <asp:Label ID="lblsanctnYrOld" runat="server" class="p1" Visible="false"></asp:Label>
                                    <asp:Label ID="lblNw" runat="server" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="lblOl" runat="server" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="lblOType" runat="server" Text="0" Visible="false"></asp:Label>
                                </td>
                            </tr>

                        </tbody>
                    </table>
                </div>
            </asp:Panel>
        
               </td>
    </tr>
  


                           </TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
<%--    <script language="javascript" type="text/javascript">
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
    function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
        
        function checkNumOnly(input)
{
   $(input).bind('keyup blur', function () { $(this).val($(this).val().replace(/[^0-9.]/g, '')) }); 
   return true;
}
	</script>
--%></asp:Content>



