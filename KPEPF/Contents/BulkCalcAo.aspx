<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="BulkCalcAo.aspx.cs" Inherits="Contents_BulkCalcAo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
        <TABLE style="WIDTH: 100%"><tr><td style="width: 902px">
<asp:Panel id="pnlB" runat="server" Visible="true" BorderColor="#CC3300" BorderStyle="Solid"><TABLE style="WIDTH: 100%"><TBODY><TR align=center>
<TD  align=left style="height: 25px" >
<asp:Label id="Label9" runat="server" Width="120px" Text="Year" CssClass="p1" Visible="False"></asp:Label>

 <asp:DropDownList id="ddlYearB" tabIndex=4 runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYearB_SelectedIndexChanged" style="height: 20px" Visible="False"></asp:DropDownList>
 &nbsp;&nbsp;&nbsp;
     <asp:Button id="btnCorrCalc" onclick="btnCorrCalc_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Correction" Font-Size="10pt" Font-Names="Verdana"></asp:Button>
   <asp:Button id="btnCalculation" onclick="btnCalculation_Click" runat="server" Width="86px" ForeColor="Blue" Font-Bold="True" Text="Calculation" Font-Size="10pt" Font-Names="Verdana"></asp:Button>
     </TD>
  
    
  </TR>
<%--    <TR align=center>
<TD  align=left style="height: 25px" >
  <asp:Button ID="btnSubmit" runat="server" Text="Submit"
            onclick="btnSubmit_Click" /><asp:Label ID="lblStatus"
            runat="server" Text=""></asp:Label>
</TD>
</TR>--%>
<%--<TR align=center>
<TD  align=left style="height: 25px" >

       <asp:UpdateProgress ID="pbarCard" runat="server"  DynamicLayout="true" AssociatedUpdatePanelID="updatepanel">
            <ProgressTemplate><asp:Image ID="imgProgress" ImageUrl="ProgressImage.gif" runat="server" /> Please Wait... </ProgressTemplate>
       </asp:UpdateProgress>    


</TD>
</TR>--%>
    


 <tr><td align="center" >


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
    
  </TD></TR>
        
        </TABLE> 
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

