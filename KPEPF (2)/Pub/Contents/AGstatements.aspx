<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AG, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>

<TABLE style="WIDTH: 100%"><TBODY>

<TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" runat="server" CssClass="MnHead" Text="AG Statements" ></asp:Label> </TD></TR><TR><TD style="HEIGHT: 30px" align=left><asp:Label id="Year" runat="server" ForeColor="#0000C0" Text="Year" Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label></TD><TD style="HEIGHT: 30px" align=left><asp:DropDownList id="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
 </asp:DropDownList></TD><TD style="HEIGHT: 30px" align=left><asp:Label id="Label2" runat="server" Width="33px" ForeColor="#0000C0" Text="Month" Font-Size="10pt" Font-Names="Verdana" CssClass="p1"></asp:Label></TD><TD style="HEIGHT: 30px" align=left><asp:DropDownList id="ddlMnth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMnth_SelectedIndexChanged"></asp:DropDownList></TD></TR>
 
  
  <TR><TD style="HEIGHT: 204px" align=center colSpan=4>
 
     <asp:Panel id="pnlStmt" runat="Server" Width="100%"><asp:GridView id="gdvAgStmt" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="2" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True" OnRowCreated="gdvAgStmt_RowCreated" DataKeyNames="intDTreasuryID" >
<FooterStyle BackColor="GradientInactiveCaption" ForeColor="White" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo"></asp:BoundField>
<asp:BoundField DataField="intDTreasuryID" Visible="False" ReadOnly="True"></asp:BoundField>
<asp:BoundField DataField="chvTreasuryName">
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
    <asp:TemplateField HeaderText="Treasury">
        <ItemTemplate>
            <asp:TextBox ID="txtTreasuryCredit"  text='<%#Eval("fltAmountTreasuryCr") %>' runat="server" 
                MaxLength="5" CssClass="txtNumeric"
                Width="83px" ReadOnly="True"></asp:TextBox>
        </ItemTemplate>
    </asp:TemplateField>
<asp:TemplateField HeaderText="AG">
<ItemStyle Width="150px" HorizontalAlign="Left"></ItemStyle>
<HeaderStyle Width="150px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox id="txtAGCredit" text='<%#Eval("fltAmountAGCr") %>'  runat="server" Width="81px" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True"  OnTextChanged="txtAGCredit_TextChanged"></asp:TextBox> 
</ItemTemplate>
<FooterTemplate>
    <asp:Label ID="lblAGCrAmt" runat="server" Font-Bold="True" Width="168px"></asp:Label>
</FooterTemplate>
</asp:TemplateField>
    <asp:TemplateField HeaderText="Treasury">
        <ItemTemplate>
            <asp:TextBox ID="txtTreasryDebit"  text='<%#Eval("fltAmountTreasuryDt") %>' runat="server" 
                Width="69px" ReadOnly="True" CssClass="txtNumeric"></asp:TextBox>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Right" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="AG">
    <ItemTemplate>
        <asp:TextBox ID="txtAGDebit" text='<%#Eval("fltAmountAGDt") %>' runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" OnTextChanged="txtAGDebit_TextChanged" Width="77px"></asp:TextBox>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Label ID="lblAGDrAmt" runat="server" Font-Bold="True" Width="140px"></asp:Label>
    </FooterTemplate>
    </asp:TemplateField>
<asp:TemplateField HeaderText="Remarks" >
<ItemTemplate>
    <asp:TextBox ID="txtRem" runat="server" Width="151px"></asp:TextBox>
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
</asp:Panel>  <asp:Panel id="TEDetails" runat="Server" Width="100%">

<table><tr>

<td align ="left"><asp:Label id="lblCrPlus" class="p1" runat="server" Text="CreditPlus"></asp:Label></td>
<td><asp:TextBox id="txtcrplus" runat="server"  MaxLength="5" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"></asp:TextBox></td>
<td><asp:LinkButton id="lnkCrplus" onclick="lnkCrplus_Click" runat="server" ForeColor="Blue" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </td>

<td align ="left"><asp:Label id="lblDebitPlus" class="p1" runat="server" Text="DebitPlus"></asp:Label></td>
<td><asp:TextBox id="TxtDbplus" runat="server"  MaxLength="5" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"></asp:TextBox></td>
<td><asp:LinkButton id="lnkDBPlus" onclick="lnkDBPlus_Click" runat="server" ForeColor="Blue" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </td>
</tr>
<TR><TD align ="left"><asp:Label id="lblCrminus" class="p1" runat="server" Text="CreditMinus"></asp:Label></TD>
<TD><asp:TextBox id="txtCrminus" runat="server" MaxLength="5" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"></asp:TextBox></TD>
  <TD><asp:LinkButton id="lnCrMinus" onclick="lnCrMinus_Click" runat="server" ForeColor="Blue" Font-Bold="True" Text="Click Here" Height="23px" ></asp:LinkButton> </TD>
  <TD align ="left"><asp:Label id="lblDebtminus" class="p1" runat="server" Text="DebitMinus"></asp:Label></TD>
  <TD><asp:TextBox id="txtDbminus" runat="server" MaxLength="5" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"></asp:TextBox></TD>
  <TD><asp:LinkButton id="lnkDbMinus" onclick="lnkDbMinus_Click" runat="server" ForeColor="Blue" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD>
  
</TR>

<TR>
<TD align ="left"><asp:Label id="lblDaer" class="p1" runat="server" Text="DAER Plus"></asp:Label></TD>
  <TD ><asp:TextBox id="txtdaer" runat="server" MaxLength="5" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"></asp:TextBox></TD><TD></TD>
  
  <TD ><asp:Label id="lblDaerDb" class="p1" runat="server" Text="DAERMinus"></asp:Label></TD>
  <TD ><asp:TextBox id="txtdaerDb" runat="server" MaxLength="5" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"></asp:TextBox></TD>
  </TR>
  <tr><td>&nbsp;</td></tr>
  <tr><td align ="left">
  <asp:Label id="lblCredit" class="p1" runat="server" Text="Net Credit"></asp:Label></TD>
  <TD align="right">  <asp:Label id="lblNetCr" runat="server" class="p4"></asp:Label></TD>
  <td></td>
  <TD ><asp:Label id="lblDebit" class="p1" runat="server" Text="Net Debit"></asp:Label></TD>
  <TD  align="right"><asp:Label id="lblNetDr" runat="server" class="p4"></asp:Label>
  
  </td></tr>
  <tr><td colspan ="6">
  <asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="119px" Text="Save"></asp:Button>
  </td></tr>
  
</table>

</asp:Panel></td></tr>

</TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
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
</asp:Content>

