<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_RemittancePDEPrev, App_Web_1la5evxf" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxExt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Remittance_Treasury"></asp:Label> </TD></TR>
    <TR><TD >
        <table>
            <tr><td> <asp:Label id="Year" runat="server" Text="Year" CssClass="p1" Width="150px"></asp:Label>     </td>
                <TD style="align: left"><asp:DropDownList id="ddlYear" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList></TD>
            </tr>

            <tr><td> <asp:Label id="Label2" runat="server" Text="Month" Width="150px" CssClass="p1"></asp:Label></asp:Label>     </td>
                <TD style="align: left"><asp:DropDownList id="ddlMnth" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlMnth_SelectedIndexChanged"></asp:DropDownList></TD>
            </tr>

            <tr><td> <asp:Label id="lblInti" runat="server" CssClass="p1" text="Intimation Date" Width="150px"></asp:Label>    </td>
                <TD style="align: left"><asp:TextBox id="txtInt" runat="server" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtInt_TextChanged" width="150px"></asp:TextBox></TD>
            </tr>

            <tr><td> <asp:Label id="lblRem" runat="server" CssClass="p1" text="Remarks" Width="150px"></asp:Label>   </td>
                <TD style="align: left"><asp:TextBox id="txtRem" runat="server" Width="150px"></asp:TextBox></TD>
            </tr>

        </table>
        </TD>
        <TD >
        <table>
            <tr><td> <asp:Label id="Label3" runat="server" Text="District" CssClass="p1" Width="150px"></asp:Label></asp:Label>     </td>
                <TD style="align: left"><asp:DropDownList id="ddldist" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddldist_SelectedIndexChanged"></asp:DropDownList></TD>
            </tr>

            <tr><td> <asp:Label id="Label4" runat="server" Text="District Treasury" CssClass="p1"></asp:Label></asp:Label>     </td>
                <TD style="align: left"><asp:DropDownList id="ddlDT" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlDT_SelectedIndexChanged"></asp:DropDownList></TD>
            </tr>

            <tr><td> <asp:Label id="lblAmt" runat="server" CssClass="p1" text="Amount"></asp:Label></asp:Label>     </td>
                <TD style="align: left"><asp:TextBox id="txtAmt" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="150px" CssClass="txtNumeric" MaxLength="8"></asp:TextBox></TD>
            </tr>

            <tr><td> <asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="60px" Height="21px" Text="Save"></asp:Button>     </td>
               <td><asp:Label id="lblStatus" runat="server" CssClass="p4" text="..."></asp:Label>  </td>
            </tr>

        </table>
        </TD>
    </TR>
    </TABLE>
        <TABLE style="WIDTH: 100%">
    
    <TR><TD colSpan=4>&nbsp;</TD></TR>
    <TR><TD align=center><asp:LinkButton id="lnkChal" onclick="lnkChal_Click" runat="server" Font-Bold="True" Font-Size="10pt" Width="150px" Enabled="False">New Chalan</asp:LinkButton></TD><TD align=center colSpan=4><asp:CheckBox id="chkShow" runat="server" Text="Show Grid" CssClass="p1" AutoPostBack="True" OnCheckedChanged="chkShow_CheckedChanged"></asp:CheckBox> </TD></TR><TR><TD colSpan=4></TD></TR>
    <caption>
        <tr>
            <td align="center" colspan="4" valign="top">
                <asp:GridView ID="gdvChalanLB" runat="server" Width="900px" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None" ShowFooter="True">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="intChalanId,numChalanId,intSTreasuryDetId" DataNavigateUrlFormatString="~/Contents/RemittancePDEPrev.aspx?intChalanId={0}&amp;numChalanId={1}&amp;intSTreasuryDetId={2} " DataTextField="SlNo" HeaderText="Sl No."></asp:HyperLinkField>
                        <asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
                            <ItemStyle Width="400px" />
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId" DataNavigateUrlFormatString="~/Contents/ChalanEdit.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}" DataTextField="intChalanDet" HeaderText="Chalan details">
                            <ItemStyle HorizontalAlign="Left" /><ItemStyle Width="150px" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="NetAmt" HeaderText="Amount">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="charType" HeaderText="FromWhom">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Un posted">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkApp" runat="server" AutoPostBack="True" Enabled="False" OnCheckedChanged="chkApp_CheckedChanged" Width="100px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unposted reason" Visible="False">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlReason" runat="server" Enabled="False" width="86px">
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
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="WIDTH: 908px">
                <AjaxExt:ModalPopupExtender ID="mdlConfirm" runat="server" BackgroundCssClass="ModalPopUpBG" CancelControlID="" OkControlID="btnCan" PopupControlID="pnlChalNew" TargetControlID="btnCan">
                </AjaxExt:ModalPopupExtender>
                <asp:Panel ID="pnlChalNew" runat="server" BackColor="LightGray" style="DISPLAY: none" Width="300px">
                    <div>
                        <table>
                            <tbody>
                                <tr align="center">
                                    <td align="center" class="p1" colspan="2" style="HEIGHT: 16px">New Chalan</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblchlIdTBchl" runat="server" Text="id." Visible="False"></asp:Label>
                                        <asp:TextBox ID="txtchlIdTBchl" runat="server" Text="0" BorderStyle="None" Visible="False" Width="2px">0</asp:TextBox>
                                        <asp:Label ID="lblchlId" runat="server" Text="id." Visible="False"></asp:Label>
                                        <asp:TextBox ID="txtchlnId" runat="server" Text="0" BorderStyle="None" Visible="False" Width="2px">0</asp:TextBox>
                                    </td>
                                    <td style="WIDTH: 158px">
                                        <asp:Label ID="lblgrpId" runat="server" Text="id." Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGrpId" runat="server" BorderStyle="None" Visible="False" Width="2px">0</asp:TextBox>
                                    </td>
                                    <td>
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
                                    <td>
                                        <asp:Label ID="lblEditMode" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Year1" runat="server" Text="Year." Visible="False"></asp:Label>
                                    </td>
                                    <td>
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
                                    <td style="WIDTH: 158px; HEIGHT: 21px">
                                        <asp:TextBox ID="txtChalNo" runat="server" Width="150px" CssClass="txtNumeric" MaxLength="7" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                        <asp:Label ID="Label1" runat="server" class="p1" Text="Date"></asp:Label>
                                    </td>
                                    <td style="WIDTH: 158px; HEIGHT: 21px">
                                        <asp:TextBox ID="txtChalDt" runat="server" Width="150px" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtChalDt_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                        <asp:Label ID="Label5" runat="server" class="p1" Text="Amount"></asp:Label>
                                    </td>
                                    <td style="WIDTH: 158px; HEIGHT: 21px">
                                        <asp:TextBox ID="txtChalAmt" runat="server" Width="150px" CssClass="txtNumeric" MaxLength="7" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                        <asp:Label ID="lblStreas" runat="server" CssClass="p1" Text="SubTreasury"></asp:Label>
                                    </td>
                                    <td style="WIDTH: 158px; HEIGHT: 21px">
                                        <asp:DropDownList ID="ddlsubTreas" runat="server" OnSelectedIndexChanged="ddlsubTreas_SelectedIndexChanged" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                        <asp:Label ID="Labe3" runat="server" CssClass="p1" Text="Localbody"></asp:Label>
                                    </td>
                                    <td style="WIDTH: 158px; HEIGHT: 21px">
                                        <asp:DropDownList ID="ddlLBNew" runat="server" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                        <asp:Label ID="Label8" runat="server" class="p1" Text="Unposted"></asp:Label>
                                    </td>
                                    <td style="WIDTH: 158px; HEIGHT: 21px">
                                        <asp:CheckBox ID="chkUpN" runat="server"  AutoPostBack="True" OnCheckedChanged="chkUpN_CheckedChanged" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                        <asp:Label ID="Label9" runat="server" class="p1" Text="Reason"></asp:Label>
                                    </td>
                                    <td style="WIDTH: 158px; HEIGHT: 21px">
                                        <asp:DropDownList ID="ddlRsnN" Width="150px" runat="server" OnSelectedIndexChanged="ddlRsnN_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="HEIGHT: 21px" width="90%">
                                        <asp:Label ID="LblFrm" runat="server" class="p1" Text="FromWhom"></asp:Label>
                                    </td>
                                    <td style="WIDTH: 104px; HEIGHT: 21px">
                                        <asp:DropDownList ID="ddlFrm" runat="server" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="HEIGHT: 21px" width="90%">
                                        <asp:Button ID="btnNewChal" runat="server" CssClass="cssCoonfirmButton" onclick="btnNewChal_Click" Text="Save" Width="55px" Height="20px"/>
                                        <asp:Button ID="btnDel" runat="server" onclick="btnDel_Click" Text="Delete" Width="55px" Height="20px"/>
                                        <asp:Button ID="btnCan" runat="server" onclick="btnCan_Click" Text="Cancel" Width="55px" Height="20px"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="WIDTH: 4px; HEIGHT: 21px">
                                        <asp:Label ID="lblNw" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                    <td style="WIDTH: 158px; HEIGHT: 21px">
                                        <asp:Label ID="lblOl" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td colspan="2" style="WIDTH: 855px" align="center">
                <asp:Button ID="btnTreasRpt" runat="server" onclick="btnTreasRpt_Click" Text="Treasury Statement" Height="20px" Width="132px" />
            </td>
        </tr>
        </TBODY>
    </caption>
        </TABLE>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

