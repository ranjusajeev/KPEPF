<%@ Page Language="C#" MasterPageFile="~/Contents/MasterPage.master" AutoEventWireup="true" CodeFile="ChalanEdit.aspx.cs" Inherits="Contents_ChalanEdit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=8><asp:Label id="lblHead" runat="server" Text="Chalan and Schedule" CssClass="MnHead"></asp:Label> </TD></TR><TR><TD style="WIDTH: 1029px; HEIGHT: 25px" align=center colSpan=2><asp:Label id="lblType" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR align=center><TD colSpan=8><asp:Label id="lblYear" runat="server" Font-Bold="True" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblDist" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD align=center colSpan=8 style="width:900px"><asp:GridView id="gdvAOApprov" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" width:900px GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo">
<HeaderStyle HorizontalAlign="Center" Width="5px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="5px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left" Width="500px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left" Width="500px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="intChalanNo" HeaderText="Chalan No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Chalan Date"><ItemTemplate>
<asp:TextBox id="txtdate" runat="server" Width="90px" CssClass="datePicker" OnTextChanged="txtdate_TextChanged" Enabled="False"></asp:TextBox>&nbsp; 
</ItemTemplate>

<ItemStyle Width="110px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="90px" CssClass="txtNumeric" ReadOnly="True" MaxLength="5"></asp:TextBox> 
</ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Id" Visible="False"><ItemTemplate>
<asp:Label id="lblChalId" runat="server" Text="Label" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Corr Id" Visible="False"><ItemTemplate>
<asp:Label id="lblCorrId" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="YearId" Visible="False"><ItemTemplate>
<asp:Label id="lblYr" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="MonthId" Visible="False"><ItemTemplate>
<asp:Label id="lblMonth" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Day" Visible="False"><ItemTemplate>
<asp:Label id="lblDay" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EditMode" Visible="False"><ItemTemplate>
<asp:Label id="lblEditMode" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Un P"><%--<HeaderTemplate>
<asp:CheckBox id="Allchk" runat="server" Text="Unposted" ></asp:CheckBox> 
</HeaderTemplate>--%>
<ItemTemplate>
<asp:CheckBox id="chkApp" runat="server"  Width="45px" Enabled="False"></asp:CheckBox> 
</ItemTemplate><ItemStyle Width="50px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted reason"><ItemTemplate>
<asp:DropDownList id="ddlReason" runat="server" width="80px" Enabled="False"></asp:DropDownList> 
</ItemTemplate><ItemStyle Width="90px"></ItemStyle>

<HeaderStyle Font-Names="Verdana" Font-Size="Small" Width="50px"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" Width="50px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnPVal" Visible="False"><ItemTemplate>
<asp:Label id="lblUnP" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR align=center><TD colSpan=9><asp:Label id="lblsch" runat="server" Text="Schedule Details" CssClass="p1"></asp:Label> </TD></TR><TR align=left><TD>&nbsp;&nbsp;&nbsp;<asp:Label id="lblschCnt" runat="server" Text="No. of Entries" CssClass="p1"></asp:Label> <asp:TextBox id="txtCnt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="80px" CssClass="txtNumeric" OnTextChanged="txtCnt_TextChanged" MaxLength="2" AutoPostBack="True"></asp:TextBox> </TD></TR><TR><TD colSpan=4><DIV style="OVERFLOW-X: auto; WIDTH: 900px"><asp:GridView id="gdvAOApprovSched" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl. No."><ItemTemplate>
<asp:Label id="lblSlNo" runat="server"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Acc. No."><ItemTemplate>
<asp:TextBox id="txtAccNo" runat="server" Width="81px" AutoPostBack="True" MaxLength="5" CssClass="txtNumeric" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAccNo_TextChanged"></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:Label id="lblName" runat="server" Width="178px" Text=""></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnIdentified"><ItemTemplate>
<asp:CheckBox id="chkUnIdent" runat="server" Width="1px" ></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Subn."><ItemTemplate>
<asp:TextBox id="txtSubn" Text="0"  oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="63px" AutoPostBack="True" OnTextChanged="txtSubn_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>

<HeaderStyle Width="20px"></HeaderStyle>

<ItemStyle Width="20px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Repay."><ItemTemplate>
<asp:TextBox id="txtRep" Text="0" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="65px" AutoPostBack="True"  OnTextChanged="txtRep_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Arr. PF"><ItemTemplate>
<asp:TextBox id="txtPf" Text="0" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="73px" AutoPostBack="True"  OnTextChanged="txtPf_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Arr. DA"><ItemTemplate>
<asp:TextBox id="txtDa" Text="0" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="69px" AutoPostBack="True"  OnTextChanged="txtDa_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>

    <asp:TemplateField HeaderText="Govt.Order"><ItemTemplate>
<asp:DropDownList id="ddlGo" runat="server" width="150px"></asp:DropDownList> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>


<asp:TemplateField HeaderText="Arr. Pay"><ItemTemplate>
<asp:TextBox id="txtPay" Text="0" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="69px" AutoPostBack="True"  OnTextChanged="txtPay_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>

       <asp:TemplateField HeaderText="From M"><ItemTemplate>
<asp:DropDownList id="ddlFm" runat="server"  AutoPostBack="true" width="70px" OnSelectedIndexChanged="ddlFm_SelectedIndexChanged"></asp:DropDownList> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
     <asp:TemplateField HeaderText="To M"><ItemTemplate>
<asp:DropDownList id="ddlTm" runat="server" AutoPostBack="true" width="70px" OnSelectedIndexChanged="ddlTm_SelectedIndexChanged"></asp:DropDownList> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Total"><ItemTemplate>
<asp:Label id="lblTotal" runat="server" Width="74px" Text="0"></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="SchedMainId" Visible="False"><ItemTemplate>
<asp:Label id="lblSchedMain" runat="server" Text="0"  ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sched Id" Visible="False"><ItemTemplate>
<asp:Label id="lblSched" runat="server" Text="0" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo" Visible="False"><ItemTemplate>
<asp:Label id="lblAccNo" runat="server" Text="0"  ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="SlNo" HeaderText="SlNo" Visible="False"></asp:BoundField>
<asp:TemplateField HeaderText="NewAccNo" Visible="False"><ItemTemplate>
<asp:Label id="lblNewAcc" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="NewTot" Visible="False"><ItemTemplate>
<asp:Label id="lblNewTot" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EditMode" Visible="False"><ItemTemplate>
<asp:Label id="lblEditModeS" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RecNo" Visible="False"><ItemTemplate>
<asp:Label id="lblRecNo" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OldTot" Visible="False"><ItemTemplate>
<asp:Label id="lblOTot" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OldAcc" Visible="False"><ItemTemplate>
<asp:Label id="lblOAcc" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndelete" onclick="btnDelete_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>

    <asp:TemplateField HeaderText="SlNo" Visible="False"><ItemTemplate>
<asp:Label id="lblSlNoNew" runat="server" Text="0"></asp:Label>
</ItemTemplate>
</asp:TemplateField>


 <asp:TemplateField HeaderText="FMO" Visible="False"><ItemTemplate> <asp:Label id="lblFMO" runat="server" Text="0"></asp:Label></ItemTemplate></asp:TemplateField>
 <asp:TemplateField HeaderText="FMN" Visible="False"><ItemTemplate> <asp:Label id="lblFMN" runat="server" Text="0"></asp:Label></ItemTemplate></asp:TemplateField>

 <asp:TemplateField HeaderText="TMO" Visible="False"><ItemTemplate> <asp:Label id="lblTMO" runat="server" Text="0"></asp:Label></ItemTemplate></asp:TemplateField>
 <asp:TemplateField HeaderText="TMN" Visible="False"><ItemTemplate> <asp:Label id="lblTMN" runat="server" Text="0"></asp:Label></ItemTemplate></asp:TemplateField>

</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </DIV></TD></TR><TR><TD style="WIDTH: 90%; HEIGHT: 20px" align="center"><asp:Button id="btnBack" onclick="btnBack_Click" runat="server" Width="150px" Text="Back " Height="19px"></asp:Button> <asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="70px" ForeColor="Navy" Text="Save" Font-Size="Small" Height="20px"></asp:Button> </TD></TR></TBODY></TABLE>
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
    function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
        
        function checkNumOnly(input)
{
   $(input).bind('keyup blur', function () { $(this).val($(this).val().replace(/[^0-9.]/g, '')) }); 
   return true;
}

    </script>
--%></asp:Content>

