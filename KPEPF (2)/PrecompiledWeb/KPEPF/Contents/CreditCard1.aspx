<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_CreditCard1, App_Web_m1ijyhfm" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
      <ContentTemplate>
<TABLE width=900 border=0><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="Credit Card"></asp:Label><%--<asp:TextBox id="txtMEMReqID" runat="server" text="0" Visible="False" OnTextChanged="txtMEMReqID_TextChanged"></asp:TextBox>--%></TD></TR><TR><TD align=left style="height: 22px"><asp:Label id="Label1" runat="server" ForeColor="Blue" Font-Bold="True" Text="Account No." Font-Names="Verdana" Font-Size="10pt"></asp:Label> </TD><TD align=left style="height: 22px"><asp:TextBox id="tctAccNo" oncopy="return false" oncut="return false" tabIndex=4 onkeypress="return isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="5" AutoPostBack="True" OnTextChanged="tctAccNo_TextChanged"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="lblClosed" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR><TD><asp:Label id="Label2" runat="server" ForeColor="Blue" Font-Bold="True" Text="Year" Font-Names="Verdana" Font-Size="10pt"></asp:Label> </TD><TD align=left><asp:DropDownList id="ddlYear" tabIndex=11 runat="server" Width="159px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;<asp:Button id="btnLedger" onclick="btnLedger_Click" runat="server" Width="100px" ForeColor="Blue" Text="Ledger" Font-Names="Verdana"></asp:Button> &nbsp;&nbsp; <asp:Button id="btnGen" onclick="btnGen_Click" runat="server" Width="140px" ForeColor="Blue" Text="Correction Report" Font-Names="Verdana" Visible="False"></asp:Button></TD></TR><TR><TD colSpan=2><asp:GridView id="gdvCorr" runat="server" Width="692px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Year"><ItemTemplate>
<asp:TextBox id="txtYr" runat="server" Width="69px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chal Dt"><ItemTemplate>
<asp:TextBox id="txtchlDt" runat="server" Width="65px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAm" runat="server" Width="55px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Rt"><ItemTemplate>
<asp:TextBox id="txtRt" runat="server" Width="50px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Calc"><ItemTemplate>
<asp:TextBox id="txtcal" runat="server" Width="50px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intAmount"><ItemTemplate>
<asp:TextBox id="txtintamt" runat="server" Width="60px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total"><ItemTemplate>
<asp:TextBox id="txttotl" runat="server" Width="60px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="MnthId"><ItemTemplate>
<asp:TextBox id="txtmnthId" runat="server" Width="58px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="BalMnth"><ItemTemplate>
<asp:TextBox id="txtbalmnth" runat="server" Width="53px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="YearId"><ItemTemplate>
<asp:TextBox id="txtyrId" runat="server" Width="57px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Type"><ItemTemplate>
<asp:TextBox id="txttype" runat="server" Width="59px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="balMonth"><ItemTemplate>
<asp:TextBox id="txtBalMth" runat="server" Width="59px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="slno"><ItemTemplate>
<asp:TextBox id="txtSlno" runat="server" Width="59px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>

    <asp:TemplateField HeaderText="yrtype"><ItemTemplate>
<asp:TextBox id="txtyrtype" runat="server" Width="59px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>

    <asp:TemplateField HeaderText="Uid"><ItemTemplate>
<asp:TextBox id="txtuid" runat="server" Width="59px" text="0"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>

</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD style="HEIGHT: 215px" colSpan=2><DIV id="PDE" runat="server"><IFRAME id="iframePDE" frameBorder="1" width="100%" scrolling=auto runat="server"></IFRAME></DIV></TD></TR></TBODY></TABLE>
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

