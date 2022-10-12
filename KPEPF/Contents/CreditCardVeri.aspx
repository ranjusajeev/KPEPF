


<%@ Page Title="" Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="CreditCardVeri.aspx.cs" Inherits="Contents_CreditCardVeri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
      <ContentTemplate>
<TABLE width="900px" style="width:900px;border:solid; "><TBODY><TR ><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="Credit Card"></asp:Label></TD></TR>
    <TR>
<TD  align="center"  >
        <asp:RadioButtonList ID="rdSngl" runat="server"  CssClass="p1"
                    RepeatDirection="Horizontal" OnSelectedIndexChanged="rdSngl_SelectedIndexChanged" AutoPostBack="True"  >
                    <asp:ListItem Selected="True" Value="1">Single</asp:ListItem>
                    <asp:ListItem Value="2">Bulk</asp:ListItem>
                </asp:RadioButtonList>

        </TD></tr>
    <tr><td  align="left" >

        <asp:Panel id="pnlS" runat="server" Visible="true" BorderColor="#CC3300" BorderStyle="Solid"><TABLE style="WIDTH: 100%"><TBODY>
    
    <TR><TD align="left"><asp:Label id="Label1" runat="server" ForeColor="Blue" Font-Bold="True" Text="Account No." Font-Names="Verdana" Font-Size="10pt" Width="100px"></asp:Label> <asp:TextBox id="tctAccNo" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" OnTextChanged="tctAccNo_TextChanged"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblClosed" runat="server" Text="..." CssClass="p4"></asp:Label> 


    <asp:Label id="lblAccNo" runat="server" Text="..." CssClass="p5"></asp:Label>
    <asp:Label id="lblName" runat="server" Text="..." CssClass="p4"></asp:Label>
    <asp:Label id="lblDistName" runat="server" Text="..." CssClass="p5" Visible="False"></asp:Label>
                                                                                                                                                                                                                                                                                                                                                                  </TD></TR><TR><TD align="left" width: 863px"><asp:Label id="Label2" runat="server" ForeColor="Blue" Font-Bold="True" Text="Year" Font-Names="Verdana" Font-Size="10pt" Width="100px"></asp:Label> <asp:DropDownList id="ddlYear" tabIndex=11 runat="server" Width="159px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;<asp:Button id="btnLedger" onclick="btnLedger_Click" runat="server" Width="100px" ForeColor="Blue" Text="Corr Calc" Font-Names="Verdana"></asp:Button> &nbsp;&nbsp; </TD></TR>
<tr>
    <asp:GridView ID="gdvS" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt"
                        Font-Names="Verdana" AutoGenerateColumns="False" GridLines="None" CellPadding="2"
                        CellSpacing="5">
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
                        <Columns>

                            <asp:BoundField DataField="slno" HeaderText="Sl No" />
                            <asp:BoundField HeaderText="AccNo" DataField="intAccNo" />
                            <asp:BoundField DataField="intYrId" HeaderText="Year">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Month" DataField="intMonthId" >
                            </asp:BoundField>
                            <asp:BoundField DataField="intDay" HeaderText="Day">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Amt" DataField="fltChalanAmt" >
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tpCorr" HeaderText="Operator" />
                            <asp:TemplateField HeaderText="Calc amt">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmt" runat="server" Text="0"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="tp" HeaderText="type" />
                            <asp:BoundField DataField="intChalanId" HeaderText="intChalanId" />
                            <asp:BoundField DataField="LCorrTp" HeaderText="LCorrTp" />
                        </Columns>
                        <RowStyle BackColor="#EFF3FB"></RowStyle>
                        <EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                        <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    </asp:GridView>

</tr>
<TR ><TD  align="left" style="border:solid ;width=800px" >
        <table style="border:1;border-color:green;border-style:solid" >
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" CssClass="p5" Text="OB"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOb" runat="server" CssClass="p5" Enabled="False" Text="0" Width="177px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" CssClass="p5" Text="Remittance"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRem" runat="server" CssClass="p5" Enabled="False" Text="0" Width="179px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" CssClass="p5" Text="Interest"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtInt" runat="server" CssClass="p5" Enabled="False" Text="0" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" CssClass="p5" Text="Total"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTot" runat="server" CssClass="p5" Enabled="False" Text="0" Width="181px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" CssClass="p5" Text="Withdrawal"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtWith" runat="server" CssClass="p5" Enabled="False" Text="0" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" CssClass="p5" Text="Correction"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCorr" runat="server" CssClass="p5" Enabled="False" Text="0" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" CssClass="p5" Text="CB"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCB" runat="server" CssClass="p5" Enabled="False" Text="0" Width="179px"></asp:TextBox>
                </td>
            </tr>
        </table> <asp:Label ID="lblMisMatch" runat="server" CssClass="p4"></asp:Label>

<asp:GridView id="gdvSerHis" runat="server"  ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField ApplyFormatInEditMode="True" DataField="SlNo" HeaderText="Sl. No.">
<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvYear" HeaderText="Year"></asp:BoundField>
<asp:BoundField DataField="chvMonth" HeaderText="Month"></asp:BoundField>
<asp:BoundField DataField="chvTp" HeaderText="Trn. Type"></asp:BoundField>
<asp:BoundField HeaderText="Amount" DataField="fltAmountBefore">
</asp:BoundField>
<asp:BoundField DataField="fltCalcAmount" HeaderText="Corr. amt.">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>






        </TD>

    </TR>
     
    
    <TR ><TD style="width: 400px" > <asp:GridView id="gdvCorrPrev" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5" Width="299px">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField ApplyFormatInEditMode="True" DataField="chvMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
    <asp:BoundField ApplyFormatInEditMode="True" DataField="dtChalDate" HeaderText="Chalan">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<%--<asp:HyperLinkField DataNavigateUrlFields="numChalanId" DataNavigateUrlFormatString="~/Contents/AoApprovalNewLnk2.aspx?intChalanId={0}" DataTextField="dtChalDate" HeaderText="Chalan">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>--%>
<asp:BoundField DataField="SubnAmt" HeaderText="Subn">
<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RefAmt" HeaderText="Ref">
<HeaderStyle HorizontalAlign="Center" Width="70px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ArreatAmt" HeaderText="Arrear">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RemTotal" HeaderText=" Total ">
    <HeaderStyle HorizontalAlign="Center" Width="50px" />
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="WihtAmt" HeaderText="With">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="LBName" HeaderText="Localbody" Visible="False">
<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <%--</td>--%>


<%--<td style="width: 400px" >--%>
<asp:GridView id="gdvCorr" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField ApplyFormatInEditMode="True" DataField="chvMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
 <asp:BoundField ApplyFormatInEditMode="True" DataField="CDate" HeaderText="Chalan">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<%--<asp:HyperLinkField DataNavigateUrlFields="numChalanId" DataNavigateUrlFormatString="~/Contents/ChalanEdit.aspx?numChalanId={0}" DataTextField="ChalanDet" HeaderText="Chalan">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>--%>
<asp:BoundField DataField="MsAmt" HeaderText="Subn">
<HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RfAmt" HeaderText="Ref">
<HeaderStyle HorizontalAlign="Center" Width="70px"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<%--<asp:BoundField DataField="DaAmt" HeaderText="Arrear">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>--%>
    <asp:TemplateField HeaderText="Arrear" ><ItemTemplate>
                        <asp:Label ID="lblArrearP" runat="server" Text="0"></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="RemAmt" HeaderText=" Total ">
    <HeaderStyle HorizontalAlign="Center" Width="50px" />
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Withdrawal" HeaderText="With">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody" Visible="False">
<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> 
 
    <asp:GridView id="gdvAnnStmnt" runat="server" Visible="False"  Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField ApplyFormatInEditMode="True" DataField="chvMonth" HeaderText="Month">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="numChalanId,flgApproval,flgPrevYear,intGroupId,PerYearId,PerMonthId,intDistID,PDEYear" DataNavigateUrlFormatString="~/Contents/ChalanEditNew.aspx?numChalanId={0}&amp;flgApproval={1}&amp;flgPrevYear={2}&amp;intGroupId={3}&amp;PerYearId={4}&amp;PerMonthId={5}&amp;intDistID={6}&amp;PDEYear={7}" DataTextField="ChalanDet" HeaderText="Chalan">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:HyperLinkField>
<asp:BoundField DataField="fltSubnAmt" HeaderText="Subn  ">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltRePaymentAmt" HeaderText="Ref">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<%--<asp:BoundField DataField="fltArearPFAmt" HeaderText="Arrear">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>--%>
    <asp:TemplateField HeaderText="Arrear" ><ItemTemplate>
                        <asp:Label ID="lblArrear" runat="server" Text="0"></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="fltTotal" HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltAllottedAmt" HeaderText="With">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>      
      </td>


       </TR>
    <tr align="center"><td><asp:Button ID="btnCorr" runat="server" Text="Corrections" OnClick="btnCorr_Click" Visible="False" /></td></tr>
    <tr align="center"><td>
 <asp:GridView id="gdvCons" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" >
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
    <asp:TemplateField HeaderText="SlNo">

        <ItemTemplate>
            <asp:Label ID="lblSlNo" runat="server" Text="1"></asp:Label>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Left" />
    </asp:TemplateField>
<asp:BoundField DataField="chvType" HeaderText="Type"></asp:BoundField>
<asp:BoundField DataField="chvCorrType" HeaderText="Corr. Type"></asp:BoundField>
<asp:BoundField DataField="chvYear" HeaderText="Year"></asp:BoundField>
<asp:BoundField DataField="chvMonth" HeaderText="Month" Visible="False"></asp:BoundField>
<asp:BoundField DataField="chvEngDistName" HeaderText="District" Visible="False"></asp:BoundField>
<asp:BoundField DataField="LBName" HeaderText="Localbody"></asp:BoundField>
<asp:BoundField DataField="dtmchalan" HeaderText="Chal / Bill"></asp:BoundField>
<asp:BoundField DataField="fltAmountBefore" HeaderText="Amount Before" Visible="False">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltCalcAmount" HeaderText="Corrected amt.">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
    </td></tr>
  
  </TBODY></TABLE></asp:Panel>


<asp:Panel id="pnlB" runat="server" Visible="False" BorderColor="#CC3300" BorderStyle="Solid"><TABLE style="WIDTH: 100%"><TBODY><TR align=center>
<TD  align=left style="height: 25px" >
<asp:Label id="Label9" runat="server" Width="120px" Text="Year" CssClass="p1">
</asp:Label>

 <asp:DropDownList id="ddlYearB" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYearB_SelectedIndexChanged" style="height: 20px"></asp:DropDownList>
 &nbsp;&nbsp;&nbsp;
     <asp:Button id="btnCorrCalc" onclick="btnCorrCalc_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Correction" Font-Size="10pt" Font-Names="Verdana"></asp:Button>
   
 <asp:Button id="btnCalcB" onclick="btnCalcB_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Calculation" Font-Size="10pt" Font-Names="Verdana" Visible="False"></asp:Button>
     </TD>
  
    
  </TR>
 <tr><td align="center" >
     <asp:GridView ID="gdvCalcCorr" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt"
                        Font-Names="Verdana" AutoGenerateColumns="False" GridLines="None" CellPadding="2"
                        CellSpacing="5">
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
                        <Columns>
                          
                            <asp:BoundField DataField="slno" HeaderText="Sl No" />
                            <asp:BoundField HeaderText="AccNo" DataField="intAccNo" />
                            <asp:BoundField DataField="intMonthId" HeaderText="Month">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Day" DataField="intDay" >
                            </asp:BoundField>
                            <asp:BoundField DataField="RemAmt" HeaderText="Rem">
                                <ItemStyle Width="100px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="With" DataField="Withdrawal" >
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Ob" HeaderText="Ob" />
                            <asp:TemplateField HeaderText="Calc amt">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmt" runat="server" Text="0"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#EFF3FB"></RowStyle>
                        <EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                        <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    </asp:GridView>



     <asp:GridView ID="gdv2" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt"
                        Font-Names="Verdana" AutoGenerateColumns="False" GridLines="None" CellPadding="2"
                        CellSpacing="5">
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
                        <Columns>

                            <asp:BoundField DataField="slno" HeaderText="Sl No" />
                            <asp:BoundField HeaderText="AccNo" DataField="intAccNo" />
                            <asp:BoundField DataField="intYrId" HeaderText="Year">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Month" DataField="intMonthId" >
                            </asp:BoundField>
                            <asp:BoundField DataField="intDay" HeaderText="Day">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Amt" DataField="RemAmt" >
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tpCorr" HeaderText="Operator" />
                            <asp:TemplateField HeaderText="Calc amt">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmt" runat="server" Text="0"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="tp" HeaderText="type" />
                            <asp:BoundField DataField="intChalanId" HeaderText="intChalanId" />
                            <asp:BoundField DataField="LCorrTp" HeaderText="LCorrTp" />
                            <asp:BoundField DataField="intTblTp" HeaderText="TblTp" />
                        </Columns>
                        <RowStyle BackColor="#EFF3FB"></RowStyle>
                        <EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                        <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    </asp:GridView>


     </td></tr> 
  
  </TBODY></TABLE></asp:Panel>

<%--<asp:Panel id="pnlB" runat="server" Visible="false" BorderColor="#CC3300" BorderStyle="Solid"><TABLE style="WIDTH: 100%"><TBODY>
    <tr><td align="center" ><asp:Label id="lblff" class="p1" runat="server" Text="Year"></asp:Label> &nbsp;&nbsp;&nbsp;
        <asp:DropDownList id="ddlYearB"  runat="server" Width="159px" AutoPostBack="True" OnSelectedIndexChanged="ddlYearB_SelectedIndexChanged"></asp:DropDownList>
        </td></tr>
    <TR><TD colspan="2" align=left >
<asp:GridView id="gdvBulk" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="chvMonth" HeaderText="Sl No" ApplyFormatInEditMode="True">

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CDate" HeaderText="Acc No" ApplyFormatInEditMode="True">

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="MsAmt" HeaderText="Year">
    <HeaderStyle HorizontalAlign="Center" Width="50px" />
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="RfAmt" HeaderText="empID">
    <HeaderStyle HorizontalAlign="Center" Width="70px" />
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Rem" Visible="False">
    <HeaderStyle HorizontalAlign="Center" Width="100px" />
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Withdrawal" HeaderText="With">

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> 

</td></tr>
  
  </TBODY></TABLE></asp:Panel>--%>












    </td></TR>
    </TBODY></TABLE>
          

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             </TD></TR><TR><TD style="HEIGHT: 215px" colSpan=2><DIV id="PDE" runat="server"></DIV></TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
<%--    <script language=javascript type="text/javascript">
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

