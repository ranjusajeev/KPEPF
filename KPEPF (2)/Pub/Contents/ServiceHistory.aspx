<%@ page language="C#" masterpagefile="~/Contents/MasterPage.master" autoeventwireup="true" inherits="Contents_ServiceHistory, App_Web_sldhjcan" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPholder" Runat="Server">
<asp:UpdatePanel ID="updatepanel" runat= "server">
    <ContentTemplate>
<TABLE style="WIDTH: 100%"><TBODY><TR><TD class="TdMnHead" colSpan=3><asp:Label id="lblHead" class="MnHead" runat="server" Text="Service History"></asp:Label> </TD></TR><TR><TD align=center><asp:Label id="Label5" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="Account No." Font-Names="Verdana" Font-Size="10pt" CssClass="p1"></asp:Label> <asp:TextBox id="txtAccNo" oncopy="return false" oncut="return false" tabIndex=3 onkeypress="return  isNumberKey(event)" onpaste="return false" runat="server" MaxLength="5" AutoPostBack="True" CssClass="txtNumeric"></asp:TextBox> <asp:Button id="btnPrint" onclick="btnPrint_Click" runat="server" Width="74px" ForeColor="Blue" Font-Bold="True" Text="Find" Font-Names="Verdana" Font-Size="10pt"></asp:Button> </TD></TR><TR align=center><TD><asp:Label id="lblAccNo" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="..." Font-Names="Verdana" Font-Size="10pt" CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblName" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="..." Font-Names="Verdana" Font-Size="10pt" CssClass="p4"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label id="lblDistName" runat="server" ForeColor="#0000C0" Font-Bold="False" Text="..." Font-Names="Verdana" Font-Size="10pt" CssClass="p4"></asp:Label></TD></TR><TR><TD style="WIDTH: 900px" align=center colSpan=3><asp:GridView id="gdvSerHis" runat="server" Width="792px" ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" Visible="False" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl. No." ApplyFormatInEditMode="True">
<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle Width="200px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Period" HeaderText=" Period">
<ItemStyle Width="200px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> <asp:GridView id="gdvSerHisLedger" runat="server"  ForeColor="#333333" Font-Names="Verdana" Font-Size="10pt" CellSpacing="5" CellPadding="2" GridLines="None" AutoGenerateColumns="False">
<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></FooterStyle>
<Columns>
<asp:BoundField DataField="SlNo" HeaderText="Sl. No." ApplyFormatInEditMode="True">
<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvYear" HeaderText="Year">
<ItemStyle Width="200px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvPeriod" HeaderText="Period">
<ItemStyle Width="300px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="chvEngLBName" HeaderText="Localbody">
<ItemStyle Width="400px" HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
</Columns>

<RowStyle BackColor="#EFF3FB"></RowStyle>

<EditRowStyle BackColor="#2461BF" Wrap="True"></EditRowStyle>

<SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>

<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"></HeaderStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
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
                yearRange: "-10:+0",
      });
//              $( ".datePicker" ).datepicker( "option", "showAnim", "explode");
});

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

