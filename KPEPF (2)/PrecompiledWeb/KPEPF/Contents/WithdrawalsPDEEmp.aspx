<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_WithdrawalsPDEEmp, App_Web_4p3ju0t2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR style="WIDTH: 90%"><TD class="TdMnHead" colSpan=4>&nbsp;<asp:Label id="lblHead" class="MnHead" runat="server" Text="Withdrawals_Treasury"></asp:Label> </TD></TR><TR><TD>&nbsp;</TD></TR><TR align=center><TD colSpan=2><asp:Label id="lblYear" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp;&nbsp; &nbsp;<asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:Label id="lblDT" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR><TD>&nbsp;</TD></TR><TR align=center><TD colSpan=3><asp:Label id="lblBillNo" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; ;<asp:Label id="lblBillDt" runat="server" Text="..." CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; ;<asp:Label id="lblBAmt" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR align=left><TD>&nbsp;&nbsp;&nbsp; <asp:Label id="lblschCnt" runat="server" Text="No. of Entries" CssClass="p1"></asp:Label> <asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="80px" CssClass="txtNumeric" OnTextChanged="txtCnt_TextChanged" MaxLength="2" AutoPostBack="True">
 </asp:TextBox> </TD></TR><TR align=center><TD vAlign=top colSpan=3>
     
     <DIV style="OVERFLOW-X: auto; WIDTH: 900px">
     <asp:GridView id="gdvChalanS" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" AutoGenerateColumns="False" GridLines="None" CellPadding="2" CellSpacing="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Acc No."><ItemTemplate>
<asp:TextBox id="txtAccNo" runat="server" Width="84px" CssClass="txtNumeric" Height="22px" OnTextChanged="txtAccNo_TextChanged1" MaxLength="10" AutoPostBack="True"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:Label id="lblName" runat="server" Width="145px" Text=" " Height="24px"></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Un Idenfd"><ItemTemplate>
<asp:CheckBox id="chkUnIdent" runat="server" Width="1px"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" oncopy="reaturn false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="84px" CssClass="txtNumeric" Height="22px" OnTextChanged="txtAmt_TextChanged" MaxLength="6" AutoPostBack="True"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Type"><ItemTemplate>
<asp:DropDownList id="ddlType" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sanction Date"><ItemTemplate>
<asp:TextBox id="txtSDate" runat="server" Width="105px" CssClass="datePicker" Height="21px" OnTextChanged="txtSDate_TextChanged" AutoPostBack="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Withdraw Date"><ItemTemplate>
<asp:TextBox id="txtWDate" runat="server" Width="116px" CssClass="datePicker" Height="21px" MaxLength="10" OnTextChanged="txtWDate_TextChanged" AutoPostBack="True"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Acc No" Visible="False"><ItemTemplate>
<asp:Label id="lblNewAcc" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Old Acc" Visible="False"><ItemTemplate>
<asp:Label id="lblOldAcc" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Old Amt" Visible="False"><ItemTemplate>
<asp:Label id="lblOldAmt" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="WithdrawId" Visible="False"><ItemTemplate>
<asp:Label id="lblWithId" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="PfoWithdrawId" Visible="False"><ItemTemplate>
<asp:Label id="lblWithIdPfo" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPosted" Visible="False"><ItemTemplate>
<asp:CheckBox id="chkUnP" runat="server" Width="51px"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPosted Reason" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlUnP" runat="server"></asp:DropDownList>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EditMode" Visible="False"><ItemTemplate>
<asp:Label id="lblEditMode" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>




<asp:TemplateField HeaderText="OrderNo.& Dt of PrevTA"><ItemTemplate>
<asp:TextBox id="txtODtPrev" runat="server" Width="105px" Height="21px" AutoPostBack="True" OnTextChanged="txtODtPrev_TextChanged" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>

    <asp:TemplateField HeaderText="Amount of PrevTA"><ItemTemplate>
<asp:TextBox id="txtAmtPrev" oncopy="reaturn false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="84px" CssClass="txtNumeric" Height="22px" MaxLength="6" AutoPostBack="True" OnTextChanged="txtAmtPrev_TextChanged" ></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="OrderNo.& Dt of PrevTA" Visible="False"><ItemTemplate>
<asp:Label id="txtODtPrevO" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>

    <asp:TemplateField HeaderText="Amount of PrevTA" Visible="False"><ItemTemplate>
<asp:Label id="txtAmtPrevO" runat="server" Text="0"></asp:Label>
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>
<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng"></HeaderStyle>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>

 <asp:TemplateField HeaderText="OldTp" Visible="False"><ItemTemplate>
<asp:Label id="lblOldTp" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
         </DIV></TD></TR><TR align="center"><TD colspan="2"><asp:Button id="btnBack" onclick="btnBack_Click" runat="server" Width="60px" Text="Back " Height="20px"></asp:Button> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="60px" Text="Save" Height="20px"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
<%--    <script language="javascript" type="text/javascript">
Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()

{
$(".datePicker").datepicker 
          ({
                numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                yearRange: "-56:+0",
      });
              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
});
</script>
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
--%></asp:Content>

