<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_EmpAdd, App_Web_vxnq-4wi" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" style="width: 303px">&nbsp;<asp:Label id="lblHead" runat="server" class="MnHead" Text="Employee_New" ></asp:Label> </TD></TR><TR><TD align=center style="width: 303px"><asp:Panel id="pnlEntry" runat="server" Width="60%" BorderColor="#ccd0e6" BorderStyle="Solid" BorderWidth="1px"><TABLE width="100%"><TBODY><TR><TD align=left><asp:Label id="District" runat="server" Text="District" Cssclass="p3"></asp:Label></TD><TD style="WIDTH: 209px" align=left><asp:DropDownList id="ddlDist" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Label id="LblPr" runat="server" Text="..." Cssclass="p3"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="Lbl" runat="server" Text="Account No." Cssclass="p3"></asp:Label></TD><TD align=left style="width: 209px"><asp:TextBox id="txtAccNo" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="184px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="5" OnTextChanged="txtAccNo_TextChanged"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="Lbl2" runat="server" Text="Name" Cssclass="p3"></asp:Label></TD><TD align=left style="width: 209px"><asp:TextBox id="txtName" runat="server" Width="184px" MaxLength="500"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="lbl3" runat="server" Text="Current District" Cssclass="p3"></asp:Label></TD><TD style="WIDTH: 209px" align=left><asp:DropDownList id="ddlDistCurr" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistCurr_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="lbl4" runat="server" Text=" Current Localbody" Cssclass="p3"></asp:Label></TD><TD style="WIDTH: 209px" align=left><asp:DropDownList id="ddlLb" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlLb_SelectedIndexChanged"></asp:DropDownList></TD></TR>
<TR><TD align=center colspan="2"><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="50px" Text="Save"></asp:Button> </TD></TR>
</TBODY></TABLE></asp:Panel> </TD></TR>

<TR><TD align=center style="width: 303px"><asp:Panel id="pnlEntryU" runat="server" Width="60%" BorderColor="#ccd0e6" BorderStyle="Solid" BorderWidth="1px"><TABLE width="100%"><TBODY><TR><TD align=left><asp:Label id="District1" runat="server" Text="District" Cssclass="p3"></asp:Label></TD><TD style="WIDTH: 140px" align=left><asp:DropDownList id="ddlDistU" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistU_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Label id="LblPrU" runat="server" Text="..." Cssclass="p3"></asp:Label> </TD></TR><TR><TD align=left><asp:Label id="LblU" runat="server" Text="Account No." Cssclass="p3"></asp:Label></TD><TD align=left><asp:TextBox id="txtAccNoU" onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" Width="184px" AutoPostBack="True" CssClass="txtNumeric" MaxLength="5" OnTextChanged="txtAccNoU_TextChanged"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="Lbl2U" runat="server" Text="Name" Cssclass="p3"></asp:Label></TD><TD align=left><asp:TextBox id="txtNameU" runat="server" Width="184px" MaxLength="500"></asp:TextBox></TD></TR><TR><TD align=left><asp:Label id="lblU3" runat="server" Text="Current District" Cssclass="p3"></asp:Label></TD><TD style="WIDTH: 140px" align=left><asp:DropDownList id="ddlDistCurrU" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistCurrU_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left><asp:Label id="lbl4U" runat="server" Text=" Current Localbody" Cssclass="p3"></asp:Label></TD><TD style="WIDTH: 140px" align=left><asp:DropDownList id="ddlLbU" runat="server" Width="184px" AutoPostBack="True" OnSelectedIndexChanged="ddlLbU_SelectedIndexChanged"></asp:DropDownList></TD></TR>
<TR><TD align=center colspan="2"><asp:Button id="btnSaveU" onclick="btnSaveU_Click" runat="server" Width="50px" Text="Save"></asp:Button> </TD></TR>
</TBODY></TABLE></asp:Panel> </TD></TR>

</TBODY></TABLE>
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

</asp:Content>