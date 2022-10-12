<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_SingleCalc, App_Web_4p3ju0t2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
        <TABLE style="WIDTH: 100%"><TR align=center>
<TD  align="center" style="width: 902px" >
        <asp:RadioButtonList ID="rdSngl" runat="server"  CssClass="p1"
                    RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdSngl_SelectedIndexChanged">
                    <asp:ListItem Value="2">Corr Single</asp:ListItem>
                    <asp:ListItem Value="1">Calc Single</asp:ListItem>
                    <asp:ListItem Value="3">Bulk</asp:ListItem>
                    <asp:ListItem Value="4">Corr Bulk</asp:ListItem>
                </asp:RadioButtonList></TR><tr><td style="width: 902px">
<asp:Panel id="pnlSanction" runat="server" Visible="true" BorderColor="#CC3300" BorderStyle="Solid"><TABLE style="WIDTH: 100%"><TBODY><TR align=center>
<TD  align=left style="height: 29px" >
<asp:Label id="Label2" runat="server" Width="120px" Text="Account No." CssClass="p1">
</asp:Label>
<%--</td>
<td>--%>
 <asp:TextBox id="txtAccNoP" oncopy="return false" oncut="return false" tabIndex=3 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="120px" CssClass="txtNumeric"  MaxLength="5" AutoPostBack="True" OnTextChanged="txtAccNoP_TextChanged">
 </asp:TextBox>

    <asp:DropDownList id="ddlYr" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYr_SelectedIndexChanged" ></asp:DropDownList>

<%--  </TD>
  <TD align=center>--%>
      <asp:Button id="btnBulkNew" onclick="btnBulkNew_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Single Calc" Font-Size="10pt" Font-Names="Verdana"></asp:Button> </TD>
    
  </TR>
  
  
  <tr>
      <td  align="center">
  <%--<asp:Button id="btnBulk" onclick="btnBulk_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Bulk Calc" Font-Size="10pt" Font-Names="Verdana" Enabled="False"></asp:Button>--%>
    <asp:Button id="btnBulkSelection" onclick="btnBulkSelection_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="BulkSelection" Font-Size="10pt" Font-Names="Verdana" Enabled="False"></asp:Button>
<%--  </td>
      <td colspan="2" align="center">--%>
          <asp:Button id="btnBulk" onclick="btnBulk_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Bulk Calc" Font-Size="10pt" Font-Names="Verdana" Enabled="False"></asp:Button>
    <asp:Button id="btnBulkMltplYr" onclick="btnBulkMltplYr_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="BulkMltplYr" Font-Size="10pt" Font-Names="Verdana" Enabled="False"></asp:Button>

  
  </td></tr>
  
  </TBODY></TABLE></asp:Panel>  </TD></TR><tr><td style="width: 902px">

        <asp:Panel id="pnlCorrCalc" runat="server" Visible="False" BorderColor="#CC3300" BorderStyle="Solid"><TABLE style="WIDTH: 100%"><TBODY><TR align=center>
<TD  align=left style="height: 25px" >
<asp:Label id="Label1" runat="server" Width="120px" Text="Account No." CssClass="p1">
</asp:Label>

 <asp:DropDownList id="ddlYear" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" Visible="False"></asp:DropDownList>
    <asp:TextBox id="txtAccNoSingle" oncopy="return false" oncut="return false" tabIndex=3 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="120px" CssClass="txtNumeric"  MaxLength="5" AutoPostBack="True">
 </asp:TextBox>
 &nbsp;&nbsp;&nbsp;<asp:Button id="btnCorrCalc" onclick="btnCorrCalc_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Corr Calc" Font-Size="10pt" Font-Names="Verdana"></asp:Button>
 
     </TD>
  
    
  </TR>
 <tr><td align="center" >
     <asp:GridView ID="gdvCalcCorr" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt"
                        Font-Names="Verdana" AutoGenerateColumns="False" GridLines="None" CellPadding="2"
                        CellSpacing="5" Visible="False">
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
                        <Columns>
                            <%--<asp:BoundField DataField="slno" HeaderText="Sl No.">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>--%>
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
                             <asp:BoundField DataField="tp" HeaderText="TrnType" />
                            <asp:TemplateField HeaderText="Calc amt">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmt" runat="server" Text="0"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
       <%--                     <asp:TemplateField HeaderText="yr">
                                <ItemTemplate>
                                    <asp:Label ID="lblyr" runat="server" Text="0"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <RowStyle BackColor="#EFF3FB"></RowStyle>
                        <EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                        <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    </asp:GridView>

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
     </td></tr> 
  
<%--  <tr><td colspan="2" align="center">
  <asp:Button id="btnCorrCalc" onclick="btnCorrCalc_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Corr Calc" Font-Size="10pt" Font-Names="Verdana"></asp:Button>
  
  </td></tr>--%>
  
  </TBODY></TABLE></asp:Panel> </TD></TR></TABLE> 
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

