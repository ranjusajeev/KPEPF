<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_DebitMinusCurr, App_Web_q2bqv01f" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 50%" class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="Transfer Entry_Debit Minus"></asp:Label> </TD></TR><TR><TD align=left colSpan=1><asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD style="WIDTH: 50%" align=right><asp:Panel id="pnlMain" runat="server"><TABLE><TBODY><TR><TD align=left><asp:Label id="lbl11" runat="server" Text="Debit Minus" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTot" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lblTotET" runat="server" Text="Debit Minus Entered " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTotE" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblBal" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="HEIGHT: 22px" colSpan=2><asp:Label id="lblCntCap" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:TextBox id="txtCnt" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" OnTextChanged="txtCntRow_TextChanged" AutoPostBack="True" MaxLength="2">
</asp:TextBox> </TD></TR><TR><TD colSpan=2><asp:GridView id="gdvDM" runat="server" Width="100%" ForeColor="#333333" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" OnRowDeleting="gdvDM_RowDeleting" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="SlNo"><ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNoDM" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"  MaxLength="10" Width="100px"  __designer:wfdid="w4"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Voucher No"><ItemTemplate>
<asp:TextBox id="txtVnDM" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="78px" CssClass="txtNumeric" MaxLength="4" __designer:wfdid="w6"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Voucher date"><ItemTemplate>
<asp:TextBox id="txtVdtDM" runat="server" Width="85px" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtVdtDM_TextChanged" __designer:wfdid="w18" MaxLength="10"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtDM" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="62px" CssClass="txtNumeric" OnTextChanged="txtAmtDM_TextChanged" AutoPostBack="True" MaxLength="7" __designer:wfdid="w7"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo &amp; Name"><ItemTemplate>
<asp:TextBox id="txtaccno" runat="server" Width="100px" __designer:wfdid="w9"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTrDM" runat="server" Width="164px" __designer:wfdid="w10"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtremDM" runat="server" Width="150px" Enabled="True"  MaxLength="50" __designer:wfdid="w1"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlStatusDM" runat="server" Width="71px" OnSelectedIndexChanged="ddlStatusDM_SelectedIndexChanged">
        </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate>
<asp:Label id="lblintId" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RelMnthwiseId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtRelMnthWiseIddb"  runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="billwiseID" Visible="False"><ItemTemplate>
<asp:TextBox id="txtBillID" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD align="center" colspan="2">

<asp:Button id="btnBack"  runat="server" Width="53px" Text="Back " Height="20px" OnClick="btnBack_Click" ></asp:Button>

<asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="73px" ForeColor="Navy" Text="Save" Font-Size="Small" Height="20px"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
<%--    <script language=javascript type="text/javascript">
function DeleteItem() {
            if (confirm("Are you sure you want to delete ...?")) {
                return true;
            }
            return false;
        }
 
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

