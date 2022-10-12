<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_DebitMinus, App_Web_vxnq-4wi" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY>
<tr><td  colspan="2" class="TdMnHead" ><asp:Label id="lblHead"  runat="server" Text="Debit Minus" class="MnHead"></asp:Label></td></tr>

<TR><TD style="HEIGHT: 269px"><asp:Panel id="pnlDM" runat="server" Width="100%" Font-Bold="False" Height="50px" Font-Size="12px" GroupingText="Debit Minus"><asp:Label id="lblAmtDM" runat="server" Text=""></asp:Label> <asp:GridView id="gdvDM" runat="server" Width="100%" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNoDM" runat="server" __designer:wfdid="w8"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Voucher No"><ItemTemplate>
<asp:TextBox id="txtVnDM" runat="server" __designer:wfdid="w9"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Voucher date"><ItemTemplate>
<asp:TextBox id="txtVdtDM" runat="server" __designer:wfdid="w10"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtDM" runat="server" Width="115px" __designer:wfdid="w11" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo &amp; Name"><ItemTemplate>
<asp:TextBox id="txtaccno" runat="server" __designer:wfdid="w12"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTrDM" runat="server" __designer:wfdid="w13">
            </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtremDM" runat="server" Width="115px" __designer:wfdid="w14" MaxLength="50" Enabled="False" ReadOnly="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStatusDM" runat="server" __designer:wfdid="w15">
        </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intId"><ItemTemplate>
<asp:TextBox id="txtintId" runat="server" __designer:wfdid="w16"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
<asp:Button id="BtnAddDM" onclick="BtnAddDM_Click" runat="server" Width="54px" Text="Add Row" __designer:wfdid="w17"></asp:Button> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <%-- </asp:Panel>--%><TR /><TD style="WIDTH: 983px; HEIGHT: 70px" align="center" /><TABLE style="WIDTH: 100%"><TBODY><TR style="WIDTH: 100%"><TD align=center colSpan=2><TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="100px" ForeColor="Navy" Text="Back" Height="28px" Font-Size="Small"></asp:Button> </TD><TD style="WIDTH: 100px"><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="96px" ForeColor="Navy" Text="Save" Height="28px" Font-Size="Small"></asp:Button> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

