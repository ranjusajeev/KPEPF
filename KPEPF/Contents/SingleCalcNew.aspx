<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="SingleCalcNew.aspx.cs" Inherits="Contents_SingleCalcNew" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
        <TABLE style="WIDTH: 100%"><tr><td style="width: 902px">

    <asp:Panel id="pnlOption" runat="server" Visible="false" BorderColor="#CC3300" BorderStyle="Solid"><TABLE style="WIDTH: 100%"><TBODY><TR align=center>
<TD  align="center" >
   <asp:RadioButtonList id="rdCategory" runat="server" OnSelectedIndexChanged="rdCategory_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="p1" Enabled="False"><asp:ListItem Selected="True">Single</asp:ListItem>
<asp:ListItem>Group</asp:ListItem>
</asp:RadioButtonList>
</TD>
    
  </TR>
  
  </TBODY></TABLE></asp:Panel> 
<asp:Panel id="pnlSanction" runat="server" Visible="true" BorderColor="#CC3300" BorderStyle="Solid"><TABLE style="WIDTH: 100%"><TBODY><TR align=center>
<TD  align=left >
<asp:Label id="Label2" runat="server" Width="120px" Text="Account No." CssClass="p1">
</asp:Label>
<%--</td>
<td>--%>
 <asp:TextBox id="txtAccNoP" oncopy="return false" oncut="return false" tabIndex=3 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="120px" CssClass="txtNumeric"  MaxLength="5" AutoPostBack="True" OnTextChanged="txtAccNoP_TextChanged">
 </asp:TextBox>

    <asp:DropDownList id="ddlYr" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYr_SelectedIndexChanged" ></asp:DropDownList>

<%--  </TD>
  <TD align=center>--%>
     <asp:Button id="btnCorrThisYear" onclick="btnCorrThisYear_Click" runat="server" Width="190px" ForeColor="Blue" Font-Bold="True" Text="Correction(Current Year)" Font-Size="10pt" Font-Names="Verdana"></asp:Button>
      <asp:Button id="btnBulkNew" onclick="btnBulkNew_Click" runat="server" Width="163px" ForeColor="Blue" Font-Bold="True" Text="Regenerate Last Card" Font-Size="10pt" Font-Names="Verdana"></asp:Button>
    <asp:Button id="btnLWACalc" onclick="btnLWACalc_Click" runat="server" Width="132px" ForeColor="Blue" Font-Bold="True" Text="Regenerate All" Font-Size="10pt" Font-Names="Verdana"></asp:Button>
</TD>
    
  </TR>
  
  </TBODY></TABLE></asp:Panel>  </TD></TR><tr><td style="width: 902px">

        <asp:Panel id="pnlCorrCalc" runat="server" Visible="False" BorderColor="#CC3300" BorderStyle="Solid"><TABLE style="WIDTH: 100%"><TBODY>

 <tr><td align="center" >



     <asp:GridView ID="gdvS" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt"
                        Font-Names="Verdana" AutoGenerateColumns="False" GridLines="None" CellPadding="2"
                        CellSpacing="5" Visible="False">
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
                            <asp:BoundField DataField="intTblTp" HeaderText="intSchedId" />
                             <asp:BoundField DataField="intLBId" HeaderText="Chal Type" />
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
  
  </TBODY></TABLE></asp:Panel> </TD></TR>

        <tr>
            <td>

                <asp:Panel id="pnlGrp" runat="server" Visible="true" BorderColor="#CC3300" BorderStyle="Solid" ><TABLE style="WIDTH: 100%"><TBODY>
            <tr><td>        
          <asp:GridView ID="gdvg" runat="server" Width="325px" ForeColor="#333333" Font-Size="10pt"
                        Font-Names="Verdana" AutoGenerateColumns="False" GridLines="None" CellPadding="2"
                        CellSpacing="5">
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
                        <Columns>

                            <asp:BoundField DataField="numEmpID" HeaderText="AccNo" />
                            <asp:BoundField HeaderText="Year" DataField="intYr" />
                        </Columns>
                        <RowStyle BackColor="#EFF3FB"></RowStyle>
                        <EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                        <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>
                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    </asp:GridView></td></tr>

                    <TR align=center>
<TD  align="center" >
   <asp:DropDownList id="ddlYrGrp" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYrGrp_SelectedIndexChanged" Visible="False" ></asp:DropDownList>
    <asp:Button id="btnGrp" onclick="btnGrp_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Group Calc" Font-Size="10pt" Font-Names="Verdana" Visible="False"></asp:Button>
</TD>
    
  </TR>
  
  </TBODY></TABLE></asp:Panel> 

            </td>
        </tr>
        </TABLE> 
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

