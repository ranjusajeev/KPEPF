<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="WithdrawalsCurr.aspx.cs" Inherits="Contents_WithdrawalsCurr" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    </asp:UpdatePanel>
    <table style="width: 100%">
        <tr>
            <td class="TdMnHead" colspan="4">
                &nbsp;<asp:Label ID="lblHead" runat="server" class="MnHead" Text="Withdrawals_Treasury"></asp:Label>
            </td>
        </tr>
        <tr style="font-family: Arial">
            <td>
                &nbsp;</td>
        </tr>
        <tr style="font-family: Arial">
            <td style="align: left">
                <asp:Label ID="YearVal" runat="server" CssClass="p4" Text="Year"></asp:Label></td>
            <td style="align: left">
                <asp:Label ID="Label2Val" runat="server" CssClass="p4" Text="Month"></asp:Label></td>
            <td style="align: left">
                <asp:Label ID="Label4Val" runat="server" CssClass="p4" Text="District Treasury"></asp:Label></td>
            <td style="align: left">
                <asp:Label ID="lblAmtBk" runat="server" CssClass="p4" Text="Amt"></asp:Label></td>
        </tr>
        <tr style="font-family: Arial">
            <td class="TdLine" colspan="4">
            </td>
        </tr>
        <tr style="font-family: Arial">
            <td>
                &nbsp;</td>
        </tr>
        <tr align="center" style="font-family: Arial">
            <td colspan="4" style="width: 100%; height: 22px">
                <asp:Label ID="lblInti" runat="server" CssClass="p1" Text="Intimation Date"></asp:Label>
                &nbsp; &nbsp;<asp:Label ID="txtInt" runat="server" CssClass="p4"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="lblAmt" runat="server"
                    CssClass="p1" Text="Amount"></asp:Label>
                &nbsp; &nbsp;<asp:Label ID="txtAmt" runat="server" CssClass="p4" Text="Amount"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="lblRem" runat="server" CssClass="p1" Text="Remarks"></asp:Label>
                &nbsp; &nbsp;<asp:Label ID="txtRem" runat="server" CssClass="p4" Text="Remarks"></asp:Label></td>
        </tr>
        <tr style="font-family: Arial">
            <td class="TdLine" colspan="4">
            </td>
        </tr>
        <tr style="font-family: Arial">
            <td>
                &nbsp;</td>
        </tr>
        <tr style="font-family: Arial">
            <td>
                <asp:LinkButton ID="lnkChal" runat="server" Font-Bold="True" Font-Size="10pt" OnClick="lnkChal_Click">New Acc. Transaction</asp:LinkButton>
            </td>
            <td align="center" colspan="2" style="height: 18px">
                &nbsp;<asp:Label ID="lblSTDet" runat="server" CssClass="p4"></asp:Label>
                &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
               <%-- <asp:CheckBox ID="chkShow" runat="server" AutoPostBack="True" CssClass="p1" OnCheckedChanged="chkShow_CheckedChanged"
                    Text="Show All" />--%>
                <asp:RadioButtonList ID="rdChecked" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="p1" OnSelectedIndexChanged="rdChecked_SelectedIndexChanged" >
        <asp:ListItem Value="1">Show All</asp:ListItem>
        <asp:ListItem Value="2">Checked</asp:ListItem>
        <asp:ListItem Value="3">Not Checked</asp:ListItem>
    </asp:RadioButtonList>
            </td>
        </tr>
        <tr style="font-family: Arial">
            <td colspan="2" style="width: 500px" valign="top">
                <asp:GridView ID="gdvChalanS" runat="server" AutoGenerateColumns="False" CellPadding="2"
                    CellSpacing="5" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None"
                    ShowFooter="True">
                    <RowStyle BackColor="#E0E0E0" ForeColor="#333333" />
                    <Columns>
                      <%--  <asp:BoundField DataField="SlNo" HeaderText="Sl.No.">
                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                        </asp:BoundField>--%>
                        <asp:HyperLinkField DataNavigateUrlFields="intTreasEntriesID" DataNavigateUrlFormatString="~/Contents/WithdrawalsCurr.aspx?intTreasEntriesID={0}" DataTextField="SlNo" HeaderText="Sl No."></asp:HyperLinkField>
                        <asp:BoundField DataField="dtmAccDate" HeaderText="Acc. Date">
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="intTreasEntriesID,SlNo" DataNavigateUrlFormatString="~/Contents/WithdrawalsCurr.aspx?intTreasEntriesID={0}&amp;SlNo={1}"
                            DataTextField="dtmTrnDate" HeaderText="Trn Date">
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="fltAmt" HeaderText="Amount">
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="Maroon" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle Wrap="True" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            <td colspan="2" style="width: 500px" valign="top">
                <asp:GridView ID="gdvChalanLB" runat="server" AutoGenerateColumns="False" CellPadding="2"
                    CellSpacing="5" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None"
                    ShowFooter="True">
                    <FooterStyle BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"
                        HorizontalAlign="Right" />
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkApp" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="numBillID,fltBillAmount" DataNavigateUrlFormatString="~/Contents/WithdrawalsEmpCurr.aspx?numBillID={0}&amp;fltBillAmount={1}"
                            DataTextField="dtBillDate" HeaderText="Bill Details">
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="fltBillAmount" HeaderText="Amount Bill">
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:BoundField>
<asp:TemplateField HeaderText="ChalanID" Visible="False"><ItemTemplate>
<asp:Label id="lblChalIdC" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChalanTp" Visible="False"><ItemTemplate>
<asp:Label id="lblChalTp" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
                        <asp:BoundField HeaderText="Amount Ind." DataField="amtW" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" />
                    <EditRowStyle BackColor="#2461BF" Wrap="True" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr style="font-family: Arial">
            <td colspan="8" style="width: 908px">
                <%--    <AjaxExt:ModalPopupExtender id="mdlConfirm" runat="server" CancelControlID="" OkControlID="btnCan" TargetControlID="btnCan" PopupControlID="pnlChalNew" BackgroundCssClass="ModalPopUpBG">
    </AjaxExt:ModalPopupExtender>--%>
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
                                    <asp:Label ID="Label2" runat="server" CssClass="p1" Text="Transaction Date"></asp:Label>
                                </td>
                                <td style="width: 158px; height: 21px">
                                    <asp:TextBox ID="txtTrnDt" runat="server" AutoPostBack="True" CssClass="datePicker"
                                        OnTextChanged="txtTrnDt_TextChanged"></asp:TextBox>
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
                                    <asp:Button ID="btnDell" runat="server" OnClick="btnDell_Click" onclientclick="return DeleteItem()" Text="Delete" Width="55px" />
                                    <asp:Button ID="btnCan" runat="server" OnClick="btnCan_Click" Text="Cancel" Width="55px" />
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
       <%-- <tr style="font-family: Arial" align="center">
            <td align="center" colspan="2">
                <asp:Button ID="btnBack" runat="server" Height="20px" OnClick="btnBack_Click" Text="Back "
                    Width="100px"/>
            </td>

            <td align="left" colspan="2" style="width: 855px">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Height="20px" Text="Save" Width="100px" />
            </td>
        </tr>--%>

         <tr align="center">
            <td align="center" colspan="2">
                <asp:Button id="btnBack" OnClick="btnBack_Click" runat="server" Width="100px" Text="Back" Height="20px"></asp:Button>
                </td>

            <td align="left" colspan="2" style="width: 855px">
                <asp:Button id="btnSave" OnClick="btnSave_Click" runat="server" Width="100px" Text="Save" Height="20px"></asp:Button>      
            </td>
        </tr>

    </table>
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
--%></asp:Content>

