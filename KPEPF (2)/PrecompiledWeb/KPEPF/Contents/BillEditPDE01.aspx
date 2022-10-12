<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_BillEdit, App_Web_1la5evxf" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=8><asp:Label id="lblHead" class="MnHead" runat="server" Text="Withdrawals PDE "></asp:Label> </TD></TR>
    <TR><TD style="HEIGHT: 25px" align=center colSpan=4></TD></TR>
  <TR><TD align=left><asp:Label id="Label2" runat="server" ForeColor="Blue" Font-Bold="True" Text="Year" CssClass="p1" Font-Size="10pt" Font-Names="Verdana"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlYear" tabIndex=4 runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD align=left><asp:Label id="Label3" runat="server" ForeColor="Blue" Font-Bold="True" Text="Month" CssClass="p1" Font-Size="10pt" Font-Names="Verdana"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlMonth" runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></TD><TD align=left><asp:Label id="Label1" runat="server" Width="104px" ForeColor="Blue" Font-Bold="True" Text="District" CssClass="p1" Font-Size="10pt" Font-Names="Verdana"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList id="ddlDistrict" runat="server" Width="136px" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> &nbsp;&nbsp;&nbsp;<asp:Label id="lblType" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR align=left><TD>&nbsp;&nbsp;&nbsp;<asp:Label id="lblschCnt" runat="server" Text="No. of Entries" CssClass="p1"></asp:Label> <asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="80px" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtCnt_TextChanged" MaxLength="2"></asp:TextBox> </TD></TR><TR><TD colSpan=6><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvBill" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Acc. No."><ItemTemplate>
<asp:TextBox id="txtAccNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="95px" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtAccNo_TextChanged" MaxLength="5" __designer:wfdid="w9"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="80px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:Label id="lblName" runat="server" Width="145px" Text=""></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnIdent."><ItemTemplate>
<asp:CheckBox id="chkUnIdnt" runat="server" Width="4px"></asp:CheckBox> 
</ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Withdrawal Amt."><ItemTemplate>
<asp:TextBox id="txtAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="70px" CssClass="txtNumeric" AutoPostBack="True" OnTextChanged="txtAmt_TextChanged" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Type"><ItemTemplate>
<asp:DropDownList id="ddlType" runat="server" Width="57px" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList> 
</ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Ordr No."><ItemTemplate>
<asp:TextBox id="txtSanction" runat="server" Width="70px" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Date of Sanction"><ItemTemplate>
<asp:TextBox id="txtDtSanction" runat="server" Width="70px" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtDtSanction_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Date of Withdrawal"><ItemTemplate>
<asp:TextBox id="txtDtWith" runat="server" Width="70px" AutoPostBack="True" CssClass="datePicker" OnTextChanged="txtDtWith_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Consolidate Amt"><ItemTemplate>
<asp:TextBox id="txtCons" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="68px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="6" OnTextChanged="txtCons_TextChanged"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="No. of Inst."><ItemTemplate>
<asp:TextBox id="txtInstNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="52px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="2" OnTextChanged="txtInstNo_TextChanged"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Inst. Amt."><ItemTemplate>
<asp:TextBox id="txtInstAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="53px" CssClass="txtNumeric" MaxLength="4"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
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

<asp:TemplateField HeaderText="WithId" Visible="False"><ItemTemplate>
<asp:Label id="lblWithId" runat="server" Text="0" __designer:wfdid="w10"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Corr Id" Visible="False"><ItemTemplate>
<asp:Label id="lblCorrId" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo" Visible="False"><ItemTemplate>
<asp:Label id="lblAccNo" runat="server">0</asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="NewAcc" Visible="False"><ItemTemplate>
<asp:Label id="lblNewAccNo" runat="server">0</asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EditMode" Visible="False"><ItemTemplate>
<asp:Label id="lblEditMode" runat="server" Text="1"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OldAmt" Visible="False"><ItemTemplate>
<asp:Label id="lblOldAmt" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sl. No." Visible="False"><ItemTemplate>
<asp:Label id="lblSlNo" runat="server" Width="42px"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted" Visible="False"><ItemTemplate>
<asp:CheckBox id="chkUp" runat="server" Width="38px" AutoPostBack="True" Height="29px" OnCheckedChanged="chkUp_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reason" Visible="False"><ItemTemplate>
<asp:DropDownList id="ddlRsn" runat="server" Width="90px" Enabled="False"></asp:DropDownList> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete" Visible="False"><ItemTemplate>
<asp:CheckBox id="chkDel" runat="server" Width="41px"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD align=center colSpan=6><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="70px" ForeColor="Navy" Text="Update" Font-Size="Small" Height="28px"></asp:Button> </TD></TR><%--  </asp:Panel>--%></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
<%--<script language="javascript" type="text/javascript">
Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function ()

{
$(".datePicker").datepicker 
          ({
                numberOfMonths: 1,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
//                yearRange: "-10:+0",
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
    </Script>
--%></asp:Content>

