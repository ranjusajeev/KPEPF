<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_CreditMinusPDE, App_Web_vxnq-4wi" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" runat="server" Text="Transfer Entry_Credit Minus" CssClass="MnHead"></asp:Label> </TD></TR><TR><TD align=left colSpan=1><asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=center><asp:Panel id="pnlMain" runat="server"><TABLE><TBODY><TR><TD align=left><asp:Label id="lbl11" runat="server" Text="Credit Minus" CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTot" runat="server" Text="..." CssClass="p4" Font-Names="Verdana" Font-Size="10pt"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblTotET" runat="server" Text="Credit Minus  Entered " CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> &nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTotE" runat="server" Text="..." CssClass="p4" Font-Names="Verdana" Font-Size="10pt"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " CssClass="p1" Font-Names="Verdana" Font-Size="10pt"></asp:Label> &nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblBal" runat="server" Text="..." CssClass="p4" Font-Names="Verdana" Font-Size="10pt"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD colSpan=2><asp:GridView id="gdvCM" runat="server" Width="100%" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" OnRowDeleting="gdvCM_RowDeleting" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5"><Columns>
<asp:TemplateField HeaderText="Sl.No">
<HeaderStyle Width="25px" CssClass="cssHeadGridEng"></HeaderStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNoCM" text='<%#Eval("chvTEId") %>' runat="server" Width="100px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtChNCM" text='<%#Eval("intChalNo") %>' runat="server" Width="70px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Date"><ItemTemplate>
<asp:TextBox id="txtChDtCM" text='<%#Eval("dtmChalDate") %>' runat="server" Width="90px" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
<ItemTemplate>
<asp:TextBox id="txtAmtCM" runat="server" Width="70px" MaxLength="7" text='<%#Eval("fltAmount") %>' __designer:wfdid="w1"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sub Treasury"><ItemTemplate>
<asp:DropDownList id="ddlSubTrCM" runat="server" Width="200px" >
            </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Account No"><ItemTemplate>
<asp:TextBox id="txtAcCM"  text='<%#Eval("chvAccNo") %>' runat="server" Width="70px" OnTextChanged="txtAcCM_TextChanged" MaxLength="50" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:TextBox id="txtName"  text='<%#Eval("chvName") %>' runat="server" Width="70px" OnTextChanged="txtAcCM_TextChanged" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtremCM"  text='<%#Eval("chvRemarks") %>' runat="server"  Width="71px"  MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStatusCM" runat="server" Width="71px" ></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="intId"><ItemTemplate>
<asp:TextBox id="txtintId" text='<%#Eval("intId") %>' runat="server" Width="71px" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add">
<ItemStyle Width="15%" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="30px" CssClass="cssHeadGridEng" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btnAddFloorNew" onclick="btnAddFloorNew_Click" runat="server"  ImageUrl="~/images/addrow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
<ItemStyle HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="30px" CssClass="cssHeadGridEng" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btndeleteCr" onclick="btnDeleteCr_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="relMnthWiseId"><ItemTemplate>
<asp:TextBox id="RelMnth" text='<%#Eval("intRelMonthWiseId") %>' runat="server" Width="71px" __designer:wfdid="w28"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="ChalanId"><ItemTemplate>
<asp:TextBox id="txtchalanId" runat="server" Width="71px" __designer:wfdid="w30"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="ChalanAGId"><ItemTemplate>
<asp:TextBox id="txtChalanAGId" runat="server"  Width="71px" ></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR>

<TR> <TD align="left" ><asp:LinkButton id="btnBack" onclick="btnBack_Click" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to AG Statements" Height="23px"></asp:LinkButton> </TD><TD style="WIDTH: 100px" align="left" ><asp:Button id="btnSaveCM" onclick="btnOK_Click" runat="server" Width="73px" ForeColor="Navy" Text="Save" Font-Size="Small" Height="21px"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
   <script type="text/javascript">
function DeleteItem() {
            if (confirm("Are you sure you want to delete ...?")) {
                return true;
            }
            return false;
        }
 </script>
</asp:Content>


