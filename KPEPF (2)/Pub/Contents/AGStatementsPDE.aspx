<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_AGStatementsPDE, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="AG StatementsPDE"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="Year" runat="server" Text="Year" CssClass="p1"></asp:Label></TD><TD style="HEIGHT: 30px" align=left><asp:DropDownList id="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
 </asp:DropDownList></TD><TD align=left><asp:Label id="Label2" runat="server" Text="Month" CssClass="p1"></asp:Label></TD><TD style="HEIGHT: 27px" align=left><asp:DropDownList id="ddlMnth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMnth_SelectedIndexChanged"></asp:DropDownList></TD></TR>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <TR><TD align=center colSpan=4><asp:Panel id="pnlStmt" runat="Server" Width="100%"><asp:GridView id="gdvAgStmt" runat="server" Width="100%" ForeColor="#333333" DataKeyNames="intDTreasuryID" OnRowCreated="gdvAgStmt_RowCreated" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="2" Font-Names="Verdana" Font-Size="10pt">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl No."></asp:BoundField>
<asp:BoundField DataField="intDTreasuryID" ReadOnly="True" Visible="False"></asp:BoundField>
<asp:BoundField DataField="chvTreasuryName">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Treasury"><FooterTemplate>
            &nbsp;<asp:Label ID="lblTrCrAmt" runat="server" Font-Bold="True" Width="128px"></asp:Label>
        
</FooterTemplate>
<ItemTemplate>
            <asp:TextBox ID="txtTreasuryCredit" runat="server" AutoPostBack="True" CssClass="txtNumeric"
                MaxLength="5" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGCredit_TextChanged"
                Width="81px" Enabled="False" ReadOnly="True"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AG"><FooterTemplate>
    <asp:Label ID="lblAGCrAmt" runat="server" Font-Bold="True" Width="128px"></asp:Label>
</FooterTemplate>
<ItemTemplate>
<asp:TextBox id="txtAGCredit" runat="server" Width="81px" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGCredit_TextChanged"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><FooterTemplate>
            <asp:Label ID="lblTrdrAmt" runat="server" Font-Bold="True" Width="128px"></asp:Label>
        
</FooterTemplate>
<ItemTemplate>
            <asp:TextBox ID="txtTreasryDebit" runat="server" AutoPostBack="True" CssClass="txtNumeric"
                MaxLength="5" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGCredit_TextChanged"
                Width="81px" Enabled="False" ReadOnly="True"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AG"><FooterTemplate>
        <asp:Label ID="lblAGDrAmt" runat="server" Font-Bold="True" Width="128px"></asp:Label>
    
</FooterTemplate>
<ItemTemplate>
        <asp:TextBox ID="txtAGDebit" runat="server" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGDebit_TextChanged" Width="81px"></asp:TextBox>
    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
    <asp:TextBox ID="txtRem" runat="server"></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Mismatch" Visible="False"><ItemTemplate>
            <asp:TextBox ID="txtmismatch" runat="server" AutoPostBack="True" CssClass="txtNumeric"
                MaxLength="5" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGCredit_TextChanged"
                Width="81px"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DTreasuryDetId" Visible="False"><ItemTemplate>
            <asp:TextBox ID="txtDTreasuryDetId" runat="server" AutoPostBack="True" CssClass="txtNumeric"
                MaxLength="5" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAGCredit_TextChanged"
                Width="81px"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></asp:Panel> <BR /><BR /><asp:Panel id="TEDetails" runat="Server" Width="100%"><TABLE border=2><TBODY><TR><TD style="WIDTH: 16%" align=left><asp:Label id="lblCrPlus" class="p1" runat="server" Text="Credit Plus"></asp:Label></TD><TD style="WIDTH: 16%"><asp:TextBox id="txtcrplus" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" OnTextChanged="txtcrplus_TextChanged" MaxLength="5"></asp:TextBox></TD><TD style="WIDTH: 16%"><asp:LinkButton id="lnkCrplus" onclick="lnkCrplus_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD><TD style="WIDTH: 16%" align=left><asp:Label id="lblDebitPlus" class="p1" runat="server" Text="Debit Plus"></asp:Label></TD><TD style="WIDTH: 16%"><asp:TextBox id="TxtDbplus" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" OnTextChanged="TxtDbplus_TextChanged" MaxLength="5"></asp:TextBox></TD><TD style="WIDTH: 16%"><asp:LinkButton id="lnkDBPlus" onclick="lnkDBPlus_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD></TR><TR><TD align=left><asp:Label id="lblCrminus" class="p1" runat="server" Text="Credit Minus"></asp:Label></TD><TD><asp:TextBox id="txtCrminus" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="5"></asp:TextBox></TD><TD><asp:LinkButton id="lnCrMinus" onclick="lnCrMinus_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD><TD align=left><asp:Label id="lblDebtminus" class="p1" runat="server" Text="Debit Minus"></asp:Label></TD><TD><asp:TextBox id="txtDbminus" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="5"></asp:TextBox></TD><TD><asp:LinkButton id="lnkDbMinus" onclick="lnkDbMinus_Click" runat="server" ForeColor="Red" Font-Bold="True" Text="Click Here" Height="23px"></asp:LinkButton> </TD></TR><TR><TD align=left><asp:Label id="lblDaer" class="p1" runat="server" Text="DAER Plus"></asp:Label></TD><TD><asp:TextBox id="txtdaer" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="5"></asp:TextBox></TD><TD></TD><TD><asp:Label id="lblDaerDb" class="p1" runat="server" Text="DAER Minus"></asp:Label></TD><TD><asp:TextBox id="txtdaerDb" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="5"></asp:TextBox></TD></TR><TR><TD>&nbsp;</TD></TR><TR><TD align=left><asp:Label id="lblCredit" class="p1" runat="server" Text="Net Credit"></asp:Label></TD><TD align=right><asp:Label id="lblNetCr" class="p4" runat="server"></asp:Label></TD><TD></TD><TD><asp:Label id="lblDebit" class="p1" runat="server" Text="Net Debit"></asp:Label></TD><TD align=right><asp:Label id="lblNetDr" class="p4" runat="server"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Approval" Height="23px" Visible="False"></asp:LinkButton></TD><TD colSpan=6><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="119px" Text="Save"></asp:Button> </TD></TR></TBODY></TABLE>
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

<%--

  <TR><TD style="HEIGHT: 22px"><asp:Label id="lblDaer" class="p1" runat="server" Text="DAER Plus"></asp:Label></TD>
  <TD style="WIDTH: 154px; HEIGHT: 22px"><asp:TextBox id="txtdaer" runat="server"></asp:TextBox></TD><TD></TD>
  
  <TD style="HEIGHT: 22px"><asp:Label id="lblDaerDb" class="p1" runat="server" Text="DAERMinus"></asp:Label></TD>
  <TD style="WIDTH: 154px; HEIGHT: 22px"><asp:TextBox id="txtdaerDb" runat="server"></asp:TextBox></TD></TR></TBODY></TABLE>
  <TD style="WIDTH: 95px" align="right" /><TABLE><TBODY><TR><TD style="WIDTH: 120px"><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="119px" Text="Save"></asp:Button></TD></TR><TR><TD style="WIDTH: 120px"><asp:Button id="btnTranfer" onclick="btnTranfer_Click" runat="server" Width="119px" Text="Transfer Entry" Visible="False"></asp:Button></TD></TR><TR><TD style="WIDTH: 120px"><asp:Button id="btnClose" runat="server" Width="119px" Text="Close"></asp:Button></TD></TR></TBODY></TABLE><TR />



<TD style="HEIGHT: 16px" align="left" /><asp:Label id="lblCredit" class="p1" runat="server" Text="Net Credit"></asp:Label>  <asp:Label id="lblNetCr" runat="server" Font-Bold="True"></asp:Label>

<asp:Label id="lblDebit" class="p1" runat="server" Text="Net Debit"></asp:Label><asp:Label id="lblNetDr" runat="server" Font-Bold="True"></asp:Label> </asp:Panel></TD></TR><TR></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
--%>
