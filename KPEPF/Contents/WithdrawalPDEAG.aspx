<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="WithdrawalPDEAG.aspx.cs" Inherits="Contents_WithdrawalPDEAG" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=5>&nbsp; <asp:Label id="lblHead" class="MnHead" runat="server" Text="Withdrawals_AG"></asp:Label> </TD></TR>
<%--    <TR><TD align="left">&nbsp; <asp:Label id="lblAmt" runat="server"  Text="..." CssClass="p4" Width="100px"></asp:Label> &nbsp; <asp:Label id="lblDate" runat="server"  Text="..." CssClass="p4"></asp:Label> <asp:TextBox id="txtDate" runat="server" Enabled="False" ReadOnly="True" Visible="false" ></asp:TextBox> </TD></TR>--%>
    <TR align=left><TD colspan="4">&nbsp;&nbsp;&nbsp; <asp:Label id="lblschCnt" runat="server" Text="No. of Rows" CssClass="p1" Width="150px"></asp:Label> <asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="80px" CssClass="txtNumeric" AutoPostBack="True" MaxLength="2" OnTextChanged="txtCnt_TextChanged"></asp:TextBox> </TD>

        <TD align="right">&nbsp; <asp:Label id="lblAmt" runat="server"  Text="..." CssClass="p4" Width="100px"></asp:Label> &nbsp; <asp:Label id="lblDate" runat="server"  Text="..." CssClass="p4"></asp:Label> <asp:TextBox id="txtDate" runat="server" Enabled="False" ReadOnly="True" Visible="false" ></asp:TextBox> </TD
    </TR>
    <TR><TD  vAlign=top colSpan=5><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvWithAG" runat="server"  Width="1600px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="1" CellPadding="2" GridLines="None" AutoGenerateColumns="False" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl.No." ></asp:BoundField>
<asp:TemplateField HeaderText="Acc No."><ItemTemplate>
<asp:TextBox id="txtAccNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="80px" CssClass="txtNumeric" AutoPostBack="True" MaxLength="10" OnTextChanged="txtAccNo_TextChanged" __designer:wfdid="w7"></asp:TextBox> 
</ItemTemplate>
    <ItemStyle Width="85px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
&nbsp;<asp:Label id="lblName" runat="server" Width="185px" ></asp:Label> 
</ItemTemplate> <ItemStyle Width="190px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Designation"><ItemTemplate>
<asp:DropDownList id="ddldesig" runat="server" Width="200px" ></asp:DropDownList> 
</ItemTemplate> <ItemStyle Width="205px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Type"><ItemTemplate>
<asp:DropDownList id="ddlType" runat="server" Width="70px" __></asp:DropDownList> 
</ItemTemplate> <ItemStyle Width="75px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Odr No"><ItemTemplate>
<asp:TextBox id="txtOrderNo" runat="server" Width="100px" CssClass="txtNumeric" AutoPostBack="True" MaxLength="10" __designer:wfdid="w11"></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="105px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Odr Date"><ItemTemplate>
&nbsp;<asp:TextBox id="txtOrderDate" runat="server"  Width="95px" CssClass="datePicker" AutoPostBack="True" OnTextChanged="txtOrderDate_TextChanged" __designer:wfdid="w12"></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="105px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" oncopy="return false" oncut="return false" AutoPostBack="true" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="95px" CssClass="txtNumeric" OnTextChanged="txtAmt_TextChanged" __designer:wfdid="w13"></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="100px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Object"><ItemTemplate>
<asp:DropDownList id="ddlpurpose" runat="server"  Width="150px" _></asp:DropDownList> 
</ItemTemplate> <ItemStyle Width="155px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Odr Prev TA"><ItemTemplate>
&nbsp;<asp:TextBox id="txtOrderNoDate" runat="server"  Width="145px" ></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="155px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Amt Prev TA"><ItemTemplate>
<asp:TextBox id="txtAmtPreTa" runat="server" Width="100px" ></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="105px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Balance Prev TA" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox id="txtBalTA" runat="server" Width="70px" ></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="75px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Cons. Amt" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox id="txtConsolidated" runat="server" Width="70px" ></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="75px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Inst" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox id="txtInstNo" runat="server" Width="70px" ></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="75px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Inst. Amt" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox id="txtinstAmt" runat="server" Width="70px" ></asp:TextBox> 
</ItemTemplate> <ItemStyle Width="75px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Un P"><ItemTemplate>
<asp:CheckBox id="chkUnP" runat="server" Width="50px" _AutoPostBack="True" OnCheckedChanged="chkUnP_CheckedChanged"></asp:CheckBox> 
</ItemTemplate> <ItemStyle Width="55px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason"><ItemTemplate>
<asp:DropDownList id="ddlUnP" runat="server" _Enabled="False" Width="150px"></asp:DropDownList> 
</ItemTemplate> <ItemStyle Width="155px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Remarks" Visible="False"><ItemTemplate>
&nbsp;<asp:TextBox id="txtRemarks" runat="server" Width="71px"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Status" Visible="False"><ItemTemplate>
&nbsp;<asp:DropDownList id="ddlStatus" runat="server" Width="71px"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo" Visible="False"><ItemTemplate>
&nbsp;<asp:Label id="lblNewAcc" Text="0" runat="server"> </asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnpostedReasonId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtUnpostedReasonId" Text="0" runat="server" Width="71px" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="WithTypeId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtTypeId" runat="server" Text="0" Width="71px" MaxLength="50"   ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="VoucherId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtVoucherId" runat="server" Width="71px" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="WithId PDE" Visible="False" ><ItemTemplate>
<asp:Label id="lblWithIDPDE" runat="server" Width="71px" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DEsigId" Visible="False"><ItemTemplate>
<asp:TextBox id="txtdesigId" runat="server" Width="71px" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OldAmt" Visible="False"><ItemTemplate>
&nbsp;<asp:Label id="lblOldAmt" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OldAccNo" Visible="False"><ItemTemplate>
&nbsp;<asp:Label id="lblOldAcc" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>


<asp:TemplateField HeaderText="Editmode" Visible="False"><ItemTemplate>
<asp:Label id="lblEditMode" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle HorizontalAlign="Right" BackColor="GradientInactiveCaption" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR>
    <TR><TD ></TD>  </TR>
    <TR><TD align="center" colSpan="4"> <asp:Button id="btnBack" onclick="btnBack_Click" runat="server" Width="60px" Text="Back " Height="20px"></asp:Button> 
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" Width="60px" Height="20px"/></TD>    
    </TR>
     </TBODY></TABLE>
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



