<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="AGStatementsPDE.aspx.cs" Inherits="Contents_AGStatementsPDE" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="AG StatementsPDE"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 30px" align=left><asp:Label id="Year" runat="server" Text="Year" CssClass="p1"></asp:Label></TD><TD style="HEIGHT: 30px" align=left><asp:DropDownList id="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True">
 </asp:DropDownList></TD><TD style="HEIGHT: 30px" align=left><asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label></TD><TD style="HEIGHT: 30px" align=left><asp:DropDownList id="ddlMnth" runat="server" OnSelectedIndexChanged="ddlMnth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblStat" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR>
    <caption>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <tr>
            <td align="center" colspan="4">
                <asp:Panel ID="pnlStmt" runat="Server" Width="100%">
                    <asp:GridView ID="gdvAgStmt" runat="server" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" DataKeyNames="intDTreasuryID" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None" OnRowCreated="gdvAgStmt_RowCreated" OnSelectedIndexChanged="gdvAgStmt_SelectedIndexChanged1" ShowFooter="True" Width="100%">
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
                            <asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury Name">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Treasury">
                                <FooterTemplate>
                                    &nbsp;<asp:Label ID="lblTrCrAmt" runat="server" Font-Bold="True" Width="98px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTreasuryCredit" runat="server" AutoPostBack="True" CssClass="txtNumeric" Enabled="False" MaxLength="5" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGCredit_TextChanged" ReadOnly="True" Width="98px"></asp:TextBox>
                                </ItemTemplate><ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AG">
                                <FooterTemplate>
                                    <asp:Label ID="lblAGCrAmt" runat="server" Font-Bold="True" Width="98px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAGCredit" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="7" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGCredit_TextChanged" Width="98px"></asp:TextBox>
                                </ItemTemplate><ItemStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Treasury">
                                <FooterTemplate>
                                    <asp:Label ID="lblTrdrAmt" runat="server" Font-Bold="True" Width="98px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTreasryDebit" runat="server" AutoPostBack="True" CssClass="txtNumeric" Enabled="False" MaxLength="5" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGCredit_TextChanged" ReadOnly="True" Width="98px"></asp:TextBox>
                                </ItemTemplate><ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AG">
                                <FooterTemplate>
                                    <asp:Label ID="lblAGDrAmt" runat="server" Font-Bold="True" Width="98px"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAGDebit" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="7" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGDebit_TextChanged" Width="98px"></asp:TextBox>
                                </ItemTemplate><ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRem" runat="server" Width="168px"></asp:TextBox>
                                </ItemTemplate><ItemStyle Width="170px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mismatch" Visible="False">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtmismatch" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="5" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGCredit_TextChanged" Width="98px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="intDTreasuryID" ReadOnly="True" Visible="False"></asp:BoundField>
                            <asp:TemplateField HeaderText="DTreasuryDetId" Visible="False">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDTreasuryDetId" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="5" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGCredit_TextChanged" Width="98px"></asp:TextBox>
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
                </asp:Panel>
                <BR />
                <BR />
                <asp:Panel ID="TEDetails" runat="Server" Width="100%">
                    <table border="2">
                        <tbody>
                            <tr>
                                <td align="left" style="WIDTH: 16%">
                                    <asp:Label ID="lblCrPlus" runat="server" class="p1" Text="Credit Plus"></asp:Label>
                                </td>
                                <td style="WIDTH: 16%">
                                    <asp:TextBox ID="txtcrplus" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" OnTextChanged="txtcrplus_TextChanged" tabIndex="4">0</asp:TextBox>
                                </td>
                                <td style="WIDTH: 16%">
                                    <asp:LinkButton ID="lnkCrplus" runat="server" Font-Bold="True" ForeColor="Red" Height="23px" onclick="lnkCrplus_Click" Text="Click Here"></asp:LinkButton>
                                </td>
                                <td align="left" style="WIDTH: 16%">
                                    <asp:Label ID="lblDebitPlus" runat="server" class="p1" Text="Debit Plus"></asp:Label>
                                </td>
                                <td style="WIDTH: 16%">
                                    <asp:TextBox ID="TxtDbplus" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" OnTextChanged="TxtDbplus_TextChanged" tabIndex="4">0</asp:TextBox>
                                </td>
                                <td style="WIDTH: 16%">
                                    <asp:LinkButton ID="lnkDBPlus" runat="server" Font-Bold="True" ForeColor="Red" Height="23px" onclick="lnkDBPlus_Click" Text="Click Here"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblCrminus" runat="server" class="p1" Text="Credit Minus"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCrminus" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" OnTextChanged="txtCrminus_TextChanged" tabIndex="4">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnCrMinus" runat="server" Font-Bold="True" ForeColor="Red" Height="23px" onclick="lnCrMinus_Click" Text="Click Here"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDebtminus" runat="server" class="p1" Text="Debit Minus"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDbminus" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" OnTextChanged="txtDbminus_TextChanged" tabIndex="4">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkDbMinus" runat="server" Font-Bold="True" ForeColor="Red" Height="23px" onclick="lnkDbMinus_Click" Text="Click Here"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblDaer" runat="server" class="p1" Text="Credit DAER"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdaer" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" OnTextChanged="txtdaer_TextChanged" tabIndex="4">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkDaerPlus" runat="server" Font-Bold="True" ForeColor="Red" Height="23px" onclick="lnkDaerPlus_Click" Text="Click Here"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDaerDb" runat="server" class="p1" Text="Debit DAER"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdaerDb" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" OnTextChanged="txtdaerDb_TextChanged" tabIndex="4">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkDaerMns" runat="server" Font-Bold="True" ForeColor="Red" Height="23px" onclick="lnkDaerMns_Click" Text="Click Here"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" class="p1" Text="Credit OAO"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdaero" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" OnTextChanged="txtdaero_TextChanged" tabIndex="4">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkDaerPluso" runat="server" Font-Bold="True" ForeColor="Red" Height="23px" onclick="lnkDaerPluso_Click" Text="Click Here"></asp:LinkButton>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" class="p1" Text="Debit OAO"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="lblDaerDbo" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="6" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" OnTextChanged="txtdaerDbo_TextChanged" tabIndex="4">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkDaerMnso" runat="server" Font-Bold="True" ForeColor="Red" Height="23px" onclick="lnkDaerMnso_Click" Text="Click Here"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="HEIGHT: 20px">
                                    <asp:Label ID="lblCredit" runat="server" class="p1" Text="Net Credit"></asp:Label>
                                </td>
                                <td align="right" style="HEIGHT: 20px">
                                    <asp:Label ID="lblNetCr" runat="server" class="p4"></asp:Label>
                                </td>
                                <td style="HEIGHT: 20px"></td>
                                <td style="HEIGHT: 20px">
                                    <asp:Label ID="lblDebit" runat="server" class="p1" Text="Net Debit"></asp:Label>
                                </td>
                                <td align="right" style="HEIGHT: 20px">
                                    <asp:Label ID="lblNetDr" runat="server" class="p4"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
           <%-- <td>
                <asp:LinkButton ID="btnBack" runat="server" Font-Bold="True" ForeColor="Blue" Height="23px" onclick="btnBack_Click1" Text="Back to Approval" Visible="False" Width="138px"></asp:LinkButton>
            </td>--%>
            <td colspan="6" align="center">
                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" Width="119px" Height="23px" />
            </td>
        </tr>
    </caption>
    </TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

