<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ChalanEdit, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD style="HEIGHT: 16px; BACKGROUND-COLOR: #ccd0e6" align=center colSpan=8><asp:Label id="lblHead" runat="server" ForeColor="Navy" Font-Bold="True" Text="Chalan and Schedule" Font-Names="Verdana" Font-Size="10pt"></asp:Label> </TD></TR><TR><TD style="WIDTH: 1029px; HEIGHT: 25px" align=center colSpan=2><asp:Label id="lblType" runat="server" ForeColor="Navy" Font-Bold="True" Text="..." Font-Names="Verdana" Font-Size="10pt"></asp:Label> </TD></TR><TR align=center><TD colSpan=8><asp:Label id="lblYear" runat="server" Font-Bold="True" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblMonth" runat="server" Text="..." CssClass="p4"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblDist" runat="server" Text="..." CssClass="p4"></asp:Label></TD></TR><TR><TD align=center colSpan=8><asp:GridView id="gdvAOApprov" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
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
<ItemStyle HorizontalAlign="Left" Width="1700px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="intChalanNo" HeaderText="Chalan No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Chalan Date"><ItemTemplate>
<asp:TextBox id="txtdate" runat="server" Width="95px" CssClass="datePicker" OnTextChanged="txtdate_TextChanged" AutoPostBack="True"></asp:TextBox>&nbsp; 
</ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="95px" CssClass="txtNumeric" ReadOnly="True" MaxLength="5"></asp:TextBox> 
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
<asp:TemplateField HeaderText="Unposted"><HeaderTemplate>
<asp:CheckBox id="Allchk" runat="server" Text="Unposted" AutoPostBack="True" OnCheckedChanged="Allchk_CheckedChanged"></asp:CheckBox> 
</HeaderTemplate>
<ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged" Width="1px"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted reason"><ItemTemplate>
<asp:DropDownList id="ddlReason" runat="server" width="86px"></asp:DropDownList> 
</ItemTemplate>

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
</asp:GridView> </TD></TR><TR align=center><TD colSpan=9><asp:Label id="lblsch" runat="server" Text="Schedule Details" CssClass="p1"></asp:Label> </TD></TR><TR><TD colSpan=4><asp:GridView id="gdvAOApprovSched" runat="server" Width="692px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2"><Columns>
<asp:TemplateField HeaderText="Sl. No."><ItemTemplate>
<asp:Label id="lblSlNo" runat="server"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Acc. No.">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
<ItemTemplate>
<asp:TextBox id="txtAccNo" runat="server" Width="81px" AutoPostBack="True" MaxLength="5" CssClass="txtNumeric" oncut="return false" oncopy="return false" onpaste="return false" onkeypress="return  isNumberKey(event)" OnTextChanged="txtAccNo_TextChanged"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblName" runat="server" Width="178px" Text="Label"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnIdentified"><ItemTemplate>
<asp:CheckBox id="chkUnIdent" runat="server" Width="1px" Height="2px"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Subn.">
<ItemStyle Width="20px"></ItemStyle>

<HeaderStyle Width="20px"></HeaderStyle>
<ItemTemplate>
<asp:TextBox id="txtSubn" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="63px" AutoPostBack="True" OnTextChanged="txtSubn_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Repay."><ItemTemplate>
<asp:TextBox id="txtRep" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="65px" AutoPostBack="True"  OnTextChanged="txtRep_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="PF"><ItemTemplate>
<asp:TextBox id="txtPf" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="73px" AutoPostBack="True"  OnTextChanged="txtPf_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DA"><ItemTemplate>
<asp:TextBox id="txtDa" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="69px" AutoPostBack="True"  OnTextChanged="txtDa_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Pay"><ItemTemplate>
<asp:TextBox id="txtPay" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="69px" AutoPostBack="True"  OnTextChanged="txtPay_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
<ItemTemplate>
<asp:Label id="lblTotal" runat="server" Width="74px" Text="Label"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="SchedMainId"><ItemTemplate>
<asp:Label id="lblSchedMain" runat="server" Text="Label"  ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="Sched Id"><ItemTemplate>
<asp:Label id="lblSched" runat="server" Text="Label" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="AccNo"><ItemTemplate>
<asp:Label id="lblAccNo" runat="server" Text="Label"  ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="SlNo" Visible="False" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField Visible="False" HeaderText="NewAccNo"><ItemTemplate>
<asp:Label id="lblNewAcc" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="NewTot"><ItemTemplate>
<asp:Label id="lblNewTot" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="EditMode"><ItemTemplate>
<asp:Label id="lblEditModeS" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="RecNo"><ItemTemplate>
<asp:Label id="lblRecNo" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="OldTot"><ItemTemplate>
<asp:Label id="lblOTot" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField Visible="False" HeaderText="OldAcc"><ItemTemplate>
<asp:Label id="lblOAcc" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 50%" align=left><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="50%" ForeColor="Blue" Font-Bold="True" Text="Back to Search" Height="23px"></asp:LinkButton></TD><TD style="WIDTH: 600px" align=left><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="70px" ForeColor="Navy" Text="Save" Font-Size="Small" Height="20px"></asp:Button> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    <script language="javascript" type="text/javascript">
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
</asp:Content>

