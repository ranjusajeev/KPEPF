<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_Calculation, App_Web_1la5evxf" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY style="WIDTH: 100%"><TR style="WIDTH: 95%"><TD class="TdMnHead"><asp:Label id="lblHead" class="MnHead" runat="server" Text="Calculation "></asp:Label> </TD></TR><TR><TD>&nbsp;</TD></TR><TR style="WIDTH: 95%"><TD align=center><asp:Panel id="pnlB" runat="server" Width="95%"><asp:Label id="lblYear" runat="server" ForeColor="Navy" Font-Bold="True" Text="..." Font-Size="Small" Font-Names="Verdana"></asp:Label> <asp:TextBox id="txtAccNoCa" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" AutoPostBack="True" CssClass="txtNumeric" MaxLength="5" OnTextChanged="txtAccNoCa_TextChanged"></asp:TextBox> <asp:Button id="btnOk" onclick="btnOk_Click" runat="server" Text="View" width="80"></asp:Button> <asp:GridView id="gdvCalc" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True"><Columns>
<asp:BoundField DataField="intAccNo" HeaderText="AccNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="intYearID" HeaderText="intYearID"></asp:BoundField>
<asp:BoundField DataField="chvYear" HeaderText="chvYear"></asp:BoundField>
<asp:BoundField DataField="dtmchalan" HeaderText="dtmchalan"></asp:BoundField>
<asp:BoundField DataField="rtInt" HeaderText="rtInterest"></asp:BoundField>
<asp:BoundField DataField="OrgAmt" HeaderText="OrgAmt"></asp:BoundField>
<asp:TemplateField HeaderText="BalMonth"><ItemTemplate>
<asp:Label id="lblBalMth" runat="server" Text="Label" __designer:wfdid="w1"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="chvCalc">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblCalc" runat="server" Text="0" __designer:wfdid="w3"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="HdnIntAmt">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblHdnIntAmt" runat="server" Text="0" __designer:wfdid="w11"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblTotal" runat="server" Text="0" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="intSlNo" Visible="False" HeaderText="SlNo"></asp:BoundField>
<asp:BoundField DataField="IntAmt" Visible="False" HeaderText="IntAmt">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField Visible="False" HeaderText="TrnType"><ItemTemplate>
<asp:Label id="lblTrnTp" runat="server" Text="Label" __designer:wfdid="w2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></asp:Panel> <asp:Panel id="pnlS" runat="server" Visible="true"><TABLE><TBODY><TR><TD colSpan=4><asp:Label id="lblYearD" runat="server" ForeColor="Navy" Font-Bold="True" Text="..." Visible="False" Font-Size="Small"></asp:Label> </TD></TR><TR><TD style="WIDTH: 40%"><asp:Label id="Label1" runat="server" Text="Acc. No." CssClass="p1"></asp:Label> &nbsp; &nbsp;&nbsp; &nbsp;<asp:TextBox id="txtAccNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="100px" OnTextChanged="txtAccNo_TextChanged" MaxLength="5" CssClass="txtNumeric" AutoPostBack="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblAccNo" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp; &nbsp;&nbsp; &nbsp; <asp:Label id="lblName" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlYearCorr" tabIndex=4 runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlYearCorr_SelectedIndexChanged" style="height: 20px"></asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblCons" CssClass="p4" runat="server" Text="0"></asp:Label>    </TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD colSpan=4>
    <DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvBill" runat="server" Width="1200px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" OnSelectedIndexChanged="gdvBill_SelectedIndexChanged">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<%--<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>--%>
     <asp:TemplateField HeaderText="Sl No." >
<ItemStyle HorizontalAlign="center"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblSln" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="chvType" HeaderText="Type"></asp:BoundField>
<asp:BoundField DataField="chvCorrType" HeaderText="Corr. Type" Visible="False"></asp:BoundField>
<asp:BoundField DataField="chvYear" HeaderText="Year">
    <ItemStyle Width="70px" />
    </asp:BoundField>
<asp:BoundField DataField="chvMonth" HeaderText="Month"></asp:BoundField>
<asp:BoundField DataField="chvEngDistName" HeaderText="District" Visible="False"></asp:BoundField>
<asp:BoundField DataField="LBName" HeaderText="Localbody"></asp:BoundField>
<asp:BoundField DataField="dtmchalan" HeaderText="Chal / Bill" >
    <ItemStyle Width="200px" />
</asp:BoundField>
<asp:BoundField DataField="fltAmountBefore" HeaderText="Amount Before" Visible="False">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
    <asp:TemplateField HeaderText="Corr, amt." Visible="False">
<ItemStyle HorizontalAlign="right"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblCorrAmt" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

        <asp:TemplateField HeaderText="Corr. Type" Visible="False">
<ItemStyle HorizontalAlign="right"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblCorrType" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

    <asp:BoundField DataField="fltCalcAmount" HeaderText="Corr. Amt." >
        <ItemStyle HorizontalAlign="Right" />
    </asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> 
</DIV>
<asp:GridView id="gdvBillCurr" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" OnSelectedIndexChanged="gdvBill_SelectedIndexChanged" Visible="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>

    <asp:TemplateField HeaderText="SlNo"><ItemTemplate>
<asp:Label id="txtslno" runat="server" Width="30px"  ></asp:Label>&nbsp; 
</ItemTemplate> 
</asp:TemplateField>

<asp:BoundField DataField="chvType" HeaderText="Type"></asp:BoundField>
<asp:BoundField DataField="chvCorrType" HeaderText="Corr. Type" Visible="False"></asp:BoundField>
<asp:BoundField DataField="chvYear" HeaderText="Year"></asp:BoundField>
<asp:BoundField DataField="chvMonth" HeaderText="Month"></asp:BoundField>
<asp:BoundField DataField="chvEngDistName" HeaderText="District" Visible="False"></asp:BoundField>
<asp:BoundField DataField="LBName" HeaderText="Localbody"></asp:BoundField>
<asp:BoundField DataField="dtmchalan" HeaderText="Chal / Bill"></asp:BoundField>
<asp:BoundField DataField="fltAmountBefore" HeaderText="Amount Before" Visible="False">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="fltChalanAmt" HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
    <asp:TemplateField HeaderText="Corr. amt.">
<ItemStyle HorizontalAlign="right"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblCorrAmt" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

        <asp:TemplateField HeaderText="Corr. Type" Visible="False">
<ItemStyle HorizontalAlign="right"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblCorrType" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>

</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

