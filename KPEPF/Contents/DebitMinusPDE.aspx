<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="DebitMinusPDE.aspx.cs" Inherits="Contents_DebitMinusPDE" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 50%" class="TdMnHead" colSpan=2><asp:Label id="lblHead" class="MnHead" runat="server" Text="Transfer Entry_Debit Minus"></asp:Label> </TD></TR><TR><TD align=left colSpan=1><asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD style="WIDTH: 50%" align=right><asp:Panel id="pnlMain" runat="server"><TABLE><TBODY><TR><TD align=left><asp:Label id="lbl11" runat="server" Text="Debit Minus" CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTot" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD align=left><asp:Label id="lblTotET" runat="server" Text="Debit Minus Entered " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblTotE" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="lbl12" runat="server" Text="  Balance " CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;</TD><TD align=right><asp:Label id="lblBal" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR>
    
  
    <TR><TD colSpan=2>
        <div style="OVERFLOW-X: auto; WIDTH: 900px">
   <asp:GridView id="gdvDM" runat="server" Width="1200px" ForeColor="#333333" datakeynames="intId" OnRowDeleting="gdvDM_RowDeleting" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5">       
 <%--<asp:GridView id="gdvDM" runat="server" Width="100%" ForeColor="#333333" datakeynames="intId" OnRowDeleting="gdvDM_RowDeleting" Font-Size="10pt" Font-Names="Verdana">--%>
    <Columns>
<asp:TemplateField HeaderText="Sl.No">
<ItemStyle Width="25px"></ItemStyle>
<HeaderStyle Width="25px" CssClass="cssHeadGridEng"></HeaderStyle>
<ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TE NO"><ItemTemplate>
<asp:TextBox id="txtTeNoDM" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"  MaxLength="10" Width="120px" text='<%#Eval("chvTEId") %>' __designer:wfdid="w19"></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="120px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Voucher No"><ItemTemplate>
<asp:TextBox id="txtVnDM" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="100px" CssClass="txtNumeric" text='<%#Eval("intVchrNo") %>' __designer:wfdid="w6"></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Voucher date"><ItemTemplate>
<asp:TextBox id="txtVdtDM" runat="server" CssClass="datePicker" Width="100px" text='<%#Eval("dtmVchrDate") %>' __designer:wfdid="w20" MaxLength="10" AutoPostBack="True" OnTextChanged="txtVdtDM_TextChanged"></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
<ItemTemplate> <ItemStyle Width="100px" />
<asp:TextBox id="txtAmtDM" runat="server" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" CssClass="txtNumeric"  Width="90px" MaxLength="7" text='<%#Eval("fltAmount") %>'></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo &amp; Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
<ItemTemplate> <ItemStyle Width="200px" />
<asp:TextBox id="txtaccno" text='<%#Eval("chvAccNo") %>' runat="server" Width="190px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Treasury"><ItemTemplate>
<asp:DropDownList id="ddlTrDM" runat="server" Width="161px" __designer:wfdid="w8"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
<asp:TextBox id="txtremDM" runat="server" Width="190px" text='<%#Eval("chvRemarks") %>' __designer:wfdid="w21" MaxLength="50" ></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="200px" />
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Status"><ItemTemplate>
<asp:DropDownList id="ddlStatusDM" runat="server" Width="71px" OnSelectedIndexChanged="ddlStatusDM_SelectedIndexChanged">
        </asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="IntID"><ItemTemplate>
<asp:TextBox id="txtintId"   text='<%#Eval("intId") %>'  runat="server" visible="false" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add">
<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="50px" CssClass="cssHeadGridEng" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btnAddFloorNew" onclick="btnAddFloorNew_Click" runat="server"  ImageUrl="~/images/addrow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="50px" CssClass="cssHeadGridEng" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="RelMnthwiseId"><ItemTemplate>
<asp:TextBox id="txtRelMnthWiseIddb"  runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="billwiseID"><ItemTemplate>
<asp:TextBox id="txtBillID" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV> </TD></TR><TR><TD align="center" colspan="2">

<%--<asp:LinkButton id="btnBack" onclick="btnBack_Click" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to AG Statements" Height="23px"></asp:LinkButton>--%> 
<asp:Button id="btnBack"  runat="server" Width="53px" Text="Back " Height="19px" OnClick="btnBack_Click" ></asp:Button>


<asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="73px" ForeColor="Navy" Text="Save" Font-Size="Small" Height="21px"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
<%--     <script language=javascript type="text/javascript">
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
--%>
</asp:Content>
