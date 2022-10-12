<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AG, App_Web_1la5evxf" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" runat="server" Text="AG Statements" CssClass="MnHead"></asp:Label> </TD></TR><TR><TD style="HEIGHT: 30px" align=left><asp:Label id="Year" runat="server" ForeColor="#0000C0" Text="Year" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label></TD><TD style="HEIGHT: 30px" align=left><asp:DropDownList id="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True">
 </asp:DropDownList></TD><TD style="HEIGHT: 30px" align=left><asp:Label id="Label2" runat="server" Width="33px" ForeColor="#0000C0" Text="Month" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label></TD><TD style="HEIGHT: 30px" align=left><asp:DropDownList id="ddlMnth" runat="server" OnSelectedIndexChanged="ddlMnth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblStat" runat="server" Text="..." CssClass="p4"></asp:Label>
     <asp:CheckBox ID="chkShow" CssClass="p1"  runat="server" AutoPostBack="True" OnCheckedChanged="chkShow_CheckedChanged" Text="Show Consolidation" /></TD></TR><TR><TD style="HEIGHT: 204px" align=center colSpan=4><asp:Panel id="pnlStmt" runat="Server" Width="100%" align="center"><asp:GridView id="gdvAgStmt" runat="server" Width="900px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" OnRowCreated="gdvAgStmt_RowCreated" DataKeyNames="intDTreasuryID">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl. No."></asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury  Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:TextBox id="txtTreasuryCredit" runat="server" Width="98px" CssClass="txtNumeric" MaxLength="5" text='<%#Eval("fltAmountTreasuryCr") %>' ReadOnly="True"></asp:TextBox> 
</ItemTemplate><ItemStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="AG"><ItemTemplate>
<asp:TextBox id="txtAGCredit" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="98px" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtAGCredit_TextChanged" MaxLength="8" text='<%#Eval("fltAmountAGCr") %>'></asp:TextBox> 
</ItemTemplate><ItemStyle Width="100px" />

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
            <asp:TextBox ID="txtTreasryDebit"  text='<%#Eval("fltAmountTreasuryDt") %>' runat="server" 
                Width="98px" ReadOnly="True" CssClass="txtNumeric"></asp:TextBox>
        
</ItemTemplate><ItemStyle Width="100px" />

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="AG"><ItemTemplate>
<asp:TextBox id="txtAGDebit" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="98px" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtAGDebit_TextChanged" MaxLength="8" text='<%#Eval("fltAmountAGDt") %>'></asp:TextBox> 
</ItemTemplate><ItemStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
    <asp:TextBox ID="txtRem" Width="168px" text='<%#Eval("chvRemarks") %>' runat="server" ></asp:TextBox>
</ItemTemplate><ItemStyle Width="170px" />
</asp:TemplateField>
<asp:BoundField DataField="intDTreasuryID" ReadOnly="True" Visible="False"></asp:BoundField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></asp:Panel> <BR /><BR /><asp:Panel id="TEDetails" runat="Server" Width="100%"><TABLE border=2><TBODY><TR><TD style="WIDTH: 16%" align=left><asp:Label id="lblCrPlus" class="p1" runat="server" Text="Credit Plus"></asp:Label></TD><TD style="WIDTH: 16%"><asp:TextBox id="txtcrplus" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True" MaxLength="10" OnTextChanged="txtcrplus_TextChanged"></asp:TextBox></TD><TD style="WIDTH: 16%"><asp:LinkButton id="lnkCrplus" onclick="lnkCrplus_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD><TD style="WIDTH: 16%" align=left><asp:Label id="lblDebitPlus" class="p1" runat="server" Text="Debit Plus"></asp:Label></TD><TD style="WIDTH: 16%">
            <asp:TextBox id="TxtDbplus" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True" MaxLength="10" OnTextChanged="TxtDbplus_TextChanged"></asp:TextBox></TD><TD style="WIDTH: 16%"><asp:LinkButton id="lnkDBPlus" onclick="lnkDBPlus_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD></TR><TR><TD align=left><asp:Label id="lblCrminus" class="p1" runat="server" Text="Credit Minus"></asp:Label></TD><TD><asp:TextBox id="txtCrminus" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True" MaxLength="7" OnTextChanged="txtCrminus_TextChanged"></asp:TextBox></TD><TD><asp:LinkButton id="lnCrMinus" onclick="lnCrMinus_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD><TD align=left><asp:Label id="lblDebtminus" class="p1" runat="server" Text="Debit Minus"></asp:Label></TD><TD><asp:TextBox id="txtDbminus" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True" MaxLength="7" OnTextChanged="txtDbminus_TextChanged"></asp:TextBox></TD><TD><asp:LinkButton id="lnkDbMinus" onclick="lnkDbMinus_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD></TR><TR><TD align=left><asp:Label id="lblDaer" class="p1" runat="server" Text="Credit DAER "></asp:Label></TD><TD><asp:TextBox id="txtdaer" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True" MaxLength="7" OnTextChanged="txtdaer_TextChanged"></asp:TextBox></TD><TD>
            <asp:LinkButton id="lnDaerCr" onclick="lnDaerCr_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD><TD align=left><asp:Label id="lblDaerDb" class="p1" runat="server" Text="Debit DAER "></asp:Label></TD><TD><asp:TextBox id="txtdaerDb" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True" MaxLength="7" OnTextChanged="txtdaerDb_TextChanged"></asp:TextBox></TD><TD><asp:LinkButton id="lndaerdt" onclick="lndaerdt_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD></TR><TR><TD align=left><asp:Label id="lblOAO" class="p1" runat="server" Text="Credit OAO "></asp:Label></TD><TD><asp:TextBox id="txtoao" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True" MaxLength="7" OnTextChanged="txtoao_TextChanged"></asp:TextBox></TD><TD>
            <asp:LinkButton id="lnOAOCr" onclick="lnOAOCr_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD><TD align=left><asp:Label id="lblOAODb" class="p1" runat="server" Text="Debit OAO "></asp:Label></TD><TD><asp:TextBox id="txtoaoDb" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" AutoPostBack="True" MaxLength="7" OnTextChanged="txtoaoDb_TextChanged"></asp:TextBox></TD><TD><asp:LinkButton id="lnoaodt" onclick="lnoaodt_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD></TR><TR><TD colspan="6">&nbsp;</TD></TR><TR><TD align=left><asp:Label id="lblCredit" class="p1" runat="server" Text="Net Credit"></asp:Label></TD><TD align=right><asp:Label id="lblNetCr" class="p4" runat="server"></asp:Label></TD><TD></TD><TD><asp:Label id="lblDebit" class="p1" runat="server" Text="Net Debit"></asp:Label></TD><TD align=right><asp:Label id="lblNetDr" class="p4" runat="server"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Approval" Visible="False" Height="23px"></asp:LinkButton></TD><TD colSpan="6" align="center"><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="119px" Text="Save"  Height="23px"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

