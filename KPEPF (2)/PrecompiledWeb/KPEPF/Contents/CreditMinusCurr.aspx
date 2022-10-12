<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_CreditMinusCurr, App_Web_1la5evxf" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE><TBODY><TR><TD class="TdMnHead" colSpan=2><asp:Label id="lblHead" runat="server" Text="Transfer Entry_Credit Minus" CssClass="MnHead"></asp:Label> </TD></TR><TR><TD align=left colSpan=1><asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align="right"><asp:Panel id="pnlMain" runat="server" Width="220px"><TABLE><TBODY><TR><TD align=left><asp:Label id="lbl11" runat="server" Text="Credit Minus" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTot" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lblTotET" runat="server" Text="Credit Minus Entered " CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTotE" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblBal" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD colSpan=2><asp:Label id="lblCntCap" runat="server" Text="No. of Rows" CssClass="p1"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:TextBox id="txtCnt" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" CssClass="txtNumeric" MaxLength="2" AutoPostBack="True" OnTextChanged="txtCntRow_TextChanged">
</asp:TextBox> </TD></TR><TR><TD colSpan=2><asp:GridView id="gdvCM" runat="server" Width="100%" ForeColor="#333333" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True" OnRowDeleting="gdvCM_RowDeleting" Font-Size="10pt" Font-Names="Verdana">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="SlNo"><ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            
</ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNoCM" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"  MaxLength="10" Width="100px" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan No"><ItemTemplate>
<asp:TextBox id="txtChNCM"  runat="server" Width="70px" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false"  CssClass="txtNumeric"  MaxLength="9"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Date"><ItemTemplate>
<asp:TextBox id="txtChDtCM" runat="server" Width="90px" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtChDtCM_TextChanged" MaxLength="10"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmtCM" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="70px" CssClass="txtNumeric" OnTextChanged="txtAmtCM_TextChanged" AutoPostBack="True" MaxLength="7"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sub Treasury"><ItemTemplate>
<asp:DropDownList id="ddlSubTrCM" runat="server" Width="150px" >
            </asp:DropDownList> 
</ItemTemplate> <ItemStyle Width="155px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Account No\Name"><ItemTemplate>
<asp:TextBox id="txtAcCM"  runat="server" Width="120px" OnTextChanged="txtAcCM_TextChanged" MaxLength="50" ></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="125px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtremCM" runat="server" Width="136px" MaxLength="50"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlStatusCM" runat="server" Width="71px" ></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="intId" Visible="False"><ItemTemplate>
<asp:Label id="lblintId" runat="server" Width="71px" ></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChalanId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtchalanId" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ChalanAGId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtChalanAGId" runat="server"  Width="71px" ></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView></TD></TR><TR><TD align="center" colspan="2">

<%--<asp:LinkButton id="btnBack" onclick="btnBack_Click" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to AG Statements" Height="23px"></asp:LinkButton>--%> 
<asp:Button id="btnBack"  runat="server" Width="57px" Text="Back " OnClick="btnBack_Click" Height="20px"></asp:Button>

<%--</TD><TD style="WIDTH: 100px" align=left>--%><asp:Button id="btnSaveCM" onclick="btnOK_Click" runat="server" Width="73px" ForeColor="Navy" Text="Save" Font-Size="Small" Height="20px"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
<%--   <script language=javascript type="text/javascript">
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


