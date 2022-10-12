<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ChalanEditNew, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=9><asp:Label id="lblHead" class="MnHead" runat="server" Text="Chalan and Schedule"></asp:Label> </TD></TR><TR><TD style="WIDTH: 1029px" align=center colSpan=2><asp:Label id="lblType" runat="server" ForeColor="Navy" Font-Bold="True" Text="..." Font-Size="10pt" Font-Names="Verdana"></asp:Label> </TD></TR><TR align=center><TD colSpan=9><asp:Label id="lblYear" runat="server" Text="..." CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblMonth" runat="server" Text="..." CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblDist" runat="server" Text="..." CssClass="p1"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label id="lblDistt" runat="server" Text="..." CssClass="p1"></asp:Label></TD></TR><TR><TD align=center colSpan=9><asp:GridView id="gdvAOApprov" runat="server" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl.No" Visible="False"><ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>

<HeaderStyle CssClass="cssHeadGridEng"></HeaderStyle>
</asp:TemplateField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Chalan No."><ItemTemplate>
<asp:TextBox id="txtNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="80px" CssClass="txtNumeric" MaxLength="4" __designer:wfdid="w1" text='<%#Eval("intChalanNo") %>'></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Date"><ItemTemplate>
<asp:TextBox id="txtdate" runat="server" Width="101px" CssClass="datePicker" __designer:wfdid="w8" text='<%#Eval("ChalanDate") %>' OnTextChanged="txtdate_TextChanged" AutoPostBack="True"></asp:TextBox>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" runat="server" Width="97px" MaxLength="6" __designer:wfdid="w9" text='<%#Eval("fltChalanAmt") %>' ReadOnly="True"></asp:TextBox> 
</ItemTemplate>
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
<asp:Label id="lblMonthId" runat="server" Text="Label"></asp:Label>
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
<asp:CheckBox id="chkApp" runat="server" Width="42px" __designer:wfdid="w4" AutoPostBack="True" OnCheckedChanged="chkApp_CheckedChanged"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted reason"><ItemTemplate>
<asp:DropDownList id="ddlReason" runat="server" __designer:wfdid="w5"></asp:DropDownList> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR align=center><TD colSpan=9><asp:Label id="lblsch" runat="server" Text="Schedule Details" CssClass="p1"></asp:Label> </TD></TR><TR><TD colSpan=9><asp:GridView id="gdvAOApprovSched" runat="server" Width="692px" ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" ShowFooter="True" CellSpacing="5" AutoGenerateColumns="False" GridLines="None" CellPadding="2">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl. No."><ItemTemplate>
<asp:Label id="lblSlNo" runat="server" Width="42px" __designer:wfdid="w4"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Acc. No."><ItemTemplate>
<asp:TextBox id="txtAccNo" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="81px" __designer:wfdid="w2" AutoPostBack="True" MaxLength="5" CssClass="txtNumeric" OnTextChanged="txtAccNo_TextChanged" text='<%#Eval("chvPF_No") %>'></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:Label id="lblName" text='<%#Eval("chvName") %>' runat="server" Width="178px"></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UnIde ntified"><ItemTemplate>
<asp:CheckBox id="chkUnIdent" runat="server" Width="50px" Height="2px" __designer:wfdid="w5"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Subn."><ItemTemplate>
<asp:TextBox id="txtSubn" oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="54px" __designer:wfdid="w6" AutoPostBack="True" MaxLength="5" CssClass="txtNumeric" OnTextChanged="txtSubn_TextChanged" text='<%#Eval("fltSubnAmt") %>'></asp:TextBox> 
</ItemTemplate>

<HeaderStyle Width="25px"></HeaderStyle>

<ItemStyle Width="25px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Repay."><ItemTemplate>
<ItemStyle Width="25px"></ItemStyle>
<asp:TextBox id="txtRep"  text='<%#Eval("fltRePaymentAmt") %>'  oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="65px" AutoPostBack="True"  OnTextChanged="txtRep_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="PF"><ItemTemplate>
<ItemStyle Width="25px"></ItemStyle>
<asp:TextBox id="txtPf" text='<%#Eval("fltArearPFAmt") %>'  oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="73px" AutoPostBack="True"  OnTextChanged="txtPf_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DA"><ItemTemplate>
<ItemStyle Width="25px"></ItemStyle>
<asp:TextBox id="txtDa" text='<%#Eval("fltArearDA") %>' oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="69px" AutoPostBack="True"  OnTextChanged="txtDa_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Pay"><ItemTemplate>
<ItemStyle Width="25px"></ItemStyle>
<asp:TextBox id="txtPay"  text='<%#Eval("fltArearPay") %>' oncopy="return false" oncut="return false" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="69px" AutoPostBack="True"  OnTextChanged="txtPay_TextChanged" CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Total"><ItemTemplate>
<asp:Label id="lblTotal" text='<%#Eval("TotRem") %>'  runat="server" Width="74px" ></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Add"><ItemTemplate>
<asp:ImageButton id="btnAddFloorNew" onclick="btnAddFloorNew_Click" runat="server"  ImageUrl="~/images/addrow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:ImageButton id="btndeleteCr" onclick="btnDeleteCr_Click"  onclientclick="return DeleteItem()" runat="server"  ImageUrl="~/images/removerow.gif"></asp:ImageButton> 
</ItemTemplate>

<HeaderStyle HorizontalAlign="Center" CssClass="cssHeadGridEng" Width="15%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="SchedMainId" Visible="False"><ItemTemplate>
<asp:Label id="lblSchedMain" runat="server"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sched Id" Visible="False"><ItemTemplate>
<asp:Label id="lblSched" text='<%#Eval("numScheduleID") %>'  runat="server"  ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo" Visible="False"><ItemTemplate>
<asp:Label id="lblAccNo"  runat="server"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="SlNo" HeaderText="SlNo" Visible="False"></asp:BoundField>
<asp:TemplateField HeaderText="NewAccNo" Visible="False"><ItemTemplate>
<asp:Label id="lblNewAcc" text='<%#Eval("numEmpId") %>'   runat="server" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="NewTot" Visible="False"><ItemTemplate>
<asp:Label id="lblNewTot"  runat="server" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="EditMode" Visible="False"><ItemTemplate>
<asp:Label id="lblEditModeS" runat="server" Text="Label"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RecNo" Visible="False"><ItemTemplate>
<asp:Label id="lblRecNo" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OldTot" Visible="False"><ItemTemplate>
<asp:Label id="lblOTot" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="OldAcc" Visible="False"><ItemTemplate>
<asp:Label id="lblOAcc" runat="server" Text="Label"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR><TR><TD style="WIDTH: 50%" align=left><asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Search" Height="23px"></asp:LinkButton></TD><TD style="WIDTH: 50%" align=left><asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Width="70px" ForeColor="Navy" Text="Save" Font-Size="Small" Height="20px"></asp:Button> </TD></TR></TBODY></TABLE>
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
     <script type="text/javascript">
function DeleteItem() {
            if (confirm("Are you sure you want to delete ...?")) {
                return true;
            }
            return false;
        }
 </script>
</asp:Content>
