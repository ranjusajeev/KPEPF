<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_CorrTemp, App_Web_rihpu3hj" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" runat="Server">
    <table>
        <tr>
            <td>
                <asp:RadioButtonList ID="rdCategory" runat="server" AutoPostBack="True" CssClass="p1"
                    OnSelectedIndexChanged="rdCategory_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">Add</asp:ListItem>
                    <asp:ListItem Value="2">Delete</asp:ListItem>
                    <asp:ListItem Value="3">Calc</asp:ListItem>
                    <asp:ListItem Value="4">Ob</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RadioButtonList ID="rdSngl" runat="server"  CssClass="p1"
                    RepeatDirection="Horizontal" Visible="False" >
                    <asp:ListItem Selected="True" Value="1">Single</asp:ListItem>
                    <asp:ListItem Value="2">Bulk</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Panel ID="pnlNo" runat="server" Width="100%" Visible="true">
                    <asp:Label ID="Label5" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Date"
                        Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>
                    <asp:TextBox ID="txtDt" TabIndex="4" runat="server" AutoPostBack="True" CssClass="datePicker"
                        MaxLength="10" OnTextChanged="txtDt_TextChanged"></asp:TextBox>
                    &nbsp;
                    <asp:Label ID="Label6" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="No."
                        Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>
                    <asp:TextBox ID="txtNo" TabIndex="4" runat="server" MaxLength="5" OnTextChanged="txtNo_TextChanged" CssClass="txtNumeric"></asp:TextBox>
                    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Button ID="btnSearch"
                        runat="server" OnClick="btnSearch_Click" Text="Search" Width="85px" />
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                    <asp:GridView ID="gdvc" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt"
                        Font-Names="Verdana" AutoGenerateColumns="False" GridLines="None" CellPadding="2"
                        CellSpacing="5">
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
                        <Columns>
                            <asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
                            <asp:HyperLinkField HeaderText="Chalan details" DataTextField="dtChalanDate" DataNavigateUrlFormatString="~/Contents/CorrTemp.aspx?numChalanId={0}&amp;intYearId={1}&amp;MonthId={2}&amp;dy={3}"
                                DataNavigateUrlFields="numChalanId,intYearId,MonthId,dy">
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="fltChalanAmt" HeaderText="Amount">
                                <ItemStyle Width="45px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="chvNAme" HeaderText="Localbody"></asp:BoundField>
                            <asp:BoundField DataField="chvEngDistName" HeaderText="District"></asp:BoundField>
                            <asp:BoundField DataField="chvTreasuryName" Visible="False" HeaderText="Treasury"></asp:BoundField>
                            <asp:TemplateField Visible="False" HeaderText="TrnId">
                                <ItemTemplate>
                                    <asp:Label ID="txtNumTrnId" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False" HeaderText="Apprv">
                                <ItemTemplate>
                                    <asp:Label ID="lblAppFlg" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="YearId" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblYear" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MonthId" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblMonth" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DistId" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDist" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="numChalanId" HeaderText="numChalanId" />
                        </Columns>
                        <RowStyle BackColor="#EFF3FB"></RowStyle>
                        <EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                        <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    </asp:GridView>
                    <asp:GridView ID="gdvs" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt"
                        Font-Names="Verdana" AutoGenerateColumns="False" GridLines="None" CellPadding="2"
                        CellSpacing="5">
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
                        <Columns>
                            <asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
                            <asp:BoundField HeaderText="AccNo" DataField="intPF_No" />
                            <asp:BoundField DataField="fltTotAmt1" HeaderText="Amount">
                                <ItemStyle Width="45px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Id" DataField="intId" />
                        </Columns>
                        <RowStyle BackColor="#EFF3FB"></RowStyle>
                        <EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                        <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    </asp:GridView>
                    <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="Calcu" Width="104px" /></asp:Panel>
                <asp:Panel ID="pnlNo1" runat="server" Width="100%" Visible="false">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" CssClass="p1"
                        OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">Rem</asp:ListItem>
                        <asp:ListItem Value="2">With</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="Label1" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Date"
                        Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>
                    <asp:TextBox ID="txtDt2" TabIndex="4" runat="server" AutoPostBack="True" CssClass="datePicker"
                        MaxLength="10" Width="102px" ></asp:TextBox>
                    &nbsp;
                    
                    <asp:Label ID="Label7" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Acc No"
                        Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>
                    <asp:TextBox ID="txtAcc" TabIndex="4" runat="server" MaxLength="5"  Width="118px" CssClass="txtNumeric"></asp:TextBox>
                    
                    <asp:Label ID="Label2" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Amt"
                        Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>
                    <asp:TextBox ID="txtAmt2" TabIndex="4" runat="server" MaxLength="7" Width="118px" CssClass="txtNumeric"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Chal"
                        Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>
                    <asp:TextBox ID="txtChal" TabIndex="4" runat="server" MaxLength="10" Width="110px" CssClass="txtNumeric"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Sched"
                        Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>
                    
                    <asp:TextBox ID="txtSch" TabIndex="4" runat="server" MaxLength="10" Width="100px" CssClass="txtNumeric"></asp:TextBox>
                    <asp:Button ID="btnCalc2"
                        runat="server" OnClick="btnCalc2_Click" Text="Calc" Width="85px" />
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:TextBox ID="txtcaAmt" TabIndex="4" runat="server" MaxLength="10"></asp:TextBox>
                     <asp:TextBox ID="txtCorrType" TabIndex="5" runat="server" MaxLength="1" ToolTip="txtCorrType" Width="63px"></asp:TextBox>
                    <asp:TextBox ID="txtChalType" TabIndex="6" runat="server" MaxLength="1" ToolTip="txtChalType" Width="52px"></asp:TextBox>

                    <asp:TextBox ID="txtAmtBfr" TabIndex="5" runat="server" MaxLength="5" ToolTip="txtAmtBfr" Width="84px"></asp:TextBox>
                    <asp:TextBox ID="txtAmtAfr" TabIndex="6" runat="server" MaxLength="5" ToolTip="txtAmtAfr" Width="73px"></asp:TextBox>


                    <asp:Button ID="btnSaveCorr"
                        runat="server" OnClick="btnSaveCorr_Click" Text="Cprrection" Width="85px" />
                </asp:Panel>

                <asp:Panel ID="pnlNo2" runat="server" Width="100%" Visible="false">
                   
                    
                    <asp:Label ID="Label9" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Acc No"
                        Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>
                    <asp:TextBox ID="txtAccO" TabIndex="4" runat="server" MaxLength="5"  Width="118px" CssClass="txtNumeric" ></asp:TextBox>
                    
                    <asp:Label ID="Label10" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Amt"
                        Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label>
                    <asp:TextBox ID="txtAmtO" TabIndex="4" runat="server" MaxLength="8" Width="118px" CssClass="txtNumeric"></asp:TextBox>
                    
                    <asp:Button ID="btnCalcO"
                        runat="server" OnClick="btnCalcO_Click" Text="Calc" Width="85px" />
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:TextBox ID="txtCalcO" TabIndex="4" runat="server" MaxLength="10"></asp:TextBox>
                    
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

