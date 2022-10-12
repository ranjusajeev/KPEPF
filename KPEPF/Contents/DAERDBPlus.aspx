<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="DAERDBPlus.aspx.cs" Inherits="Contents_DAERDBPlus" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="DAER_Debit"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblYear" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD style="WIDTH: 658px" align=right><asp:Panel id="pnlMain" runat="server"><TABLE><TBODY><TR><TD align=left><asp:Label id="lbl11" runat="server" Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD style="WIDTH: 69px" align=right><asp:Label id="lblTot" runat="server" Text="0" Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR><TR><TD style="HEIGHT: 16px" align=left><asp:Label id="lblTotET" runat="server" Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD style="WIDTH: 69px; HEIGHT: 16px" align=right><asp:Label id="lblTotE" runat="server" Text="0" Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD style="WIDTH: 69px" align=right><asp:Label id="lblBal" runat="server" Text="0" Font-Size="10pt" Font-Names="Verdana" CssClass="p4"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR>
    <caption>
        &lt;<tr>
            <td class="TdMnHead" colspan="2">
                <asp:Label ID="lbl2" runat="server" CssClass="p1" Text="Bill Entry"></asp:Label>
                &nbsp; &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblAmtWCP" runat="server" CssClass="p4" Text="0"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl23" runat="server" CssClass="p1" Text="Employee wise Entry"></asp:Label>
                &nbsp; &nbsp;&nbsp;&nbsp;<asp:Label ID="lblAmtBill" runat="server" CssClass="p4" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="HEIGHT: 22px">
                <asp:Label ID="lblCntCap" runat="server" CssClass="p1" Text="No. of Rows"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCnt" runat="server" AutoPostBack="True" CssClass="txtNumeric" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" OnTextChanged="txtCnt_TextChanged">
                </asp:TextBox>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2">
                <div style="OVERFLOW-X: auto; WIDTH: 900px">
                    <asp:GridView ID="gdvDPWith" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="5" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="1000px">
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
                            <asp:TemplateField HeaderText="TE NO">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTeDP" runat="server" __designer:wfdid="w1" Width="71px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bill No.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBillNoWD" runat="server" CssClass="txtNumeric" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" Width="71px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bill Date">
                                <ItemTemplate>
                                    &nbsp;<asp:TextBox ID="txtBilldateDBplus" runat="server" AutoPostBack="True" CssClass="datePicker" MaxLength="10" OnTextChanged="txtBilldateDBplus_TextChanged" Width="71px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DrawnBy">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddldrawn" runat="server" Width="88px">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAmtDbPlus" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" OnTextChanged="txtAmtDbPlus_TextChanged" Width="71px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dist.Treasury">
                                <ItemTemplate>
                                    &nbsp;<asp:DropDownList ID="ddlTreasDBplus" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UnP">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chlUnpostDPW" runat="server" __designer:wfdid="w2" AutoPostBack="True" OnCheckedChanged="chkUnpostDPW_CheckedChanged" Width="50px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reason">
                                <ItemTemplate>
                                    &nbsp;<asp:DropDownList ID="ddlreason" runat="server" Enabled="False" Width="110px">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField DataNavigateUrlFields="intVoucherID" DataNavigateUrlFormatString="~/Contents/WithdrawalPDEAG.aspx?intVoucherID={0}" DataTextField="intVoucherNo" HeaderText="Bill No." Text="Bill" >
                                <ItemStyle Width="100px" />
                            </asp:HyperLinkField>
                            <asp:TemplateField HeaderText="intId" Visible="False">
                                <ItemTemplate>
                                    &nbsp;<asp:Label ID="lblintId" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RelmtnhWiseId" Visible="False">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRelMnthWiseIdW" runat="server" Width="71px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RelMnth" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblMnth" runat="server" Width="71px" Text="0"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RelYear" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblYearId" runat="server" Width="71px" Text="0"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btndelete" runat="server" ImageUrl="~/images/removerow.gif" onclick="btnDelete_Click" onclientclick="return DeleteItem()" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="cssHeadGridEng" HorizontalAlign="Center" Width="30px" />
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
 <asp:TemplateField HeaderText="EditId" Visible="False"><ItemTemplate>
<asp:Label id="lblEditId" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
                        </Columns>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" Wrap="True" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                 <asp:Button ID="btnBack" runat="server" Height="19px" onclick="btnBack_Click" Text="Back " Width="53px" />
                <asp:Button ID="btnSaveDBPlus" runat="server" onclick="btnSaveDBPlus_Click" Text="Save" Width="53px"  Height="20px"/>
            </td>
        </tr>
       <%-- <tr>
            <td colspan="2">
                <asp:Button ID="btnBack" runat="server" Height="19px" onclick="btnBack_Click" Text="Back " Width="53px" />
            </td>
        </tr>--%>
    </caption>
    </TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

