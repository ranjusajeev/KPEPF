
<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_RemittancePDE, App_Web_rihpu3hj" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4>&nbsp; <asp:Label id="lblHead" class="MnHead" runat="server" Text="Remittance_Treasury"></asp:Label> </TD></TR><%--
<TR><TD style="align: left"><asp:Label id="Year" runat="server" Text="Year" CssClass="p1"></asp:Label></TD>
<TD style="align: left"><asp:DropDownList id="ddlYear" runat="server" Width="150px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD>
<TD style="align: left"><asp:Label id="Label3" runat="server" Text="District" CssClass="p1"></asp:Label></TD>
<TD style="align: left"><asp:DropDownList id="ddldist" runat="server" Width="150px" OnSelectedIndexChanged="ddldist_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD>
</TR>

<TR align=left>
<TD style="align: left">
<asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label></TD>
<TD style="align: left"><asp:DropDownList id="ddlMnth" runat="server" Width="150px" OnSelectedIndexChanged="ddlMnth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD>
<TD style="align: left"><asp:Label id="Label4" runat="server" Text="District Treasury" CssClass="p1"></asp:Label></TD>
<TD style="align: left"><asp:DropDownList id="ddlDT" runat="server" Width="150px" OnSelectedIndexChanged="ddlDT_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD>
</TR>


<TR align=left>
<TD style="HEIGHT: 22px; align: left"><asp:Label id="lblInti" runat="server" CssClass="p1" text="Intimation Date"></asp:Label></TD>
<TD style="HEIGHT: 22px; align: left"><asp:TextBox id="txtInt" runat="server" CssClass="datePicker" AutoPostBack="True" width="150px" OnTextChanged="txtInt_TextChanged"></asp:TextBox></TD>
<TD style="HEIGHT: 22px; align: left"><asp:Label id="lblAmt" runat="server" CssClass="p1" text="Amount"></asp:Label></TD>
<TD style="HEIGHT: 22px; align: left"><asp:TextBox id="txtAmt" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="150px" CssClass="txtNumeric" MaxLength="8"></asp:TextBox></TD>
</TR>--%><TR align=center><TD style="WIDTH: 800px" colSpan=4><asp:Label id="Year" runat="server" Text="Year" CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label2" runat="server" Text="Month" CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label4" runat="server" Text="District Treasury" CssClass="p4"></asp:Label> </TD></TR><TR align=left><TD align=center><asp:Label id="lblStatus" runat="server" CssClass="p4" text="..."></asp:Label></TD></TR><TR><TD align=center colSpan=2><asp:Label id="lbl1" runat="server" Text="Sub Treasury wise Details" CssClass="p1"></asp:Label></TD><TD align=left colSpan=2>&nbsp;<asp:Label id="lbl2" runat="server" Text="Chalan Details" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblSTDet" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR>

<TD>
    <asp:LinkButton ID="lnkChal" runat="server" Font-Bold="True" Font-Size="10pt" onclick="lnkChal_Click">New Acc. Transaction</asp:LinkButton>
    </TD></TR><TR><TD>
        <asp:Panel ID="pnlChalNew" runat="server" BackColor="LightGray" style="Z-INDEX: 100; LEFT: 300px; POSITION: absolute; TOP: 550px" Visible="false" Width="300px">
            <div>
                <table>
                    <tbody>
                        <tr align="center">
                            <td align="center" class="p1" colspan="2" style="HEIGHT: 18px">New Acc. Transaction</td>
                        </tr>
                        <tr>
                            <td align="left" style="HEIGHT: 21px" width="90%">
                                <asp:Label ID="lblchlId" runat="server" Text="id." Visible="False"></asp:Label>
                                <asp:Label ID="lblEditMode" runat="server" Text="0" Visible="False"></asp:Label>
                                <asp:Label ID="lblDtOld" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                            <td style="WIDTH: 104px; HEIGHT: 21px">
                                <asp:TextBox ID="txtchlnId" runat="server" BorderStyle="None" CssClass="txtNumeric" Enabled="False" MaxLength="7" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" Visible="False">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="HEIGHT: 21px" width="90%">
                                <asp:Label ID="Label6" runat="server" class="p1" Text="Acc. date"></asp:Label>
                            </td>
                            <td style="WIDTH: 104px; HEIGHT: 21px">
                                <asp:TextBox ID="txtAccDtE" runat="server" AutoPostBack="True" CssClass="datePicker" MaxLength="10" OnTextChanged="txtAccDtE_TextChanged" Width="129px">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="HEIGHT: 21px" width="90%">
                                <asp:Label ID="Label1" runat="server" class="p1" Text="Transaction date"></asp:Label>
                            </td>
                            <td style="WIDTH: 104px; HEIGHT: 21px">
                                <asp:TextBox ID="txtTrnDtE" runat="server" AutoPostBack="True" CssClass="datePicker" MaxLength="10" OnTextChanged="txtTrnDtE_TextChanged" Width="129px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="HEIGHT: 21px" width="90%">
                                <asp:Label ID="Label5" runat="server" class="p1" Text="Amount"></asp:Label>
                            </td>
                            <td style="WIDTH: 104px; HEIGHT: 21px">
                                <asp:TextBox ID="txtChalAmt" runat="server" CssClass="txtNumeric" MaxLength="7" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="HEIGHT: 21px" width="90%">
                                <asp:Label ID="lblStreas" runat="server" CssClass="p1" Text="SubTreasury"></asp:Label>
                            </td>
                            <td style="WIDTH: 104px; HEIGHT: 21px">
                                <asp:DropDownList ID="ddlsubTreas" runat="server" OnSelectedIndexChanged="ddlsubTreas_SelectedIndexChanged" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="HEIGHT: 21px" width="90%">
                                <asp:Button ID="btnNewChal" runat="server" onclick="btnNewChal_Click" Text="Save" Width="55px" />
                                <asp:Button ID="btnCan" runat="server" onclick="btnCan_Click" Text="Cancel" Width="55px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="HEIGHT: 21px" width="90%">
                                <asp:Label ID="lblNw" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                            <td style="WIDTH: 104px; HEIGHT: 21px">
                                <asp:Label ID="lblOl" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </asp:Panel>
        </TD></TR>
    <tr>
        <td colspan="2" valign="top">
            <asp:GridView ID="gdvChalanS" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None" ShowFooter="True">
                <FooterStyle BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                <Columns>
                    <asp:BoundField DataField="SlNo" HeaderText="Sl.No.">
                        <ItemStyle Width="4px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Acc. Date">
                        <ItemTemplate>
                            <%--<asp:TextBox id="txtAccDate" runat="server" Width="75px" __designer:wfdid="w1"></asp:TextBox>--%>
                            <asp:TextBox ID="txtAccDate" runat="server" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtAccDate_TextChanged" Width="77px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trn Date">
                        <ItemTemplate>
                            <%--<asp:TextBox id="txtTrnDate" runat="server" Width="75px" __designer:wfdid="w2"></asp:TextBox>--%>
                            <asp:TextBox ID="txtTrnDate" runat="server" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtTrnDate_TextChanged" Width="77px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="intSTreasuryDetId" DataNavigateUrlFormatString="~/Contents/RemittancePDE.aspx?intSTreasuryDetId={0}" DataTextField="chvTreasuryNameDisp" HeaderText="Sub Treasury">
                        <ItemStyle HorizontalAlign="Left" Width="160px" />
                    </asp:HyperLinkField>
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <asp:TextBox ID="txtAmt" runat="server" CssClass="txtNumeric" OnTextChanged="txtAmt_TextChanged" Width="75px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STreasDetId" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblSTDetId" runat="server" Text="Label" visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TreasuryId" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblTreasId" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="EditMode" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblEditMode" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OldAmt" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblOldAmt" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" Wrap="True" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </td>
        <td colspan="2" valign="top">
            <asp:GridView ID="gdvChalanLB" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None" ShowFooter="True">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <%--<asp:BoundField DataField="SlNo" HeaderText="Sl.No."></asp:BoundField>--%>
                    <asp:TemplateField HeaderText="Sl.No.">
                        <ItemTemplate>
                            <asp:Label ID="lblSlNo" runat="server" Text="."></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sub Treasury" Visible="False">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlST" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
                        <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId" DataNavigateUrlFormatString="~/Contents/ChalanEdit.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}" DataTextField="intChalanDet" HeaderText="Chalan details">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="NetAmt" HeaderText="Amount">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Un posted">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkApp" runat="server" AutoPostBack="True" Enabled="False" OnCheckedChanged="chkApp_CheckedChanged" Width="1px" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="20px" />
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
        <td colspan="2" align="center" style="width:800px">
            <asp:Button ID="btnBack" runat="server" PostBackUrl="~/Contents/RemittancePDEPrev.aspx" Text="Back" Width="100px" Height="20px" OnClick="btnBack_Click" />
            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Height="20px" Text="Save" Width="100px" />
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
   
	</script>
--%></asp:Content>

