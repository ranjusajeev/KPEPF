<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ChalanEditAg, App_Web_rihpu3hj" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">

<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=9><asp:Label id="lblHead" class="MnHead" runat="server" Text="Chalan and Schedule"></asp:Label> </TD></TR><TR><TD style="WIDTH: 1029px" align=center colSpan=2><asp:Label id="lblType" runat="server" Text="..." CssClass="p4"></asp:Label> </TD></TR><TR align=center><TD colSpan=9>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD></TR><TR><TD align=center colSpan=9><asp:GridView id="gdvAOApprov" runat="server" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True" Enabled="False">
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Sl.No" Visible="False"><ItemTemplate>
<%# Container.DataItemIndex + 1 %>
</ItemTemplate>

<HeaderStyle CssClass="cssHeadGridEng"></HeaderStyle>
</asp:TemplateField>
<%--<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
</asp:BoundField>--%>
<asp:TemplateField HeaderText="Localbody"><ItemTemplate>
<asp:DropDownList id="ddlLb" runat="server" Width="150px"></asp:DropDownList> 
</ItemTemplate>
<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>

<asp:BoundField DataField="chvTreasuryName" HeaderText="Treasury">
<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Chalan No."><ItemTemplate>
<asp:TextBox id="txtNo" runat="server" Width="80px" MaxLength="9" text='<%#Eval("intChalanNo") %>'></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Date"><ItemTemplate>
<asp:TextBox id="txtdate" runat="server" Width="101px" CssClass="datePicker" text='<%#Eval("ChalanDate") %>' ></asp:TextBox>&nbsp; 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Chalan Amount"><ItemTemplate>
<asp:TextBox id="txtAmt" runat="server" Width="97px" MaxLength="6" text='<%#Eval("fltChalanAmt") %>' ReadOnly="True" ></asp:TextBox> 
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
<asp:TemplateField HeaderText="Unposted">
<ItemTemplate>
<asp:CheckBox id="chkApp" runat="server" Width="42px" ></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unposted reason"><ItemTemplate>
<asp:DropDownList id="ddlReason" runat="server"></asp:DropDownList> 
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
</asp:GridView> </TD></TR><TR align=center><TD colSpan=9></TD><TD>&nbsp;</TD></TR><TR align=center><TD class="TdMnHead" colSpan=9><asp:Label id="lblsch" class="MnHead" runat="server" Text="Schedule Details"></asp:Label> </TD></TR>

<TR align="left"><TD> &nbsp;&nbsp;&nbsp;<asp:Label id="lblschCnt" runat="server" Text="No. of Entries" CssClass="p1"></asp:Label> <asp:TextBox id="txtCnt" runat="server" Width="80px" MaxLength="2" ></asp:TextBox> </TD></TR>

<TR align=center><TD colSpan=9>
    
    <DIV style="OVERFLOW-X: auto; WIDTH: 900px">

    <asp:GridView id="gdvAOApprovSched" runat="server" Width="692px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellPadding="2" GridLines="None" AutoGenerateColumns="False" CellSpacing="5" ShowFooter="True" Enabled="False" >
<RowStyle BackColor="#EFF3FB"></RowStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="SlNo"></asp:BoundField>
<asp:TemplateField HeaderText="Acc. No."><ItemTemplate>
<asp:TextBox id="txtAccNo" runat="server" Width="85px" CssClass="txtNumeric" MaxLength="5" ></asp:TextBox> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Name"><ItemTemplate>
<asp:Label id="lblName" runat="server" Width="160px"></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Un Idfd"><ItemTemplate>
<asp:CheckBox id="chkUnIdent" runat="server" Width="3px" Height="2px"></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Subn."><ItemTemplate>
<asp:TextBox id="txtSubn" Text="0" runat="server" Width="54px" MaxLength="5" CssClass="txtNumeric" ></asp:TextBox> 
</ItemTemplate>

<HeaderStyle Width="25px"></HeaderStyle>

<ItemStyle Width="25px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Repay."><ItemTemplate>
<ItemStyle Width="20px"></ItemStyle>
<asp:TextBox id="txtRep" Text="0" runat="server" Width="65px"  CssClass="txtNumeric" MaxLength="5"></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="PF"><ItemTemplate>
<ITEMSTYLE Width="20px" /><asp:TextBox id="txtPf" Text="0" runat="server" Width="59px" CssClass="txtNumeric" MaxLength="5" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DA"><ItemTemplate>
<ITEMSTYLE Width="20px" /><asp:TextBox id="txtDa" Text="0" runat="server" Width="55px" CssClass="txtNumeric" MaxLength="5" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Govt.Order"><ItemTemplate>
<asp:DropDownList id="ddlGo" runat="server" width="150px"></asp:DropDownList> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Pay"><ItemTemplate>
<ITEMSTYLE Width="20px" /><asp:TextBox id="txtPay" Text="0" runat="server" Width="59px" CssClass="txtNumeric"  MaxLength="5" ></asp:TextBox> 
</ItemTemplate>
</asp:TemplateField>


    <asp:TemplateField HeaderText="From M"><ItemTemplate>
<asp:DropDownList id="ddlFm" runat="server" width="70px"></asp:DropDownList> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>
     <asp:TemplateField HeaderText="To M"><ItemTemplate>
<asp:DropDownList id="ddlTm" runat="server" width="70px"></asp:DropDownList> 
</ItemTemplate>

<HeaderStyle Font-Names="Verdana" Font-Size="Small"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Total"><ItemTemplate>
<asp:Label id="lblTotal" runat="server" Width="30px" Text="0" ></asp:Label> 
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="SchedMainId" Visible="False"><ItemTemplate>
<asp:Label id="lblSchedMain" runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sched Id" Visible="False"><ItemTemplate>
<asp:Label id="lblSched"  runat="server" Text="0" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AccNo" Visible="False"><ItemTemplate>
<asp:Label id="lblAccNo"  runat="server" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sl. No." Visible="False"><ItemTemplate>
<asp:Label id="lblSlNo" runat="server" Width="42px" Text="0"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="NewAccNo" Visible="False"><ItemTemplate>
<asp:Label id="lblNewAcc" runat="server" Text="0" ></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="NewTot" Visible="False"><ItemTemplate>
<asp:Label id="lblNewTot"  runat="server" Text="0"></asp:Label>
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
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle Wrap="True" BackColor="#2461BF"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
        </DIV> 
         </TD></TR><TR><TD style="WIDTH: 50%" align=left>


<%--<asp:LinkButton id="btnBack" onclick="btnBack_Click1" runat="server" Width="138px" ForeColor="Blue" Font-Bold="True" Text="Back to Search" Height="23px"></asp:LinkButton>--%>
<asp:Button id="btnBack"  runat="server" Width="53px" Text="Back " Height="19px" OnClick="btnBack_Click" ></asp:Button>


</TD><TD style="WIDTH: 50%" align=left>&nbsp;</TD></TR></TBODY></TABLE>
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
     <script type="text/javascript">
        function DeleteItem() 
        {
            if (confirm("Are you sure you want to delete ...?")) 
            {
                return true;
            }
            return false;
        }
 </script>
 --%>
</asp:Content>
