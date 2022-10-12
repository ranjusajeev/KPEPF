<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_WithdrawalsPDE, App_Web_m1ijyhfm" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Withdrawals_Treasury"></asp:Label> </TD></TR>

<TR align=center>
<TD style="WIDTH: 800px" colSpan=4>
<asp:Label id="Year" runat="server" Text="Year" CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label id="Label2" runat="server" Text="Month" CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label id="Label4" runat="server" Text="District Treasury" CssClass="p4"></asp:Label>
</TD>
</TR>

<TR><TD align=center colSpan=4><asp:Label id="lblStat" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><%--<TR><TD align=left>&nbsp;<asp:Label id="lblSTDet" runat="server" Text="..." CssClass="p4"></asp:Label></TD>&nbsp;&nbsp; <TD align=right><asp:Label id="lblSTDet2" runat="server" Text="..." CssClass="p4"></asp:Label> </TD>&nbsp;&nbsp; <TD align=right><asp:Label id="lblSTDet3" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR>
--%><TR><TD>&nbsp;</TD></TR><TR><TD align=left colSpan=2>
      <tr style="font-family: Arial">
            <td>
                <asp:LinkButton ID="lnkChal" runat="server" Font-Bold="True" Font-Size="10pt" OnClick="lnkChal_Click">New Acc. Transaction</asp:LinkButton>

                                </TD><TD align=left colSpan=2>&nbsp;<asp:Label id="lbl2" runat="server" Text="Bill Details" CssClass="p1" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblSTDet3" runat="server" Text="..." CssClass="p4" Visible="False"></asp:Label> 

                                    <asp:RadioButtonList ID="rdChecked" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="p1" OnSelectedIndexChanged="rdChecked_SelectedIndexChanged" >
        <asp:ListItem Value="1" Selected="True">Show All</asp:ListItem>
        <asp:ListItem Value="2">Checked</asp:ListItem>
        <asp:ListItem Value="3">Not Checked</asp:ListItem>
    </asp:RadioButtonList>


                                     </TD></TR><TR>
      <td colspan="2" style="HEIGHT: 188px" valign="top">
          <asp:GridView ID="gdvChalanS" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" Font-Size="11pt" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gdvChalanS_SelectedIndexChanged" ShowFooter="True">
              <RowStyle BackColor="#EFF3FB" />
              <Columns>
                   <asp:HyperLinkField DataNavigateUrlFields="intWithdrawConId" DataNavigateUrlFormatString="~/Contents/WithdrawalsPDE.aspx?intWithdrawConId={0}" DataTextField="SlNo" HeaderText="Sl No.">
                       <ItemStyle Width="80px" />
                   </asp:HyperLinkField>
                   <%--<asp:BoundField DataField="AccDate" HeaderText="Acc Date">
                       <ItemStyle Width="150px" />
                   </asp:BoundField>--%>
                   <asp:HyperLinkField DataNavigateUrlFields="intWithdrawConId,SlNo" DataNavigateUrlFormatString="~/Contents/WithdrawalsPDE.aspx?intWithdrawConId={0}&amp;SlNo={1}" DataTextField="AccDate" HeaderText="Acc Date">
                      <ItemStyle Width="100px" />
                  </asp:HyperLinkField>
                   <asp:BoundField DataField="TrnDate" HeaderText="Trn Date">
                       <ItemStyle Width="200px" HorizontalAlign="Center" />
                   </asp:BoundField>
                   <asp:BoundField DataField="fltNetAmt" HeaderText="Amount">
                       <ItemStyle HorizontalAlign="Right" Width="150px" />
                   </asp:BoundField>
                  <asp:TemplateField HeaderText="TreasuryId" Visible="False">
                      <ItemTemplate>
                          <asp:Label ID="lblTreasId" runat="server" Text="Label"></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="WithConId" Visible="False">
                      <ItemTemplate>
                          <asp:Label ID="lblWithConId" runat="server" __designer:wfdid="w2" Text="Label"></asp:Label>
                      </ItemTemplate>
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
      <td colspan="2" style="WIDTH: 864px" valign="top">
          <asp:GridView ID="gdvChalanLB" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" Font-Size="11pt" ForeColor="#333333" GridLines="None" ShowFooter="True">
              <RowStyle BackColor="#EFF3FB" />
              <Columns>
                  <asp:BoundField DataField="SlNo" HeaderText="Sl.No." Visible="False"></asp:BoundField>
                  <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkApp" runat="server" AutoPostBack="True"  />
                            </ItemTemplate>
                        </asp:TemplateField>
            <%--      <asp:BoundField DataField="dtmBillDaten" HeaderText="Bill Details">
                      <ItemStyle HorizontalAlign="Left" Width="200px" />
                  </asp:BoundField>--%>

                   <asp:HyperLinkField DataNavigateUrlFields="intBillWiseId,fltNetAmt,dtmBillDate" DataNavigateUrlFormatString="~/Contents/WithdrawalsPDEEmp.aspx?intBillWiseId={0}&amp;fltNetAmt={1}&amp;dtmBillDate={1}" DataTextField="dtmBillDaten" HeaderText="Bill Details">
                      <ItemStyle Width="180px" />
                  </asp:HyperLinkField>

                  <asp:BoundField DataField="fltNetAmt" HeaderText="Amount">
                      <ItemStyle HorizontalAlign="Right" Width="150px" />
                  </asp:BoundField>
                  <asp:TemplateField HeaderText="Trn Date" Visible="False">
                      <ItemTemplate>
                          <asp:TextBox ID="txtBillId" runat="server" Width="81px"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Unposted" Visible="False">
                      <HeaderTemplate>
                          <asp:CheckBox ID="Allchk" runat="server" AutoPostBack="True" OnCheckedChanged="Allchk_CheckedChanged" Text="Unposted" />
                      </HeaderTemplate>
                    
                  </asp:TemplateField>

              </Columns>
              <FooterStyle BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <EditRowStyle BackColor="#2461BF" Wrap="True" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
          <%--<asp:GridView ID="gdvChalanLB" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None" ShowFooter="True">
              <RowStyle BackColor="#EFF3FB" />
              <Columns>
                  <asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>
                  <asp:HyperLinkField DataNavigateUrlFields="intBillWiseId,fltNetAmt" DataNavigateUrlFormatString="~/Contents/WithdrawalsPDEEmp.aspx?intBillWiseId={0}&amp;fltNetAmt={1}" DataTextField="intBillNo" HeaderText="Bill No.">
                      <ItemStyle Width="100px" />
                  </asp:HyperLinkField>
                  <asp:TemplateField HeaderText="Bill Date">
                      <ItemTemplate>
                          <asp:TextBox ID="txtBDate" runat="server" __designer:wfdid="w3" CssClass="datePicker" Height="21px" ReadOnly="True" Width="105px"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Amount">
                      <ItemTemplate>
                          <asp:TextBox ID="txtAmt" runat="server" __designer:wfdid="w4" CssClass="txtNumeric" Height="21px" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" ReadOnly="True" Width="95px"></asp:TextBox>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Unposted">
                      <HeaderTemplate>
                          <asp:CheckBox ID="Allchk" runat="server" AutoPostBack="True" OnCheckedChanged="Allchk_CheckedChanged" Text="Unposted" />
                      </HeaderTemplate>
                      <ItemTemplate>
                          <asp:CheckBox ID="chkApp" runat="server" __designer:wfdid="w5" AutoPostBack="True" Enabled="False" OnCheckedChanged="chkApp_CheckedChanged" Width="1px" />
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Unposted reason">
                      <ItemTemplate>
                          <asp:DropDownList ID="ddlReason" runat="server" __designer:wfdid="w6" Enabled="False" width="86px">
                          </asp:DropDownList>
                      </ItemTemplate>
                      <HeaderStyle Font-Names="Verdana" Font-Size="Small" Width="50px" />
                      <ItemStyle HorizontalAlign="Left" Width="50px" />
                  </asp:TemplateField>
              </Columns>
              <FooterStyle BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <EditRowStyle BackColor="#2461BF" Wrap="True" />
              <AlternatingRowStyle BackColor="White" />
          </asp:GridView>--%>
      </td>
      </TR>
    <tr style="font-family: Arial">
            <td colspan="8" style="width: 908px">
                
                <AjaxExt:ModalPopupExtender ID="mdlConfirm" runat="server" BackgroundCssClass="ModalPopUpBG"
                    CancelControlID="" OkControlID="btnCan" PopupControlID="pnlChalNew" TargetControlID="btnCan">
                </AjaxExt:ModalPopupExtender>
                <asp:Panel ID="pnlChalNew" runat="server" BackColor="LightGray" Style="display: none"
                    Width="300px">
                    <div>
                        <table>
                            <tr align="center">
                                <td align="center" class="p1" colspan="2" style="height: 16px">
                                    New Acc. Date</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSTDetIdn" runat="server" Text="0" Visible="False"></asp:Label><asp:Label
                                        ID="lblSlNo" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEditMode" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 4px; height: 21px">
                                    <asp:Label ID="lblSd" runat="server" CssClass="p1" Text="Accounting Date"></asp:Label>
                                </td>
                                <td style="width: 158px; height: 21px">
                                    <asp:TextBox ID="txtAccDt" runat="server" AutoPostBack="True" CssClass="datePicker"
                                        OnTextChanged="txtAccDt_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 4px; height: 21px">
                                    <asp:Label ID="Label1" runat="server" CssClass="p1" Text="Transaction Date"></asp:Label>
                                </td>
                                <td style="width: 158px; height: 21px">
                                    <asp:TextBox ID="txtTrnDtn" runat="server" AutoPostBack="True" CssClass="datePicker"
                                        OnTextChanged="txtTrnDtn_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 4px; height: 21px">
                                    <asp:Label ID="Label6" runat="server" class="p1" Text="Amount"></asp:Label>
                                </td>
                                <td style="width: 158px; height: 21px">
                                    <asp:TextBox ID="txtAccAmt" runat="server" CssClass="txtNumeric" MaxLength="7" oncopy="return false"
                                        oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="height: 21px" width="90%">
                                    <asp:Button ID="btnNewChal" runat="server" CssClass="cssCoonfirmButton" OnClick="btnNewChal_Click"
                                        Text="Save" Width="55px" />
                                    <asp:Button ID="btnDell" runat="server" OnClick="btnDell_Click" Text="Delete" Width="55px" />
                                    <asp:Button ID="btnCan" runat="server" Text="Cancel" Width="55px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 4px; height: 21px">
                                    <asp:Label ID="lblNw" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>
                                <td style="width: 158px; height: 21px">
                                    <asp:Label ID="lblOl" runat="server" Text="0" Visible="False"></asp:Label>


                                </td>
                            </tr>
                           
                        </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
    <TR><TD colSpan="2" align="center">
          <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" Text="Back" Width="100px" Height="20px" />
          
              <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" Width="100px"  Height="20px" Enabled="False" />
          </TD></TR></TBODY></TABLE>
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
   
	</script>
--%>
</asp:Content>

