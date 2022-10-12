<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_WithdrawalsPDEPrev, App_Web_1la5evxf" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>

        <TABLE style="WIDTH: 100%"><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="Label7" class="MnHead" runat="server" Text="Withdrawals_Treasury"></asp:Label> </TD></TR>
    <TR><TD >
        <table>
            <tr><td> <asp:Label id="Label10" runat="server" Text="Year" CssClass="p1" Width="150px"></asp:Label>     </td>
                <TD style="align: left"><asp:DropDownList id="ddlYear" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList></TD>
            </tr>

            <tr><td> <asp:Label id="Label11" runat="server" Text="Month" Width="150px" CssClass="p1"></asp:Label>     </td>
                <TD style="align: left"><asp:DropDownList id="ddlMnth" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlMnth_SelectedIndexChanged"></asp:DropDownList></TD>
            </tr>
          
<%--            <tr><td> <asp:Label id="lblInti" runat="server" CssClass="p1" text="Intimation Date" Width="150px"></asp:Label>    </td>
                <TD style="align: left"><asp:TextBox id="txtInt" runat="server" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtInt_TextChanged" width="150px"></asp:TextBox></TD>
            </tr>

            <tr><td> <asp:Label id="lblRem" runat="server" CssClass="p1" text="Remarks" Width="150px"></asp:Label>   </td>
                <TD style="align: left"><asp:TextBox id="txtRem" runat="server" Width="150px"></asp:TextBox></TD>
            </tr>--%>

        </table>
        </TD>
        <TD >
        <table>
            <tr><td> <asp:Label id="Label12" runat="server" Text="District" CssClass="p1" Width="150px"></asp:Label>     </td>
                <TD style="align: left"><asp:DropDownList id="ddldist" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddldist_SelectedIndexChanged"></asp:DropDownList></TD>
            </tr>

            <tr><td> <asp:Label id="Label13" runat="server" Text="District Treasury" CssClass="p1"></asp:Label>    </td>
                <TD style="align: left"><asp:DropDownList id="ddlDT" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlDT_SelectedIndexChanged"></asp:DropDownList></TD>
            </tr>
           <%-- <tr>
               <td><asp:Label id="lblStat" runat="server" CssClass="p4" text="..."></asp:Label>  </td>
            </tr>--%>
<%--            <tr><td> <asp:Label id="lblAmt" runat="server" CssClass="p1" text="Amount"></asp:Label></asp:Label>     </td>
                <TD style="align: left"><asp:TextBox id="txtAmt" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="150px" CssClass="txtNumeric" MaxLength="8"></asp:TextBox></TD>
            </tr>

            <tr><td> <asp:Button id="Button1" onclick="btnSave_Click" runat="server" Width="60px" Height="21px" Text="Save"></asp:Button>     </td>
               <td><asp:Label id="lblStatus" runat="server" CssClass="p4" text="..."></asp:Label>  </td>
            </tr>--%>

        </table>
        </TD>
    </TR>
    </TABLE>
<TABLE style="WIDTH: 100%"><TBODY>
       <tr>
               <td align="center" colspan="4"><asp:Label id="lblStat" runat="server" CssClass="p4" text="..."></asp:Label>  </td>
            </tr>
    <TR><TD align="left" colspan="4"><asp:LinkButton id="lnkChal" onclick="lnkChal_Click" runat="server" Font-Bold="True" Enabled="False" Font-Size="10pt">New Bill</asp:LinkButton></TD>   </TR>
    
    <TR>
        <td colspan="4" style="WIDTH: 900px" valign="top">
            <asp:GridView ID="gdvChalanLB" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="850px">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="intBillWiseId" DataNavigateUrlFormatString="~/Contents/WithdrawalsPDEPrev.aspx?intBillWiseId={0}" DataTextField="SlNo" HeaderText="Sl No."></asp:HyperLinkField>
                    <asp:HyperLinkField DataNavigateUrlFields="intBillWiseId,fltNetAmt,dtmBillDate" DataNavigateUrlFormatString="~/Contents/WithdrawalsPDEEmp.aspx?intBillWiseId={0}&amp;fltNetAmt={1}&amp;dtmBillDate={2}" DataTextField="intBillNo" HeaderText="Bill No.">
                        <ItemStyle Width="160px" />
                    </asp:HyperLinkField>
                    <asp:TemplateField HeaderText="Bill Date">
                        <ItemTemplate>
                            <asp:TextBox ID="txtBDate" runat="server" __designer:wfdid="w11" CssClass="datePicker" Enabled="False" ReadOnly="True" Width="158px"></asp:TextBox>
                        </ItemTemplate> <ItemStyle Width="160px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <asp:TextBox ID="txtAmt" runat="server" __designer:wfdid="w8" CssClass="txtNumeric" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" ReadOnly="True" Width="158px"></asp:TextBox>
                        </ItemTemplate> <ItemStyle Width="160px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unposted">
                        <%--<HeaderTemplate>
                            <asp:CheckBox ID="Allchk" runat="server" AutoPostBack="True" OnCheckedChanged="Allchk_CheckedChanged" Text="Unposted" />
                        </HeaderTemplate>--%>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkApp" runat="server" __designer:wfdid="w9" Enabled="False" OnCheckedChanged="chkApp_CheckedChanged" Width="78px" />
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unposted reason">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlReason" runat="server" __designer:wfdid="w10" Enabled="False" width="168px">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <HeaderStyle Font-Names="Verdana" Font-Size="Small" Width="170px" />
                        <ItemStyle HorizontalAlign="Left" Width="50px" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" Wrap="True" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
    </TR><TR><TD style="WIDTH: 908px" colSpan=8>
        <AjaxExt:ModalPopupExtender ID="mdlConfirm" runat="server" BackgroundCssClass="ModalPopUpBG" CancelControlID="" OkControlID="btnCan" PopupControlID="pnlChalNew" TargetControlID="btnCan">
        </AjaxExt:ModalPopupExtender>
        <asp:Panel ID="pnlChalNew" runat="server" BackColor="LightGray" style="DISPLAY: none" Width="300px">
            <div>
                <table>
                    <tbody>
                        <tr>
                            <%--<td align="center" class="p1" colspan="10" style="HEIGHT: 16px ">Bill Details</td>--%>
                            <td></td>
                            <td align="center" class="p1" colspan="10" >Bill Details</td>
                            
                        </tr><tr><td></td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblWthConsId" runat="server" Text="id." Visible="False"></asp:Label>
                                <asp:TextBox ID="txtWthConsId" runat="server" BorderStyle="None" Visible="False" Width="2px">0</asp:TextBox>
                                <asp:Label ID="lblBilId" runat="server" Text="id." Visible="False"></asp:Label>
                                <asp:TextBox ID="txtBillId" runat="server" BorderStyle="None" Visible="False" Width="2px">0</asp:TextBox>
                            </td>
                            <td style="WIDTH: 165px">
                                <asp:Label ID="lblgrpId" runat="server" Text="id." Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGrpId" runat="server" BorderStyle="None" Visible="False" Width="2px">0</asp:TextBox>
                            </td>
                            <td style="WIDTH: 12px">
                                <asp:Label ID="lblSchMainId" runat="server" Text="id." Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSchMainId" runat="server" BorderStyle="None" Visible="False" Width="2px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbleditmde" runat="server" Text="id." Visible="False"></asp:Label>
                            </td>
                            <td style="WIDTH: 165px">
                                <asp:Label ID="lblEditMode" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Year1" runat="server" Text="Year." Visible="False"></asp:Label>
                            </td>
                            <td style="WIDTH: 12px">
                                <asp:Label ID="lblYr" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Monthd" runat="server" Text="Month." Visible="False"></asp:Label>
                            </td>
                            <td style="WIDTH: 7px">
                                <asp:Label ID="lblMonth" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="dy" runat="server" Text="Day." Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDy" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                            <td style="WIDTH: 7px">
                                <asp:TextBox ID="txtOldAmt" runat="server" BorderStyle="None" Visible="False" Width="20px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                <asp:Label ID="lblSd" runat="server" CssClass="p1" Text="AccountingDate"></asp:Label>
                            </td>
                            <td style="WIDTH: 158px; HEIGHT: 21px">
                                <asp:DropDownList ID="ddlsubd" runat="server" OnSelectedIndexChanged="ddlsubd_SelectedIndexChanged" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                <asp:Label ID="Label6" runat="server" class="p1" Text="No."></asp:Label>
                            </td>
                            <td style="WIDTH: 165px; HEIGHT: 21px">
                                <asp:TextBox ID="txtBillNo" runat="server"  Width="150px" CssClass="txtNumeric" MaxLength="7" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                <asp:Label ID="Label1" runat="server" class="p1" Text="Date"></asp:Label>
                            </td>
                            <td style="WIDTH: 165px; HEIGHT: 21px">
                                <asp:TextBox ID="txtBillDt" runat="server"  Width="150px" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtChalDt_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                <asp:Label ID="Label5" runat="server" class="p1" Text="Amount"></asp:Label>
                            </td>
                            <td style="WIDTH: 165px; HEIGHT: 21px">
                                <asp:TextBox ID="txtbillAmt" runat="server"  Width="150px" CssClass="txtNumeric" MaxLength="7" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"></asp:TextBox>
                            </td>
                        </tr>



                        <tr>
                            <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                <asp:Label ID="Label8" runat="server" class="p1" Text="Unposted"></asp:Label>
                            </td>
                            <td style="WIDTH: 165px; HEIGHT: 21px">
                                <asp:CheckBox ID="chkUpN" runat="server" AutoPostBack="True" OnCheckedChanged="chkUpN_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                <asp:Label ID="Label9" runat="server" class="p1" Text="Reason"></asp:Label>
                            </td>
                            <td style="WIDTH: 165px; HEIGHT: 21px">
                                <asp:DropDownList ID="ddlRsnN" runat="server" Width="150px" Enabled="False">
                                </asp:DropDownList>
                            </td>
                        </tr>



                        <tr>
                            <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                <asp:Label ID="lblStreas" runat="server" CssClass="p1" Text="SubTreasury" Visible="False"></asp:Label>
                            </td>
                            <td style="WIDTH: 165px; HEIGHT: 21px">
                                <asp:DropDownList ID="ddlsubTreas" runat="server" Visible="False" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>

                         <tr >
                            <td align="center" colspan="9" >
                                <asp:Button ID="btnNewChal" runat="server" CssClass="cssCoonfirmButton" onclick="btnNewChal_Click" Text="Save" Width="55px" Height="20px"/>
                                <asp:Button ID="btnDel" runat="server" onclick="btnDel_Click" Text="Delete" Width="55px" Height="20px"/>
                                <asp:Button ID="btnCan" runat="server" onclick="btnCan_Click" Text="Cancel" Width="55px" Height="20px"/>
                            </td>
                        </tr>

                        <tr>
                            <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                <asp:Label ID="Labe3" runat="server" CssClass="p1" Text="Localbody" Visible="False"></asp:Label>
                            </td>
                            <td style="WIDTH: 165px; HEIGHT: 21px">
                                <asp:DropDownList ID="ddlLBNew" runat="server" Visible="False" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>

                       <%-- <tr >
                            <td align="center" colspan="9" >
                                <asp:Button ID="btnNewChal" runat="server" CssClass="cssCoonfirmButton" onclick="btnNewChal_Click" Text="Save" Width="55px" />
                                <asp:Button ID="btnDel" runat="server" onclick="btnDel_Click" Text="Delete" Width="55px" />
                                <asp:Button ID="btnCan" runat="server" onclick="btnCan_Click" Text="Cancel" Width="55px" />
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                <asp:Label ID="lblNw" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                            <td style="WIDTH: 165px; HEIGHT: 21px">
                                <asp:Label ID="lblOl" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </asp:Panel>
        </TD></TR><TR><TD colSpan=2> </TD>
        <td colspan="2" style="WIDTH: 855px" align="center">
            <asp:Button ID="btnSave" runat="server" Enabled="False" onclick="btnSave_Click" Text="Treasury Statement" Width="137px"  Height="21px"/>
        </td>
    </TR></TBODY></TABLE>
</contenttemplate>
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
   
	</script>
--%>
</asp:Content>


