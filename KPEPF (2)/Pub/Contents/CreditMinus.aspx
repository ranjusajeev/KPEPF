
<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_CreditMinus, App_Web_sldhjcan" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY>
<tr><td  colspan="2" class="TdMnHead" ><asp:Label id="lblHead"  runat="server" Text="Credit Minus" class="MnHead"></asp:Label></td></tr>
<TR><TD><asp:Panel id="PnlCM" runat="server" Width="100%" Font-Bold="False" Height="50px" Font-Size="12px" GroupingText="Credit Minus"><asp:Label id="lblAmtCM" runat="server" Text=""></asp:Label> <asp:GridView id="gdvCM" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNoCM" runat="server" __designer:wfdid="w3"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtChNCM" runat="server" __designer:wfdid="w5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Date"><ItemTemplate>
<asp:TextBox id="txtChDtCM" runat="server" __designer:wfdid="w6"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtCM" runat="server" Width="115px" __designer:wfdid="w7" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sub Treasury"><ItemTemplate>
<asp:DropDownList id="ddlSubTrCM" runat="server" __designer:wfdid="w8">
            </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Account No"><ItemTemplate>
<asp:TextBox id="txtAcCM" runat="server" Width="115px" __designer:wfdid="w9" MaxLength="50" OnTextChanged="txtAcCM_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtremCM" runat="server" Width="115px" __designer:wfdid="w10" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStatusCM" runat="server" __designer:wfdid="w11">
        </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intId"><ItemTemplate>
<asp:TextBox id="txtintId" runat="server" __designer:wfdid="w2"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
<asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="54px" Text="Add Row" __designer:wfdid="w12"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <%-- </asp:Panel>--%><TR /><TD style="WIDTH: 983px; HEIGHT: 70px" align="center" /><%--<asp:Panel id="PnlCredit" runat="server" Width="100%">--%><TABLE style="WIDTH: 100%"><TBODY><TR style="WIDTH: 100%"><TD align=center colSpan=2><TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:Button id="btnBackCM" onclick="btnBackCM_Click" runat="server" Width="100px" ForeColor="Navy" Text="Back" Height="28px" Font-Size="Small"></asp:Button> </TD><TD style="WIDTH: 100px"><asp:Button id="btnSaveCM" onclick="btnOK_Click" runat="server" Width="96px" ForeColor="Navy" Text="Save" Height="28px" Font-Size="Small"></asp:Button> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

